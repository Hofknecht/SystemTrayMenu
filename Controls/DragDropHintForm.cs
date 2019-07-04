using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTrayMenu.Controls
{
    public partial class DragDropHintForm : Form
    {
        public DragDropHintForm(string hintTitle, string hintText, 
            string buttonOk)
        {
            InitializeComponent();
            this.Text = hintTitle;
            this.labelHint.Text = hintText;
            this.buttonOk.Text = buttonOk;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
