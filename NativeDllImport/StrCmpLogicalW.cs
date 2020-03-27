using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string x, string y);

        public static int ShlwapiStrCmpLogicalW(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
