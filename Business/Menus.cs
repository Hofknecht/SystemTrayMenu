// <copyright file="Menus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Win32;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;
    using Menu = SystemTrayMenu.UserInterface.Menu;
    using StartLocation = SystemTrayMenu.UserInterface.Menu.StartLocation;

    internal class Menus : IDisposable
    {
        private readonly AppNotifyIcon menuNotifyIcon = new();
        private readonly BackgroundWorker workerMainMenu = new();
        private readonly List<BackgroundWorker> workersSubMenu = new();
        private readonly WaitToLoadMenu waitToOpenMenu = new();
        private readonly KeyboardInput keyboardInput = new();
        private readonly List<FileSystemWatcher> watchers = new();
        private readonly List<EventArgs> watcherHistory = new();
        private readonly DispatcherTimer timerShowProcessStartedAsLoadingIcon = new();
        private readonly DispatcherTimer timerStillActiveCheck = new();
        private readonly DispatcherTimer waitLeave = new();
        private readonly Menu mainMenu;

        private TaskbarPosition taskbarPosition = TaskbarPosition.Unknown;
        private bool mainMenuPreloading = true;
        private bool showMenuAfterMainPreload;
        private TaskbarLogo? taskbarLogo;
        private DateTime lastUserSwitchOpenClose = DateTime.Now;

        public Menus()
        {
            SingleAppInstance.Wakeup += SwitchOpenCloseByHotKey;
            menuNotifyIcon.Click += () => UserSwitchOpenClose(true);

            if (!keyboardInput.RegisterHotKey(Settings.Default.HotKey))
            {
                Settings.Default.HotKey = string.Empty;
                Settings.Default.Save();
            }

            keyboardInput.HotKeyPressed += SwitchOpenCloseByHotKey;
            keyboardInput.RowSelectionChanged += waitToOpenMenu.RowSelectionChanged;
            keyboardInput.EnterPressed += waitToOpenMenu.OpenSubMenuByKey;

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

                menuNotifyIcon.LoadingStop();
            }

            waitToOpenMenu.MouseSelect += keyboardInput.SelectByMouse;

            // Timer to check after activation if the application lost focus and close/fadeout windows again
            timerStillActiveCheck.Interval = TimeSpan.FromMilliseconds(Settings.Default.TimeUntilClosesAfterEnterPressed + 20);
            timerStillActiveCheck.Tick += (sender, e) => StillActiveTick();
            void StillActiveTick()
            {
                timerStillActiveCheck.Stop();
                FadeHalfOrOutIfNeeded();
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

            mainMenu = new(null, Config.Path);
        }

        public void Dispose()
        {
            SingleAppInstance.Wakeup -= SwitchOpenCloseByHotKey;
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
            timerShowProcessStartedAsLoadingIcon.Stop();
            timerStillActiveCheck.Stop();
            waitLeave.Stop();
            taskbarLogo?.Close();
            menuNotifyIcon.Dispose();
            mainMenu.Close();
        }

        internal static void OpenFolder(string path) => Log.ProcessStart(path);

        internal void Startup()
        {
            if (Settings.Default.ShowInTaskbar)
            {
                taskbarLogo = new();
                taskbarLogo.Show();
                taskbarLogo.Activated += (_, _) => UserSwitchOpenClose(true);
            }

            SwitchOpenClose();
        }

        internal void UserSwitchOpenClose(bool byClick)
        {
            if (mainMenuPreloading)
            {
                showMenuAfterMainPreload = true;
                return;
            }

            DateTime now = DateTime.Now;
            if ((now - lastUserSwitchOpenClose).TotalMilliseconds < 500)
            {
                // Prevent open/close spamming
                return;
            }

            lastUserSwitchOpenClose = now;

            waitToOpenMenu.MouseActive = byClick;

            SwitchOpenClose();
        }

        internal void SwitchOpenClose()
        {
            if (workerMainMenu.IsBusy)
            {
                // Stop current loading process of main menu
                workerMainMenu.CancelAsync();
                menuNotifyIcon.LoadingStop();
            }
            else if (mainMenu.Visibility == Visibility.Visible)
            {
                // Main menu is visible, hide all menus
                mainMenu.HideWithFade(true);
            }
            else
            {
                // Main menu is hidden or even not created at all, (create and) show it
                if (Settings.Default.GenerateShortcutsToDrives)
                {
                    // PK: Once or actually on every startup?
                    // MH: e.g. usb device can change each startup, so currently every startup.
                    // in future we need here something without creating files
                    GenerateDriveShortcuts.Start();
                }

                menuNotifyIcon.LoadingStart();
                workerMainMenu.RunWorkerAsync(null);
            }
        }

        internal void KeyPressed(Key key, ModifierKeys modifiers)
        {
            // Look for a valid menu that is visible, active and has focus
            if (mainMenu.Visibility == Visibility.Visible)
            {
                Menu? menu = mainMenu;
                do
                {
                    if (menu.IsActive || menu.IsKeyboardFocusWithin)
                    {
                        // Send the keys to the active menu
                        menu.Dispatcher.Invoke(keyboardInput.CmdKeyProcessed, new object[] { menu, key, modifiers });
                        return;
                    }

                    menu = menu.SubMenu;
                }
                while (menu != null);
            }
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
            menuNotifyIcon.LoadingStop();

            if (e.Result == null)
            {
                mainMenu.SelectedItem = null;
                mainMenu.RelocateOnNextShow = true;
                mainMenu.ShowWithFade(false, true);
                mainMenu.textBoxSearch.Focus();
            }
            else
            {
                // First time the main menu gets loaded
                MenuData menuData = (MenuData)e.Result;
                switch (menuData.DirectoryState)
                {
                    case MenuDataDirectoryState.Valid:
                        if (mainMenuPreloading)
                        {
                            InitializeMenu(mainMenu, menuData.RowDatas); // Level 0 Main Menu

                            mainMenuPreloading = false;
                            if (showMenuAfterMainPreload)
                            {
                                mainMenu.ShowWithFade(false, false);
                            }
                        }
                        else
                        {
                            mainMenu.ShowWithFade(false, true);
                        }

                        break;
                    case MenuDataDirectoryState.Empty:
                        MessageBox.Show(Translator.GetText("Your root directory for the app does not exist or is empty! Change the root directory or put some files, directories or shortcuts into the root directory."));
                        OpenFolder(Config.Path);
                        Config.SetFolderByUser();
                        AppRestart.ByConfigChange();
                        break;
                    case MenuDataDirectoryState.NoAccess:
                        MessageBox.Show(Translator.GetText("You have no access to the root directory of the app. Grant access to the directory or change the root directory."));
                        OpenFolder(Config.Path);
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
        }

        private void LoadSubMenuCompleted(object? senderCompleted, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null || mainMenu.Visibility != Visibility.Visible)
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
                // There will be some layout, size and position changes.
                // Just hide the inner controls for a moment until all changes have been applied.
                menu.windowFrame.Visibility = Visibility.Hidden;
                menu.AddItemsToMenu(menuData.RowDatas, menuData.DirectoryState);
                AdjustMenusSizeAndLocation(menu.Level);
                menu.windowFrame.Visibility = Visibility.Visible;
            }
            else
            {
                // TODO: Main menu should destroy sub menu(s?) when it becomes unusable
                menu.HideWithFade(false);

                // TODO: Remove when setting SubMenu of RowData notifies about value change
                menu.ParentMenu?.RefreshSelection();
            }
        }

        private void InitializeMenu(Menu menu, List<RowData> rowDatas)
        {
            // As we are usually in loading state here, we do not provide a state.
            // However, when the main menu loads, we know it is valid and we can enter desired state directly.
            menu.AddItemsToMenu(rowDatas, menu.Level == 0 ? MenuDataDirectoryState.Valid : null);

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
                        keyboardInput.SelectByMouse((RowData)dgv.Items[0]);
                    }
                }

                AdjustMenusSizeAndLocation(menu.Level + 1);

                if (!causedByWatcherUpdate)
                {
                    // if there is any open sub menu, close it
                    menu.SubMenu?.HideWithFade(true);
                    menu.RefreshSelection();
                }
            }

            menu.Deactivated += Deactivate;
            void Deactivate(object? sender, EventArgs e)
            {
                // TODO: Does this check make any sense here?
                if (!Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed)
                {
                    FadeHalfOrOutIfNeeded();
                }
            }

            menu.Activated += (sender, e) => Activated();
            void Activated()
            {
                // Bring transparent menus back
                mainMenu.ActivateWithFade(true);

                timerStillActiveCheck.Stop();
                timerStillActiveCheck.Start();
            }

            menu.IsVisibleChanged += (sender, _) => MenuVisibleChanged((Menu)sender);
            menu.RowSelectionChanged += waitToOpenMenu.RowSelectionChanged;
            menu.CellMouseEnter += waitToOpenMenu.MouseEnter;
            menu.CellMouseLeave += waitToOpenMenu.MouseLeave;
            menu.CellMouseDown += keyboardInput.SelectByMouse;
            menu.CellOpenOnClick += waitToOpenMenu.OpenSubMenuByMouse;

            if (menu.Level == 0)
            {
                // Main Menu
                menu.Loaded += (s, e) => ExecuteWatcherHistory();
            }
            else
            {
                // Sub Menu (loading)
                menu.ShowWithFade(!App.IsActiveApp, false);
                menu.RefreshSelection();
            }

            menu.StartLoadSubMenu += StartLoadSubMenu;
            void StartLoadSubMenu(RowData rowData)
            {
                if (mainMenu.Visibility != Visibility.Visible)
                {
                    return;
                }

                Menu? menu = mainMenu.SubMenu;
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
                    InitializeMenu(new(rowData, rowData.Path), new()); // Level 1+ Sub Menu (loading)

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
        }

        private void MenuVisibleChanged(Menu menu)
        {
            if (menu.Visibility == Visibility.Visible)
            {
                AdjustMenusSizeAndLocation(menu.Level);

                if (menu.Level == 0)
                {
                    menu.ResetSearchText();
                    menu.Activate();
                }
            }
            else if (menu.Level != 0)
            {
                // Close down non-visible sub menus
                menu.Close();
            }
            else
            {
                // Non-visible main menu, do some housekeeping
                IconReader.ClearCacheWhenLimitReached();
            }
        }

        private void SwitchOpenCloseByHotKey() => mainMenu.Dispatcher.Invoke(() => UserSwitchOpenClose(false));

        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e) =>
            mainMenu.Dispatcher.Invoke(() => mainMenu.RelocateOnNextShow = true);

        private void FadeHalfOrOutIfNeeded()
        {
            if (!App.IsActiveApp && mainMenu.Visibility == Visibility.Visible)
            {
                if (Settings.Default.StaysOpenWhenFocusLost && IsMouseOverAnyMenu(mainMenu) != null)
                {
                    if (!keyboardInput.IsSelectedByKey)
                    {
                        mainMenu.ShowWithFade(true, true);
                    }
                }
                else if (Config.AlwaysOpenByPin)
                {
                    mainMenu.ShowWithFade(true, true);
                }
                else
                {
                    mainMenu.HideWithFade(true);
                }
            }
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

            // Shrink the usable space depending on taskbar location
            WindowsTaskbar taskbar = new();
            taskbarPosition = taskbar.Position;
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

        private void AdjustLocationOnWatcherUpdate(Menu menu)
        {
            // Force refresh of view, let layout settle and then update position based on new size
            menu.RefreshDataGridView();
            menu.UpdateLayout();
            AdjustMenusSizeAndLocation(menu.Level);
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
            // Store event in history as long as menu is not loaded
            if (mainMenu.Dispatcher.Invoke(() => !mainMenu.IsLoaded))
            {
                watcherHistory.Add(e);
                return;
            }

            if (e is RenamedEventArgs renamedEventArgs)
            {
                mainMenu.Dispatcher.Invoke(() => RenameItem(mainMenu, renamedEventArgs));
            }
            else if (e is FileSystemEventArgs fileSystemEventArgs)
            {
                if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Deleted)
                {
                    mainMenu.Dispatcher.Invoke(() => DeleteItem(mainMenu, fileSystemEventArgs));
                }
                else if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Created)
                {
                    mainMenu.Dispatcher.Invoke(() => CreateItem(mainMenu, fileSystemEventArgs));
                }
            }
        }

        private void RenameItem(Menu menu, RenamedEventArgs e)
        {
            try
            {
                List<RowData> rowDatas = new();
                foreach (RowData rowData in menu.GetDataGridView().Items.SourceCollection)
                {
                    // TODO: Check if this check is correct as it looks like wronge entries might be modified as well?
                    if (rowData.Path.StartsWith($"{e.OldFullPath}"))
                    {
                        string path = rowData.Path.Replace(e.OldFullPath, e.FullPath);
                        if (rowData.IsFolder)
                        {
                            string? dirpath = Path.GetDirectoryName(path);
                            if (string.IsNullOrEmpty(dirpath))
                            {
                                continue;
                            }

                            path = dirpath;
                        }

                        RowData rowDataRenamed = new(rowData.IsFolder, rowData.IsAdditionalItem, 0, path);
                        FolderOptions.ReadHiddenAttributes(rowDataRenamed.Path, out bool hasHiddenFlag, out bool isDirectoryToHide);
                        if (isDirectoryToHide)
                        {
                            continue;
                        }

                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowDataRenamed.HiddenEntry = hasHiddenFlag;
                        rowDataRenamed.LoadIcon(true);
                        rowDatas.Add(rowDataRenamed);
                    }
                    else
                    {
                        rowDatas.Add(rowData);
                    }
                }

                if (menu.SelectedItem != null)
                {
                    menu.SelectedItem = null;
                    menu.SubMenu?.Close();
                    menu.RefreshSelection();
                }

                // Apply list changes
                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                menu.AddItemsToMenu(rowDatas, null);

                AdjustLocationOnWatcherUpdate(menu);
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
                List<RowData> rowsToRemove = new();

                foreach (RowData rowData in dgv.ItemsSource)
                {
                    if (rowData.Path == e.FullPath ||
                        rowData.Path.StartsWith($"{e.FullPath}\\"))
                    {
                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowsToRemove.Add(rowData);
                    }
                }

                if (menu.SelectedItem != null && rowsToRemove.Contains(menu.SelectedItem))
                {
                    menu.SelectedItem = null;
                    menu.SubMenu?.Close();
                    menu.RefreshSelection();
                }

                // Apply list changes
                ((List<RowData>)dgv.ItemsSource).RemoveAll(rowsToRemove.Contains);

                AdjustLocationOnWatcherUpdate(menu);
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
                rowData.LoadIcon(true);

                var items = (List<RowData>)menu.GetDataGridView().Items.SourceCollection;
                List<RowData> rowDatas = new(items.Count + 1) { rowData };
                foreach (RowData item in items)
                {
                    rowDatas.Add(item);
                }

                // Apply list changes
                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                menu.AddItemsToMenu(rowDatas, null);

                AdjustLocationOnWatcherUpdate(menu);
                menu.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(CreateItem)}: {e.FullPath}", ex);
            }
        }
    }
}
