using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SystemTrayMenu.Controls;
using SystemTrayMenu.Helper;

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
            NoAccess,
            MaxReached
        }

        public bool IsFadingIn => FadeForm.IsFadingIn;

        public bool IsFadingOut => FadeForm.IsFadingOut;

        public int Level = 0;
        private readonly FadeForm FadeForm = null;
        private bool autoResizeRowsDone = false;

        public enum MenuType { Default, DisposedFake };

        public Menu(MenuType menuType = MenuType.Default)
        {
            FadeForm = new FadeForm(this);
            InitializeComponent();
            SetDoubleBuffer(dgv, true);

            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = MenuDefines.ColorSelectedItem,
                SelectionForeColor = Color.Black
            };
            dgv.DefaultCellStyle = dgvCellStyle;

            VScrollBar scrollBar = dgv.Controls.OfType<VScrollBar>().First();
            scrollBar.MouseWheel += dgv_MouseWheel;

            if (menuType == MenuType.DisposedFake)
            {
                Dispose();
            }
        }

        private static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
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
        public void SetTypeNoAccess()
        {
            SetType(Type.NoAccess);
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
                    SetTitle(Language.Translate("Folder empty"));
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    break;
                case Type.NoAccess:
                    SetTitle(Language.Translate("Folder inaccessible"));
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    break;
                case Type.MaxReached:
                    SetTitle($"Max {MenuDefines.MenusMax - 1} Menus");
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
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
            int height = dgv.Rows.GetRowsHeight(states);
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

        public void AdjustLocationAndSize(int heightMax, Menu menuPredecessor)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            if (!autoResizeRowsDone)
            {
                autoResizeRowsDone = true;
                this.dgv.AutoResizeRows();
            }
            int height = this.dgv.Rows.GetRowsHeight(states);
            if (height > heightMax)
            {
                height = heightMax;
            }
            this.dgv.Height = height;

            AdjustDataGridViewSize();
            int x = menuPredecessor.Location.X - Width +
                (int)Math.Round(Scaling.Factor, 0,
                MidpointRounding.AwayFromZero);

            RowData trigger = (RowData)Tag;
            DataGridView dgv = menuPredecessor.GetDataGridView();
            if (dgv.Rows.Count > trigger.RowIndex)
            {
                Rectangle cellRectangle = dgv.GetCellDisplayRectangle(
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
            //dgv.AutoResizeColumns(); //AutoResizeColumns slow ~45ms
            DataGridViewExtensions.FastAutoSizeColumns(dgv);

            bool scrollbarShown = false;
            foreach (VScrollBar scroll in dgv.Controls.OfType<VScrollBar>())
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

            MouseWheel.Invoke();
        }

        private void Menu_Deactivate(object sender, EventArgs e)
        {
            Deactivated?.Invoke();
        }

        public void SetTitleColorDeactive()
        {
            labelTitle.ForeColor = Color.LightGray;
        }

        public void SetTitleColorActive()
        {
            labelTitle.ForeColor = Color.Black;
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
            labelTitle.BackColor = MenuDefines.ColorTitleSelected;
        }

        private void LabelTitle_MouseLeave(object sender, EventArgs e)
        {
            labelTitle.BackColor = MenuDefines.ColorTitleBackground;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
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

    /// <summary>
    /// Workaround class for "Clipboard" issue on .Net Windows Forms Label (https://github.com/Hofknecht/SystemTrayMenu/issues/5)
    /// On Label MouseDoubleClick the framework will copy the title text into the clipboard.
    /// We avoid this by overriding the Text atrribute and use own _text attribute.
    /// Text will remain unset and clipboard copy will not take place but it is still possible to get/set Text attribute as usual from outside.
    /// (see: https://stackoverflow.com/questions/2519587/is-there-any-way-to-disable-the-double-click-to-copy-functionality-of-a-net-l)
    /// 
    /// Note: When you have trouble with the Visual Studio Designer not showing the GUI properly, simply build once and reopen the Designer.
    /// This will place the required files into the Designer's cache and becomes able to show the GUI as usual.
    /// </summary>
    public class LabelNoCopy : Label
    {
        private string _text;
        public override string Text
        {
            get => _text;
            set
            {
                if (value == null)
                {
                    value = "";
                }

                if (_text != value)
                {
                    _text = value;
                    Refresh();
                    OnTextChanged(EventArgs.Empty);
                }
            }
        }
    }
}