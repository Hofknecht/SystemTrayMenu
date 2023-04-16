// <copyright file="KeyPressedEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    internal class KeyPressedEventArgs : EventArgs
    {
        private readonly Key key;

        internal KeyPressedEventArgs(KeyboardHookModifierKeys modifier, Key key)
        {
            Modifier = modifier;
            this.key = key;
        }

        internal KeyboardHookModifierKeys Modifier { get; }

        internal Key Key => key;
    }
}
