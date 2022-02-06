// <copyright file="TaskbarForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TaskbarForm : Form
    {
        public TaskbarForm()
        {
            InitializeComponent();
            Icon = Config.GetAppIcon();
            MaximumSize = new Size(10, 1);
            // Opacity = 0.01f;
            // (otherwise: Task View causes Explorer restart when SystemTrayMenu is open #299)
            SetLocation();
        }

        private void TaskbarForm_LocationChanged(object sender, System.EventArgs e)
        {
            SetLocation();
        }

        /// <summary>
        /// Hide below taskbar.
        /// </summary>
        private void SetLocation()
        {
            Screen screen = Screen.PrimaryScreen;
            Location = new Point(
                screen.Bounds.Right - Size.Width,
                screen.Bounds.Bottom + 80);
        }
    }
}
