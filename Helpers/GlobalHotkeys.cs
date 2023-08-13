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

            string GetHotkeyInvariantString();

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

        internal static (ModifierKeys Modifiers, Key Key) ModifiersAndKeyFromInvariantString(string hotKeyString)
        {
            if (string.IsNullOrEmpty(hotKeyString))
            {
                return (ModifierKeys.None, Key.None);
            }

            string? modifiersString;
            string keyString;
            if (hotKeyString.Contains('+'))
            {
                modifiersString = hotKeyString[..hotKeyString.LastIndexOf('+')];
                keyString = hotKeyString[(hotKeyString.LastIndexOf('+') + 1)..];
            }
            else
            {
                modifiersString = null;
                keyString = hotKeyString;
            }

            ModifierKeys modifiers = ModifierKeys.None;
            Key key;
            try
            {
                if (modifiersString != null)
                {
                    modifiers = (ModifierKeys?)new ModifierKeysConverter().ConvertFromInvariantString(modifiersString) ?? ModifierKeys.None;
                }

                key = (Key?)new KeyConverter().ConvertFromInvariantString(keyString) ?? Key.None;
            }
            catch (Exception ex)
            {
                Log.Info("Could not parse key and modifiers for \"" + hotKeyString + "\" with modifiers. Cause: " + ex.Message);
                return (ModifierKeys.None, Key.None);
            }

            if (key == Key.LWin || key == Key.RWin)
            {
                // It seems we have to add the Windows modifier when the major key is a Windows key
                modifiers |= ModifierKeys.Windows;
            }

            return (modifiers, key);
        }

        internal static string ModifiersAndKeyToInvariantString(ModifierKeys modifiers, Key key)
        {
            string? keyString = null;
            string? modifiersString = null;

            if (modifiers != ModifierKeys.None)
            {
                modifiersString = new ModifierKeysConverter().ConvertToInvariantString(modifiers);
            }

            if (key != Key.None)
            {
                keyString = new KeyConverter().ConvertToInvariantString(key);
            }

            if (string.IsNullOrEmpty(modifiersString) && string.IsNullOrEmpty(keyString))
            {
                return string.Empty;
            }
            else if (string.IsNullOrEmpty(modifiersString))
            {
                return keyString!;
            }
            else if (string.IsNullOrEmpty(keyString))
            {
                return modifiersString;
            }

            return modifiersString + "+" + keyString;
        }

        // Should be same as ModifiersAndKeyToInvariantString() just with non-Invariant convertion
        // but the converters seems not to convert every key into a user firendly string,
        // so we use old fashioned native Windows API to fetch the localized strings.
        internal static string ModifiersAndKeyToString(ModifierKeys modifiers, Key key)
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

            return key == Key.None ? hotkeyString.ToString().Replace(" + ", string.Empty) : hotkeyString.ToString() + GetKeyName(key);
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

        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WmHotkey = 0x0312;

            // check if we got a hot key pressed.
            if (msg == WmHotkey && IsEnabled)
            {
                // If actual keys are required without looking at regisrations
                // e.g. when multiple key combination are registered for one registration
                // one can get the values as of this example below:
                //     ModifierKeys modifiers = (ModifierKeys)((int)lParam & 0xFFFF);
                //     int virtualKeyCode = ((int)lParam >> 16) & 0xFFFF;
                //     Key key = KeyInterop.KeyFromVirtualKey(virtualKeyCode);
                HotkeyRegistration? reg;
                lock (CriticalSectionLock)
                {
                    Registrations.TryGetValue((int)wParam, out reg);
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

            public ModifierKeys GetModifierKeys() => Registration?.Modifiers ?? ModifierKeys.None;

            public Key GetKey() => Registration?.Key ?? Key.None;

            public string GetHotkeyInvariantString() => ModifiersAndKeyToInvariantString(GetModifierKeys(), GetKey());

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
                var (modifiers, key) = ModifiersAndKeyFromInvariantString(hotKeyString);
                Register(modifiers, key);
            }

            public void Unregister()
            {
                if (Registration != null)
                {
                    GlobalHotkeys.Unregister(Registration);
                    Registration = null;
                }
            }
        }
    }
}
