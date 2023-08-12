// <copyright file="HowToOpenSettingsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System.Windows;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// Logic of HowToOpenSettings window.
    /// </summary>
    public partial class HowToOpenSettingsWindow : Window
    {
        public HowToOpenSettingsWindow()
        {
            InitializeComponent();

            // TODO: Find a way to escape ' within inline single quotes markup string in XAML
            checkBoxDontShowThisHintAgain.Content = Translator.GetText("Don't show this hint again.");
        }

        internal bool DoNotShowAgain => checkBoxDontShowThisHintAgain.IsChecked ?? false;

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
