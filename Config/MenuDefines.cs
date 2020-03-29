using System.Collections.Generic;
using System.Drawing;

namespace SystemTrayMenu
{
    public static class MenuDefines
    {
        public static readonly List<string> Languages =
            new List<string>() { "en", "de" };
        public static readonly Color File = Color.White;
        public static readonly Color Folder = Color.White;
        public static readonly Color ColorSelectedItem = AppColors.Blue;
        public static readonly Color ColorOpenFolder = AppColors.Green;
        public static readonly Color ColorTitleWarning = AppColors.Red;
        public static readonly Color ColorTitleSelected = AppColors.Yellow;
        public static readonly Color ColorTitleBackground = AppColors.YellowSlightly;
        public const int KeySearchInterval = 1000;
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
        public const int MaxClicksInQueue = 1;
    }

    public static class AppColors
    {
        public static readonly Color Blue = Color.FromArgb(204, 232, 255);
        public static readonly Color BlueSelectedInactive = Color.FromArgb(217, 217, 217);
        public static readonly Color Green = Color.FromArgb(194, 245, 222);
        public static readonly Color GreenBackgroundInactive = Color.FromArgb(217, 217, 217);
        public static readonly Color Red = Color.FromArgb(255, 204, 232);
        public static readonly Color Yellow = Color.LightYellow;
        public static readonly Color YellowSlightly = Color.Azure;
    }
}