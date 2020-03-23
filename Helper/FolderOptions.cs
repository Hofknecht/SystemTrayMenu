using Shell32;
using System;
using System.IO;

namespace SystemTrayMenu.Helper
{
    internal static class FolderOptions
    {
        private static bool hideHiddenEntries = false;
        private static bool hideSystemEntries = false;
        private static IShellDispatch4 iShellDispatch4 = null;

        internal static void Initialize()
        {
            try
            {
                iShellDispatch4 = (IShellDispatch4)Activator.CreateInstance(
                    Type.GetTypeFromProgID("Shell.Application"));

                // Using SHGetSetSettings would be much better in performance but the results are not accurate.
                // We have to go for the shell interface in order to receive the correct settings:
                // https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
                const int SSF_SHOWALLOBJECTS = 0x00000001;
                hideHiddenEntries = !iShellDispatch4.GetSetting(
                    SSF_SHOWALLOBJECTS);

                const int SSF_SHOWSUPERHIDDEN = 0x00040000;
                hideSystemEntries = !iShellDispatch4.GetSetting(
                    SSF_SHOWSUPERHIDDEN);
            }
            catch (Exception ex)
            {
                Log.Error("Get Shell COM instance failed", ex);
            }
        }

        internal static bool IsHidden(string path, ref bool hiddenEntry)
        {
            bool isDirectoryToHide = false;

            FileAttributes attributes = File.GetAttributes(path);
            hiddenEntry = attributes.HasFlag(FileAttributes.Hidden);
            bool systemEntry = attributes.HasFlag(
                FileAttributes.Hidden | FileAttributes.System);
            if ((hideHiddenEntries && hiddenEntry) ||
                (hideSystemEntries && systemEntry))
            {
                isDirectoryToHide = true;
            }

            return isDirectoryToHide;
        }
    }
}
