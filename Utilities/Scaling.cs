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
            Factor = Properties.Settings.Default.SizeInPercentage / 100f;
        }

        internal static int Scale(int width)
        {
            return (int)Math.Round(width * Factor, 0, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/5977445/how-to-get-windows-display-settings
        /// Since .net core 3.1 not more necessary / always returns 1.
        /// </summary>
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
