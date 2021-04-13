// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;

    public static class Config
    {
        public const string Language = "en";

        private static bool readDarkModeDone = false;
        private static bool isDarkModeFromFirstCall = false;

        public static string Path => Properties.Settings.Default.PathDirectory;

        public static void UpgradeIfNotUpgraded()
        {
            if (!Properties.Settings.Default.IsUpgraded)
            {
                // configs located at "%localappdata%\<AssemblyCompany>\"
                Properties.Settings.Default.Upgrade();

                Properties.Settings.Default.IsUpgraded = true;
                Properties.Settings.Default.Save();

                FileVersionInfo versionInfo = FileVersionInfo.
                    GetVersionInfo(Assembly.GetEntryAssembly().Location);
                Log.Info($"Settings upgraded from " +
                    $"%localappdata%\\{versionInfo.CompanyName}\\");
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

        internal static bool IsDarkMode()
        {
            bool isDarkMode = false;
            if (readDarkModeDone)
            {
                isDarkMode = isDarkModeFromFirstCall;
            }
            else
            {
                if (Properties.Settings.Default.IsDarkModeAlwaysOn || IsDarkModeActive())
                {
                    isDarkModeFromFirstCall = true;
                    isDarkMode = true;
                }

                readDarkModeDone = true;
            }

            return isDarkMode;
        }

        /// <summary>
        /// Read the OS setting whether dark mode is enabled.
        /// </summary>
        /// <returns>true = Dark mode; false = Light mode.</returns>
        private static bool IsDarkModeActive()
        {
            // Check: AppsUseLightTheme (REG_DWORD)
            bool isDarkModeActive = false;
            object registryValueAppsUseLightTheme = Registry.GetValue(
                "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
                "AppsUseLightTheme",
                1);

            // 0 = Dark mode, 1 = Light mode
            if (registryValueAppsUseLightTheme != null && 
                registryValueAppsUseLightTheme.ToString() == "0")
            {
                isDarkModeActive = true;
            }

            return isDarkModeActive;
        }
    }
}
