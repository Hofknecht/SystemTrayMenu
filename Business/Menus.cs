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

namespace SystemTrayMenu.Business
{
    internal class Menus : IDisposable
    {
        internal event EventHandlerEmpty LoadStarted;
        internal event EventHandlerEmpty LoadStopped;
        private enum OpenCloseState { Default, Opening, Closing };
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private readonly Menu[] menus = new Menu[MenuDefines.MenusMax];
        private readonly BackgroundWorker workerMainMenu = new BackgroundWorker();
        private readonly List<BackgroundWorker> workersSubMenu = new List<BackgroundWorker>();

        private readonly WaitToLoadMenu waitToOpenMenu = new WaitToLoadMenu();
        private readonly KeyboardInput keyboardInput = null;
        private readonly Timer timerStillActiveCheck = new Timer();
        private readonly WaitLeave waitLeave = new WaitLeave(MenuDefines.TimeUntilClose);
        private DateTime deactivatedTime = DateTime.MinValue;

        private IEnumerable<Menu> AsEnumerable => menus.Where(m => m != null && !m.IsDisposed);
        private List<Menu> AsList => AsEnumerable.ToList();

        private readonly int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private readonly int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private readonly int screenRight = Screen.PrimaryScreen.Bounds.Right;
        private readonly int taskbarHeight = new WindowsTaskbar().Size.Height;

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
                if (menuData.Validity == MenuDataValidity.Valid)
                {
                    DisposeMenu(menus[menuData.Level]);
                    menus[0] = Create(menuData, Path.GetFileName(Config.Path));
                    AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
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
            }

            waitToOpenMenu.StartLoadMenu += StartLoadMenu;
            void StartLoadMenu(RowData rowData)
            {
                if (menus[0].IsUsable &&
                    (menus[rowData.MenuLevel + 1] == null ||
                    menus[rowData.MenuLevel + 1].Tag as RowData != rowData))
                {
                    LoadStarted();
                    BackgroundWorker workerSubMenu = workersSubMenu.
                        Where(w => !w.IsBusy).FirstOrDefault();
                    if (workerSubMenu == null)
                    {
                        workerSubMenu = new BackgroundWorker
                        {
                            WorkerSupportsCancellation = true
                        };
                        workerSubMenu.DoWork += LoadMenu;
                        workerSubMenu.RunWorkerCompleted += LoadSubMenuCompleted;
                        workersSubMenu.Add(workerSubMenu);
                    }
                    workerSubMenu.RunWorkerAsync(rowData); ;
                }

                void LoadSubMenuCompleted(object senderCompleted,
                        RunWorkerCompletedEventArgs e)
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
                }
            }

            waitToOpenMenu.CloseMenu += CloseMenu;
            void CloseMenu(int level)
            {
                if (menus[level] != null)
                {
                    menus[level - 1].FocusTextBox();
                    HideOldMenu(menus[level]);
                }
            }

            keyboardInput = new KeyboardInput(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += KeyboardInput_HotKeyPressed;
            void KeyboardInput_HotKeyPressed()
            {
                SwitchOpenClose(false);
            }

            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;

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

        internal void SwitchOpenCloseByTaskbarItem()
        {
            SwitchOpenClose(true);
            timerStillActiveCheck.Start();
        }

        internal void SwitchOpenClose(bool byClick)
        {
            waitToOpenMenu.MouseActive = byClick;
            if (byClick && (DateTime.Now - deactivatedTime).TotalMilliseconds < 200)
            {
                //By click on notifyicon the menu gets deactivated and closed
            }
            else if (string.IsNullOrEmpty(Config.Path))
            {
                //Case when Folder Dialog open
            }
            else if (openCloseState == OpenCloseState.Opening ||
                menus[0].Visible && openCloseState == OpenCloseState.Default)
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
                dgv.CellMouseEnter -= waitToOpenMenu.MouseEnter;
                dgv.CellMouseLeave -= waitToOpenMenu.MouseLeave;
                dgv.MouseMove -= waitToOpenMenu.MouseMove;
                dgv.MouseDown -= Dgv_MouseDown;
                dgv.MouseDoubleClick -= Dgv_MouseDoubleClick;
                dgv.SelectionChanged -= Dgv_SelectionChanged;
                dgv.RowPostPaint -= Dgv_RowPostPaint;
                dgv.ClearSelection();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    RowData rowData = (RowData)row.Cells[2].Value;
                    rowData.Dispose();
                    DisposeMenu(rowData.SubMenu);
                }

                menuToDispose.Dispose();
            }
        }

        internal static MenuData GetData(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new MenuData
            {
                RowDatas = new List<RowData>(),
                Validity = MenuDataValidity.AbortedOrUnknown,
                Level = level
            };
            if (!worker.CancellationPending)
            {
                string[] directories = Array.Empty<string>();

                try
                {
                    if (LnkHelper.IsNetworkRoot(path))
                    {
                        directories = GetDirectoriesInNetworkLocation(path);
                        static string[] GetDirectoriesInNetworkLocation(string networkLocationRootPath)
                        {
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

                            output = output.Substring(output.LastIndexOf('-') + 2);
                            output = output.Substring(0, output.IndexOf("The command completed successfully.", StringComparison.InvariantCulture));

                            return
                                output
                                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => Path.Combine(networkLocationRootPath,
                                    x.Substring(0, x.IndexOf(' ', StringComparison.InvariantCulture))))
                                    .ToArray();
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

                foreach (string directory in directories)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

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
                    if (LnkHelper.IsNetworkRoot(path))
                    {
                        //UNC root can not have files
                    }
                    else
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

                foreach (string file in files)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

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

        internal void MainPreload()
        {
            menus[0] = Create(GetData(workerMainMenu, Config.Path, 0),
                Path.GetFileName(Config.Path));
            menus[0].AdjustSizeAndLocation(screenHeight,
                screenRight, taskbarHeight);
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

        private static RowData ReadRowData(string fileName,
            bool isResolvedLnk, RowData rowData = null)
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
                static void OpenFolder()
                {
                    Log.ProcessStart("explorer.exe", Config.Path);
                }
            }

            menu.Level = menuData.Level;
            menu.MouseWheel += AdjustMenusSizeAndLocation;
            menu.MouseLeave += waitLeave.Start;
            menu.MouseEnter += waitLeave.Stop;
            menu.KeyPress += keyboardInput.KeyPress;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.SearchTextChanging += keyboardInput.SearchTextChanging;
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
                    menus[0].SetTitleColorActive();
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
                foreach (RowData rowData in data)
                {
                    rowData.SetData(rowData, dataTable);
                }
                dgv.DataSource = dataTable;
            }
            DataGridView dgv = menu.GetDataGridView();
            dgv.CellMouseEnter += waitToOpenMenu.MouseEnter;
            waitToOpenMenu.MouseEnterOk += Dgv_CellMouseEnter;
            void Dgv_CellMouseEnter(DataGridView dgv, int rowIndex)
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
            dgv.CellMouseLeave += waitToOpenMenu.MouseLeave;
            dgv.MouseMove += waitToOpenMenu.MouseMove;
            dgv.MouseDown += Dgv_MouseDown;
            dgv.MouseDoubleClick += Dgv_MouseDoubleClick;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.RowPostPaint += Dgv_RowPostPaint;

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
                rowData.MouseDown(dgv, e);
                waitToOpenMenu.ClickOpensInstantly(dgv, hitTestInfo.RowIndex);
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
                trigger.DoubleClick(e);
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            RefreshSelection((DataGridView)sender);
        }

        private void RefreshSelection(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;

                if (rowData == null)
                {
                    //Case when filtering a previous menu
                }
                else if (!menus[0].IsUsable)
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                    row.Selected = false;
                }
                else if (rowData.IsMenuOpen && rowData.IsSelected)
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
            dgv.Refresh();
        }

        private void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            if (row.Selected)
            {
                RowData rowData = (RowData)row.Cells[2].Value;

                Rectangle rowBounds = new Rectangle(
                    0, e.RowBounds.Top,
                    dgv.Columns[0].Width +
                    dgv.Columns[1].Width,
                    e.RowBounds.Height);

                if (rowData.IsMenuOpen && rowData.IsSelected)
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds,
                        MenuDefines.ColorSelectedItemBorder,
                        ButtonBorderStyle.Solid);
                    row.DefaultCellStyle.SelectionBackColor = MenuDefines.ColorSelectedItem;
                }
                else if (rowData.IsMenuOpen)
                {
                    ControlPaint.DrawBorder(e.Graphics, rowBounds,
                        MenuDefines.ColorOpenFolderBorder,
                        ButtonBorderStyle.Solid);
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
            //Clean up menu status IsMenuOpen for previous one
            Menu menuPrevious = menus[menuToShow.Level - 1];
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

            //Hide old menu
            foreach (Menu menuToClose in menus.Where(
                m => m != null && m.Level > menuPrevious.Level))
            {
                menuToClose.VisibleChanged += MenuVisibleChanged;
                menuToClose.HideWithFade();
                menus[menuToClose.Level] = null;
            }
        }

        internal void FadeHalfOrOutIfNeeded()
        {
            if (menus[0].IsUsable)
            {
                if (!(IsActive()))
                {
                    Point position = Control.MousePosition;
                    if (AsList.Any(m => m.IsMouseOn(position)))
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

        private static bool IsActive()
        {
            return Form.ActiveForm is Menu ||
                Form.ActiveForm is UserInterface.TaskbarForm;
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
            Menu menuPredecessor = menus[0];
            int widthPredecessors = -1; // -1 padding
            bool directionToRight = false;

            menus[0].AdjustSizeAndLocation(screenHeight,
                screenRight, taskbarHeight);

            foreach (Menu menu in AsEnumerable.Where(m => m.Level > 0))
            {
                int newWith = (menu.Width -
                    menu.Padding.Horizontal + menuPredecessor.Width);
                if (directionToRight)
                {
                    if (widthPredecessors - menus[0].Width - menu.Width < 0)
                    {
                        directionToRight = false;
                    }
                    else
                    {
                        widthPredecessors -= newWith;
                    }
                }
                else if (screenWidth < widthPredecessors + menus[0].Width + menu.Width)
                {
                    directionToRight = true;
                    widthPredecessors -= newWith;
                }

                menu.AdjustSizeAndLocation(screenHeight, screenRight, taskbarHeight,
                    menuPredecessor, directionToRight);
                widthPredecessors += menu.Width - menu.Padding.Left;
                menuPredecessor = menu;
            }
        }

        private void Menu_SearchTextChanged(object sender, EventArgs e)
        {
            keyboardInput.SearchTextChanged(sender, e);
            AdjustMenusSizeAndLocation();
        }
    }
}
