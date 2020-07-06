using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SystemTrayMenu.DataClasses;
using SystemTrayMenu.DllImports;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.UserInterface
{
    internal partial class Menu : Form
    {
        internal new event EventHandlerEmpty MouseWheel;
        internal new event EventHandlerEmpty MouseEnter;
        internal new event EventHandlerEmpty MouseLeave;
        internal event EventHandlerEmpty UserClickedOpenFolder;
        internal event EventHandler<Keys> CmdKeyProcessed;
        internal event EventHandlerEmpty SearchTextChanging;
        internal event EventHandler SearchTextChanged;

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
                if (!IsDisposed && !Disposing)
                {
                    Opacity = newOpacity;
                }
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
#pragma warning disable CA1031 // Do not catch general exception types
                    catch (ObjectDisposedException)
#pragma warning restore CA1031 // Do not catch general exception types
                    {
                        Visible = false;
                        isShowing = false;
                        Log.Info($"Could not open menu, old menu was disposing," +
                            $" IsDisposed={IsDisposed}");
                    }

                    if (Visible)
                    {
                        Activate();
                        textBoxSearch.Focus();
                        NativeMethods.User32ShowInactiveTopmost(this);
                        NativeMethods.ForceForegroundWindow(Handle);
                        SetTitleColorActive();
                    }
                }
                else
                {
                    NativeMethods.User32ShowInactiveTopmost(this);
                    textBoxSearch.Focus();
                }
            }
            fading.Hide += Hide;

            InitializeComponent();
            pictureBoxSearch.Paint += PictureBoxSearch_Paint;
            void PictureBoxSearch_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawIcon(Properties.Resources.search2,
                    new Rectangle(0, 0, pictureBoxSearch.Width, pictureBoxSearch.Height));
            }
            SetDoubleBuffer(dgv, true);

            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = MenuDefines.ColorSelectedItem,
                SelectionForeColor = Color.Black
            };
            dgv.DefaultCellStyle = dgvCellStyle;

            VScrollBar scrollBar = dgv.Controls.OfType<VScrollBar>().First();
            scrollBar.MouseWheel += DgvMouseWheel;
            scrollBar.MouseEnter += ControlsMouseEnter;
            dgv.MouseEnter += ControlsMouseEnter;
            labelTitle.MouseEnter += ControlsMouseEnter;
            void ControlsMouseEnter(object sender, EventArgs e)
            {
                MouseEnter?.Invoke();
            }
            scrollBar.MouseLeave += ControlsMouseLeave;
            dgv.MouseLeave += ControlsMouseLeave;
            labelTitle.MouseLeave += ControlsMouseLeave;
            void ControlsMouseLeave(object sender, EventArgs e)
            {
                MouseLeave?.Invoke();
            }
        }

        internal void FocusTextBox()
        {
            textBoxSearch.Focus();
        }

        private static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, ctl, new object[] { DoubleBuffered },
                CultureInfo.InvariantCulture);
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
                    pictureBoxSearch.Visible = false;
                    textBoxSearch.Visible = false;
                    tableLayoutPanelSearch.Visible = false;
                    break;
                case MenuType.NoAccess:
                    SetTitle(Translator.GetText("Folder inaccessible"));
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    pictureBoxSearch.Visible = false;
                    textBoxSearch.Visible = false;
                    tableLayoutPanelSearch.Visible = false;
                    break;
                case MenuType.MaxReached:
                    SetTitle($"Max {MenuDefines.MenusMax - 1} Menus");
                    labelTitle.BackColor = MenuDefines.ColorTitleWarning;
                    pictureBoxSearch.Visible = false;
                    textBoxSearch.Visible = false;
                    tableLayoutPanelSearch.Visible = false;
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
            if (!isShowing)
            {
                fading.Fade(Fading.FadingState.Hide);
            }
        }

        internal void AdjustSizeAndLocation(int screenHeight,
            int screenRight, int taskbarHeight,
            Menu menuPredecessor = null,
            bool directionToRight = false)
        {
            CheckForAutoResizeRowDone();
            void CheckForAutoResizeRowDone()
            {
                double factor = 1;
                if (NativeMethods.IsTouchEnabled())
                {
                    factor = 1.5;
                }

                if (menuPredecessor == null)
                {
                    if (dgv.Tag == null && dgv.Rows.Count > 0)
                    {
                        dgv.AutoResizeRows();
                        dgv.RowTemplate.Height = (int)(dgv.Rows[0].Height * factor);
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            row.Height = dgv.RowTemplate.Height;
                        }
                        dgv.Tag = true;
                    }
                }
                else
                {
                    dgv.RowTemplate.Height = menuPredecessor.GetDataGridView().
                        RowTemplate.Height;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        row.Height = dgv.RowTemplate.Height;
                    }
                    dgv.Tag = true;
                }
            }

            int dgvHeightNeeded = dgv.Rows.GetRowsHeight(
                DataGridViewElementStates.None);
            int menuRestNeeded = Height - dgv.Height;

            int dgvHeightMax = screenHeight - taskbarHeight -
                menuRestNeeded;

            if (dgvHeightNeeded > dgvHeightMax)
            {
                dgvHeightNeeded = dgvHeightMax;
            }

            DataTable data = (DataTable)dgv.DataSource;
            if (string.IsNullOrEmpty(data.DefaultView.RowFilter))
            {
                dgv.Height = dgvHeightNeeded;
            }

            AdjustDataGridViewWidth();

            int x;
            if (menuPredecessor == null)
            {
                x = screenRight - Width;
            }
            else
            {
                if (directionToRight)
                {
                    x = menuPredecessor.Location.X +
                        menuPredecessor.Width -
                        (int)Math.Round(Scaling.Factor, 0,
                        MidpointRounding.AwayFromZero);
                }
                else
                {
                    x = menuPredecessor.Location.X -
                        Width +
                        (int)Math.Round(Scaling.Factor, 0,
                        MidpointRounding.AwayFromZero);
                }
            }

            if (x < 0)
            {
                x += menuPredecessor.Width;
                x += Width;
            }

            int y;
            if (menuPredecessor == null)
            {
                y = screenHeight - taskbarHeight - Height;
            }
            else
            {
                RowData trigger = (RowData)Tag;
                DataGridView dgv = menuPredecessor.GetDataGridView();
                int distanceFromItemToDgvTop = 0;
                if (dgv.Rows.Count > trigger.RowIndex)
                {
                    Rectangle cellRectangle = dgv.GetCellDisplayRectangle(
                        0, trigger.RowIndex, false);
                    distanceFromItemToDgvTop = cellRectangle.Top;
                }
                y = menuPredecessor.Location.Y +
                    menuPredecessor.dgv.Location.Y +
                    distanceFromItemToDgvTop;
                if ((y + Height - tableLayoutPanelSearch.Height) > dgvHeightMax)
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

            if (labelTitle.Width > newWidth)
            {
                dgv.Width = labelTitle.Width;
                dgv.Columns[1].Width = labelTitle.Width - dgv.Columns[0].Width;
            }
            else
            {
                dgv.Width = newWidth;
            }

            //Only scaling correct with Sans Serif for textBoxSearch. Workaround:
            textBoxSearch.Font = new Font("Segoe UI", 8.25F * Scaling.Factor,
                FontStyle.Regular, GraphicsUnit.Point, 0);

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

        private void DgvMouseWheel(object sender, MouseEventArgs e)
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

            MouseWheel?.Invoke();
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
                case Keys.Control | Keys.F:
                case Keys.Tab:
                case Keys.Tab | Keys.Shift:
                case Keys.Apps:
                    CmdKeyProcessed.Invoke(this, keys);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keys);
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable data = (DataTable)dgv.DataSource;
            string filterField = dgv.Columns[1].Name;
            SearchTextChanging?.Invoke();

            data.DefaultView.RowFilter = string.Format(CultureInfo.InvariantCulture,
                "[{0}] LIKE '%{1}%'", filterField, textBoxSearch.Text);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;
                rowData.RowIndex = row.Index;
            }

            SearchTextChanged.Invoke(this, null);
        }

        internal void KeyPressedSearch(string letter)
        {
            textBoxSearch.Text += letter;
            textBoxSearch.SelectionStart = textBoxSearch.Text.Length;
            textBoxSearch.SelectionLength = 0;
            textBoxSearch.Focus();
        }
    }
}