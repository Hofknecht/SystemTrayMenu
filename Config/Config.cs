// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;

    public static class Config
    {
        private static bool readDarkModeDone;
        private static bool isDarkMode;
        private static bool readHideFileExtdone;
        private static bool isHideFileExtension;

        public static bool IsHideFileExtdone => IsHideFileExtension();

        public static string Path => Settings.Default.PathDirectory;

        public static void Initialize()
        {
            UpgradeIfNotUpgraded();
            InitializeColors();
        }

        public static bool LoadOrSetByUser()
        {
            bool pathOK = Directory.Exists(Path);

            if (!pathOK)
            {
                string textFirstStart = Translator.GetText("TextFirstStart");
                MessageBox.Show(
                    textFirstStart,
                    Translator.GetText("SystemTrayMenu"),
                    MessageBoxButtons.OK);
                ShowHelpFAQ();
                pathOK = SetFolderByUser();
            }

            return pathOK;
        }

        public static bool SetFolderByUser(bool save = true)
        {
            bool pathOK = false;
            bool userAborted = false;
            using (FolderDialog dialog = new FolderDialog())
            {
                dialog.InitialFolder = Path;

                do
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.Exists(dialog.Folder))
                        {
                            pathOK = true;
                            Settings.Default.PathDirectory =
                                dialog.Folder;
                            if (save)
                            {
                                Settings.Default.Save();
                            }
                        }
                    }
                    else
                    {
                        userAborted = true;
                    }
                }
                while (!pathOK && !userAborted);
            }

            return pathOK;
        }

        internal static void ShowHelpFAQ()
        {
            if (FileUrl.GetDefaultBrowserPath(out string browserPath))
            {
                Process.Start(browserPath, "https://github.com/Hofknecht/SystemTrayMenu#FAQ");
            }
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

        /// <summary>
        /// Read the OS setting whether HideFileExt enabled.
        /// </summary>
        /// <returns>true = Dark mode; false = Light mode.</returns>
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
            var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).FilePath;
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Settings.Default.IsUpgraded)
            {
                Settings.Default.Upgrade();
                Settings.Default.IsUpgraded = true;
                Settings.Default.Save();
                Log.Info($"Settings upgraded from {CustomSettingsProvider.UserConfigPath}");
            }
        }

        private static void InitializeColors()
        {
            ColorConverter converter = new ColorConverter();
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

            colorAndCode.HtmlColorCode = Settings.Default.ColorWarning;
            colorAndCode.Color = Color.FromArgb(255, 204, 232);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorWarning = colorAndCode.HtmlColorCode;
            AppColors.Warning = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeWarning;
            colorAndCode.Color = Color.FromArgb(75, 24, 52);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeWarning = colorAndCode.HtmlColorCode;
            AppColors.DarkModeWarning = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorTitle;
            colorAndCode.Color = Color.Azure;
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorTitle = colorAndCode.HtmlColorCode;
            AppColors.Title = colorAndCode.Color;

            colorAndCode.HtmlColorCode = Settings.Default.ColorDarkModeTitle;
            colorAndCode.Color = Color.FromArgb(43, 43, 43);
            colorAndCode = ProcessColorAndCode(converter, colorAndCode, ref changed);
            Settings.Default.ColorDarkModeTitle = colorAndCode.HtmlColorCode;
            AppColors.DarkModeTitle = colorAndCode.Color;

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

            if (changed)
            {
                Settings.Default.Save();
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
