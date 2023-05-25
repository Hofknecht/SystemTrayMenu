// <copyright file="HotkeyControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Input;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// A simple control that allows the user to select pretty much any valid hotkey combination
    /// See: http://www.codeproject.com/KB/buttons/hotkeycontrol.aspx
    /// But is modified to fit in Greenshot, and have localized support.
    /// Modfied to fit SystemTrayMenu.
    /// </summary>
    public sealed class HotkeyControl : TextBox
    {
        private static readonly IntPtr HotkeyHwnd = (IntPtr)0x0000000000000000;

        // Holds the list of hotkeys
        private static readonly IDictionary<int, Action> KeyHandlers = new Dictionary<int, Action>();
        private static int hotKeyCounter = 1;

        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly IList<int> needNonShiftModifier = new List<int>();
        private readonly IList<int> needNonAltGrModifier = new List<int>();

        // These variables store the current hotkey and modifier(s)
        private Key hotkey = Key.None;
        private ModifierKeys modifiers = ModifierKeys.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyControl"/> class.
        /// </summary>
        public HotkeyControl()
        {
            // Disable right-clicking
            ContextMenu = new();
            ContextMenu.Visibility = System.Windows.Visibility.Collapsed;
            ContextMenu.IsEnabled = false;

            Text = string.Empty;

            // Handle events that occurs when keys are pressed
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;
            PreviewKeyDown += HandlePreviewKeyDown;
            PreviewTextInput += HandlePreviewTextInput;

            PopulateModifierLists();
        }

        private enum MapType : uint
        {
            MAPVK_VK_TO_VSC = 0, // The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
            MAPVK_VSC_TO_VK = 1, // The uCode parameter is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.
            MAPVK_VK_TO_CHAR = 2,     // The uCode parameter is a virtual-key code and is translated into an unshifted character value in the low order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.
            MAPVK_VSC_TO_VK_EX = 3, // The uCode parameter is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.
            MAPVK_VK_TO_VSC_EX = 4, // The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If the scan code is an extended scan code, the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code. If there is no translation, the function returns 0.
        }

        /// <summary>
        /// Gets or sets used to get/set the hotkey (e.g. Key.A).
        /// </summary>
        public Key Hotkey
        {
            get => hotkey;
            set
            {
                hotkey = value;
                Redraw(true);
            }
        }

        /// <summary>
        /// Gets or sets used to get/set the modifier keys (e.g. Alt | Control).
        /// </summary>
        public ModifierKeys HotkeyModifiers
        {
            get => modifiers;
            set
            {
                modifiers = value;
                Redraw(true);
            }
        }

        public static string HotkeyToString(ModifierKeys modifierKeyCode, Key key)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & ModifierKeys.Alt) != 0)
            {
                hotkeyString.Append("Alt").Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Control) != 0)
            {
                hotkeyString.Append("Ctrl").Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Shift) != 0)
            {
                hotkeyString.Append("Shift").Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Windows) != 0)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString() + key.ToString();
        }

        public static string HotkeyToLocalizedString(ModifierKeys modifierKeyCode, Key key)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & ModifierKeys.Alt) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftAlt)).Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Control) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftCtrl)).Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Shift) != 0)
            {
                hotkeyString.Append(GetKeyName(Key.LeftShift)).Append(" + ");
            }

            if ((modifierKeyCode & ModifierKeys.Windows) != 0)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString() + GetKeyName(key);
        }

        public static ModifierKeys HotkeyModifiersFromString(string modifiersString)
        {
            ModifierKeys modifiers = ModifierKeys.None;
            if (!string.IsNullOrEmpty(modifiersString))
            {
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
            }

            return modifiers;
        }

        public static Key HotkeyFromString(string hotkey)
        {
            Key key = Key.None;
            if (!string.IsNullOrEmpty(hotkey))
            {
                if (hotkey.LastIndexOf('+') > 0)
                {
                    hotkey = hotkey.Remove(0, hotkey.LastIndexOf('+') + 1).Trim();
                }

                try
                {
                    hotkey = hotkey.
                        Replace("PgDn", "PageDown", StringComparison.InvariantCulture).
                        Replace("PgUp", "PageUp", StringComparison.InvariantCulture);
                    key = (Key)Enum.Parse(typeof(Key), hotkey);
                }
                catch (ArgumentException ex)
                {
                    Log.Warn($"{hotkey} can not be parsed", ex);
                }
            }

            return key;
        }

        /// <summary>
        /// Register a hotkey.
        /// </summary>
        /// <param name="modifierKeyCode">The key modifiers .</param>
        /// <param name="key">The virtual key code.</param>
        /// <param name="handler">A HotKeyHandler, this will be called to handle the hotkey press.</param>
        /// <returns>the hotkey number, -1 if failed.</returns>
        public static int RegisterHotKey(ModifierKeys modifierKeyCode, Key key, Action handler)
        {
            if (key == Key.None)
            {
                return 0;
            }

            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(key);
            if (NativeMethods.User32RegisterHotKey(HotkeyHwnd, hotKeyCounter, (uint)modifierKeyCode, (uint)virtualKeyCode))
            {
                KeyHandlers.Add(hotKeyCounter, handler);
                return hotKeyCounter++;
            }
            else
            {
                string errorHint = NativeMethods.GetLastErrorHint();
                Log.Info($"Couldn't register hotkey modifier {modifierKeyCode} virtualKeyCode {virtualKeyCode} hint: " + errorHint);
                return -1;
            }
        }

        public static void UnregisterHotkeys()
        {
            foreach (int hotkey in KeyHandlers.Keys)
            {
                NativeMethods.User32UnregisterHotKey(HotkeyHwnd, hotkey);
            }

            KeyHandlers.Clear();
        }

        public static string GetKeyName(Key givenKey)
        {
            StringBuilder keyName = new();
            const uint numpad = 55;

            Key virtualKey = givenKey;
            string keyString = string.Empty;

            // Make VC's to real keys
            switch (virtualKey)
            {
                case Key.Multiply:
                    if (NativeMethods.User32GetKeyNameText(numpad << 16, keyName, 100) > 0)
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
                    if (NativeMethods.User32GetKeyNameText(numpad << 16, keyName, 100) > 0)
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

            uint scanCode = NativeMethods.User32MapVirtualKey((uint)virtualKey, (uint)MapType.MAPVK_VK_TO_VSC);

            // because MapVirtualKey strips the extended bit for some keys
            switch (virtualKey)
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
                    scanCode |= 0x100; // set extended bit
                    break;
                case Key.PrintScreen: // PrintScreen
                    scanCode = 311;
                    break;
                case Key.Pause: // PrintScreen
                    scanCode = 69;
                    break;
            }

            scanCode |= 0x200;
            if (NativeMethods.User32GetKeyNameText(scanCode << 16, keyName, 100) != 0)
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
                return givenKey.ToString();
            }
        }

        /// <summary>
        /// Clears the current hotkey and resets the TextBox.
        /// </summary>
        public void ResetHotkey()
        {
            hotkey = Key.None;
            modifiers = ModifierKeys.None;
            Redraw();
        }

        /// <summary>
        /// Used to get/set the hotkey (e.g. Key.A).
        /// </summary>
        /// <param name="hotkey">hotkey.</param>
        public void SetHotkey(string hotkey)
        {
            this.hotkey = HotkeyFromString(hotkey);
            modifiers = HotkeyModifiersFromString(hotkey);
            Redraw(true);
        }

        public override string ToString() => HotkeyToString(modifiers, hotkey);

        private void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Handle some misc keys, such as Delete and Shift+Insert
            ModifierKeys modifiers = Keyboard.Modifiers;
            switch (e.Key)
            {
                case Key.Delete:
                    ResetHotkey();
                    e.Handled = true;
                    break;
                case Key.Insert:
                    if (modifiers == ModifierKeys.Shift)
                    {
                        e.Handled = true; // Don't allow
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Redraws the TextBox when necessary.
        /// </summary>
        /// <param name="bCalledProgramatically">Specifies whether this function was called by the Hotkey/HotkeyModifiers properties or by the user.</param>
        private void Redraw(bool bCalledProgramatically = false)
        {
            // No hotkey set
            if (hotkey == Key.None)
            {
                Text = string.Empty;
                return;
            }

            // Only validate input if it comes from the user
            if (bCalledProgramatically == false)
            {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if ((modifiers == ModifierKeys.Shift || modifiers == ModifierKeys.None) && needNonShiftModifier.Contains((int)hotkey))
                {
                    if (modifiers == ModifierKeys.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (needNonAltGrModifier.Contains((int)hotkey) == false)
                        {
                            modifiers = ModifierKeys.Alt | ModifierKeys.Control;
                        }
                        else
                        {
                            // ... in that case, use Shift+Alt instead.
                            modifiers = ModifierKeys.Alt | ModifierKeys.Shift;
                        }
                    }
                    else
                    {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        hotkey = Key.None;
                        Text = string.Empty;
                        return;
                    }
                }

                // Check all Ctrl+Alt keys
                if (modifiers == (ModifierKeys.Alt | ModifierKeys.Control) && needNonAltGrModifier.Contains((int)hotkey))
                {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    hotkey = Key.None;
                    Text = string.Empty;
                    return;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (hotkey == Key.LeftAlt || hotkey == Key.RightAlt ||
                hotkey == Key.LeftShift || hotkey == Key.RightShift ||
                hotkey == Key.LeftCtrl || hotkey == Key.RightCtrl)
            {
                hotkey = Key.None;
            }

            Text = HotkeyToLocalizedString(modifiers, hotkey);
        }

        /// <summary>
        /// Populates the ArrayLists specifying disallowed hotkeys
        /// such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign) etc.
        /// </summary>
        private void PopulateModifierLists()
        {
            // Shift + 0 - 9, A - Z
            for (Key k = Key.D0; k <= Key.Z; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Numpad keys
            for (Key k = Key.NumPad0; k <= Key.NumPad9; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Misc (,;<./ etc)
            for (Key k = Key.Oem1; k <= Key.OemBackslash; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Key k = Key.Space; k <= Key.Home; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Misc keys that we can't loop through
            needNonShiftModifier.Add((int)Key.Insert);
            needNonShiftModifier.Add((int)Key.Help);
            needNonShiftModifier.Add((int)Key.Multiply);
            needNonShiftModifier.Add((int)Key.Add);
            needNonShiftModifier.Add((int)Key.Subtract);
            needNonShiftModifier.Add((int)Key.Divide);
            needNonShiftModifier.Add((int)Key.Decimal);
            needNonShiftModifier.Add((int)Key.Return);
            needNonShiftModifier.Add((int)Key.Escape);
            needNonShiftModifier.Add((int)Key.NumLock);

            // Ctrl+Alt + 0 - 9
            for (Key k = Key.D0; k <= Key.D9; k++)
            {
                needNonAltGrModifier.Add((int)k);
            }
        }

        /// <summary>
        /// Fires when a key is pushed down. Here, we'll want to update the text in the box
        /// to notify the user what combination is currently pressed.
        /// </summary>
        private void HotkeyControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Clear the current hotkey
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                ResetHotkey();
            }
            else
            {
                modifiers = Keyboard.Modifiers;
                hotkey = e.Key;
                Redraw();
            }
        }

        /// <summary>
        /// Fires when all keys are released. If the current hotkey isn't valid, reset it.
        /// Otherwise, do nothing and keep the text and hotkey as it was.
        /// </summary>
        private void HotkeyControl_KeyUp(object sender, KeyEventArgs e)
        {
            // Somehow the PrintScreen only comes as a keyup, therefore we handle it here.
            if (e.Key == Key.PrintScreen)
            {
                modifiers = Keyboard.Modifiers;
                hotkey = e.Key;
                Redraw();
            }
            else if (hotkey == Key.None && modifiers == ModifierKeys.None)
            {
                ResetHotkey();
            }
        }

        /// <summary>
        /// Prevents the letter/whatever entered to show up in the TextBox
        /// Without this, a "A" key press would appear as "aControl, Alt + A".
        /// </summary>
        private void HandlePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
}
