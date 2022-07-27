// <copyright file="Scaling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Drawing;

    internal static class Scaling
    {
        public static float Factor { get; private set; } = 1;

        public static float FactorByDpi { get; private set; } = 1;

        public static void Initialize()
        {
            Factor = Properties.Settings.Default.SizeInPercent / 100f;
        }

        public static int Scale(int width)
        {
            return (int)Math.Round(width * Factor, 0, MidpointRounding.AwayFromZero);
        }

        public static void CalculateFactorByDpi(Graphics graphics)
        {
            FactorByDpi = graphics.DpiX / 96;
        }
    }
}
