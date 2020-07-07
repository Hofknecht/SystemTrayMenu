// <copyright file="MenuDefines.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Drawing;

    internal static class MenuDefines
    {
        internal const int Scrollspeed = 4;
        internal const int TimeUntilClose = 1000;
        internal const int MenusMax = 50;
        internal const int LengthMax = 37;
        internal const float MaxMenuWidth = 300;
        internal static readonly Color File = Color.White;
        internal static readonly Color Folder = Color.White;
        internal static readonly Color ColorSelectedItem = AppColors.Blue;
        internal static readonly Color ColorSelectedItemBorder = AppColors.BlueBorder;
        internal static readonly Color ColorOpenFolder = AppColors.Green;
        internal static readonly Color ColorOpenFolderBorder = AppColors.GreenBorder;
        internal static readonly Color ColorTitleWarning = AppColors.Red;
        internal static readonly Color ColorTitleSelected = AppColors.Yellow;
        internal static readonly Color ColorTitleBackground = AppColors.Azure;
    }
}