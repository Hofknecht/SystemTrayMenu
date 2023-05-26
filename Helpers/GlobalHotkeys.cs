// <copyright file="GlobalHotkeys.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023-2023 Peter Kirmeier

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Text;
    using System.Windows.Input;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Utilities;

    internal static class GlobalHotkeys
    {
        private static readonly object LastIdLock = new();
        private static int lastId = 0;

        /// <summary>
        /// Registers a global hotkey in a thread safe manner.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="hWnd">Window handle receiving the events.</param>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey major key.</param>
        /// <returns>ID of registered key.</returns>
        internal static int RegisterHotkeyGlobal(IntPtr hWnd, ModifierKeys modifiers, Key key)
        {
            lock (LastIdLock)
            {
                lastId = RegisterHotkeyLocal(hWnd, lastId + 1, modifiers, key);
            }

            return lastId;
        }

        /// <summary>
        /// Registers a global hotkey in a thread safe manner.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="hWnd">Window handle receiving the events.</param>
        /// <param name="hotKeyString">Hotkey string description.</param>
        /// <returns>ID of registered key.</returns>
        internal static int RegisterHotkeyGlobal(IntPtr hWnd, string hotKeyString)
        {
            ModifierKeys modifiers = ModifierKeysFromString(hotKeyString);
            Key key = KeyFromString(hotKeyString);
            return RegisterHotkeyGlobal(hWnd, modifiers, key);
        }

        /// <summary>
        /// Registers a local hotkey (with given ID).
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="hWnd">Window handle receiving the events.</param>
        /// <param name="id">ID for the registration.</param>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey major key.</param>
        /// <returns>ID of registered key.</returns>
        internal static int RegisterHotkeyLocal(IntPtr hWnd, int id, ModifierKeys modifiers, Key key)
        {
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            if (!NativeMethods.User32RegisterHotKey(hWnd, id, (uint)modifiers, (uint)virtualKeyCode))
            {
                string errorHint = NativeMethods.GetLastErrorHint();
                throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
            }

            return id;
        }

        /// <summary>
        /// Registers a local hotkey (with given ID).
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call UnregisterHotkey to free up ressources.
        /// </summary>
        /// <param name="hWnd">Window handle receiving the events.</param>
        /// <param name="id">ID for the registration.</param>
        /// <param name="hotKeyString">Hotkey string description.</param>
        /// <returns>ID of registered key.</returns>
        internal static int RegisterHotkeyLocal(IntPtr hWnd, int id, string hotKeyString)
        {
            ModifierKeys modifiers = ModifierKeysFromString(hotKeyString);
            Key key = KeyFromString(hotKeyString);
            return RegisterHotkeyLocal(hWnd, id, modifiers, key);
        }

        /// <summary>
        /// Unregisters a local or global hotkey.
        /// </summary>
        /// <param name="hWnd">Window handle.</param>
        /// <param name="id">ID for the registration.</param>
        internal static void UnregisterHotkey(IntPtr hWnd, int id) => NativeMethods.User32UnregisterHotKey(hWnd, id);

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
    }
}
