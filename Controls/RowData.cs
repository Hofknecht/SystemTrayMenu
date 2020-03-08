using Clearcove.Logging;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SystemTrayMenu.Handler;
using SystemTrayMenu.Helper;
using TAFactory.IconPack;

namespace SystemTrayMenu.Controls
{
    public class RowData : IDisposable
    {
        public FileInfo FileInfo;
        public Icon Icon;
        public bool ContainsMenu;
        public bool IsContextMenuOpen;
        public bool ResolvedFileNotFound;
        public string WorkingDirectory;
        public string Arguments;

        public bool IsResolvedLnk;
        public string TargetFilePath;
        public string Text;


        public Menu SubMenu;
        public int RowIndex;

        public bool IsSelected;
        public bool IsSelectedByKeyboard;

        /// <summary>
        /// Loads the icon
        /// </summary>
        /// <param name="isDirectory">True = directory, false = file</param>
        /// <param name="resolvedLnkPath">Discovered path when functions returns true</param>
        /// <returns>True when linking to a different directory, otherwise false</returns>
        public bool ReadIcon(bool isDirectory, ref string resolvedLnkPath)
        {
            bool isLnkDirectory = false;

            Logger log = new Logger(nameof(RowData));

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                log.Warn($"ReadIcon called but TargetFilePath not set.");
                return isLnkDirectory;
            }

            if (isDirectory)
            {
                Icon = IconReader.GetFolderIcon(TargetFilePath,
                    IconReader.FolderType.Closed, false);
            }
            else
            {
                bool handled = false;
                string fileExtension = Path.GetExtension(TargetFilePath);

                if (fileExtension == ".lnk")
                {
                    handled = SetLnk(log, ref isLnkDirectory,
                        ref resolvedLnkPath);
                }
                else if (fileExtension == ".url")
                {
                    handled = SetUrl(log);
                }
                else if (fileExtension == ".sln")
                {
                    handled = SetSln(log);
                }

                if (!handled)
                {
                    try
                    {
                        Icon = IconReader.GetFileIcon(TargetFilePath, false);

                        // other project -> fails sometimes
                        //icon = IconHelper.ExtractIcon(TargetFilePath, 0);

                        // standard way -> fails sometimes
                        //icon = Icon.ExtractAssociatedIcon(filePath);

                        // API Code Pack  -> fails sometimes
                        //ShellFile shellFile = ShellFile.FromFilePath(filePath);
                        //Bitmap shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
                    }
                    catch (Exception ex)
                    {
                        log.Info($"TargetFilePath:'{TargetFilePath}'");
                        log.Error($"{ex.ToString()}");
                    }
                }
            }

            return isLnkDirectory;
        }

        private bool SetLnk(Logger log, ref bool isLnkDirectory,
            ref string resolvedLnkPath)
        {
            bool handled = false;
            resolvedLnkPath = LnkHelper.ResolveShortcut(TargetFilePath);
            if (LnkHelper.IsDirectory(resolvedLnkPath))
            {
                Icon = IconReader.GetFolderIcon(TargetFilePath,
                    IconReader.FolderType.Open, true);
                handled = true;
                isLnkDirectory = true;
            }
            else if (string.IsNullOrEmpty(resolvedLnkPath))
            {
                ResolvedFileNotFound = true;
                log.Info($"Resolve '{TargetFilePath}' not possible => no icon");
            }
            else
            {
                IWshShell shell = new WshShell();
                var lnk = shell.CreateShortcut(TargetFilePath)
                    as IWshShortcut;
                Arguments = lnk.Arguments;
                WorkingDirectory = lnk.WorkingDirectory;
                string iconLocation = lnk.IconLocation;
                if (iconLocation.Length > 2)
                {
                    iconLocation = iconLocation.Substring(0,
                        iconLocation.Length - 2);
                    if (System.IO.File.Exists(iconLocation))
                    {
                        try
                        {
                            Icon = Icon.ExtractAssociatedIcon(iconLocation);
                            handled = true;
                        }
                        catch (Exception ex)
                        {
                            log.Info($"iconLocation:'{iconLocation}'");
                            log.Error($"{ex.ToString()}");
                        }
                    }
                }

                TargetFilePath = resolvedLnkPath;
            }

            SetText(Path.GetFileNameWithoutExtension(TargetFilePathOrig));

            return handled;
        }

        private bool SetUrl(Logger log)
        {
            bool handled = false;
            string iconFile = string.Empty;
            try
            {
                FileIni file = new FileIni(TargetFilePath);
                iconFile = file.Value("IconFile", string.Empty);
                if (string.IsNullOrEmpty(iconFile))
                {
                    string browserPath = FileUrl.GetDefaultBrowserPath();
                    if (string.IsNullOrEmpty(browserPath))
                    {
                        log.Info($"No default browser found!");
                    }
                    else
                    {
                        Icon = IconReader.GetFileIcon(browserPath, false);
                        handled = true;
                    }
                }
                else if (System.IO.File.Exists(iconFile))
                {
                    Icon = Icon.ExtractAssociatedIcon(iconFile);
                    handled = true;
                }
                else
                {
                    log.Info($"Resolve '{TargetFilePath}' not possible => no icon");
                }
            }
            catch (Exception ex)
            {
                log.Info($"TargetFilePath:'{TargetFilePath}', " +
                    $"iconFile:'{iconFile}'");
                log.Error($"{ex.ToString()}");
            }

            SetText($"{FileInfo.Name.Substring(0, FileInfo.Name.Length - 4)}");

            return handled;
        }

        [DllImport("shell32.dll")]
        static extern int FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult);
        private bool SetSln(Logger log)
        {
            bool handled = false;
            var executable = new StringBuilder(1024);
            try
            {
                FindExecutable(TargetFilePath, string.Empty, executable);
                // icon = IconReader.GetFileIcon(executable, false);
                // e.g. VS 2019 icon, need another icom in imagelist
                List<Icon> extractedIcons = IconHelper.ExtractAllIcons(
                    executable.ToString());
                Icon = extractedIcons.Last();
                handled = true;
            }
            catch (Exception ex)
            {
                log.Info($"TargetFilePath:'{TargetFilePath}', " +
                    $"executable:'{executable.ToString()}'");
                log.Error($"{ex.ToString()}");
            }

            return handled;
        }

        public void SetText(string text)
        {
            //text = $" {text}";
            if (text.Length > MenuDefines.LengthMax)
            {
                text = $"{text.Substring(0, MenuDefines.LengthMax)}...";
            }
            Text = text;
        }


#warning sort this class and check for duplicated

        public event Action<object, EventArgs> OpenMenu;

        public bool IsLoading = false;
        public bool RestartLoading = false;
        public BackgroundWorker Reading = new BackgroundWorker();

        Icon icon = null;
        //FontFamily fontFamily = new FontFamily("Segoe UI");
        //Font font = new Font(new FontFamily("Segoe UI"), 12F,
        //    FontStyle.Regular, GraphicsUnit.Pixel);

        WaitMenuOpen waitMenuOpen = new WaitMenuOpen();
        bool resolvedFileNotFound = false;

        bool disposed = false;
        Logger log = new Logger(nameof(RowData));
        internal string TargetFilePathOrig;
        internal bool HiddenEntry;

        public RowData()
        {
            Reading.WorkerSupportsCancellation = true;

            Initialize();
            void Initialize()
            {
                //Margin = new Padding(0, 0, 0, 0);
                //FlatAppearance.BorderSize = 0;
                //UseVisualStyleBackColor = true;
                //FlatStyle = FlatStyle.Flat;
                //BackColor = MenuDefines.File;
                //FlatAppearance.BorderColor = MenuDefines.File;
                //Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                //AutoSize = true;
                //AutoSizeMode = AutoSizeMode.GrowAndShrink;
                //Font = new Font(fontFamily, 7, FontStyle.Regular, GraphicsUnit.Pixel);
                //ForeColor = Color.Black;
                waitMenuOpen.DoOpen += WaitMenuOpen_DoOpen;

                //MouseLeave += MenuButton_MouseLeave;
                //void MenuButton_MouseLeave(object sender, EventArgs e)
                //{
                //    if (Tag == null &&
                //        !isContextMenuOpen &&
                //        !ContainsMenu)
                //    {
                //        BackColor = MenuDefines.File;
                //    }
                //}

                //MouseEnter += Menubutton_MouseEnter;
                //void Menubutton_MouseEnter(object sender, EventArgs e)
                //{
                //    if (Tag == null &&
                //        !ContainsMenu)
                //    {
                //        BackColor = MenuDefines.FileHover;
                //    }
                //}

                //BackColorChanged += MenuButton_BackColorChanged;
                //void MenuButton_BackColorChanged(object sender, EventArgs e)
                //{
                //    FlatAppearance.BorderColor = BackColor;
                //}


            }
        }

        //DoubleClick += MenuButton_DoubleClick;
        public void DoubleClick()
        {
            if (ContainsMenu)
            {
                try
                {
                    Process.Start("explorer.exe", TargetFilePath);
                }
                catch (Exception ex)
                {
                    log.Info($"TargetFilePath:'{TargetFilePath}', " +
                        $"=>DirectoryNotFound?");
                    log.Error($"{ex.ToString()}");
                    ex = new DirectoryNotFoundException();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //MouseDown += MenuButton_MouseDown;
        public void MouseDown(DataGridView dgv, MouseEventArgs e)
        {
            if (ContainsMenu)
            {
                TriggerMenuOpener(); // Touchscreen
            }

            if (IsLoading)
            {
                waitMenuOpen.Click();
            }

            if (e == null ||
                e.Button == MouseButtons.Left &&
                !ContainsMenu)
            {
                try
                {
                    //https://stackoverflow.com/questions/31627801/
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(TargetFilePath);
                    p.StartInfo.Arguments = Arguments;
                    p.StartInfo.WorkingDirectory = WorkingDirectory;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                }
                catch (Exception ex)
                {
                    log.Info($"TargetFilePath:'{ TargetFilePath}', " +
                        $"=>FileNotFound?");
                    log.Error($"{ex.ToString()}");
                    if (resolvedFileNotFound)
                    {
                        ex = new FileNotFoundException();
                    }
                    MessageBox.Show(ex.Message);
                }
            }

            if (e != null &&
                e.Button == MouseButtons.Right &&
                FileInfo != null &&
                dgv.Rows.Count > RowIndex)
            {
                IsContextMenuOpen = true;

#warning is there any other possiblity to raise selection changed event? dataGridView.ClearSelection(); seems to overwrite selected
                IsSelected = true;
                dgv.Rows[RowIndex].Selected = true;

                try
                {
                    ShellContextMenu ctxMnu = new ShellContextMenu();
                    Point location = dgv.FindForm().Location;
                    Point point = new Point(
                        e.X + location.X + dgv.Location.X,
                        e.Y + location.Y + dgv.Location.Y);
                    if (ContainsMenu)
                    {
                        DirectoryInfo[] dir = new DirectoryInfo[1];
                        dir[0] = new DirectoryInfo(TargetFilePathOrig);
                        ctxMnu.ShowContextMenu(dir, point);
                    }
                    else
                    {
                        FileInfo[] arrFI = new FileInfo[1];
                        arrFI[0] = new FileInfo(TargetFilePathOrig);
                        ctxMnu.ShowContextMenu(arrFI, point);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + TargetFilePath);
                }

                if (!dgv.IsDisposed)
                {
                    IsSelected = false;
                    dgv.Rows[RowIndex].Selected = false;
                }

                IsContextMenuOpen = false;
            }
        }

        public void MenuLoaded()
        {
            waitMenuOpen.MenuLoaded();
        }

        public void StartMenuOpener()
        {
            if (ContainsMenu)
            {
                IsLoading = true;
                waitMenuOpen.Start();
            }
        }

        private void TriggerMenuOpener()
        {
            if (ContainsMenu && IsLoading)
            {
                waitMenuOpen.Start();
            }
        }

        public void StopLoadMenuAndStartWaitToOpenIt()
        {
            if (ContainsMenu)
            {
                waitMenuOpen.Stop();
                //IsLoading = false;
            }
        }

        private void WaitMenuOpen_DoOpen()
        {
            IsLoading = false;
            OpenMenu?.Invoke(this, null);
        }

        public void SetData(RowData data, DataGridView dgv)
        {
            data.RowIndex = dgv.Rows.Add();
            DataGridViewRow row = dgv.Rows[data.RowIndex];

            if (Icon == null)
            {
                Icon = Properties.Resources.SystemTrayMenu;
            }
            DataGridViewImageCell cellIcon =
                (DataGridViewImageCell)row.Cells[0];

            if (HiddenEntry)
            {
                cellIcon.Value = AddIconOverlay(data.Icon, Properties.Resources.WhiteTransparency);
            }
            else
            {
                cellIcon.Value = data.Icon;
            }

            DataGridViewTextBoxCell cellName =
                (DataGridViewTextBoxCell)row.Cells[1];
            cellName.Value = data.Text;

            row.Tag = data;
        }

#warning either not public and as inline method or we want probably to move that code somewhere else
        public Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            var target = new Bitmap(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.DrawIcon(originalIcon, 0, 0);
            graphics.DrawIcon(overlay, 0, 0);
            target.MakeTransparent(target.GetPixel(1, 1));
            return Icon.FromHandle(target.GetHicon());
        }

        public void Dispose()
        {
            if (!disposed)
            {
                icon?.Dispose();
                waitMenuOpen.Dispose();
            }
            disposed = true;
        }
    }
}
