// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;

    internal partial class Menu : Form
    {
        private const int CornerRadius = 20;
        private readonly Fading fading = new();
        private bool isShowing;
        private bool directionToRight;
        private int rotationAngle;
        private bool mouseDown;
        private Point lastLocation;
        private bool isSetSearchText;

        internal Menu()
        {
            fading.ChangeOpacity += Fading_ChangeOpacity;
            void Fading_ChangeOpacity(object sender, double newOpacity)
            {
                if (newOpacity != Opacity && !IsDisposed && !Disposing)
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
                    timerUpdateIcons.Start();
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
                        NativeMethods.User32ShowInactiveTopmost(this);
                        NativeMethods.ForceForegroundWindow(Handle);
                    }
                    else
                    {
                        NativeMethods.User32ShowInactiveTopmost(this);
                    }
                }
            }

            fading.Hide += Hide;

            InitializeComponent();

            SetDoubleBuffer(dgv, true);

            Color foreColor = Color.Black;
            Color backColor = AppColors.Background;
            Color backColorSearch = AppColors.SearchField;
            Color backgroundBorder = AppColors.BackgroundBorder;

            if (Config.IsDarkMode())
            {
                foreColor = Color.White;
                labelTitle.ForeColor = foreColor;
                textBoxSearch.ForeColor = foreColor;
                backColor = AppColors.DarkModeBackground;
                backColorSearch = AppColors.DarkModeSearchField;
                backgroundBorder = AppColors.DarkModeBackgroundBorder;
            }

            ColorConverter colorConverter = new();
            labelItems.ForeColor = MenuDefines.ColorIcons;

            if (backColor.R == 0)
            {
                backColor = Color.White;
            }

            BackColor = backgroundBorder;
            labelTitle.BackColor = backColor;
            tableLayoutPanelDgvAndScrollbar.BackColor = backColor;
            tableLayoutPanelBottom.BackColor = backColor;
            tableLayoutPanelMenu.BackColor = backColor;
            dgv.BackgroundColor = backColor;
            textBoxSearch.BackColor = backColorSearch;
            panelLine.BackColor = AppColors.Icons;
            pictureBoxSearch.BackColor = backColorSearch;
            tableLayoutPanelSearch.BackColor = backColorSearch;
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                SelectionForeColor = foreColor,
                ForeColor = foreColor,
                BackColor = backColor,
            };

            dgv.GotFocus += (sender, e) => FocusTextBox();
            customScrollbar.GotFocus += (sender, e) => FocusTextBox();

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
            textBoxSearch.MouseEnter += ControlsMouseEnter;
            pictureBoxOpenFolder.MouseEnter += ControlsMouseEnter;
            pictureBoxMenuAlwaysOpen.MouseEnter += ControlsMouseEnter;
            pictureBoxSettings.MouseEnter += ControlsMouseEnter;
            pictureBoxRestart.MouseEnter += ControlsMouseEnter;
            pictureBoxSearch.MouseEnter += ControlsMouseEnter;
            tableLayoutPanelMenu.MouseEnter += ControlsMouseEnter;
            tableLayoutPanelDgvAndScrollbar.MouseEnter += ControlsMouseEnter;
            tableLayoutPanelBottom.MouseEnter += ControlsMouseEnter;
            labelItems.MouseEnter += ControlsMouseEnter;
            void ControlsMouseEnter(object sender, EventArgs e)
            {
                MouseEnter?.Invoke();
            }

            customScrollbar.MouseLeave += ControlsMouseLeave;
            dgv.MouseLeave += ControlsMouseLeave;
            labelTitle.MouseLeave += ControlsMouseLeave;
            textBoxSearch.MouseLeave += ControlsMouseLeave;
            pictureBoxMenuAlwaysOpen.MouseLeave += ControlsMouseLeave;
            pictureBoxOpenFolder.MouseLeave += ControlsMouseLeave;
            pictureBoxSettings.MouseLeave += ControlsMouseLeave;
            pictureBoxRestart.MouseLeave += ControlsMouseLeave;
            pictureBoxSearch.MouseLeave += ControlsMouseLeave;
            tableLayoutPanelMenu.MouseLeave += ControlsMouseLeave;
            tableLayoutPanelDgvAndScrollbar.MouseLeave += ControlsMouseLeave;
            tableLayoutPanelBottom.MouseLeave += ControlsMouseLeave;
            labelItems.MouseLeave += ControlsMouseLeave;
            void ControlsMouseLeave(object sender, EventArgs e)
            {
                MouseLeave?.Invoke();
            }

            bool isTouchEnabled = NativeMethods.IsTouchEnabled();
            if ((isTouchEnabled && Properties.Settings.Default.DragDropItemsEnabledTouch) ||
                (!isTouchEnabled && Properties.Settings.Default.DragDropItemsEnabled))
            {
                AllowDrop = true;
                DragEnter += DragDropHelper.DragEnter;
                DragDrop += DragDropHelper.DragDrop;
            }
        }

        internal new event EventHandlerEmpty MouseWheel;

        internal new event EventHandlerEmpty MouseEnter;

        internal new event EventHandlerEmpty MouseLeave;

        internal event EventHandlerEmpty UserClickedOpenFolder;

        internal event EventHandler<Keys> CmdKeyProcessed;

        internal event EventHandler<KeyPressEventArgs> KeyPressCheck;

        internal event EventHandlerEmpty SearchTextChanging;

        internal event EventHandler SearchTextChanged;

        internal event EventHandlerEmpty UserDragsMenu;

        internal enum MenuType
        {
            Main,
            Sub,
            Empty,
            NoAccess,
            MaxReached,
            Loading,
        }

        internal enum StartLocation
        {
            Predecessor,
            BottomLeft,
            BottomRight,
            TopRight,
        }

        internal int Level { get; set; }

        internal bool IsUsable => Visible && !fading.IsHiding && !IsDisposed && !Disposing;

        internal bool ScrollbarVisible { get; private set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createparams = base.CreateParams;
                createparams.ExStyle |= 0x80; // do not show when user presses alt + tab
                createparams.ClassStyle |= 0x00020000; // CS_DROPSHADOW

                return createparams;
            }
        }

        internal void ResetSearchText()
        {
            textBoxSearch.Text = string.Empty;
        }

        internal void FocusTextBox()
        {
            if (isSetSearchText)
            {
                isSetSearchText = false;
                textBoxSearch.SelectAll();
                textBoxSearch.Focus();
                textBoxSearch.SelectionStart = textBoxSearch.Text.Length;
                textBoxSearch.SelectionLength = 0;
            }
            else
            {
                textBoxSearch.SelectAll();
                textBoxSearch.Focus();
            }
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

        internal void SetTypeLoading()
        {
            SetType(MenuType.Loading);
        }

        internal void SetType(MenuType type)
        {
            if (type != MenuType.Main)
            {
                pictureBoxSettings.Visible = false;
                pictureBoxRestart.Visible = false;
            }

            switch (type)
            {
                case MenuType.Main:
                    break;
                case MenuType.Sub:
                    pictureBoxMenuAlwaysOpen.Visible = false;
                    break;
                case MenuType.Empty:
                    pictureBoxSearch.Visible = true;
                    textBoxSearch.Visible = true;
                    tableLayoutPanelSearch.Visible = true;
                    labelItems.Text = Translator.GetText("Directory empty");
                    pictureBoxMenuAlwaysOpen.Visible = false;
                    break;
                case MenuType.NoAccess:
                    pictureBoxSearch.Visible = true;
                    textBoxSearch.Visible = true;
                    tableLayoutPanelSearch.Visible = true;
                    labelItems.Text = Translator.GetText("Directory inaccessible");
                    pictureBoxMenuAlwaysOpen.Visible = false;
                    break;
                case MenuType.Loading:
                    pictureBoxSearch.Visible = true;
                    textBoxSearch.Visible = true;
                    tableLayoutPanelSearch.Visible = true;
                    labelItems.Text = Translator.GetText("loading");
                    pictureBoxMenuAlwaysOpen.Visible = true;
                    textBoxSearch.TextChanged -= TextBoxSearch_TextChanged;
                    pictureBoxOpenFolder.Visible = false;
                    pictureBoxMenuAlwaysOpen.Paint -= PictureBoxMenuAlwaysOpen_Paint;
                    pictureBoxMenuAlwaysOpen.Paint += LoadingMenu_Paint;
                    timerUpdateIcons.Tick -= TimerUpdateIcons_Tick;
                    timerUpdateIcons.Tick += (sender, e) => pictureBoxMenuAlwaysOpen.Invalidate();
                    timerUpdateIcons.Interval = 15;
                    break;
                default:
                    break;
            }
        }

        internal string GetSearchText()
        {
            return textBoxSearch.Text;
        }

        internal void SetSearchText(string userSearchText)
        {
            if (!string.IsNullOrEmpty(userSearchText))
            {
                textBoxSearch.Text = userSearchText + "*";
                isSetSearchText = true;
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

        internal void AdjustControls(string title, MenuDataValidity menuDataValidity)
        {
            if (!string.IsNullOrEmpty(title) && Config.ShowDirectoryTitleAtTop)
            {
                if (title.Length > MenuDefines.LengthMax)
                {
                    title = $"{title[..MenuDefines.LengthMax]}...";
                }

                labelTitle.Text = title;
            }
            else
            {
                labelTitle.Text = string.Empty;
                labelTitle.MaximumSize = new Size(0, 12);
            }

            if (!Config.ShowSearchBar)
            {
                tableLayoutPanelSearch.AutoSize = false;
                tableLayoutPanelSearch.Height = 0;
                textBoxSearch.AutoSize = false;
                textBoxSearch.Height = 0;
                pictureBoxSearch.Visible = false;
                panelLine.Visible = false;
            }

            if (!Config.ShowCountOfElementsBelow &&
                menuDataValidity == MenuDataValidity.Valid)
            {
                labelItems.Visible = false;
            }

            if (!Config.ShowFunctionKeysBelow)
            {
                pictureBoxOpenFolder.Visible = false;
                pictureBoxMenuAlwaysOpen.Visible = false;
                pictureBoxSettings.Visible = false;
                pictureBoxRestart.Visible = false;
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
        /// <param name="isCustomLocationOutsideOfScreen">isCustomLocationOutsideOfScreen.</param>
        internal void AdjustSizeAndLocation(
            Rectangle bounds,
            Menu menuPredecessor,
            StartLocation startLocation,
            bool isCustomLocationOutsideOfScreen)
        {
            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();

            bool useCustomLocation = Properties.Settings.Default.UseCustomLocation || lastLocation.X > 0;
            bool changeDirectionWhenOutOfBounds = true;

            if (menuPredecessor != null)
            {
                // Ignore start as we use predecessor
                startLocation = StartLocation.Predecessor;
            }
            else if (useCustomLocation && !isCustomLocationOutsideOfScreen)
            {
                // Do not adjust location again because Cursor.Postion changed
                if (Tag != null)
                {
                    return;
                }

                // Use this menu as predecessor and overwrite location with CustomLocation
                menuPredecessor = this;
                Tag = new RowData();
                Location = new Point(
                    Properties.Settings.Default.CustomLocationX,
                    Properties.Settings.Default.CustomLocationY);
                directionToRight = true;
                startLocation = StartLocation.Predecessor;
                changeDirectionWhenOutOfBounds = false;
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
                changeDirectionWhenOutOfBounds = false;
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

                        if (changeDirectionWhenOutOfBounds &&
                            bounds.X + bounds.Width <= x + Width - scaling)
                        {
                            x = menuPredecessor.Location.X - Width + scaling;
                            if (x < bounds.X &&
                                menuPredecessor.Location.X + menuPredecessor.Width < bounds.X + bounds.Width &&
                                bounds.X + (bounds.Width / 2) > menuPredecessor.Location.X + (Width / 2))
                            {
                                x = bounds.X + bounds.Width - Width + scaling;
                            }
                            else
                            {
                                if (x < bounds.X)
                                {
                                    x = bounds.X;
                                }

                                directionToRight = !directionToRight;
                            }
                        }
                    }
                    else
                    {
                        x = menuPredecessor.Location.X - Width + scaling;

                        if (changeDirectionWhenOutOfBounds &&
                            x < bounds.X)
                        {
                            x = menuPredecessor.Location.X + menuPredecessor.Width - scaling;
                            if (x + Width > bounds.X + bounds.Width &&
                                menuPredecessor.Location.X > bounds.X &&
                                bounds.X + (bounds.Width / 2) < menuPredecessor.Location.X + (Width / 2))
                            {
                                x = bounds.X;
                            }
                            else
                            {
                                if (x + Width > bounds.X + bounds.Width)
                                {
                                    x = bounds.X + bounds.Width - Width + scaling;
                                }

                                directionToRight = !directionToRight;
                            }
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
            }

            if (Level != 0 &&
                !Properties.Settings.Default.AppearNextToPreviousMenu &&
                menuPredecessor.Width > Properties.Settings.Default.OverlappingOffsetPixels)
            {
                if (directionToRight)
                {
                    x = x - menuPredecessor.Width + Properties.Settings.Default.OverlappingOffsetPixels;
                }
                else
                {
                    x = x + menuPredecessor.Width - Properties.Settings.Default.OverlappingOffsetPixels;
                }
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
                        TableLayoutPanelCellPosition pos = tableLayoutPanelMenu.GetCellPosition(labelTitle);
                        int height = tableLayoutPanelMenu.GetRowHeights()[pos.Row];
                        y += height;
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

            if (Properties.Settings.Default.RoundCorners)
            {
                if (NativeMethods.GetRegionRoundCorners(Width + 1, Height + 1, CornerRadius, CornerRadius, out Region regionOutline))
                {
                    Region = regionOutline;
                }

                if (NativeMethods.GetRegionRoundCorners(Width - 1, Height - 1, CornerRadius, CornerRadius, out Region region))
                {
                    tableLayoutPanelMenu.Region = region;
                }
            }
        }

        internal void AdjustScrollbar()
        {
            if (dgv.Rows.Count > 0)
            {
                customScrollbar.Value = (int)Math.Round(
                    dgv.FirstDisplayedScrollingRowIndex * (decimal)customScrollbar.Maximum / dgv.Rows.Count,
                    0,
                    MidpointRounding.AwayFromZero);
            }
        }

        internal void SetCounts(int foldersCount, int filesCount)
        {
            int filesAndFoldersCount = foldersCount + filesCount;
            string elements = filesAndFoldersCount == 1 ? "element" : "elements";
            labelItems.Text = $"{filesAndFoldersCount} {Translator.GetText(elements)}";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            switch (keys)
            {
                case Keys.Enter:
                case Keys.Home:
                case Keys.End:
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
            double factor = Properties.Settings.Default.RowHeighteInPercentage / 100f;
            if (NativeMethods.IsTouchEnabled())
            {
                factor = Properties.Settings.Default.RowHeighteInPercentageTouch / 100f;
            }

            double factorIconSizeInPercent = Properties.Settings.Default.IconSizeInPercent / 100f;

            if (factor < factorIconSizeInPercent)
            {
                factor = factorIconSizeInPercent;
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
                ScrollbarVisible = true;
            }
            else
            {
                customScrollbar.PaintDisable();
                ScrollbarVisible = false;
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

            if (tableLayoutPanelBottom.Width > (widthIcon + widthText + widthScrollbar))
            {
                dgv.Width = tableLayoutPanelBottom.Width - widthScrollbar;
                dgv.Columns[1].Width = tableLayoutPanelBottom.Width - widthIcon - widthScrollbar;
            }
            else
            {
                dgv.Width = widthIcon + widthText;
            }

            tableLayoutPanelSearch.MinimumSize = new Size(dgv.Width + widthScrollbar, 0);

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

        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressCheck?.Invoke(sender, e);
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            customScrollbar.Value = 0;

            DataTable data = (DataTable)dgv.DataSource;
            string filterField = dgv.Columns[1].Name;
            SearchTextChanging?.Invoke();

            // Expression reference: https://docs.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?view=net-6.0

            // Instead implementing in-string wildcards, simply split into multiple search patters
            string searchString = textBoxSearch.Text.Trim()
                .Replace("%", " ")
                .Replace("*", " ");

            // Replace special characters
            string tmp = new(searchString);
            searchString = string.Empty;
            foreach (char ch in tmp)
            {
                searchString += ch switch
                {
                    '[' => "[[]",
                    ']' => "[]]",
                    _ => ch,
                };
            }

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

            bool isSearchStringEmpty = string.IsNullOrEmpty(searchString);

            try
            {
                if (Properties.Settings.Default.ShowOnlyAsSearchResult &&
                    isSearchStringEmpty)
                {
                    data.DefaultView.RowFilter = "[SortIndex] LIKE '%0%'";
                }
                else
                {
                    data.DefaultView.RowFilter = $"[{filterField}] {like}";
                }
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

            string columnSortIndex = "SortIndex";
            if (isSearchStringEmpty)
            {
                foreach (DataRow row in data.Rows)
                {
                    RowData rowData = (RowData)row[2];
                    if (Properties.Settings.Default.ShowOnlyAsSearchResult &&
                        rowData.ShowOnlyWhenSearch)
                    {
                        row[columnSortIndex] = 99;
                    }
                    else
                    {
                        row[columnSortIndex] = 0;
                    }
                }

                data.DefaultView.Sort = string.Empty;
                data.AcceptChanges();
            }
            else
            {
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
            bool anyIconNotUpdated = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;

                if (!isSearchStringEmpty || !rowData.ShowOnlyWhenSearch)
                {
                    rowData.RowIndex = row.Index;

                    if (rowData.ContainsMenu)
                    {
                        foldersCount++;
                    }
                    else
                    {
                        filesCount++;
                    }

                    if (rowData.IconLoading)
                    {
                        anyIconNotUpdated = true;
                    }
                }
            }

            SetCounts(foldersCount, filesCount);

            SearchTextChanged.Invoke(this, null);

            if (anyIconNotUpdated)
            {
                timerUpdateIcons.Start();
            }

            if (isSearchStringEmpty && dgv.Rows.Count > 0)
            {
                dgv.FirstDisplayedScrollingRowIndex = 0;
            }
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

        private void PictureBoxOpenFolder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            e.Graphics.DrawImage(AppColors.BitmapOpenFolder, new Rectangle(Point.Empty, pictureBox.ClientSize));

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxOpenFolder_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserClickedOpenFolder?.Invoke();
            }
        }

        private void PictureBoxMenuAlwaysOpen_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (Config.AlwaysOpenByPin)
            {
                e.Graphics.DrawImage(AppColors.BitmapPinActive, new Rectangle(Point.Empty, pictureBox.ClientSize));
            }
            else
            {
                e.Graphics.DrawImage(AppColors.BitmapPin, new Rectangle(Point.Empty, pictureBox.ClientSize));
            }

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxMenuAlwaysOpen_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Config.AlwaysOpenByPin = !Config.AlwaysOpenByPin;
            pictureBox.Invalidate();
        }

        private void PictureBoxSettings_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            e.Graphics.DrawImage(AppColors.BitmapSettings, new Rectangle(Point.Empty, pictureBox.ClientSize));

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Properties.Settings.Default.CacheMainMenu)
                {
                    SettingsForm.ShowSingleInstance(this);
                }
                else
                {
                    SettingsForm.ShowSingleInstance(null);
                }
            }
        }

        private void PictureBoxRestart_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            e.Graphics.DrawImage(AppColors.BitmapRestart, new Rectangle(Point.Empty, pictureBox.ClientSize));

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }

        private void PictureBoxRestart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AppRestart.ByMenuButton();
            }
        }

        private void PictureBoxSearch_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            e.Graphics.DrawImage(AppColors.BitmapSearch, new Rectangle(Point.Empty, pictureBox.ClientSize));
        }

        private void LoadingMenu_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            rotationAngle += 5;
            e.Graphics.DrawImage(
                ImagingHelper.RotateImage(Resources.StaticResources.LoadingIcon.ToBitmap(), rotationAngle),
                new Rectangle(Point.Empty, new Size(pictureBox.ClientSize.Width - 2, pictureBox.ClientSize.Height - 2)));
        }

        private void TimerUpdateIcons_Tick(object sender, EventArgs e)
        {
            int iconsToUpdate = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                RowData rowData = (RowData)row.Cells[2].Value;
                rowData.RowIndex = row.Index;

                if (rowData.IconLoading)
                {
                    iconsToUpdate++;
                    row.Cells[0].Value = rowData.ReadLoadedIcon();
                }
            }

            if (iconsToUpdate < 1)
            {
                timerUpdateIcons.Stop();
            }
        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (Level == 0)
            {
                mouseDown = true;
                lastLocation = e.Location;
                UserDragsMenu.Invoke();
            }
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    Location.X - lastLocation.X + e.X,
                    Location.Y - lastLocation.Y + e.Y);

                Properties.Settings.Default.CustomLocationX = Location.X;
                Properties.Settings.Default.CustomLocationY = Location.Y;

                Update();
            }
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (Properties.Settings.Default.UseCustomLocation)
            {
                if (!SettingsForm.IsOpen())
                {
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}