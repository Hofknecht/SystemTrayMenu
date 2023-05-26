// <copyright file="HotkeySelector.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Origin of some parts: http://www.codeproject.com/KB/buttons/hotkeycontrol.aspx

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Input;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Utilities;

    public sealed class HotkeySelector : TextBox, IDisposable
    {
        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly IList<int> needNonShiftModifier = new List<int>();
        private readonly IList<int> needNonAltGrModifier = new List<int>();

        private KeyboardHook hook = new();

        // These variables store the current hotkey and modifier(s)
        private Key hotkey = Key.None;
        private ModifierKeys modifiers = ModifierKeys.None;
        private Action? handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeySelector"/> class.
        /// </summary>
        public HotkeySelector()
        {
            // Disable right-clicking
            ContextMenu = new()
            {
                Visibility = System.Windows.Visibility.Collapsed,
                IsEnabled = false,
            };

            Text = string.Empty;

            // Handle events that occurs when keys are pressed
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;
            PreviewKeyDown += HandlePreviewKeyDown;
            PreviewTextInput += HandlePreviewTextInput;

            GotFocus += (_, _) =>
            {
                UnregisterHotKey();
                Reassigning = true;
            };
            LostFocus += (_, _) =>
            {
#if TODO // HOTKEY
                Settings.Default.HotKey =
                    new KeysConverter().ConvertToInvariantString(
                    textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
#endif
#if TODO // HOTKEY
                /// <summary>
                /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
                /// </summary>
                /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
                RegisterHotkeys(false);
#else
                ReregisterHotKey();
#endif
                Reassigning = false;
            };

            PopulateModifierLists();
        }

        ~HotkeySelector() => Dispose();

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

        internal bool Reassigning { get; private set; }

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

        public void Dispose()
        {
            hook.Dispose();
            GC.SuppressFinalize(this);
        }

        public override string ToString() => HotkeyToString(modifiers, hotkey);

        /// <summary>
        /// Used to get/set the hotkey (e.g. Key.A).
        /// </summary>
        /// <param name="hotkey">hotkey.</param>
        public void SetHotkey(string hotkey)
        {
            this.hotkey = GlobalHotkeys.KeyFromString(hotkey);
            modifiers = GlobalHotkeys.ModifierKeysFromString(hotkey);
            Redraw(true);
        }

        /// <summary>
        /// Register a hotkey.
        /// </summary>
        /// <param name="modifiers">The key modifiers .</param>
        /// <param name="key">The virtual key code.</param>
        /// <param name="handler">A HotKeyHandler, this will be called to handle the hotkey press.</param>
        /// <returns>the hotkey number, -1 if failed.</returns>
        public int RegisterHotKey(ModifierKeys modifiers, Key key, Action handler)
        {
            if (key == Key.None)
            {
                return 0;
            }

            try
            {
                hook.RegisterHotKey(modifiers, key);
            }
            catch (InvalidOperationException ex)
            {
                Log.Info($"Couldn't register hotkey modifier {modifiers} key {key} ex: " + ex.ToString());
                return -1;
            }

            this.handler = handler;
            hook.KeyPressed += (_, _) => handler.Invoke();
            return 1;
        }

        private void ReregisterHotKey()
        {
            if (handler != null)
            {
                RegisterHotKey(modifiers, hotkey, handler);
            }
        }

        private void UnregisterHotKey()
        {
            // TODO: Rework to allow deregistration?
            hook.Dispose();
            hook = new();
        }

        /// <summary>
        /// Clears the current hotkey and resets the TextBox.
        /// </summary>
        private void ResetHotkey()
        {
            hotkey = Key.None;
            modifiers = ModifierKeys.None;
            Redraw(false);
        }

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
        private void Redraw(bool bCalledProgramatically)
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

            Text = GlobalHotkeys.HotkeyToLocalizedString(modifiers, hotkey);
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
                Redraw(false);
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
                Redraw(false);
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

#if TODO // HOTKEY
        /// <summary>
        /// Helper method to cleanly register a hotkey.
        /// </summary>
        /// <param name="failedKeys">failedKeys.</param>
        /// <param name="hotkeyString">hotkeyString.</param>
        /// <param name="handler">handler.</param>
        /// <returns>bool success.</returns>
        private static bool RegisterHotkey(StringBuilder failedKeys, string hotkeyString, HotKeyHandler handler)
        {
            Keys modifierKeyCode = HotkeyModifiersFromString(hotkeyString);
            Keys virtualKeyCode = HotkeyFromString(hotkeyString);
            if (!Keys.None.Equals(virtualKeyCode))
            {
                if (RegisterHotKey(modifierKeyCode, virtualKeyCode, handler) < 0)
                {
                    if (failedKeys.Length > 0)
                    {
                        failedKeys.Append(", ");
                    }

                    failedKeys.Append(hotkeyString);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <param name="ignoreFailedRegistration">if true, a failed hotkey registration will not be reported to the user - the hotkey will simply not be registered.</param>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        private static bool RegisterHotkeys(bool ignoreFailedRegistration)
        {
            bool success = true;
            StringBuilder failedKeys = new();
            if (!RegisterHotkey(
                failedKeys,
                Settings.Default.HotKey,
                handler))
            {
                success = false;
            }

            if (!success)
            {
                if (!ignoreFailedRegistration)
                {
                    success = HandleFailedHotkeyRegistration(failedKeys.ToString());
                }
            }

            return success || ignoreFailedRegistration;
        }

        /// <summary>
        /// Displays a dialog for the user to choose how to handle hotkey registration failures:
        /// retry (allowing to shut down the conflicting application before),
        /// ignore (not registering the conflicting hotkey and resetting the respective config to "None", i.e. not trying to register it again on next startup)
        /// abort (do nothing about it).
        /// </summary>
        /// <param name="failedKeys">comma separated list of the hotkeys that could not be registered, for display in dialog text.</param>
        /// <returns>bool success.</returns>
        private static bool HandleFailedHotkeyRegistration(string failedKeys)
        {
            bool success = false;
            string warningTitle = Translator.GetText("Warning");
            string message = Translator.GetText("Could not register the hot key.") + failedKeys;
            DialogResult dr = MessageBox.Show(message, warningTitle, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Retry)
            {
                UnregisterHotKey();
                success = RegisterHotkeys(false); // TODO: This may end up in endless recursion, better use a loop at caller
            }
            else if (dr == DialogResult.Ignore)
            {
                UnregisterHotKey();
                success = RegisterHotkeys(true);
            }

            return success;
        }
#endif
    }
}
