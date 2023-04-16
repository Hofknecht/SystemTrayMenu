// <copyright file="Menu.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.Utilities;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;

    /// <summary>
    /// Logic of Menu window.
    /// </summary>
    public partial class Menu : Window
    {
        private const int CornerRadius = 10;

        private static readonly RoutedEvent FadeInEvent = EventManager.RegisterRoutedEvent(
            nameof(FadeIn), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));

        private static readonly RoutedEvent FadeOutEvent = EventManager.RegisterRoutedEvent(
            nameof(FadeOut), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));

        private readonly string folderPath;
#if TODO // SEARCH
        public const string RowFilterShowAll = "[SortIndex] LIKE '%0%'";
#endif
        private bool isFading;
        private bool directionToRight;
        private bool mouseDown;
        private Point lastLocation;
#if TODO // SEARCH
        private bool isSetSearchText;
#endif
        private bool isClosed = false; // TODO WPF Replace Forms wrapper
        private DispatcherTimer timerUpdateIcons = new DispatcherTimer(DispatcherPriority.Render, Dispatcher.CurrentDispatcher);

        internal Menu(MenuData menuData, string path)
        {
            timerUpdateIcons.Tick += TimerUpdateIcons_Tick;
            Closed += (_, _) =>
            {
                timerUpdateIcons.Stop();
                isClosed = true; // TODO WPF Replace Forms wrapper
            };

            InitializeComponent();

            folderPath = path;
            RowDataParent = menuData.RowDataParent;
            Level = menuData.Level;
            if (Level == 0)
            {
                // Use Main Menu DPI for all further calculations
                Scaling.CalculateFactorByDpi(this);
            }
            else
            {
                // This will be a submenu
                if (RowDataParent != null)
                {
                    RowDataParent.SubMenu = this;
                }
            }

            string title = new DirectoryInfo(path).Name;
            if (title.Length > MenuDefines.LengthMax)
            {
                title = $"{title[..MenuDefines.LengthMax]}...";
            }

            txtTitle.Text = Title = title;

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
            labelStatus.FontSize = Scaling.ScaleFontByPoints(7F);
            dgv.FontSize = Scaling.ScaleFontByPoints(9F);

            MouseDown += Menu_MouseDown;
            MouseUp += Menu_MouseUp;
            MouseMove += Menu_MouseMove;


            textBoxSearch.ContextMenu = new()
            {
                Background = SystemColors.ControlBrush,
            };
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Cut"),
                Command = new ActionCommand((_) => textBoxSearch.Cut()),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Copy"),
                Command = new ActionCommand((_) => Clipboard.SetData(DataFormats.Text, textBoxSearch.SelectedText)),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Paste"),
                Command = new ActionCommand((_) =>
                    {
                        if (Clipboard.ContainsText(TextDataFormat.Text))
                        {
                            textBoxSearch.SelectedText = Clipboard.GetData(DataFormats.Text).ToString();
                        }
                    }),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Undo"),
                Command = new ActionCommand((_) => textBoxSearch.Undo()),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Select All"),
                Command = new ActionCommand((_) => textBoxSearch.SelectAll()),
            });

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
                Resources["ic_fluent_svgColor"] = WPFExtensions.SolidColorBrushFromString(Settings.Default.ColorDarkModeIcons);
            }
            else
            {
                Resources["ic_fluent_svgColor"] = WPFExtensions.SolidColorBrushFromString(Settings.Default.ColorIcons);
            }

            labelTitle.Foreground = foreColor;
            textBoxSearch.Foreground = foreColor;
            dgv.Foreground = foreColor;
            labelStatus.Foreground = MenuDefines.ColorIcons.ToSolidColorBrush();

            windowFrame.BorderBrush = backgroundBorder;
            windowFrame.Background = backColor;
            searchPanel.Background = backColorSearch;
            panelLine.Background = AppColors.Icons.ToSolidColorBrush();

            dgv.GotFocus += (_, _) => FocusTextBox();
#if TODO // Misc MouseEvents
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
            labelStatus.MouseEnter += ControlsMouseEnter;
            void ControlsMouseEnter(object sender, EventArgs e)
            {
                MouseEnter?.Invoke();
            }

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
            labelStatus.MouseLeave += ControlsMouseLeave;
            void ControlsMouseLeave(object sender, EventArgs e)
            {
                MouseLeave?.Invoke();
            }
#endif
#if TODO // TOUCH
            bool isTouchEnabled = NativeMethods.IsTouchEnabled();
            if ((isTouchEnabled && Settings.Default.DragDropItemsEnabledTouch) ||
                (!isTouchEnabled && Settings.Default.DragDropItemsEnabled))
            {
                AllowDrop = true;
                DragEnter += DragDropHelper.DragEnter;
                DragDrop += DragDropHelper.DragDrop;
            }
#endif

            Loaded += (sender, e) =>
                {
                    NativeMethods.HideFromAltTab(this);

                    RaiseEvent(new(routedEvent: FadeInEvent));
                };

            Closed += (sender, e) =>
                {
                    foreach (ListViewItemData item in dgv.Items)
                    {
                        item.data.SubMenu?.Close();
                    }
                };

            // This will be a submenu..
            if (Level > 0)
            {
                SetBehavior(menuData.DirectoryState);
            }
        }

        internal event Action? MenuScrolled;

#if TODO // Misc MouseEvents
        internal new event Action MouseEnter;

        internal new event Action MouseLeave;
#endif

        internal event Action<Menu, Key, ModifierKeys>? CmdKeyProcessed;

#if TODO // Misc MouseEvents and TOUCH
        internal event EventHandler<KeyPressEventArgs> KeyPressCheck;
#endif

        internal event Action? SearchTextChanging;

#if TODO // SEARCH
        internal event EventHandler<bool> SearchTextChanged;
#endif

        internal event Action? UserDragsMenu;

        internal event Action<ListView, int>? CellMouseEnter;

        internal event Action<ListView, int>? CellMouseLeave;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseDown;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseUp;

        internal event Action<ListView, int, MouseButtonEventArgs>? CellMouseClick;

        internal event RoutedEventHandler FadeIn
        {
            add { AddHandler(FadeInEvent, value); }
            remove { RemoveHandler(FadeInEvent, value); }
        }

        internal event RoutedEventHandler FadeOut
        {
            add { AddHandler(FadeOutEvent, value); }
            remove { RemoveHandler(FadeOutEvent, value); }
        }

        internal enum StartLocation
        {
            Predecessor,
            BottomLeft,
            BottomRight,
            TopRight,
        }

        public bool IsLoadingMenu { get; internal set; } // TODO State out of window

        public bool IsDisposed => isClosed; // TODO WPF Replace Forms wrapper

        public bool Disposing => isClosed; // TODO WPF Replace Forms wrapper

        public System.Drawing.Point Location => new System.Drawing.Point((int)Left, (int)Top); // TODO WPF Replace Forms wrapper)

        internal int Level { get; set; }

        internal RowData? RowDataParent { get; set; }

        internal bool IsUsable => Visibility == Visibility.Visible && !isFading && !IsDisposed && !Disposing;

#if TODO // TOUCH
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
        }

        internal void RefreshSearchText()
        {
            TextBoxSearch_TextChanged();
            if (dgv.Items.Count > 0)
            {
                dgv.ScrollIntoView(dgv.Items[0]);
            }
        }

        internal void FocusTextBox()
        {
#if TODO // SEARCH
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

        internal void SetBehavior(MenuDataDirectoryState state)
        {
            if (!Config.ShowDirectoryTitleAtTop)
            {
                txtTitle.Visibility = Visibility.Hidden;
            }

            if (!Config.ShowSearchBar)
            {
                searchPanel.Visibility = Visibility.Collapsed;
            }

            if (!(Config.ShowCountOfElementsBelow || state != MenuDataDirectoryState.Valid))
            {
                // Hide status when neither config is set nor an error message must be shown
                labelStatus.Visibility = Visibility.Collapsed;
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

            if (Level == 0)
            {
                // Main Menu
                textBoxSearch.TextChanged += (_, _) => TextBoxSearch_TextChanged();
            }
            else
            {
                // SubMenu
                buttonSettings.Visibility = Visibility.Collapsed;
                buttonRestart.Visibility = Visibility.Collapsed;

                switch (state)
                {
                    case MenuDataDirectoryState.Valid:
                        IsLoadingMenu = false;
                        textBoxSearch.TextChanged += (_, _) => TextBoxSearch_TextChanged();
                        buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                        buttonOpenFolder.Visibility = Visibility.Visible;
                        pictureBoxLoading.Visibility = Visibility.Collapsed;
                        break;
                    case MenuDataDirectoryState.Empty:
                        IsLoadingMenu = false;
                        searchPanel.Visibility = Visibility.Collapsed;
                        labelStatus.Content = Translator.GetText("Directory empty");
                        buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                        buttonOpenFolder.Visibility = Visibility.Visible;
                        pictureBoxLoading.Visibility = Visibility.Collapsed;
                        break;
                    case MenuDataDirectoryState.NoAccess:
                        IsLoadingMenu = false;
                        searchPanel.Visibility = Visibility.Collapsed;
                        labelStatus.Content = Translator.GetText("Directory inaccessible");
                        buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
                        buttonOpenFolder.Visibility = Visibility.Visible;
                        pictureBoxLoading.Visibility = Visibility.Collapsed;
                        break;
                    case MenuDataDirectoryState.Undefined:
                        IsLoadingMenu = true;
                        labelStatus.Content = Translator.GetText("loading");
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

        internal void RefreshDataGridView()
        {
            ((CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource)).Refresh();
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

        internal void ShowWithFade() => Fading_Show(false);

        internal void ShowTransparent() => Fading_Show(true);

        internal void Fading_Show(bool transparency)
        {
            timerUpdateIcons.Start();

            if (Level == 0)
            {
                Activate();
            }
            else
            {
                ShowActivated = false;
            }

            Opacity = 0D;
            Show();

            if (Settings.Default.UseFading)
            {
                isFading = true;
                if (transparency)
                {
                    // TODO: FADING: Instead setting of opacity 100% only go up to 80% (Temporarily go to 100% as well)
                    RaiseEvent(new(routedEvent: FadeInEvent));
                }
                else
                {
                    RaiseEvent(new(routedEvent: FadeInEvent));
                }
            }
            else
            {
                Opacity = transparency ? 0.80D : 1D;
                FadeIn_Completed(this, new());
            }
        }

        internal void HideWithFade()
        {
            if (Settings.Default.UseFading)
            {
                isFading = true;

                // TODO: FADING: Instead starting at opacity 100% it should start with 80% due to transparency setting
                RaiseEvent(new(routedEvent: FadeOutEvent));
            }
            else
            {
                FadeOut_Completed(this, new());
            }
        }

        internal void TimerUpdateIconsStart()
        {
            timerUpdateIcons.Start();
        }

        /// <summary>
        /// Update the position and size of the menu.
        /// </summary>
        /// <param name="bounds">Screen coordinates where the menu is allowed to be drawn in.</param>
        /// <param name="menuPredecessor">Predecessor menu (when available).</param>
        /// <param name="startLocation">Defines where the first menu is drawn (when no predecessor is set).</param>
        /// <param name="isCustomLocationOutsideOfScreen">isCustomLocationOutsideOfScreen.</param>
        internal void AdjustSizeAndLocation(
            Rect bounds,
            Menu? menuPredecessor,
            StartLocation startLocation,
            bool isCustomLocationOutsideOfScreen)
        {
            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();

            bool useCustomLocation = Settings.Default.UseCustomLocation || lastLocation.X > 0;
            bool changeDirectionWhenOutOfBounds = true;

            if (menuPredecessor != null)
            {
                // Ignore start as we use predecessor
                startLocation = StartLocation.Predecessor;
            }
            else if (useCustomLocation && !isCustomLocationOutsideOfScreen)
            {
                // Do not adjust location again because Cursor.Postion changed
                if (RowDataParent != null)
                {
                    return;
                }

                // Use this menu as predecessor and overwrite location with CustomLocation
                menuPredecessor = this;
                RowDataParent = new RowData();
                Left = Settings.Default.CustomLocationX;
                Top = Settings.Default.CustomLocationY;
                directionToRight = true;
                startLocation = StartLocation.Predecessor;
                changeDirectionWhenOutOfBounds = false;
            }
            else if (Settings.Default.AppearAtMouseLocation)
            {
                // Do not adjust location again because Cursor.Postion changed
                if (RowDataParent != null)
                {
                    return;
                }

                // Use this menu as predecessor and overwrite location with Cursor.Postion
                menuPredecessor = this;
                RowDataParent = new RowData();
                var position = Mouse.GetPosition(this);
                Left = position.X;
                Top = position.Y - labelTitle.Height;
                directionToRight = true;
                startLocation = StartLocation.Predecessor;
                changeDirectionWhenOutOfBounds = false;
            }

            if (IsLoaded)
            {
                AdjustSizeAndLocationInternal();
            }
            else
            {
                // Layout cannot be calculated during loading, postpone this event
                // TODO: Make sure lampa capture is registered only once
                Loaded += (_, _) => AdjustSizeAndLocationInternal();
            }

            void AdjustSizeAndLocationInternal()
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
                    !Settings.Default.AppearNextToPreviousMenu &&
                    menuPredecessor != null && menuPredecessor.Width > Settings.Default.OverlappingOffsetPixels)
                {
                    if (directionToRight)
                    {
                        x = x - menuPredecessor.Width + Settings.Default.OverlappingOffsetPixels;
                    }
                    else
                    {
                        x = x + menuPredecessor.Width - Settings.Default.OverlappingOffsetPixels;
                    }
                }

                // Calculate Y position
                double y;
                switch (startLocation)
                {
                    case StartLocation.Predecessor:

                        RowData trigger = RowDataParent;
                        ListView dgv = menuPredecessor!.GetDataGridView() !;

                        // Set position on same height as the selected row from predecessor
                        y = menuPredecessor.Location.Y;
                        if (dgv.Items.Count > trigger.RowIndex)
                        {
                            // When item is not found, it might be invalidated due to resizing or moving
                            // After updating the layout the location should be available again.
                            // It also makes sure all height and location information is up to date
                            menuPredecessor.UpdateLayout();

                            // When scrolled, we have to reduce the index number as we calculate based on visual tree
                            int startIndex = 0;
                            double offset = 0D;
                            ScrollViewer? scrollViewer = (VisualTreeHelper.GetChild(dgv, 0) as Decorator)?.Child as ScrollViewer;
                            if (scrollViewer != null)
                            {
                                startIndex = (int)scrollViewer.VerticalOffset;
                                if (trigger.RowIndex < startIndex)
                                {
                                    // calculate position above starting point
                                    for (int i = trigger.RowIndex; i < startIndex; i++)
                                    {
                                        ListViewItem? item = dgv.FindVisualChildOfType<ListViewItem>(i);
                                        if (item != null)
                                        {
                                            offset -= item.ActualHeight;
                                        }
                                    }
                                }
                            }

                            if (startIndex < trigger.RowIndex)
                            {
                                // calculate position below starting point
                                for (int i = startIndex; i < trigger.RowIndex; i++)
                                {
                                    ListViewItem? item = dgv.FindVisualChildOfType<ListViewItem>(i);
                                    if (item != null)
                                    {
                                        offset += item.ActualHeight;
                                    }
                                }
                            }

                            if (offset < 0)
                            {
                                // Do not allow to show window higher than previous window
                                offset = 0;
                            }
                            else
                            {
                                double offsetList = menuPredecessor.GetRelativeChildPositionTo(dgv).Y;
                                offsetList += dgv.ActualHeight;
                                if (offsetList < offset)
                                {
                                    // Do not allow to show window below last entry position of list
                                    offset = offsetList;
                                }
                            }

                            y += (int)offset;
                        }

                        if (searchPanel.Visibility == Visibility.Collapsed)
                        {
                            y += menuPredecessor.searchPanel.ActualHeight;
                        }

                        // Move vertically when out of bounds
                        if (bounds.Y + bounds.Height < y + Height)
                        {
                            y = bounds.Y + bounds.Height - Height;
                        }
                        else if (y < bounds.Y)
                        {
                            y = bounds.Y;
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

                if (Settings.Default.RoundCorners)
                {
                    windowFrame.CornerRadius = new CornerRadius(CornerRadius);
                }

                UpdateLayout();
            }
        }

        internal void SetCounts(int foldersCount, int filesCount)
        {
            int filesAndFoldersCount = foldersCount + filesCount;
            string elements = filesAndFoldersCount == 1 ? "element" : "elements";
            labelStatus.Content = $"{filesAndFoldersCount} {Translator.GetText(elements)}";
        }

        private void FadeIn_Completed(object sender, EventArgs e)
        {
            isFading = false;
        }

        private void FadeOut_Completed(object sender, EventArgs e)
        {
            isFading = false;
            Hide();
        }

        private void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            searchPanel.Visibility = Visibility.Visible;

            ModifierKeys modifiers = Keyboard.Modifiers;
            switch (e.Key)
            {
                case Key.F4:
                    if (modifiers != ModifierKeys.Alt)
                    {
                        return;
                    }

                    break;
                case Key.F:
                    if (modifiers != ModifierKeys.Control)
                    {
                        return;
                    }

                    break;
                case Key.Tab:
                    if ((modifiers != ModifierKeys.Shift) && (modifiers != ModifierKeys.None))
                    {
                        return;
                    }

                    break;
                case Key.Enter:
                case Key.Home:
                case Key.End:
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                case Key.Escape:
                case Key.Apps:
                    if (modifiers != ModifierKeys.None)
                    {
                        return;
                    }

                    break;
                default:
                    return;
            }

            CmdKeyProcessed?.Invoke(this, e.Key, modifiers);
            e.Handled = true;
        }

        private void AdjustDataGridViewHeight(Menu? menuPredecessor, double screenHeightMax)
        {
            double factor = Settings.Default.RowHeighteInPercentage / 100f;
            if (NativeMethods.IsTouchEnabled())
            {
                factor = Settings.Default.RowHeighteInPercentageTouch / 100f;
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

            double heightMaxByOptions = Scaling.Factor * Scaling.FactorByDpi *
                450f * (Settings.Default.HeightMaxInPercent / 100f);
            MaxHeight = Math.Min(screenHeightMax, heightMaxByOptions);
        }

        private void AdjustDataGridViewWidth()
        {
            if (!string.IsNullOrEmpty(textBoxSearch.Text))
            {
                return;
            }

            double factorIconSizeInPercent = Settings.Default.IconSizeInPercent / 100f;

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

            Resources["ColumnTextWidth"] = Math.Min(
                renderedMaxWidth,
                (double)(Scaling.Factor * Scaling.FactorByDpi * 400f * (Settings.Default.WidthMaxInPercent / 100f)));
        }

        private void HandleScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (IsLoaded)
            {
                MenuScrolled?.Invoke();
            }
        }

#if TODO // Misc MouseEvents and TOUCH
        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressCheck?.Invoke(sender, e);
        }
#endif
        private void TextBoxSearch_TextChanged()
        {
            SearchTextChanging?.Invoke();

            string? userPattern = textBoxSearch.Text?.Replace("%", " ").Replace("*", " ").ToLower();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            if (string.IsNullOrEmpty(userPattern))
            {
                view.Filter = null;
            }
            else
            {
                // Instead implementing in-string wildcards, simply split into multiple search patters
                view.Filter = (object item) =>
                {
                    // Look for each space separated string if it is part of an entries text (case insensitive)
                    ListViewItemData row = (ListViewItemData)item;
                    foreach (string pattern in userPattern.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!row.ColumnText.ToLower().Contains(pattern))
                        {
                            return false;
                        }
                    }

                    return true;
                };
            }

#if TODO // SEARCH
            DataTable data = (DataTable)dgv.DataSource;
            string columnSortIndex = "SortIndex";
            if (string.IsNullOrEmpty(userPattern))
            {
                foreach (DataRow row in data.Rows)
                {
                    RowData rowData = (RowData)row[2];
                    if (rowData.IsAddionalItem && Settings.Default.ShowOnlyAsSearchResult)
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

                if (!string.IsNullOrEmpty(userPattern) ||
                    !(rowData.IsAddionalItem && Settings.Default.ShowOnlyAsSearchResult))
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

            SearchTextChanged.Invoke(this, string.IsNullOrEmpty(userPattern));

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

#if TODO // Misc MouseEvents and BorderColors
        private void PictureBoxOpenFolder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (pictureBox.Tag != null && (bool)pictureBox.Tag)
            {
                Rectangle rowBounds = new(0, 0, pictureBox.Width, pictureBox.Height);
                ControlPaint.DrawBorder(e.Graphics, rowBounds, MenuDefines.ColorSelectedItemBorder, ButtonBorderStyle.Solid);
            }
        }
#endif

        private void PictureBoxOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            Menus.OpenFolder(folderPath);
        }

#if TODO // BorderColors
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

#if TODO // BorderColors
        private void PictureBoxSettings_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

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

#if TODO // BorderColors
        private void PictureBoxRestart_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

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
                    rowData.ReadIcon(false);
                    if (rowData.Icon != null)
                    {
                        row.ColumnIcon = rowData.Icon.ToImageSource();
                    }
                }
            }

            if (iconsToUpdate < 1)
            {
                timerUpdateIcons.Stop();
            }
            else
            {
                RefreshDataGridView();
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

                Settings.Default.CustomLocationX = (int)Left;
                Settings.Default.CustomLocationY = (int)Top;
            }
        }

        private void Menu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            if (Settings.Default.UseCustomLocation)
            {
                if (!SettingsWindow.IsOpen())
                {
                    Settings.Default.Save();
                }
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            CellMouseEnter?.Invoke(dgv, dgv.IndexOfSenderItem((ListViewItem)sender));
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            CellMouseLeave?.Invoke(dgv, dgv.IndexOfSenderItem((ListViewItem)sender));
        }

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CellMouseDown?.Invoke(dgv, dgv.IndexOfSenderItem((ListViewItem)sender), e);
        }

        private void ListViewItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CellMouseUp?.Invoke(dgv, dgv.IndexOfSenderItem((ListViewItem)sender), e);
        }

        private void ListViewxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CellMouseClick?.Invoke(dgv, dgv.IndexOfSenderItem((ListViewItem)sender), e);
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
