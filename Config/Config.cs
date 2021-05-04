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
            s.ColorBlue = SetColor(c, ref AppColors.Blue, Color.FromArgb(204, 232, 255), s.ColorBlue);
            s.ColorDarkModeBlue = SetColor(c, ref AppColors.DarkModeBlue, Color.FromArgb(51, 51, 51), s.ColorDarkModeBlue);
            s.ColorBlueBorder = SetColor(c, ref AppColors.BlueBorder, Color.FromArgb(153, 209, 255), s.ColorBlueBorder);
            s.ColorDarkModeBlueBorder = SetColor(c, ref AppColors.DarkModeBlueBorder, Color.FromArgb(20, 29, 75), s.ColorDarkModeBlueBorder);
            s.ColorGreen = SetColor(c, ref AppColors.Green, Color.FromArgb(194, 245, 222), s.ColorGreen);
            s.ColorDarkModeGreen = SetColor(c, ref AppColors.DarkModeGreen, Color.FromArgb(20, 65, 42), s.ColorDarkModeGreen);
            s.ColorGreenBorder = SetColor(c, ref AppColors.GreenBorder, Color.FromArgb(153, 255, 165), s.ColorGreenBorder);
            s.ColorDarkModeGreenBorder = SetColor(c, ref AppColors.DarkModeGreenBorder, Color.FromArgb(20, 75, 85), s.ColorDarkModeGreenBorder);
            s.ColorRed = SetColor(c, ref AppColors.Red, Color.FromArgb(255, 204, 232), s.ColorRed);
            s.ColorDarkModeRed = SetColor(c, ref AppColors.DarkModeRed, Color.FromArgb(75, 24, 52), s.ColorDarkModeRed);
            s.ColorAzure = SetColor(c, ref AppColors.Azure, Color.Azure, s.ColorAzure);
            s.ColorDarkModeAzure = SetColor(c, ref AppColors.DarkModeAzure, Color.FromArgb(43, 43, 43), s.ColorDarkModeAzure);
            s.ColorSearch = SetColor(c, ref AppColors.Search, Color.FromArgb(255, 255, 255), s.ColorSearch);
            s.ColorDarkModeSearch = SetColor(c, ref AppColors.DarkModeSearch, Color.FromArgb(25, 25, 25), s.ColorDarkModeSearch);
            s.ColorMain = SetColor(c, ref AppColors.Main, Color.FromArgb(255, 255, 255), s.ColorMain);
            s.ColorDarkModeMain = SetColor(c, ref AppColors.DarkModeMain, Color.FromArgb(32, 32, 32), s.ColorDarkModeMain);

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
