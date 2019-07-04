using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SystemTrayMenu.Controls;

namespace SystemTrayMenu
{
    public partial class Menu : Form, IDisposable
    {
        public new event EventHandler MouseWheel;
        public event EventHandler Deactivated;
        public event EventHandler UserClickedOpenFolder;

        public event Action<Keys> CmdKeyProcessed;

        public enum Type
        {
            Main,
            Sub,
            Empty,
            MaxReached
        }

        public bool IsFadingIn
        {
            get
            {
                return FadeForm.IsFadingIn;
            }
        }

        public bool IsFadingOut
        {
            get
            {
                return FadeForm.IsFadingOut;
            }
        }

        public int Level = 0;
        FadeForm FadeForm = null;

        public Menu()
        {
            FadeForm = new FadeForm(this);
            InitializeComponent();
            SetDoubleBuffer(dgv, true);

            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle();
            dgvCellStyle.SelectionBackColor = MenuDefines.FileHover;
            dgvCellStyle.SelectionForeColor = Color.Black;
            this.dgv.DefaultCellStyle = dgvCellStyle;
        }

        static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, ctl, new object[] { DoubleBuffered });
        }

        public void SetTypeSub()
        {
            SetType(Type.Sub);
        }
        public void SetTypeEmpty()
        {
            SetType(Type.Empty);
        }

        public void SetType(Type type)
        {
            switch (type)
            {
                case Type.Sub:
                    if (!labelTitle.IsDisposed)
                    {
                        labelTitle.Dispose();
                    }
                    break;
                case Type.Empty:
                    SetTitle(Program.Translate("Folder empty"));
                    labelTitle.BackColor = MenuDefines.Background;
                    break;
                case Type.MaxReached:
                    SetTitle($"Max {MenuDefines.MenusMax - 1} Menus");
                    labelTitle.BackColor = MenuDefines.Background;
                    break;
                case Type.Main:
                    break;
                default:
                    break;
            }
        }

        public bool IsVisible()
        {
            return Visible;
        }

        public bool IsActive(Form activeForm)
        {
            bool isActive = (this == activeForm);
            return isActive;
        }

        public bool IsMouseOn(Point mousePosition)
        {
            bool isMouseOn = Visible && Opacity >= MenuDefines.OpacityHalfValue
                && ClientRectangle.Contains(
                  PointToClient(mousePosition));
            return isMouseOn;
        }

        public DataGridView GetDataGridView()
        {
            return dgv;
        }

        public void SetTitle(string title)
        {
            if (title.Length > MenuDefines.LengthMax)
            {
                title = $"{title.Substring(0, MenuDefines.LengthMax)}...";
            }
            labelTitle.Text = title;
        }

        public void FadeIn()
        {
            FadeForm.FadeIn();
        }

        public void FadeHalf()
        {
            FadeForm.FadeHalf();
        }

        public void FadeOut()
        {
            FadeForm.FadeOut();
        }

        public void AdjustLocationAndSize(Screen screen)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgv.AutoResizeRows();
            int height =  (int)(dgv.Rows.GetRowsHeight(states));
            int heightMax = screen.Bounds.Height - 
                new Taskbar().Size.Height - 
                labelTitle.Height;
            if (height > heightMax)
            {
                height = heightMax;
            }
            dgv.Height = height;
            AdjustDataGridViewSize();
            int x = screen.Bounds.Right - Width;
            int y = heightMax - Height + labelTitle.Height;

            Location = new Point(x, y);
        }

        public void AdjustLocationAndSize(int heightMax, int widthPredecessors,
            Menu menuPredecessor)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            this.dgv.AutoResizeRows();
            int height = this.dgv.Rows.GetRowsHeight(states);
            if (height > heightMax)
            {
                height = heightMax;
            }
            this.dgv.Height = height;

            AdjustDataGridViewSize();
            int x = menuPredecessor.Location.X - Width + 
                (int)Math.Round(Program.ScalingFactor, 0, 
                MidpointRounding.AwayFromZero);

            RowData trigger = (RowData)Tag;
            DataGridView dgv = menuPredecessor.GetDataGridView();
            if (dgv.Rows.Count > trigger.RowIndex)
            {
                var cellRectangle = dgv.GetCellDisplayRectangle(
                    0, trigger.RowIndex, false);
                int y = menuPredecessor.Location.Y +
                    menuPredecessor.dgv.Location.Y +
                    cellRectangle.Top;
                if ((y + Height) > heightMax)
                {
                    y = heightMax - Height;
                }

                Location = new Point(x, y);
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgv.AutoResizeColumns();
            bool scrollbarShown = false;
            foreach (var scroll in dgv.Controls.OfType<VScrollBar>())
            {
                if (scroll.Visible)
                {
                    scroll.Width = 120;
                    scrollbarShown = true;
                }
            }
            int newWidth = dgv.Columns[0].Width + dgv.Columns[1].Width;
            if (scrollbarShown)
            {
                newWidth += SystemInformation.VerticalScrollBarWidth;
            }
            dgv.Width = newWidth;
        }

        private void dgv_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            int scrollspeed = MenuDefines.Scrollspeed;
            if (e.Delta < 0)
            {
                if (dgv.FirstDisplayedScrollingRowIndex < dgv.Rows.Count - scrollspeed)
                {
                    dgv.FirstDisplayedScrollingRowIndex += scrollspeed;
                }
                else
                {
                    dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
                }
            }
            else
            {
                if (dgv.FirstDisplayedScrollingRowIndex > 0 + scrollspeed)
                {
                    dgv.FirstDisplayedScrollingRowIndex -= scrollspeed;
                }
                else
                {
                    dgv.FirstDisplayedScrollingRowIndex = 0;
                }
            }

            dgv.PerformLayout();
            MouseWheel.Invoke();
        }

        private void Menu_Deactivate(object sender, EventArgs e)
        {
            Deactivated?.Invoke();
        }

        public void SetTitleColorDeactive()
        {
            this.labelTitle.ForeColor = Color.LightGray;
        }

        public void SetTitleColorActive()
        {
            this.labelTitle.ForeColor = Color.Black;
        }

        private void LabelTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserClickedOpenFolder?.Invoke();
            }
        }

        private void LabelTitle_MouseEnter(object sender, EventArgs e)
        {
            this.labelTitle.BackColor = MenuDefines.FileHover;
        }

        private void LabelTitle_MouseLeave(object sender, EventArgs e)
        {
            this.labelTitle.BackColor = MenuDefines.Background;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            switch (keys)
            {
                case Keys.Enter:
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Escape:
                    CmdKeyProcessed.Invoke(keys);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keys);
        }
    }
}