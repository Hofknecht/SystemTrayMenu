using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
        // Takes a STRRET structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and places the result in a buffer. 
        [DllImport("shlwapi.dll", EntryPoint = "StrRetToBuf", ExactSpelling = false, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

        public static int ShlwapiStrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf)
        {
            return StrRetToBuf(pstr, pidl, pszBuf, cchBuf);
        }
    }
}
