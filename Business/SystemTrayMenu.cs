using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using SystemTrayMenu.DataClasses;
using SystemTrayMenu.Handler;
using SystemTrayMenu.Helper;
using SystemTrayMenu.Helper.Taskbar;
using SystemTrayMenu.UserInterface;
using SystemTrayMenu.Utilities;
using Menu = SystemTrayMenu.UserInterface.Menu;

namespace SystemTrayMenu
{
    internal class SystemTrayMenu : IDisposable
    {
        private enum OpenCloseState { Default, Opening, Closing };

        private OpenCloseState openCloseState = OpenCloseState.Default;
        private readonly MessageFilter messageFilter = new MessageFilter();
        private readonly MenuNotifyIcon menuNotifyIcon = null;
        private readonly Menu[] menus = new Menu[MenuDefines.MenusMax];
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private readonly Screen screen = Screen.PrimaryScreen;
        private readonly WaitFastLeave fastLeave = new WaitFastLeave();
        private readonly KeyboardInput keyboardInput;
        private DataGridView dgvFromLastMouseEvent = null;
        private DataGridViewCellEventArgs cellEventArgsFromLastMouseEvent = null;
        private int clicksInQueue = 0;

        public SystemTrayMenu()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += AppRestart.ByDisplaySettings;
            menus[0] = new Menu(Menu.MenuType.DisposedFake);

            keyboardInput = new KeyboardInput(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += SwitchOpenClose;
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowSelected += KeyboardInputRowSelected;
            void KeyboardInputRowSelected(DataGridView dgv, int rowIndex)
            {
                keyboardInput.InUse = true;
                FadeInIfNeeded();
                CheckMenuOpenerStart(dgv, rowIndex);
            }
            keyboardInput.RowDeselected += CheckMenuOpenerStop;
            keyboardInput.Cleared += FadeHalfOrOutIfNeeded;

            menuNotifyIcon = new MenuNotifyIcon();
            menuNotifyIcon.Exit += Application.Exit;
            menuNotifyIcon.Restart += AppRestart.ByMenuNotifyIcon;
            menuNotifyIcon.HandleClick += SwitchOpenClose;
            void SwitchOpenClose()
            {
                if (string.IsNullOrEmpty(Config.Path))
                {
                    //Case when Folder Dialog open
                }
                else if (openCloseState == OpenCloseState.Opening ||
                    menus[0].Visible && openCloseState == OpenCloseState.Default)
                {
                    openCloseState = OpenCloseState.Closing;
                    MenusFadeOut();
                    if (worker.IsBusy)
                    {
                        worker.CancelAsync();
                    }
                    if (!Menus().Any(m => m.Visible))
                    {
                        openCloseState = OpenCloseState.Default;
                    }
                }
                else if (worker.IsBusy)
                {
                    if (clicksInQueue < MenuDefines.MaxClicksInQueue)
                    {
                        clicksInQueue++;
                        while (worker.IsBusy)
                        {
                            Application.DoEvents();
                        }
                        clicksInQueue--;
                        SwitchOpenClose();
                    }
                    else
                    {
                        Log.Info("User is clicking too often => throw event away");
                    }
                }
                else
                {
                    openCloseState = OpenCloseState.Opening;
                    menuNotifyIcon.LoadingStart();
                    worker.RunWorkerAsync();
                }
            }

            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            void Worker_DoWork(object senderDoWork,
                DoWorkEventArgs eDoWork)
            {
                int level = 0;
                BackgroundWorker worker = (BackgroundWorker)senderDoWork;
                eDoWork.Result = ReadMenu(worker, Config.Path, level);
            }

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            void Worker_RunWorkerCompleted(object sender,
                RunWorkerCompletedEventArgs e)
            {
                keyboardInput.ResetSelectedByKey();
                menuNotifyIcon.LoadingStop();
                MenuData menuData = (MenuData)e.Result;
                if (menuData.Validity == MenuDataValidity.Valid)
                {
                    DisposeMenu(menus[0]);
                    menus[0] = CreateMenu(menuData, Path.GetFileName(Config.Path));
                    menus[0].AdjustLocationAndSize(screen);
                    ActivateMenu();
                    menus[0].AdjustLocationAndSize(screen);
                    messageFilter.StartListening();
                }

                openCloseState = OpenCloseState.Default;
            }

            void ActivateMenu()
            {
                Menus().ToList().ForEach(m => { m.FadeIn(); m.FadeHalf(); });
                menus[0].SetTitleColorActive();
                menus[0].Activate();
                DllImports.NativeMethods.ForceForegroundWindow(menus[0].Handle);
            }

            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menuNotifyIcon.ChangeFolder += ChangeFolder;
            void ChangeFolder()
            {
                if (Config.SetFolderByUser())
                {
                    AppRestart.ByConfigChange();
                }
            }

            messageFilter.MouseMove += FadeInIfNeeded;
            messageFilter.MouseMove += MessageFilter_MouseMove;
            void MessageFilter_MouseMove()
            {
                if (keyboardInput.InUse)
                {
                    CheckMenuOpenerStop(keyboardInput.iMenuKey,
                        keyboardInput.iRowKey);
                    keyboardInput.ClearIsSelectedByKey();

                    keyboardInput.InUse = false;
                    if (dgvFromLastMouseEvent != null)
                    {
                        Dgv_MouseEnter(dgvFromLastMouseEvent,
                            cellEventArgsFromLastMouseEvent);
                    }
                }
            }
            messageFilter.ScrollBarMouseMove += FadeInIfNeeded;

            messageFilter.MouseLeave += fastLeave.Start;
            fastLeave.Leave += FadeHalfOrOutIfNeeded;
        }

        private void FadeInIfNeeded()
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

        private void FadeHalfOrOutIfNeeded()
        {
            Point mousePosition = Control.MousePosition;
            bool isMouseOnAnyMenu =
                !Menus().Any(m => m.IsMouseOn(mousePosition));
            bool isAnyMenuActive = IsAnyMenuActive();

            if (menus[0].Visible &&
                isMouseOnAnyMenu)
            {
                if (isAnyMenuActive &&
                    !(openCloseState == OpenCloseState.Closing))
                {
                    if (!keyboardInput.InUse)
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

        public void Dispose()
        {
            worker.Dispose();
            keyboardInput.Dispose();
            menuNotifyIcon.Dispose();
            fastLeave.Dispose();
            DisposeMenu(menus[0]);
        }

        private void DisposeMenu(Menu menuToDispose)
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
            }
        }

        private void DisposeWhenHidden(object sender, EventArgs e)
        {
            Menu menuToDispose = (Menu)sender;
            if (!menuToDispose.Visible)
            {
                DisposeMenu(menuToDispose);
            }
            if (!Menus().Any(m => m.Visible))
            {
                openCloseState = OpenCloseState.Default;
            }
        }

        private void AdjustSubMenusLocationAndSize()
        {
            int heightMax = screen.Bounds.Height -
                new Taskbar().Size.Height;
            Menu menuPredecessor = menus[0];
            int widthPredecessors = -1; // -1 padding
            bool directionToRight = false;

            foreach (Menu menu in Menus().Where(m => m.Level > 0))
            {
                int newWith = (menu.Width -
                    menu.Padding.Horizontal + menuPredecessor.Width);
                if (directionToRight)
                {
                    if (widthPredecessors - menu.Width <=
                        -menu.Padding.Horizontal)
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

                menu.AdjustLocationAndSize(heightMax, menuPredecessor);
                widthPredecessors += menu.Width - menu.Padding.Left;
                menuPredecessor = menu;
            }
        }

        private void OpenSubMenu(object sender, EventArgs e)
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

            DisposeMenu(menus[menuTriggered.Level]);
            menus[menuTriggered.Level] = menuTriggered;
            AdjustSubMenusLocationAndSize();
            menus[menuTriggered.Level].FadeIn();
            AdjustSubMenusLocationAndSize();
            IsAnyMenuActive();
        }

        private bool IsAnyMenuActive()
        {
            bool isAnyMenuActive = Form.ActiveForm is Menu;
            if (!isAnyMenuActive)
            {
                menus[0].SetTitleColorDeactive();
            }
            else
            {
                menus[0].SetTitleColorActive();
            }

            return isAnyMenuActive;
        }

        private static MenuData ReadMenu(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new MenuData
            {
                RowDatas = new List<RowData>(),
                Validity = MenuDataValidity.Invalid,
                Level = level
            };
            if (!worker.CancellationPending)
            {
                string[] directories = Array.Empty<string>();

                try
                {
                    directories = Directory.GetDirectories(path);
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

                    RowData menuButtonData = ReadMenuButtonData(directory, false);
                    menuButtonData.ContainsMenu = true;
                    menuButtonData.HiddenEntry = hiddenEntry;
                    string resolvedLnkPath = string.Empty;
                    menuButtonData.ReadIcon(true, ref resolvedLnkPath);
                    menuData.RowDatas.Add(menuButtonData);
                }
            }

            if (!worker.CancellationPending)
            {
                string[] files = Array.Empty<string>();

                try
                {
                    files = Directory.GetFiles(path);
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

                    RowData menuButtonData = ReadMenuButtonData(file, false);
                    string resolvedLnkPath = string.Empty;
                    if (menuButtonData.ReadIcon(false, ref resolvedLnkPath))
                    {
                        menuButtonData = ReadMenuButtonData(resolvedLnkPath, true, menuButtonData);
                        menuButtonData.ContainsMenu = true;
                        menuButtonData.HiddenEntry = hiddenEntry;
                    }

                    menuData.RowDatas.Add(menuButtonData);
                }
            }

            if (!worker.CancellationPending)
            {
                if (menuData.Validity == MenuDataValidity.Invalid)
                {
                    menuData.Validity = MenuDataValidity.Valid;
                }
            }

            return menuData;
        }

        private static RowData ReadMenuButtonData(string fileName,
            bool isResolvedLnk, RowData menuButtonData = null)
        {
            if (menuButtonData == null)
            {
                menuButtonData = new RowData();
            }
            menuButtonData.IsResolvedLnk = isResolvedLnk;

            try
            {
                menuButtonData.FileInfo = new FileInfo(fileName);
                menuButtonData.TargetFilePath = menuButtonData.FileInfo.FullName;
                if (!isResolvedLnk)
                {
                    menuButtonData.SetText(menuButtonData.FileInfo.Name);
                    menuButtonData.TargetFilePathOrig = menuButtonData.FileInfo.FullName;
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
            dgvFromLastMouseEvent = dgv;
            cellEventArgsFromLastMouseEvent = e;

            if (!keyboardInput.InUse)
            {
                keyboardInput.Select(dgv, e.RowIndex);
                CheckMenuOpenerStart(dgv, e.RowIndex);
            }
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

            if (!keyboardInput.InUse)
            {
                Menu menu = (Menu)dgv.FindForm();
                CheckMenuOpenerStop(menu.Level, e.RowIndex, dgv);
            }

            dgvFromLastMouseEvent = null;
            cellEventArgsFromLastMouseEvent = null;
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
                        MenuDefines.ColorSelectedItem;
                    row.Selected = true;
                }
                else if (rowData.IsSelected)
                {
                    row.DefaultCellStyle.SelectionBackColor =
                        MenuDefines.ColorOpenFolder;
                    row.Selected = true;
                }
                else
                {
                    rowData.IsSelected = false;
                    row.Selected = false;
                }
            }
        }

        private IEnumerable<Menu> Menus()
        {
            return menus.Where(m => m != null && !m.IsDisposed);
        }

        private void MenusFadeOut()
        {
            messageFilter.StopListening();

            Menus().ToList().ForEach(menu =>
            {
                if (menu.Level > 0)
                {
                    menus[menu.Level] = null;
                }
                menu.FadeOut();
            });
        }

        private Menu CreateMenu(MenuData menuData, string title = null)
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
                void OpenFolder()
                {
                    Log.ProcessStart("explorer.exe", Config.Path);
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
            menu.KeyPress += keyboardInput.KeyPress;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.Activated += Activated;
            void Activated(object sender, EventArgs e)
            {
                menus[0].SetTitleColorActive();
            }
            menu.Deactivated += fastLeave.Start;
            menu.VisibleChanged += DisposeWhenHidden;
            AddItemsToMenu(menuData.RowDatas, menu);
            return menu;
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
                    if (menuData.Validity != MenuDataValidity.Invalid)
                    {
                        menu = CreateMenu(menuData);
                        if (menuData.RowDatas.Count > 0)
                        {
                            menu.SetTypeSub();
                        }
                        else if (menuData.Validity == MenuDataValidity.NoAccess)
                        {
                            menu.SetTypeNoAccess();
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
}