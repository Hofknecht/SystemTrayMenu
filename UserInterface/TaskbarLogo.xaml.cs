// <copyright file="TaskbarLogo.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.Resources;

    /// <summary>
    /// Logic of Taskbar window.
    /// </summary>
    public partial class TaskbarLogo : Window
    {
        public TaskbarLogo()
        {
            InitializeComponent();

            Assembly myassembly = Assembly.GetExecutingAssembly();
            string myname = myassembly.GetName().Name ?? string.Empty;

            ImagePictureBox.Source = StaticResources.ApplicationImgSrc;
            Icon = Imaging.CreateBitmapSourceFromHIcon(
                Config.GetAppIcon().Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            Title = myname;

            Closed += (_, _) => Application.Current.Shutdown();
            ContentRendered += MoveOutOfScreen;
        }

        private void MoveOutOfScreen(object? sender, EventArgs e)
        {
            // Do this only once
            ContentRendered -= MoveOutOfScreen;
            Top += SystemParameters.VirtualScreenHeight;
        }
    }
}
