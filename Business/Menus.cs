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
    using System.Windows.Media;
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
        private readonly Menu?[] menus = new Menu?[MenuDefines.MenusMax];
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
        private bool searchTextChanging;
#if TODO // Misc MouseEvents
        private int lastMouseDownRowIndex = -1;
#endif
        private bool showMenuAfterMainPreload;

        public Menus()
        {
            keyboardInput = new(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += () => SwitchOpenClose(false, false);
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;

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
                if (IsMainUsable &&
                    (menus[rowData.Level + 1] == null ||
                    menus[rowData.Level + 1]?.RowDataParent != rowData))
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

            waitToOpenMenu.CloseMenu += CloseMenu;
            void CloseMenu(int level)
            {
                if (level < menus.Length)
                {
                    Menu? menu = menus[level];
                    if (menu != null)
                    {
                        HideOldMenu(menu);
                    }
                }
            }

            waitToOpenMenu.MouseEnterOk += MouseEnterOk;
#if TODO // Misc MouseEvents
            dgvMouseRow.RowMouseLeave += Dgv_RowMouseLeave; // event moved to Menu.CellMouseLeave()
#endif

            if (Settings.Default.SupportGamepad)
            {
                joystickHelper = new();
                joystickHelper.KeyPressed += (key, modifiers) =>
                {
                    if (IsMainUsable)
                    {
                        Menu? menu = AsEnumerable.FirstOrDefault(m => m != null && (m.IsActive || m.IsKeyboardFocusWithin), MainMenu);
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
                if (!IsActive())
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

        private Menu? MainMenu => menus[0];

        private bool IsMainUsable => MainMenu?.IsUsable ?? false;

        private IEnumerable<Menu> AsEnumerable => menus.Where(m => m != null && !m.IsClosed)!;

        private List<Menu> AsList => AsEnumerable.ToList();

        public void Dispose()
        {
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
            workerMainMenu.Dispose();
            foreach (BackgroundWorker worker in workersSubMenu)
            {
                worker.Dispose();
            }

            waitToOpenMenu.Dispose();
            keyboardInput.Dispose();
            joystickHelper?.Dispose();
            timerShowProcessStartedAsLoadingIcon.Stop();
            timerStillActiveCheck.Stop();
            waitLeave.Stop();
            MainMenu?.Close();

            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.Created -= WatcherProcessItem;
                watcher.Deleted -= WatcherProcessItem;
                watcher.Renamed -= WatcherProcessItem;
                watcher.Changed -= WatcherProcessItem;
                watcher.Dispose();
            }
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
                    ((MainMenu?.Visibility ?? Visibility.Collapsed) == Visibility.Visible && openCloseState == OpenCloseState.Default))
                {
                    openCloseState = OpenCloseState.Closing;
                    MenusFadeOut();
                    StopWorker();
                    if (!AsEnumerable.Any(m => m.Visibility == Visibility.Visible))
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
                Menu? menu = MainMenu;
                if (menu != null)
                {
                    // The main menu gets loaded again
                    // Clean up menu status of previous one
                    ListView dgvMainMenu = menu.GetDataGridView();
                    foreach (ListViewItemData item in dgvMainMenu.Items)
                    {
                        RowData rowDataToClear = item.data;
                        rowDataToClear.IsMenuOpen = false;
                        rowDataToClear.IsClicking = false;
                        rowDataToClear.IsSelected = false;
                    }

                    RefreshSelection(dgvMainMenu);

                    menu.RelocateOnNextShow = true;
                }

                AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
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
                            Create(menuData, Config.Path); // Level 0 Main Menu

                            IconReader.IsPreloading = false;
                            if (showMenuAfterMainPreload)
                            {
                                MainMenu?.ShowWithFade();
                            }
                        }
                        else
                        {
                            AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
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
            if (e.Result == null)
            {
                return;
            }

            MenuData menuData = (MenuData)e.Result;
            Menu? menu = menus[menuData.Level];
            if (menu == null)
            {
                return;
            }

            if (IsMainUsable)
            {
                if (menuData.DirectoryState != MenuDataDirectoryState.Undefined)
                {
                    // Sub Menu (completed)
                    menu.AddItemsToMenu(menuData.RowDatas, menuData.DirectoryState, true);
                    AdjustMenusSizeAndLocation(menu.Level);
                }
                else
                {
                    menu.HideWithFade();
                    menus[menu.Level] = null;

                    ListView? lv = menus[menuData.Level - 1]?.GetDataGridView();
                    if (lv != null)
                    {
                        RefreshSelection(lv);
                    }
                }
            }
        }

        private bool IsActive()
        {
            return menus.Where(m => m != null && (m.IsActive || m.IsKeyboardFocusWithin)).FirstOrDefault() != null || (App.TaskbarLogo?.IsActive ?? false);
        }

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
                searchTextChanging = true;
                keyboardInput.SearchTextChanging();
                waitToOpenMenu.MouseActive = false;
            }

            menu.SearchTextChanged += Menu_SearchTextChanged;
            void Menu_SearchTextChanged(Menu menu, bool isSearchStringEmpty, bool causedByWatcherUpdate)
            {
                keyboardInput.SearchTextChanged(menu, isSearchStringEmpty);
                AdjustMenusSizeAndLocation(menu.Level + 1);
                searchTextChanging = false;

                // if any open menu close
                if (!causedByWatcherUpdate && menu.Level + 1 < menus.Length)
                {
                    Menu? menuToClose = menus[menu.Level + 1];
                    if (menuToClose != null)
                    {
                        HideOldMenu(menuToClose);
                    }
                }
            }

            menu.UserDragsMenu += Menu_UserDragsMenu;
            void Menu_UserDragsMenu()
            {
                Menu? menu = menus[1];
                if (menu != null)
                {
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
                    if (!IsActive())
                    {
                        deactivatedTime = DateTime.Now;
                    }
                }
            }

            menu.Activated += (sender, e) => Activated();
            void Activated()
            {
                // Bring transparent menus back
                foreach (Menu? menu in menus.Where(m => m != null && m.Opacity != 1D))
                {
                    menu!.ActivateWithFade();
                }

                timerStillActiveCheck.Stop();
                timerStillActiveCheck.Start();
            }

            menu.IsVisibleChanged += (sender, _) => MenuVisibleChanged((Menu)sender);
            menu.CellMouseEnter += waitToOpenMenu.MouseEnter;
            menu.CellMouseLeave += waitToOpenMenu.MouseLeave;
            menu.CellMouseDown += Dgv_MouseDown;
            menu.CellMouseUp += Dgv_MouseUp;
            menu.CellOpenOnClick += Dgv_OpenItemOnClick;
            menu.ClosePressed += MenusFadeOut;

            ListView dgv = menu.GetDataGridView();
            dgv.SelectionChanged += Dgv_SelectionChanged;
#if TODO // Misc MouseEvents
            dgv.MouseMove += waitToOpenMenu.MouseMove;
#endif

            if (menu.Level == 0)
            {
                // Main Menu
                menus[menu.Level] = menu;
                menu.Loaded += (s, e) => ExecuteWatcherHistory();
            }
            else
            {
                // Sub Menu (loading)
                if (IsMainUsable)
                {
                    HideOldMenu(menu, true);
                    menus[menu.Level] = menu;
                    menu.ShowWithFade(!IsActive());
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

            if (!AsEnumerable.Any(m => m.Visibility == Visibility.Visible))
            {
                IconReader.ClearCacheWhenLimitReached();

                openCloseState = OpenCloseState.Default;
            }
        }

        private void Dgv_MouseDown(ListView dgv, ListViewItemData itemData, MouseButtonEventArgs e)
        {
            MouseEnterOk(dgv, itemData, true);

#if TODO // Misc MouseEvents
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastMouseDownRowIndex = index;
            }
#endif
        }

        private void Dgv_MouseUp(object sender, ListViewItemData itemData, MouseButtonEventArgs e)
        {
#if TODO // Misc MouseEvents
            lastMouseDownRowIndex = -1;
#endif
        }

        private void MouseEnterOk(ListView dgv, ListViewItemData itemData)
        {
            MouseEnterOk(dgv, itemData, false);
        }

        private void MouseEnterOk(ListView dgv, ListViewItemData itemData, bool refreshView)
        {
            if (IsMainUsable)
            {
                if (keyboardInput.InUse)
                {
                    keyboardInput.ClearIsSelectedByKey();
                    keyboardInput.InUse = false;
                }

                keyboardInput.Select(dgv, itemData, refreshView);
            }
        }
#if TODO // Misc MouseEvents
        private void Dgv_RowMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            ListView dgv = (ListView)sender;

            if (e.RowIndex == lastMouseDownRowIndex &&
                e.RowIndex > -1 &&
                e.RowIndex < dgv.Items.Count)
            {
                lastMouseDownRowIndex = -1;

                RowData rowData = (RowData)dgv.Items[e.RowIndex].Cells[2].Value;
                string[] files = new string[] { rowData.Path };

                // Update position raises move event which prevent DoDragDrop blocking UI when mouse not moved
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);

                dgv.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
            }
        }
#endif

        private void Dgv_OpenItemOnClick(ListView sender, ListViewItemData itemData)
        {
#if TODO // Misc MouseEvents
            lastMouseDownRowIndex = -1;
#endif
            waitToOpenMenu.ClickOpensInstantly(sender, itemData);
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            RefreshSelection((ListView)sender);
        }

        private void RefreshSelection(ListView dgv)
        {
            dgv.SelectionChanged -= Dgv_SelectionChanged;

            foreach (ListViewItemData itemData in dgv.Items)
            {
                RowData rowData = itemData.data;
                if (rowData.IsClicking)
                {
                    itemData.BorderBrush = MenuDefines.ColorIcons;
                    itemData.BackgroundBrush = MenuDefines.ColorSelectedItem;
                    dgv.SelectedItems.Add(itemData);
                }
                else if (rowData.IsMenuOpen)
                {
                    itemData.BorderBrush = MenuDefines.ColorOpenFolderBorder;
                    itemData.BackgroundBrush = MenuDefines.ColorOpenFolder;
                    dgv.SelectedItems.Add(itemData);
                }
                else if (rowData.IsSelected)
                {
                    itemData.BorderBrush = MenuDefines.ColorSelectedItemBorder;
                    itemData.BackgroundBrush = MenuDefines.ColorSelectedItem;
                    dgv.SelectedItems.Add(itemData);
                }
                else
                {
                    itemData.BorderBrush = Brushes.White;
                    itemData.BackgroundBrush = Brushes.White;
                    dgv.SelectedItems.Remove(itemData);
                }
            }

            dgv.SelectionChanged += Dgv_SelectionChanged;

            if (!searchTextChanging)
            {
                dgv.InvalidateVisual();
            }
        }

        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e)
        {
            dispatchter.Invoke(() =>
            {
                if (IsMainUsable)
                {
                    Menu? menu = MainMenu;
                    if (menu != null)
                    {
                        menu.RelocateOnNextShow = true;
                    }
                }
            });
        }

        private void HideOldMenu(Menu menuToShow, bool keepOrSetIsMenuOpen = false)
        {
            Menu? menuPrevious = menus[menuToShow.Level - 1];
            if (menuPrevious != null)
            {
                // Clean up menu status IsMenuOpen for previous one
                ListView dgvPrevious = menuPrevious.GetDataGridView();
                foreach (ListViewItemData item in dgvPrevious.Items)
                {
                    RowData rowDataToClear = item.data;
                    if (rowDataToClear == menuToShow.RowDataParent)
                    {
                        rowDataToClear.IsMenuOpen = keepOrSetIsMenuOpen;
                    }
                    else
                    {
                        rowDataToClear.IsMenuOpen = false;
                    }
                }

                RefreshSelection(dgvPrevious);

                // Hide old menu
                foreach (Menu? menuToClose in menus.Where(
                    m => m != null && m.Level > menuPrevious.Level))
                {
                    menuToClose!.HideWithFade();
                    menus[menuToClose.Level] = null;
                }
            }
        }

        private void FadeHalfOrOutIfNeeded()
        {
            if (IsMainUsable)
            {
                if (!IsActive())
                {
                    if (Settings.Default.StaysOpenWhenFocusLost &&
                        AsList.Any(m => m.IsMouseOn()))
                    {
                        if (!keyboardInput.InUse)
                        {
                            AsList.ForEach(menu => menu.ShowWithFade(true));
                        }
                    }
                    else if (Config.AlwaysOpenByPin)
                    {
                        AsList.ForEach(menu => menu.ShowWithFade(true));
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
            AsList.ForEach(menu =>
            {
                if (menu.Level > 0)
                {
                    menus[menu.Level] = null;
                }

                menu.HideWithFade();
            });

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
            List<Menu> list = AsList;
            WindowsTaskbar taskbar = new();
            if (list.Count == 1)
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

            Menu menu;
            Menu? menuPredecessor = null;
            List<Menu> list = AsList;
            for (int i = 0; i < list.Count; i++)
            {
                menu = list[i];

                if (startLevel <= i)
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
                    i == 0)
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
            Menu? menu = MainMenu;
            bool useHistory = false;
            if (menu == null)
            {
                useHistory = true;
            }
            else
            {
                menu.Dispatcher.Invoke(() => useHistory = !menu.IsLoaded);
            }

            if (useHistory)
            {
                watcherHistory.Add(e);
                return;
            }

            if (e is RenamedEventArgs renamedEventArgs)
            {
                MainMenu?.Dispatcher.Invoke(() => RenameItem(renamedEventArgs));
            }
            else if (e is FileSystemEventArgs fileSystemEventArgs)
            {
                if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Deleted)
                {
                    MainMenu?.Dispatcher.Invoke(() => DeleteItem(fileSystemEventArgs));
                }
                else if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Created)
                {
                    MainMenu?.Dispatcher.Invoke(() => CreateItem(fileSystemEventArgs));
                }
            }
        }

        private void RenameItem(RenamedEventArgs e)
        {
            try
            {
                List<RowData> rowDatas = new();
                ListView? dgv = MainMenu?.GetDataGridView();
                if (dgv != null)
                {
                    foreach (ListViewItemData item in dgv.Items)
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
                }

                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                keyboardInput.ClearIsSelectedByKey();
                MainMenu?.AddItemsToMenu(rowDatas, null, true);
                MainMenu?.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(RenameItem)}: {e.OldFullPath} {e.FullPath}", ex);
            }
        }

        private void DeleteItem(FileSystemEventArgs e)
        {
            try
            {
                ListView? dgv = MainMenu?.GetDataGridView();
                if (dgv != null)
                {
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
                }

                keyboardInput.ClearIsSelectedByKey();
                MainMenu?.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(DeleteItem)}: {e.FullPath}", ex);
            }
        }

        private void CreateItem(FileSystemEventArgs e)
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

                List<RowData> rowDatas = new()
                {
                    rowData,
                };

                ListView? dgv = MainMenu?.GetDataGridView();
                if (dgv != null)
                {
                    foreach (ListViewItemData item in dgv.Items)
                    {
                        rowDatas.Add(item.data);
                    }
                }

                rowDatas = DirectoryHelpers.SortItems(rowDatas);
                keyboardInput.ClearIsSelectedByKey();
                MainMenu?.AddItemsToMenu(rowDatas, null, true);
                MainMenu?.OnWatcherUpdate();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(CreateItem)}: {e.FullPath}", ex);
            }
        }
    }
}
