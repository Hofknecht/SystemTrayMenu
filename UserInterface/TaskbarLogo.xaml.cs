// <copyright file="TaskbarLogo.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable enable

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    using SystemTrayMenu.DllImports;

    /// <summary>
    /// Logic of Taskbar window.
    /// </summary>
    public partial class TaskbarLogo : Window
    {
        private DispatcherTimer? moveOutOfScreenTimer = null;

        public TaskbarLogo()
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

                    ImagePictureBox.Source = imageSource;
                }
            }

            Icon = Imaging.CreateBitmapSourceFromHIcon(
                Config.GetAppIcon().Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            Title = myname;

            Closed += (_, _) => Application.Current.Shutdown();
            Deactivated += (_, _) => SetStateNormal();
            Activated += (_, _) =>
            {
                SetStateNormal();
                Activate();
                UpdateLayout();
                Focus();
                moveOutOfScreenTimer = new DispatcherTimer(
                    TimeSpan.FromMilliseconds(500),
                    DispatcherPriority.Loaded,
                    (s, e) =>
                    {
                        // Do this after loading because Top may be invalid at the beginning
                        // and when initial rendering is out of screen it will never be actually painted.
                        // This makes sure logo is rendered once and then window is moved.
                        Top += SystemParameters.VirtualScreenHeight;
                        ((DispatcherTimer)s!).IsEnabled = false; // only once
                    },
                    Dispatcher.CurrentDispatcher);
            };
        }

        /// <summary>
        /// This ensures that next click on taskbaritem works as activate event/click event.
        /// </summary>
        private void SetStateNormal()
        {
            if (IsActive)
            {
                WindowState = WindowState.Normal;
            }
        }
    }
}
