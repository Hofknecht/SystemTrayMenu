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
