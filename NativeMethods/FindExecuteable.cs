using System.Runtime.InteropServices;
using System.Text;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult);

        public static void Shell32FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult)
        {
            _ = FindExecutable(lpFile, lpDirectory, lpResult);
        }
    }
}
