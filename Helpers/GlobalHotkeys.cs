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

        private static readonly Dictionary<int, HotkeyRegistration> Registrations = new();
        private static readonly object CriticalSectionLock = new();

        private static IHotkeyFunction? lastCreatedHotkeyFunction; // TODO: Remove this hack! See: GetLastCreatedHotkeyFunction

        static GlobalHotkeys()
        {
            HWnd = HwndSource.FromHwnd(new WindowInteropHelper(Window).EnsureHandle());
            HWnd.AddHook(Hook);
        }

        internal interface IHotkeyFunction
        {
            event Action<IHotkeyFunction>? KeyPressed;

            ModifierKeys GetModifierKeys();

            Key GetKey();

            void Register(ModifierKeys modifiers, Key key);

            void Register(string hotKeyString);

            void Unregister();
        }

        /// <summary>
        /// Gets or sets a value indicating whether hotkeys are enabled
        /// (e.g. during user configuration dialog).
        /// </summary>
        internal static bool IsEnabled { get; set; } = true;

        internal static IHotkeyFunction Create() => lastCreatedHotkeyFunction = new HotkeyFunction();

        // TODO: Instead of searching for the registration, it should be passed to the caller instead.
        //       Only this ensures caller and registrator are talking about the SAME registration.
        internal static IHotkeyFunction? GetLastCreatedHotkeyFunction() => lastCreatedHotkeyFunction;

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
                    foreach (var (id, registration) in Registrations)
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

        /// <summary>
        /// Registers a global hotkey.
        /// Function is thread safe.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call Unregister to free up ressources.
        /// </summary>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey major key.</param>
        /// <returns>Hotkey registration.</returns>
        private static HotkeyRegistration Register(ModifierKeys modifiers, Key key)
        {
            HotkeyRegistration registration;
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            int id = 0;

            lock (CriticalSectionLock)
            {
                while (Registrations.ContainsKey(id))
                {
                    id++;
                }

                if (!NativeMethods.User32RegisterHotKey(HWnd.Handle, id, (uint)modifiers, (uint)virtualKeyCode))
                {
                    string errorHint = NativeMethods.GetLastErrorHint();
                    throw new InvalidOperationException(Translator.GetText("Could not register the hot key.") + " (" + errorHint + ")");
                }

                registration = new()
                {
                    Id = id,
                    Modifiers = modifiers,
                    Key = key,
                };
                Registrations.Add(id, registration);
            }

            return registration;
        }

        /// <summary>
        /// Unregisters a global hotkey.
        /// Function is thread safe.
        /// </summary>
        /// <param name="registration">Hotkey registration.</param>
        private static void Unregister(HotkeyRegistration registration)
        {
            lock (CriticalSectionLock)
            {
                if (Registrations.ContainsValue(registration))
                {
                    if (!NativeMethods.User32UnregisterHotKey(HWnd.Handle, registration.Id))
                    {
                        Log.Info("Hotkey registration cannot unregister key " + registration.Modifiers.ToString() + " with modifiers " + registration.Modifiers.ToString());
                    }

                    // In case unregister failes, unfortunately registration remains
                    // but will not trigger anything as we remove the hotkey registration.
                    // However, this means the hotkey keeps being registered with this application
                    // and the key combination will not be availalbe for re-registration till app restart.
                    // TODO: Decide how to handle this? Restart App? Try keep old registartion and not update it?
                    Registrations.Remove(registration.Id);
                }
            }
        }

        /// <summary>
        /// Registers a new global hotkey and unregisters the old one.
        /// Function is thread safe.
        /// Throws an InvalidOperationException on error.
        /// The caller needs to call Unregister to free up ressources in case a new registration is returned.
        /// </summary>
        /// <param name="registration">Old hotkey registration.</param>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey key.</param>
        /// <returns>New hotkey registration or null (nothing changed).</returns>
        private static HotkeyRegistration? Reassign(HotkeyRegistration registration, ModifierKeys modifiers, Key key)
        {
            if (!Registrations.ContainsValue(registration) ||
                (modifiers == registration.Modifiers && key == registration.Key))
            {
                // Either registration is not valid or
                // nothing would as requested key is already properly registered.
                return null;
            }

            HotkeyRegistration reg = Register(modifiers, key);
            Unregister(registration);
            return reg;
        }

        private class HotkeyRegistration
        {
            public event Action? KeyPressed;

            internal int Id { get; init; }

            internal ModifierKeys Modifiers { get; init; }

            internal Key Key { get; init; }

            internal void OnKeyPressed() => KeyPressed?.Invoke();
        }

        private class HotkeyFunction : IHotkeyFunction
        {
            public event Action<IHotkeyFunction>? KeyPressed;

            internal HotkeyRegistration? Registration { get; set; }

            public void Unregister()
            {
                if (Registration != null)
                {
                    GlobalHotkeys.Unregister(Registration);
                    Registration = null;
                }
            }

            public ModifierKeys GetModifierKeys() => Registration?.Modifiers ?? ModifierKeys.None;

            public Key GetKey() => Registration?.Key ?? Key.None;

            public void Register(ModifierKeys modifiers, Key key)
            {
                if (Registration == null)
                {
                    Registration = GlobalHotkeys.Register(modifiers, key);
                    Registration.KeyPressed += () => KeyPressed?.Invoke(this);
                }
                else
                {
                    HotkeyRegistration? reg = Reassign(Registration, modifiers, key);
                    if (reg != null)
                    {
                        Registration = reg;
                        Registration.KeyPressed += () => KeyPressed?.Invoke(this);
                    }
                }
            }

            public void Register(string hotKeyString)
            {
                var (modifiers, key) = ParseKeysAndModifiersFromString(hotKeyString);
                Register(modifiers, key);
            }
        }
    }
}
