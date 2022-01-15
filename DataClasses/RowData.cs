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
    using SystemTrayMenu.Utilities;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class RowData
    {
        private static readonly Icon White50PercentageIcon = Properties.Resources.White50Percentage;
        private static readonly Icon NotFoundIcon = Properties.Resources.NotFound;
        private static DateTime contextMenuClosed;
        private string text;
        private Icon icon;

        internal RowData()
        {
        }

        internal FileInfo FileInfo { get; set; }

        internal Menu SubMenu { get; set; }

        internal bool IsMenuOpen { get; set; }

        internal bool IsSelected { get; set; }

        internal bool ContainsMenu { get; set; }

        internal bool IsContextMenuOpen { get; set; }

        internal bool IsResolvedLnk { get; set; }

        internal bool HiddenEntry { get; set; }

        internal bool ShowOnlyWhenSearch { get; set; }

        internal string TargetFilePath { get; set; }

        internal string TargetFilePathOrig { get; set; }

        internal int RowIndex { get; set; }

        internal int MenuLevel { get; set; }

        internal bool IconLoading { get; set; }

        internal string FilePathIcon { get; set; }

        internal bool ProcessStarted { get; set; }

        internal void SetText(string text)
        {
            this.text = text;
        }

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

            row[1] = data.text;
            row[2] = data;
        }

        internal bool ReadIcon(bool isDirectory, ref string resolvedLnkPath, int level)
        {
            bool isLnkDirectory = false;

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                Log.Info($"TargetFilePath from {resolvedLnkPath} empty");
            }
            else if (isDirectory)
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Closed, false, true, level == 0, out bool loading);
                IconLoading = loading;
            }
            else
            {
                bool handled = false;
                bool showOverlay = false;
                string fileExtension = Path.GetExtension(TargetFilePath);

                if (fileExtension.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
                {
                    handled = SetLnk(level, ref isLnkDirectory, ref resolvedLnkPath);
                    showOverlay = true;
                }
                else if (fileExtension.Equals(".url", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetText($"{FileInfo.Name[0..^4]}");
                    showOverlay = true;
                }
                else if (fileExtension.Equals(".sln", StringComparison.InvariantCultureIgnoreCase))
                {
                    handled = SetSln(level);
                }
                else if (fileExtension.Equals(".appref-ms", StringComparison.InvariantCultureIgnoreCase))
                {
                    showOverlay = true;
                }

                if (!handled)
                {
                    try
                    {
                        FilePathIcon = TargetFilePathOrig;
                        icon = IconReader.GetFileIconWithCache(FilePathIcon, showOverlay, true, level == 0, out bool loading);
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

        internal void MouseDown(DataGridView dgv, MouseEventArgs e)
        {
            if (e != null &&
                e.Button == MouseButtons.Right &&
                FileInfo != null &&
                dgv != null &&
                dgv.Rows.Count > RowIndex &&
                (DateTime.Now - contextMenuClosed).TotalMilliseconds > 200)
            {
                IsContextMenuOpen = true;

                ShellContextMenu ctxMnu = new();
                Point location = dgv.FindForm().Location;
                Point point = new(
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
        }

        internal void MouseClick(MouseEventArgs e, out bool toCloseByDoubleClick)
        {
            toCloseByDoubleClick = false;
            if (Properties.Settings.Default.OpenItemWithOneClick)
            {
                OpenItem(e, ref toCloseByDoubleClick);
            }

            if (Properties.Settings.Default.OpenDirectoryWithOneClick &&
                ContainsMenu && (e == null || e.Button == MouseButtons.Left))
            {
                Log.ProcessStart(TargetFilePath);
                if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                {
                    toCloseByDoubleClick = true;
                }
            }
        }

        internal void DoubleClick(MouseEventArgs e, out bool toCloseByDoubleClick)
        {
            toCloseByDoubleClick = false;
            if (!Properties.Settings.Default.OpenItemWithOneClick)
            {
                OpenItem(e, ref toCloseByDoubleClick);
            }

            if (!Properties.Settings.Default.OpenDirectoryWithOneClick &&
                ContainsMenu && (e == null || e.Button == MouseButtons.Left))
            {
                Log.ProcessStart(TargetFilePath);
                if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                {
                    toCloseByDoubleClick = true;
                }
            }
        }

        internal Icon ReadLoadedIcon()
        {
            if (ContainsMenu)
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Closed, false, false, MenuLevel == 0, out bool loading);
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

                icon = IconReader.GetFileIconWithCache(filePath, showOverlay, false, MenuLevel == 0, out bool loading);
                IconLoading = loading;
            }

            if (!IconLoading && icon == null)
            {
                icon = NotFoundIcon;
            }

            if (HiddenEntry)
            {
                icon = IconReader.AddIconOverlay(icon, White50PercentageIcon);
            }

            return icon;
        }

        private void OpenItem(MouseEventArgs e, ref bool toCloseByOpenItem)
        {
            if (!ContainsMenu &&
                (e == null || e.Button == MouseButtons.Left))
            {
                ProcessStarted = true;
                Log.ProcessStart(TargetFilePathOrig, string.Empty, false, string.Empty, true);
                if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                {
                    toCloseByOpenItem = true;
                }
            }
        }

        private bool SetLnk(int level, ref bool isLnkDirectory, ref string resolvedLnkPath)
        {
            bool handled = false;
            resolvedLnkPath = FileLnk.GetResolvedFileName(TargetFilePath, out bool isFolder);

            if (string.IsNullOrEmpty(resolvedLnkPath))
            {
                //Log.Info($"Could not resolve *.LNK '{TargetFilePath}'");
            }
            else if (isFolder)
            {
                icon = IconReader.GetFolderIconWithCache(TargetFilePathOrig, IconReader.FolderType.Open, true, true, level == 0, out bool loading);
                IconLoading = loading;
                handled = true;
                isLnkDirectory = true;
            }
            else if (FileLnk.IsNetworkRoot(resolvedLnkPath))
            {
                isLnkDirectory = true;
            }
            else
            {
                TargetFilePath = resolvedLnkPath;
            }

            SetText(Path.GetFileNameWithoutExtension(TargetFilePathOrig));

            return handled;
        }

        private bool SetSln(int level)
        {
            bool handled = false;
            try
            {
                icon = IconReader.GetExtractAllIconsLastWithCache(TargetFilePathOrig, true, level == 0, out bool loading);
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
