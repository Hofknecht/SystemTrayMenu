using System.Collections.Generic;
using System.Drawing;

namespace SystemTrayMenu
{
    public static class MenuDefines
    {
        public static readonly List<string> Languages =
            new List<string>() { "en", "de" };
        public static Color File = Color.White;
        public static Color Folder = Color.White;
        public static Color ColorSelectedItem = AppColors.Blue;
        public static Color ColorOpenFolder = AppColors.Green;
        public static Color ColorTitleWarning = AppColors.Red;
        public static Color ColorTitleSelected = AppColors.Yellow;
        public static Color ColorTitleBackground = AppColors.YellowSlightly;
        public static int KeySearchInterval = 1000;
        public const int MenuRowsHeight = 18;
        public const int LengthMax = 37;
        public const int Scrollspeed = 4;
        public const int WaitMenuOpen = 200;
        // 60 fps => 1000ms/60fps =~ 16.6ms
        public const int IntervalFade = 16;
        // 60 fps => 1000ms/60fps =~ 16.6ms
        public const int IntervalLoad = 16;
        public const double OpacityHalfValue = 0.80;
        public const double OpacityInStep = 0.20;
        public const double OpacityOutStep = 0.05;
        public const double OpacityHalfStep = 0.01;
        public const int MenusMax = 50;
        public static int MaxClicksInQueue = 1;
    }

    public static class AppColors
    {
        public static Color Blue = Color.FromArgb(204, 232, 255);
        public static Color BlueSelectedInactive = Color.FromArgb(217, 217, 217);
        public static Color Green = Color.FromArgb(194, 245, 222);
        public static Color GreenBackgroundInactive = Color.FromArgb(217, 217, 217);
        public static Color Red = Color.FromArgb(255, 204, 232);
        public static Color Yellow = Color.LightYellow;
        public static Color YellowSlightly = Color.Azure;
    }
}