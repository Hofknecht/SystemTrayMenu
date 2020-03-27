using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
        [DllImport("shfolder.dll", CharSet = CharSet.Unicode)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        public static int ShfolderSHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath)
        {
            return SHGetFolderPath(hwndOwner, nFolder, hToken, dwFlags, lpszPath);
        }
    }
}
