// <copyright file="MenuDefines.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System.Drawing;

    internal static class MenuDefines
    {
        internal const int Scrollspeed = 4;
        internal const int MenusMax = 50;
        internal const int LengthMax = 37;
        internal static readonly Color File = Color.White;
        internal static readonly Color Folder = Color.White;

        public static Color ColorSelectedItem
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeSeleceted;
                }
                else
                {
                    return AppColors.Selected;
                }
            }
        }

        public static Color ColorSelectedItemBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeSelectedBorder;
                }
                else
                {
                    return AppColors.SelectedBorder;
                }
            }
        }

        public static Color ColorOpenFolder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeOpenMenu;
                }
                else
                {
                    return AppColors.OpenMenu;
                }
            }
        }

        public static Color ColorOpenFolderBorder
        {
            get
            {
                if (Config.IsDarkMode())
                {
                    return AppColors.DarkModeOpenMenuBorder;
                }
                else
                {
                    return AppColors.OpenMenuBorder;
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
                    return AppColors.DarkModeSeleceted;
                }
                else
                {
                    return AppColors.Selected;
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