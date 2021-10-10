// <copyright file="Scaling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;

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
    }
}
