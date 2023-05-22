// <copyright file="KeyboardHook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Windows.Input;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.UserInterface.HotkeyTextboxControl;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.Utilities.FormsExtensions;

    public sealed class KeyboardHook : IDisposable
    {
        private readonly Window window = new();
        private int currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            window.KeyPressed += (key, modifiers) => KeyPressed?.Invoke(key, modifiers);
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        internal event Action<Key, ModifierKeys>? KeyPressed;

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = currentId; i > 0; i--)
            {
                NativeMethods.User32UnregisterHotKey(window.Handle, i);
            }

            // dispose the inner native window.
            window.Dispose();
        }

        internal void RegisterHotKey(string hotKeyString)
        {
            // TODO: Replace old code of v1 with HotKeyControl methods like here
            //       as there is a bug in the body of this function (missing "+" when checking for modifiers)
            ModifierKeys modifiers = HotkeyControl.HotkeyModifiersFromString(hotKeyString);
            Key hotkey = HotkeyControl.HotkeyFromString(hotKeyString);

            RegisterHotKey((uint)modifiers, hotkey);
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        private void RegisterHotKey(uint modifier, Key key)
        {
            currentId += 1;

            if (!NativeMethods.User32RegisterHotKey(window.Handle, currentId, modifier, (uint)key))
            {
                string errorHint = NativeMethods.GetLastErrorHint();
                throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
            }
        }

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private const int WmHotkey = 0x0312;

            public event Action<Key, ModifierKeys>? KeyPressed;

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                // check if we got a hot key pressed.
                if (msg == WmHotkey)
                {
                    // get the keys.
                    Key key = (Key)(((int)lParam >> 16) & 0xFFFF);
                    ModifierKeys modifiers = (ModifierKeys)((int)lParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    KeyPressed?.Invoke(key, modifiers);
                }

                handled = false;
                return IntPtr.Zero;
            }
        }
    }
}
