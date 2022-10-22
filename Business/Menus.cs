// <copyright file="Menus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Handler;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static SystemTrayMenu.Utilities.IconReader;
    using ListView = System.Windows.Controls.ListView;
    using Menu = SystemTrayMenu.UserInterface.Menu;
    using MessageBox = System.Windows.MessageBox;
    using Point = System.Drawing.Point;

    internal class Menus : IDisposable
    {
        private readonly Menu[] menus = new Menu[MenuDefines.MenusMax];
        private readonly BackgroundWorker workerMainMenu = new();
        private readonly List<BackgroundWorker> workersSubMenu = new();
        private readonly DgvMouseRow<ListView> dgvMouseRow = new();
        private readonly WaitToLoadMenu waitToOpenMenu = new();
        private readonly KeyboardInput keyboardInput;
        private readonly JoystickHelper joystickHelper;
        private readonly List<FileSystemWatcher> watchers = new();
        private readonly List<EventArgs> watcherHistory = new();
        private readonly DispatcherTimer timerShowProcessStartedAsLoadingIcon = new();
        private readonly DispatcherTimer timerStillActiveCheck = new();
        private readonly WaitLeave waitLeave = new(Properties.Settings.Default.TimeUntilCloses);
        private DateTime deactivatedTime = DateTime.MinValue;
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private TaskbarPosition taskbarPosition = new WindowsTaskbar().Position;
        private bool searchTextChanging;
        private bool waitingForReactivate;
        private int lastMouseDownRowIndex = -1;
        private bool showMenuAfterMainPreload;
#if TODO
        private int dragSwipeScrollingStartRowIndex = -1;
#endif
        private bool isDraggingSwipeScrolling;
        private bool isDragSwipeScrolled;
        private bool hideSubmenuDuringRefreshSearch;

        public Menus()
        {
            workerMainMenu.WorkerSupportsCancellation = true;
            workerMainMenu.DoWork += LoadMenu;
            workerMainMenu.RunWorkerCompleted += LoadMainMenuCompleted;
            void LoadMainMenuCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                keyboardInput.ResetSelectedByKey();
                LoadStopped();

                if (e.Result == null)
                {
                    // Clean up menu status IsMenuOpen for previous one
                    ListView dgvMainMenu = menus[0].GetDataGridView();
#if TODO
                    foreach (DataRow row in ((DataTable)dgvMainMenu.DataSource).Rows)
                    {
                        RowData rowDataToClear = (RowData)row[2];
                        rowDataToClear.IsMenuOpen = false;
                        rowDataToClear.IsClicking = false;
                        rowDataToClear.IsSelected = false;
                        rowDataToClear.IsContextMenuOpen = false;
                    }
#endif

                    RefreshSelection(dgvMainMenu);

                    if (Properties.Settings.Default.AppearAtMouseLocation)
                    {
                        menus[0].Tag = null;
                    }

                    AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
                }
                else
                {
                    MenuData menuData = (MenuData)e.Result;
                    switch (menuData.Validity)
                    {
                        case MenuDataValidity.Valid:
                            if (IconReader.MainPreload)
                            {
                                workerMainMenu.DoWork -= LoadMenu;
                                menus[0] = Create(menuData, new DirectoryInfo(Config.Path).Name);
                                menus[0].HandleCreated += (s, e) => ExecuteWatcherHistory();
                                Scaling.CalculateFactorByDpi(menus[0]);

                                IconReader.MainPreload = false;
                                if (showMenuAfterMainPreload)
                                {
                                    AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
                                }
                            }
                            else
                            {
                                AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
                            }

                            break;
                        case MenuDataValidity.Empty:
                            MessageBox.Show(Translator.GetText("Your root directory for the app does not exist or is empty! Change the root directory or put some files, directories or shortcuts into the root directory."));
                            OpenFolder();
                            Config.SetFolderByUser();
                            AppRestart.ByConfigChange();
                            break;
                        case MenuDataValidity.NoAccess:
                            MessageBox.Show(Translator.GetText("You have no access to the root directory of the app. Grant access to the directory or change the root directory."));
                            OpenFolder();
                            Config.SetFolderByUser();
                            AppRestart.ByConfigChange();
                            break;
                        case MenuDataValidity.Undefined:
                            Log.Info($"{nameof(MenuDataValidity)}.{nameof(MenuDataValidity.Undefined)}");
                            break;
                        default:
                            break;
                    }
                }

                openCloseState = OpenCloseState.Default;
            }

            waitToOpenMenu.StopLoadMenu += WaitToOpenMenu_StopLoadMenu;
            void WaitToOpenMenu_StopLoadMenu()
            {
                foreach (BackgroundWorker workerSubMenu in workersSubMenu.
                    Where(w => w.IsBusy))
                {
                    workerSubMenu.CancelAsync();
                }

                LoadStopped();
            }

            waitToOpenMenu.StartLoadMenu += StartLoadMenu;
            void StartLoadMenu(RowData rowData)
            {
                if (menus[0].IsUsable &&
                    (menus[rowData.Level + 1] == null ||
                    menus[rowData.Level + 1].Tag as RowData != rowData))
                {
                    CreateAndShowLoadingMenu(rowData);
                    void CreateAndShowLoadingMenu(RowData rowData)
                    {
                        MenuData menuDataLoading = new(rowData.Level + 1)
                        {
                            Validity = MenuDataValidity.Valid,
                        };

                        Menu menuLoading = Create(menuDataLoading, new DirectoryInfo(rowData.Path).Name);
                        menuLoading.IsLoadingMenu = true;
                        AdjustMenusSizeAndLocation();
                        menus[rowData.Level + 1] = menuLoading;
                        menuLoading.Tag = menuDataLoading.RowDataParent = rowData;
                        menuDataLoading.RowDataParent.SubMenu = menuLoading;
                        menuLoading.SetTypeLoading();
                        ShowSubMenu(menuLoading);
                    }

                    BackgroundWorker workerSubMenu = workersSubMenu.
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

                void LoadSubMenuCompleted(object senderCompleted, RunWorkerCompletedEventArgs e)
                {
                    MenuData menuData = (MenuData)e.Result;

                    Menu menuLoading = menus[menuData.Level];
                    string userSearchText = string.Empty;
                    bool closedLoadingMenu = false;
                    if (menuLoading != null && menuLoading.IsLoadingMenu)
                    {
                        menuLoading.HideWithFade();
                        userSearchText = menuLoading.GetSearchText();
                        menus[menuLoading.Level] = null;
                        closedLoadingMenu = true;
                    }

                    if (menuData.Validity != MenuDataValidity.Undefined &&
                        menus[0].IsUsable)
                    {
                        Menu menu = Create(menuData);
                        switch (menuData.Validity)
                        {
                            case MenuDataValidity.Valid:
                                menu.SetTypeSub();
                                break;
                            case MenuDataValidity.Empty:
                                menu.SetTypeEmpty();
                                break;
                            case MenuDataValidity.NoAccess:
                                menu.SetTypeNoAccess();
                                break;
                        }

                        menu.Tag = menuData.RowDataParent;
                        menuData.RowDataParent.SubMenu = menu;
                        if (menus[0].IsUsable)
                        {
                            ShowSubMenu(menu);
                            menu.SetSearchText(userSearchText);
                        }
                    }
                    else if (closedLoadingMenu && menus[0].IsUsable)
                    {
                        menuData.RowDataParent.IsMenuOpen = false;
                        menuData.RowDataParent.IsClicking = false;
                        menuData.RowDataParent.IsSelected = false;
                        Menu menuPrevious = menus[menuData.Level - 1];
                        if (menuPrevious != null)
                        {
                            RefreshSelection(menuPrevious.GetDataGridView());
                        }
                    }
                }
            }

            waitToOpenMenu.CloseMenu += CloseMenu;
            void CloseMenu(int level)
            {
                if (level < menus.Length && menus[level] != null)
                {
                    HideOldMenu(menus[level]);
                }

                if (level - 1 < menus.Length && menus[level - 1] != null)
                {
                    menus[level - 1].FocusTextBox();
                }
            }

            waitToOpenMenu.MouseEnterOk += MouseEnterOk;
            dgvMouseRow.RowMouseEnter += waitToOpenMenu.MouseEnter;
            dgvMouseRow.RowMouseLeave += waitToOpenMenu.MouseLeave;
#if TODO
            dgvMouseRow.RowMouseLeave += Dgv_RowMouseLeave;
#endif

            keyboardInput = new(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += () => SwitchOpenClose(false);
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;
            keyboardInput.RowSelected += AdjustScrollbarToDisplayedRow;
            void AdjustScrollbarToDisplayedRow(ListView dgv, int index)
            {
                Menu menu = (Menu)dgv.GetParentWindow();
                menu.AdjustScrollbar();
            }

            joystickHelper = new();
            joystickHelper.KeyPressed += (key) => menus[0].Dispatcher.Invoke(keyboardInput.CmdKeyProcessed, new object[] { null, key });

            timerShowProcessStartedAsLoadingIcon.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilClosesAfterEnterPressed);
            timerStillActiveCheck.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilClosesAfterEnterPressed + 20);
            timerStillActiveCheck.Tick += (sender, e) => StillActiveTick();
            void StillActiveTick()
            {
                if (!IsActive())
                {
                    FadeHalfOrOutIfNeeded();
                }

                timerStillActiveCheck.Stop();
            }

            waitLeave.LeaveTriggered += FadeHalfOrOutIfNeeded;

            CreateWatcher(Config.Path, false);
            foreach (var pathAndFlags in MenusHelpers.GetAddionalPathsForMainMenu())
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
        }

        internal event Action LoadStarted;

        internal event Action LoadStopped;

        private enum OpenCloseState
        {
            Default,
            Opening,
            Closing,
        }

        private IEnumerable<Menu> AsEnumerable => menus.Where(m => m != null && !m.IsDisposed);

        private List<Menu> AsList => AsEnumerable.ToList();

        public void Dispose()
        {
            workerMainMenu.Dispose();
            foreach (BackgroundWorker worker in workersSubMenu)
            {
                worker.Dispose();
            }

            waitToOpenMenu.Dispose();
            keyboardInput.Dispose();
            joystickHelper.Dispose();
            timerShowProcessStartedAsLoadingIcon.Stop();
            timerStillActiveCheck.Stop();
            waitLeave.Dispose();
            IconReader.Dispose();
            DisposeMenu(menus[0]);
            dgvMouseRow.Dispose();

            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.Created -= WatcherProcessItem;
                watcher.Deleted -= WatcherProcessItem;
                watcher.Renamed -= WatcherProcessItem;
                watcher.Changed -= WatcherProcessItem;
                watcher.Dispose();
            }
        }

        internal static MenuData GetData(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new(level);
            if (worker?.CancellationPending == true || string.IsNullOrEmpty(path))
            {
                return menuData;
            }

            MenusHelpers.GetItemsForMainMenu(worker, path, ref menuData);
            if (worker?.CancellationPending == true)
            {
                return menuData;
            }

            MenusHelpers.GetAddionalItemsForMainMenu(ref menuData);
            if (worker?.CancellationPending == true)
            {
                return menuData;
            }

            MenusHelpers.ReadHiddenAndReadIcons(worker, ref menuData);
            if (worker?.CancellationPending == true)
            {
                return menuData;
            }

            MenusHelpers.CheckIfValid(ref menuData);
            MenusHelpers.SortItemsWhenValid(ref menuData);
            return menuData;
        }

        internal void SwitchOpenCloseByTaskbarItem()
        {
            SwitchOpenClose(true);
            timerStillActiveCheck.Start();
        }

        internal bool IsOpenCloseStateOpening()
        {
            return openCloseState == OpenCloseState.Opening;
        }

        internal void SwitchOpenClose(bool byClick, bool isMainPreload = false)
        {
            // Ignore open close events during main preload #248
            if (IconReader.MainPreload && !isMainPreload)
            {
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
            else if (openCloseState == OpenCloseState.Opening ||
                (menus[0] != null && menus[0].Visibility == Visibility.Visible && openCloseState == OpenCloseState.Default))
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
                joystickHelper.Enable();
                StartWorker();
            }

            deactivatedTime = DateTime.MinValue;
        }

        internal void DisposeMenu(Menu menuToDispose)
        {
            if (menuToDispose != null)
            {
                menuToDispose.CellMouseEnter -= dgvMouseRow.CellMouseEnter;
                menuToDispose.CellMouseLeave -= dgvMouseRow.CellMouseLeave;
                menuToDispose.CellMouseDown -= Dgv_MouseDown;
                menuToDispose.CellMouseUp -= Dgv_MouseUp;
                menuToDispose.CellMouseClick -= Dgv_MouseClick;
                menuToDispose.CellMouseDoubleClick -= Dgv_MouseDoubleClick;
#if TODO
                menuToDispose.MouseWheel -= AdjustMenusSizeAndLocation;
                menuToDispose.MouseLeave -= waitLeave.Start;
                menuToDispose.MouseEnter -= waitLeave.Stop;
                menuToDispose.CmdKeyProcessed -= keyboardInput.CmdKeyProcessed;
                menuToDispose.SearchTextChanging -= keyboardInput.SearchTextChanging;
                menuToDispose.KeyPressCheck -= Menu_KeyPressCheck;
                menuToDispose.SearchTextChanged -= Menu_SearchTextChanged;
                ListView dgv = menuToDispose.GetDataGridView();
                if (dgv != null)
                {
                    dgv.MouseLeave -= dgvMouseRow.MouseLeave;
                    dgv.MouseLeave -= Dgv_MouseLeave;
                    dgv.MouseMove -= waitToOpenMenu.MouseMove;
                    dgv.MouseMove -= Dgv_MouseMove;
                    dgv.SelectionChanged -= Dgv_SelectionChanged;
                    dgv.RowPostPaint -= Dgv_RowPostPaint;
                    dgv.ClearSelection();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        RowData rowData = (RowData)row.Cells[2].Value;
                        DisposeMenu(rowData.SubMenu);
                    }
                }
                menuToDispose.Dispose();
#endif
            }
        }

        internal void ReAdjustSizeAndLocation()
        {
            if (menus[0].IsUsable)
            {
                menus[0].Tag = null;
            }
        }

        internal void MainPreload()
        {
            IconReader.MainPreload = true;

            timerShowProcessStartedAsLoadingIcon.Tick += Tick;
            timerShowProcessStartedAsLoadingIcon.Interval = TimeSpan.FromMilliseconds(5);
            timerShowProcessStartedAsLoadingIcon.Start();
            void Tick(object sender, EventArgs e)
            {
                timerShowProcessStartedAsLoadingIcon.Tick -= Tick;
                timerShowProcessStartedAsLoadingIcon.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilClosesAfterEnterPressed);
                SwitchOpenClose(false, true);
            }
        }

        internal void StartWorker()
        {
            if (Properties.Settings.Default.GenerateShortcutsToDrives)
            {
                GenerateDriveShortcuts.Start();
            }

            if (!workerMainMenu.IsBusy)
            {
                LoadStarted();
                workerMainMenu.RunWorkerAsync(
                    new object[] { Config.Path, 0 });
            }
        }

        internal void StopWorker()
        {
            if (workerMainMenu.IsBusy)
            {
                workerMainMenu.CancelAsync();
            }
        }

        private static void LoadMenu(object senderDoWork, DoWorkEventArgs eDoWork)
        {
            string path;
            int level = 0;
            RowData rowData = eDoWork.Argument as RowData;
            if (rowData != null)
            {
                path = rowData.ResolvedPath;
                level = rowData.Level + 1;
            }
            else
            {
                path = Config.Path;
            }

            MenuData menuData = GetData((BackgroundWorker)senderDoWork, path, level);
            menuData.RowDataParent = rowData;
            eDoWork.Result = menuData;
        }

        private static void OpenFolder(string pathToFolder = "")
        {
            string path = pathToFolder;
            if (string.IsNullOrEmpty(path))
            {
                path = Config.Path;
            }

            Log.ProcessStart(path);
        }

        private static int GetRowUnderCursor(ListView dgv, Point location)
        {
#if TODO
            ListView.HitTestInfo myHitTest = dgv.HitTest(location.X, location.Y);
            return myHitTest.RowIndex;
#else
            return 0;
#endif
        }

        private static void AddItemsToMenu(List<RowData> data, Menu menu, out int foldersCount, out int filesCount)
        {
            foldersCount = 0;
            filesCount = 0;

            List<Menu.ListViewItemData> items = new();
            ListView lv = menu.GetDataGridView();
#if TODO // REMOVE?
            DataTable dataTable = new();

            foreach (var prop in typeof(Menu.ListViewItemData).GetProperties())
            {
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (RowData rowData in data)
            {
                if (!(rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult))
                {
                    if (rowData.ContainsMenu)
                    {
                        foldersCount++;
                    }
                    else
                    {
                        filesCount++;
                    }
                }

                rowData.SetData(rowData, dataTable);
            }

            lv.ItemsSource = dataTable.DefaultView;

            foreach (DataRow row in dataTable.Rows)
            {
                RowData rowData = (RowData)row[nameof(Menu.ListViewItemData.data)];
                if (rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult)
                {
                    row[nameof(Menu.ListViewItemData.SortIndex)] = 99;
                }
                else
                {
                    row[nameof(Menu.ListViewItemData.SortIndex)] = 0;
                }
            }
#else
            foreach (RowData rowData in data)
            {
                if (!(rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult))
                {
                    if (rowData.ContainsMenu)
                    {
                        foldersCount++;
                    }
                    else
                    {
                        filesCount++;
                    }
                }

                rowData.RowIndex = items.Count; // Index
                items.Add(new(
                    rowData.HiddenEntry ? AddIconOverlay(rowData.Icon, Properties.Resources.White50Percentage) : rowData.Icon,
                    rowData.Text,
                    rowData,
                    rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult ? 99 : 0));
            }

            lv.ItemsSource = items;
#endif
        }

        private bool IsActive()
        {
            bool IsShellContextMenuOpen()
            {
                bool isShellContextMenuOpen = false;
                foreach (Menu menu in menus.Where(m => m != null))
                {
                    ListView dgv = menu.GetDataGridView();
#if TODO
                    foreach (DataGridViewRow row in dgv.Items)
                    {
                        RowData rowData = (RowData)row.Cells[2].Value;
                        if (rowData != null && rowData.IsContextMenuOpen)
                        {
                            isShellContextMenuOpen = true;
                            break;
                        }
                    }
#endif

                    if (isShellContextMenuOpen)
                    {
                        break;
                    }
                }

                return isShellContextMenuOpen;
            }

            foreach (Menu menu in menus.Where(m => m != null && m.IsActive))
            {
                return true;
            }

            return (App.TaskbarLogo != null && App.TaskbarLogo.IsActive) || IsShellContextMenuOpen();
        }

        private Menu Create(MenuData menuData, string title = null)
        {
            Menu menu = new();

            string path = Config.Path;
            if (title == null)
            {
                title = new DirectoryInfo(menuData.RowDataParent.ResolvedPath).Name;
                path = menuData.RowDataParent.ResolvedPath;
            }

            title ??= Path.GetPathRoot(path);

            menu.AdjustControls(title, menuData.Validity);
            menu.UserClickedOpenFolder += () => OpenFolder(path);
            menu.Level = menuData.Level;
#if TODO
            menu.MouseWheel += AdjustMenusSizeAndLocation;
            menu.MouseLeave += waitLeave.Start;
            menu.MouseEnter += waitLeave.Stop;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.KeyPressCheck += Menu_KeyPressCheck;
            menu.SearchTextChanging += Menu_SearchTextChanging;
            menu.SearchTextChanged += Menu_SearchTextChanged;
#endif
            menu.UserDragsMenu += Menu_UserDragsMenu;
            void Menu_UserDragsMenu()
            {
                if (menus[1] != null)
                {
                    HideOldMenu(menus[1]);
                }
            }

            menu.Deactivated += Deactivate;
            void Deactivate(object sender, EventArgs e)
            {
                if (IsOpenCloseStateOpening())
                {
                    Log.Info("Ignored Deactivate, because openCloseState == OpenCloseState.Opening");
                }
                else if (!Properties.Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed ||
                    !waitingForReactivate)
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
                if (IsActive() && menus[0].IsUsable)
                {
                    AsList.ForEach(m => m.ShowWithFade());
                    timerStillActiveCheck.Stop();
                    timerStillActiveCheck.Start();
                }
            }

            menu.IsVisibleChanged += (sender, _) => MenuVisibleChanged(sender, new EventArgs());

            AddItemsToMenu(menuData.RowDatas, menu, out int foldersCount, out int filesCount);

            menu.CellMouseEnter += dgvMouseRow.CellMouseEnter;
            menu.CellMouseLeave += dgvMouseRow.CellMouseLeave;
            menu.CellMouseDown += Dgv_MouseDown;
            menu.CellMouseUp += Dgv_MouseUp;
            menu.CellMouseClick += Dgv_MouseClick;
            menu.CellMouseDoubleClick += Dgv_MouseDoubleClick;
#if TODO
            ListView dgv = menu.GetDataGridView();
            dgv.MouseLeave += dgvMouseRow.MouseLeave;
            dgv.MouseLeave += Dgv_MouseLeave;
            dgv.MouseMove += waitToOpenMenu.MouseMove;
            dgv.MouseMove += Dgv_MouseMove;
            dgv.MouseDoubleClick += Dgv_MouseDoubleClick;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.RowPostPaint += Dgv_RowPostPaint;
            dgv.DataError += Dgv_DataError;
            void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
                // WARN Dgv_DataError occured System.ObjectDisposedException: Cannot access a disposed object. Object name: 'Icon'
                // => Rare times occured (e.g. when focused an close other application => closed and activated at same time)
                Log.Warn("Dgv_DataError occured", e.Exception);
            }
#endif
            menu.SetCounts(foldersCount, filesCount);

            return menu;
        }

        private void MenuVisibleChanged(object sender, EventArgs e)
        {
            Menu menu = (Menu)sender;
            if (menu.IsUsable)
            {
                AdjustMenusSizeAndLocation();

                if (menu.Level == 0)
                {
                    menu.ResetSearchText();
                    menu.ResetHeight();
                    AdjustMenusSizeAndLocation();
                }
            }

            if (menu.Visibility != Visibility.Visible && menu.Level != 0)
            {
                DisposeMenu(menu);
            }

            if (!AsEnumerable.Any(m => m.Visibility == Visibility.Visible))
            {
                if (IconReader.ClearIfCacheTooBig())
                {
                    GC.Collect();
                }

                openCloseState = OpenCloseState.Default;
            }
        }

        private void Dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingSwipeScrolling)
            {
#if TODO
                ListView dgv = (ListView)sender;
                int newRow = GetRowUnderCursor(dgv, e.Location);
                if (newRow > -1)
                {
                    int delta = dragSwipeScrollingStartRowIndex - newRow;
                    if (DoScroll(dgv, ref delta))
                    {
                        dragSwipeScrollingStartRowIndex += delta;
                    }
                }
#endif
            }
        }

        private bool DoScroll(ListView dgv, ref int delta)
        {
            bool scrolled = false;
            if (delta != 0)
            {
#if TODO
                if (delta < 0 && dgv.FirstDisplayedScrollingRowIndex == 0)
                {
                    delta = 0;
                }

                int newFirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex + (delta * 2);

                if (newFirstDisplayedScrollingRowIndex < 0 || newFirstDisplayedScrollingRowIndex >= dgv.RowCount)
                {
                    newFirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex + delta;
                }

                if (newFirstDisplayedScrollingRowIndex > -1 && newFirstDisplayedScrollingRowIndex < dgv.RowCount)
                {
                    isDragSwipeScrolled = true;
                    dgv.FirstDisplayedScrollingRowIndex = newFirstDisplayedScrollingRowIndex;
                    Menu menu = (Menu)dgv.GetParentWindow();
                    menu.AdjustScrollbar();
                    scrolled = dgv.FirstDisplayedScrollingRowIndex == newFirstDisplayedScrollingRowIndex;
                }
#endif
            }

            return scrolled;
        }

        private void Dgv_MouseDown(object sender, int index, MouseButtonEventArgs e)
        {
            ListView dgv = (ListView)sender;

            MouseEnterOk(dgv, index, true);

            // TODO WPF: Move directly into ListViewItem_MouseDown ?
            ((Menu.ListViewItemData)dgv.Items[index]).data.MouseDown(dgv, e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastMouseDownRowIndex = index;
            }
#if TODO
            Menu menu = (Menu)((ListView)sender).GetParentWindow();
            if (menu != null && menu.ScrollbarVisible)
            {
                bool isTouchEnabled = DllImports.NativeMethods.IsTouchEnabled();
                if ((isTouchEnabled && Properties.Settings.Default.SwipeScrollingEnabledTouch) ||
                    (!isTouchEnabled && Properties.Settings.Default.SwipeScrollingEnabled))
                {
                    isDraggingSwipeScrolling = true;
                }

                dragSwipeScrollingStartRowIndex = GetRowUnderCursor(dgv, e.Location);
            }
#endif
        }

        private void Dgv_MouseUp(object sender, int index, MouseButtonEventArgs e)
        {
            lastMouseDownRowIndex = -1;
            isDraggingSwipeScrolling = false;
            isDragSwipeScrolled = false;
        }

        private void Dgv_MouseLeave(object sender, EventArgs e)
        {
            isDraggingSwipeScrolling = false;
            isDragSwipeScrolled = false;
        }

        private void MouseEnterOk(ListView dgv, int rowIndex)
        {
            MouseEnterOk(dgv, rowIndex, false);
        }

        private void MouseEnterOk(ListView dgv, int rowIndex, bool refreshView)
        {
            if (menus[0].IsUsable)
            {
                if (keyboardInput.InUse)
                {
                    keyboardInput.ClearIsSelectedByKey();
                    keyboardInput.InUse = false;
                }

                keyboardInput.Select(dgv, rowIndex, refreshView);
            }
        }
#if TODO
        private void Dgv_RowMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            ListView dgv = (ListView)sender;

            if (!isDragSwipeScrolled &&
                e.RowIndex == lastMouseDownRowIndex &&
                e.RowIndex > -1 &&
                e.RowIndex < dgv.Items.Count)
            {
                lastMouseDownRowIndex = -1;
#if TODO
                RowData rowData = (RowData)dgv.Items[e.RowIndex].Cells[2].Value;
                string[] files = new string[] { rowData.Path };

                // Update position raises move event which prevent DoDragDrop blocking UI when mouse not moved
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);

                dgv.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
#endif
            }
        }
#endif

        private void Dgv_MouseClick(object sender, int index, MouseButtonEventArgs e)
        {
            if (!isDragSwipeScrolled)
            {
                ListView dgv = (ListView)sender;
                lastMouseDownRowIndex = -1;

                // TODO WPF: Move directly into ListViewxItem_PreviewMouseLeftButtonDown ?
                ((Menu.ListViewItemData)dgv.Items[index]).data.MouseClick(e, out bool toCloseByClick);

                waitToOpenMenu.ClickOpensInstantly(dgv, index);

                if (toCloseByClick)
                {
                    MenusFadeOut();
                }
            }

            lastMouseDownRowIndex = -1;
        }

        private void Dgv_MouseDoubleClick(object sender, int index, MouseButtonEventArgs e)
        {
            ListView dgv = (ListView)sender;
            lastMouseDownRowIndex = -1;

            // TODO WPF: Move directly into ListViewItem_MouseDoubleClick ?
            ((Menu.ListViewItemData)dgv.Items[index]).data.DoubleClick(e, out bool toCloseByDoubleClick);

            if (toCloseByDoubleClick)
            {
                MenusFadeOut();
            }

            lastMouseDownRowIndex = -1;
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            RefreshSelection((ListView)sender);
        }

        private void RefreshSelection(ListView dgv)
        {
            dgv.SelectionChanged -= Dgv_SelectionChanged;

            foreach (Menu.ListViewItemData row in dgv.Items)
            {
                RowData rowData = row.data;

                if (rowData == null)
                {
                    // Case when filtering a previous menu
                }
                else if (!menus[0].IsUsable)
                {
#if TODO
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
#endif
                    dgv.SelectedItems.Remove(row);
                }
                else if (rowData.IsClicking)
                {
#if TODO
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorIcons;
#endif
                    dgv.SelectedItems.Add(row);
                }
                else if (rowData.IsContextMenuOpen || (rowData.IsMenuOpen && rowData.IsSelected))
                {
                    dgv.SelectedItems.Add(row);
                }
                else if (rowData.IsMenuOpen)
                {
                    dgv.SelectedItems.Add(row);
                }
                else if (rowData.IsSelected)
                {
#if TODO
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
#endif
                    dgv.SelectedItems.Add(row);
                }
                else
                {
#if TODO
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
#endif
                    dgv.SelectedItems.Remove(row);
                }
            }

            dgv.SelectionChanged += Dgv_SelectionChanged;

            if (!searchTextChanging)
            {
#if TODO
                dgv.Invalidate();
#endif
            }
        }

#if TODO
        private void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ListView dgv = (ListView)sender;
            DataGridViewRow row = dgv.Items[e.RowIndex];

            if (row.Selected)
            {
                RowData rowData = (RowData)row.Cells[2].Value;

                int width = dgv.Columns[0].Width + dgv.Columns[1].Width;
                Rectangle rowBounds = new(0, e.RowBounds.Top, width, e.RowBounds.Height);

                if (rowData.IsClicking)
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorIcons, ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
                }
                else if (rowData.IsContextMenuOpen || (rowData.IsMenuOpen && rowData.IsSelected))
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
                }
                else if (rowData.IsMenuOpen)
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorOpenFolderBorder, ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorOpenFolder;
                }

                if (rowData.ProcessStarted)
                {
                    waitingForReactivate = true;
                    rowData.ProcessStarted = false;
                    row.Cells[0].Value = Resources.StaticResources.LoadingIcon;
                    timerShowProcessStartedAsLoadingIcon.Tick += Tick;
                    void Tick(object sender, EventArgs e)
                    {
                        timerShowProcessStartedAsLoadingIcon.Tick -= Tick;
                        timerShowProcessStartedAsLoadingIcon.Stop();
                        row.Cells[0].Value = rowData.ReadIcon(false);
                        waitingForReactivate = false;
                    }

                    timerShowProcessStartedAsLoadingIcon.Stop();
                    timerShowProcessStartedAsLoadingIcon.Start();
                    timerStillActiveCheck.Stop();
                    timerStillActiveCheck.Start();
                }
            }
    }
#endif

        private void ShowSubMenu(Menu menuToShow)
        {
            HideOldMenu(menuToShow, true);
            menus[menuToShow.Level] = menuToShow;
            AdjustMenusSizeAndLocation();
            menus[menuToShow.Level]?.ShowWithFadeOrTransparent(IsActive());
        }

        private void HideOldMenu(Menu menuToShow, bool keepOrSetIsMenuOpen = false)
        {
            Menu menuPrevious = menus[menuToShow.Level - 1];
            if (menuPrevious != null)
            {
                // Clean up menu status IsMenuOpen for previous one
                ListView dgvPrevious = menuPrevious.GetDataGridView();
#if TODO
                foreach (DataRow row in ((DataTable)dgvPrevious.DataSource).Rows)
                {
                    RowData rowDataToClear = (RowData)row[2];
                    if (rowDataToClear == (RowData)menuToShow.Tag)
                    {
                        rowDataToClear.IsMenuOpen = keepOrSetIsMenuOpen;
                    }
                    else
                    {
                        rowDataToClear.IsMenuOpen = false;
                    }
                }
#endif

                RefreshSelection(dgvPrevious);

                // Hide old menu
                foreach (Menu menuToClose in menus.Where(
                    m => m != null && m.Level > menuPrevious.Level))
                {
                    menuToClose.HideWithFade();
                    menus[menuToClose.Level] = null;
                }
            }
        }

        private void FadeHalfOrOutIfNeeded()
        {
            if (menus[0] != null && menus[0].IsUsable)
            {
                if (!IsActive())
                {
                    if (Properties.Settings.Default.StaysOpenWhenFocusLost &&
                        AsList.Any(m => m.IsMouseOn()))
                    {
                        if (!keyboardInput.InUse)
                        {
                            AsList.ForEach(menu => menu.ShowTransparent());
                        }
                    }
                    else if (Config.AlwaysOpenByPin)
                    {
                        AsList.ForEach(menu => menu.ShowTransparent());
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
            joystickHelper.Disable();
        }

        private void AdjustMenusSizeAndLocation()
        {
            Rectangle screenBounds;
            bool isCustomLocationOutsideOfScreen = false;

            if (Properties.Settings.Default.AppearAtMouseLocation)
            {
                screenBounds = NativeMethods.Screen.FromPoint(NativeMethods.Screen.CursorPosition);
            }
            else if (Properties.Settings.Default.UseCustomLocation)
            {
                screenBounds = NativeMethods.Screen.FromPoint(new Point(
                    Properties.Settings.Default.CustomLocationX,
                    Properties.Settings.Default.CustomLocationY));

                isCustomLocationOutsideOfScreen = !screenBounds.Contains(
                    new Point(Properties.Settings.Default.CustomLocationX, Properties.Settings.Default.CustomLocationY));
            }
            else
            {
                screenBounds = NativeMethods.Screen.PrimaryScreen;
            }

            // Only apply taskbar position change when no menu is currently open
            List<Menu> list = AsList;
            WindowsTaskbar taskbar = new();
            if (list.Count == 1)
            {
                taskbarPosition = taskbar.Position;
            }

            // Shrink the usable space depending on taskbar location
            Menu.StartLocation startLocation;
            switch (taskbarPosition)
            {
                case TaskbarPosition.Left:
                    screenBounds.X += taskbar.Size.Width;
                    screenBounds.Width -= taskbar.Size.Width;
                    startLocation = Menu.StartLocation.BottomLeft;
                    break;
                case TaskbarPosition.Right:
                    screenBounds.Width -= taskbar.Size.Width;
                    startLocation = Menu.StartLocation.BottomRight;
                    break;
                case TaskbarPosition.Top:
                    screenBounds.Y += taskbar.Size.Height;
                    screenBounds.Height -= taskbar.Size.Height;
                    startLocation = Menu.StartLocation.TopRight;
                    break;
                case TaskbarPosition.Bottom:
                default:
                    screenBounds.Height -= taskbar.Size.Height;
                    startLocation = Menu.StartLocation.BottomRight;
                    break;
            }

            if (Properties.Settings.Default.AppearAtTheBottomLeft ||
                isCustomLocationOutsideOfScreen)
            {
                startLocation = Menu.StartLocation.BottomLeft;
            }

            Menu menu;
            Menu menuPredecessor = null;
            for (int i = 0; i < list.Count; i++)
            {
                menu = list[i];

                menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation, isCustomLocationOutsideOfScreen);
#if TODO // What is this, doesn't seem to have any effect ?
                if (!Properties.Settings.Default.AppearAtTheBottomLeft &&
                    !Properties.Settings.Default.AppearAtMouseLocation &&
                    !Properties.Settings.Default.UseCustomLocation &&
                    i == 0)
                {
                    const int overlapTolerance = 4;

                    // Remember width of the initial menu as we don't want to overlap with it
                    if (taskbarPosition == TaskbarPosition.Left)
                    {
                        screenBounds.X += (int)menu.Width - overlapTolerance;
                    }

                    screenBounds.Width -= (int)menu.Width - overlapTolerance;
                }
#endif
                menuPredecessor = menu;
            }
        }

#if TODO
        private void Menu_KeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (isDraggingSwipeScrolling)
            {
                e.Handled = true;
            }
        }
#endif

        private void Menu_SearchTextChanging()
        {
            searchTextChanging = true;
            keyboardInput.SearchTextChanging();
            waitToOpenMenu.MouseActive = false;
        }

        private void Menu_SearchTextChanged(object sender, bool isSearchStringEmpty)
        {
            Menu menu = (Menu)sender;
            keyboardInput.SearchTextChanged(menu, isSearchStringEmpty);
            AdjustMenusSizeAndLocation();
            searchTextChanging = false;

            // if any open menu close
            if (menu.Level + 1 < menus.Length)
            {
                Menu menuToClose = menus[menu.Level + 1];
                if (menuToClose != null && hideSubmenuDuringRefreshSearch)
                {
                    HideOldMenu(menuToClose);
                }
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
            if (menus[0] == null || !menus[0].IsHandleCreated)
            {
                watcherHistory.Add(e);
                return;
            }

            if (e is RenamedEventArgs renamedEventArgs)
            {
                menus[0].Dispatcher.Invoke(() => RenameItem(renamedEventArgs));
            }
            else
            {
                FileSystemEventArgs fileSystemEventArgs = (FileSystemEventArgs)e;
                if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Deleted)
                {
                    menus[0].Dispatcher.Invoke(() => DeleteItem(e as FileSystemEventArgs));
                }
                else if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Created)
                {
                    menus[0].Dispatcher.Invoke(() => CreateItem(e as FileSystemEventArgs));
                }
            }
        }

        private void RenameItem(RenamedEventArgs e)
        {
            try
            {
                List<RowData> rowDatas = new();
#if TODO
                DataTable dataTable = (DataTable)menus[0].GetDataGridView().DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    RowData rowData = (RowData)row[2];
                    if (rowData.Path.StartsWith($"{e.OldFullPath}"))
                    {
                        string path = rowData.Path.Replace(e.OldFullPath, e.FullPath);
                        FileAttributes attr = File.GetAttributes(path);
                        bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                        if (isFolder)
                        {
                            path = Path.GetDirectoryName(path);
                        }

                        RowData rowDataRenamed = new(isFolder, rowData.IsAddionalItem, false, 0, path);
                        if (FolderOptions.IsHidden(rowDataRenamed))
                        {
                            continue;
                        }

                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowDataRenamed.ReadIcon(true);
                        rowDatas.Add(rowDataRenamed);
                    }
                    else
                    {
                        rowDatas.Add(rowData);
                    }
                }
#endif

                rowDatas = MenusHelpers.SortItems(rowDatas);
                keyboardInput.ClearIsSelectedByKey();
                AddItemsToMenu(rowDatas, menus[0], out _, out _);

                hideSubmenuDuringRefreshSearch = false;
                menus[0].RefreshSearchText();
                hideSubmenuDuringRefreshSearch = true;

                menus[0].TimerUpdateIconsStart();
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
                List<DataRow> rowsToRemove = new();
#if TODO
                ListView dgv = menus[0].GetDataGridView();
                DataTable dataTable = (DataTable)dgv.DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    RowData rowData = (RowData)row[2];
                    if (rowData.Path == e.FullPath ||
                        rowData.Path.StartsWith($"{e.FullPath}\\"))
                    {
                        IconReader.RemoveIconFromCache(rowData.Path);
                        rowsToRemove.Add(row);
                    }
                }

                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    dataTable.Rows.Remove(rowToRemove);
                }

                keyboardInput.ClearIsSelectedByKey();
                dgv.DataSource = dataTable;
#endif

                hideSubmenuDuringRefreshSearch = false;
                menus[0].ResetHeight();
                menus[0].RefreshSearchText();
                hideSubmenuDuringRefreshSearch = true;
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
                RowData rowData = new(isFolder, isAddionalItem, false, 0, e.FullPath);
                if (FolderOptions.IsHidden(rowData))
                {
                    return;
                }

                rowData.ReadIcon(true);

                List<RowData> rowDatas = new()
                {
                    rowData,
                };

#if TODO
                DataTable dataTable = (DataTable)menus[0].GetDataGridView().DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    rowDatas.Add((RowData)row[2]);
                }
#endif

                rowDatas = MenusHelpers.SortItems(rowDatas);
                keyboardInput.ClearIsSelectedByKey();
                AddItemsToMenu(rowDatas, menus[0], out _, out _);

                hideSubmenuDuringRefreshSearch = false;
                menus[0].ResetHeight();
                menus[0].RefreshSearchText();
                hideSubmenuDuringRefreshSearch = true;

                menus[0].TimerUpdateIconsStart();
            }
            catch (Exception ex)
            {
                Log.Warn($"Failed to {nameof(CreateItem)}: {e.FullPath}", ex);
            }
        }
    }
}
