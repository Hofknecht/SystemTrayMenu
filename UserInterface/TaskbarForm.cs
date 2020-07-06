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
            SetLocation();
        }

        private void TaskbarForm_LocationChanged(object sender, System.EventArgs e)
        {
            SetLocation();
        }

        private void SetLocation()
        {
            Screen screen = Screen.PrimaryScreen;
            Location = new Point(
                screen.Bounds.Right - Size.Width,
                screen.Bounds.Bottom + 80); // Hide below taskbar
        }
    }
}
