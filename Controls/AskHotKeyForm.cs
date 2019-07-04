using System;
using System.Windows.Forms;

namespace SystemTrayMenu.Controls
{
    public partial class AskHotKeyForm : Form
    {
        public string NewHotKey;

        public AskHotKeyForm()
        {
            InitializeComponent();
            this.Text = Program.Translate("Shortcut key");
            this.labelCaption.Text = $"{Program.Translate("Shortcut key")} " +
                $"{Program.Translate("(e.g. F12)")}";
            this.labelText.Text =
                Program.Translate("CTRL") + " + " +
                Program.Translate("ALT") + " + ?";

            this.buttonOk.Text = Program.Translate("buttonOk");
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            switch (keys)
            {
                case Keys.Space:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                case Keys.F13:
                case Keys.F14:
                case Keys.F15:
                case Keys.F16:
                case Keys.F17:
                case Keys.F18:
                case Keys.F19:
                case Keys.F20:
                case Keys.F21:
                case Keys.F22:
                case Keys.F23:
                case Keys.F24:
                    NewHotKey = keys.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.Back:
                case Keys.Delete:
                    NewHotKey = string.Empty;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keys);
        }
    }
}
