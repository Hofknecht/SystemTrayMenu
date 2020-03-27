using System.Collections.Generic;

namespace SystemTrayMenu.Helper
{
    internal class WindowsExplorerSort : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return NativeMethods.NativeMethods.ShlwapiStrCmpLogicalW(x, y);
        }
    }
}
