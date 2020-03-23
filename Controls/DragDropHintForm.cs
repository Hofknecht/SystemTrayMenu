using System;
using System.Windows.Forms;

namespace SystemTrayMenu.Controls
{
    public partial class DragDropHintForm : Form
    {
        public DragDropHintForm(string hintTitle, string hintText,
            string buttonOk)
        {
            InitializeComponent();
            Text = hintTitle;
            labelHint.Text = hintText;
            this.buttonOk.Text = buttonOk;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
