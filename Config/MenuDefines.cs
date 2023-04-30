// <copyright file="MenuDefines.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Windows.Media;

    internal static class MenuDefines
    {
        internal const int MenusMax = 50;
        internal const int LengthMax = 37;

        public static SolidColorBrush ColorForeground =>
            Config.IsDarkMode() ? Brushes.White : Brushes.Black;

        public static SolidColorBrush ColorSelectedItem =>
            Config.IsDarkMode() ? AppColors.DarkModeSelecetedItem : AppColors.SelectedItem;

        public static SolidColorBrush ColorSelectedItemBorder =>
            Config.IsDarkMode() ? AppColors.DarkModeSelectedItemBorder : AppColors.SelectedItemBorder;

        public static SolidColorBrush ColorOpenFolder =>
            Config.IsDarkMode() ? AppColors.DarkModeOpenFolder : AppColors.OpenFolder;

        public static SolidColorBrush ColorOpenFolderBorder =>
            Config.IsDarkMode() ? AppColors.DarkModeOpenFolderBorder : AppColors.OpenFolderBorder;

        public static SolidColorBrush ColorIcons =>
            Config.IsDarkMode() ? AppColors.DarkModeIcons : AppColors.Icons;

        public static SolidColorBrush ColorBackground =>
            Config.IsDarkMode() ? AppColors.DarkModeBackground : AppColors.Background;

        public static SolidColorBrush ColorBackgroundBorder =>
            Config.IsDarkMode() ? AppColors.DarkModeBackgroundBorder : AppColors.BackgroundBorder;

        public static SolidColorBrush ColorSearchField =>
            Config.IsDarkMode() ? AppColors.DarkModeSearchField : AppColors.SearchField;
    }
}
