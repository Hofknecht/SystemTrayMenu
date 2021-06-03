// <copyright file="MenuDefines.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Drawing;

    internal static class MenuDefines
    {
        internal const int MenusMax = 50;
        internal const int LengthMax = 37;
        internal const int Scrollspeed = 3;

        public static Color ColorSelectedItem
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeSelecetedItem;
                }
                else
                {
                    return AppColors.SelectedItem;
                }
            }
        }

        public static Color ColorSelectedItemBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeSelectedItemBorder;
                }
                else
                {
                    return AppColors.SelectedItemBorder;
                }
            }
        }

        public static Color ColorOpenFolder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeOpenFolder;
                }
                else
                {
                    return AppColors.OpenFolder;
                }
            }
        }

        public static Color ColorOpenFolderBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeOpenFolderBorder;
                }
                else
                {
                    return AppColors.OpenFolderBorder;
                }
            }
        }

        public static Color ColorTitleWarning
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeWarning;
                }
                else
                {
                    return AppColors.Warning;
                }
            }
        }

        public static Color ColorTitleSelected
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeSelecetedItem;
                }
                else
                {
                    return AppColors.SelectedItem;
                }
            }
        }

        public static Color ColorTitleBackground
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeTitle;
                }
                else
                {
                    return AppColors.Title;
                }
            }
        }
    }
}