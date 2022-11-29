// <copyright file="ColorSelector.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable enable

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Logic of ColorSelector .
    /// </summary>
    public partial class ColorSelector : UserControl
    {
        public ColorSelector()
        {
            InitializeComponent();
            label.Content = string.Empty;
        }

        public event Action<ColorSelector>? ColorChanged;

        public string Text
        {
            get
            {
                try
                {
                    Color color = (Color)ColorConverter.ConvertFromString(txtbox.Text.Trim());
                    return txtbox.Text.Trim();
                }
                catch
                {
                    return Colors.White.ToString();
                }
            }

            set
            {
                txtbox.Text = value;
            }
        }

        public string Description
        {
            get => (string)label.Content;
            set => label.Content = value ?? string.Empty;
        }

        private void Txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Color color = (Color)ColorConverter.ConvertFromString(txtbox.Text.Trim());
                pane.Background = new SolidColorBrush(color);
            }
            catch
            {
                return;
            }

            ColorChanged?.Invoke(this);
        }

#if TODO // ColorPicker
        private void PictureBoxClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            TextBox textBox = (TextBox)pictureBox.Tag;
            colorDialog.Color = pictureBox.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = ColorTranslator.ToHtml(colorDialog.Color);
                pictureBox.BackColor = colorDialog.Color;
            }
        }
#endif
    }
}
