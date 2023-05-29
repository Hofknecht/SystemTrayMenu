// <copyright file="GlobalHotkeys.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Utilities;

    internal static class GlobalHotkeys
    {
        private static readonly HwndSourceHook Hook = new (WndProc);
        private static readonly Window Window = new();
        private static readonly HwndSource HWnd;

        private static readonly List<HotkeyRegistration> Registrations = new();
        private static readonly object CriticalSectionLock = new();

        static GlobalHotkeys()
        {
            HWnd = HwndSource.FromHwnd(new WindowInteropHelper(Window).EnsureHandle());
            HWnd.AddHook(Hook);
        }

        internal interface IHotkeyRegistration
        {
            event Action<IHotkeyRegistration>? KeyPressed;

            ModifierKeys GetModifierKeys();

            Key GetKey();
        }

        /// <summary>
        /// Gets or sets a value indicating whether hotkeys are enabled
        /// (e.g. during user configuration dialog).
        /// </summary>
        internal static bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Registers a global hotkey.
        /// Function is thread safe.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey major key.</param>
        /// <returns>Registration interface.</returns>
        internal static IHotkeyRegistration Register(ModifierKeys modifiers, Key key)
        {
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            int id = 0;

            lock (CriticalSectionLock)
            {
                foreach (var reg in Registrations)
                {
                    if (id <= reg.Id)
                    {
                        id = reg.Id + 1; // TODO: Rework to re-use gaps
                    }
                }

                if (!NativeMethods.User32RegisterHotKey(HWnd.Handle, id, (uint)modifiers, (uint)virtualKeyCode))
                {
                    string errorHint = NativeMethods.GetLastErrorHint();
                    throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
                }
            }

            HotkeyRegistration registration = new()
            {
                Id = id,
                Modifiers = modifiers,
                Key = key,
            };
            Registrations.Add(registration);
            return registration;
        }

        /// <summary>
        /// Registers a global hotkey.
        /// Function is thread safe.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="hotKeyString">Hotkey string representation.</param>
        /// <returns>Registration interface.</returns>
        internal static IHotkeyRegistration Register(string hotKeyString)
        {
            var (modifiers, key) = ParseKeysAndModifiersFromString(hotKeyString);
            return Register(modifiers, key);
        }

        /// <summary>
        /// Unregisters a global hotkey in a thread safe manner.
        /// Function is thread safe.
        /// </summary>
        /// <param name="registration">Registration interface.</param>
        /// <returns>true: Success or false: Failure.</returns>
        internal static bool Unregister(IHotkeyRegistration? registration)
        {
            if (registration == null || registration is not HotkeyRegistration reg || !Registrations.Contains(reg))
            {
                return true;
            }

            lock (CriticalSectionLock)
            {
                if (!NativeMethods.User32UnregisterHotKey(HWnd.Handle, reg.Id))
                {
                    return false;
                }

                Registrations.Remove(reg);
            }

            return true;
        }

        internal static bool Reassign(IHotkeyRegistration? registration, ModifierKeys modifiers, Key key)
        {
            if (registration == null || registration is not HotkeyRegistration reg || !Registrations.Contains(reg))
            {
                return false;
            }

            if (modifiers == reg.Modifiers && key == reg.Key)
            {
                return true; // Yes, nothing changed, but we return true as requested key is properly registered even when unchanged.
            }

            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            int id = 0;

            lock (CriticalSectionLock)
            {
                foreach (var regs in Registrations)
                {
                    if (id <= regs.Id)
                    {
                        id = reg.Id + 1; // TODO: Rework to re-use gaps
                    }
                }

                if (!NativeMethods.User32RegisterHotKey(HWnd.Handle, id, (uint)modifiers, (uint)virtualKeyCode))
                {
                    string errorHint = NativeMethods.GetLastErrorHint();
                    throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
                }

                // In case unregister failes, unfortunately registration remains
                // but will not trigger anything as we change our hotkey registration.
                // However, this means the hotkey keeps being registered with this application
                // and the key combination will not be availalbe for re-registration till app restart.
                // TODO: Decide how to handle this? Restart App? Try keep old registartion and not update it?
                if (!NativeMethods.User32UnregisterHotKey(HWnd.Handle, reg.Id))
                {
                    Log.Info("Hotkey registration cannot unregister key " + reg.Modifiers.ToString() + " with modifiers " + reg.Modifiers.ToString());
                }

                reg.Id = id;
                reg.Modifiers = modifiers;
                reg.Key = key;
            }

            return true;
        }

        internal static bool Reassign(IHotkeyRegistration? registration, string hotKeyString)
        {
            var (modifiers, key) = ParseKeysAndModifiersFromString(hotKeyString);
            return Reassign(registration, modifiers, key);
        }

        // TODO: Instead of searching for the registration, it should be passed to the caller instead.
        //       Only this ensures caller and registrator are talking about the SAME registration.
        internal static IHotkeyRegistration? FindRegistration(string hotKeyString)
        {
            var (modifiers, key) = ParseKeysAndModifiersFromString(hotKeyString);

            lock (CriticalSectionLock)
            {
                foreach (var registration in Registrations)
                {
                    if (modifiers == registration.Modifiers && key == registration.Key)
                    {
                        return registration;
                    }
                }
            }

            return null;
        }

        internal static ModifierKeys ModifierKeysFromString(string modifiersString)
        {
            ModifierKeys modifiers = ModifierKeys.None;
            string upper = modifiersString.ToUpperInvariant();

            if (upper.Contains("ALT+", StringComparison.InvariantCulture))
            {
                modifiers |= ModifierKeys.Alt;
            }

            if (upper.Contains("CTRL+", StringComparison.InvariantCulture) ||
                upper.Contains("STRG+", StringComparison.InvariantCulture))
            {
                modifiers |= ModifierKeys.Control;
            }

            if (upper.Contains("SHIFT+", StringComparison.InvariantCulture))
            {
                modifiers |= ModifierKeys.Shift;
            }

            // LWin and RWin keys will implicitly set Windows key modifier
            if (upper.Contains("WIN+", StringComparison.InvariantCulture) ||
                upper.EndsWith("LWIN", StringComparison.InvariantCulture) ||
                upper.EndsWith("RWIN", StringComparison.InvariantCulture))
            {
                modifiers |= ModifierKeys.Windows;
            }

            return modifiers;
        }

        internal static Key KeyFromString(string keyString)
        {
            Key key = Key.None;
            if (!string.IsNullOrEmpty(keyString))
            {
                if (keyString.LastIndexOf('+') > 0)
                {
                    keyString = keyString.Remove(0, keyString.LastIndexOf('+') + 1).Trim();
                }

                keyString = keyString.
                    Replace("PgDn", "PageDown", StringComparison.InvariantCulture).
                    Replace("PgUp", "PageUp", StringComparison.InvariantCulture);
                if (!Enum.TryParse(keyString, true, out key))
                {
                    Log.Warn($"{keyString} cannot be parsed", new());
                }
            }

            return key;
        }

        internal static string HotkeyToLocalizedString(ModifierKeys modifiers, Key key)
        {
            StringBuilder hotkeyString = new();
            if ((modifiers & ModifierKeys.Alt) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftAlt)).Append(" + ");
            }

            if ((modifiers & ModifierKeys.Control) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftCtrl)).Append(" + ");
            }

            if ((modifiers & ModifierKeys.Shift) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftShift)).Append(" + ");
            }

            if ((modifiers & ModifierKeys.Windows) != 0)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString() + GetKeyName(key);
        }

        private static string GetKeyName(Key key)
        {
            const uint MAPVK_VK_TO_VSC = 0;
            const uint KF_EXTENDED = 0x100;
            const uint SCANCODE_SIMULATED = 0x200;
            const uint scanCodeNumPad = 0x37;
            const uint scanCodePause = 0x45;

            StringBuilder keyName = new(100);
            string keyString = string.Empty;

            switch (key)
            {
                case Key.Multiply:
                    if (NativeMethods.User32GetKeyNameText(scanCodeNumPad << 16, keyName, keyName.Capacity) > 0)
                    {
                        keyString = keyName.ToString().Replace("*", string.Empty, StringComparison.InvariantCulture).Trim().ToLowerInvariant();
                        if (keyString.Contains('('))
                        {
                            return "* " + keyString;
                        }

                        keyString = keyString[..1].ToUpperInvariant() + keyString[1..].ToLowerInvariant();
                    }

                    return keyString + " *";
                case Key.Divide:
                    if (NativeMethods.User32GetKeyNameText(scanCodeNumPad << 16, keyName, keyName.Capacity) > 0)
                    {
                        keyString = keyName.ToString().Replace("*", string.Empty, StringComparison.InvariantCulture).Trim().ToLowerInvariant();
                        if (keyString.Contains('('))
                        {
                            return "/ " + keyString;
                        }

                        keyString = keyString[..1].ToUpperInvariant() + keyString[1..].ToLowerInvariant();
                    }

                    return keyString + " /";
            }

            // Converting Windows Input Key Enums into Virtual-Key Codes into Scan Codes into Text
            // - Windows Input Key Enums: https://learn.microsoft.com/en-us/dotnet/api/system.windows.input.key?view=windowsdesktop-7.0
            // - Virtual-Key Codes:       https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
            // - Scan Codes:              https://learn.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input#scan-codes
            uint virtualKeyCode = (uint)KeyInterop.VirtualKeyFromKey(key);
            uint scanCode = NativeMethods.User32MapVirtualKey(virtualKeyCode, MAPVK_VK_TO_VSC);

            // Handle names of some special keys
            switch (key)
            {
                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down: // arrow keys
                case Key.Prior:
                case Key.Next: // page up and page down
                case Key.End:
                case Key.Home:
                case Key.Insert:
                case Key.Delete:
                case Key.NumLock:
                    scanCode |= KF_EXTENDED; // set extended bit (simulate origin from enhanced 101/102-key keyboard)
                    break;
                case Key.PrintScreen:
                    scanCode = KF_EXTENDED | scanCodeNumPad;
                    break;
                case Key.Pause:
                    scanCode = scanCodePause;
                    break;
            }

            scanCode |= SCANCODE_SIMULATED;
            if (NativeMethods.User32GetKeyNameText(scanCode << 16, keyName, keyName.Capacity) != 0)
            {
                string visibleName = keyName.ToString();
                if (visibleName.Length > 1)
                {
                    visibleName = visibleName[..1] + visibleName[1..].ToLowerInvariant();
                }

                return visibleName;
            }
            else
            {
                return key.ToString();
            }
        }

        private static (ModifierKeys, Key) ParseKeysAndModifiersFromString(string hotKeyString) => (ModifierKeysFromString(hotKeyString), KeyFromString(hotKeyString));

        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WmHotkey = 0x0312;

            // check if we got a hot key pressed.
            if (msg == WmHotkey && IsEnabled)
            {
                ModifierKeys modifiers = (ModifierKeys)((int)lParam & 0xFFFF);
                int virtualKeyCode = ((int)lParam >> 16) & 0xFFFF;
                Key key = KeyInterop.KeyFromVirtualKey(virtualKeyCode);

                HotkeyRegistration? reg = null;
                lock (CriticalSectionLock)
                {
                    foreach (var registration in Registrations)
                    {
                        if (modifiers == registration.Modifiers && key == registration.Key)
                        {
                            reg = registration;
                            break;
                        }
                    }
                }

                reg?.OnKeyPressed();
            }

            handled = false;
            return IntPtr.Zero;
        }

        private class HotkeyRegistration : IHotkeyRegistration
        {
            public event Action<IHotkeyRegistration>? KeyPressed;

            internal int Id { get; set; }

            internal ModifierKeys Modifiers { get; set; }

            internal Key Key { get; set; }

            public ModifierKeys GetModifierKeys() => Modifiers;

            public Key GetKey() => Key;

            internal void OnKeyPressed() => KeyPressed?.Invoke(this);
        }
    }
}
