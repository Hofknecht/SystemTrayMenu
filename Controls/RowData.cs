using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
        public event Action<object, EventArgs> OpenMenu;
        public BackgroundWorker Reading = new BackgroundWorker();
        public FileInfo FileInfo;
        public Menu SubMenu;
        public Icon Icon;
        public bool IsSelected;
        public bool IsSelectedByKeyboard;
        public bool ContainsMenu;
        public bool IsContextMenuOpen;
        public bool ResolvedFileNotFound;
        public bool IsResolvedLnk;
        public bool IsLoading = false;
        public bool RestartLoading = false;
        public bool HiddenEntry;
        public string WorkingDirectory;
        public string Arguments;
        public string TargetFilePath;
        public string TargetFilePathOrig;
        public string Text;
        public int RowIndex;
        private readonly WaitMenuOpen waitMenuOpen = new WaitMenuOpen();
        private readonly Icon icon = null;
        private bool isDisposed = false;

        public RowData()
        {
            Reading.WorkerSupportsCancellation = true;
            waitMenuOpen.DoOpen += WaitMenuOpen_DoOpen;
        }

        public void SetText(string text)
        {
            if (text != null && text.Length > MenuDefines.LengthMax)
            {
                text = $"{text.Substring(0, MenuDefines.LengthMax)}...";
            }
            Text = text;
        }

        private bool SetLnk(ref bool isLnkDirectory,
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
                Log.Info($"Resolve *.LNK '{TargetFilePath}' has no icon");
#warning [Feature] Resolve network root #48, start here
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
                            Log.Error($"iconLocation:'{iconLocation}'", ex);
                        }
                    }
                }

                TargetFilePath = resolvedLnkPath;
            }

            SetText(Path.GetFileNameWithoutExtension(TargetFilePathOrig));

            return handled;
        }

        private bool SetUrl()
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
                        Log.Info($"Resolve *.URL '{TargetFilePath}'" +
                            $"No default browser found!");
                    }
                    else
                    {
                        Icon = IconReader.GetFileIconWithCache(browserPath, false);
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
                    Log.Info($"Resolve *.URL '{TargetFilePath}' has no icon");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"TargetFilePath:'{TargetFilePath}', " +
                    $"iconFile:'{iconFile}'", ex);
            }

            SetText($"{FileInfo.Name.Substring(0, FileInfo.Name.Length - 4)}");

            return handled;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult);
        private bool SetSln()
        {
            bool handled = false;
            var executable = new StringBuilder(1024);
            try
            {
                _ = FindExecutable(TargetFilePath, string.Empty, executable);
                // icon = IconReader.GetFileIcon(executable, false);
                // e.g. VS 2019 icon, need another icom in imagelist
                List<Icon> extractedIcons = IconHelper.ExtractAllIcons(
                    executable.ToString());
                Icon = extractedIcons.Last();
                handled = true;
            }
            catch (Exception ex)
            {
                Log.Error($"TargetFilePath:'{TargetFilePath}', " +
                    $"executable:'{executable.ToString()}'", ex);
            }

            return handled;
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
                cellIcon.Value = IconReader.AddIconOverlay(data.Icon,
                    Properties.Resources.WhiteTransparency);
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

        public bool ReadIcon(bool isDirectory, ref string resolvedLnkPath)
        {
            bool isLnkDirectory = false;

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                Log.Info($"TargetFilePath from {resolvedLnkPath} empty");
            }
            else if (isDirectory)
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
                    handled = SetLnk(ref isLnkDirectory,
                        ref resolvedLnkPath);
                }
                else if (fileExtension == ".url")
                {
                    handled = SetUrl();
                }
                else if (fileExtension == ".sln")
                {
                    handled = SetSln();
                }

                if (!handled)
                {
                    try
                    {
                        Icon = IconReader.GetFileIconWithCache(TargetFilePath, false);

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
                        Log.Error($"TargetFilePath:'{TargetFilePath}'", ex);
                    }
                }
            }

            return isLnkDirectory;
        }

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
                    Log.Error($"TargetFilePath:'{ TargetFilePath}', " +
                        $"=>FileNotFound?", ex);
                    MessageBox.Show(ex.Message);
                }
            }

            if (e != null &&
                e.Button == MouseButtons.Right &&
                FileInfo != null &&
                dgv.Rows.Count > RowIndex)
            {
                IsContextMenuOpen = true;
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
                    Log.Error($"TargetFilePath:'{TargetFilePath}', " +
                        $"=>DirectoryNotFound?", ex);
                    ex = new DirectoryNotFoundException();
                    MessageBox.Show(ex.Message);
                }
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                icon?.Dispose();
                waitMenuOpen.Dispose();
            }
            isDisposed = true;
        }
    }
}
