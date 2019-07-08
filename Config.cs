using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace SystemTrayMenu
{
    public class Config
    {
        public static string Language = "en";

        public static string Path
        {
            get
            {
                return Properties.Settings.Default.PathDirectory;
            }
        }

        public static void UpgradeIfNotUpgraded()
        {
            if (!Properties.Settings.Default.IsUpgraded)
            {
                // configs located at "%localappdata%\<AssemblyCompany>\"
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgraded = true;
                Properties.Settings.Default.Save();
            }
        }

        public static bool LoadOrSetByUser()
        {
            bool pathOK = Directory.Exists(
                Properties.Settings.Default.PathDirectory);

            if (!pathOK)
            {
                pathOK = SetFolderByUser();
            }
            return pathOK;
        }

        public static bool SetFolderByUser()
        {
            bool pathOK = false;
            bool userAborted = false;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
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
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    userAborted = true;
                }
            }
            while (!pathOK && !userAborted);

            return pathOK;
        }
    }
}
