//using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SystemTrayMenu.UserInterface.FolderDialog;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu
{
    public static class Config
    {
        public const string Language = "en";

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
            bool pathOK = Directory.Exists(
                Properties.Settings.Default.PathDirectory);

            if (!pathOK)
            {
                string textFirstStart = Translator.GetText("TextFirstStart");
                MessageBox.Show(textFirstStart, Translator.GetText("SystemTrayMenu"),
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
            };

            return pathOK;
        }

        internal static void ShowHelpFAQ()
        {
            string browserPath = FileUrl.GetDefaultBrowserPath();
            if (string.IsNullOrEmpty(browserPath))
            {
                Process.Start(browserPath, "https://github.com/Hofknecht/SystemTrayMenu#FAQ");
            }
        }
    }
}
