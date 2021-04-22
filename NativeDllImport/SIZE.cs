// <copyright file="SIZE.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SIZE
    {
        public int Cx;
        public int Cy;

        public SIZE(int cx, int cy)
        {
            Cx = cx;
            Cy = cy;
        }
    }
}
