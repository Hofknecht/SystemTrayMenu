// <copyright file="KeyboardHook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Windows.Forms;
    using SystemTrayMenu.UserInterface.HotkeyTextboxControl;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum KeyboardHookModifierKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8,
    }

    public sealed class KeyboardHook : IDisposable
    {
        private readonly Window window = new();
        private int currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            window.KeyPressed += Window_KeyPressed;
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        internal event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = currentId; i > 0; i--)
            {
                DllImports.NativeMethods.User32UnregisterHotKey(window.Handle, i);
            }

            // dispose the inner native window.
            window.KeyPressed -= Window_KeyPressed;
            window.Dispose();
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        internal void RegisterHotKey(Keys key)
        {
            uint keyModifiersNone = 0;
            RegisterHotKey(keyModifiersNone, key);
        }

        internal void RegisterHotKey()
        {
            KeyboardHookModifierKeys modifiers = KeyboardHookModifierKeys.None;
            string modifiersString = Properties.Settings.Default.HotKey;
            if (!string.IsNullOrEmpty(modifiersString))
            {
                if (modifiersString.ToUpperInvariant().Contains("ALT", StringComparison.InvariantCulture))
                {
                    modifiers |= KeyboardHookModifierKeys.Alt;
                }

                if (modifiersString.ToUpperInvariant().Contains("CTRL", StringComparison.InvariantCulture) ||
                    modifiersString.ToUpperInvariant().Contains("STRG", StringComparison.InvariantCulture))
                {
                    modifiers |= KeyboardHookModifierKeys.Control;
                }

                if (modifiersString.ToUpperInvariant().Contains("SHIFT", StringComparison.InvariantCulture))
                {
                    modifiers |= KeyboardHookModifierKeys.Shift;
                }

                if (modifiersString.ToUpperInvariant().Contains("WIN", StringComparison.InvariantCulture))
                {
                    modifiers |= KeyboardHookModifierKeys.Win;
                }
            }

            RegisterHotKey(
                modifiers,
                HotkeyControl.HotkeyFromString(
                    Properties.Settings.Default.HotKey));
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        internal void RegisterHotKey(KeyboardHookModifierKeys modifier, Keys key)
        {
            RegisterHotKey((uint)modifier, key);
        }

        private void Window_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            KeyPressed?.Invoke(this, e);
        }

        private void RegisterHotKey(uint modifier, Keys key)
        {
            currentId += 1;

            if (!DllImports.NativeMethods.User32RegisterHotKey(
                window.Handle, currentId, modifier, (uint)key))
            {
                throw new InvalidOperationException(
                    Translator.GetText("Could not register the hot key."));
            }
        }

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private const int WmHotkey = 0x0312;

            public Window()
            {
                // create the handle for the window.
                CreateHandle(new CreateParams());
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            public void Dispose()
            {
                DestroyHandle();
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m">m.</param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WmHotkey)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    KeyboardHookModifierKeys modifier = (KeyboardHookModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }
        }
    }
}
