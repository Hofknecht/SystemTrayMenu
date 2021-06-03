// <copyright file="Menus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Handler;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;
    using Menu = SystemTrayMenu.UserInterface.Menu;
    using Timer = System.Windows.Forms.Timer;

    internal class Menus : IDisposable
    {
        private readonly Menu[] menus = new Menu[MenuDefines.MenusMax];
        private readonly BackgroundWorker workerMainMenu = new BackgroundWorker();
        private readonly List<BackgroundWorker> workersSubMenu = new List<BackgroundWorker>();

        private readonly DgvMouseRow dgvMouseRow = new DgvMouseRow();
        private readonly WaitToLoadMenu waitToOpenMenu = new WaitToLoadMenu();
        private readonly KeyboardInput keyboardInput;
        private readonly Timer timerStillActiveCheck = new Timer();
        private readonly WaitLeave waitLeave = new WaitLeave(Properties.Settings.Default.TimeUntilCloses);
        private DateTime deactivatedTime = DateTime.MinValue;
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private RowData loadingRowData;
        private bool showingMessageBox;
        private TaskbarPosition taskbarPosition = new WindowsTaskbar().Position;
        private bool searchTextChanging;

        public Menus()
        {
            workerMainMenu.WorkerSupportsCancellation = true;
            workerMainMenu.DoWork += LoadMenu;
            static void LoadMenu(object senderDoWork, DoWorkEventArgs eDoWork)
            {
                string path = Config.Path;
                int level = 0;
                RowData rowData = eDoWork.Argument as RowData;
                if (rowData != null)
                {
                    path = rowData.TargetFilePath;
                    level = rowData.MenuLevel + 1;
                }

                MenuData menuData = GetData((BackgroundWorker)senderDoWork, path, level);
                menuData.RowDataParent = rowData;
                eDoWork.Result = menuData;
            }

            workerMainMenu.RunWorkerCompleted += LoadMainMenuCompleted;
            void LoadMainMenuCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                keyboardInput.ResetSelectedByKey();
                LoadStopped();
                MenuData menuData = (MenuData)e.Result;
                switch (menuData.Validity)
                {
                    case MenuDataValidity.Valid:
                        DisposeMenu(menus[menuData.Level]);
                        menus[0] = Create(menuData, Path.GetFileName(Config.Path));
                        AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
                        break;
                    case MenuDataValidity.Empty:
                        if (!showingMessageBox)
                        {
                            showingMessageBox = true;
                            MessageBox.Show(Translator.GetText(
                                "MessageRootFolderEmpty"));
                            OpenFolder();
                            showingMessageBox = false;
                        }

                        break;
                    case MenuDataValidity.NoAccess:
                        if (!showingMessageBox)
                        {
                            showingMessageBox = true;
                            MessageBox.Show(Translator.GetText(
                            "MessageRootFolderNoAccess"));
                            OpenFolder();
                            showingMessageBox = false;
                        }

                        break;
                    case MenuDataValidity.AbortedOrUnknown:
                        Log.Info("MenuDataValidity.AbortedOrUnknown");
                        break;
                    default:
                        break;
                }
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
                    loadingRowData != rowData &&
                    (menus[rowData.MenuLevel + 1] == null ||
                    menus[rowData.MenuLevel + 1].Tag as RowData != rowData))
                {
                    loadingRowData = rowData;
                    LoadStarted();
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
                    LoadStopped();
                    MenuData menuData = (MenuData)e.Result;
                    if (menus[0].IsUsable &&
                        menuData.Validity != MenuDataValidity.AbortedOrUnknown)
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
                        }
                    }

                    loadingRowData = null;
                }
            }

            waitToOpenMenu.CloseMenu += CloseMenu;
            void CloseMenu(int level)
            {
                if (menus[level] != null)
                {
                    HideOldMenu(menus[level]);
                }

                if (menus[level - 1] != null)
                {
                    menus[level - 1].FocusTextBox();
                }
            }

            waitToOpenMenu.MouseEnterOk += MouseEnterOk;
            void MouseEnterOk(DataGridView dgv, int rowIndex)
            {
                if (menus[0].IsUsable)
                {
                    if (keyboardInput.InUse)
                    {
                        keyboardInput.ClearIsSelectedByKey();
                        keyboardInput.InUse = false;
                    }

                    keyboardInput.Select(dgv, rowIndex, false);
                }
            }

            dgvMouseRow.RowMouseEnter += waitToOpenMenu.MouseEnter;
            dgvMouseRow.RowMouseLeave += waitToOpenMenu.MouseLeave;

            keyboardInput = new KeyboardInput(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += KeyboardInput_HotKeyPressed;
            void KeyboardInput_HotKeyPressed()
            {
                SwitchOpenClose(false);
            }

            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;
            keyboardInput.RowSelected += AdjustScrollbarToDisplayedRow;
            void AdjustScrollbarToDisplayedRow(DataGridView dgv, int index)
            {
#warning to improve arguments, do not use .Parent.Parent.Parent
                Menu menu = dgv.Parent.Parent.Parent as Menu;
                menu.AdjustScrollbar();
            }

            timerStillActiveCheck.Interval = 1000;
            timerStillActiveCheck.Tick += StillActiveTick;
            void StillActiveTick(object senderTimer, EventArgs eTimer)
            {
                if (!IsActive())
                {
                    FadeHalfOrOutIfNeeded();
                    timerStillActiveCheck.Stop();
                }
            }

            waitLeave.LeaveTriggered += LeaveTriggered;
            void LeaveTriggered()
            {
                FadeHalfOrOutIfNeeded();
            }
        }

        internal event EventHandlerEmpty LoadStarted;

        internal event EventHandlerEmpty LoadStopped;

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
            timerStillActiveCheck.Dispose();
            waitLeave.Dispose();
            IconReader.Dispose();
            DisposeMenu(menus[0]);
            loadingRowData?.Dispose();
            dgvMouseRow.Dispose();
        }

        internal static MenuData GetData(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new MenuData
            {
                RowDatas = new List<RowData>(),
                Validity = MenuDataValidity.AbortedOrUnknown,
                Level = level,
            };
            if (!worker.CancellationPending)
            {
                string[] directories = Array.Empty<string>();

                try
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        Log.Info($"path is null or empty");
                    }
                    else if (FileLnk.IsNetworkRoot(path))
                    {
                        directories = GetDirectoriesInNetworkLocation(path);
                        static string[] GetDirectoriesInNetworkLocation(string networkLocationRootPath)
                        {
                            List<string> directories = new List<string>();
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            cmd.Start();
                            cmd.StandardInput.WriteLine($"net view {networkLocationRootPath}");
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();

                            string output = cmd.StandardOutput.ReadToEnd();

                            cmd.WaitForExit();
                            cmd.Close();

                            bool resolvedSomething = false;

                            List<string> lines = output
                                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (lines.Count > 8)
                            {
                                foreach (string line in lines.Skip(6).SkipLast(2))
                                {
                                    int indexOfFirstSpace = line.IndexOf("  ", StringComparison.InvariantCulture);
                                    if (indexOfFirstSpace > 0)
                                    {
                                        string directory = Path.Combine(
                                            networkLocationRootPath,
                                            line.Substring(0, indexOfFirstSpace));

                                        directories.Add(directory);
                                        resolvedSomething = true;
                                    }
                                }
                            }

                            if (!resolvedSomething)
                            {
                                Log.Info($"Could not resolve network root folder: {networkLocationRootPath} , output:{output}");
                            }

                            return directories.ToArray();
                        }
                    }
                    else
                    {
                        directories = Directory.GetDirectories(path);
                    }

                    Array.Sort(directories, new WindowsExplorerSort());
                }
                catch (UnauthorizedAccessException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
                catch (IOException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                }

                foreach (string directoryWithIllegalCharacters in directories)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

                    // https://github.com/Hofknecht/SystemTrayMenu/issues/171
                    string directory = directoryWithIllegalCharacters.Replace("\x00", string.Empty);

                    bool hiddenEntry = false;
                    if (FolderOptions.IsHidden(directory, ref hiddenEntry))
                    {
                        continue;
                    }

                    RowData rowData = ReadRowData(directory, false);
                    rowData.ContainsMenu = true;
                    rowData.HiddenEntry = hiddenEntry;
                    string resolvedLnkPath = string.Empty;
                    rowData.ReadIcon(true, ref resolvedLnkPath);
                    rowData.MenuLevel = level;
                    menuData.RowDatas.Add(rowData);
                }
            }

            if (!worker.CancellationPending)
            {
                string[] files = Array.Empty<string>();

                try
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        Log.Info($"path is null or empty");
                    }
                    else if (!FileLnk.IsNetworkRoot(path))
                    {
                        files = Directory.GetFiles(path);
                    }

                    Array.Sort(files, new WindowsExplorerSort());
                }
                catch (UnauthorizedAccessException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
                catch (IOException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                }

                foreach (string fileWithIllegalCharacters in files)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

                    // https://github.com/Hofknecht/SystemTrayMenu/issues/171
                    string file = fileWithIllegalCharacters.Replace("\x00", string.Empty);

                    bool hiddenEntry = false;
                    if (FolderOptions.IsHidden(file, ref hiddenEntry))
                    {
                        continue;
                    }

                    RowData rowData = ReadRowData(file, false);
                    string resolvedLnkPath = string.Empty;
                    if (rowData.ReadIcon(false, ref resolvedLnkPath))
                    {
                        rowData = ReadRowData(resolvedLnkPath, true, rowData);
                        rowData.ContainsMenu = true;
                        rowData.HiddenEntry = hiddenEntry;
                    }

                    menuData.RowDatas.Add(rowData);
                }
            }

            if (!worker.CancellationPending)
            {
                if (menuData.Validity == MenuDataValidity.AbortedOrUnknown)
                {
                    if (menuData.RowDatas.Count == 0)
                    {
                        menuData.Validity = MenuDataValidity.Empty;
                    }
                    else
                    {
                        menuData.Validity = MenuDataValidity.Valid;
                    }
                }
            }

            return menuData;
        }

        internal void SwitchOpenClose(bool byClick)
        {
            waitToOpenMenu.MouseActive = byClick;
            if (byClick && (DateTime.Now - deactivatedTime).TotalMilliseconds < 200)
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
                StartWorker();
            }

            deactivatedTime = DateTime.MinValue;
        }

        internal void DisposeMenu(Menu menuToDispose)
        {
            if (menuToDispose != null)
            {
                menuToDispose.MouseWheel -= AdjustMenusSizeAndLocation;
                menuToDispose.MouseLeave -= waitLeave.Start;
                menuToDispose.MouseEnter -= waitLeave.Stop;
                menuToDispose.KeyPress -= keyboardInput.KeyPress;
                menuToDispose.CmdKeyProcessed -= keyboardInput.CmdKeyProcessed;
                menuToDispose.SearchTextChanging -= keyboardInput.SearchTextChanging;
                menuToDispose.SearchTextChanged -= Menu_SearchTextChanged;
                DataGridView dgv = menuToDispose.GetDataGridView();
                if (dgv != null)
                {
                    dgv.CellMouseEnter -= dgvMouseRow.CellMouseEnter;
                    dgv.CellMouseLeave -= dgvMouseRow.CellMouseLeave;
                    dgv.MouseLeave -= dgvMouseRow.MouseLeave;
                    dgv.MouseMove -= waitToOpenMenu.MouseMove;
                    dgv.MouseDown -= Dgv_MouseDown;
                    dgv.MouseDoubleClick -= Dgv_MouseDoubleClick;
                    dgv.SelectionChanged -= Dgv_SelectionChanged;
                    dgv.RowPostPaint -= Dgv_RowPostPaint;
                    dgv.ClearSelection();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        RowData rowData = (RowData)row.Cells[2].Value;
                        rowData?.Dispose();
                        DisposeMenu(rowData.SubMenu);
                    }
                }

                menuToDispose.Dispose();
            }
        }

        internal void MainPreload()
        {
            menus[0] = Create(
                GetData(workerMainMenu, Config.Path, 0),
                Path.GetFileName(Config.Path));
            AdjustMenusSizeAndLocation();
            DisposeMenu(menus[0]);
        }

        internal void StartWorker()
        {
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

        private static RowData ReadRowData(string fileName, bool isResolvedLnk, RowData rowData = null)
        {
            if (rowData == null)
            {
                rowData = new RowData();
            }

            rowData.IsResolvedLnk = isResolvedLnk;

            try
            {
                rowData.FileInfo = new FileInfo(fileName);
                rowData.TargetFilePath = rowData.FileInfo.FullName;
                if (!isResolvedLnk)
                {
                    if (string.IsNullOrEmpty(rowData.FileInfo.Name))
                    {
                        string path = rowData.FileInfo.FullName;
                        int directoryNameBegin = path.LastIndexOf(@"\", StringComparison.InvariantCulture) + 1;
                        rowData.SetText(path.Substring(directoryNameBegin));
                    }
                    else
                    {
                        rowData.SetText(rowData.FileInfo.Name);
                    }

                    rowData.TargetFilePathOrig = rowData.FileInfo.FullName;
                }
            }
            catch (Exception ex)
            {
                if (ex is SecurityException ||
                    ex is ArgumentException ||
                    ex is UnauthorizedAccessException ||
                    ex is PathTooLongException ||
                    ex is NotSupportedException)
                {
                    Log.Warn($"fileName:'{fileName}'", ex);
                }
                else
                {
                    throw;
                }
            }

            return rowData;
        }

        private static bool IsActive()
        {
            return Form.ActiveForm is Menu;
        }

        private static void OpenFolder()
        {
            Log.ProcessStart(Config.Path);
        }

        private Menu Create(MenuData menuData, string title = null)
        {
            Menu menu = new Menu();

            if (title != null)
            {
                if (string.IsNullOrEmpty(title))
                {
                    title = Path.GetPathRoot(Config.Path);
                }

                menu.SetTitle(title);
                menu.UserClickedOpenFolder += OpenFolder;
            }

            menu.Level = menuData.Level;
            menu.MouseWheel += AdjustMenusSizeAndLocation;
            menu.MouseLeave += waitLeave.Start;
            menu.MouseEnter += waitLeave.Stop;
            menu.KeyPress += keyboardInput.KeyPress;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.SearchTextChanging += Menu_SearchTextChanging;
            menu.SearchTextChanged += Menu_SearchTextChanged;
            menu.Deactivate += Deactivate;
            void Deactivate(object sender, EventArgs e)
            {
                FadeHalfOrOutIfNeeded();
                if (!IsActive())
                {
                    deactivatedTime = DateTime.Now;
                }
            }

            menu.Activated += Activated;
            void Activated(object sender, EventArgs e)
            {
                if (IsActive() &&
                    menus[0].IsUsable)
                {
                    AsList.ForEach(m => m.ShowWithFade());
                    timerStillActiveCheck.Start();
                }
            }

            menu.VisibleChanged += MenuVisibleChanged;
            AddItemsToMenu(menuData.RowDatas, menu);
            static void AddItemsToMenu(List<RowData> data, Menu menu)
            {
                DataGridView dgv = menu.GetDataGridView();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(dgv.Columns[0].Name, typeof(Icon));
                dataTable.Columns.Add(dgv.Columns[1].Name, typeof(string));
                dataTable.Columns.Add("data", typeof(RowData));
                dataTable.Columns.Add("SortIndex");
                foreach (RowData rowData in data)
                {
                    rowData.SetData(rowData, dataTable);
                }

                dgv.DataSource = dataTable;
                dgv.Columns["data"].Visible = false;
                dgv.Columns["SortIndex"].Visible = false;
            }

            DataGridView dgv = menu.GetDataGridView();
            dgv.CellMouseEnter += dgvMouseRow.CellMouseEnter;
            dgv.CellMouseLeave += dgvMouseRow.CellMouseLeave;
            dgv.MouseLeave += dgvMouseRow.MouseLeave;
            dgv.MouseMove += waitToOpenMenu.MouseMove;
            dgv.MouseDown += Dgv_MouseDown;
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

            return menu;
        }

        private void MenuVisibleChanged(object sender, EventArgs e)
        {
            Menu menu = (Menu)sender;
            if (menu.IsUsable)
            {
                AdjustMenusSizeAndLocation();
            }

            if (!menu.Visible)
            {
                DisposeMenu(menu);
            }

            if (!AsEnumerable.Any(m => m.Visible))
            {
                openCloseState = OpenCloseState.Default;
            }
        }

        private void Dgv_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                dgv.Rows.Count > hitTestInfo.RowIndex)
            {
                RowData rowData = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                rowData.MouseDown(dgv, e, out bool toCloseByClick);
                waitToOpenMenu.ClickOpensInstantly(dgv, hitTestInfo.RowIndex);
                if (toCloseByClick)
                {
                    MenusFadeOut();
                }
            }
        }

        private void Dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                dgv.Rows.Count > hitTestInfo.RowIndex)
            {
                RowData trigger = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                trigger.DoubleClick(e, out bool toCloseByDoubleClick);
                if (toCloseByDoubleClick)
                {
                    MenusFadeOut();
                }
            }
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
                Rectangle rowBounds = new Rectangle(0, e.RowBounds.Top, width, e.RowBounds.Height);

                if (rowData.IsContextMenuOpen || (rowData.IsMenuOpen && rowData.IsSelected))
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
                }
                else if (rowData.IsMenuOpen)
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorOpenFolderBorder, ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorOpenFolder;
                }
            }
        }

        private void ShowSubMenu(Menu menuToShow)
        {
            HideOldMenu(menuToShow, true);

            menus[menuToShow.Level] = menuToShow;
            AdjustMenusSizeAndLocation();
            menus[menuToShow.Level].ShowWithFadeOrTransparent(IsActive());
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
                    menuToClose.VisibleChanged += MenuVisibleChanged;
                    menuToClose.HideWithFade();
                    menus[menuToClose.Level] = null;
                }
            }
        }

        private void FadeHalfOrOutIfNeeded()
        {
            if (menus[0].IsUsable)
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
        }

        private void AdjustMenusSizeAndLocation()
        {
            Rectangle screenBounds;
            if (Properties.Settings.Default.AppearAtMouseLocation)
            {
                screenBounds = Screen.FromPoint(Cursor.Position).Bounds;
            }
            else
            {
                screenBounds = Screen.PrimaryScreen.Bounds;
            }

            // Only apply taskbar position change when no menu is currently open
            List<Menu> list = AsList;
            WindowsTaskbar taskbar = new WindowsTaskbar();
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

            Menu menu;
            Menu menuPredecessor = null;
            for (int i = 0; i < list.Count; i++)
            {
                menu = list[i];

                // Only last one has to be updated as all previous one were already updated in the past
                if (list.Count - 1 == i)
                {
                    menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation);
                }
#warning workaround added also as else, because need adjust scrollbar after search
                else
                {
                    menu.AdjustSizeAndLocation(screenBounds, menuPredecessor, startLocation);
                }

                if (i == 0)
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

        private void Menu_SearchTextChanging()
        {
            searchTextChanging = true;
            keyboardInput.SearchTextChanging();
        }

        private void Menu_SearchTextChanged(object sender, EventArgs e)
        {
            keyboardInput.SearchTextChanged(sender, e);
            AdjustMenusSizeAndLocation();
            searchTextChanging = false;
        }
    }
}
