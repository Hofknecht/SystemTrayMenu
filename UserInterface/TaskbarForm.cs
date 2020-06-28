using System.Drawing;
using System.Windows.Forms;

namespace SystemTrayMenu.UserInterface
{
    public partial class TaskbarForm : Form
    {
        public TaskbarForm()
        {
            InitializeComponent();
            SetLocation();
        }

        private void TaskbarForm_LocationChanged(object sender, System.EventArgs e)
        {
            SetLocation();
        }

        private void SetLocation()
        {
            Screen screen = Screen.PrimaryScreen;
            Location = new Point(screen.Bounds.Right - Size.Width,
            screen.Bounds.Bottom + 80); //Hide below taskbar
        }
    }
}
