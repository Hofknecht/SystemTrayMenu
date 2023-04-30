// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Win32;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.Utilities.IconReader;
    using Icon = System.Drawing.Icon;

    public static class Config
    {
        private static readonly Icon SystemTrayMenu = new(Properties.Resources.SystemTrayMenu, (int)SystemParameters.SmallIconWidth, (int)SystemParameters.SmallIconHeight);
        private static readonly Icon? IconRootFolder = GetIconSTA(Path, Path, false, IconSize.Small, true);

        private static bool readDarkModeDone;
        private static bool isDarkMode;
        private static bool readHideFileExtdone;
        private static bool isHideFileExtension;

        public static string Path => Settings.Default.PathDirectory;

        public static string SearchPattern => Settings.Default.SearchPattern;

        public static bool ShowDirectoryTitleAtTop => Settings.Default.ShowDirectoryTitleAtTop;

        public static bool ShowSearchBar => Settings.Default.ShowSearchBar;

        public static bool ShowCountOfElementsBelow => Settings.Default.ShowCountOfElementsBelow;

        public static bool ShowFunctionKeyOpenFolder => Settings.Default.ShowFunctionKeyOpenFolder;

        public static bool ShowFunctionKeyPinMenu => Settings.Default.ShowFunctionKeyPinMenu;

        public static bool ShowFunctionKeySettings => Settings.Default.ShowFunctionKeySettings;

        public static bool ShowFunctionKeyRestart => Settings.Default.ShowFunctionKeyRestart;

        public static bool AlwaysOpenByPin { get; internal set; }

        public static void Initialize()
        {
            UpgradeIfNotUpgraded();
            InitializeColors();
            if (string.IsNullOrEmpty(Settings.Default.PathIcoDirectory))
            {
                Settings.Default.PathIcoDirectory = System.IO.Path.Combine(
                    System.IO.Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.ApplicationData), $"SystemTrayMenu"), "ico");
                if (!Directory.Exists(Settings.Default.PathIcoDirectory))
                {
                    Directory.CreateDirectory(Settings.Default.PathIcoDirectory);
                }
            }
        }

        public static Icon GetAppIcon()
        {
            if (Settings.Default.UseIconFromRootFolder && (IconRootFolder != null))
            {
                return IconRootFolder;
            }
            else
            {
                return SystemTrayMenu;
            }
        }

        public static void SetFolderByWindowsContextMenu(string[] args)
        {
            if (args != null && args.Length > 0 && args[0] != "-r")
            {
                string path = args[0];
                Log.Info($"SetFolderByWindowsContextMenu() path: {path}");
                Settings.Default.PathDirectory = path;
                Settings.Default.Save();
            }
        }

        public static void LoadOrSetByUser()
        {
            if (string.IsNullOrEmpty(Path))
            {
                string textFirstStart = Translator.GetText(
                    "Read the FAQ and then choose a root directory for SystemTrayMenu.");
                MessageBox.Show(
                    textFirstStart,
                    "SystemTrayMenu",
                    MessageBoxButton.OK);
                ShowHelpFAQ();
                SetFolderByUser();
            }
        }

        public static void SetFolderByUser(Window? owner = null, bool save = true)
        {
            using FolderDialog dialog = new();
            dialog.InitialFolder = Path;

            if (dialog.ShowDialog(owner))
            {
                Settings.Default.PathDirectory = dialog.Folder;
                if (save)
                {
                    Settings.Default.Save();
                }
            }
        }

        public static void SetFolderIcoByUser(Window owner)
        {
            using FolderDialog dialog = new();
            dialog.InitialFolder = Settings.Default.PathIcoDirectory;

            if (dialog.ShowDialog(owner))
            {
                Settings.Default.PathIcoDirectory = dialog.Folder;
            }
        }

        internal static void ShowHelpFAQ()
        {
            Log.ProcessStart("https://github.com/Hofknecht/SystemTrayMenu#FAQ");
        }

        internal static void ShowSupportSystemTrayMenu()
        {
            Log.ProcessStart("https://github.com/Hofknecht/SystemTrayMenu#donations");
        }

        /// <summary>
        /// Read the OS setting whether dark mode is enabled.
        /// </summary>
        /// <returns>true = Dark mode; false = Light mode.</returns>
        internal static bool IsDarkMode()
        {
            if (!readDarkModeDone)
            {
                // 0 = Dark mode, 1 = Light mode
                if (Settings.Default.IsDarkModeAlwaysOn ||
                    IsRegistryValueThisValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "AppsUseLightTheme",
                    "0"))
                {
                    isDarkMode = true;
                }

                readDarkModeDone = true;
            }

            return isDarkMode;
        }

        internal static void ResetReadDarkModeDone()
        {
            isDarkMode = false;
            readDarkModeDone = false;
        }

        /// <summary>
        /// Read the OS setting whether HideFileExt enabled.
        /// </summary>
        /// <returns>isHideFileExtension.</returns>
        internal static bool IsHideFileExtension()
        {
            if (!readHideFileExtdone)
            {
                // 0 = To show extensions, 1 = To hide extensions
                if (IsRegistryValueThisValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "HideFileExt",
                    "1"))
                {
                    isHideFileExtension = true;
                }

                readHideFileExtdone = true;
            }

            return isHideFileExtension;
        }

        internal static void InitializeColors(bool save = true)
        {
            ColorConverter converter = new();
            ColorAndCode colorAndCode = default;
            bool resetDefaults = false;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSelectedItem;
            colorAndCode.Color = Color.FromRgb(204, 232, 255);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSelectedItem = colorAndCode.HtmlColorCode;
            AppColors.SelectedItem = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSelecetedItem;
            colorAndCode.Color = Color.FromRgb(51, 51, 51);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeSelecetedItem = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSelecetedItem = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSelectedItemBorder;
            colorAndCode.Color = Color.FromRgb(153, 209, 255);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSelectedItemBorder = colorAndCode.HtmlColorCode;
            AppColors.SelectedItemBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSelectedItemBorder;
            colorAndCode.Color = Color.FromRgb(20, 29, 75);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeSelectedItemBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSelectedItemBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorOpenFolder;
            colorAndCode.Color = Color.FromRgb(194, 245, 222);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorOpenFolder = colorAndCode.HtmlColorCode;
            AppColors.OpenFolder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeOpenFolder;
            colorAndCode.Color = Color.FromRgb(20, 65, 42);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeOpenFolder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeOpenFolder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorOpenFolderBorder;
            colorAndCode.Color = Color.FromRgb(153, 255, 165);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorOpenFolderBorder = colorAndCode.HtmlColorCode;
            AppColors.OpenFolderBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeOpenFolderBorder;
            colorAndCode.Color = Color.FromRgb(20, 75, 85);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeOpenFolderBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeOpenFolderBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorIcons;
            colorAndCode.Color = Color.FromRgb(149, 160, 166);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorIcons = colorAndCode.HtmlColorCode;
            AppColors.Icons = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeIcons;
            colorAndCode.Color = Color.FromRgb(149, 160, 166);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeIcons = colorAndCode.HtmlColorCode;
            AppColors.DarkModeIcons = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSearchField;
            colorAndCode.Color = Color.FromRgb(255, 255, 255);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSearchField = colorAndCode.HtmlColorCode;
            AppColors.SearchField = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSearchField;
            colorAndCode.Color = Color.FromRgb(25, 25, 25);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeSearchField = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSearchField = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorBackground;
            colorAndCode.Color = Color.FromRgb(255, 255, 255);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorBackground = colorAndCode.HtmlColorCode;
            AppColors.Background = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeBackground;
            colorAndCode.Color = Color.FromRgb(32, 32, 32);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeBackground = colorAndCode.HtmlColorCode;
            AppColors.DarkModeBackground = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorBackgroundBorder;
            colorAndCode.Color = Color.FromRgb(0, 0, 0);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorBackgroundBorder = colorAndCode.HtmlColorCode;
            AppColors.BackgroundBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeBackgroundBorder;
            colorAndCode.Color = Color.FromRgb(0, 0, 0);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorDarkModeBackgroundBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeBackgroundBorder = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrow;
            colorAndCode.Color = Color.FromRgb(96, 96, 96);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrow = colorAndCode.HtmlColorCode;
            AppColors.Arrow = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverBackground;
            colorAndCode.Color = Color.FromRgb(218, 218, 218);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowHoverBackground = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverBackground = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHover;
            colorAndCode.Color = Color.FromRgb(0, 0, 0);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowHover = colorAndCode.HtmlColorCode;
            AppColors.ArrowHover = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClick;
            colorAndCode.Color = Color.FromRgb(255, 255, 255);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowClick = colorAndCode.HtmlColorCode;
            AppColors.ArrowClick = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickBackground;
            colorAndCode.Color = Color.FromRgb(96, 96, 96);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowClickBackground = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickBackground = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderArrowsAndTrackHover;
            colorAndCode.Color = Color.FromRgb(192, 192, 192);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderArrowsAndTrackHover = colorAndCode.HtmlColorCode;
            AppColors.SliderArrowsAndTrackHover = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSlider;
            colorAndCode.Color = Color.FromRgb(205, 205, 205);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSlider = colorAndCode.HtmlColorCode;
            AppColors.Slider = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderHover;
            colorAndCode.Color = Color.FromRgb(166, 166, 166);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderHover = colorAndCode.HtmlColorCode;
            AppColors.SliderHover = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDragging;
            colorAndCode.Color = Color.FromRgb(96, 96, 96);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderDragging = colorAndCode.HtmlColorCode;
            AppColors.SliderDragging = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorScrollbarBackground;
            colorAndCode.Color = Color.FromRgb(240, 240, 240);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorScrollbarBackground = colorAndCode.HtmlColorCode;
            AppColors.ScrollbarBackground = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowDarkMode;
            colorAndCode.Color = Color.FromRgb(103, 103, 103);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverBackgroundDarkMode;
            colorAndCode.Color = Color.FromRgb(55, 55, 55);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowHoverBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverBackgroundDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverDarkMode;
            colorAndCode.Color = Color.FromRgb(103, 103, 103);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickDarkMode;
            colorAndCode.Color = Color.FromRgb(23, 23, 23);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowClickDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickBackgroundDarkMode;
            colorAndCode.Color = Color.FromRgb(166, 166, 166);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorArrowClickBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickBackgroundDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode;
            colorAndCode.Color = Color.FromRgb(77, 77, 77);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderArrowsAndTrackHoverDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDarkMode;
            colorAndCode.Color = Color.FromRgb(77, 77, 77);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderHoverDarkMode;
            colorAndCode.Color = Color.FromRgb(122, 122, 122);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderHoverDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDraggingDarkMode;
            colorAndCode.Color = Color.FromRgb(166, 166, 166);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorSliderDraggingDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderDraggingDarkMode = new SolidColorBrush(colorAndCode.Color);

            colorAndCode.HtmlColorCode = Settings.Default.ColorScrollbarBackgroundDarkMode;
            colorAndCode.Color = Color.FromRgb(23, 23, 23);
            ProcessColorAndCode(converter, ref colorAndCode, ref resetDefaults);
            Settings.Default.ColorScrollbarBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ScrollbarBackgroundDarkMode = new SolidColorBrush(colorAndCode.Color);

            if (save && resetDefaults)
            {
                Settings.Default.Save();
            }
        }

        private static bool IsRegistryValueThisValue(string keyName, string valueName, string value)
        {
            bool isRegistryValueThisValue = false;

            try
            {
                object? registryHideFileExt = Registry.GetValue(keyName, valueName, 1);

                if (registryHideFileExt == null)
                {
                    Log.Info($"Could not read registry keyName:{keyName} valueName:{valueName}");
                }
                else if (registryHideFileExt.ToString() == value)
                {
                    isRegistryValueThisValue = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Security.SecurityException ||
                    ex is IOException)
                {
                    Log.Warn($"Could not read registry keyName:{keyName} valueName:{valueName}", ex);
                }
                else
                {
                    throw;
                }
            }

            return isRegistryValueThisValue;
        }

        private static void UpgradeIfNotUpgraded()
        {
            if (!Settings.Default.IsUpgraded)
            {
                Settings.Default.Upgrade();
                Settings.Default.IsUpgraded = true;
                Settings.Default.Save();
                Log.Info($"Settings upgraded from {CustomSettingsProvider.UserConfigPath}");
            }
        }

        private static void ProcessColorAndCode(
            ColorConverter colorConverter,
            ref ColorAndCode colorAndCode,
            ref bool resetDefaults)
        {
            try
            {
                Color? color = (Color?)colorConverter.ConvertFromInvariantString(colorAndCode.HtmlColorCode);
                if (color != null)
                {
                    colorAndCode.Color = color.Value;
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"HtmlColorCode {colorAndCode.HtmlColorCode}", ex);
                colorAndCode.HtmlColorCode = System.Drawing.ColorTranslator.ToHtml(
                    System.Drawing.Color.FromArgb(colorAndCode.Color.R, colorAndCode.Color.G, colorAndCode.Color.B));
                resetDefaults = true;
            }
        }

        /// <summary>
        /// Helper class to process color settings.
        /// </summary>
        internal struct ColorAndCode
        {
            public Color Color { get; set; }

            public string HtmlColorCode { get; set; }
        }
    }
}
