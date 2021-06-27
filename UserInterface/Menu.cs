// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Svg;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Utilities;

    internal partial class Menu : Form
    {
        private static readonly Icon Search = Properties.Resources.search;
        private readonly Fading fading = new Fading();
        private bool isShowing;
        private bool directionToRight;

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
                    if (Level == 0)
                    {
                        Activate();
                        textBoxSearch.Focus();
                        NativeMethods.User32ShowInactiveTopmost(this);
                        NativeMethods.ForceForegroundWindow(Handle);
                    }
                    else
                    {
                        NativeMethods.User32ShowInactiveTopmost(this);
                        textBoxSearch.Focus();
                    }
                }
            }

            fading.Hide += Hide;

            InitializeComponent();

            SetDoubleBuffer(dgv, true);

            Color foreColor = Color.Black;
            Color titleBackColor = AppColors.Title;
            Color backColor = AppColors.Background;
            Color backColorSearch = AppColors.SearchField;

            if (Config.IsDarkMode())
            {
                foreColor = Color.White;
                labelTitle.ForeColor = foreColor;
                textBoxSearch.ForeColor = foreColor;
                titleBackColor = AppColors.DarkModeTitle;
                backColor = AppColors.DarkModeBackground;
                backColorSearch = AppColors.DarkModeSearchField;
            }

            ColorConverter colorConverter = new ColorConverter();
            labelFoldersCount.ForeColor = (Color)colorConverter.ConvertFromString("#585858");
            labelFilesCount.ForeColor = (Color)colorConverter.ConvertFromString("#585858");

            if (backColor.R == 0)
            {
                backColor = Color.White;
            }

            tableLayoutPanelTitle.BackColor = titleBackColor;
            tableLayoutPanelDgvAndScrollbar.BackColor = backColor;
            dgv.BackgroundColor = backColor;
            textBoxSearch.BackColor = backColorSearch;
            pictureBoxSearch.BackColor = backColorSearch;
            pictureBoxFoldersCount.BackColor = backColorSearch;
            pictureBoxFilesCount.BackColor = backColorSearch;
            tableLayoutPanelSearch.BackColor = backColorSearch;
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                SelectionForeColor = foreColor,
                ForeColor = foreColor,
                BackColor = backColor,
            };

            customScrollbar.GotFocus += CustomScrollbar_GotFocus;
            void CustomScrollbar_GotFocus(object sender, EventArgs e)
            {
                textBoxSearch.Focus();
            }

            customScrollbar.Margin = new Padding(0);
            customScrollbar.Scroll += CustomScrollbar_Scroll;
            void CustomScrollbar_Scroll(object sender, EventArgs e)
            {
                decimal firstIndex = customScrollbar.Value * dgv.Rows.Count / (decimal)customScrollbar.Maximum;
                int firstIndexRounded = (int)Math.Ceiling(firstIndex);
                if (firstIndexRounded > -1 && firstIndexRounded < dgv.RowCount)
                {
                    dgv.FirstDisplayedScrollingRowIndex = firstIndexRounded;
                }
            }

            customScrollbar.MouseEnter += ControlsMouseEnter;
            dgv.MouseEnter += ControlsMouseEnter;
            labelTitle.MouseEnter += ControlsMouseEnter;
            void ControlsMouseEnter(object sender, EventArgs e)
            {
                MouseEnter?.Invoke();
            }

            customScrollbar.MouseLeave += ControlsMouseLeave;
            dgv.MouseLeave += ControlsMouseLeave;
            labelTitle.MouseLeave += ControlsMouseLeave;
            void ControlsMouseLeave(object sender, EventArgs e)
            {
                MouseLeave?.Invoke();
            }

            AllowDrop = true;
            DragEnter += DragDropHelper.DragEnter;
            DragDrop += DragDropHelper.DragDrop;
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

        internal int Level { get; set; }

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
            if (type != MenuType.Main)
            {
                pictureBoxMenuAlwaysOpen.Visible = false;
            }

            switch (type)
            {
                case MenuType.Sub:
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
            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();

            if (menuPredecessor != null)
            {
                // Ignore start as we use predecessor
                startLocation = StartLocation.Predecessor;
            }
            else if (Properties.Settings.Default.AppearAtMouseLocation)
            {
                // Do not adjust location again because Cursor.Postion changed
                if (Tag != null)
                {
                    return;
                }

                // Use this menu as predecessor and overwrite location with Cursor.Postion
                menuPredecessor = this;
                Tag = new RowData();
                Location = new Point(Cursor.Position.X, Cursor.Position.Y - labelTitle.Height);
                directionToRight = true;
                startLocation = StartLocation.Predecessor;
            }

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

            // X position for click, remove width of this menu as it is used as predecessor
            if (menuPredecessor == this && directionToRight)
            {
                x -= Width;
                directionToRight = false;
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

                    // when warning the title should appear in same height as selected row
                    if (!tableLayoutPanelSearch.Visible)
                    {
                        y += tableLayoutPanelTitle.Height;
                    }

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

        internal void AdjustScrollbar()
        {
            customScrollbar.Value = (int)Math.Round(
                dgv.FirstDisplayedScrollingRowIndex * (decimal)customScrollbar.Maximum / dgv.Rows.Count,
                0,
                MidpointRounding.AwayFromZero);
        }

        internal void SetCounts(int foldersCount, int filesCount)
        {
            labelFoldersCount.Text = foldersCount.ToString();
            labelFilesCount.Text = filesCount.ToString();
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
            int dgvHeightNew = dgv.Rows.GetRowsHeight(DataGridViewElementStates.None); // Height of all rows
            int dgvHeightMax = screenHeightMax - (Height - dgv.Height); // except dgv

            if (dgvHeightMax > Properties.Settings.Default.MaximumMenuHeight)
            {
                dgvHeightMax = Properties.Settings.Default.MaximumMenuHeight;
            }

            if (dgvHeightNew > dgvHeightMax)
            {
                // Make all rows fit into the screen
                customScrollbar.PaintEnable();
                if (customScrollbar.Maximum != dgvHeightNew)
                {
                    customScrollbar.Reset();
                    customScrollbar.Height = dgvHeightMax;
                    customScrollbar.Minimum = 0;
                    customScrollbar.Maximum = dgvHeightNew;
                    customScrollbar.LargeChange = dgvHeightMax;
                    customScrollbar.SmallChange = dgv.RowTemplate.Height;
                }

                dgvHeightNew = dgvHeightMax;
            }
            else
            {
                customScrollbar.PaintDisable();
            }

            if (string.IsNullOrEmpty(data.DefaultView.RowFilter))
            {
                dgv.Height = dgvHeightNew;
            }
        }

        private void AdjustDataGridViewWidth()
        {
            DataGridViewExtensions.FastAutoSizeColumns(dgv);

            if (dgv.Columns[1].Width < 60)
            {
                dgv.Columns[1].Width = 60;
            }

            int widthIcon = dgv.Columns[0].Width;
            int widthText = dgv.Columns[1].Width;
            int widthScrollbar = 0;
            if (customScrollbar.Enabled)
            {
                widthScrollbar = customScrollbar.Width;
            }

            if (tableLayoutPanelTitle.Width > (widthIcon + widthText + widthScrollbar))
            {
                dgv.Width = tableLayoutPanelTitle.Width - widthScrollbar;
                dgv.Columns[1].Width = tableLayoutPanelTitle.Width - widthIcon - widthScrollbar;
            }
            else
            {
                dgv.Width = widthIcon + widthText;
            }

            // Only scaling correct with Sans Serif for textBoxSearch. Workaround:
            textBoxSearch.Font = new Font(
                "Segoe UI",
                8.25F * Scaling.Factor,
                FontStyle.Regular,
                GraphicsUnit.Point,
                0);
        }

        private void DgvMouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            customScrollbar.CustomScrollbar_MouseWheel(sender, e);
            MouseWheel?.Invoke();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            customScrollbar.Value = 0;

            DataTable data = (DataTable)dgv.DataSource;
            string filterField = dgv.Columns[1].Name;
            SearchTextChanging?.Invoke();

            string searchString = textBoxSearch.Text.Trim()
                .Replace("%", " ")
                .Replace("*", " ");
            string like = string.Empty;
            string[] splittedParts = searchString.Split(" ");
            if (splittedParts.Length > 1)
            {
                foreach (string splittedPart in splittedParts)
                {
                    string and = string.Empty;
                    if (!string.IsNullOrEmpty(like))
                    {
                        and = $" AND [{filterField}]";
                    }

                    like += $"{and} LIKE '%{splittedPart}%'";
                }
            }
            else
            {
                like = $"LIKE '%{searchString}%'";
            }

            try
            {
                data.DefaultView.RowFilter = $"[{filterField}] {like}";
            }
            catch (Exception ex)
            {
                if (ex is EvaluateException ||
                    ex is SyntaxErrorException)
                {
                    Log.Warn($"searchString \"{searchString}\" is a invalid", ex);
                }
                else
                {
                    throw;
                }
            }

            if (string.IsNullOrEmpty(searchString))
            {
                data.DefaultView.Sort = string.Empty;
            }
            else
            {
                string columnSortIndex = "SortIndex";

                foreach (DataRow row in data.Rows)
                {
                    if (row[1].ToString().StartsWith(
                        searchString,
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

            int foldersCount = 0;
            int filesCount = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;
                rowData.RowIndex = row.Index;

                if (rowData.ContainsMenu)
                {
                    foldersCount++;
                }
                else
                {
                    filesCount++;
                }
            }

            SetCounts(foldersCount, filesCount);

            SearchTextChanged.Invoke(this, null);
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = MenuDefines.ColorSelectedItem;
            pictureBox.Tag = true;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Tag = false;
        }

        private void PictureBox_Resize(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Invalidate();
        }

        private void PictureBoxSearch_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            e.Graphics.DrawImage(Config.BitmapSearch, new Rectangle(Point.Empty, pictureBox.ClientSize));
        }

        private void PictureBoxFoldersCount_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            e.Graphics.DrawImage(Config.BitmapFoldersCount, new Rectangle(Point.Empty, pictureBox.ClientSize));
        }

        private void PictureBoxFilesCount_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            e.Graphics.DrawImage(Config.BitmapFilesCount, new Rectangle(Point.Empty, pictureBox.ClientSize));
        }

        private void PictureBoxMenuAlwaysOpen_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (Config.AlwaysOpenByPin)
            {
                e.Graphics.DrawImage(Config.BitmapPinActive, new Rectangle(Point.Empty, pictureBox.ClientSize));
            }
            else
            {
                e.Graphics.DrawImage(Config.BitmapPin, new Rectangle(Point.Empty, pictureBox.ClientSize));
            }

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new Rectangle(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxMenuOpenFolder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            e.Graphics.DrawImage(Config.BitmapOpenFolder, new Rectangle(Point.Empty, pictureBox.ClientSize));

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new Rectangle(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxMenuAlwaysOpen_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Config.AlwaysOpenByPin = !Config.AlwaysOpenByPin;
            pictureBox.Invalidate();
        }

        private void PictureBoxOpenFolder_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserClickedOpenFolder?.Invoke();
            }
        }
    }
}