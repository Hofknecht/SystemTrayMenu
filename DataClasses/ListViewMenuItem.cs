// <copyright file="ListViewMenuItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// Type for ListView items.
    /// </summary>
    internal class ListViewMenuItem : INotifyPropertyChanged
    {
        private Brush? backgroundBrush;
        private Brush? borderBrush;
        private ImageSource? columnIcon;
        private bool isSelected;

        internal ListViewMenuItem(ImageSource? columnIcon, string columnText, RowData rowData, int sortIndex)
        {
            this.columnIcon = columnIcon;
            ColumnText = columnText;
            data = rowData;
            SortIndex = sortIndex;
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

        public string ColumnText { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Benennungsstile", Justification = "Temporarily retained for compatibility reasons")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "Temporarily retained for compatibility reasons")]
        internal RowData data { get; set; }

        internal int SortIndex { get; set; }

        internal bool IsPendingOpenItem { get; set; }

        internal bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    CallPropertyChanged();
                }
            }
        }

        public override string ToString() => nameof(ListViewMenuItem) + ": " + ColumnText + ", Owner: " + (data.Owner?.ToString() ?? "null");

        /// <summary>
        /// Triggers an PropertyChanged event of INotifyPropertyChanged.
        /// </summary>
        /// <param name="propertyName">Name of the changing property.</param>
        public void CallPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void OpenItem(int clickCount)
        {
            bool doCloseAfterOpen = false;

            if (!data.IsPointingToFolder)
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Settings.Default.OpenItemWithOneClick) ||
                (clickCount == 2 && !Settings.Default.OpenItemWithOneClick))
                {
                    string? workingDirectory = System.IO.Path.GetDirectoryName(data.ResolvedPath);
                    Log.ProcessStart(data.Path, string.Empty, false, workingDirectory, true, data.ResolvedPath);
                    if (!Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }
                }
            }
            else
            {
                if (clickCount == -1 ||
                (clickCount == 1 && Settings.Default.OpenDirectoryWithOneClick) ||
                (clickCount == 2 && !Settings.Default.OpenDirectoryWithOneClick))
                {
                    Log.ProcessStart(data.Path);
                    if (!Settings.Default.StaysOpenWhenItemClicked)
                    {
                        doCloseAfterOpen = true;
                    }
                }
            }

            if (data.Owner != null)
            {
                if (clickCount == 1)
                {
                    data.Owner.RiseItemOpened(this);
                }

                if (doCloseAfterOpen)
                {
                    data.Owner.HideAllMenus();
                }
            }
        }

        internal void OpenShellContextMenu(Point position)
        {
            if (data.IsPointingToFolder)
            {
                ShellContextMenu.OpenShellContextMenu(new DirectoryInfo(data.Path), position);
            }
            else
            {
                ShellContextMenu.OpenShellContextMenu(data.FileInfo, position);
            }
        }

        internal void OpenSubMenu()
        {
            Menu? owner = data.Owner;

            // TODO: always true? maybe only when cached in WaitToLoadMenu or keyboardInput?
            if (owner?.GetDataGridView().Items.Contains(this) ?? false)
            {
                Menu? openSubMenu = owner.SubMenu;

                // only re-open when the menu is not already open
                if (data.SubMenu != null && data.SubMenu == openSubMenu)
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
                        owner.Activate();
                        owner.FocusTextBox();
                        openSubMenu.HideWithFade(true);
                        owner.RefreshSelection();
                    }

                    if (data.IsPointingToFolder)
                    {
                        owner.RiseStartLoadSubMenu(data);
                    }
                }
            }
        }

        internal void UpdateColors()
        {
            if (data.SubMenu != null)
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
                BorderBrush = Brushes.White;
                BackgroundBrush = Brushes.White;
            }
        }
    }
}
