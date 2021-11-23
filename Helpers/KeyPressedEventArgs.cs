// <copyright file="KeyPressedEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    internal class KeyPressedEventArgs : EventArgs
    {
        private readonly Keys key;

        internal KeyPressedEventArgs(KeyboardHookModifierKeys modifier, Keys key)
        {
            Modifier = modifier;
            this.key = key;
        }

        internal KeyboardHookModifierKeys Modifier { get; }

        internal Keys Key => key;
    }
}
