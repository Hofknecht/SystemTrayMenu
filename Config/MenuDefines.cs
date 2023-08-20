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

        /* -- General -- */

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

        /* -- ScrollBar -- */

        public static SolidColorBrush ColorArrow =>
            Config.IsDarkMode() ? AppColors.ArrowDarkMode : AppColors.Arrow;

        public static SolidColorBrush ColorArrowHoverBackground =>
            Config.IsDarkMode() ? AppColors.ArrowHoverBackgroundDarkMode : AppColors.ArrowHoverBackground;

        public static SolidColorBrush ColorArrowHover =>
            Config.IsDarkMode() ? AppColors.ArrowHoverDarkMode : AppColors.ArrowHover;

        public static SolidColorBrush ColorArrowClick =>
            Config.IsDarkMode() ? AppColors.ArrowClickDarkMode : AppColors.ArrowClick;

        public static SolidColorBrush ColorArrowClickBackground =>
            Config.IsDarkMode() ? AppColors.ArrowClickBackgroundDarkMode : AppColors.ArrowClickBackground;

        public static SolidColorBrush ColorSlider =>
            Config.IsDarkMode() ? AppColors.SliderDarkMode : AppColors.Slider;

        public static SolidColorBrush ColorSliderHover =>
            Config.IsDarkMode() ? AppColors.SliderHoverDarkMode : AppColors.SliderHover;

        public static SolidColorBrush ColorSliderDragging =>
            Config.IsDarkMode() ? AppColors.SliderDraggingDarkMode : AppColors.SliderDragging;

        public static SolidColorBrush ColorScrollbarBackground =>
            Config.IsDarkMode() ? AppColors.ScrollbarBackgroundDarkMode : AppColors.ScrollbarBackground;
    }
}
