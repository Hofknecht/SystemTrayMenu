// <copyright file="TrackPopupMenuEx.cs" company="PlaceholderCompany">
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
        /// <summary>
        /// Specifies how TrackPopupMenuEx positions the shortcut menu horizontally.
        /// </summary>
        [Flags]
        internal enum TPM : uint
        {
#pragma warning disable SA1602 // Enumeration items should be documented
            LEFTBUTTON = 0x0000, // LEFTALIGN = 0x0000, // TOPALIGN = 0x0000, // HORIZONTAL = 0x0000,
            RIGHTBUTTON = 0x0002,
            CENTERALIGN = 0x0004,
            RIGHTALIGN = 0x0008,
            VCENTERALIGN = 0x0010,
            BOTTOMALIGN = 0x0020,
            VERTICAL = 0x0040,
            NONOTIFY = 0x0080,
            RETURNCMD = 0x0100,
            RECURSE = 0x0001,
            HORPOSANIMATION = 0x0400,
            HORNEGANIMATION = 0x0800,
            VERPOSANIMATION = 0x1000,
            VERNEGANIMATION = 0x2000,
            NOANIMATION = 0x4000,
            LAYOUTRTL = 0x8000,
#pragma warning restore SA1602 // Enumeration items should be documented
        }

        /// <summary>
        /// user32 TrackPopupMenuEx.
        /// </summary>
        /// <param name="hmenu">hmenu.</param>
        /// <param name="flags">flags.</param>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        /// <param name="hwnd">hwnd.</param>
        /// <param name="lptpm">lptpm.</param>
        /// <returns>uint.</returns>
        internal static uint User32TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm)
        {
            return TrackPopupMenuEx(hmenu, flags, x, y, hwnd, lptpm);
        }

        // The TrackPopupMenuEx function displays a shortcut menu at the specified location and tracks the selection of items on the shortcut menu. The shortcut menu can appear anywhere on the screen.
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern uint TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    }
}
