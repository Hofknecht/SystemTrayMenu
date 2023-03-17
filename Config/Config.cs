// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using Svg;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.Utilities.IconReader;

    public static class Config
    {
        private static readonly Icon SystemTrayMenu = new Icon(Properties.Resources.SystemTrayMenu, SystemInformation.SmallIconSize);
        private static readonly Icon IconRootFolder = GetIconSTA(Path, Path, false, IconSize.Small, true);

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

        public static void Dispose()
        {
            AppColors.BitmapOpenFolder.Dispose();
            AppColors.BitmapPin.Dispose();
            AppColors.BitmapPinActive.Dispose();
            AppColors.BitmapSettings.Dispose();
            AppColors.BitmapRestart.Dispose();
            AppColors.BitmapSearch.Dispose();
        }

        public static Icon GetAppIcon()
        {
            if (Settings.Default.UseIconFromRootFolder)
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
                    MessageBoxButtons.OK);
                ShowHelpFAQ();
                SetFolderByUser();
            }
        }

        public static void SetFolderByUser(bool save = true)
        {
            using FolderDialog dialog = new();
            dialog.InitialFolder = Path;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PathDirectory = dialog.Folder;
                if (save)
                {
                    Settings.Default.Save();
                }
            }
        }

        public static void SetFolderIcoByUser()
        {
            using FolderDialog dialog = new();
            dialog.InitialFolder = Settings.Default.PathIcoDirectory;

            if (dialog.ShowDialog() == DialogResult.OK)
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
            bool changed = false;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSelectedItem;
            colorAndCode.Color = Color.FromArgb(204, 232, 255);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSelectedItem = colorAndCode.HtmlColorCode;
            AppColors.SelectedItem = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSelecetedItem;
            colorAndCode.Color = Color.FromArgb(51, 51, 51);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeSelecetedItem = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSelecetedItem = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSelectedItemBorder;
            colorAndCode.Color = Color.FromArgb(153, 209, 255);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSelectedItemBorder = colorAndCode.HtmlColorCode;
            AppColors.SelectedItemBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSelectedItemBorder;
            colorAndCode.Color = Color.FromArgb(20, 29, 75);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeSelectedItemBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSelectedItemBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorOpenFolder;
            colorAndCode.Color = Color.FromArgb(194, 245, 222);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorOpenFolder = colorAndCode.HtmlColorCode;
            AppColors.OpenFolder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeOpenFolder;
            colorAndCode.Color = Color.FromArgb(20, 65, 42);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeOpenFolder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeOpenFolder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorOpenFolderBorder;
            colorAndCode.Color = Color.FromArgb(153, 255, 165);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorOpenFolderBorder = colorAndCode.HtmlColorCode;
            AppColors.OpenFolderBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeOpenFolderBorder;
            colorAndCode.Color = Color.FromArgb(20, 75, 85);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeOpenFolderBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeOpenFolderBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorIcons;
            colorAndCode.Color = Color.FromArgb(149, 160, 166);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorIcons = colorAndCode.HtmlColorCode;
            AppColors.Icons = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeIcons;
            colorAndCode.Color = Color.FromArgb(149, 160, 166);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeIcons = colorAndCode.HtmlColorCode;
            AppColors.DarkModeIcons = colorAndCode.Color;

            string htmlColorCodeIcons;
            if (IsDarkMode())
            {
                htmlColorCodeIcons = Settings.Default.ColorDarkModeIcons;
            }
            else
            {
                htmlColorCodeIcons = Settings.Default.ColorIcons;
            }

            AppColors.BitmapOpenFolder =
                ReadSvg(Properties.Resources.ic_fluent_folder_arrow_right_48_regular, htmlColorCodeIcons);
            AppColors.BitmapPin =
                ReadSvg(Properties.Resources.ic_fluent_pin_48_regular, htmlColorCodeIcons);
            AppColors.BitmapSettings =
                ReadSvg(Properties.Resources.ic_fluent_settings_28_regular, htmlColorCodeIcons);
            AppColors.BitmapRestart =
                ReadSvg(Properties.Resources.ic_fluent_arrow_sync_24_regular, htmlColorCodeIcons);
            AppColors.BitmapPinActive =
                ReadSvg(Properties.Resources.ic_fluent_pin_48_filled, htmlColorCodeIcons);
            AppColors.BitmapSearch =
                ReadSvg(Properties.Resources.ic_fluent_search_48_regular, htmlColorCodeIcons);

            colorAndCode.HtmlColorCode = Settings.Default.ColorSearchField;
            colorAndCode.Color = Color.FromArgb(255, 255, 255);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSearchField = colorAndCode.HtmlColorCode;
            AppColors.SearchField = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeSearchField;
            colorAndCode.Color = Color.FromArgb(25, 25, 25);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeSearchField = colorAndCode.HtmlColorCode;
            AppColors.DarkModeSearchField = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorBackground;
            colorAndCode.Color = Color.FromArgb(255, 255, 255);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorBackground = colorAndCode.HtmlColorCode;
            AppColors.Background = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeBackground;
            colorAndCode.Color = Color.FromArgb(32, 32, 32);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeBackground = colorAndCode.HtmlColorCode;
            AppColors.DarkModeBackground = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorBackgroundBorder;
            colorAndCode.Color = Color.FromArgb(0, 0, 0);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorBackgroundBorder = colorAndCode.HtmlColorCode;
            AppColors.BackgroundBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeBackgroundBorder;
            colorAndCode.Color = Color.FromArgb(0, 0, 0);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeBackgroundBorder = colorAndCode.HtmlColorCode;
            AppColors.DarkModeBackgroundBorder = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrow;
            colorAndCode.Color = Color.FromArgb(96, 96, 96);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrow = colorAndCode.HtmlColorCode;
            AppColors.Arrow = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverBackground;
            colorAndCode.Color = Color.FromArgb(218, 218, 218);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowHoverBackground = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverBackground = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHover;
            colorAndCode.Color = Color.FromArgb(0, 0, 0);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowHover = colorAndCode.HtmlColorCode;
            AppColors.ArrowHover = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClick;
            colorAndCode.Color = Color.FromArgb(255, 255, 255);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowClick = colorAndCode.HtmlColorCode;
            AppColors.ArrowClick = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickBackground;
            colorAndCode.Color = Color.FromArgb(96, 96, 96);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowClickBackground = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickBackground = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderArrowsAndTrackHover;
            colorAndCode.Color = Color.FromArgb(192, 192, 192);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderArrowsAndTrackHover = colorAndCode.HtmlColorCode;
            AppColors.SliderArrowsAndTrackHover = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSlider;
            colorAndCode.Color = Color.FromArgb(205, 205, 205);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSlider = colorAndCode.HtmlColorCode;
            AppColors.Slider = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderHover;
            colorAndCode.Color = Color.FromArgb(166, 166, 166);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderHover = colorAndCode.HtmlColorCode;
            AppColors.SliderHover = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDragging;
            colorAndCode.Color = Color.FromArgb(96, 96, 96);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderDragging = colorAndCode.HtmlColorCode;
            AppColors.SliderDragging = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorScrollbarBackground;
            colorAndCode.Color = Color.FromArgb(240, 240, 240);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorScrollbarBackground = colorAndCode.HtmlColorCode;
            AppColors.ScrollbarBackground = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowDarkMode;
            colorAndCode.Color = Color.FromArgb(103, 103, 103);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverBackgroundDarkMode;
            colorAndCode.Color = Color.FromArgb(55, 55, 55);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowHoverBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverBackgroundDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowHoverDarkMode;
            colorAndCode.Color = Color.FromArgb(103, 103, 103);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowHoverDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickDarkMode;
            colorAndCode.Color = Color.FromArgb(23, 23, 23);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowClickDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorArrowClickBackgroundDarkMode;
            colorAndCode.Color = Color.FromArgb(166, 166, 166);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorArrowClickBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ArrowClickBackgroundDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode;
            colorAndCode.Color = Color.FromArgb(77, 77, 77);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderArrowsAndTrackHoverDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDarkMode;
            colorAndCode.Color = Color.FromArgb(77, 77, 77);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderHoverDarkMode;
            colorAndCode.Color = Color.FromArgb(122, 122, 122);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderHoverDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderHoverDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorSliderDraggingDarkMode;
            colorAndCode.Color = Color.FromArgb(166, 166, 166);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorSliderDraggingDarkMode = colorAndCode.HtmlColorCode;
            AppColors.SliderDraggingDarkMode = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorScrollbarBackgroundDarkMode;
            colorAndCode.Color = Color.FromArgb(23, 23, 23);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorScrollbarBackgroundDarkMode = colorAndCode.HtmlColorCode;
            AppColors.ScrollbarBackgroundDarkMode = colorAndCode.Color;

            if (save && changed)
            {
                Settings.Default.Save();
            }
        }

        private static Bitmap ReadSvg(byte[] byteArray, string htmlColorCode)
        {
            string str = Encoding.UTF8.GetString(byteArray);
            str = str.Replace("#585858", htmlColorCode);
            byteArray = Encoding.UTF8.GetBytes(str);

            using MemoryStream stream = new(byteArray);
            SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(stream);
            svgDocument.Color = new SvgColourServer(Color.Black);
            return svgDocument.Draw();
        }

        private static bool IsRegistryValueThisValue(string keyName, string valueName, string value)
        {
            bool isRegistryValueThisValue = false;

            try
            {
                object registryHideFileExt = Registry.GetValue(keyName, valueName, 1);

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

        private static ColorAndCode ProcessColorAndCode(
            ColorConverter colorConverter,
            ColorAndCode colorAndCode,
            ref bool changedHtmlColorCode)
        {
            try
            {
                colorAndCode.Color = (Color)colorConverter.ConvertFromString(colorAndCode.HtmlColorCode);
            }
            catch (ArgumentException ex)
            {
                Log.Warn($"HtmlColorCode {colorAndCode.HtmlColorCode}", ex);
                colorAndCode.HtmlColorCode = ColorTranslator.ToHtml(colorAndCode.Color);
                changedHtmlColorCode = true;
            }

            return colorAndCode;
        }
    }
}
