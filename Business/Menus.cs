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
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Handler;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;
    using Menu = SystemTrayMenu.UserInterface.Menu;
    using Timer = System.Windows.Forms.Timer;

    internal class Menus : IDisposable
    {
        private readonly Menu[] menus = new Menu[MenuDefines.MenusMax];
        private readonly BackgroundWorker workerMainMenu = new();
        private readonly List<BackgroundWorker> workersSubMenu = new();
        private readonly DgvMouseRow dgvMouseRow = new();
        private readonly WaitToLoadMenu waitToOpenMenu = new();
        private readonly KeyboardInput keyboardInput;
        private readonly JoystickHelper joystickHelper;
        private readonly List<FileSystemWatcher> watchers = new();
        private readonly List<EventArgs> watcherHistory = new();
        private readonly Timer timerShowProcessStartedAsLoadingIcon = new();
        private readonly Timer timerStillActiveCheck = new();
        private readonly WaitLeave waitLeave = new(Properties.Settings.Default.TimeUntilCloses);
        private DateTime deactivatedTime = DateTime.MinValue;
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private TaskbarPosition taskbarPosition = new WindowsTaskbar().Position;
        private bool searchTextChanging;
        private bool waitingForReactivate;
        private int lastMouseDownRowIndex = -1;
        private bool showMenuAfterMainPreload;
        private int dragSwipeScrollingStartRowIndex = -1;
        private bool isDraggingSwipeScrolling;
        private bool isDragSwipeScrolled;
        private bool hideSubmenuDuringRefreshSearch;

        public Menus()
        {
            workerMainMenu.WorkerSupportsCancellation = true;
            workerMainMenu.DoWork += LoadMenu;
            workerMainMenu.RunWorkerCompleted += LoadMainMenuCompleted;
            waitToOpenMenu.StopLoadMenu += WaitToOpenMenu_StopLoadMenu;
            waitToOpenMenu.StartLoadMenu += StartLoadMenu;
            waitToOpenMenu.CloseMenu += CloseMenu;
            waitToOpenMenu.MouseEnterOk += MouseEnterOk;
            dgvMouseRow.RowMouseEnter += waitToOpenMenu.MouseEnter;
            dgvMouseRow.RowMouseLeave += waitToOpenMenu.MouseLeave;
            dgvMouseRow.RowMouseLeave += Dgv_RowMouseLeave;
            keyboardInput = new(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += KeyboardInput_HotKeyPressed;
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;
            keyboardInput.RowSelected += AdjustScrollbarToDisplayedRow;
            joystickHelper = new();
            joystickHelper.KeyPressed += JoystickHelper_KeyPressed;
            timerShowProcessStartedAsLoadingIcon.Interval = Properties.Settings.Default.TimeUntilClosesAfterEnterPressed;
            timerStillActiveCheck.Interval = Properties.Settings.Default.TimeUntilClosesAfterEnterPressed + 20;
            timerStillActiveCheck.Tick += TimerStillActiveCheck_Tick;
            waitLeave.LeaveTriggered += FadeHalfOrOutIfNeeded;
            CreateWatchers();
        }

        public event Action LoadStarted;

        public event Action LoadStopped;

        private enum OpenCloseState
        {
            Default,
            Opening,
            Closing,
        }

        private IEnumerable<Menu> AsEnumerable => menus.Where(m => m != null && !m.IsDisposed);

        private List<Menu> AsList => AsEnumerable.ToList();

        public static MenuData GetData(BackgroundWorker worker, string path, int level)
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

        public void Dispose()
        {
            workerMainMenu.DoWork -= LoadMenu;
            workerMainMenu.RunWorkerCompleted -= LoadMainMenuCompleted;
            workerMainMenu.Dispose();
            dgvMouseRow.RowMouseEnter -= waitToOpenMenu.MouseEnter;
            dgvMouseRow.RowMouseLeave -= waitToOpenMenu.MouseLeave;
            dgvMouseRow.RowMouseLeave -= Dgv_RowMouseLeave;
            keyboardInput.HotKeyPressed -= KeyboardInput_HotKeyPressed;
            keyboardInput.ClosePressed -= MenusFadeOut;
            keyboardInput.RowDeselected -= waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed -= waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected -= waitToOpenMenu.RowSelected;
            keyboardInput.RowSelected -= AdjustScrollbarToDisplayedRow;
            keyboardInput.Dispose();
            waitToOpenMenu.StopLoadMenu -= WaitToOpenMenu_StopLoadMenu;
            waitToOpenMenu.StartLoadMenu -= StartLoadMenu;
            waitToOpenMenu.CloseMenu -= CloseMenu;
            waitToOpenMenu.MouseEnterOk -= MouseEnterOk;
            waitToOpenMenu.Dispose();
            joystickHelper.KeyPressed -= JoystickHelper_KeyPressed;
            joystickHelper.Dispose();
            timerShowProcessStartedAsLoadingIcon.Dispose();
            timerStillActiveCheck.Tick -= TimerStillActiveCheck_Tick;
            timerStillActiveCheck.Dispose();
            waitLeave.LeaveTriggered -= FadeHalfOrOutIfNeeded;
            waitLeave.Dispose();
            foreach (BackgroundWorker workerSubMenu in workersSubMenu)
            {
                workerSubMenu.DoWork -= LoadMenu;
                workerSubMenu.RunWorkerCompleted -= LoadSubMenuCompleted;
                workerSubMenu.Dispose();
            }

            IconReader.Dispose();
            dgvMouseRow.Dispose();
            DisposeMenu(menus[0]);
            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.Created -= WatcherProcessItem;
                watcher.Deleted -= WatcherProcessItem;
                watcher.Renamed -= WatcherProcessItem;
                watcher.Changed -= WatcherProcessItem;
                watcher.Dispose();
            }
        }

        public void SwitchOpenCloseByTaskbarItem()
        {
            SwitchOpenClose(true);
            timerStillActiveCheck.Start();
        }

        public bool IsOpenCloseStateOpening()
        {
            return openCloseState == OpenCloseState.Opening;
        }

        public void SwitchOpenClose(bool byClick, bool isMainPreload = false)
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
                (menus[0] != null && menus[0].Visible && openCloseState == OpenCloseState.Default))
            {
                openCloseState = OpenCloseState.Closing;
                MenusFadeOut();
                StopWorker();
                if (!AsEnumerable.Any(m => m.Visible))
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
                menuToDispose.UserClickedOpenFolder -= OpenFolder;
                menuToDispose.MouseWheel -= AdjustMenusSizeAndLocation;
                menuToDispose.MouseLeave -= waitLeave.Start;
                menuToDispose.MouseEnter -= waitLeave.Stop;
                menuToDispose.CmdKeyProcessed -= keyboardInput.CmdKeyProcessed;
                menuToDispose.KeyPressCheck -= Menu_KeyPressCheck;
                menuToDispose.SearchTextChanging -= Menu_SearchTextChanging;
                menuToDispose.SearchTextChanged -= Menu_SearchTextChanged;
                menuToDispose.UserDragsMenu -= Menu_UserDragsMenu;
                menuToDispose.Activated -= Menu_Activated;
                menuToDispose.Deactivate -= Menu_Deactivate;
                menuToDispose.VisibleChanged -= MenuVisibleChanged;
                DataGridView dgv = menuToDispose.GetDataGridView();
                if (dgv != null)
                {
                    dgv.CellMouseEnter -= dgvMouseRow.CellMouseEnter;
                    dgv.CellMouseLeave -= dgvMouseRow.CellMouseLeave;
                    dgv.MouseLeave -= dgvMouseRow.MouseLeave;
                    dgv.MouseLeave -= Dgv_MouseLeave;
                    dgv.MouseMove -= waitToOpenMenu.MouseMove;
                    dgv.MouseMove -= Dgv_MouseMove;
                    dgv.MouseDown -= Dgv_MouseDown;
                    dgv.MouseUp -= Dgv_MouseUp;
                    dgv.MouseClick -= Dgv_MouseClick;
                    dgv.MouseDoubleClick -= Dgv_MouseDoubleClick;
                    dgv.SelectionChanged -= Dgv_SelectionChanged;
                    dgv.RowPostPaint -= Dgv_RowPostPaint;
                    dgv.DataError -= Dgv_DataError;
                    dgv.ClearSelection();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        RowData rowData = (RowData)row.Cells[2].Value;
                        DisposeMenu(rowData.SubMenu);
                    }

                    DataTable dataTable = (DataTable)dgv.DataSource;
                    dataTable.Dispose();
                }

                menuToDispose.Dispose();
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
            timerShowProcessStartedAsLoadingIcon.Interval = 5;
            timerShowProcessStartedAsLoadingIcon.Start();
            void Tick(object sender, EventArgs e)
            {
                timerShowProcessStartedAsLoadingIcon.Tick -= Tick;
                timerShowProcessStartedAsLoadingIcon.Interval = Properties.Settings.Default.TimeUntilClosesAfterEnterPressed;
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
                LoadStarted?.Invoke();
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

        private static int GetRowUnderCursor(DataGridView dgv, Point location)
        {
            DataGridView.HitTestInfo myHitTest = dgv.HitTest(location.X, location.Y);
            return myHitTest.RowIndex;
        }

        private static void InvalidateRowIfIndexInRange(DataGridView dgv, int rowIndex)
        {
            if (rowIndex > -1 && rowIndex < dgv.Rows.Count)
            {
                dgv.InvalidateRow(rowIndex);
            }
        }

        private static void AddItemsToMenu(List<RowData> data, Menu menu, out int foldersCount, out int filesCount)
        {
            foldersCount = 0;
            filesCount = 0;
            DataGridView dgv = menu.GetDataGridView();
            DataTable dataTable = new();
            dataTable.Columns.Add(dgv.Columns[0].Name, typeof(Icon));
            dataTable.Columns.Add(dgv.Columns[1].Name, typeof(string));
            dataTable.Columns.Add("data", typeof(RowData));
            dataTable.Columns.Add("SortIndex");
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

            dgv.DataSource = dataTable;
            dgv.Columns["data"].Visible = false;
            dgv.Columns["SortIndex"].Visible = false;

            string columnSortIndex = "SortIndex";
            foreach (DataRow row in dataTable.Rows)
            {
                RowData rowData = (RowData)row[2];
                if (rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult)
                {
                    row[columnSortIndex] = 99;
                }
                else
                {
                    row[columnSortIndex] = 0;
                }
            }
        }

        private void LoadMainMenuCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            keyboardInput.ResetSelectedByKey();
            LoadStopped();

            if (e.Result == null)
            {
                // Clean up menu status IsMenuOpen for previous one
                DataGridView dgvMainMenu = menus[0].GetDataGridView();
                foreach (DataRow row in ((DataTable)dgvMainMenu.DataSource).Rows)
                {
                    RowData rowDataToClear = (RowData)row[2];
                    rowDataToClear.IsMenuOpen = false;
                    rowDataToClear.IsClicking = false;
                    rowDataToClear.IsSelected = false;
                    rowDataToClear.IsContextMenuOpen = false;
                }

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
                            Scaling.CalculateFactorByDpi(menus[0].GetDataGridView().CreateGraphics());
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

        private void WaitToOpenMenu_StopLoadMenu()
        {
            foreach (BackgroundWorker workerSubMenu in workersSubMenu.Where(w => w.IsBusy))
            {
                workerSubMenu.CancelAsync();
            }

            LoadStopped();
        }

        private void StartLoadMenu(RowData rowData)
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
                    workerSubMenu = new BackgroundWorker()
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

        private void CloseMenu(int level)
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

        private void LoadSubMenuCompleted(object senderCompleted, RunWorkerCompletedEventArgs e)
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

        private bool IsActive()
        {
            bool IsShellContextMenuOpen()
            {
                bool isShellContextMenuOpen = false;
                foreach (Menu menu in menus.Where(m => m != null))
                {
                    DataGridView dgv = menu.GetDataGridView();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        RowData rowData = (RowData)row.Cells[2].Value;
                        if (rowData != null && rowData.IsContextMenuOpen)
                        {
                            isShellContextMenuOpen = true;
                            break;
                        }
                    }

                    if (isShellContextMenuOpen)
                    {
                        break;
                    }
                }

                return isShellContextMenuOpen;
            }

            return Form.ActiveForm is Menu or TaskbarForm || IsShellContextMenuOpen();
        }

        private Menu Create(MenuData menuData, string title = null)
        {
            Menu menu = new();
            menu.Level = menuData.Level;
            menu.Path = Config.Path;
            if (title == null)
            {
                title = new DirectoryInfo(menuData.RowDataParent.ResolvedPath).Name;
                menu.Path = menuData.RowDataParent.ResolvedPath;
            }

            if (string.IsNullOrEmpty(title))
            {
                title = Path.GetPathRoot(menu.Path);
            }

            menu.AdjustControls(title, menuData.Validity);
            menu.UserClickedOpenFolder += OpenFolder;
            menu.MouseWheel += AdjustMenusSizeAndLocation;
            menu.MouseLeave += waitLeave.Start;
            menu.MouseEnter += waitLeave.Stop;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.KeyPressCheck += Menu_KeyPressCheck;
            menu.SearchTextChanging += Menu_SearchTextChanging;
            menu.SearchTextChanged += Menu_SearchTextChanged;
            menu.UserDragsMenu += Menu_UserDragsMenu;
            menu.Activated += Menu_Activated;
            menu.Deactivate += Menu_Deactivate;
            menu.VisibleChanged += MenuVisibleChanged;
            AddItemsToMenu(menuData.RowDatas, menu, out int foldersCount, out int filesCount);

            DataGridView dgv = menu.GetDataGridView();
            dgv.CellMouseEnter += dgvMouseRow.CellMouseEnter;
            dgv.CellMouseLeave += dgvMouseRow.CellMouseLeave;
            dgv.MouseLeave += dgvMouseRow.MouseLeave;
            dgv.MouseLeave += Dgv_MouseLeave;
            dgv.MouseMove += waitToOpenMenu.MouseMove;
            dgv.MouseMove += Dgv_MouseMove;
            dgv.MouseDown += Dgv_MouseDown;
            dgv.MouseUp += Dgv_MouseUp;
            dgv.MouseClick += Dgv_MouseClick;
            dgv.MouseDoubleClick += Dgv_MouseDoubleClick;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.RowPostPaint += Dgv_RowPostPaint;
            dgv.DataError += Dgv_DataError;

            menu.SetCounts(foldersCount, filesCount);

            return menu;
        }

        private void Menu_UserDragsMenu()
        {
            if (menus[1] != null)
            {
                HideOldMenu(menus[1]);
            }
        }

        private void Menu_Activated(object sender, EventArgs e)
        {
            if (IsActive() && menus[0].IsUsable)
            {
                AsList.ForEach(m => m.ShowWithFade());
                timerStillActiveCheck.Stop();
                timerStillActiveCheck.Start();
            }
        }

        private void Menu_Deactivate(object sender, EventArgs e)
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

            if (!menu.Visible && menu.Level != 0)
            {
                DisposeMenu(menu);
            }

            if (!AsEnumerable.Any(m => m.Visible))
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
                DataGridView dgv = (DataGridView)sender;
                int newRow = GetRowUnderCursor(dgv, e.Location);
                if (newRow > -1)
                {
                    int delta = dragSwipeScrollingStartRowIndex - newRow;
                    if (DoScroll(dgv, ref delta))
                    {
                        dragSwipeScrollingStartRowIndex += delta;
                    }
                }
            }
        }

        private bool DoScroll(DataGridView dgv, ref int delta)
        {
            bool scrolled = false;
            if (delta != 0)
            {
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
                    Menu menu = (Menu)dgv.FindForm();
                    menu.AdjustScrollbar();
                    scrolled = dgv.FirstDisplayedScrollingRowIndex == newFirstDisplayedScrollingRowIndex;
                }
            }

            return scrolled;
        }

        private void Dgv_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                hitTestInfo.RowIndex < dgv.Rows.Count)
            {
                MouseEnterOk(dgv, hitTestInfo.RowIndex, true);
                RowData rowData = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                rowData.MouseDown(dgv, e);
                InvalidateRowIfIndexInRange(dgv, hitTestInfo.RowIndex);
            }

            if (e.Button == MouseButtons.Left)
            {
                lastMouseDownRowIndex = hitTestInfo.RowIndex;
            }

            Menu menu = (Menu)((DataGridView)sender).FindForm();
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
        }

        private void Dgv_MouseUp(object sender, MouseEventArgs e)
        {
            lastMouseDownRowIndex = -1;
            isDraggingSwipeScrolling = false;
            isDragSwipeScrolled = false;

            // In case during mouse down move mouse out of dgv (it has own scrollbehavior) which we need to refresh
            Menu menu = (Menu)((DataGridView)sender).FindForm();
            menu.AdjustScrollbar();
        }

        private void Dgv_MouseLeave(object sender, EventArgs e)
        {
            isDraggingSwipeScrolling = false;
            isDragSwipeScrolled = false;
        }

        private void MouseEnterOk(DataGridView dgv, int rowIndex)
        {
            MouseEnterOk(dgv, rowIndex, false);
        }

        private void MouseEnterOk(DataGridView dgv, int rowIndex, bool refreshView)
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

        private void Dgv_RowMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (!isDragSwipeScrolled &&
                e.RowIndex == lastMouseDownRowIndex &&
                e.RowIndex > -1 &&
                e.RowIndex < dgv.Rows.Count)
            {
                lastMouseDownRowIndex = -1;
                RowData rowData = (RowData)dgv.Rows[e.RowIndex].Cells[2].Value;
                string[] files = new string[] { rowData.Path };

                // Update position raises move event which prevent DoDragDrop blocking UI when mouse not moved
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);

                dgv.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
            }
        }

        private void Dgv_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (!isDragSwipeScrolled &&
                hitTestInfo.RowIndex == lastMouseDownRowIndex &&
                hitTestInfo.RowIndex > -1 &&
                hitTestInfo.RowIndex < dgv.Rows.Count)
            {
                lastMouseDownRowIndex = -1;
                RowData rowData = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                rowData.MouseClick(e, out bool toCloseByClick);
                waitToOpenMenu.ClickOpensInstantly(dgv, hitTestInfo.RowIndex);
                if (toCloseByClick)
                {
                    MenusFadeOut();
                }
            }

            lastMouseDownRowIndex = -1;
        }

        private void Dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                dgv.Rows.Count > hitTestInfo.RowIndex)
            {
                lastMouseDownRowIndex = -1;
                RowData rowData = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                rowData.DoubleClick(e, out bool toCloseByDoubleClick);
                InvalidateRowIfIndexInRange(dgv, hitTestInfo.RowIndex);
                if (toCloseByDoubleClick)
                {
                    MenusFadeOut();
                }
            }

            lastMouseDownRowIndex = -1;
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            RefreshSelection((DataGridView)sender);
        }

        private void RefreshSelection(DataGridView dgv)
        {
            dgv.SelectionChanged -= Dgv_SelectionChanged;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;

                if (rowData == null)
                {
                    // Case when filtering a previous menu
                }
                else if (!menus[0].IsUsable)
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.Selected = false;
                }
                else if (rowData.IsClicking)
                {
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorIcons;
                    row.Selected = true;
                }
                else if (rowData.IsContextMenuOpen || (rowData.IsMenuOpen && rowData.IsSelected))
                {
                    row.Selected = true;
                }
                else if (rowData.IsMenuOpen)
                {
                    row.Selected = true;
                }
                else if (rowData.IsSelected)
                {
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
                    row.Selected = true;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.Selected = false;
                }
            }

            dgv.SelectionChanged += Dgv_SelectionChanged;

            if (!searchTextChanging)
            {
                dgv.Invalidate();
            }
        }

        private void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

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

        private void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // WARN Dgv_DataError occured System.ObjectDisposedException: Cannot access a disposed object. Object name: 'Icon'
            // => Rare times occured (e.g. when focused an close other application => closed and activated at same time)
            Log.Warn("Dgv_DataError occured", e.Exception);
        }

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
                DataGridView dgvPrevious = menuPrevious.GetDataGridView();
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
                    Point position = Control.MousePosition;
                    if (Properties.Settings.Default.StaysOpenWhenFocusLost &&
                        AsList.Any(m => m.IsMouseOn(position)))
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

        private void CreateWatchers()
        {
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

        private void AdjustScrollbarToDisplayedRow(DataGridView dgv, int index)
        {
            Menu menu = (Menu)dgv.FindForm();
            menu.AdjustScrollbar();
        }

        private void JoystickHelper_KeyPressed(Keys keys)
        {
            menus[0].Invoke(keyboardInput.CmdKeyProcessed, null, keys);
        }

        private void TimerStillActiveCheck_Tick(object sender, EventArgs e)
        {
            if (!IsActive())
            {
                FadeHalfOrOutIfNeeded();
            }

            timerStillActiveCheck.Stop();
        }

        private void KeyboardInput_HotKeyPressed()
        {
            SwitchOpenClose(false);
        }

        private void AdjustMenusSizeAndLocation()
        {
            Rectangle screenBounds;
            bool isCustomLocationOutsideOfScreen = false;
            if (Properties.Settings.Default.AppearAtMouseLocation)
            {
                screenBounds = Screen.FromPoint(Cursor.Position).Bounds;
            }
            else if (Properties.Settings.Default.UseCustomLocation)
            {
                screenBounds = Screen.FromPoint(new Point(
                    Properties.Settings.Default.CustomLocationX,
                    Properties.Settings.Default.CustomLocationY)).Bounds;

                isCustomLocationOutsideOfScreen = !screenBounds.Contains(
                    new Point(Properties.Settings.Default.CustomLocationX, Properties.Settings.Default.CustomLocationY));
            }
            else
            {
                screenBounds = Screen.PrimaryScreen.Bounds;
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

                // Only last one has to be updated as all previous one were already updated in the past
                if (list.Count - 1 == i)
                {
                    menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation, isCustomLocationOutsideOfScreen);
                }
                else
                {
                    // workaround added also as else, because need adjust scrollbar after search
                    menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation, isCustomLocationOutsideOfScreen);
                }

                if (!Properties.Settings.Default.AppearAtTheBottomLeft &&
                    !Properties.Settings.Default.AppearAtMouseLocation &&
                    !Properties.Settings.Default.UseCustomLocation &&
                    i == 0)
                {
                    const int overlapTolerance = 4;

                    // Remember width of the initial menu as we don't want to overlap with it
                    if (taskbarPosition == TaskbarPosition.Left)
                    {
                        screenBounds.X += menu.Width - overlapTolerance;
                    }

                    screenBounds.Width -= menu.Width - overlapTolerance;
                }

                menuPredecessor = menu;
            }
        }

        private void Menu_KeyPressCheck(object sender, KeyPressEventArgs e)
        {
            if (isDraggingSwipeScrolling)
            {
                e.Handled = true;
            }
        }

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
                menus[0]?.Invoke(() => RenameItem(renamedEventArgs));
            }
            else if (e is FileSystemEventArgs fileSystemEventArgs)
            {
                if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Deleted)
                {
                    menus[0]?.Invoke(() => DeleteItem(e as FileSystemEventArgs));
                }
                else if (fileSystemEventArgs.ChangeType == WatcherChangeTypes.Created)
                {
                    menus[0]?.Invoke(() => CreateItem(e as FileSystemEventArgs));
                }
            }
        }

        private void RenameItem(RenamedEventArgs e)
        {
            try
            {
                List<RowData> rowDatas = new();
                DataTable dataTable = (DataTable)menus[0].GetDataGridView().DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    RowData rowData = (RowData)row[2];
                    if (rowData.Path.StartsWith($"{e.OldFullPath}"))
                    {
                        string path = rowData.Path.Replace(e.OldFullPath, e.FullPath);
                        if (rowData.IsFolder)
                        {
                            path = Path.GetDirectoryName(path);
                        }

                        RowData rowDataRenamed = new(rowData.IsFolder, rowData.IsAddionalItem, false, 0, path);
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
                DataGridView dgv = menus[0].GetDataGridView();
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

                DataTable dataTable = (DataTable)menus[0].GetDataGridView().DataSource;
                foreach (DataRow row in dataTable.Rows)
                {
                    rowDatas.Add((RowData)row[2]);
                }

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
