// <copyright file="Menu.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable enable

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// Logic of Menu window.
    /// </summary>
    public partial class Menu : Window
    {
#if TODO
        public const string RowFilterShowAll = "[SortIndex] LIKE '%0%'";
#endif
        private const int CornerRadius = 10;

        private readonly Fading fading = new();
        private bool isShowing;
        private bool directionToRight;
        private bool mouseDown;
        private Point lastLocation;
#if TODO
        private bool isSetSearchText;
        private bool dgvHeightSet;
#endif
        private bool isClosed = false; // TODO WPF Replace Forms wrapper
        private DispatcherTimer timerUpdateIcons = new DispatcherTimer(DispatcherPriority.Render, Dispatcher.CurrentDispatcher);

        internal Menu()
        {
            timerUpdateIcons.Tick += TimerUpdateIcons_Tick;
            Closed += (_, _) =>
            {
                fading.Fade(Fading.FadingState.Idle);
                timerUpdateIcons.Stop();
                isClosed = true; // TODO WPF Replace Forms wrapper
            };

            Opacity = 0D;
            fading.ChangeOpacity += Fading_ChangeOpacity;
            void Fading_ChangeOpacity(object? sender, double newOpacity)
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
                    Visibility = Visibility.Visible;
                    isShowing = false;
                    timerUpdateIcons.Start();
                }
                catch (ObjectDisposedException)
                {
                    Visibility = Visibility.Hidden;
                    isShowing = false;
                    Log.Info($"Could not open menu, old menu was disposing," +
                        $" IsDisposed={IsDisposed}");
                }

                if (Visibility == Visibility.Visible)
                {
                    if (Level == 0)
                    {
                        Activate();
                        Show();
                    }
                    else
                    {
                        ShowActivated = false;
                        Show();
                    }
                }
            }

            fading.Hide += Hide;

            InitializeComponent();

            Assembly myassembly = Assembly.GetExecutingAssembly();
            string myname = myassembly.GetName().Name ?? string.Empty;

            txtTitle.Text = myname;

            foreach (FrameworkElement control in
                new List<FrameworkElement>()
                {
                    buttonMenuAlwaysOpen,
                    buttonOpenFolder,
                    buttonSettings,
                    buttonRestart,
                    pictureBoxSearch,
                    pictureBoxMenuAlwaysOpen,
                    pictureBoxOpenFolder,
                    pictureBoxSettings,
                    pictureBoxRestart,
                    pictureBoxLoading,
                })
            {
                control.Width = Scaling.Scale(control.Width);
                control.Height = Scaling.Scale(control.Height);
            }

            labelTitle.FontSize = Scaling.ScaleFontByPoints(8.25F);
            textBoxSearch.FontSize = Scaling.ScaleFontByPoints(8.25F);
            labelItems.FontSize = Scaling.ScaleFontByPoints(7F);
            dgv.FontSize = Scaling.ScaleFontByPoints(9F);

#if TODO
            customScrollbar = new CustomScrollbar();

            tableLayoutPanelDgvAndScrollbar.Controls.Add(customScrollbar, 1, 0);
#endif
            MouseDown += Menu_MouseDown;
            MouseUp += Menu_MouseUp;
            MouseMove += Menu_MouseMove;
#if TODO
            labelTitle.MouseWheel += new MouseEventHandler(DgvMouseWheel);

            // customScrollbar
            customScrollbar.Location = new Point(0, 0);
            customScrollbar.Name = "customScrollbar";
            customScrollbar.Size = new Size(Scaling.Scale(15), 40);
#endif
            SolidColorBrush foreColor = new(Colors.Black);
            SolidColorBrush backColor = AppColors.Background.ToSolidColorBrush();
            SolidColorBrush backColorSearch = AppColors.SearchField.ToSolidColorBrush();
            SolidColorBrush backgroundBorder = AppColors.BackgroundBorder.ToSolidColorBrush();

            if (Config.IsDarkMode())
            {
                foreColor = new (Colors.White);
                backColor = AppColors.DarkModeBackground.ToSolidColorBrush();
                backColorSearch = AppColors.DarkModeSearchField.ToSolidColorBrush();
                backgroundBorder = AppColors.DarkModeBackgroundBorder.ToSolidColorBrush();
            }

            labelTitle.Foreground = foreColor;
            textBoxSearch.Foreground = foreColor;
            dgv.Foreground = foreColor;
            labelItems.Foreground = MenuDefines.ColorIcons.ToSolidColorBrush();

            windowFrame.BorderBrush = backgroundBorder;
            windowFrame.Background = backColor;
            searchPanel.Background = backColorSearch;
            panelLine.Background = AppColors.Icons.ToSolidColorBrush();

            dgv.GotFocus += (_, _) => FocusTextBox();
#if TODO
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
#endif

            Loaded += (sender, e) =>
                {
                    NativeMethods.HideFromAltTab(this);

                    // TODO WPF Replace Forms wrapper
                    IsHandleCreated = true;
                    HandleCreated?.Invoke(sender, e);
                };
        }

#if TODO
        internal new event Action MouseWheel;

        internal new event Action MouseEnter;

        internal new event Action MouseLeave;
#endif

        internal event Action? UserClickedOpenFolder;
#if TODO

        internal event EventHandler<Key> CmdKeyProcessed;

        internal event EventHandler<KeyPressEventArgs> KeyPressCheck;

        internal event Action SearchTextChanging;

        internal event EventHandler<bool> SearchTextChanged;
#endif

        internal event Action? UserDragsMenu;

        internal event RoutedEventHandler? HandleCreated; // TODO WPF Replace Forms wrapper

        internal event Action<ListView, int>? CellMouseEnter;

        internal event Action<ListView, int>? CellMouseLeave;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseDown;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseUp;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseClick;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseDoubleClick;

        internal enum MenuType
        {
            /// <summary>
            /// Root menu
            /// </summary>
            Main,

            /// <summary>
            /// Sub menu
            /// </summary>
            Sub,

            /// <summary>
            /// Sub menu with no content
            /// </summary>
            Empty,

            /// <summary>
            /// Sub menu with no access
            /// </summary>
            NoAccess,

            /// <summary>
            /// TODO: Not used - remove?
            /// </summary>
            MaxReached,

            /// <summary>
            /// Sub menu but with yet unknown content
            /// </summary>
            Loading,
        }

        internal enum StartLocation
        {
            Predecessor,
            BottomLeft,
            BottomRight,
            TopRight,
        }

        public bool IsHandleCreated { get; internal set; } // TODO State out of window

        public bool IsLoadingMenu { get; internal set; } // TODO State out of window

        public bool IsDisposed => isClosed; // TODO WPF Replace Forms wrapper

        public bool Disposing => isClosed; // TODO WPF Replace Forms wrapper

        public System.Drawing.Point Location => new System.Drawing.Point((int)Left, (int)Top); // TODO WPF Replace Forms wrapper)

        internal int Level { get; set; }

        internal bool IsUsable => Visibility == Visibility.Visible && !fading.IsHiding && !IsDisposed && !Disposing;

#if TODO
        internal bool ScrollbarVisible { get; private set; }

        private ListView tableLayoutPanelDgvAndScrollbar => dgv; // TODO WPF Remove and replace with dgv
#endif
        internal void ResetSearchText()
        {
            textBoxSearch.Text = string.Empty;
            if (dgv.Items.Count > 0)
            {
                dgv.ScrollIntoView(dgv.Items[0]);
            }
#if TODO
            AdjustScrollbar();
#endif
        }

        internal void RefreshSearchText()
        {
            TextBoxSearch_TextChanged();
            if (dgv.Items.Count > 0)
            {
                dgv.ScrollIntoView(dgv.Items[0]);
            }
#if TODO
            AdjustScrollbar();
#endif
        }

        internal void FocusTextBox()
        {
#if TODO
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
#endif
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
                buttonSettings.Visibility = Visibility.Collapsed;
                buttonRestart.Visibility = Visibility.Collapsed;
            }

            switch (type)
            {
                case MenuType.Main:
                    textBoxSearch.TextChanged += (_, _) => TextBoxSearch_TextChanged();
                    break;
                case MenuType.Sub:
                    textBoxSearch.TextChanged += (_, _) => TextBoxSearch_TextChanged();
                    buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                    break;
                case MenuType.Empty:
                    // TODO? remove search bar when searching makes no sense (take care of calculating initial position)
                    //       searchPanel.Visibility = Visibility.Collapsed;
                    labelItems.Content = Translator.GetText("Directory empty");
                    buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                    break;
                case MenuType.NoAccess:
                    // TODO? remove search bar when searching makes no sense (take care of calculating initial position)
                    //       searchPanel.Visibility = Visibility.Collapsed;
                    labelItems.Content = Translator.GetText("Directory inaccessible");
                    buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                    break;
                case MenuType.Loading:
                    labelItems.Content = Translator.GetText("loading");
                    buttonMenuAlwaysOpen.Visibility = Visibility.Visible;
                    buttonOpenFolder.Visibility = Visibility.Collapsed;

                    // Todo: use embedded resources that we can assign image in XAML already
                    pictureBoxLoading.Source = SystemTrayMenu.Resources.StaticResources.LoadingIcon.ToImageSource();
                    pictureBoxLoading.Visibility = Visibility.Visible;
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
#if TODO
                isSetSearchText = true;
#endif
            }
        }

        internal bool IsMouseOn()
        {
            Point mousePos = NativeMethods.Screen.CursorPosition;
            bool isMouseOn = Visibility == Visibility.Visible &&
                mousePos.X >= 0 && mousePos.X < Width &&
                mousePos.Y >= 0 && mousePos.Y < Height;
            return isMouseOn;
        }

        internal ListView? GetDataGridView() // TODO WPF Replace Forms wrapper
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

                txtTitle.Text = title;
            }
            else
            {
                txtTitle.Text = string.Empty;
            }

            if (!Config.ShowSearchBar)
            {
                searchPanel.Visibility = Visibility.Collapsed;
                panelLine.Visibility = Visibility.Collapsed;
            }

            if (!Config.ShowCountOfElementsBelow &&
                menuDataValidity == MenuDataValidity.Valid)
            {
                labelItems.Visibility = Visibility.Collapsed;
            }

            if (!Config.ShowFunctionKeyOpenFolder)
            {
                buttonOpenFolder.Visibility = Visibility.Collapsed;
            }

            if (!Config.ShowFunctionKeyPinMenu)
            {
                buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
            }

            if (!Config.ShowFunctionKeySettings)
            {
                buttonSettings.Visibility = Visibility.Collapsed;
            }

            if (!Config.ShowFunctionKeyRestart)
            {
                buttonRestart.Visibility = Visibility.Collapsed;
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

        internal void TimerUpdateIconsStart()
        {
            timerUpdateIcons.Start();
        }

#if TODO // Hack for a pseudo Refresh
        private delegate void NoArgDelegate();
#endif

        /// <summary>
        /// Update the position and size of the menu.
        /// </summary>
        /// <param name="bounds">Screen coordinates where the menu is allowed to be drawn in.</param>
        /// <param name="menuPredecessor">Predecessor menu (when available).</param>
        /// <param name="startLocation">Defines where the first menu is drawn (when no predecessor is set).</param>
        /// <param name="isCustomLocationOutsideOfScreen">isCustomLocationOutsideOfScreen.</param>
        internal void AdjustSizeAndLocation(
            Rect bounds,
            Menu menuPredecessor,
            StartLocation startLocation,
            bool isCustomLocationOutsideOfScreen)
        {
            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();
#if TODO // Hack for a pseudo Refresh
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
                (NoArgDelegate)delegate { });

#endif
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
                Left = Properties.Settings.Default.CustomLocationX;
                Top = Properties.Settings.Default.CustomLocationY;
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
                var position = Mouse.GetPosition(this);
                Left = position.X;
                Top = position.Y - labelTitle.Height;
                directionToRight = true;
                startLocation = StartLocation.Predecessor;
                changeDirectionWhenOutOfBounds = false;
            }

            Loaded += (_, _) =>
            {
                // Calculate X position
                double x;
                switch (startLocation)
                {
                    case StartLocation.Predecessor:
                        double scaling = Math.Round(Scaling.Factor, 0, MidpointRounding.AwayFromZero);
                        directionToRight = menuPredecessor!.directionToRight; // try keeping same direction
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
                    menuPredecessor != null && menuPredecessor.Width > Properties.Settings.Default.OverlappingOffsetPixels)
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
                double y;
                switch (startLocation)
                {
                    case StartLocation.Predecessor:

                        RowData trigger = (RowData)Tag;
                        ListView dgv = menuPredecessor!.GetDataGridView()!;

                        // Set position on same height as the selected row from predecessor
                        y = menuPredecessor.Location.Y;
                        if (dgv.Items.Count > trigger.RowIndex)
                        {
                            ListViewItem? lvi = dgv.FindVisualChildOfType<ListViewItem>(trigger.RowIndex);
                            if (lvi != null)
                            {
                                y += menuPredecessor.GetRelativeChildPositionTo(lvi).Y;
                            }
                        }

                        // when warning is shown, the title should appear at same height as selected row
                        if (searchPanel.Visibility != Visibility.Visible)
                        {
                            y += labelTitle.ActualHeight;
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
                Left = x;
                Top = y;

                if (Properties.Settings.Default.RoundCorners)
                {
                    windowFrame.CornerRadius = new CornerRadius(CornerRadius);
                }
            };
        }

        internal void AdjustScrollbar()
        {
#if TODO
            if (dgv.Rows.Count > 0)
            {
                customScrollbar.Value = (int)Math.Round(
                    dgv.FirstDisplayedScrollingRowIndex * (decimal)customScrollbar.Maximum / dgv.Rows.Count,
                    0,
                    MidpointRounding.AwayFromZero);
            }
#endif
        }

        internal void ResetHeight()
        {
#if TODO
            dgvHeightSet = false;
#endif
        }

        internal void SetCounts(int foldersCount, int filesCount)
        {
            int filesAndFoldersCount = foldersCount + filesCount;
            string elements = filesAndFoldersCount == 1 ? "element" : "elements";
            labelItems.Content = $"{filesAndFoldersCount} {Translator.GetText(elements)}";
        }

#if TODO
        protected override bool ProcessCmdKey(ref Message msg, Key keys)
        {
            switch (keys)
            {
                case Key.Enter:
                case Key.Home:
                case Key.End:
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                case Key.Escape:
                case Key.Alt | Key.F4:
                case Key.Control | Key.F:
                case Key.Tab:
                case Key.Tab | Key.Shift:
                case Key.Apps:
                    CmdKeyProcessed.Invoke(this, keys);
                    return true;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keys);
        }
#endif
        private void AdjustDataGridViewHeight(Menu menuPredecessor, double screenHeightMax)
        {
            double factor = Properties.Settings.Default.RowHeighteInPercentage / 100f;
            if (NativeMethods.IsTouchEnabled())
            {
                factor = Properties.Settings.Default.RowHeighteInPercentageTouch / 100f;
            }

            if (menuPredecessor == null)
            {
                if (dgv.Tag == null && dgv.Items.Count > 0)
                {
                    // dgv.AutoResizeRows(); slightly incorrect depending on dpi
                    // 100% = 20 instead 21
                    // 125% = 23 instead 27, 150% = 28 instead 32
                    // 175% = 33 instead 37, 200% = 35 instead 42
                    // #418 use 21 as default and scale it manually
                    double rowHeightDefault = 21.24f * Scaling.FactorByDpi;
                    Resources["RowHeight"] = (double)(int)((rowHeightDefault * factor * Scaling.Factor) + 0.5);
                    dgv.Tag = true;
                }
            }
            else
            {
                // Take over the height from predecessor menu
                Resources["RowHeight"] = menuPredecessor.Resources["RowHeight"];
                dgv.Tag = true;
            }

#if TODO
            if (!dgvHeightSet && dgvHeightByItems > 0 && dgvHeightMax > 0)
            {
#endif
            double heightMaxByOptions = Scaling.Factor * Scaling.FactorByDpi *
                450f * (Properties.Settings.Default.HeightMaxInPercent / 100f);
            MaxHeight = Math.Min(screenHeightMax, heightMaxByOptions);
#if TODO
                dgvHeightSet = true;
            }
#endif
#if TODO
            if (dgvHeightByItems > dgvHeightMax)
            {
                ScrollbarVisible = true;
                customScrollbar.PaintEnable(dgv.Height);
                if (customScrollbar.Maximum != dgvHeightByItems)
                {
                    customScrollbar.Reset();
                    customScrollbar.Minimum = 0;
                    customScrollbar.Maximum = dgvHeightByItems;
                    customScrollbar.LargeChange = dgvHeightMax;
                    customScrollbar.SmallChange = Resources["RowHeight"];
                }
            }
            else
            {
                ScrollbarVisible = false;
                customScrollbar.PaintDisable();
            }
#endif
        }

        private void AdjustDataGridViewWidth()
        {
            if (!string.IsNullOrEmpty(textBoxSearch.Text))
            {
                return;
            }

            double factorIconSizeInPercent = Properties.Settings.Default.IconSizeInPercent / 100f;
            // IcoWidth 100% = 21px, 175% is 33, +3+2 is padding from ColumnIcon
            double icoWidth = (16 * Scaling.FactorByDpi) + 5;
            Resources["ColumnIconWidth"] = (double)(int)((icoWidth * factorIconSizeInPercent * Scaling.Factor) + 0.5);

            double renderedMaxWidth = 0D;
            foreach (ListViewItemData item in dgv.Items)
            {
                double renderedWidth = new FormattedText(
                        item.ColumnText,
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(dgv.FontFamily, dgv.FontStyle, dgv.FontWeight, dgv.FontStretch),
                        dgv.FontSize,
                        dgv.Foreground,
                        VisualTreeHelper.GetDpi(this).PixelsPerDip).Width;
                if (renderedWidth > renderedMaxWidth)
                {
                    renderedMaxWidth = renderedWidth;
                }
            }

#if TODO // Lazy value setting because of DataBinging but too late for Menues.AdjustSizeAndLocation()
            renderedMaxWidth = Math.Min(
                renderedMaxWidth,
                (double)(Scaling.Factor * Scaling.FactorByDpi * 400f * (Properties.Settings.Default.WidthMaxInPercent / 100f)));

            for (int i = 0; i < dgv.Items.Count; i++)
            {
                ListViewItem? lvi = dgv.FindVisualChildOfType<ListViewItem>(i);
                if (lvi != null)
                {
                    Label? columnTextLabel = lvi.FindVisualChildOfType<Label>();
                    if (columnTextLabel != null)
                    {
                        columnTextLabel.Content = i.ToString() + " ; " + Width + " ; " + renderedMaxWidth.ToString();
                        columnTextLabel.Width = renderedMaxWidth;
                    }
                }
            }
#else
            Resources["ColumnTextWidth"] = Math.Min(
                renderedMaxWidth,
                (double)(Scaling.Factor * Scaling.FactorByDpi * 400f * (Properties.Settings.Default.WidthMaxInPercent / 100f)));

#endif
#if TODO
            int widthIcon = dgv.Columns[0].Width;
            int widthText = dgv.Columns[1].Width;
            int widthScrollbar = customScrollbar.Width;

            using Graphics gfx = labelTitle.CreateGraphics();
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            int withTitle = (int)(gfx.MeasureString(
                txtTitle.Text + "___",
                dgv.RowTemplate.DefaultCellStyle.Font).Width + 0.5);

            if (withTitle > (widthIcon + widthText + widthScrollbar))
            {
                tableLayoutPanelDgvAndScrollbar.MinimumSize = new Size(withTitle, 0);
                dgv.Width = withTitle - widthScrollbar;
                dgv.Columns[1].Width = dgv.Width - widthIcon;
            }
            else
            {
                tableLayoutPanelDgvAndScrollbar.MinimumSize = new Size(widthIcon + widthText + widthScrollbar, 0);
                dgv.Width = widthIcon + widthText;
                dgv.Columns[1].Width = dgv.Width - widthIcon;
            }

            DataTable dataTable = (DataTable)dgv.DataSource;
            dataTable.DefaultView.RowFilter = RowFilterShowAll;
#endif
        }

#if TODO
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
#endif
        private void TextBoxSearch_TextChanged()
        {
#if TODO
            customScrollbar.Value = 0;

            DataTable data = (DataTable)dgv.DataSource;
#endif
            string filterField = nameof(ListViewItemData.ColumnText);
#if TODO
            SearchTextChanging?.Invoke();

            // Expression reference: https://docs.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?view=net-6.0
#endif
            // Instead implementing in-string wildcards, simply split into multiple search patters
            string searchString = textBoxSearch.Text.Trim()
                .Replace("%", " ")
                .Replace("*", " ");

            string searchStringReplaceSpecialCharacters = new(searchString);
            searchString = string.Empty;
            foreach (char character in searchStringReplaceSpecialCharacters)
            {
                searchString += character switch
                {
                    '[' => "[[]",
                    ']' => "[]]",
                    _ => character,
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

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            if (isSearchStringEmpty)
            {
                view.Filter = null;
            }
            else
            {
                view.Filter = SearchFilter;
                bool SearchFilter(object item)
                {
                    ListViewItemData row = (ListViewItemData)item;
                    return row.ColumnText.Contains(textBoxSearch.Text.Trim()); // TODO: THIS IS JUST TEMPORARY DUMMY FILTER (see below)
                }
            }
#if TODO
            try
            {
                if (Properties.Settings.Default.ShowOnlyAsSearchResult &&
                    isSearchStringEmpty)
                {
                    data.DefaultView.RowFilter = RowFilterShowAll;
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
                    if (rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult)
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

                if (!isSearchStringEmpty ||
                    !(rowData.IsAddionalItem && Properties.Settings.Default.ShowOnlyAsSearchResult))
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

            SearchTextChanged.Invoke(this, isSearchStringEmpty);

            if (anyIconNotUpdated)
            {
                timerUpdateIcons.Start();
            }

            if (dgv.Rows.Count > 0)
            {
                dgv.FirstDisplayedScrollingRowIndex = 0;
            }
#endif
        }
#if TODO

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
#endif

        private void PictureBoxOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            UserClickedOpenFolder?.Invoke();
        }

#if TODO
        private void PictureBoxMenuAlwaysOpen_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }
#endif
        private void PictureBoxMenuAlwaysOpen_Click(object sender, RoutedEventArgs e)
        {
            if (Config.AlwaysOpenByPin = !Config.AlwaysOpenByPin)
            {
                pictureBoxMenuAlwaysOpen.Source = (DrawingImage)Resources["ic_fluent_pin_48_filledDrawingImage"];
            }
            else
            {
                pictureBoxMenuAlwaysOpen.Source = (DrawingImage)Resources["ic_fluent_pin_48_regularDrawingImage"];
            }
        }

#if TODO
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
#endif
        private void PictureBoxSettings_MouseClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow.ShowSingleInstance();
        }

#if TODO
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
#endif
        private void PictureBoxRestart_MouseClick(object sender, RoutedEventArgs e)
        {
            AppRestart.ByMenuButton();
        }

#if TODO
        private void PictureBoxSearch_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            e.Graphics.DrawImage(AppColors.BitmapSearch, new Rectangle(Point.Empty, pictureBox.ClientSize));
        }
#endif
        private void TimerUpdateIcons_Tick(object? sender, EventArgs e)
        {
            int iconsToUpdate = 0;

            foreach (Menu.ListViewItemData row in dgv.Items)
            {
                RowData rowData = row.data;
                rowData.RowIndex = dgv.Items.IndexOf(row);

                if (rowData.IconLoading)
                {
                    iconsToUpdate++;
                    row.ColumnIcon = rowData.ReadIcon(false).ToImageSource();
                }
            }

            if (iconsToUpdate < 1)
            {
                timerUpdateIcons.Stop();
            }
            else
            {
                ((CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource)).Refresh();
            }
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Level == 0)
            {
                mouseDown = true;
                lastLocation = NativeMethods.Screen.CursorPosition;
                UserDragsMenu?.Invoke();
            }
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point mousePos = NativeMethods.Screen.CursorPosition;
                Left = Left + mousePos.X - lastLocation.X;
                Top = Top + mousePos.Y - lastLocation.Y;
                lastLocation = mousePos;

                Properties.Settings.Default.CustomLocationX = (int)Left;
                Properties.Settings.Default.CustomLocationY = (int)Top;
            }
        }

        private void Menu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            if (Properties.Settings.Default.UseCustomLocation)
            {
                if (!SettingsWindow.IsOpen())
                {
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            CellMouseEnter?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content));
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            CellMouseLeave?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content));
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CellMouseDown?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content), e);
        }

        private void ListViewItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CellMouseUp?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content), e);
            AdjustScrollbar();
        }

        private void ListViewxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Simulate missing MouseClick event
            CellMouseClick?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content), e);
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CellMouseDoubleClick?.Invoke(dgv, dgv.Items.IndexOf(((ListViewItem)sender).Content), e);
        }

        /// <summary>
        /// Type for ListView items.
        /// </summary>
        internal class ListViewItemData
        {
            public ListViewItemData(ImageSource columnIcon, string columnText, RowData rowData, int sortIndex)
            {
                ColumnIcon = columnIcon;
                ColumnText = columnText;
                data = rowData;
                SortIndex = sortIndex;
            }

            public ImageSource ColumnIcon { get; set; }

            public string ColumnText { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Benennungsstile", Justification = "Temporarily retained for compatibility reasons")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "Temporarily retained for compatibility reasons")]
            public RowData data { get; set; }

            public int SortIndex { get; set; }
        }

        private void textBoxSearch_TextInput(object sender, TextCompositionEventArgs e)
        {
            // TODO WPF
        }
    }
}
