using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace SystemTrayMenu
{
    internal static class MenuDefines
    {
        internal static string NotifyIconText = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        internal static readonly List<string> Languages =
            new List<string>() { "en", "de" };
        internal static readonly Color File = Color.White;
        internal static readonly Color Folder = Color.White;
        internal static readonly Color ColorSelectedItem = AppColors.Blue;
        internal static readonly Color ColorOpenFolder = AppColors.Green;
        internal static readonly Color ColorTitleWarning = AppColors.Red;
        internal static readonly Color ColorTitleSelected = AppColors.Yellow;
        internal static readonly Color ColorTitleBackground = AppColors.YellowSlightly;
        internal const int KeySearchInterval = 1000;
        internal const int MenuRowsHeight = 18;
        internal const int LengthMax = 37;
        internal const int Scrollspeed = 4;
        internal const int WaitMenuOpen = 200;
        internal const int MenusMax = 50;
        internal const int MaxClicksInQueue = 1;
        internal const int TimeUntilClose = 1000;
    }

    internal static class AppColors
    {
        internal static readonly Color Blue = Color.FromArgb(204, 232, 255);
        internal static readonly Color BlueSelectedInactive = Color.FromArgb(217, 217, 217);
        internal static readonly Color Green = Color.FromArgb(194, 245, 222);
        internal static readonly Color GreenBackgroundInactive = Color.FromArgb(217, 217, 217);
        internal static readonly Color Red = Color.FromArgb(255, 204, 232);
        internal static readonly Color Yellow = Color.LightYellow;
        internal static readonly Color YellowSlightly = Color.Azure;
    }
}