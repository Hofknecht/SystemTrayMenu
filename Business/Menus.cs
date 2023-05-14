// <copyright file="Menus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using Microsoft.Win32;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Handler;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.Menu;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class Menus : IDisposable
    {
        private readonly Dispatcher dispatchter = Dispatcher.CurrentDispatcher;
        private readonly BackgroundWorker workerMainMenu = new();
        private readonly List<BackgroundWorker> workersSubMenu = new();
        private readonly WaitToLoadMenu waitToOpenMenu = new();
        private readonly KeyboardInput keyboardInput;
        private readonly JoystickHelper? joystickHelper;
        private readonly List<FileSystemWatcher> watchers = new();
        private readonly List<EventArgs> watcherHistory = new();
        private readonly DispatcherTimer timerShowProcessStartedAsLoadingIcon = new();
        private readonly DispatcherTimer timerStillActiveCheck = new();
        private readonly DispatcherTimer waitLeave = new();
        private DateTime deactivatedTime = DateTime.MinValue;
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private TaskbarPosition taskbarPosition = new WindowsTaskbar().Position;
        private bool showMenuAfterMainPreload;
        private Menu? mainMenu;

        public Menus()
        {
            keyboardInput = new();
            if (!keyboardInput.RegisterHotKey(Settings.Default.HotKey))
            {
                Settings.Default.HotKey = string.Empty;
                Settings.Default.Save();
            }

            keyboardInput.HotKeyPressed += () => SwitchOpenClose(false, false);
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowSelectionChanged += waitToOpenMenu.RowSelectionChanged;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;

            workerMainMenu.WorkerSupportsCancellation = true;
            workerMainMenu.DoWork += LoadMenu;
            workerMainMenu.RunWorkerCompleted += LoadMainMenuCompleted;

            waitToOpenMenu.StopLoadMenu += WaitToOpenMenu_StopLoadMenu;
            void WaitToOpenMenu_StopLoadMenu()
            {
                foreach (BackgroundWorker workerSubMenu in workersSubMenu.
                    Where(w => w.IsBusy))
                {
                    workerSubMenu.CancelAsync();
                }

                LoadStopped?.Invoke();
            }

            waitToOpenMenu.StartLoadMenu += StartLoadMenu;
            void StartLoadMenu(RowData rowData)
            {
                if (!IsMainUsable)
                {
                    return;
                }

                Menu? menu = mainMenu?.SubMenu;
                int nextLevel = rowData.Level + 1;
                while (menu != null)
                {
                    if (menu.Level == nextLevel)
                    {
                        break;
                    }

                    menu = menu.SubMenu;
                }

                // sanity check not creating same sub menu twice
                if (menu?.RowDataParent != rowData)
                {
                    Create(new(rowData), rowData.Path); // Level 1+ Sub Menu (loading)

                    BackgroundWorker? workerSubMenu = workersSubMenu.
                        Where(w => !w.IsBusy).FirstOrDefault();
                    if (workerSubMenu == null)
                    {
                        workerSubMenu = new BackgroundWorker
                        {
                            WorkerSupportsCancellation = true,
                        };
                        workerSubMenu.DoWork += LoadMenu;
                        workerSubMenu.RunWorkerCompleted += LoadSubMenuCompleted;
                        workersSubMenu.Add(workerSubMenu);
                    }

                    workerSubMenu.RunWorkerAsync(rowData);
                }
            }

            waitToOpenMenu.MouseEnterOk += MouseEnterOk;
            waitToOpenMenu.CloseMenu += (menu) => HideOldMenu(menu);

            if (Settings.Default.SupportGamepad)
            {
                joystickHelper = new();
                joystickHelper.KeyPressed += (key, modifiers) =>
                {
                    if (IsMainUsable)
                    {
                        Menu? menu = GetActiveMenu(mainMenu) ?? mainMenu;
                        menu?.Dispatcher.Invoke(keyboardInput.CmdKeyProcessed, new object[] { menu, key, modifiers });
                    }
                };
            }

            // Timer to check after activation if the application lost focus and close/fadeout windows again
            timerStillActiveCheck.Interval = TimeSpan.FromMilliseconds(Settings.Default.TimeUntilClosesAfterEnterPressed + 20);
            timerStillActiveCheck.Tick += (sender, e) => StillActiveTick();
            void StillActiveTick()
            {
                timerStillActiveCheck.Stop();
                if (!IsActiveApp())
                {
                    FadeHalfOrOutIfNeeded();
                }
            }

            waitLeave.Interval = TimeSpan.FromMilliseconds(Settings.Default.TimeUntilCloses);
            waitLeave.Tick += (_, _) =>
            {
                waitLeave.Stop();
                FadeHalfOrOutIfNeeded();
            };

            CreateWatcher(Config.Path, false);
            foreach (var pathAndFlags in DirectoryHelpers.GetAddionalPathsForMainMenu())
            {
                CreateWatcher(pathAndFlags.Path, pathAndFlags.Recursive);
            }

            void CreateWatcher(string path, bool recursiv)
            {
                try
                {
                    FileSystemWatcher watcher = new()
                    {
                        Path = path,
                        NotifyFilter = NotifyFilters.Attributes |
                        NotifyFilters.DirectoryName |
                        NotifyFilters.FileName |
                        NotifyFilters.LastWrite,
                        Filter = "*.*",
                    };
                    watcher.Created += WatcherProcessItem;
                    watcher.Deleted += WatcherProcessItem;
                    watcher.Renamed += WatcherProcessItem;
                    watcher.Changed += WatcherProcessItem;
                    watcher.IncludeSubdirectories = recursiv;
                    watcher.EnableRaisingEvents = true;
                    watchers.Add(watcher);
                }
                catch (Exception ex)
                {
                    Log.Warn($"Failed to {nameof(CreateWatcher)}: {path}", ex);
                }
            }

            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        internal event Action? LoadStarted;

        internal event Action? LoadStopped;

        private enum OpenCloseState
        {
            Default,
            Opening,
            Closing,
        }

        [MemberNotNullWhen(true, nameof(mainMenu))]
        private bool IsMainUsable => mainMenu?.IsUsable ?? false;

        public void Dispose()
        {
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
            workerMainMenu.Dispose();
            foreach (BackgroundWorker worker in workersSubMenu)
            {
                worker.Dispose();
            }

            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.Created -= WatcherProcessItem;
                watcher.Deleted -= WatcherProcessItem;
                watcher.Renamed -= WatcherProcessItem;
                watcher.Changed -= WatcherProcessItem;
                watcher.Dispose();
            }

            waitToOpenMenu.Dispose();
            keyboardInput.Dispose();
            joystickHelper?.Dispose();
            timerShowProcessStartedAsLoadingIcon.Stop();
            timerStillActiveCheck.Stop();
            waitLeave.Stop();
            mainMenu?.Close();
        }

        internal static void OpenFolder(string? path = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Config.Path;
            }

            Log.ProcessStart(path);
        }

        internal void SwitchOpenCloseByTaskbarItem()
        {
            // User started with taskbar or clicked on taskbar: remember to open menu after preload has finished
            showMenuAfterMainPreload = true;
            SwitchOpenClose(true, true);
            timerStillActiveCheck.Start();
        }

        internal void FirstStartInBackground()
        {
            dispatchter.Invoke(() => SwitchOpenClose(false, true));
        }

        internal void SwitchOpenClose(bool byClick, bool allowPreloading)
        {
            // Ignore open close events during main preload #248
            if (IconReader.IsPreloading && !allowPreloading)
            {
                // User pressed hotkey or clicked on notifyicon: remember to open menu after preload has finished
                showMenuAfterMainPreload = true;
                return;
            }

            waitToOpenMenu.MouseActive = byClick;
            if (byClick &&
                !Config.AlwaysOpenByPin &&
                (DateTime.Now - deactivatedTime).TotalMilliseconds < 200)
            {
                // By click on notifyicon the menu gets deactivated and closed
            }
            else if (string.IsNullOrEmpty(Config.Path))
            {
                // Case when Folder Dialog open
            }
            else
            {
                if (openCloseState == OpenCloseState.Opening ||
                    ((mainMenu?.Visibility ?? Visibility.Collapsed) == Visibility.Visible && openCloseState == OpenCloseState.Default))
                {
                    openCloseState = OpenCloseState.Closing;
                    MenusFadeOut();
                    StopWorker();
                    if (IsVisibleAnyMenu(mainMenu) == null)
                    {
                        openCloseState = OpenCloseState.Default;
                    }
                }
                else
                {
                    openCloseState = OpenCloseState.Opening;
                    StartWorker();
                }
            }

            deactivatedTime = DateTime.MinValue;
        }

        internal void StartWorker()
        {
            if (Settings.Default.GenerateShortcutsToDrives)
            {
                GenerateDriveShortcuts.Start();
            }

            if (!workerMainMenu.IsBusy)
            {
                LoadStarted?.Invoke();
                workerMainMenu.RunWorkerAsync(null);
            }
        }

        internal void StopWorker()
        {
            if (workerMainMenu.IsBusy)
            {
                workerMainMenu.CancelAsync();
            }
        }

        private static Menu? IsVisibleAnyMenu(Menu? menu)
        {
            while (menu != null)
            {
                if (menu.Visibility == Visibility.Visible)
                {
                    break;
                }

                menu = menu.SubMenu;
            }

            return menu;
        }

        private static Menu? IsMouseOverAnyMenu(Menu? menu)
        {
            while (menu != null)
            {
                if (menu.IsMouseOver())
                {
                    break;
                }

                menu = menu.SubMenu;
            }

            return menu;
        }

        private static Menu? GetActiveMenu(Menu? menu)
        {
            while (menu != null)
            {
                if (menu.IsActive || menu.IsKeyboardFocusWithin)
                {
                    break;
                }

                menu = menu.SubMenu;
            }

            return menu;
        }

        private static void HideOldMenu(Menu menuToShow)
        {
            Menu? menuPrevious = menuToShow.ParentMenu;
            if (menuPrevious != null)
            {
                menuPrevious.SubMenu?.HideWithFade(true);

                menuPrevious.RefreshSelection();
            }
        }

        private static void LoadMenu(object? sender, DoWorkEventArgs eDoWork)
        {
            BackgroundWorker? workerSelf = sender as BackgroundWorker;
            RowData? rowData = eDoWork.Argument as RowData;
            string path = rowData?.ResolvedPath ?? Config.Path;

            MenuData menuData = new(rowData);
            DirectoryHelpers.DiscoverItems(workerSelf, path, ref menuData);
            if (menuData.DirectoryState != MenuDataDirectoryState.Undefined &&
                workerSelf != null && rowData == null)
            {
                // After success of MainMenu loading: never run again
                workerSelf.DoWork -= LoadMenu;
            }

            eDoWork.Result = menuData;
        }

        private void LoadMainMenuCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            keyboardInput.ResetSelectedByKey();
            LoadStopped?.Invoke();

            if (e.Result == null)
            {
                Menu? menu = mainMenu;
                if (menu != null)
                {
                    menu.SelectedItem = null;

                    menu.RelocateOnNextShow = true;

                    menu.ShowWithFade(false, true);
                }
            }
            else
            {
                // First time the main menu gets loaded
                MenuData menuData = (MenuData)e.Result;
                switch (menuData.DirectoryState)
                {
                    case MenuDataDirectoryState.Valid:
                        if (IconReader.IsPreloading)
                        {
                            Menu menu = Create(menuData, Config.Path); // Level 0 Main Menu

                            IconReader.IsPreloading = false;
                            if (showMenuAfterMainPreload)
                            {
                                menu.ShowWithFade(false, false);
                            }
                        }
                        else
                        {
                            mainMenu?.ShowWithFade(false, true);
                        }

                        break;
                    case MenuDataDirectoryState.Empty:
                        MessageBox.Show(Translator.GetText("Your root directory for the app does not exist or is empty! Change the root directory or put some files, directories or shortcuts into the root directory."));
                        OpenFolder();
                        Config.SetFolderByUser();
                        AppRestart.ByConfigChange();
                        break;
                    case MenuDataDirectoryState.NoAccess:
                        MessageBox.Show(Translator.GetText("You have no access to the root directory of the app. Grant access to the directory or change the root directory."));
                        OpenFolder();
                        Config.SetFolderByUser();
                        AppRestart.ByConfigChange();
                        break;
                    case MenuDataDirectoryState.Undefined:
                        Log.Info($"{nameof(MenuDataDirectoryState)}.{nameof(MenuDataDirectoryState.Undefined)}");
                        break;
                    default:
                        break;
                }
            }

            openCloseState = OpenCloseState.Default;
        }

        private void LoadSubMenuCompleted(object? senderCompleted, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null || !IsMainUsable)
            {
                return;
            }

            MenuData menuData = (MenuData)e.Result;
            Menu? menu = mainMenu.SubMenu;
            while (menu != null)
            {
                if (menu.Level == menuData.Level)
                {
                    break;
                }

                menu = menu.SubMenu;
            }

            if (menu == null)
            {
                return;
            }

            if (menuData.DirectoryState != MenuDataDirectoryState.Undefined)
            {
                // Sub Menu (completed)
                menu.AddItemsToMenu(menuData.RowDatas, menuData.DirectoryState, true);
                AdjustMenusSizeAndLocation(menu.Level);
            }
            else
            {
                // TODO: Main menu should destroy sub menu(s?) when it becomes unusable
                menu.HideWithFade(false);

                // TODO: Remove when setting SubMenu of RowData notifies about value change
                menu.ParentMenu?.RefreshSelection();
            }
        }

        private bool IsActiveApp() => GetActiveMenu(mainMenu) != null || (App.TaskbarLogo?.IsActive ?? false);

        private Menu Create(MenuData menuData, string path)
        {
            Menu menu = new(menuData, path);

            menu.MenuScrolled += () => AdjustMenusSizeAndLocation(menu.Level + 1); // TODO: Only update vertical location while scrolling?
            menu.MouseLeave += (_, _) =>
            {
                // Restart timer
                waitLeave.Stop();
                waitLeave.Start();
            };
            menu.MouseEnter += (_, _) => waitLeave.Stop();
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;

            menu.SearchTextChanging += Menu_SearchTextChanging;
            void Menu_SearchTextChanging()
            {
                waitToOpenMenu.MouseActive = false;
            }

            menu.SearchTextChanged += Menu_SearchTextChanged;
            void Menu_SearchTextChanged(Menu menu, bool isSearchStringEmpty, bool causedByWatcherUpdate)
            {
                menu.SelectedItem = null;
                if (!isSearchStringEmpty)
                {
                    ListView dgv = menu.GetDataGridView();
                    if (dgv.Items.Count > 0)
                    {
                        keyboardInput.SelectByMouse(menu, (ListViewItemData)dgv.Items[0]);
                    }
                }

                AdjustMenusSizeAndLocation(menu.Level + 1);

                // if any open menu close
                if (!causedByWatcherUpdate)
                {
                    Menu? menuToClose = menu.SubMenu;
                    if (menuToClose != null)
                    {
                        HideOldMenu(menuToClose);
                    }
                }
            }

            menu.UserDragsMenu += Menu_UserDragsMenu;
            void Menu_UserDragsMenu(Menu mainMenu)
            {
                Menu? menu = mainMenu.SubMenu;
                if (menu != null)
                {
                    // TODO: menus array not updated? Remove any way? (Call HideOldMenu within Menu_MouseDown direcly?)
                    HideOldMenu(menu);
                }
            }

            menu.Deactivated += Deactivate;
            void Deactivate(object? sender, EventArgs e)
            {
                if (openCloseState == OpenCloseState.Opening)
                {
                    Log.Info("Ignored Deactivate, because openCloseState == OpenCloseState.Opening");
                }
                else if (!Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed)
                {
                    FadeHalfOrOutIfNeeded();
                    if (!IsActiveApp())
                    {
                        deactivatedTime = DateTime.Now;
                    }
                }
            }

            menu.Activated += (sender, e) => Activated();
            void Activated()
            {
                // Bring transparent menus back
                mainMenu?.ActivateWithFade(true);

                timerStillActiveCheck.Stop();
                timerStillActiveCheck.Start();
            }

            menu.IsVisibleChanged += (sender, _) => MenuVisibleChanged((Menu)sender);
            menu.RowSelectionChanged += waitToOpenMenu.RowSelectionChanged;
            menu.CellMouseEnter += waitToOpenMenu.MouseEnter;
            menu.CellMouseLeave += waitToOpenMenu.MouseLeave;
            menu.CellMouseDown += (menu, itemData) => MouseEnterOk(menu, itemData);
            menu.CellOpenOnClick += waitToOpenMenu.ClickOpensInstantly;
            menu.ClosePressed += MenusFadeOut;

            if (menu.Level == 0)
            {
                // Main Menu
                mainMenu = menu;
                menu.Loaded += (s, e) => ExecuteWatcherHistory();
            }
            else
            {
                // Sub Menu (loading)
                if (IsMainUsable)
                {
                    menu.ShowWithFade(!IsActiveApp(), false);
                    menu.RefreshSelection();
                }
            }

            return menu;
        }

        private void MenuVisibleChanged(Menu menu)
        {
            if (menu.IsUsable)
            {
                AdjustMenusSizeAndLocation(menu.Level);

                if (menu.Level == 0)
                {
                    menu.ResetSearchText();
                    menu.Activate();
                }
            }

            if (menu.Visibility != Visibility.Visible && menu.Level != 0)
            {
                menu.Close();
            }

            if (IsVisibleAnyMenu(mainMenu) == null)
            {
                IconReader.ClearCacheWhenLimitReached();

                openCloseState = OpenCloseState.Default;
            }
        }

        private void MouseEnterOk(Menu menu, ListViewItemData itemData)
        {
            if (IsMainUsable)
            {
                keyboardInput.SelectByMouse(menu, itemData);
            }
        }

        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e)
        {
            dispatchter.Invoke(() =>
            {
                if (IsMainUsable)
                {
                    Menu? menu = mainMenu;
                    if (menu != null)
                    {
                        menu.RelocateOnNextShow = true;
                    }
                }
            });
        }

        private void FadeHalfOrOutIfNeeded()
        {
            if (IsMainUsable)
            {
                if (!IsActiveApp())
                {
                    if (Settings.Default.StaysOpenWhenFocusLost && IsMouseOverAnyMenu(mainMenu) != null)
                    {
                        if (!keyboardInput.IsSelectedByKey)
                        {
                            mainMenu?.ShowWithFade(true, true);
                        }
                    }
                    else if (Config.AlwaysOpenByPin)
                    {
                        mainMenu?.ShowWithFade(true, true);
                    }
                    else
                    {
                        MenusFadeOut();
                    }
                }
            }
        }

        private void MenusFadeOut()
        {
            openCloseState = OpenCloseState.Closing;

            mainMenu?.HideWithFade(true);

            Config.AlwaysOpenByPin = false;
        }

        private void GetScreenBounds(out Rect screenBounds, out bool useCustomLocation, out StartLocation startLocation)
        {
            if (Settings.Default.AppearAtMouseLocation)
            {
                screenBounds = NativeMethods.Screen.FromPoint(NativeMethods.Screen.CursorPosition);
                useCustomLocation = false;
            }
            else if (Settings.Default.UseCustomLocation)
            {
                screenBounds = NativeMethods.Screen.FromPoint(new(
                    Settings.Default.CustomLocationX,
                    Settings.Default.CustomLocationY));

                useCustomLocation = screenBounds.Contains(
                    new Point(Settings.Default.CustomLocationX, Settings.Default.CustomLocationY));
            }
            else
            {
                screenBounds = NativeMethods.Screen.PrimaryScreen;
                useCustomLocation = false;
            }

            // Only apply taskbar position change when no menu is currently open
            WindowsTaskbar taskbar = new();
            if (IsMainUsable && mainMenu.SubMenu == null)
            {
                taskbarPosition = taskbar.Position;
            }

            // Shrink the usable space depending on taskbar location
            switch (taskbarPosition)
            {
                case TaskbarPosition.Left:
                    screenBounds.X += taskbar.Size.Width;
                    screenBounds.Width -= taskbar.Size.Width;
                    startLocation = StartLocation.BottomLeft;
                    break;
                case TaskbarPosition.Right:
                    screenBounds.Width -= taskbar.Size.Width;
                    startLocation = StartLocation.BottomRight;
                    break;
                case TaskbarPosition.Top:
                    screenBounds.Y += taskbar.Size.Height;
                    screenBounds.Height -= taskbar.Size.Height;
                    startLocation = StartLocation.TopRight;
                    break;
                case TaskbarPosition.Bottom:
                default:
                    screenBounds.Height -= taskbar.Size.Height;
                    startLocation = StartLocation.BottomRight;
                    break;
            }

            if (Settings.Default.AppearAtTheBottomLeft)
            {
                startLocation = StartLocation.BottomLeft;
            }
        }

        private void AdjustMenusSizeAndLocation(int startLevel)
        {
            GetScreenBounds(out Rect screenBounds, out bool useCustomLocation, out StartLocation startLocation);

            Menu? menu = mainMenu;
            Menu? menuPredecessor = null;

            while (menu != null)
            {
                if (startLevel <= menu.Level)
                {
                    menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation, useCustomLocation);
                }
                else
                {
                    // Make sure further calculations of this menu access updated values (later used as predecessor)
                    menu.UpdateLayout();
                }

                if (!Settings.Default.AppearAtTheBottomLeft &&
                    !Settings.Default.AppearAtMouseLocation &&
                    !Settings.Default.UseCustomLocation &&
                    menu.Level == 0)
                {
                    const double overlapTolerance = 4D;

                    // Remember width of the initial menu as we don't want to overlap with it
                    if (taskbarPosition == TaskbarPosition.Left)
                    {
                        screenBounds.X += (int)menu.Width - overlapTolerance;
                    }

                    screenBounds.Width -= (int)menu.Width - overlapTolerance;
                }

                menuPredecessor = menu;
                menu = menu.SubMenu;
            }
        }

        private void ExecuteWatcherHistory()
        {
            foreach (var fileSystemEventArgs in watcherHistory)
            {
                WatcherProcessItem(watchers, fileSystemEventArgs);
            }

            watcherHistory.Clear();
        }

        private void WatcherProcessItem(object sender, EventArgs e)
        {
            Menu? menu = mainMenu;

            // Store event in history as long as menu is not loaded
            if (menu?.Dispatcher.Invoke(() => !menu.IsLoaded) ?? true)
            {
                watcherHistory.Add(e);
                return;
            }

            if (e is RenamedEventArgs renamedEventArgs)
            {
                menu.Dispatcher.Invoke(() => RenameItem(menu, renamedEventArgs));
            }
            else if (e is FileSystemEventArgs fileSystemEventArgs)
            {
                if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Deleted)
                {
                    menu.Dispatcher.Invoke(() => DeleteItem(menu, fileSystemEventArgs));
                }
                else if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Created)
                {
                    menu.Dispatcher.Invoke(() => CreateItem(menu, fileSystemEventArgs));
                }
            }
        }

        private void RenameItem(Menu menu, RenamedEventArgs e)
        {
            try
            {
                List<RowData> rowDatas = new();
                foreach (ListViewItemData item in menu.GetDataGridView().Items)
                {
                    RowData rowData = item.data;
                    if (rowData.Path.StartsWith($"{e.OldFullPath}"))
                    {
                        string path = rowData.Path.Replace(e.OldFullPath, e.FullPath);
                        FileAttributes attr = File.GetAttributes(path);
                        bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                        if (isFolder)
                        {
                            string? dirpath = Path.GetDirectoryName(path);
                            if (string.IsNullOrEmpty(dirpath))
                            {
                                continue;
                            }

                            path = dirpath;
                        }

                        RowData rowDataRenamed = new(isFolder, rowData.IsAdditionalItem, 0, path);
                        FolderOptions.ReadHiddenAttributes(rowDataRenamed.Path, out bool hasHiddenFlag, out bool isDirectoryToHide);
                        if (isDirectoryToHide)
                        {
                            continue;
                        }

                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowDataRenamed.HiddenEntry = hasHiddenFlag;
                        rowDataRenamed.ReadIcon(true);
                        rowDatas.Add(rowDataRenamed);
                    }
                    else
                    {
                        rowDatas.Add(rowData);
                    }
                }

                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                menu.SelectedItem = null;
                menu.AddItemsToMenu(rowDatas, null, true);
                menu.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(RenameItem)}: {e.OldFullPath} {e.FullPath}", ex);
            }
        }

        private void DeleteItem(Menu menu, FileSystemEventArgs e)
        {
            try
            {
                ListView? dgv = menu.GetDataGridView();
                List<ListViewItemData> rowsToRemove = new();

                foreach (ListViewItemData item in dgv.ItemsSource)
                {
                    RowData rowData = item.data;
                    if (rowData.Path == e.FullPath ||
                        rowData.Path.StartsWith($"{e.FullPath}\\"))
                    {
                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowsToRemove.Add(item);
                    }
                }

                foreach (ListViewItemData rowToRemove in rowsToRemove)
                {
                    ((IEditableCollectionView)dgv.Items).Remove(rowToRemove);
                }

                menu.SelectedItem = null;
                menu.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(DeleteItem)}: {e.FullPath}", ex);
            }
        }

        private void CreateItem(Menu menu, FileSystemEventArgs e)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(e.FullPath);
                bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                bool isAddionalItem = Path.GetDirectoryName(e.FullPath) != Config.Path;
                RowData rowData = new(isFolder, isAddionalItem, 0, e.FullPath);
                FolderOptions.ReadHiddenAttributes(rowData.Path, out bool hasHiddenFlag, out bool isDirectoryToHide);
                if (isDirectoryToHide)
                {
                    return;
                }

                rowData.HiddenEntry = hasHiddenFlag;
                rowData.ReadIcon(true);

                var items = menu.GetDataGridView().Items;
                List<RowData> rowDatas = new(items.Count + 1) { rowData };
                foreach (ListViewItemData item in items)
                {
                    rowDatas.Add(item.data);
                }

                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                menu.SelectedItem = null;
                menu.AddItemsToMenu(rowDatas, null, true);
                menu.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(CreateItem)}: {e.FullPath}", ex);
            }
        }
    }
}
