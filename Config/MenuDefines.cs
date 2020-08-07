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

        public static Color ColorSelectedItem
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeBlue;
                }
                else
                {
                    return AppColors.Blue;
                }
            }
        }

        public static Color ColorSelectedItemBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeBlueBorder;
                }
                else
                {
                    return AppColors.BlueBorder;
                }
            }
        }

        public static Color ColorOpenFolder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeGreen;
                }
                else
                {
                    return AppColors.Green;
                }
            }
        }

        public static Color ColorOpenFolderBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeGreenBorder;
                }
                else
                {
                    return AppColors.GreenBorder;
                }
            }
        }

        public static Color ColorTitleWarning
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeRed;
                }
                else
                {
                    return AppColors.Red;
                }
            }
        }

        public static Color ColorTitleSelected
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeBlue;
                }
                else
                {
                    return AppColors.Blue;
                }
            }
        }

        public static Color ColorTitleBackground
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeAzure;
                }
                else
                {
                    return AppColors.Azure;
                }
            }
        }
    }
}