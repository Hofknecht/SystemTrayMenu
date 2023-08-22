// <copyright file="Scaling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    internal static class Scaling
    {
        private static readonly FontSizeConverter FontConverter = new ();

        public static float Factor { get; private set; } = 1;

        // TODO: This value is per visual element and should not be shared!
        public static double FactorByDpi { get; private set; } = 1;

        public static void Initialize()
        {
            Factor = Properties.Settings.Default.SizeInPercent / 100f;
        }

        public static int Scale(int width)
        {
            return (int)Math.Round(width * Factor, 0, MidpointRounding.AwayFromZero);
        }

        public static double Scale(double width)
        {
            return Math.Round(width * Factor, 0, MidpointRounding.AwayFromZero);
        }

        public static double ScaleFontByPoints(float points)
        {
            return (double)FontConverter.ConvertFrom((points * Factor).ToString() + "pt")!;
        }

        public static double ScaleFontByPixels(float pixels)
        {
            return pixels * Factor;
        }

        public static void CalculateFactorByDpi(Window window)
        {
            FactorByDpi = VisualTreeHelper.GetDpi(window).DpiScaleX;
        }
    }
}
