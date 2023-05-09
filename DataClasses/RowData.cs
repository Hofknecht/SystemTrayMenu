// <copyright file="RowData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System;
    using System.Drawing;
    using System.IO;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.Utilities.IconReader;
    using Menu = SystemTrayMenu.UserInterface.Menu;
    using Point = System.Windows.Point;

    internal class RowData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowData"/> class.
        /// (Related replace "\x00" see #171.)
        /// </summary>
        /// <param name="isFolder">Flag if file or folder.</param>
        /// <param name="isAdditionalItem">Flag if additional item, from other folder than root folder.</param>
        /// <param name="level">The number of the menu level.</param>
        /// <param name="path">Path to item.</param>
        internal RowData(bool isFolder, bool isAdditionalItem, int level, string path)
        {
            IsFolder = isFolder;
            IsAdditionalItem = isAdditionalItem;
            Level = level;
            FileInfo = new FileInfo(path.Replace("\x00", string.Empty));
            Path = isFolder ? $@"{FileInfo.FullName}\" : FileInfo.FullName;
            FileExtension = System.IO.Path.GetExtension(Path) ?? string.Empty;

            if (FileExtension.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
            {
                ResolvedPath = FileLnk.GetResolvedFileName(Path, out bool isLinkToFolder);
                ShowOverlay = Properties.Settings.Default.ShowLinkOverlay;
                Text = System.IO.Path.GetFileNameWithoutExtension(Path);
                if (Properties.Settings.Default.ResolveLinksToFolders)
                {
                    IsPointingToFolder |= isLinkToFolder || FileLnk.IsNetworkRoot(ResolvedPath);
                }
            }
            else
            {
                ResolvedPath = Path;
                if (string.IsNullOrEmpty(FileInfo.Name))
                {
                    int nameBegin = FileInfo.FullName.LastIndexOf(@"\", StringComparison.InvariantCulture) + 1;
                    Text = FileInfo.FullName[nameBegin..];
                }
                else if (FileExtension.Equals(".url", StringComparison.InvariantCultureIgnoreCase) ||
                    FileExtension.Equals(".appref-ms", StringComparison.InvariantCultureIgnoreCase))
                {
                    ShowOverlay = Properties.Settings.Default.ShowLinkOverlay;
                    Text = System.IO.Path.GetFileNameWithoutExtension(FileInfo.Name);
                }
                else if (!isFolder && Config.IsHideFileExtension())
                {
                    Text = System.IO.Path.GetFileNameWithoutExtension(FileInfo.Name);
                }
                else
                {
                    Text = FileInfo.Name;
                }
            }

            IsPointingToFolder |= isFolder;
        }

        internal Icon? Icon { get; private set; }

        internal FileInfo FileInfo { get; }

        /// <summary>
        /// Gets the original/local path.
        /// </summary>
        internal string Path { get; }

        /// <summary>
        /// Gets the resulting target path after following shortcuts or CLSIDs.
        /// </summary>
        internal string ResolvedPath { get; }

        /// <summary>
        /// Gets a value indicating whether
        /// the item is actually a folder and not a file.
        /// E.g. a shortcut (.lnk) would return false.
        /// </summary>
        internal bool IsFolder { get; }

        /// <summary>
        /// Gets a value indicating whether
        /// the item is actually a folder or at least points to one.
        /// E.g. a shortcut (.lnk) could return either false or true.
        /// </summary>
        internal bool IsPointingToFolder { get; }

        internal bool IsAdditionalItem { get; }

        internal int Level { get; set; }

        internal string FileExtension { get; }

        internal bool ShowOverlay { get; }

        internal string? Text { get; }

        internal Menu? Owner { get; set; }

        internal Menu? SubMenu { get; set; }

        internal bool HiddenEntry { get; set; }

        internal int RowIndex { get; set; }

        internal bool IconLoading { get; set; }

        internal void ReadIcon(bool updateIconInBackground)
        {
            bool loading;
            if (IsPointingToFolder)
            {
                Icon = GetFolderIconWithCache(Path, ShowOverlay, updateIconInBackground, Level == 0, out loading);
            }
            else
            {
                Icon = GetFileIconWithCache(Path, ResolvedPath, ShowOverlay, updateIconInBackground, Level == 0, out loading);
            }

            IconLoading = loading;
            if (!IconLoading)
            {
                if (Icon == null)
                {
                    Icon = Properties.Resources.NotFound;
                }
                else if (HiddenEntry)
                {
                    Icon = AddIconOverlay(Icon, Properties.Resources.White50Percentage);
                }
            }
        }

        internal void OpenItem(out bool doCloseAfterOpen, int clickCount = -1)
        {
            doCloseAfterOpen = false;

            if (!IsPointingToFolder)
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Properties.Settings.Default.OpenItemWithOneClick) ||
                (clickCount == 2 && !Properties.Settings.Default.OpenItemWithOneClick))
                {
                    string? workingDirectory = System.IO.Path.GetDirectoryName(ResolvedPath);
                    Log.ProcessStart(Path, string.Empty, false, workingDirectory, true, ResolvedPath);
                    if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }
                }
            }
            else
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Properties.Settings.Default.OpenDirectoryWithOneClick) ||
                (clickCount == 2 && !Properties.Settings.Default.OpenDirectoryWithOneClick))
                {
                    Log.ProcessStart(Path);
                    if (!Properties.Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }
                }
            }
        }
    }
}
