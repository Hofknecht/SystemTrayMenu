// <copyright file="WindowsExplorerSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System.Collections.Generic;
    internal class WindowsExplorerSort : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return DllImports.NativeMethods.ShlwapiStrCmpLogicalW(x, y);
        }
    }
}
