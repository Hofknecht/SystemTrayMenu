// <copyright file="SIZE.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int Cx;
        public int Cy;

        public SIZE(int cx, int cy)
        {
            this.Cx = cx;
            this.Cy = cy;
        }
    }
}
