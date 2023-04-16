// <copyright file="UpdateWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.Helpers.Updater;

    /// <summary>
    /// Logic of Update window.
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();

            Assembly myassembly = Assembly.GetExecutingAssembly();
            string myname = myassembly.GetName().Name ?? string.Empty;

            using (Stream? imgstream = myassembly.GetManifestResourceStream(myname + ".Resources.SystemTrayMenu.png"))
            {
                if (imgstream != null)
                {
                    BitmapImage imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = imgstream;
                    imageSource.EndInit();

                    Icon = imageSource;
                }
            }

            label.Content = ((string)label.Content) + " " + GitHubUpdate.LatestVersionName;
        }

        private void ButtonGoToDownloadPage_Click(object sender, RoutedEventArgs e)
        {
            GitHubUpdate.WebOpenLatestRelease();
            Close();
        }
    }
}
