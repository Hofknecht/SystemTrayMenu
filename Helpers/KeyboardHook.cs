// <copyright file="KeyboardHook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    internal class KeyboardHook : IDisposable
    {
        private readonly HwndSourceHook hook;
        private readonly HwndSource hwnd;
        private readonly Window window = new(); // TODO: Try using mainMenu to spare creating additional Win32 window handle?
        private int currentId;

        public KeyboardHook()
        {
            hwnd = HwndSource.FromHwnd(new WindowInteropHelper(window).EnsureHandle());
            hook = new HwndSourceHook(WndProc);
            hwnd.AddHook(hook);
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        internal event Action<Key, ModifierKeys>? KeyPressed;

        public void Dispose()
        {
            // On regular App.Dispose the handle was already invalidated
            if (hwnd.Handle != IntPtr.Zero)
            {
                // unregister all the registered hot keys.
                for (int i = currentId; i > 0; i--)
                {
                    NativeMethods.User32UnregisterHotKey(hwnd.Handle, i);
                }

                hwnd.RemoveHook(hook);
            }

            hwnd.Dispose();
        }

        internal void RegisterHotKey(string hotKeyString)
        {
            ModifierKeys modifiers = HotkeyControl.HotkeyModifiersFromString(hotKeyString);
            Key key = HotkeyControl.HotkeyFromString(hotKeyString);
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            int nextId = currentId + 1;

            if (!NativeMethods.User32RegisterHotKey(hwnd.Handle, nextId, (uint)modifiers, (uint)virtualKeyCode))
            {
                string errorHint = NativeMethods.GetLastErrorHint();
                throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
            }

            currentId = nextId;
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WmHotkey = 0x0312;

            // check if we got a hot key pressed.
            if (msg == WmHotkey)
            {
                // get the keys.
                ModifierKeys modifiers = (ModifierKeys)((int)lParam & 0xFFFF);
                int virtualKeyCode = ((int)lParam >> 16) & 0xFFFF;
                Key key = KeyInterop.KeyFromVirtualKey(virtualKeyCode);

                // invoke the event to notify the parent.
                KeyPressed?.Invoke(key, modifiers);
            }

            handled = false;
            return IntPtr.Zero;
        }
    }
}
