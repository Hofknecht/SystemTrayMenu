// <copyright file="TaskbarLogo.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Reflection;
    using System.Windows;

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
            Title = myname;

            Closed += (_, _) => Application.Current.Shutdown();

            // Do final initialization after rendering has been finished for the first time.
            // This ensures all icons and images are properly loaded and renderd (e.g. thumbnail image of alt tab menu).
            ContentRendered += LateInitialize;
        }

        private void LateInitialize(object? sender, EventArgs e)
        {
            // Do this only once
            ContentRendered -= LateInitialize;

            // Move the window out of screen, just for safety
            Top += SystemParameters.VirtualScreenHeight;

            // There is nothing to see, so no need to show this window.
            // Therefore it shall always be in minimized state.
            // Further, we then can rely on every activating event.
            WindowState = WindowState.Minimized;
            StateChanged += (_, _) => WindowState = WindowState.Minimized;
        }
    }
}
