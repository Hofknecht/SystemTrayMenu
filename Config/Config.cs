// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
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
            if (!Settings.Default.IsUpgraded)
            {
                Settings.Default.Upgrade();
                Settings.Default.IsUpgraded = true;
                Settings.Default.Save();

                FileVersionInfo versionInfo = FileVersionInfo.
                    GetVersionInfo(Assembly.GetEntryAssembly().Location);
                string upgradedFromPath = $"%localappdata%\\{versionInfo.CompanyName}\\";
                try
                {
                    upgradedFromPath = System.IO.Path.GetFullPath(upgradedFromPath);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException ||
                        ex is System.Security.SecurityException ||
                        ex is NotSupportedException ||
                        ex is PathTooLongException)
                    {
                        Log.Warn($"Resolve path {upgradedFromPath} failed", ex);
                    }
                    else
                    {
                        throw;
                    }
                }

                Log.Info($"Settings upgraded from {upgradedFromPath}");
            }
        }

        private static void InitializeColors()
        {
            ColorConverter c = new ColorConverter();
            Settings s = Settings.Default;
            s.ColorSelectedItem = SetColor(c, ref AppColors.SelectedItem, Color.FromArgb(204, 232, 255), s.ColorSelectedItem);
            s.ColorDarkModeSelecetedItem = SetColor(c, ref AppColors.DarkModeSelecetedItem, Color.FromArgb(51, 51, 51), s.ColorDarkModeSelecetedItem);
            s.ColorSelectedItemBorder = SetColor(c, ref AppColors.SelectedItemBorder, Color.FromArgb(153, 209, 255), s.ColorSelectedItemBorder);
            s.ColorDarkModeSelectedItemBorder = SetColor(c, ref AppColors.DarkModeSelectedItemBorder, Color.FromArgb(20, 29, 75), s.ColorDarkModeSelectedItemBorder);
            s.ColorOpenFolder = SetColor(c, ref AppColors.OpenFolder, Color.FromArgb(194, 245, 222), s.ColorOpenFolder);
            s.ColorDarkModeOpenFolder = SetColor(c, ref AppColors.DarkModeOpenFolder, Color.FromArgb(20, 65, 42), s.ColorDarkModeOpenFolder);
            s.ColorOpenFolderBorder = SetColor(c, ref AppColors.OpenFolderBorder, Color.FromArgb(153, 255, 165), s.ColorOpenFolderBorder);
            s.ColorDarkModeOpenFolderBorder = SetColor(c, ref AppColors.DarkModeOpenFolderBorder, Color.FromArgb(20, 75, 85), s.ColorDarkModeOpenFolderBorder);
            s.ColorWarning = SetColor(c, ref AppColors.Warning, Color.FromArgb(255, 204, 232), s.ColorWarning);
            s.ColorDarkModeWarning = SetColor(c, ref AppColors.DarkModeWarning, Color.FromArgb(75, 24, 52), s.ColorDarkModeWarning);
            s.ColorTitle = SetColor(c, ref AppColors.Title, Color.Azure, s.ColorTitle);
            s.ColorDarkModeTitle = SetColor(c, ref AppColors.DarkModeTitle, Color.FromArgb(43, 43, 43), s.ColorDarkModeTitle);
            s.ColorSearchField = SetColor(c, ref AppColors.SearchField, Color.FromArgb(255, 255, 255), s.ColorSearchField);
            s.ColorDarkModeSearchField = SetColor(c, ref AppColors.DarkModeSearchField, Color.FromArgb(25, 25, 25), s.ColorDarkModeSearchField);
            s.ColorBackground = SetColor(c, ref AppColors.Background, Color.FromArgb(255, 255, 255), s.ColorBackground);
            s.ColorDarkModeBackground = SetColor(c, ref AppColors.DarkModeBackground, Color.FromArgb(32, 32, 32), s.ColorDarkModeBackground);
            s.Save();
        }

        private static string SetColor(
            ColorConverter colorConverter,
            ref Color appColor,
            Color colorDefault,
            string colorHtmlCode)
        {
            string colorHtmlCodeCorrected = colorHtmlCode;

            try
            {
                appColor = (Color)colorConverter.ConvertFromString(colorHtmlCode);
            }
            catch (ArgumentException ex)
            {
                Log.Warn($"colorHtmlCode {colorHtmlCode}", ex);
                appColor = colorDefault;
                colorHtmlCodeCorrected = ColorTranslator.ToHtml(colorDefault);
                Settings.Default.Save();
            }

            return colorHtmlCodeCorrected;
        }
    }
}
