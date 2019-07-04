using System.Drawing;
using System.Windows.Forms;

namespace SystemTrayMenu.Helper
{
    public class ScreenMouse
    {
        public static Screen GetScreen()
        {
            return Screen.PrimaryScreen;
            // Maybe we need for later feature
            // Show on mouse position
            //return GetScreenFromMousePosition(
            //    Cursor.Position.X, Cursor.Position.Y);
        }

        //public static Screen GetScreenFromMousePosition(int x, int y)
        //{
        //    Screen clickedScreen = null;
        //    foreach (Screen screen in Screen.AllScreens)
        //    {
        //        if (screen.Bounds.Contains(new Point(x, y)))
        //        {
        //            clickedScreen = screen;
        //        }
        //    }
        //    return clickedScreen;
        //}
    }
}
