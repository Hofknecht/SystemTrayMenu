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
        private readonly BackgroundWorker workerMainMenu = new();
        private readonly List<BackgroundWorker> workersSubMenu = new();

        private readonly DgvMouseRow dgvMouseRow = new();
        private readonly WaitToLoadMenu waitToOpenMenu = new();
        private readonly KeyboardInput keyboardInput;
        private readonly Timer timerShowProcessStartedAsLoadingIcon = new();
        private readonly Timer timerStillActiveCheck = new();
        private readonly WaitLeave waitLeave = new(Properties.Settings.Default.TimeUntilCloses);
        private DateTime deactivatedTime = DateTime.MinValue;
        private DateTime dateTimeLastOpening = DateTime.MinValue;
        private DateTime dateTimeDisplaySettingsChanged = DateTime.MinValue;
        private OpenCloseState openCloseState = OpenCloseState.Default;
        private bool showingMessageBox;
        private TaskbarPosition taskbarPosition = new WindowsTaskbar().Position;
        private bool searchTextChanging;
        private bool waitingForReactivate;
        private int lastMouseDownRowIndex = -1;
        private bool showMenuAfterMainPreload;
        private int dragSwipeScrollingStartRowIndex = -1;
        private bool isDraggingSwipeScrolling;
        private bool isDragSwipeScrolled;

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
                    DataGridView dgvMainMenu = menus[0].GetDataGridView();
                    foreach (DataRow row in ((DataTable)dgvMainMenu.DataSource).Rows)
                    {
                        RowData rowDataToClear = (RowData)row[2];
                        rowDataToClear.IsMenuOpen = false;
                        rowDataToClear.IsSelected = false;
                        rowDataToClear.IsContextMenuOpen = false;
                    }

                    RefreshSelection(dgvMainMenu);

                    if (Properties.Settings.Default.CacheMainMenu &&
                        Properties.Settings.Default.AppearAtMouseLocation)
                    {
                        menus[0].Tag = null;
                    }

                    AsEnumerable.ToList().ForEach(m => { m.ShowWithFade(); });
                    menus[0].ResetSearchText();
                }
                else
                {
                    MenuData menuData = (MenuData)e.Result;
                    switch (menuData.Validity)
                    {
                        case MenuDataValidity.Valid:
                            if (Properties.Settings.Default.CacheMainMenu)
                            {
                                if (IconReader.MainPreload)
                                {
                                    workerMainMenu.DoWork -= LoadMenu;
                                    menus[0] = Create(menuData, Path.GetFileName(Config.Path));
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
                            }
                            else
                            {
                                DisposeMenu(menus[menuData.Level]);
                                menus[0] = Create(menuData, Path.GetFileName(Config.Path));

                                if (IconReader.MainPreload)
                                {
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
                            }

                            break;
                        case MenuDataValidity.Empty:
                            IconReader.MainPreload = false;
                            if (!showingMessageBox)
                            {
                                showingMessageBox = true;
                                MessageBox.Show(Translator.GetText(
                                    "MessageRootFolderEmpty"));
                                OpenFolder();
                                Config.SetFolderByUser();
                                showingMessageBox = false;
                            }

                            break;
                        case MenuDataValidity.NoAccess:
                            IconReader.MainPreload = false;
                            if (!showingMessageBox)
                            {
                                showingMessageBox = true;
                                MessageBox.Show(Translator.GetText(
                                    "MessageRootFolderNoAccess"));
                                OpenFolder();
                                Config.SetFolderByUser();
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
                    (menus[rowData.MenuLevel + 1] == null ||
                    menus[rowData.MenuLevel + 1].Tag as RowData != rowData))
                {
                    CreateAndShowLoadingMenu(rowData);
                    void CreateAndShowLoadingMenu(RowData rowData)
                    {
                        MenuData menuDataLoading = new()
                        {
                            RowDatas = new List<RowData>(),
                            Validity = MenuDataValidity.Valid,
                            Level = rowData.MenuLevel + 1,
                        };

                        Menu menuLoading = Create(menuDataLoading, Path.GetFileName(rowData.TargetFilePathOrig));
                        menuLoading.IsLoadingMenu = true;
                        AdjustMenusSizeAndLocation();
                        menus[rowData.MenuLevel + 1] = menuLoading;
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
                    if (menuLoading != null && menuLoading.IsLoadingMenu)
                    {
                        userSearchText = menuLoading.GetSearchText();
                        menuLoading.HideWithFade();
                        menus[menuLoading.Level] = null;
                    }

                    if (menuData.Validity != MenuDataValidity.AbortedOrUnknown &&
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
                            if (!string.IsNullOrEmpty(userSearchText))
                            {
                                menu.SetSearchText(userSearchText);
                            }
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
            dgvMouseRow.RowMouseLeave += Dgv_RowMouseLeave;

            keyboardInput = new KeyboardInput(menus);
            keyboardInput.RegisterHotKey();
            keyboardInput.HotKeyPressed += () => SwitchOpenClose(false);
            keyboardInput.ClosePressed += MenusFadeOut;
            keyboardInput.RowDeselected += waitToOpenMenu.RowDeselected;
            keyboardInput.EnterPressed += waitToOpenMenu.EnterOpensInstantly;
            keyboardInput.RowSelected += waitToOpenMenu.RowSelected;
            keyboardInput.RowSelected += AdjustScrollbarToDisplayedRow;
            void AdjustScrollbarToDisplayedRow(DataGridView dgv, int index)
            {
                Menu menu = (Menu)dgv.FindForm();
                menu.AdjustScrollbar();
            }

            timerShowProcessStartedAsLoadingIcon.Interval = Properties.Settings.Default.TimeUntilClosesAfterEnterPressed;
            timerStillActiveCheck.Interval = Properties.Settings.Default.TimeUntilClosesAfterEnterPressed + 20;
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
            timerShowProcessStartedAsLoadingIcon.Dispose();
            timerStillActiveCheck.Dispose();
            waitLeave.Dispose();
            IconReader.Dispose();
            DisposeMenu(menus[0]);
            dgvMouseRow.Dispose();
        }

        internal static MenuData GetData(BackgroundWorker worker, string path, int level)
        {
            MenuData menuData = new()
            {
                RowDatas = new List<RowData>(),
                Validity = MenuDataValidity.AbortedOrUnknown,
                Level = level,
            };

            string[] directoriesToAddToMainMenu = Array.Empty<string>();
            string[] filesToAddToMainMenu = Array.Empty<string>();
            if (level == 0)
            {
                AddFoldersToMainMenu(ref directoriesToAddToMainMenu, ref filesToAddToMainMenu);
            }

            if (!worker.CancellationPending)
            {
                string[] directories = Array.Empty<string>();
                bool isSharedDirectory = false;

                try
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        Log.Info($"path is null or empty");
                    }
                    else if (FileLnk.IsNetworkRoot(path))
                    {
                        isSharedDirectory = true;
                        directories = GetDirectoriesInNetworkLocation(path);
                        static string[] GetDirectoriesInNetworkLocation(string networkLocationRootPath)
                        {
                            List<string> directories = new();
                            Process cmd = new();
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
                                            line[..indexOfFirstSpace]);

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
                        directories = directories.Concat(directoriesToAddToMainMenu).ToArray();
                    }

                    Array.Sort(directories, new WindowsExplorerSort());
                }
                catch (UnauthorizedAccessException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
                catch (Exception ex)
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
                    if (!isSharedDirectory &&
                        FolderOptions.IsHidden(directory, ref hiddenEntry))
                    {
                        continue;
                    }

                    RowData rowData = ReadRowData(directory, false, true);
                    rowData.HiddenEntry = hiddenEntry;
                    string resolvedLnkPath = string.Empty;
                    rowData.ReadIcon(true, ref resolvedLnkPath, level);
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
                        files = files.Concat(filesToAddToMainMenu).ToArray();
                    }

                    Array.Sort(files, new WindowsExplorerSort());
                }
                catch (UnauthorizedAccessException ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
                catch (Exception ex)
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

                    RowData rowData = ReadRowData(file, false, false);
                    rowData.HiddenEntry = hiddenEntry;
                    if (Properties.Settings.Default.ShowOnlyAsSearchResult)
                    {
                        rowData.ShowOnlyWhenSearch = filesToAddToMainMenu.Contains(fileWithIllegalCharacters);
                    }

                    string resolvedLnkPath = string.Empty;
                    if (rowData.ReadIcon(false, ref resolvedLnkPath, level))
                    {
                        rowData = ReadRowData(resolvedLnkPath, true, true, rowData);
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

        internal void SwitchOpenCloseByTaskbarItem()
        {
            SwitchOpenClose(true);
            timerStillActiveCheck.Start();
        }

        internal bool IsOpenCloseStateOpening()
        {
            return openCloseState == OpenCloseState.Opening || (DateTime.Now - dateTimeDisplaySettingsChanged).TotalMilliseconds < 500;
        }

        internal bool IsShortlyAfterOpening()
        {
            dateTimeDisplaySettingsChanged = DateTime.Now;
            return (DateTime.Now - dateTimeLastOpening).TotalMilliseconds < 2000;
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
            dateTimeLastOpening = DateTime.Now;
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
                    dgv.MouseLeave -= Dgv_MouseLeave;
                    dgv.MouseMove -= waitToOpenMenu.MouseMove;
                    dgv.MouseMove -= Dgv_MouseMove;
                    dgv.MouseDown -= Dgv_MouseDown;
                    dgv.MouseUp -= Dgv_MouseUp;
                    dgv.MouseClick -= Dgv_MouseClick;
                    dgv.MouseDoubleClick -= Dgv_MouseDoubleClick;
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

            if (!Properties.Settings.Default.CacheMainMenu)
            {
                DisposeMenu(menus[0]);
            }
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

        private static void LoadMenu(object senderDoWork, DoWorkEventArgs eDoWork)
        {
            string path = Config.Path;
            int level = 0;
            RowData rowData = eDoWork.Argument as RowData;
            if (rowData != null)
            {
                path = rowData.TargetFilePath;
                level = rowData.MenuLevel + 1;
            }

            if (Properties.Settings.Default.GenerateShortcutsToDrives)
            {
                GenerateDriveShortcuts.Start();
            }

            MenuData menuData = GetData((BackgroundWorker)senderDoWork, path, level);
            menuData.RowDataParent = rowData;
            eDoWork.Result = menuData;
        }

        private static void AddFoldersToMainMenu(ref string[] directoriesToAddToMainMenu, ref string[] filesToAddToMainMenu)
        {
            string pathAddToMainMenu = string.Empty;
            bool recursive = false;
            try
            {
                foreach (string pathAndRecursivString in Properties.Settings.Default.PathsAddToMainMenu.Split(@"|"))
                {
                    if (string.IsNullOrEmpty(pathAndRecursivString))
                    {
                        continue;
                    }

                    pathAddToMainMenu = pathAndRecursivString.Split("recursiv:")[0].Trim();
                    recursive = pathAndRecursivString.Split("recursiv:")[1].StartsWith("True");
                    bool onlyFiles = pathAndRecursivString.Split("onlyFiles:")[1].StartsWith("True");

                    string[] directoriesToConcat = Array.Empty<string>();
                    string[] filesToAddToConcat = Array.Empty<string>();
                    if (recursive)
                    {
                        GetDirectoriesAndFilesRecursive(ref directoriesToConcat, ref filesToAddToConcat, pathAddToMainMenu);
                    }
                    else
                    {
                        directoriesToConcat = Directory.GetDirectories(pathAddToMainMenu);
                        filesToAddToConcat = Directory.GetFiles(pathAddToMainMenu);
                    }

                    if (!onlyFiles)
                    {
                        directoriesToAddToMainMenu = directoriesToAddToMainMenu.Concat(directoriesToConcat).ToArray();
                    }

                    filesToAddToMainMenu = filesToAddToMainMenu.Concat(filesToAddToConcat).ToArray();
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{pathAddToMainMenu}' recursiv:{recursive}", ex);
            }
        }

        private static void GetDirectoriesAndFilesRecursive(ref string[] directoriesToConcat, ref string[] filesToAddToConcat, string pathAddToMainMenu)
        {
            try
            {
                string[] directories = Directory.GetDirectories(pathAddToMainMenu);

                try
                {
                    filesToAddToConcat = filesToAddToConcat.Concat(Directory.GetFiles(pathAddToMainMenu)).ToArray();
                }
                catch (Exception ex)
                {
                    Log.Warn($"GetDirectoriesAndFilesRecursive path:'{pathAddToMainMenu}'", ex);
                }

                foreach (string directory in directories)
                {
                    GetDirectoriesAndFilesRecursive(ref directoriesToConcat, ref filesToAddToConcat, directory);
                }

                directoriesToConcat = directoriesToConcat.Concat(directories).ToArray();
            }
            catch (Exception ex)
            {
                Log.Warn($"GetDirectoriesAndFilesRecursive path:'{pathAddToMainMenu}'", ex);
            }
        }

        private static RowData ReadRowData(string fileName, bool isResolvedLnk, bool containsMenu, RowData rowData = null)
        {
            if (rowData == null)
            {
                rowData = new RowData();
            }

            rowData.ContainsMenu = containsMenu;
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
                        rowData.SetText(path[directoryNameBegin..]);
                    }
                    else if (!rowData.ContainsMenu && Config.IsHideFileExtension())
                    {
                        rowData.SetText(Path.GetFileNameWithoutExtension(rowData.FileInfo.Name));
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
                Log.Warn($"fileName:'{fileName}'", ex);
            }

            return rowData;
        }

        private static bool IsActive()
        {
            return Form.ActiveForm is Menu ||
                Form.ActiveForm is UserInterface.TaskbarForm;
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

        private Menu Create(MenuData menuData, string title = null)
        {
            Menu menu = new();

            string path = Config.Path;
            if (title == null)
            {
                title = Path.GetFileName(menuData.RowDataParent.TargetFilePath);
                path = menuData.RowDataParent.TargetFilePath;
            }

            if (string.IsNullOrEmpty(title))
            {
                title = Path.GetPathRoot(path);
            }

            menu.SetTitle(title);
            menu.UserClickedOpenFolder += () => OpenFolder(path);
            menu.Level = menuData.Level;
            menu.MouseWheel += AdjustMenusSizeAndLocation;
            menu.MouseLeave += waitLeave.Start;
            menu.MouseEnter += waitLeave.Stop;
            menu.KeyPress += keyboardInput.KeyPress;
            menu.CmdKeyProcessed += keyboardInput.CmdKeyProcessed;
            menu.SearchTextChanging += Menu_SearchTextChanging;
            menu.SearchTextChanged += Menu_SearchTextChanged;
            menu.UserDragsMenu += Menu_UserDragsMenu;
            void Menu_UserDragsMenu()
            {
                if (menus[1] != null)
                {
                    HideOldMenu(menus[1]);
                }
            }

            menu.Deactivate += Deactivate;
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

            menu.VisibleChanged += MenuVisibleChanged;
            AddItemsToMenu(menuData.RowDatas, menu, out int foldersCount, out int filesCount);
            static void AddItemsToMenu(List<RowData> data, Menu menu, out int foldersCount, out int filesCount)
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
                    if (!rowData.ShowOnlyWhenSearch)
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
                    if (rowData.ShowOnlyWhenSearch)
                    {
                        row[columnSortIndex] = 99;
                    }
                    else
                    {
                        row[columnSortIndex] = 0;
                    }
                }
            }

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
            void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
                // WARN Dgv_DataError occured System.ObjectDisposedException: Cannot access a disposed object. Object name: 'Icon'
                // => Rare times occured (e.g. when focused an close other application => closed and activated at same time)
                Log.Warn("Dgv_DataError occured", e.Exception);
            }

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
                    DataGridView dgv = menu.GetDataGridView();
                    ((DataTable)dgv.DataSource).DefaultView.RowFilter = "[SortIndex] LIKE '%0%'";
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

                    if (!Properties.Settings.Default.CacheMainMenu)
                    {
                        MainPreload();
                    }
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
                    DoScroll(dgv, delta * 2);
                    dragSwipeScrollingStartRowIndex += delta;
                }
            }
        }

        private void DoScroll(DataGridView dgv, int delta)
        {
            if (delta != 0)
            {
                if (delta < 0 && dgv.FirstDisplayedScrollingRowIndex == 0)
                {
                    delta = 0;
                }

                int newFirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex + delta;
                if (newFirstDisplayedScrollingRowIndex > -1 && newFirstDisplayedScrollingRowIndex < dgv.RowCount)
                {
                    isDragSwipeScrolled = true;
                    dgv.FirstDisplayedScrollingRowIndex = newFirstDisplayedScrollingRowIndex;
                    Menu menu = (Menu)dgv.FindForm();
                    menu.AdjustScrollbar();
                }
            }
        }

        private void Dgv_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hitTestInfo;
            hitTestInfo = dgv.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1 &&
                hitTestInfo.RowIndex < dgv.Rows.Count)
            {
                RowData rowData = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                rowData.MouseDown(dgv, e);
            }

            if (e.Button == MouseButtons.Left)
            {
                lastMouseDownRowIndex = hitTestInfo.RowIndex;
            }

            Menu menu = (Menu)((DataGridView)sender).FindForm();
            if (menu.ScrollbarVisible)
            {
                isDraggingSwipeScrolling = true;
                dragSwipeScrollingStartRowIndex = GetRowUnderCursor(dgv, e.Location);
            }
        }

        private int GetRowUnderCursor(DataGridView dgv, Point location)
        {
            DataGridView.HitTestInfo myHitTest = dgv.HitTest(location.X, location.Y);
            return myHitTest.RowIndex;
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
                string[] files = new string[] { rowData.TargetFilePathOrig };

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
                RowData trigger = (RowData)dgv.Rows[hitTestInfo.RowIndex].Cells[2].Value;
                trigger.DoubleClick(e, out bool toCloseByDoubleClick);
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
                        row.Cells[0].Value = rowData.ReadLoadedIcon();
                        waitingForReactivate = false;
                    }

                    timerShowProcessStartedAsLoadingIcon.Stop();
                    timerShowProcessStartedAsLoadingIcon.Start();
                    timerStillActiveCheck.Stop();
                    timerStillActiveCheck.Start();
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

        private void Menu_SearchTextChanging()
        {
            searchTextChanging = true;
            keyboardInput.SearchTextChanging();
        }

        private void Menu_SearchTextChanged(object sender, EventArgs e)
        {
            Menu menu = (Menu)sender;
            keyboardInput.SearchTextChanged(menu);
            AdjustMenusSizeAndLocation();
            searchTextChanging = false;

            // if any open menu close
            if (menu.Level + 1 < menus.Length)
            {
                Menu menuToClose = menus[menu.Level + 1];
                if (menuToClose != null)
                {
                    HideOldMenu(menuToClose);
                }
            }
        }
    }
}
