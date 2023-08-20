// <copyright file="AppColors.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Windows.Media;

    internal static class AppColors
    {
        /* -- General -- */

        public static SolidColorBrush SelectedItem { get; internal set; } = new(Color.FromRgb(204, 232, 255));

        public static SolidColorBrush DarkModeSelecetedItem { get; internal set; } = new (Color.FromRgb(51, 51, 51));

        public static SolidColorBrush SelectedItemBorder { get; internal set; } = new (Color.FromRgb(153, 209, 255));

        public static SolidColorBrush DarkModeSelectedItemBorder { get; internal set; } = new (Color.FromRgb(20, 29, 75));

        public static SolidColorBrush OpenFolder { get; internal set; } = new (Color.FromRgb(194, 245, 222));

        public static SolidColorBrush DarkModeOpenFolder { get; internal set; } = new (Color.FromRgb(20, 65, 42));

        public static SolidColorBrush OpenFolderBorder { get; internal set; } = new (Color.FromRgb(153, 255, 165));

        public static SolidColorBrush DarkModeOpenFolderBorder { get; internal set; } = new (Color.FromRgb(20, 75, 85));

        public static SolidColorBrush Background { get; internal set; } = new (Color.FromRgb(255, 255, 255));

        public static SolidColorBrush DarkModeBackground { get; internal set; } = new (Color.FromRgb(32, 32, 32));

        public static SolidColorBrush BackgroundBorder { get; internal set; } = new (Color.FromRgb(0, 0, 0));

        public static SolidColorBrush DarkModeBackgroundBorder { get; internal set; } = new (Color.FromRgb(0, 0, 0));

        public static SolidColorBrush SearchField { get; internal set; } = new (Color.FromRgb(255, 255, 255));

        public static SolidColorBrush DarkModeSearchField { get; internal set; } = new (Color.FromRgb(25, 25, 25));

        public static SolidColorBrush Icons { get; internal set; } = new (Color.FromRgb(149, 160, 166));

        public static SolidColorBrush DarkModeIcons { get; internal set; } = new (Color.FromRgb(149, 160, 166));

        /* -- ScrollBar -- */

        public static SolidColorBrush Arrow { get; internal set; } = new(Color.FromRgb(96, 96, 96));

        public static SolidColorBrush ArrowHoverBackground { get; internal set; } = new(Color.FromRgb(218, 218, 218));

        public static SolidColorBrush ArrowHover { get; internal set; } = new(Color.FromRgb(0, 0, 0));

        public static SolidColorBrush ArrowClick { get; internal set; } = new(Color.FromRgb(255, 255, 255));

        public static SolidColorBrush ArrowClickBackground { get; internal set; } = new(Color.FromRgb(96, 96, 96));

        public static SolidColorBrush Slider { get; internal set; } = new(Color.FromRgb(205, 205, 205));

        public static SolidColorBrush SliderHover { get; internal set; } = new(Color.FromRgb(166, 166, 166));

        public static SolidColorBrush SliderDragging { get; internal set; } = new(Color.FromRgb(96, 96, 96));

        public static SolidColorBrush ScrollbarBackground { get; internal set; } = new(Color.FromRgb(240, 240, 240));

        public static SolidColorBrush ArrowDarkMode { get; internal set; } = new(Color.FromRgb(103, 103, 103));

        public static SolidColorBrush ArrowHoverBackgroundDarkMode { get; internal set; } = new(Color.FromRgb(55, 55, 55));

        public static SolidColorBrush ArrowHoverDarkMode { get; internal set; } = new(Color.FromRgb(103, 103, 103));

        public static SolidColorBrush ArrowClickDarkMode { get; internal set; } = new(Color.FromRgb(23, 23, 23));

        public static SolidColorBrush ArrowClickBackgroundDarkMode { get; internal set; } = new(Color.FromRgb(166, 166, 166));

        public static SolidColorBrush SliderDarkMode { get; internal set; } = new(Color.FromRgb(77, 77, 77));

        public static SolidColorBrush SliderHoverDarkMode { get; internal set; } = new(Color.FromRgb(122, 122, 122));

        public static SolidColorBrush SliderDraggingDarkMode { get; internal set; } = new(Color.FromRgb(166, 166, 166));

        public static SolidColorBrush ScrollbarBackgroundDarkMode { get; internal set; } = new(Color.FromRgb(23, 23, 23));
    }
}