// <copyright file="RowData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    internal class RowData : INotifyPropertyChanged
    {
        private Brush? backgroundBrush;
        private Brush? borderBrush;
        private ImageSource? columnIcon;
        private string? columnText;
        private bool isClicked;
        private bool isSelected;
        private Menu? subMenu;

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
                ShowOverlay = Settings.Default.ShowLinkOverlay;
                ColumnText = System.IO.Path.GetFileNameWithoutExtension(Path);
                if (Settings.Default.ResolveLinksToFolders)
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
                    ColumnText = FileInfo.FullName[nameBegin..];
                }
                else if (FileExtension.Equals(".url", StringComparison.InvariantCultureIgnoreCase) ||
                    FileExtension.Equals(".appref-ms", StringComparison.InvariantCultureIgnoreCase))
                {
                    ShowOverlay = Settings.Default.ShowLinkOverlay;
                    ColumnText = System.IO.Path.GetFileNameWithoutExtension(FileInfo.Name);
                }
                else if (!isFolder && Config.IsHideFileExtension())
                {
                    ColumnText = System.IO.Path.GetFileNameWithoutExtension(FileInfo.Name);
                }
                else
                {
                    ColumnText = FileInfo.Name;
                }
            }

            IsPointingToFolder |= isFolder;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Brush? BackgroundBrush
        {
            get => backgroundBrush;
            private set
            {
                if (value != backgroundBrush)
                {
                    backgroundBrush = value;
                    CallPropertyChanged();
                }
            }
        }

        public Brush? BorderBrush
        {
            get => borderBrush;
            private set
            {
                if (value != borderBrush)
                {
                    borderBrush = value;
                    CallPropertyChanged();
                }
            }
        }

        public ImageSource? ColumnIcon
        {
            get => columnIcon;
            set
            {
                if (value != columnIcon)
                {
                    columnIcon = value;
                    CallPropertyChanged();
                }
            }
        }

        [AllowNull]
        public string ColumnText
        {
            get => columnText ?? "?";
            set
            {
                if (value != columnText)
                {
                    columnText = value;
                    CallPropertyChanged();
                }
            }
        }

        internal int SortIndex { get; set; }

        internal bool IsPendingOpenItem { get; set; }

        internal bool IsClicked
        {
            get => isClicked;
            set
            {
                if (value != isClicked)
                {
                    isClicked = value;
                    UpdateColors();
                }
            }
        }

        internal bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    UpdateColors();
                }
            }
        }

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

        internal int Level { get; }

        internal string FileExtension { get; }

        internal bool ShowOverlay { get; }

        internal Menu? Owner { get; set; }

        internal Menu? SubMenu
        {
            get => subMenu;
            set
            {
                if (value != subMenu)
                {
                    subMenu = value;
                    UpdateColors();
                }
            }
        }

        internal bool HiddenEntry { get; set; }

        internal int RowIndex { get; set; }

        internal bool IconLoading { get; private set; }

        public override string ToString() => nameof(RowData) + ": " + ColumnText + ", Owner: " + (Owner?.ToString() ?? "null");

        /// <summary>
        /// Triggers an PropertyChanged event of INotifyPropertyChanged.
        /// </summary>
        /// <param name="propertyName">Name of the changing property.</param>
        public void CallPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void LoadIcon(bool isMainMenu)
        {
            if (!IconReader.GetIconAsync(IsPointingToFolder, Path, ResolvedPath, ShowOverlay, isMainMenu, UpdateFinalIcon, isMainMenu))
            {
                IconLoading = true;
                ColumnIcon = IconReader.LoadingImage; // TODO: Maybe add rotation animation like for the loading Menu icon? (See: pictureBoxLoading, LoadingRotation)
            }
        }

        internal void OpenItem(int clickCount)
        {
            bool doCloseAfterOpen = false;

            if (!IsPointingToFolder)
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Settings.Default.OpenItemWithOneClick) ||
                (clickCount == 2 && !Settings.Default.OpenItemWithOneClick))
                {
                    string? workingDirectory = System.IO.Path.GetDirectoryName(ResolvedPath);
                    Log.ProcessStart(Path, string.Empty, false, workingDirectory, true, ResolvedPath);
                    if (!Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }

                    Owner?.RiseItemExecuted(this);
                }
            }
            else
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Settings.Default.OpenDirectoryWithOneClick) ||
                (clickCount == 2 && !Settings.Default.OpenDirectoryWithOneClick))
                {
                    Log.ProcessStart(Path);
                    if (!Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }
                }
            }

            if (Owner != null)
            {
                if (clickCount == 1)
                {
                    Owner.RiseItemOpened(this);
                }

                if (doCloseAfterOpen)
                {
                    Owner.HideAllMenus();
                }
            }
        }

        internal void OpenShellContextMenu(Point? mousePosition)
        {
            Point position = default;

            if (mousePosition != null)
            {
                position = mousePosition.Value;
            }
            else
            {
                if (Owner != null)
                {
                    // Snap context menu left aligned to the ListViewItem with a small padding, but keep it vertically centered
                    Rect rectChild = Owner.GetDataGridViewChildRect(this);
                    position = Owner.GetRelativeChildPositionTo(Owner.GetDataGridView());
                    position.Offset(Owner.Left + rectChild.Left + 10D, Owner.Top + rectChild.Top + (rectChild.Height / 2D));
                }
            }

            if (IsPointingToFolder)
            {
                ShellContextMenu.OpenShellContextMenu(new DirectoryInfo(Path), position);
            }
            else
            {
                ShellContextMenu.OpenShellContextMenu(FileInfo, position);
            }
        }

        internal void OpenSubMenu()
        {
            Menu? openSubMenu = Owner?.SubMenu;

            // only re-open when the menu is not already open
            if (SubMenu != null && SubMenu == openSubMenu)
            {
                // Close second level sub menus when already opened
                openSubMenu.SelectedItem = null;
                if (openSubMenu.SubMenu != null)
                {
                    openSubMenu.SubMenu.HideWithFade(true);
                    openSubMenu.RefreshSelection();
                }
            }
            else
            {
                // In case another menu exists, close it
                if (openSubMenu != null)
                {
                    // Give the opening window focus
                    // if closing window lose focus, no window would have focus any more
                    Owner?.Activate();
                    Owner?.FocusTextBox();
                    openSubMenu.HideWithFade(true);
                    Owner?.RefreshSelection();
                }

                if (IsPointingToFolder)
                {
                    Owner?.RiseStartLoadSubMenu(this);
                }
            }
        }

        internal void UpdateColors()
        {
            if (IsClicked)
            {
                BorderBrush = MenuDefines.ColorIcons;
                BackgroundBrush = MenuDefines.ColorSelectedItem;
            }
            else if (SubMenu != null)
            {
                BorderBrush = MenuDefines.ColorOpenFolderBorder;
                BackgroundBrush = MenuDefines.ColorOpenFolder;
            }
            else if (IsSelected)
            {
                BorderBrush = MenuDefines.ColorSelectedItemBorder;
                BackgroundBrush = MenuDefines.ColorSelectedItem;
            }
            else
            {
                BorderBrush = null;
                BackgroundBrush = null;
            }
        }

        private void UpdateFinalIcon(BitmapSource icon)
        {
            if (HiddenEntry)
            {
                icon = ImagingHelper.ApplyOpactiy(icon, 0.5d);
                icon.Freeze(); // Make it accessible for any thread
            }

            IconLoading = false;
            ColumnIcon = icon;
        }
    }
}
