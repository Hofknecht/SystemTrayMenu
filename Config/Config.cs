using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
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
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.InitialDirectory = Path;
                dialog.IsFolderPicker = true;

                do
                {
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        if (Directory.Exists(dialog.FileName))
                        {
                            pathOK = true;
                            Properties.Settings.Default.PathDirectory =
                                dialog.FileName;
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
            Process.Start("https://github.com/Hofknecht/SystemTrayMenu#FAQ");
        }
    }
}
