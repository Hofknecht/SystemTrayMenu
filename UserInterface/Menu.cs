// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
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

    internal partial class Menu : Form
    {
        private readonly Fading fading = new Fading();
        private bool isShowing = false;
        private bool directionToRight = false;

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
                e.Graphics.DrawIcon(
                    Properties.Resources.search2,
                    new Rectangle(0, 0, pictureBoxSearch.Width, pictureBoxSearch.Height));
            }

            SetDoubleBuffer(dgv, true);

            Color foreColor = Color.Black;
            Color backColor = Color.White;
            if (Config.IsDarkMode())
            {
                foreColor = Color.White;
                labelTitle.ForeColor = foreColor;
                labelTitle.BackColor = AppColors.DarkModeBackColor1;

                backColor = AppColors.DarkModeBackColor2;
                tableLayoutPanel.BackColor = backColor;
                dgv.BackgroundColor = backColor;

                textBoxSearch.ForeColor = foreColor;
                textBoxSearch.BackColor = AppColors.DarkModeBackColor3;
                pictureBoxSearch.BackColor = AppColors.DarkModeBackColor3;
                tableLayoutPanelSearch.BackColor = AppColors.DarkModeBackColor3;
            }

            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle
            {
                SelectionForeColor = foreColor,
                ForeColor = foreColor,
                BackColor = backColor,
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

        internal new event EventHandlerEmpty MouseWheel;

        internal new event EventHandlerEmpty MouseEnter;

        internal new event EventHandlerEmpty MouseLeave;

        internal event EventHandlerEmpty UserClickedOpenFolder;

        internal event EventHandler<Keys> CmdKeyProcessed;

        internal event EventHandlerEmpty SearchTextChanging;

        internal event EventHandler SearchTextChanged;

        internal enum MenuType
        {
            Main,
            Sub,
            Empty,
            NoAccess,
            MaxReached,
        }

        internal enum StartLocation
        {
            Predecessor,
            BottomLeft,
            BottomRight,
            TopRight,
        }

        internal int Level { get; set; } = 0;

        internal bool IsUsable => Visible && !fading.IsHiding &&
            !IsDisposed && !Disposing;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createparams = base.CreateParams;
                createparams.ExStyle |= 0x80;
                return createparams;
            }
        }

        internal void FocusTextBox()
        {
            textBoxSearch.Focus();
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

        /// <summary>
        /// Update the position and size of the menu.
        /// </summary>
        /// <param name="bounds">Screen coordinates where the menu is allowed to be drawn in.</param>
        /// <param name="menuPredecessor">Predecessor menu (when available).</param>
        /// <param name="startLocation">Defines where the first menu is drawn (when no predecessor is set).</param>
        internal void AdjustSizeAndLocation(
            Rectangle bounds,
            Menu menuPredecessor,
            StartLocation startLocation)
        {
            if (menuPredecessor != null)
            {
                // Ignore start as we use predecessor
                startLocation = StartLocation.Predecessor;
            }

            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();

            // Calculate X position
            int x;
            switch (startLocation)
            {
                case StartLocation.Predecessor:
                    int scaling = (int)Math.Round(Scaling.Factor, 0, MidpointRounding.AwayFromZero);
                    directionToRight = menuPredecessor.directionToRight; // try keeping same direction
                    if (directionToRight)
                    {
                        x = menuPredecessor.Location.X + menuPredecessor.Width - scaling;

                        // Change direction when out of bounds
                        if (bounds.X + bounds.Width <= x + Width - scaling)
                        {
                            x = menuPredecessor.Location.X - Width + scaling;
                            directionToRight = !directionToRight;
                        }
                    }
                    else
                    {
                        x = menuPredecessor.Location.X - Width + scaling;

                        // Change direction when out of bounds
                        if (x < bounds.X)
                        {
                            x = menuPredecessor.Location.X + menuPredecessor.Width - scaling;
                            directionToRight = !directionToRight;
                        }
                    }

                    break;
                case StartLocation.BottomLeft:
                    x = bounds.X;
                    directionToRight = true;
                    break;
                case StartLocation.TopRight:
                case StartLocation.BottomRight:
                default:
                    x = bounds.Width - Width;
                    directionToRight = false;
                    break;
            }

            // Calculate Y position
            int y;
            switch (startLocation)
            {
                case StartLocation.Predecessor:
                    RowData trigger = (RowData)Tag;
                    DataGridView dgv = menuPredecessor.GetDataGridView();
                    int distanceFromItemToDgvTop = 0;

                    // Get offset of selected row from predecessor
                    if (dgv.Rows.Count > trigger.RowIndex)
                    {
                        Rectangle cellRectangle = dgv.GetCellDisplayRectangle(0, trigger.RowIndex, false);
                        distanceFromItemToDgvTop = cellRectangle.Top;
                    }

                    // Set position on same height as the selected row from predecessor
                    y = menuPredecessor.Location.Y + menuPredecessor.dgv.Location.Y + distanceFromItemToDgvTop;

                    // Move vertically when out of bounds
                    if (bounds.Y + bounds.Height < y + Height)
                    {
                        y = bounds.Y + bounds.Height - Height;
                    }

                    break;
                case StartLocation.TopRight:
                    y = bounds.Y;
                    break;
                case StartLocation.BottomLeft:
                case StartLocation.BottomRight:
                default:
                    y = bounds.Height - Height;
                    break;
            }

            // Update position
            Location = new Point(x, y);
        }

        internal void KeyPressedSearch(string letter)
        {
            textBoxSearch.Text += letter;
            textBoxSearch.SelectionStart = textBoxSearch.Text.Length;
            textBoxSearch.SelectionLength = 0;
            textBoxSearch.Focus();
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

        private static void SetDoubleBuffer(Control ctl, bool doubleBuffered)
        {
            typeof(Control).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                ctl,
                new object[] { doubleBuffered },
                CultureInfo.InvariantCulture);
        }

        private void AdjustDataGridViewHeight(Menu menuPredecessor, int screenHeightMax)
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
                    // Find row size based on content and apply factor
                    dgv.AutoResizeRows();
                    dgv.RowTemplate.Height = (int)(dgv.Rows[0].Height * factor);
                    dgv.Tag = true;
                }
            }
            else
            {
                // Take over the height from predecessor menu
                dgv.RowTemplate.Height = menuPredecessor.GetDataGridView().RowTemplate.Height;
                dgv.Tag = true;
            }

            // Patch size of each row
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = dgv.RowTemplate.Height;
            }

            DataTable data = (DataTable)dgv.DataSource;
            if (string.IsNullOrEmpty(data.DefaultView.RowFilter))
            {
                int dgvHeight = dgv.Rows.GetRowsHeight(DataGridViewElementStates.None); // Height of all rows
                int dgvHeightMax = screenHeightMax - (Height - dgv.Height); // except dgv
                if (dgvHeight > dgvHeightMax)
                {
                    // Make all rows fit into the screen
                    dgvHeight = dgvHeightMax;
                }

                dgv.Height = dgvHeight;
            }
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

            // Only scaling correct with Sans Serif for textBoxSearch. Workaround:
            textBoxSearch.Font = new Font(
                "Segoe UI",
                8.25F * Scaling.Factor,
                FontStyle.Regular,
                GraphicsUnit.Point,
                0);

            // Ancor not working like in the label
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

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable data = (DataTable)dgv.DataSource;
            string filterField = dgv.Columns[1].Name;
            SearchTextChanging?.Invoke();

            data.DefaultView.RowFilter = string.Format(
                CultureInfo.InvariantCulture,
                "[{0}] LIKE '%{1}%'",
                filterField,
                textBoxSearch.Text);

            if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                data.DefaultView.Sort = string.Empty;
            }
            else
            {
                string columnSortIndex = "SortIndex";

                foreach (DataRow row in data.Rows)
                {
                    if (row[1].ToString().StartsWith(
                        textBoxSearch.Text,
                        StringComparison.InvariantCultureIgnoreCase))
                    {
                        row[columnSortIndex] = 0;
                    }
                    else
                    {
                        row[columnSortIndex] = 1;
                    }
                }

                data.DefaultView.Sort = columnSortIndex;
            }

            SearchTextChanged.Invoke(this, null);
        }
    }
}