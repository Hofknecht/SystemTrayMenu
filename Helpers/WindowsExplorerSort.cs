// <copyright file="WindowsExplorerSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System.Collections.Generic;
    using System.IO;

    internal class WindowsExplorerSort : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (Properties.Settings.Default.SortFolderAndFilesByDate)
            {
                if (new FileInfo(x).LastWriteTime > new FileInfo(y).LastWriteTime)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return DllImports.NativeMethods.ShlwapiStrCmpLogicalW(x, y);
            }
        }
    }
}
