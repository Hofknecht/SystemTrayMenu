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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.Helpers.GlobalHotkeys;

    public sealed class HotkeySelector : TextBox
    {
        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly IList<int> needNonShiftModifier = new List<int>();
        private readonly IList<int> needNonAltGrModifier = new List<int>();

        // These variables store the current hotkey and modifier(s)
        private Key hotkey = Key.None;
        private ModifierKeys modifiers = ModifierKeys.None;

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

            // Handle events that occurs when keys are pressed
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;
            PreviewKeyDown += HandlePreviewKeyDown;
            PreviewTextInput += HandlePreviewTextInput;

            GotFocus += (_, _) => GlobalHotkeys.IsEnabled = false;
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
#endif
                GlobalHotkeys.IsEnabled = true;
            };

            PopulateModifierLists();
            SetHotkeyRegistration((IHotkeyFunction?)null);
        }

        internal IHotkeyFunction? HotkeyFunction { get; private set; }

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

        public override string ToString() => HotkeyToString(modifiers, hotkey);

        /// <summary>
        /// Set the hotkey function the control is working on.
        /// </summary>
        /// <param name="hotkeyFunction">Hotkey function interface.</param>
        internal void SetHotkeyRegistration(IHotkeyFunction? hotkeyFunction)
        {
            HotkeyFunction = hotkeyFunction;
            UpdateHotkeyRegistration();
        }

        /// <summary>
        /// Update the UI based on the hotkey registration.
        /// </summary>
        internal void UpdateHotkeyRegistration()
        {
            hotkey = HotkeyFunction?.GetKey() ?? Key.None;
            modifiers = HotkeyFunction?.GetModifierKeys() ?? ModifierKeys.None;

            if (modifiers == ModifierKeys.None && hotkey == Key.None)
            {
                Background = SystemColors.ControlBrush;
            }
            else if (HotkeyFunction != null)
            {
                Background = Brushes.LightGreen;
            }
            else
            {
                Background = Brushes.IndianRed;
            }

            Text = HotkeyToLocalizedString(modifiers, hotkey);
        }

        /// <summary>
        /// Change the hotkey to given combination.
        /// </summary>
        /// <param name="hotkeyString">Hotkey combination string.</param>
        internal void ChangeHotkey(string hotkeyString)
        {
            HotkeyFunction?.Register(hotkeyString);
            UpdateHotkeyRegistration();
        }

        /// <summary>
        /// Change the hotkey to given combination.
        /// Sets background accordingly.
        /// </summary>
        /// <param name="modifiers">Hotkey modifiers.</param>
        /// <param name="key">Hotkey key.</param>
        internal void ChangeHotkey(ModifierKeys modifiers, Key key)
        {
            if (key == Key.None)
            {
                Background = SystemColors.ControlBrush;
            }
            else
            {
                try
                {
                    HotkeyFunction?.Register(modifiers, key);
                }
                catch (InvalidOperationException ex)
                {
                    Background = Brushes.IndianRed;
                    Log.Info($"Couldn't register hotkey modifier {modifiers} key {key} ex: " + ex.ToString());
                }

                Background = Brushes.LightGreen;
            }
        }

        /// <summary>
        /// Clears the current hotkey and resets the TextBox.
        /// </summary>
        private void ResetHotkey()
        {
            HotkeyFunction?.Unregister();
            UpdateHotkeyRegistration();
        }

        private void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            ModifierKeys modifiers = Keyboard.Modifiers;
            switch (e.Key)
            {
                case Key.Back:
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

        // TODO: Instead of Redraw this seem to act more like an input filter for valid combinations?
        //       Maybe move to places right before Register() calls of the HotkeyFunction
        private void Redraw()
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
                ChangeHotkey(modifiers, hotkey);
                UpdateHotkeyRegistration();
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
                ChangeHotkey(modifiers, hotkey);
                UpdateHotkeyRegistration();
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
        private void HandlePreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = true;

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
