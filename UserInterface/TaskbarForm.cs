using System.Drawing;
using System.Windows.Forms;

namespace SystemTrayMenu.UserInterface
{
    public partial class TaskbarForm : Form
    {
        public TaskbarForm()
        {
            InitializeComponent();
            
            //Hide the form under the taskbar of primary screen
            Screen screen = Screen.PrimaryScreen;
            Location = new Point(screen.Bounds.Right - 155,
                screen.Bounds.Bottom);
            //This would be above of taskbar
            //Location = new Point(screen.Bounds.Right - 155,
            //    screen.Bounds.Bottom - Height - 65);
        }
    }
}
