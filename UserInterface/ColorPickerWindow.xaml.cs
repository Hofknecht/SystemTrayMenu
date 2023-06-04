// <copyright file="ColorPickerWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Logic of ColorPickerWindow.xaml .
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        internal ColorPickerWindow(string description, Color initialColor)
        {
            InitializeComponent();

            if (Config.IsDarkMode())
            {
                ResourceDictionary resDict = new ();
                resDict.Source = new Uri("pack://application:,,,/ColorPicker;component/Styles/DefaultColorPickerStyle.xaml", UriKind.RelativeOrAbsolute);
                picker.Style = (Style)resDict["DefaultColorPickerStyle"];
            }

            Loaded += (_, _) =>
            {
                MinWidth = ActualWidth;
                MinHeight = ActualHeight;

                // Issue: Placement of picker child elements incorrect.
                //        Beyond initial layout updates it requires to have a fixed size set.
                //        But this will force us to manually update on resize events.
                // Workaround: Remove the fixed values and witch back to automatic size calculation afterwards.
                SizeChanged += UnsetSize;
                void UnsetSize(object sender, RoutedEventArgs e)
                {
                    SizeChanged -= UnsetSize;
                    picker.Width = double.NaN;
                    picker.Height = double.NaN;
                }
            };

            picker.SelectedColor = picker.SecondaryColor = initialColor;
            lblDescription.Content = description;
        }

        public Color SelectedColor => picker.SelectedColor;

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
