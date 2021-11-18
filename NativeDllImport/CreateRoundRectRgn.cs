// <copyright file="CreateRoundRectRgn.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static bool GetRegionRoundCorners(int width, int height, int widthEllipse, int heightEllipse, out System.Drawing.Region region)
        {
            bool success = false;
            region = null;

            IntPtr handle = CreateRoundRectRgn(0, 0, width, height, widthEllipse, heightEllipse);
            if (handle != IntPtr.Zero)
            {
                region = System.Drawing.Region.FromHrgn(handle);
                DeleteObject(handle);
                success = true;
            }

            return success;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateRoundRectRgn(
               int nLeftRect,     // x-coordinate of upper-left corner
               int nTopRect,      // y-coordinate of upper-left corner
               int nRightRect,    // x-coordinate of lower-right corner
               int nBottomRect,   // y-coordinate of lower-right corner
               int nWidthEllipse, // width of ellipse
               int nHeightEllipse); // height of ellipse
    }
}
