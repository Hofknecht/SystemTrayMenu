// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;

    public static class Config
    {
        private static bool readDarkModeDone = false;
        private static bool isDarkMode = false;
        private static bool readHideFileExtdone = false;
        private static bool isHideFileExtension = false;

        public static bool IsHideFileExtdone => IsHideFileExtension();

        public static string Path => Properties.Settings.Default.PathDirectory;

        public static void UpgradeIfNotUpgraded()
        {
            if (!Properties.Settings.Default.IsUpgraded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgraded = true;
                Properties.Settings.Default.Save();

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
                            Properties.Settings.Default.PathDirectory =
                                dialog.Folder;
                            if (save)
                            {
                                Properties.Settings.Default.Save();
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
            string browserPath = FileUrl.GetDefaultBrowserPath();
            if (!string.IsNullOrEmpty(browserPath))
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
                if (Properties.Settings.Default.IsDarkModeAlwaysOn ||
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
    }
}
