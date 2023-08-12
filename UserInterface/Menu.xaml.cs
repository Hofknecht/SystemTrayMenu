// <copyright file="Menu.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
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

        private static readonly RoutedEvent FadeToTransparentEvent = EventManager.RegisterRoutedEvent(
            nameof(FadeToTransparent), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));

        private static readonly RoutedEvent FadeInEvent = EventManager.RegisterRoutedEvent(
            nameof(FadeIn), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));

        private static readonly RoutedEvent FadeOutEvent = EventManager.RegisterRoutedEvent(
            nameof(FadeOut), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));

        private readonly string folderPath;

        private bool isShellContextMenuOpen;
        private bool directionToRight;
        private Point lastLocation;

        internal Menu(RowData? rowDataParent, string path)
        {
            InitializeComponent();

            if (!Config.ShowDirectoryTitleAtTop)
            {
                txtTitle.Visibility = Visibility.Hidden;
            }

            if (!Config.ShowSearchBar)
            {
                searchPanel.Visibility = Visibility.Collapsed;
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

            folderPath = path;
            RowDataParent = rowDataParent;
            if (RowDataParent == null)
            {
                // This will be a main menu
                Level = 0;
                MainMenu = this;

                // Use Main Menu DPI for all further calculations
                Scaling.CalculateFactorByDpi(this);

                // Moving the window is only supported for the main menu
                MouseDown += MainMenu_MoveStart;
            }
            else
            {
                // This will be a sub menu
                if (ParentMenu == null)
                {
                    // Should never happen as each parent menu must have a valid entry which's owner is set
                    throw new ArgumentNullException(new (nameof(ParentMenu)));
                }

                Level = RowDataParent.Level + 1;
                MainMenu = ParentMenu.MainMenu;
                RowDataParent.SubMenu = this;

                buttonOpenFolder.Visibility = Visibility.Collapsed;
                buttonSettings.Visibility = Visibility.Collapsed;
                buttonRestart.Visibility = Visibility.Collapsed;
                pictureBoxLoading.Visibility = Visibility.Visible;
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

            textBoxSearch.TextChanged += (_, _) => TextBoxSearch_TextChanged(false);
            textBoxSearch.ContextMenu = new()
            {
                Background = SystemColors.ControlBrush,
            };
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("To cut out"),
                Command = new ActionCommand((_) => textBoxSearch.Cut()),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("Copy"),
                Command = new ActionCommand((_) => Clipboard.SetData(DataFormats.Text, textBoxSearch.SelectedText)),
            });
            textBoxSearch.ContextMenu.Items.Add(new MenuItem()
            {
                Header = Translator.GetText("To paste"),
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
                Header = Translator.GetText("Selecting All"),
                Command = new ActionCommand((_) => textBoxSearch.SelectAll()),
            });

            dgv.SelectionChanged += ListView_SelectionChanged;
            ((INotifyCollectionChanged)dgv.Items).CollectionChanged += (_, _) =>
            {
                int count = dgv.Items.Count;
                labelStatus.Content = count.ToString() + " " + Translator.GetText(count == 1 ? "element" : "elements");
            };

            Loaded += (_, _) =>
            {
                NativeMethods.HideFromAltTab(this);

                RaiseEvent(new(routedEvent: FadeInEvent));

                FocusTextBox();
            };

            Closed += (_, _) =>
            {
                if (RowDataParent?.SubMenu == this)
                {
                    RowDataParent.SubMenu = null;
                }

                foreach (RowData item in dgv.Items)
                {
                    item.SubMenu?.Close();
                }
            };
        }

        internal event Action<RowData>? StartLoadSubMenu;

        internal event Action? MenuScrolled;

        internal event Action<Menu, Key, ModifierKeys>? CmdKeyProcessed;

        internal event Action? SearchTextChanging;

        internal event Action<Menu, bool, bool>? SearchTextChanged;

        internal event Action<RowData>? RowSelectionChanged;

        internal event Action<RowData>? CellMouseEnter;

        internal event Action? CellMouseLeave;

        internal event Action<RowData>? CellMouseDown;

        internal event Action<RowData>? CellOpenOnClick;

        internal event RoutedEventHandler FadeToTransparent
        {
            add { AddHandler(FadeToTransparentEvent, value); }
            remove { RemoveHandler(FadeToTransparentEvent, value); }
        }

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
            Point,
            Predecessor,
            BottomLeft,
            BottomRight,
            TopRight,
        }

        internal Point Location => new (Left, Top); // TODO WPF Replace Forms wrapper

        internal int Level { get; set; }

        internal RowData? RowDataParent { get; set; }

        internal RowData? SelectedItem
        {
            get => (RowData?)dgv.SelectedItem;
            set => dgv.SelectedItem = value;
        }

        internal Menu MainMenu { get; private set; }

        internal Menu? ParentMenu => RowDataParent?.Owner;

        internal Menu? SubMenu
        {
            get
            {
                foreach (RowData rowData in dgv.Items)
                {
                    if (rowData.SubMenu != null)
                    {
                        return rowData.SubMenu;
                    }
                }

                return null;
            }
        }

        internal bool RelocateOnNextShow { get; set; } = true;

        public override string ToString() => nameof(Menu) + " L" + Level.ToString() + ": " + Title;

        internal void RiseItemOpened(RowData item) => CellOpenOnClick?.Invoke(item);

        internal void RiseStartLoadSubMenu(RowData rowData) => StartLoadSubMenu?.Invoke(rowData);

        internal void ResetSearchText()
        {
            textBoxSearch.Text = string.Empty;
            if (dgv.Items.Count > 0)
            {
                dgv.ScrollIntoView(dgv.Items[0]);
            }
        }

        internal void OnWatcherUpdate()
        {
            TextBoxSearch_TextChanged(true);
            if (dgv.Items.Count > 0)
            {
                dgv.ScrollIntoView(dgv.Items[0]);
            }
        }

        internal void FocusTextBox()
        {
            textBoxSearch.Select(textBoxSearch.Text.Length, 0);
            textBoxSearch.Focus();
        }

        internal void SetSubMenuState(MenuDataDirectoryState state)
        {
            if (Config.ShowFunctionKeyOpenFolder)
            {
                buttonOpenFolder.Visibility = Visibility.Visible;
            }

            buttonMenuAlwaysOpen.Visibility = Visibility.Collapsed;
            pictureBoxLoading.Visibility = Visibility.Collapsed;

            switch (state)
            {
                case MenuDataDirectoryState.Valid:
                    if (!Config.ShowCountOfElementsBelow)
                    {
                        labelStatus.Visibility = Visibility.Collapsed;
                    }

                    break;
                case MenuDataDirectoryState.Empty:
                    searchPanel.Visibility = Visibility.Collapsed;
                    labelStatus.Content = Translator.GetText("Directory empty");
                    break;
                case MenuDataDirectoryState.NoAccess:
                    searchPanel.Visibility = Visibility.Collapsed;
                    labelStatus.Content = Translator.GetText("Directory inaccessible");
                    break;
                default:
                    break;
            }
        }

        // TODO: Check if we can just use original IsMouseOver instead?  (Check if it requires Mouse.Capture(this))
        internal new bool IsMouseOver()
        {
            Point mousePos = NativeMethods.Screen.CursorPosition;
            bool isMouseOver = Visibility == Visibility.Visible &&
                mousePos.X >= 0 && mousePos.X < Width &&
                mousePos.Y >= 0 && mousePos.Y < Height;
            return isMouseOver;
        }

        internal ListView GetDataGridView() => dgv; // TODO WPF Replace Forms wrapper

        // Not used as refreshing should be done automatically due to databinding
        // TODO: As long as WPF transition from Forms is incomplete, keep it for testing.
        internal void RefreshDataGridView()
        {
            ((CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource)).Refresh();
        }

        // TODO: Check if it is implicitly already running due to SelectionChanged event
        //       In case it is needed, run it within HideWithFade/ShowWithFade?
        internal void RefreshSelection() => ListView_SelectionChanged(GetDataGridView(), null);

        internal bool TrySelectAt(int index, int indexAlternative = -1)
        {
            RowData itemData;
            if (index >= 0 && dgv.Items.Count > index)
            {
                itemData = (RowData)dgv.Items[index];
            }
            else if (indexAlternative >= 0 && dgv.Items.Count > indexAlternative)
            {
                itemData = (RowData)dgv.Items[indexAlternative];
            }
            else
            {
                return false;
            }

            dgv.SelectedItem = itemData;
            dgv.ScrollIntoView(itemData);

            RowSelectionChanged?.Invoke(itemData);

            return true;
        }

        internal void AddItemsToMenu(List<RowData> data, MenuDataDirectoryState? state)
        {
            for (int index = 0; index < data.Count; index++)
            {
                RowData rowData = data[index];
                rowData.RowIndex = index;
                rowData.Owner = this;
                rowData.SortIndex = rowData.IsAdditionalItem && Settings.Default.ShowOnlyAsSearchResult ? 99 : 0;
            }

            dgv.ItemsSource = data;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            view.Filter = (object item) => Filter_Default((RowData)item);

            if (state != null)
            {
                SetSubMenuState(state.Value);
            }
        }

        internal void ActivateWithFade(bool recursive)
        {
            if (recursive)
            {
                SubMenu?.ActivateWithFade(true);
            }

            if (Opacity != 1D)
            {
                if (Settings.Default.UseFading)
                {
                    RaiseEvent(new(routedEvent: FadeInEvent));
                }
                else
                {
                    Opacity = 1D;
                }
            }
        }

        internal void ShowWithFade(bool transparency, bool recursive)
        {
            if (recursive)
            {
                SubMenu?.ShowWithFade(transparency, true);
            }

            if (Level > 0)
            {
                ShowActivated = false;
            }

            Opacity = 0D;
            Show();

            if (!Settings.Default.UseFading)
            {
                Opacity = transparency ? 0.80D : 1D;
            }
            else if (transparency)
            {
                RaiseEvent(new(routedEvent: FadeToTransparentEvent));
            }
            else
            {
                RaiseEvent(new(routedEvent: FadeInEvent));
            }
        }

        internal void HideAllMenus()
        {
            // Find main menu and close/hide all
            Menu menu = this;
            while (menu.ParentMenu != null)
            {
                menu = menu.ParentMenu;
            }

            menu.HideWithFade(true);
        }

        internal void HideWithFade(bool recursive)
        {
            if (recursive)
            {
                SubMenu?.HideWithFade(true);
            }

            if (RowDataParent != null)
            {
                RowDataParent.SubMenu = null;
            }

            if (Settings.Default.UseFading)
            {
                RaiseEvent(new(routedEvent: FadeOutEvent));
            }
            else
            {
                FadeOut_Completed(this, new());
            }
        }

        /// <summary>
        /// Update the position and size of the menu.
        /// </summary>
        /// <param name="bounds">Screen coordinates where the menu is allowed to be drawn in.</param>
        /// <param name="menuPredecessor">Predecessor menu (when available).</param>
        /// <param name="startLocation">Defines where the first menu is drawn (when no predecessor is set).</param>
        /// <param name="useCustomLocation">Use CustomLocation as start position.</param>
        internal void AdjustSizeAndLocation(
            Rect bounds,
            Menu? menuPredecessor,
            StartLocation startLocation,
            bool useCustomLocation)
        {
            Point originLocation = new(0D, 0D);

            // Update the height and width
            AdjustDataGridViewHeight(menuPredecessor, bounds.Height);
            AdjustDataGridViewWidth();

            if (Level > 0)
            {
                if (menuPredecessor == null)
                {
                    // should never happen
                    return;
                }

                // Sub Menu location depends on the location of its predecessor
                startLocation = StartLocation.Predecessor;
                originLocation = menuPredecessor.Location;
            }
            else if (useCustomLocation)
            {
                if (!RelocateOnNextShow)
                {
                    return;
                }

                RelocateOnNextShow = false;
                startLocation = StartLocation.Point;
                originLocation = new(Settings.Default.CustomLocationX, Settings.Default.CustomLocationY);
            }
            else if (Settings.Default.AppearAtMouseLocation)
            {
                if (!RelocateOnNextShow)
                {
                    return;
                }

                RelocateOnNextShow = false;
                startLocation = StartLocation.Point;
                originLocation = NativeMethods.Screen.CursorPosition;
            }

            if (IsLoaded)
            {
                AdjustWindowPositionInternal(originLocation);
            }
            else
            {
                // Layout cannot be calculated during loading, postpone this event
                Loaded += (_, _) => AdjustWindowPositionInternal(originLocation);
            }

            void AdjustWindowPositionInternal(in Point originLocation)
            {
                double scaling = Math.Round(Scaling.Factor, 0, MidpointRounding.AwayFromZero);
                double overlappingOffset = 0D;

                // Make sure we have latest values of own window size
                UpdateLayout();

                // Prepare parameters
                if (startLocation == StartLocation.Predecessor)
                {
                    if (menuPredecessor == null)
                    {
                        // should never happen
                        return;
                    }

                    // When (later in calculation) a list item is not found,
                    // its values might be invalidated due to resizing or moving.
                    // After updating the layout the location should be available again.
                    menuPredecessor.UpdateLayout();

                    directionToRight = menuPredecessor.directionToRight; // try keeping same direction from predecessor

                    if (!Settings.Default.AppearNextToPreviousMenu &&
                        menuPredecessor.Width > Settings.Default.OverlappingOffsetPixels)
                    {
                        if (directionToRight)
                        {
                            overlappingOffset = Settings.Default.OverlappingOffsetPixels - menuPredecessor.Width;
                        }
                        else
                        {
                            overlappingOffset = menuPredecessor.Width - Settings.Default.OverlappingOffsetPixels;
                        }
                    }
                }
                else
                {
                    directionToRight = true; // use right as default direction
                }

                // Calculate X position
                double x;
                switch (startLocation)
                {
                    case StartLocation.Point:
                        x = originLocation.X;
                        break;
                    case StartLocation.Predecessor:
                        if (menuPredecessor == null)
                        {
                            // should never happen
                            return;
                        }

                        if (directionToRight)
                        {
                            x = originLocation.X + menuPredecessor.Width - scaling;

                            // Change direction when out of bounds (predecessor only)
                            if (startLocation == StartLocation.Predecessor &&
                                bounds.X + bounds.Width <= x + Width - scaling)
                            {
                                x = originLocation.X - Width + scaling;
                                if (x < bounds.X &&
                                    originLocation.X + menuPredecessor.Width < bounds.X + bounds.Width &&
                                    bounds.X + (bounds.Width / 2) > originLocation.X + (Width / 2))
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
                            x = originLocation.X - Width + scaling;

                            // Change direction when out of bounds (predecessor only)
                            if (startLocation == StartLocation.Predecessor &&
                                x < bounds.X)
                            {
                                x = originLocation.X + menuPredecessor.Width - scaling;
                                if (x + Width > bounds.X + bounds.Width &&
                                    originLocation.X > bounds.X &&
                                    bounds.X + (bounds.Width / 2) < originLocation.X + (Width / 2))
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

                x += overlappingOffset;

                // Calculate Y position
                double y;
                switch (startLocation)
                {
                    case StartLocation.Point:
                        y = originLocation.Y;
                        if (Settings.Default.AppearAtMouseLocation)
                        {
                            y -= labelTitle.ActualHeight; // Mouse should point below title
                        }

                        break;
                    case StartLocation.Predecessor:
                        if (menuPredecessor == null)
                        {
                            // should never happen
                            return;
                        }

                        y = originLocation.Y;

                        // Set position on same height as the selected row from predecessor
                        ListView dgv = menuPredecessor.GetDataGridView()!;
                        RowData? trigger = RowDataParent;
                        if (trigger != null && dgv.Items.Count > trigger.RowIndex)
                        {
                            // When scrolled, we have to reduce the index number as we calculate based on visual tree
                            int startIndex = 0;
                            double offset = 0D;
                            if (VisualTreeHelper.GetChild(dgv, 0) is Decorator { Child: ScrollViewer scrollViewer })
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

                            y += offset;
                        }

                        if (searchPanel.Visibility == Visibility.Collapsed)
                        {
                            y += menuPredecessor.searchPanel.ActualHeight;
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

                // Move vertically when out of bounds
                if (bounds.Y + bounds.Height < y + Height)
                {
                    y = bounds.Y + bounds.Height - Height;
                }
                else if (y < bounds.Y)
                {
                    y = bounds.Y;
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

        private void FadeOut_Completed(object sender, EventArgs e) => Hide();

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
                    // 2px less due to subtracted boarder around list view item
                    double rowHeightDefault = 21.24d * Scaling.FactorByDpi;
                    Resources["RowHeight"] = (double)(int)((rowHeightDefault * factor * Scaling.Factor) + 0.5d - 2.0d);
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

            // IcoWidth 100% = 21px, 175% is 33
            double icoWidth = 16 * Scaling.FactorByDpi;
            Resources["ColumnIconWidth"] = (double)(int)((icoWidth * factorIconSizeInPercent * Scaling.Factor) + 0.5);

            double renderedMaxWidth = 0D;
            foreach (RowData item in dgv.Items)
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

        private bool Filter_Default(RowData itemData)
        {
            if (Settings.Default.ShowOnlyAsSearchResult && itemData.IsAdditionalItem)
            {
                return false;
            }

            return true;
        }

        private bool Filter_ByUserPattern(RowData itemData, string userPattern)
        {
            // Instead implementing in-string wildcards, simply split into multiple search pattersy
            // Look for each space separated string if it is part of an entry's text (case insensitive)
            foreach (string pattern in userPattern.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
            {
                if (!itemData.ColumnText.ToLower().Contains(pattern))
                {
                    return false;
                }
            }

            return true;
        }

        private void TextBoxSearch_TextChanged(bool causedByWatcherUpdate)
        {
            SearchTextChanging?.Invoke();

            string? userPattern = textBoxSearch.Text?.Replace("%", " ").Replace("*", " ").ToLower();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            if (string.IsNullOrEmpty(userPattern))
            {
                SizeToContent = SizeToContent.WidthAndHeight;
                view.Filter = (object item) => Filter_Default((RowData)item);
            }
            else
            {
                SizeToContent = SizeToContent.Manual;
                view.Filter = (object item) => Filter_ByUserPattern((RowData)item, userPattern);
            }

            SearchTextChanged?.Invoke(this, string.IsNullOrEmpty(userPattern), causedByWatcherUpdate);
        }

        private void PictureBoxOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            Menus.OpenFolder(folderPath);
        }

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

        private void PictureBoxSettings_MouseClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow.ShowSingleInstance();
        }

        private void PictureBoxRestart_MouseClick(object sender, RoutedEventArgs e)
        {
            AppRestart.ByMenuButton();
        }

        private void MainMenu_MoveStart(object sender, MouseButtonEventArgs e)
        {
            // Hide all sub menus to clear the view for repositioning of the main menu
            if (SubMenu != null)
            {
                SubMenu?.HideWithFade(true);
                RefreshSelection();
            }

            lastLocation = NativeMethods.Screen.CursorPosition;
            MouseMove += MainMenu_MoveRelocate;
            MouseUp += MainMenu_MoveEnd;
            Deactivated += MainMenu_MoveEnd;
            Mouse.Capture(this);
        }

        private void MainMenu_MoveRelocate(object sender, MouseEventArgs e)
        {
            Point mousePos = NativeMethods.Screen.CursorPosition;
            Left = Left + mousePos.X - lastLocation.X;
            Top = Top + mousePos.Y - lastLocation.Y;
            lastLocation = mousePos;

            Settings.Default.CustomLocationX = (int)Left;
            Settings.Default.CustomLocationY = (int)Top;
        }

        private void MainMenu_MoveEnd(object? sender, EventArgs? e)
        {
            Mouse.Capture(null);
            MouseMove -= MainMenu_MoveRelocate;
            MouseUp -= MainMenu_MoveEnd;
            Deactivated -= MainMenu_MoveEnd;

            if (Settings.Default.UseCustomLocation)
            {
                if (!SettingsWindow.IsOpen())
                {
                    Settings.Default.Save();
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs? e)
        {
            if (e != null)
            {
                foreach (RowData itemData in e.AddedItems)
                {
                    itemData.IsSelected = true;
                    itemData.UpdateColors();
                }

                foreach (RowData itemData in e.RemovedItems)
                {
                    itemData.IsSelected = false;
                    itemData.UpdateColors();
                }
            }
            else
            {
                // TODO: Refactor item selection to prevent running this loop
                ListView lv = (ListView)sender;
                foreach (RowData itemData in lv.Items)
                {
                    itemData.IsSelected = lv.SelectedItem == itemData;
                    itemData.UpdateColors();
                }
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isShellContextMenuOpen)
            {
                CellMouseEnter?.Invoke((RowData)((ListViewItem)sender).Content);
            }
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isShellContextMenuOpen)
            {
                CellMouseLeave?.Invoke();
            }
        }

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RowData itemData = (RowData)((ListViewItem)sender).Content;

            CellMouseDown?.Invoke(itemData);

            if (e.RightButton == MouseButtonState.Pressed)
            {
                // Somehow when the TrackPopupMenuEx is called to spawn the context menu
                // This will fire a MouseEnter event on the next item, like WTF?!
                // Prevent any use of MouseEnter/MouseLeave while the menu is open.
                // TODO: Find root case and fix this properly.
                isShellContextMenuOpen = true;
                var position = Mouse.GetPosition(this);
                position.Offset(Left, Top);
                itemData.OpenShellContextMenu(position);
                isShellContextMenuOpen = false;
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
            ((RowData)((ListViewItem)sender).Content).OpenItem(e.ClickCount);
    }
}
