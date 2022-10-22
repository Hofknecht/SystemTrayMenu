// <copyright file="HotkeyControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface.HotkeyTextboxControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// A simple control that allows the user to select pretty much any valid hotkey combination
    /// See: http://www.codeproject.com/KB/buttons/hotkeycontrol.aspx
    /// But is modified to fit in Greenshot, and have localized support.
    /// modfied to fit SystemTrayMenu.
    /// </summary>
    public sealed class HotkeyControl : TextBox
    {
        private static readonly bool IsWindows7OrOlder = Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1;
        private static readonly IntPtr HotkeyHwnd = (IntPtr)0x0000000000000000;

        // Holds the list of hotkeys
        private static readonly IDictionary<int, HotKeyHandler> KeyHandlers = new Dictionary<int, HotKeyHandler>();
        private static int hotKeyCounter = 1;

        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly IList<int> needNonShiftModifier = new List<int>();
        private readonly IList<int> needNonAltGrModifier = new List<int>();

        private readonly ContextMenu dummy = new();

        // These variables store the current hotkey and modifier(s)
        private Key hotkey = Key.None;
        private Key modifiers = Key.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyControl"/> class.
        /// </summary>
        public HotkeyControl()
        {
            ContextMenu = dummy; // Disable right-clicking
            Text = string.Empty;

            // Handle events that occurs when keys are pressed
            KeyPress += HotkeyControl_KeyPress;
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;

            PopulateModifierLists();
        }

        public delegate void HotKeyHandler();

        private enum Modifiers
        {
            NONE = 0,
            ALT = 1,
            CTRL = 2,
            SHIFT = 4,
            WIN = 8,
            NOREPEAT = 0x4000,
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
        /// Gets or sets used to make sure that there is no right-click menu available.
        /// </summary>
        public override ContextMenu ContextMenu
        {
            get => dummy;
            set => base.ContextMenu = dummy;
        }

        /// <summary>
        /// Gets or sets a value indicating whether forces the control to be non-multiline.
        /// </summary>
        public override bool Multiline
        {
            get => base.Multiline;
            set => base.Multiline = false;
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
        /// Gets or sets used to get/set the modifier keys (e.g. Key.Alt | Key.Control).
        /// </summary>
        public Key HotkeyModifiers
        {
            get => modifiers;
            set
            {
                modifiers = value;
                Redraw(true);
            }
        }

        public static string HotkeyToString(Key modifierKeyCode, Key virtualKeyCode)
        {
            return HotkeyModifiersToString(modifierKeyCode) + virtualKeyCode;
        }

        public static string HotkeyModifiersToString(Key modifierKeyCode)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & Key.Alt) > 0)
            {
                hotkeyString.Append("Alt").Append(" + ");
            }

            if ((modifierKeyCode & Key.Control) > 0)
            {
                hotkeyString.Append("Ctrl").Append(" + ");
            }

            if ((modifierKeyCode & Key.Shift) > 0)
            {
                hotkeyString.Append("Shift").Append(" + ");
            }

            if (modifierKeyCode == Key.LWin || modifierKeyCode == Key.RWin)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString();
        }

        public static string HotkeyToLocalizedString(Key modifierKeyCode, Key virtualKeyCode)
        {
            return HotkeyModifiersToLocalizedString(modifierKeyCode) + GetKeyName(virtualKeyCode);
        }

        public static string HotkeyModifiersToLocalizedString(Key modifierKeyCode)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & Key.Alt) > 0)
            {
                hotkeyString.Append(GetKeyName(Key.Alt)).Append(" + ");
            }

            if ((modifierKeyCode & Key.Control) > 0)
            {
                hotkeyString.Append(GetKeyName(Key.Control)).Append(" + ");
            }

            if ((modifierKeyCode & Key.Shift) > 0)
            {
                hotkeyString.Append(GetKeyName(Key.Shift)).Append(" + ");
            }

            if (modifierKeyCode == Key.LWin || modifierKeyCode == Key.RWin)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString();
        }

        public static Key HotkeyModifiersFromString(string modifiersString)
        {
            Key modifiers = Key.None;
            if (!string.IsNullOrEmpty(modifiersString))
            {
                if (modifiersString.ToUpperInvariant().Contains("ALT+", StringComparison.InvariantCulture))
                {
                    modifiers |= Key.Alt;
                }

                if (modifiersString.ToUpperInvariant().Contains("CTRL+", StringComparison.InvariantCulture) ||
                    modifiersString.ToUpperInvariant().Contains("STRG+", StringComparison.InvariantCulture))
                {
                    modifiers |= Key.Control;
                }

                if (modifiersString.ToUpperInvariant().Contains("SHIFT+", StringComparison.InvariantCulture))
                {
                    modifiers |= Key.Shift;
                }

                if (modifiersString.ToUpperInvariant().Contains("WIN+", StringComparison.InvariantCulture))
                {
                    modifiers |= Key.LWin;
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
        /// <param name="modifierKeyCode">The modifier, e.g.: Modifiers.CTRL, Modifiers.NONE or Modifiers.ALT .</param>
        /// <param name="virtualKeyCode">The virtual key code.</param>
        /// <param name="handler">A HotKeyHandler, this will be called to handle the hotkey press.</param>
        /// <returns>the hotkey number, -1 if failed.</returns>
        public static int RegisterHotKey(Key modifierKeyCode, Key virtualKeyCode, HotKeyHandler handler)
        {
            if (virtualKeyCode == Key.None)
            {
                return 0;
            }

            // Convert Modifiers to fit HKM_SETHOTKEY
            uint modifiers = 0;
            if ((modifierKeyCode & Key.Alt) > 0)
            {
                modifiers |= (uint)Modifiers.ALT;
            }

            if ((modifierKeyCode & Key.Control) > 0)
            {
                modifiers |= (uint)Modifiers.CTRL;
            }

            if ((modifierKeyCode & Key.Shift) > 0)
            {
                modifiers |= (uint)Modifiers.SHIFT;
            }

            if (modifierKeyCode == Key.LWin || modifierKeyCode == Key.RWin)
            {
                modifiers |= (uint)Modifiers.WIN;
            }

            if (IsWindows7OrOlder)
            {
                modifiers |= (uint)Modifiers.NOREPEAT;
            }

            if (NativeMethods.User32RegisterHotKey(HotkeyHwnd, hotKeyCounter, modifiers, (uint)virtualKeyCode))
            {
                KeyHandlers.Add(hotKeyCounter, handler);
                return hotKeyCounter++;
            }
            else
            {
                Log.Info($"Couldn't register hotkey modifier {modifierKeyCode} virtualKeyCode {virtualKeyCode}");
                return -1;
            }
        }

        public static void UnregisterHotkeys()
        {
            foreach (int hotkey in KeyHandlers.Key)
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
                case Key.Alt:
                    virtualKey = Key.LMenu;
                    break;
                case Key.Control:
                    virtualKey = Key.ControlKey;
                    break;
                case Key.Shift:
                    virtualKey = Key.LShiftKey;
                    break;
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
            modifiers = Key.None;
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

        public override string ToString()
        {
            return HotkeyToString(HotkeyModifiers, Hotkey);
        }

        /// <summary>
        /// Handles some misc keys, such as Ctrl+Delete and Shift+Insert.
        /// </summary>
        /// <param name="msg">msg.</param>
        /// <param name="keyData">keyData.</param>
        /// <returns>bool if handled.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Key keyData)
        {
            if (keyData == Key.Delete || keyData == (Key.Control | Key.Delete))
            {
                ResetHotkey();
                return true;
            }

            // Paste
            if (keyData == (Key.Shift | Key.Insert))
            {
                return true; // Don't allow
            }

            // Allow the rest
            return base.ProcessCmdKey(ref msg, keyData);
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
                if ((modifiers == Key.Shift || modifiers == Key.None) && needNonShiftModifier.Contains((int)hotkey))
                {
                    if (modifiers == Key.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (needNonAltGrModifier.Contains((int)hotkey) == false)
                        {
                            modifiers = Key.Alt | Key.Control;
                        }
                        else
                        {
                            // ... in that case, use Shift+Alt instead.
                            modifiers = Key.Alt | Key.Shift;
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
                if ((modifiers == (Key.Alt | Key.Control)) && needNonAltGrModifier.Contains((int)hotkey))
                {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    hotkey = Key.None;
                    Text = string.Empty;
                    return;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (hotkey == Key.Menu /* Alt */ || hotkey == Key.ShiftKey || hotkey == Key.ControlKey)
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
            if (e.KeyCode == Key.Back || e.KeyCode == Key.Delete)
            {
                ResetHotkey();
            }
            else
            {
                modifiers = e.Modifiers;
                hotkey = e.KeyCode;
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
            if (e.KeyCode == Key.PrintScreen)
            {
                modifiers = e.Modifiers;
                hotkey = e.KeyCode;
                Redraw();
            }

            if (hotkey == Key.None && ModifierKeys == Key.None)
            {
                ResetHotkey();
            }
        }

        /// <summary>
        /// Prevents the letter/whatever entered to show up in the TextBox
        /// Without this, a "A" key press would appear as "aControl, Alt + A".
        /// </summary>
        private void HotkeyControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}