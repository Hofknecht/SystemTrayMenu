using System.Drawing;

namespace SystemTrayMenu
{
    public static class MenuDefines
    {
        // windows explorer background white
        public static Color File = Color.White;
        public static Color Folder = Color.White;

        // windows explorer selected text
        public static Color FileHover = Color.FromArgb(204, 232, 255);

        // windows explorer highlighted text
        public static Color FolderOpen = Color.FromArgb(229, 243, 255);
        public static Color Background = Color.FromArgb(229, 243, 255);
        internal static Color KeyBoardSelection = Color.Yellow;
        internal static int KeySearchInterval = 1000;
        public const int MenuRowsHeight = 18;
        public const int LengthMax = 37;
        public const int ButtonTextPaddingLeft = 18;
        public const int ButtonTextPaddingRight= 12;

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
    }
}