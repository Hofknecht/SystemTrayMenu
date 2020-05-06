using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SystemTrayMenu.DataClasses;
using SystemTrayMenu.DllImports;
using SystemTrayMenu.Helper;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.UserInterface
{
    internal partial class Menu : Form
    {
        internal new event EventHandlerEmpty MouseWheel;
        internal new event EventHandlerEmpty MouseEnter;
        internal new event EventHandlerEmpty MouseLeave;
        internal event EventHandlerEmpty UserClickedOpenFolder;
        internal event Action<Keys> CmdKeyProcessed;
#warning #68 => use event and not a action here?

        internal bool IsUsable => Visible && !fading.IsHiding &&
            !IsDisposed && !Disposing;

        internal enum MenuType
        {
            Main,
            Sub,
            Empty,
            NoAccess,
            MaxReached
        }

        internal int Level = 0;

        private readonly Fading fading = new Fading();
        private bool isShowing = false;

        internal Menu()
        {
            fading.ChangeOpacity += Fading_ChangeOpacity;
            void Fading_ChangeOpacity(object sender, double newOpacity)
            {
                Opacity = newOpacity;
            }
            fading.Show += Fading_Show;
            void Fading_Show()
            {
                if (Level == 0)
                {
                    try
                    {
                        isShowing = true;
                        Visible = true;
                        isShowing = false;
                    }
                    catch (ObjectDisposedException)
                    {
                        Visible = false;
                        isShowing = false;
                        Log.Info($"Could not open menu, old menu was disposing," +
                            $" IsDisposed={IsDisposed}");
                    }

                    if (Visible)
                    {
                        Activate();
                        NativeMethods.User32ShowInactiveTopmost(this);
                        NativeMethods.ForceForegroundWindow(Handle);
                        SetTitleColorActive();
                    }
                }
                else
                {
                    NativeMethods.User32ShowInactiveTopmost(this);
                }
            }
            fading.Hide += Hide;

            InitializeComponent();
            //pictureBoxSearch.Image = Bitmap.FromHicon(new Icon(
            //    Properties.Resources.search,new Size(
            //        pictureBoxSearch.Width,
            //        pictureBoxSearch.Height)).Handle);
            SetDoubleBuffer(dgv, true);

            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = MenuDefines.ColorSelectedItem,
                SelectionForeColor = Color.Black
            };
            dgv.DefaultCellStyle = dgvCellStyle;

            VScrollBar scrollBar = dgv.Controls.OfType<VScrollBar>().First();
            scrollBar.MouseWheel += dgv_MouseWheel;
            scrollBar.MouseEnter += ControlsMouseEnter;
            dgv.MouseEnter += ControlsMouseEnter;
            labelTitle.MouseEnter += ControlsMouseEnter;
            void ControlsMouseEnter(object sender, EventArgs e)
            {
                MouseEnter.Invoke();
            }
            scrollBar.MouseLeave += ControlsMouseLeave;
            dgv.MouseLeave += ControlsMouseLeave;
            labelTitle.MouseLeave += ControlsMouseLeave;
            void ControlsMouseLeave(object sender, EventArgs e)
            {
                MouseLeave.Invoke();
            }
        }

        private static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, ctl, new object[] { DoubleBuffered },
                System.Globalization.CultureInfo.InvariantCulture);
        }

        internal void SetTypeSub()
        {
            SetType(MenuType.Sub);
        }

        internal void SetTypeEmpty()
        {
            SetType(MenuType.Empty);
        }

        internal void SetTypeNoAccess()
        {
            SetType(MenuType.NoAccess);
        }

        internal void SetType(MenuType type)
        {
            switch (type)
            {
                case MenuType.Sub:
                    if (!labelTitle.IsDisposed)
                    {
                        labelTitle.Dispose();
                    }
                    break;
                case MenuType.Empty:
                    SetTitle(Translator.GetText("Folder empty"));
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    break;
                case MenuType.NoAccess:
                    SetTitle(Translator.GetText("Folder inaccessible"));
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    break;
                case MenuType.MaxReached:
                    SetTitle($"Max {MenuDefines.MenusMax - 1} Menus");
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    break;
                case MenuType.Main:
                    break;
                default:
                    break;
            }
        }

        internal bool IsMouseOn(Point mousePosition)
        {
            bool isMouseOn = Visible && ClientRectangle.Contains(
                  PointToClient(mousePosition));
            return isMouseOn;
        }

        internal DataGridView GetDataGridView()
        {
            return dgv;
        }

        internal void SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                if (title.Length > MenuDefines.LengthMax)
                {
                    title = $"{title.Substring(0, MenuDefines.LengthMax)}...";
                }
                labelTitle.Text = title;
            }
        }

        internal void ShowWithFadeOrTransparent(bool formActiveFormIsMenu)
        {
            if (formActiveFormIsMenu)
            {
                ShowWithFade();
            }
            else
            {
                ShowTransparent();
            }
        }

        internal void ShowWithFade()
        {
            fading.Fade(Fading.FadingState.Show);
        }

        internal void ShowTransparent()
        {
            fading.Fade(Fading.FadingState.ShowTransparent);
        }

        internal void HideWithFade()
        {
            if(!isShowing)
            {
                fading.Fade(Fading.FadingState.Hide);
            }
        }

        internal void AdjustSizeAndLocation(Menu menuPredecessor = null)
        {
            dgv.AutoResizeRows();

            int dgvHeightNeeded = dgv.Rows.GetRowsHeight(
                DataGridViewElementStates.None);
            int menuRestNeeded = Height - dgv.Height;

            int dgvHeightMax = Statics.ScreenHeight - Statics.TaskbarHeight -
                menuRestNeeded;

            if (dgvHeightNeeded > dgvHeightMax)
            {
                dgvHeightNeeded = dgvHeightMax;
            }
            dgv.Height = dgvHeightNeeded;

            AdjustDataGridViewWidth();

            int x;
            if (menuPredecessor == null)
            {
                x = Statics.ScreenRight - Width;
            }
            else
            {
                x = menuPredecessor.Location.X - Width +
                    (int)Math.Round(Scaling.Factor, 0,
                    MidpointRounding.AwayFromZero);
            }

            int y;
            if (menuPredecessor == null)
            {
                y = Statics.ScreenHeight - Statics.TaskbarHeight - Height;
            } 
            else
            {
                RowData trigger = (RowData)Tag;
                DataGridView dgv = menuPredecessor.GetDataGridView();

                Rectangle cellRectangle = dgv.GetCellDisplayRectangle(
                    0, trigger.RowIndex, false);
                y = menuPredecessor.Location.Y +
                    menuPredecessor.dgv.Location.Y +
                    cellRectangle.Top;
                if ((y + Height) > dgvHeightMax)
                {
                    y = dgvHeightMax - Height + menuRestNeeded;
                }
            }

            Location = new Point(x, y);
        }

        private void AdjustDataGridViewWidth()
        {
            DataGridViewExtensions.FastAutoSizeColumns(dgv);
            int newWidth = dgv.Columns[0].Width + dgv.Columns[1].Width;
            if (IsScrollbarShown())
            {
                newWidth += SystemInformation.VerticalScrollBarWidth;
            }
            dgv.Width = newWidth;

            //Only scaling correct with Sans Serif for textBoxSearch. Workaround:
            textBoxSearch.Font = new Font("Segoe UI", 8.25F * Scaling.Factor,
                FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            //Ancor not working like in the label
            textBoxSearch.Width = newWidth -
                pictureBoxSearch.Width -
                pictureBoxSearch.Margin.Horizontal -
                textBoxSearch.Margin.Horizontal;
        }

        private bool IsScrollbarShown()
        {
            bool isScrollbarShown = false;
            foreach (VScrollBar scroll in dgv.Controls.OfType<VScrollBar>())
            {
                if (scroll.Visible)
                {
                    isScrollbarShown = true;
                }
            }

            return isScrollbarShown;
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

        internal void SetTitleColorDeactive()
        {
            labelTitle.ForeColor = Color.LightGray;
        }

        internal void SetTitleColorActive()
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
}