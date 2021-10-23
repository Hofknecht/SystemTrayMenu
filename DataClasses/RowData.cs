// <copyright file="RowData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using IWshRuntimeLibrary;
    using SystemTrayMenu.Utilities;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    /// <summary>
    /// Contains data of row.
    /// </summary>
    internal class RowData
    {
        private static readonly Icon White50PercentageIcon = Properties.Resources.White50Percentage;
        private static readonly Icon NotFoundIcon = Properties.Resources.NotFound;
        private static DateTime contextMenuClosed;
        private string workingDirectory;
        private string arguments;
        private string text;
        private Icon icon;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowData"/> class.
        /// </summary>
        internal RowData()
        {
        }

        /// <summary>
        /// Gets or sets fileInfo.
        /// </summary>
        internal FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets SubMenu.
        /// </summary>
        internal Menu SubMenu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsMenuOpen.
        /// </summary>
        internal bool IsMenuOpen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelected.
        /// </summary>
        internal bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ContainsMenu.
        /// </summary>
        internal bool ContainsMenu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsContextMenuOpen.
        /// </summary>
        internal bool IsContextMenuOpen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsResolvedLnk.
        /// </summary>
        internal bool IsResolvedLnk { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is a HiddenEntry.
        /// </summary>
        internal bool HiddenEntry { get; set; }

        /// <summary>
        /// Gets or sets TargetFilePath.
        /// </summary>
        internal string TargetFilePath { get; set; }

        /// <summary>
        /// Gets or sets TargetFilePathOrig.
        /// </summary>
        internal string TargetFilePathOrig { get; set; }

        /// <summary>
        /// Gets or sets RowIndex.
        /// </summary>
        internal int RowIndex { get; set; }

        /// <summary>
        /// Gets or sets MenuLevel.
        /// </summary>
        internal int MenuLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IconLoading.
        /// </summary>
        internal bool IconLoading { get; set; }

        /// <summary>
        /// Gets or sets FilePathIcon.
        /// </summary>
        internal string FilePathIcon { get; set; }

        /// <summary>
        /// Set text of row.
        /// </summary>
        /// <param name="text">text of row.</param>
        internal void SetText(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// SetData.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="dataTable">dataTable.</param>
        internal void SetData(RowData data, DataTable dataTable)
        {
            DataRow row = dataTable.Rows.Add();
            data.RowIndex = dataTable.Rows.IndexOf(row);

            if (HiddenEntry)
            {
                row[0] = IconReader.AddIconOverlay(data.icon, White50PercentageIcon);
            }
            else
            {
                row[0] = data.icon;
            }

            if (!ContainsMenu &&
                Config.IsHideFileExtension())
            {
                row[1] = Path.GetFileNameWithoutExtension(data.text);
            }
            else
            {
                row[1] = data.text;
            }

            row[2] = data;
        }

        /// <summary>
        /// ReadIcon.
        /// </summary>
        /// <param name="isDirectory">isDirectory.</param>
        /// <param name="resolvedLnkPath">resolvedLnkPath.</param>
        /// <returns>isLnkDirectory.</returns>
        internal bool ReadIcon(bool isDirectory, ref string resolvedLnkPath)
        {
            bool isLnkDirectory = false;

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                Log.Info($"TargetFilePath from {resolvedLnkPath} empty");
            }
            else if (isDirectory)
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Closed, false, true, out bool loading);
                IconLoading = loading;
            }
            else
            {
                bool handled = false;
                bool showOverlay = false;
                string fileExtension = Path.GetExtension(TargetFilePath);

                if (fileExtension == ".lnk")
                {
                    handled = SetLnk(
                        ref isLnkDirectory,
                        ref resolvedLnkPath);
                    showOverlay = true;
                }
                else if (fileExtension == ".url")
                {
                    handled = SetUrl();
                    showOverlay = true;
                }
                else if (fileExtension == ".sln")
                {
                    handled = SetSln();
                }
                else if (fileExtension == ".appref-ms")
                {
                    showOverlay = true;
                }

                if (!handled)
                {
                    try
                    {
                        FilePathIcon = TargetFilePathOrig;
                        icon = IconReader.GetFileIconWithCache(FilePathIcon, showOverlay, true, out bool loading);
                        IconLoading = loading;
                    }
                    catch (Exception ex)
                    {
                        Log.Warn($"path:'{TargetFilePathOrig}'", ex);
                    }
                }
            }

            if (icon == null)
            {
                icon = NotFoundIcon;
            }

            return isLnkDirectory;
        }

        /// <summary>
        /// MouseDown.
        /// </summary>
        /// <param name="dgv">dgv.</param>
        /// <param name="e">e.</param>
        /// <param name="toCloseByDoubleClick">toCloseByDoubleClick.</param>
        internal void MouseDown(DataGridView dgv, MouseEventArgs e, out bool toCloseByDoubleClick)
        {
            toCloseByDoubleClick = false;

            if (e != null &&
                e.Button == MouseButtons.Right &&
                FileInfo != null &&
                dgv != null &&
                dgv.Rows.Count > RowIndex &&
                (DateTime.Now - contextMenuClosed).TotalMilliseconds > 200)
            {
                IsContextMenuOpen = true;

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

                IsContextMenuOpen = false;
                contextMenuClosed = DateTime.Now;
            }

            if (Properties.Settings.Default.OpenItemWithOneClick)
            {
                OpenItem(e, ref toCloseByDoubleClick);
            }
        }

        /// <summary>
        /// DoubleClick.
        /// </summary>
        /// <param name="e">e.</param>
        /// <param name="toCloseByDoubleClick">toCloseByDoubleClick.</param>
        internal void DoubleClick(MouseEventArgs e, out bool toCloseByDoubleClick)
        {
            toCloseByDoubleClick = false;
            if (!Properties.Settings.Default.OpenItemWithOneClick)
            {
                OpenItem(e, ref toCloseByDoubleClick);
            }

            if (ContainsMenu && (e == null || e.Button == MouseButtons.Left))
            {
                Log.ProcessStart(TargetFilePath);
                if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                {
                    toCloseByDoubleClick = true;
                }
            }
        }

        /// <summary>
        /// ReadLoadedIcon.
        /// </summary>
        /// <returns>Icon.</returns>
        internal Icon ReadLoadedIcon()
        {
            if (ContainsMenu)
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Closed, false, false, out bool loading);
                IconLoading = loading;
            }
            else
            {
                bool showOverlay = false;
                string fileExtension = Path.GetExtension(TargetFilePath);
                if (fileExtension == ".lnk" || fileExtension == ".url" || fileExtension == ".appref-ms")
                {
                    showOverlay = true;
                }

                string filePath = FilePathIcon;
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = TargetFilePathOrig;
                }

                icon = IconReader.GetFileIconWithCache(filePath, showOverlay, false, out bool loading);
                IconLoading = loading;
            }

            if (!IconLoading && icon == null)
            {
                icon = NotFoundIcon;
            }

            return icon;
        }

        private void OpenItem(MouseEventArgs e, ref bool toCloseByOpenItem)
        {
            if (!ContainsMenu &&
                (e == null || e.Button == MouseButtons.Left))
            {
                Log.ProcessStart(TargetFilePathOrig, arguments, false, workingDirectory, true);
                if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                {
                    toCloseByOpenItem = true;
                }
            }
        }

        private bool SetLnk(
            ref bool isLnkDirectory,
            ref string resolvedLnkPath)
        {
            bool handled = false;
            resolvedLnkPath = FileLnk.GetResolvedFileName(TargetFilePath);

            if (string.IsNullOrEmpty(Path.GetExtension(resolvedLnkPath)))
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Open, true, true, out bool loading);
                IconLoading = loading;
                handled = true;
                isLnkDirectory = true;
            }
            else if (FileLnk.IsNetworkRoot(resolvedLnkPath))
            {
                isLnkDirectory = true;
            }
            else if (string.IsNullOrEmpty(resolvedLnkPath))
            {
                Log.Info($"Resolve *.LNK '{TargetFilePath}' has no icon");
            }
            else
            {
                IWshShell shell = new WshShell();
                IWshShortcut lnk = shell.CreateShortcut(TargetFilePath) as IWshShortcut;
                arguments = lnk.Arguments;
                workingDirectory = lnk.WorkingDirectory;
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
                    if (FileUrl.GetDefaultBrowserPath(out string browserPath))
                    {
                        FilePathIcon = browserPath;
                        icon = IconReader.GetFileIconWithCache(FilePathIcon, true, true, out bool loading);
                        IconLoading = loading;
                        handled = true;
                    }
                }
                else if (System.IO.File.Exists(iconFile))
                {
                    FilePathIcon = iconFile;
                    icon = IconReader.GetFileIconWithCache(FilePathIcon, true, true, out bool loading);
                    IconLoading = loading;
                    handled = true;
                }
                else
                {
                    Log.Info($"Resolve *.URL '{TargetFilePath}' has no icon");
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{TargetFilePath}', iconFile:'{iconFile}'", ex);
            }

            SetText($"{FileInfo.Name[0..^4]}");

            return handled;
        }

        private bool SetSln()
        {
            bool handled = false;
            try
            {
                icon = IconReader.GetExtractAllIconsLastWithCache(TargetFilePathOrig, true, out bool loading);
                IconLoading = loading;
                handled = true;
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{TargetFilePath}'", ex);
            }

            return handled;
        }
    }
}
