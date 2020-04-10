using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using SystemTrayMenu.Handler;
using SystemTrayMenu.Utilities;
using TAFactory.IconPack;
using Menu = SystemTrayMenu.UserInterface.Menu;

namespace SystemTrayMenu.DataClasses
{
    internal class RowData : IDisposable
    {
        internal event EventHandler<RowData> OpenMenu;
        internal BackgroundWorker Reading = new BackgroundWorker();
        internal FileInfo FileInfo;
        internal Menu SubMenu;
        internal bool IsSelected;
        internal bool IsSelectedByKeyboard;
        internal bool ContainsMenu;
        internal bool IsContextMenuOpen;
        internal bool IsResolvedLnk;
        internal bool IsLoading = false;
        internal bool RestartLoading = false;
        internal bool HiddenEntry;
        internal string TargetFilePath;
        internal string TargetFilePathOrig;
        internal int RowIndex;
        private string WorkingDirectory;
        private string Arguments;
        private string Text;
        private readonly WaitMenuOpen waitMenuOpen = new WaitMenuOpen();
        private Icon Icon = null;
        private bool diposeIcon = true;
        private bool isDisposed = false;

        internal RowData()
        {
            Reading.WorkerSupportsCancellation = true;
            waitMenuOpen.DoOpen += WaitMenuOpen_DoOpen;
        }

        internal void SetText(string text)
        {
            if (text.Length > MenuDefines.LengthMax)
            {
                text = $"{text.Substring(0, MenuDefines.LengthMax)}...";
            }
            Text = text;
        }

        internal void SetData(RowData data, DataGridView dgv)
        {
            data.RowIndex = dgv.Rows.Add();
            DataGridViewRow row = dgv.Rows[data.RowIndex];

            if (Icon == null)
            {
                Icon = Properties.Resources.WhiteTransparency;
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

        internal bool ReadIcon(bool isDirectory, ref string resolvedLnkPath)
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
                        diposeIcon = false;

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
                        if (ex is SecurityException ||
                            ex is ArgumentException ||
                            ex is UnauthorizedAccessException ||
                            ex is PathTooLongException ||
                            ex is NotSupportedException)
                        {
                            Log.Warn($"path:'{TargetFilePath}'", ex);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            return isLnkDirectory;
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
                Log.Info($"Resolve *.LNK '{TargetFilePath}' has no icon");
#warning [Feature] Resolve network root #48, start here
            }
            else
            {
                IWshShell shell = new WshShell();
                IWshShortcut lnk = shell.CreateShortcut(TargetFilePath)
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
                        catch (ArgumentException ex)
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
                        diposeIcon = false;
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
                if (ex is SecurityException ||
                    ex is ArgumentException ||
                    ex is UnauthorizedAccessException ||
                    ex is PathTooLongException ||
                    ex is NotSupportedException)
                {
                    Log.Warn($"path:'{TargetFilePath}', " +
                        $"iconFile:'{iconFile}'", ex);
                }
                else
                {
                    throw;
                }
            }

            SetText($"{FileInfo.Name.Substring(0, FileInfo.Name.Length - 4)}");

            return handled;
        }

        private bool SetSln()
        {
            bool handled = false;
            StringBuilder executable = new StringBuilder(1024);
            try
            {
                DllImports.NativeMethods.Shell32FindExecutable(TargetFilePath, string.Empty, executable);
                // icon = IconReader.GetFileIcon(executable, false);
                // e.g. VS 2019 icon, need another icom in imagelist
                List<Icon> extractedIcons = IconHelper.ExtractAllIcons(
                    executable.ToString());
                Icon = extractedIcons.Last();
                handled = true;
            }
            catch (Exception ex)
            {
                if (ex is SecurityException ||
                    ex is ArgumentException ||
                    ex is UnauthorizedAccessException ||
                    ex is PathTooLongException ||
                    ex is NotSupportedException)
                {
                    Log.Warn($"path:'{TargetFilePath}', " +
                        $"executable:'{executable}'", ex);
                }
                else
                {
                    throw;
                }
            }

            return handled;
        }

        internal void MouseDown(DataGridView dgv, MouseEventArgs e)
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
                    using (Process p = new Process())
                    {
                        p.StartInfo = new ProcessStartInfo(TargetFilePath)
                        {
                            FileName = TargetFilePathOrig,
                            Arguments = Arguments,
                            WorkingDirectory = WorkingDirectory,
                            CreateNoWindow = true
                        };
                        p.Start();
                    };
                }
                catch (Win32Exception ex)
                {
                    Log.Warn($"path:'{TargetFilePath}'", ex);
                    MessageBox.Show(ex.Message);
                }
            }

            if (e != null &&
                e.Button == MouseButtons.Right &&
                FileInfo != null &&
                dgv != null &&
                dgv.Rows.Count > RowIndex)
            {
                IsContextMenuOpen = true;
                IsSelected = true;
                dgv.Rows[RowIndex].Selected = true;

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

                if (!dgv.IsDisposed)
                {
                    IsSelected = false;
                    dgv.Rows[RowIndex].Selected = false;
                }

                IsContextMenuOpen = false;
            }
        }

        internal void DoubleClick()
        {
            if (ContainsMenu)
            {
                Log.ProcessStart("explorer.exe", TargetFilePath);
            }
        }

        internal void MenuLoaded()
        {
            waitMenuOpen.MenuLoaded();
        }

        internal void StartMenuOpener()
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

        internal void StopLoadMenuAndStartWaitToOpenIt()
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
            OpenMenu?.Invoke(this, this);
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
                waitMenuOpen.Dispose();
                Reading.Dispose();
                if (diposeIcon)
                {
                    Icon?.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
