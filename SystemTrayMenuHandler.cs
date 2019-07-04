using Clearcove.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SystemTrayMenu.Controls;
using SystemTrayMenu.Helper;

namespace SystemTrayMenu
{
    #region Enable debug log by putting this code into each function
    //MethodBase m = MethodBase.GetCurrentMethod();
    //log.Debug($"Executing {m.ReflectedType.Name}, {m.Name}");
    #endregion
    class SystemTrayMenuHandler : IDisposable
    {
        Logger log = new Logger(nameof(SystemTrayMenuHandler));

        KeyboardHook hook = new KeyboardHook();
        Timer timerKeySearch = new Timer();
        int iRowKey = -1;
        int iMenuKey = 0;
        string keyInput = string.Empty;

        MenuNotifyIcon menuNotifyIcon = new MenuNotifyIcon();
        WaitFastLeave fastLeave = new WaitFastLeave();
        Menu[] menus = new Menu[MenuDefines.MenusMax];
        bool isMainMenuOpen = false;

        BackgroundWorker worker = new BackgroundWorker();
        bool restartLoading = false;
        Screen screen = null;

        public SystemTrayMenuHandler(ref bool cancelAppRun)
        {
            log.Info("Application Start " +
                Assembly.GetExecutingAssembly().
                GetName().Version.ToString() +
                $" ScalingFactor={Program.ScalingFactor}");

            if (!string.IsNullOrEmpty(Properties.Settings.Default.HotKey))
            {
                var cvt = new KeysConverter();
                var key = (Keys)cvt.ConvertFrom(
                    Properties.Settings.Default.HotKey);
                try
                {
                    hook.RegisterHotKey(
                        KeyboardHookModifierKeys.Control |
                        KeyboardHookModifierKeys.Alt,
                        key);
                    hook.KeyPressed += hook_KeyPressed;
                }
                catch (Exception ex)
                {
                    log.Info($"key:'{key.ToString()}'");
                    log.Error($"{ex.ToString()}");
                    Properties.Settings.Default.HotKey = string.Empty;
                    Properties.Settings.Default.Save();
                    MessageBox.Show(ex.Message);
                    ApplicationRestart();
                }
            }
            void hook_KeyPressed(object sender, KeyPressedEventArgs e)
            {
                SwitchOpenClose();
            }

            timerKeySearch.Interval = MenuDefines.KeySearchInterval;
            timerKeySearch.Tick += TimerKeySearch_Tick;
            menus[0] = new Menu();
            MessageFilter messageFilter = new MessageFilter();
            Application.AddMessageFilter(messageFilter);
            menuNotifyIcon.Exit += Application.Exit;

            menuNotifyIcon.HandleClick += SwitchOpenClose;
            void SwitchOpenClose()
            {
                if (Config.Path == string.Empty)
                {
                    //Case when Folder Dialog open
                }
                else if (isMainMenuOpen && menus[0].Visible)
                {
                    isMainMenuOpen = false;
                    MenusFadeOut();
                    if (worker.IsBusy)
                    {
                        worker.CancelAsync();
                    }
                }
                else if (worker.IsBusy)
                {
                    restartLoading = true;
                    worker.CancelAsync();
                }
                else
                {
                    isMainMenuOpen = true;
                    if (menus[0].Visible)
                    {
                        ActivateMenu();
                    }
                    else
                    {
                        screen = ScreenMouse.GetScreen();
                        bool IsNotifyIconInTaskbar()
                        {
                            bool isNotifyIconInTaskbar = false;
                            int height = screen.Bounds.Height -
                                new Taskbar().Size.Height;
                            if (Cursor.Position.Y >= height)
                            {
                                isNotifyIconInTaskbar = true;
                            }
                            return isNotifyIconInTaskbar;
                        }
                        if (!IsNotifyIconInTaskbar())
                        {
                            //DragDropHintForm hintForm = new DragDropHintForm(
                            //    Program.Translate("HintDragDropTitle"),
                            //    Program.Translate("HintDragDropText"),
                            //    Program.Translate("buttonOk"));
                            //hintForm.Show();
                        }

                        menuNotifyIcon.LoadingStart();
                        worker.RunWorkerAsync();
                    }
                }
            }

            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            void Worker_DoWork(object senderDoWork,
                DoWorkEventArgs eDoWork)
            {
                int level = 0;
                BackgroundWorker worker = (BackgroundWorker)senderDoWork;
                restartLoading = false;
                eDoWork.Result = ReadMenu(worker, Config.Path, level);
            }

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            void Worker_RunWorkerCompleted(object sender,
                RunWorkerCompletedEventArgs e)
            {
                if (restartLoading)
                {
                    worker.RunWorkerAsync();
                }
                else
                {
                    ResetSelectedByKey();
                    menuNotifyIcon.LoadingStop();
                    MenuData menuData = (MenuData)e.Result;
                    if (menuData.Valid)
                    {
                        menus[0] = CreateMenu(menuData, Path.GetFileName(Config.Path));
                        menus[0].AdjustLocationAndSize(screen);
                        ActivateMenu();
                        menus[0].AdjustLocationAndSize(screen);
                    }
                }
            }

            void ActivateMenu()
            {
                Menus().ToList().ForEach(menu =>
                {
                    menu.FadeIn();
                    menu.FadeHalf();
                });
                menus[0].SetTitleColorActive();
                menus[0].Activate();
                WindowToTop.ForceForegroundWindow(menus[0].Handle);
            }

            menuNotifyIcon.ChangeFolder += ChangeFolder;
            void ChangeFolder()
            {
                if (Config.SetFolderByUser())
                {
                    ApplicationRestart();
                }
            }

            menuNotifyIcon.OpenLog += OpenLog;
            void OpenLog()
            {
                Process.Start(Program.GetLogFilePath());
            }

            menuNotifyIcon.Restart += ApplicationRestart;
            void ApplicationRestart()
            {
                Dispose();
                Process.Start(Assembly.GetExecutingAssembly().
                    ManifestModule.FullyQualifiedName);
            }

            messageFilter.MouseMove += FadeInIfNeeded;
            messageFilter.ScrollBarMouseMove += FadeInIfNeeded;

            messageFilter.MouseLeave += fastLeave.Start;
            fastLeave.Leave += FadeHalfOrOutIfNeeded;

            if (!Config.LoadOrSetByUser())
            {
                cancelAppRun = true;
            }
        }
        void FadeInIfNeeded()
        {
            if (menus[0].Visible &&
                !menus[0].IsFadingIn &&
                !menus[0].IsFadingOut)
            {
                if (Menus().Any(m => m.Opacity < 1))
                {
                    Menus().ToList().ForEach(menu => menu.FadeIn());
                }
            }
        }

        void FadeHalfOrOutIfNeeded()
        {
            Point mousePosition = Control.MousePosition;
            bool isMouseOnAnyMenu =
                !Menus().Any(m => m.IsMouseOn(mousePosition));
            bool isAnyMenuActive = IsAnyMenuActive();

            if (isMouseOnAnyMenu)
            {
                if (isAnyMenuActive && isMainMenuOpen)
                {
                    if (!IsAnyMenuSelectedByKey())
                    {
                        Menus().ToList().ForEach(menu => menu.FadeHalf());
                    }
                }
                else
                {
                    MenusFadeOut();
                }
            }
        }

        private void ResetSelectedByKey()
        {
            iRowKey = -1;
            iMenuKey = 0;
        }

        public void Dispose()
        {
            hook.Dispose();
            menuNotifyIcon.Dispose();
            fastLeave.Dispose();
            DisposeMenu(menus[0]);
        }

        void DisposeMenu(Menu menuToDispose)
        {
            if (menuToDispose != null)
            {
                DataGridView dgv = menuToDispose.GetDataGridView();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    RowData rowData = (RowData)row.Tag;
                    rowData.Dispose();
                    DisposeMenu(rowData.SubMenu);
                }
                dgv.ClearSelection();
                menuToDispose.Dispose();
                menuToDispose = null;
            }
        }

        void DisposeWhenHidden(object sender, EventArgs e)
        {
            Menu menuToDispose = (Menu)sender;
            if (!menuToDispose.Visible)
            {
                DisposeMenu(menuToDispose);
            }
        }

        void AdjustSubMenusLocationAndSize()
        {
            Screen screen = ScreenMouse.GetScreen();
            int heightMax = screen.Bounds.Height -
                new Taskbar().Size.Height;
            Menu menuPredecessor = menus[0];
            int widthPredecessors = -1; // -1 padding
            bool directionToRight = false;

            foreach (Menu menu in Menus().Skip(1))
            {
                // -1*2 padding
                int newWith = (menu.Width - 2 + menuPredecessor.Width);
                if (directionToRight)
                {
#warning is this still correct?
                    if (widthPredecessors - menu.Width <= -2) // -1*2 padding
                    {
                        directionToRight = false;
                    }
                    else
                    {
                        widthPredecessors -= newWith;
                    }
                }
                else if (screen.Bounds.Width <
                    widthPredecessors + menuPredecessor.Width + menu.Width)
                {
                    directionToRight = true;
                    widthPredecessors -= newWith;
                }

                menu.AdjustLocationAndSize(heightMax,
                    widthPredecessors, menuPredecessor);
                widthPredecessors += menu.Width - 1; // -1 padding
                menuPredecessor = menu;
            }
        }

        void OpenSubMenu(object sender, EventArgs e)
        {
            RowData trigger = (RowData)sender;
            Menu menuTriggered = trigger.SubMenu;
            Menu menuFromTrigger = menus[menuTriggered.Level - 1];

            for (int level = menuTriggered.Level;
                level < MenuDefines.MenusMax; level++)
            {
                if (menus[level] != null)
                {
                    Menu menuToClose = menus[level];
                    RowData oldTrigger = (RowData)menuToClose.Tag;
                    DataGridView dgv = menuFromTrigger.GetDataGridView();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        RowData rowData = (RowData)row.Tag;
                        rowData.IsSelected = false;
                    }
                    trigger.IsSelected = true;
                    dgv.ClearSelection();
                    dgv.Rows[trigger.RowIndex].Selected = true;
                    menuToClose.FadeOut();
                    menuToClose.VisibleChanged += DisposeWhenHidden;
                    menus[level] = null;
                }
            }

            menus[menuTriggered.Level] = menuTriggered;
            AdjustSubMenusLocationAndSize();
            menus[menuTriggered.Level].FadeIn();
            AdjustSubMenusLocationAndSize();
            IsAnyMenuActive();
        }

        void Activated(object sender, EventArgs e)
        {
            Menu triggeredMenu = (Menu)sender;
            menus[0].SetTitleColorActive();
        }

        bool IsAnyMenuActive()
        {
            bool isAnyMenuActive;
            Form activeForm = Form.ActiveForm;
            //isAnyMenuActive = Menus().Any(m => m.IsActive(activeForm));
            isAnyMenuActive = activeForm is Menu;
            if (!isAnyMenuActive)
            {
                menus[0].SetTitleColorDeactive();
                CheckMenuOpenerStop(iMenuKey, iRowKey);
                ClearIsSelectedByKey(iMenuKey, iRowKey);
                ResetSelectedByKey();
            }
            else
            {
                menus[0].SetTitleColorActive();
            }

            return isAnyMenuActive;
        }

        MenuData ReadMenu(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new MenuData();
            menuData.RowDatas = new List<RowData>();
            menuData.Valid = false;
            menuData.Level = level;
            if (!worker.CancellationPending)
            {
                string[] directories = new string[] { };

                try
                {
                    directories = Directory.GetDirectories(path);
                    Array.Sort(directories, new WindowsExplorerSort());
                }
                catch (Exception ex)
                {
                    log.Info($"path:'{path}'");
                    log.Error($"{ex.ToString()}");
                }

                foreach (string directory in directories)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

                    RowData menuButtonData = ReadMenuButtonData(directory, false);
                    menuButtonData.ContainsMenu = true;
                    string resolvedLnkPath = string.Empty;
                    menuButtonData.ReadIcon(true, false, ref resolvedLnkPath);
                    menuData.RowDatas.Add(menuButtonData);
                }
            }

            if (!worker.CancellationPending)
            {
                string[] files = new string[] { };

                try
                {
                    files = Directory.GetFiles(path).
                        Where(p => Path.GetFileName(p) != "desktop.ini").ToArray();
                    Array.Sort(files, new WindowsExplorerSort());
                }
                catch (Exception ex)
                {
                    log.Info($"path:'{path}'");
                    log.Error($"{ex.ToString()}");
                }

                foreach (string file in files)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        break;
                    }

                    RowData menuButtonData = ReadMenuButtonData(file, false);
                    string resolvedLnkPath = string.Empty;
                    if (menuButtonData.ReadIcon(false,
                        false, ref resolvedLnkPath))
                    {
                        menuButtonData = ReadMenuButtonData(resolvedLnkPath, true, file);
                        menuButtonData.ContainsMenu = true;
                        menuButtonData.ReadIcon(true, true, ref resolvedLnkPath);
                    }

                    menuData.RowDatas.Add(menuButtonData);
                }
            }

            if (!worker.CancellationPending)
            {
                menuData.Valid = true;
            }

            return menuData;
        }

        RowData ReadMenuButtonData(string fileName,
            bool isResolvedLnk, string fileUnresolved = null)
        {
            RowData menuButtonData = new RowData();
            menuButtonData.IsResolvedLnk = isResolvedLnk;

            try
            {
                menuButtonData.FileInfo = new FileInfo(fileName);
                menuButtonData.TargetFilePath = menuButtonData.FileInfo.FullName;
                menuButtonData.SetText($"{menuButtonData.FileInfo.Name}");
                if(string.IsNullOrEmpty(fileUnresolved))
                {
                    menuButtonData.TargetFilePathOrig = menuButtonData.TargetFilePath;
                }
                else
                {
                    menuButtonData.TargetFilePathOrig = fileUnresolved;
                }
            }
            catch (Exception ex)
            {
                log.Info($"fileName:'{fileName}'");
                log.Error($"{ex.ToString()}");
            }

            return menuButtonData;
        }

        private void Dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                dgv.Rows.Count > hitTestInfo.RowIndex)
            {
                RowData trigger = (RowData)dgv.Rows[hitTestInfo.RowIndex].Tag;
                trigger.DoubleClick();
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
                RowData trigger = (RowData)dgv.Rows[hitTestInfo.RowIndex].Tag;
                trigger.MouseDown(dgv, e);
            }
        }

        private void Dgv_MouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            CheckMenuOpenerStart(dgv, e.RowIndex);
        }

        private void CheckMenuOpenerStart(DataGridView dgv, int rowIndex)
        {
            if (rowIndex > -1 &&
                dgv.Rows.Count > rowIndex)
            {
                RowData trigger = (RowData)dgv.Rows[rowIndex].Tag;
                trigger.IsSelected = true;
                dgv.Rows[rowIndex].Selected = true;
                Menu menuFromTrigger = (Menu)dgv.FindForm();
                Menu menuTriggered = trigger.SubMenu;
                int level = menuFromTrigger.Level + 1;

                if (trigger.ContainsMenu &&
                    level < MenuDefines.MenusMax &&
                    !menus[0].IsFadingOut &&
                    !menuFromTrigger.IsFadingOut &&
                    (menus[level] == null ||
                    menus[level] != menuTriggered))
                {
                    trigger.StopLoadMenuAndStartWaitToOpenIt();
                    trigger.StartMenuOpener();

                    if (trigger.Reading.IsBusy)
                    {
                        trigger.RestartLoading = true;
                    }
                    else
                    {
                        menuNotifyIcon.LoadingStart();
                        trigger.Reading.RunWorkerAsync(level);
                    }
                }
            }
        }

        private void Dgv_MouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Menu menu = (Menu)dgv.FindForm();
            CheckMenuOpenerStop(menu.Level, e.RowIndex, dgv);
        }

        private void CheckMenuOpenerStop(int menuIndex, int rowIndex, DataGridView dgv = null)
        {
            Menu menu = menus[menuIndex];
            if (menu != null && 
                rowIndex > -1)
            {
                if (dgv == null)
                {
                    dgv = menu.GetDataGridView();
                }
                if (dgv.Rows.Count > rowIndex)
                {
                    RowData trigger = (RowData)dgv.Rows[rowIndex].Tag;
                    if (trigger.Reading.IsBusy)
                    {
                        if (!trigger.IsContextMenuOpen)
                        {
                            trigger.IsSelected = false;
                            dgv.Rows[rowIndex].Selected = false;
                        }
                        trigger.Reading.CancelAsync();
                    }
                    else if (trigger.ContainsMenu && !trigger.IsLoading)
                    {
                        trigger.IsSelected = true;
                        dgv.Rows[rowIndex].Selected = true;
                    }
                    else
                    {
                        if (!trigger.IsContextMenuOpen)
                        {
                            trigger.IsSelected = false;
                            dgv.Rows[rowIndex].Selected = false;
                        }
                    }
                    if (trigger.IsLoading)
                    {
                        trigger.StopLoadMenuAndStartWaitToOpenIt();
                        trigger.IsLoading = false;
                    }
                }
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Tag;
                if (rowData.IsSelectedByKeyboard)
                {
                    row.DefaultCellStyle.SelectionBackColor = 
                        MenuDefines.KeyBoardSelection;
                    row.Selected = true;
                }
                else if (rowData.IsSelected)
                {
                    row.DefaultCellStyle.SelectionBackColor = 
                        MenuDefines.FolderOpen;
                    row.Selected = true;
                }
                else
                {
                    rowData.IsSelected = false;
                    row.Selected = false;
                }
            }
        }

        IEnumerable<Menu> Menus()
        {
            return menus.Where(m => m != null);
        }

        void MenusFadeOut()
        {
            Menus().ToList().ForEach(menu =>
            {
                if (menu.Level > 0)
                {
                    menus[menu.Level] = null;
                }
                menu.FadeOut();
            });
        }

        Menu CreateMenu(MenuData menuData, string title = null)
        {
            Menu menu = new Menu();
            if (title != null)
            {
                if (title == string.Empty)
                {
                    title = Path.GetPathRoot(Config.Path);
                }

                menu.SetTitle(title);
                menu.UserClickedOpenFolder += OpenFolder;
                void OpenFolder()
                {
                    Process.Start("explorer.exe", Config.Path);
                }
            }
            menu.Level = menuData.Level;
            menu.MouseWheel += AdjustSubMenusLocationAndSize;
            DataGridView dgv = menu.GetDataGridView();
            dgv.CellMouseEnter += Dgv_MouseEnter;
            dgv.CellMouseLeave += Dgv_MouseLeave;
            dgv.MouseDoubleClick += Dgv_MouseDoubleClick;
            dgv.MouseDown += Dgv_MouseDown;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            menu.KeyPress += KeyPress;
            menu.CmdKeyProcessed += CmdKeyProcessed;
            menu.Activated += Activated;
            menu.Deactivated += fastLeave.Start;
            menu.VisibleChanged += DisposeWhenHidden;
            AddItemsToMenu(menuData.RowDatas, menu);
            return menu;
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsSeparator(e.KeyChar))
            {
                string letter = e.KeyChar.ToString();

                if (string.IsNullOrEmpty(keyInput))
                {
                    keyInput = letter;
                    Search(keyInput, true);
                }
                else if (keyInput.LastOrDefault().ToString() == letter)
                {
                    keyInput += letter;
                    Search(letter, true);
                    timerKeySearch.Stop();
                }
                else
                {
                    keyInput += letter;
                    Search(keyInput, false);
                    timerKeySearch.Stop();
                }
                timerKeySearch.Start();
                e.Handled = true;
            }
        }

        private void TimerKeySearch_Tick(object sender, EventArgs e)
        {
            timerKeySearch.Stop();
            //Search(keyInput);
            keyInput = string.Empty;
        }

#warning better word than force
        private void Search(string keyInput, bool force)
        {
            SelectByKey(Keys.None, keyInput, force);
        }

        private void CmdKeyProcessed(Keys keys)
        {
            SelectByKey(keys);
        }

        private bool IsAnyMenuSelectedByKey()
        {
            Menu menu = null;
            DataGridView dgv = null;
            string textselected = string.Empty;
            return IsAnyMenuSelectedByKey(ref dgv, ref menu, ref textselected);
        }

        private bool IsAnyMenuSelectedByKey(
            ref DataGridView dgv,
            ref Menu menuFromSelected, 
            ref string textselected)
        {
            Menu menu = menus[iMenuKey];
            bool isStillSelected = false;
            if (menu != null &&
                iRowKey > -1)
            {
                dgv = menu.GetDataGridView();
                if (dgv.Rows.Count > iRowKey)
                {
                    RowData rowData = (RowData)dgv.
                        Rows[iRowKey].Tag;
                    if (rowData.IsSelectedByKeyboard)
                    {
                        isStillSelected = true;
                        menuFromSelected = rowData.SubMenu;
#warning refactor datagridviewrow get
                        textselected = dgv.Rows[iRowKey].
                            Cells[1].Value.ToString();
                    }
                }
            }

            return isStillSelected;
        }

        private void SelectByKey(Keys keys, string keyInput = "",
            bool force = true)
        {
            int iRowBefore = iRowKey;
            int iMenuBefore = iMenuKey;

            Menu menu = menus[iMenuKey];
            DataGridView dgv = null;
            DataGridView dgvBefore = null;
            Menu menuFromSelected = null;
            string textselected = string.Empty;
            bool isStillSelected = IsAnyMenuSelectedByKey(
                ref dgv, ref menuFromSelected, ref textselected);
            if (isStillSelected)
            {
                dgvBefore = dgv;
                if (!force &&
                    textselected.ToLower().StartsWith(keyInput.ToLower()))
                {
#warning rewrite function should not return here
                    return; // is that ok? check twice
                }
            }
            else
            {
                ResetSelectedByKey();
                menu = menus[iMenuKey];
                dgv = menu.GetDataGridView();
            }

            bool toClear = false;
            switch (keys)
            {
                case Keys.Enter:
                    if (iRowKey > -1 &&
                        dgv.Rows.Count > iRowKey)
                    {
                        RowData trigger = (RowData)dgv.Rows[iRowKey].Tag;
                        trigger.MouseDown(dgv, null);
                        //trigger.DoubleClick();
                    }
                    break;
                case Keys.Up:
                    FadeInIfNeeded();
                    if (SelectMatchedReverse(dgv, iRowKey) ||
                        SelectMatchedReverse(dgv, dgv.Rows.Count - 1))
                    {
                        CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                        CheckMenuOpenerStart(dgv, iRowKey);
                        toClear = true;
                    }
                    break;
                case Keys.Down:
                    FadeInIfNeeded();
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                        CheckMenuOpenerStart(dgv, iRowKey);
                        toClear = true;
                    }
                    break;
                case Keys.Left:
                    FadeInIfNeeded();
                    int iMenuKeyNext = iMenuKey + 1;
                    if (isStillSelected)
                    {
                        if (menuFromSelected != null &&
                            menuFromSelected == menus[iMenuKeyNext])
                        {
                            dgv = menuFromSelected.GetDataGridView();
                            if (dgv.Rows.Count > 0)
                            {
                                iMenuKey += 1;
                                iRowKey = -1;
                                if (SelectMatched(dgv, iRowKey) ||
                                    SelectMatched(dgv, 0))
                                {
                                    CheckMenuOpenerStop(iMenuBefore, 
                                        iRowBefore, dgvBefore);
                                    CheckMenuOpenerStart(dgv, iRowKey);
                                    toClear = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        iRowKey = -1;
                        iMenuKey = menus.Where(m => m != null).Count() - 1;
                        if (menus[iMenuKey] != null)
                        {
                            dgv = menus[iMenuKey].GetDataGridView();
                            if (SelectMatched(dgv, iRowKey) ||
                                SelectMatched(dgv, 0))
                            {
                                CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                                CheckMenuOpenerStart(dgv, iRowKey);
                                toClear = true;
                            }
                        }
                        else
                        {
                            log.Info("indexMenuByKey = menus.Where(m => m != null).Count()" +
                                "=> menus[iMenuKey] == null");
                        }
                    }
                    break;
                case Keys.Right:
                    if (iMenuKey > 0)
                    {
                        if (menus[iMenuKey - 1] != null)
                        {
                            iMenuKey -= 1;
                            iRowKey = -1;
                            menu = menus[iMenuKey];
                            dgv = menu.GetDataGridView();
                            if (SelectMatched(dgv, dgv.SelectedRows[0].Index) ||
                                SelectMatched(dgv, 0))
                            {
                                CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                                CheckMenuOpenerStart(dgv, iRowKey);
                                toClear = true;
                            }
                        }
                    }
                    else
                    {
                        CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                        iMenuKey = 0;
                        iRowKey = -1;
                        toClear = true;
                        FadeHalfOrOutIfNeeded();
                    }
                    break;
                case Keys.Escape:
                    CheckMenuOpenerStop(iMenuBefore, iRowBefore, dgvBefore);
                    iMenuKey = 0;
                    iRowKey = -1;
                    toClear = true;
                    isMainMenuOpen = false;
                    MenusFadeOut();
                    break;
                default:
                    if (!string.IsNullOrEmpty(keyInput) &&
                        (SelectMatched(dgv, iRowKey, keyInput) ||
                         SelectMatched(dgv, 0, keyInput)))
                    {
                        FadeInIfNeeded();
                        CheckMenuOpenerStop(iMenuBefore, iRowBefore);
                        CheckMenuOpenerStart(dgv, iRowKey);
                        toClear = true;
                    }
                    break;
            }
            if (isStillSelected && toClear)
            {
                ClearIsSelectedByKey(iMenuBefore, 
                    iRowBefore);
            }
            
        }

        private bool SelectMatched(DataGridView dgv, 
            int indexStart, string keyInput = "")
        {
            bool found = false;
            for (int i = indexStart; i < dgv.Rows.Count; i++)
            {
                if (Select(dgv, i, keyInput))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private bool SelectMatchedReverse(DataGridView dgv, 
            int indexStart, string keyInput = "")
        {
            bool found = false;
            for (int i = indexStart; i > -1; i--)
            {
                if (Select(dgv, i, keyInput))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private bool Select(DataGridView dgv, int i, 
            string keyInput = "")
        {
            bool found = false;
            if (i > -1 &&
                i != iRowKey &&
                dgv.Rows.Count > i)
            {
                DataGridViewRow row = dgv.Rows[i];
                RowData rowData = (RowData)row.Tag;
                string text = row.Cells[1].Value.ToString();
                if (text.ToLower().StartsWith(keyInput.ToLower()))
                {
                    iRowKey = rowData.RowIndex;
                    rowData.IsSelectedByKeyboard = true;
                    row.Selected = false; //event trigger
                    row.Selected = true; //event trigger
                    if (row.Index < dgv.FirstDisplayedScrollingRowIndex)
                    {
                        dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                    else if(row.Index >= 
                        dgv.FirstDisplayedScrollingRowIndex + 
                        dgv.DisplayedRowCount(false))
                    {
                        dgv.FirstDisplayedScrollingRowIndex = row.Index -
                        dgv.DisplayedRowCount(false) + 1;
                    }
                    
                    found = true;
                }
            }
            return found;
        }

        private void ClearIsSelectedByKey(int menuIndex, int rowIndex)
        {
            Menu menu = menus[menuIndex];
            if (menu != null && rowIndex > -1)
            {
                DataGridView dgv = menu.GetDataGridView();
                if (dgv.Rows.Count > rowIndex)
                {
                    DataGridViewRow row = dgv.Rows[rowIndex];
                    RowData rowData = (RowData)row.Tag;
                    rowData.IsSelectedByKeyboard = false;
                    row.Selected = false; //event trigger
                }
            }
        }

        private void AddItemsToMenu(List<RowData> data, Menu menu)
        {
            foreach (RowData rowData in data)
            {
                CreateMenuRow(rowData, menu);
            }
        }

        private void CreateMenuRow(RowData rowData, Menu menu)
        {
            rowData.SetData(rowData, menu.GetDataGridView());
            rowData.OpenMenu += OpenSubMenu;
            rowData.Reading.WorkerSupportsCancellation = true;
            rowData.Reading.DoWork += ReadMenu_DoWork;
            void ReadMenu_DoWork(object senderDoWork,
                DoWorkEventArgs eDoWork)
            {
                int level = (int)eDoWork.Argument;
                BackgroundWorker worker = (BackgroundWorker)senderDoWork;
                rowData.RestartLoading = false;
                eDoWork.Result = ReadMenu(worker, rowData.TargetFilePath, level);
            }

            rowData.Reading.RunWorkerCompleted += ReadMenu_RunWorkerCompleted;
            void ReadMenu_RunWorkerCompleted(object senderCompleted,
                RunWorkerCompletedEventArgs e)
            {
                MenuData menuData = (MenuData)e.Result;
                if (rowData.RestartLoading)
                {
                    rowData.Reading.RunWorkerAsync(menuData.Level);
                }
                else
                {
                    menuNotifyIcon.LoadingStop();
                    menuNotifyIcon.LoadWait();
                    if (menuData.Valid)
                    {
                        menu = CreateMenu(menuData);
                        if (menuData.RowDatas.Count > 0)
                        {
                            menu.SetTypeSub();
                        }
                        else
                        {
                            menu.SetTypeEmpty();
                        }
                        menu.Tag = rowData;
                        rowData.SubMenu = menu;
                        rowData.MenuLoaded();
                    }
                    menuNotifyIcon.LoadStop();
                }
            }
        }
    }

    class WindowsExplorerSort : IComparer<string>
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        static extern int StrCmpLogicalW(String x, String y);

        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}