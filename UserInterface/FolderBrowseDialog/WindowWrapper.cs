﻿// <copyright file="WindowWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface.FolderBrowseDialog
{
    using System;
    using System.Windows.Interop;

    public class WindowWrapper : IWin32Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowWrapper"/> class.
        /// </summary>
        /// <param name="handle">Handle to wrap.</param>
        public WindowWrapper(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Gets original ptr.
        /// </summary>
        public IntPtr Handle { get; }
    }
}
