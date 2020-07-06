// <copyright file="MenuDefines.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Drawing;
    using System.Reflection;
    internal static class MenuDefines
    {
        internal static string NotifyIconText = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        internal static readonly Color File = Color.White;
        internal static readonly Color Folder = Color.White;
        internal static readonly Color ColorSelectedItem = AppColors.Blue;
        internal static readonly Color ColorSelectedItemBorder = AppColors.BlueBorder;
        internal static readonly Color ColorOpenFolder = AppColors.Green;
        internal static readonly Color ColorOpenFolderBorder = AppColors.GreenBorder;
        internal static readonly Color ColorTitleWarning = AppColors.Red;
        internal static readonly Color ColorTitleSelected = AppColors.Yellow;
        internal static readonly Color ColorTitleBackground = AppColors.Azure;
        internal const int Scrollspeed = 4;
        internal const int TimeUntilClose = 1000;
        internal const int MenusMax = 50;
        internal const int LengthMax = 37;
        internal static float MaxMenuWidth = 300;
    }

    internal static class AppColors
    {
        internal static readonly Color Blue = Color.FromArgb(204, 232, 255);
        internal static readonly Color BlueBorder = Color.FromArgb(153, 209, 255);
        internal static readonly Color Green = Color.FromArgb(194, 245, 222);
        internal static readonly Color GreenBorder = Color.FromArgb(153, 255, 165);
        internal static readonly Color Red = Color.FromArgb(255, 204, 232);
        internal static readonly Color Yellow = Color.LightYellow;
        internal static readonly Color Azure = Color.Azure;
    }
}