// <copyright file="Scaling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Drawing;

    internal static class Scaling
    {
        private enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        public static float Factor { get; private set; } = 1;

        internal static void Initialize()
        {
#warning [Feature(s)] High resolution compatibility #188
            Factor = 1f; // todo put factor to options

            // Not more necesssary, i think since upgrade to .net core
            // CalculateScalingFactor();
        }

        internal static int Scale(int width)
        {
            return (int)Math.Round(width * Factor, 0, MidpointRounding.AwayFromZero);
        }

        private static void CalculateScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int logicalScreenHeight = DllImports.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.VERTRES);
            int physicalScreenHeight = DllImports.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.DESKTOPVERTRES);
            Factor = physicalScreenHeight / (float)logicalScreenHeight;
        }
    }
}
