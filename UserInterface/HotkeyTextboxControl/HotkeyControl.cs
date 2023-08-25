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

        private readonly ContextMenuStrip dummy = new();

        // These variables store the current hotkey and modifier(s)
        private Keys hotkey = Keys.None;
        private Keys modifiers = Keys.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyControl"/> class.
        /// </summary>
        public HotkeyControl()
        {
            ContextMenuStrip = dummy; // Disable right-clicking
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
        public override ContextMenuStrip ContextMenuStrip
        {
            get => dummy;
            set => base.ContextMenuStrip = dummy;
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
        /// Gets or sets used to get/set the hotkey (e.g. Keys.A).
        /// </summary>
        public Keys Hotkey
        {
            get => hotkey;
            set
            {
                hotkey = value;
                Redraw(true);
            }
        }

        /// <summary>
        /// Gets or sets used to get/set the modifier keys (e.g. Keys.Alt | Keys.Control).
        /// </summary>
        public Keys HotkeyModifiers
        {
            get => modifiers;
            set
            {
                modifiers = value;
                Redraw(true);
            }
        }

        public static string HotkeyToString(Keys modifierKeyCode, Keys virtualKeyCode)
        {
            return HotkeyModifiersToString(modifierKeyCode) + virtualKeyCode;
        }

        public static string HotkeyModifiersToString(Keys modifierKeyCode)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                hotkeyString.Append("Alt").Append(" + ");
            }

            if ((modifierKeyCode & Keys.Control) > 0)
            {
                hotkeyString.Append("Ctrl").Append(" + ");
            }

            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                hotkeyString.Append("Shift").Append(" + ");
            }

            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString();
        }

        public static string HotkeyToLocalizedString(Keys modifierKeyCode, Keys virtualKeyCode)
        {
            return HotkeyModifiersToLocalizedString(modifierKeyCode) + GetKeyName(virtualKeyCode);
        }

        public static string HotkeyModifiersToLocalizedString(Keys modifierKeyCode)
        {
            StringBuilder hotkeyString = new();
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Alt)).Append(" + ");
            }

            if ((modifierKeyCode & Keys.Control) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Control)).Append(" + ");
            }

            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Shift)).Append(" + ");
            }

            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
            {
                hotkeyString.Append("Win").Append(" + ");
            }

            return hotkeyString.ToString();
        }

        public static Keys HotkeyModifiersFromString(string modifiersString)
        {
            Keys modifiers = Keys.None;
            if (!string.IsNullOrEmpty(modifiersString))
            {
                if (modifiersString.ToUpperInvariant().Contains("ALT+", StringComparison.InvariantCulture))
                {
                    modifiers |= Keys.Alt;
                }

                if (modifiersString.ToUpperInvariant().Contains("CTRL+", StringComparison.InvariantCulture) ||
                    modifiersString.ToUpperInvariant().Contains("STRG+", StringComparison.InvariantCulture))
                {
                    modifiers |= Keys.Control;
                }

                if (modifiersString.ToUpperInvariant().Contains("SHIFT+", StringComparison.InvariantCulture))
                {
                    modifiers |= Keys.Shift;
                }

                if (modifiersString.ToUpperInvariant().Contains("WIN+", StringComparison.InvariantCulture))
                {
                    modifiers |= Keys.LWin;
                }
            }

            return modifiers;
        }

        public static Keys HotkeyFromString(string hotkey)
        {
            Keys key = Keys.None;
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
                    key = (Keys)Enum.Parse(typeof(Keys), hotkey);
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
        public static int RegisterHotKey(Keys modifierKeyCode, Keys virtualKeyCode, HotKeyHandler handler)
        {
            if (virtualKeyCode == Keys.None)
            {
                return 0;
            }

            // Convert Modifiers to fit HKM_SETHOTKEY
            uint modifiers = 0;
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                modifiers |= (uint)Modifiers.ALT;
            }

            if ((modifierKeyCode & Keys.Control) > 0)
            {
                modifiers |= (uint)Modifiers.CTRL;
            }

            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                modifiers |= (uint)Modifiers.SHIFT;
            }

            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
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
            foreach (int hotkey in KeyHandlers.Keys)
            {
                NativeMethods.User32UnregisterHotKey(HotkeyHwnd, hotkey);
            }

            KeyHandlers.Clear();
        }

        public static string GetKeyName(Keys givenKey)
        {
            StringBuilder keyName = new();
            const uint numpad = 55;

            Keys virtualKey = givenKey;
            string keyString = string.Empty;

            // Make VC's to real keys
            switch (virtualKey)
            {
                case Keys.Alt:
                    virtualKey = Keys.LMenu;
                    break;
                case Keys.Control:
                    virtualKey = Keys.ControlKey;
                    break;
                case Keys.Shift:
                    virtualKey = Keys.LShiftKey;
                    break;
                case Keys.Multiply:
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
                case Keys.Divide:
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
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down: // arrow keys
                case Keys.Prior:
                case Keys.Next: // page up and page down
                case Keys.End:
                case Keys.Home:
                case Keys.Insert:
                case Keys.Delete:
                case Keys.NumLock:
                    scanCode |= 0x100; // set extended bit
                    break;
                case Keys.PrintScreen: // PrintScreen
                    scanCode = 311;
                    break;
                case Keys.Pause: // PrintScreen
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
            hotkey = Keys.None;
            modifiers = Keys.None;
            Redraw();
        }

        /// <summary>
        /// Used to get/set the hotkey (e.g. Keys.A).
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
        /// Disposes of the resources used by the HotkeyControl.
        /// </summary>
        /// <param name="disposing">True if being called from Dispose, false otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dummy.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Handles some misc keys, such as Ctrl+Delete and Shift+Insert.
        /// </summary>
        /// <param name="msg">msg.</param>
        /// <param name="keyData">keyData.</param>
        /// <returns>bool if handled.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.Delete))
            {
                ResetHotkey();
                return true;
            }

            // Paste
            if (keyData == (Keys.Shift | Keys.Insert))
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
            if (hotkey == Keys.None)
            {
                Text = string.Empty;
                return;
            }

            // Only validate input if it comes from the user
            if (bCalledProgramatically == false)
            {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if ((modifiers == Keys.Shift || modifiers == Keys.None) && needNonShiftModifier.Contains((int)hotkey))
                {
                    if (modifiers == Keys.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (needNonAltGrModifier.Contains((int)hotkey) == false)
                        {
                            modifiers = Keys.Alt | Keys.Control;
                        }
                        else
                        {
                            // ... in that case, use Shift+Alt instead.
                            modifiers = Keys.Alt | Keys.Shift;
                        }
                    }
                    else
                    {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        hotkey = Keys.None;
                        Text = string.Empty;
                        return;
                    }
                }

                // Check all Ctrl+Alt keys
                if ((modifiers == (Keys.Alt | Keys.Control)) && needNonAltGrModifier.Contains((int)hotkey))
                {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    hotkey = Keys.None;
                    Text = string.Empty;
                    return;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (hotkey == Keys.Menu /* Alt */ || hotkey == Keys.ShiftKey || hotkey == Keys.ControlKey)
            {
                hotkey = Keys.None;
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
            for (Keys k = Keys.D0; k <= Keys.Z; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Misc keys that we can't loop through
            needNonShiftModifier.Add((int)Keys.Insert);
            needNonShiftModifier.Add((int)Keys.Help);
            needNonShiftModifier.Add((int)Keys.Multiply);
            needNonShiftModifier.Add((int)Keys.Add);
            needNonShiftModifier.Add((int)Keys.Subtract);
            needNonShiftModifier.Add((int)Keys.Divide);
            needNonShiftModifier.Add((int)Keys.Decimal);
            needNonShiftModifier.Add((int)Keys.Return);
            needNonShiftModifier.Add((int)Keys.Escape);
            needNonShiftModifier.Add((int)Keys.NumLock);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++)
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
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
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
            if (e.KeyCode == Keys.PrintScreen)
            {
                modifiers = e.Modifiers;
                hotkey = e.KeyCode;
                Redraw();
            }

            if (hotkey == Keys.None && ModifierKeys == Keys.None)
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