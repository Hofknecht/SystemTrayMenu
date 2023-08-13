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
        private readonly List<Key> needNonShiftModifier = new ();
        private readonly List<Key> needNonAltGrModifier = new ();

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
                Visibility = Visibility.Collapsed,
                IsEnabled = false,
            };

            // Set style defaults from App.xaml (TODO: Fix XAML styles to also apply for this class)
            Height = 21;

            // Handle events that occurs when keys are pressed
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;
            PreviewKeyDown += HandlePreviewKeyDown;
            PreviewTextInput += HandlePreviewTextInput;

            GotFocus += (_, _) => GlobalHotkeys.IsEnabled = false;
            LostFocus += (_, _) => GlobalHotkeys.IsEnabled = true;

            PopulateModifierLists();
            SetHotkeyRegistration(null);
        }

        internal bool WasHotkeyChanged { get; private set; }

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
            WasHotkeyChanged = false;
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

            Text = ModifiersAndKeyToString(modifiers, hotkey);
        }

        /// <summary>
        /// Change the hotkey to given combination.
        /// </summary>
        /// <param name="hotkeyString">Hotkey combination string.</param>
        internal void ChangeHotkey(string hotkeyString)
        {
            try
            {
                HotkeyFunction?.Register(hotkeyString);
                WasHotkeyChanged = true;
            }
            catch (InvalidOperationException ex)
            {
                Log.Warn($"Hotkey failed resetting to default: '{hotkeyString}'", ex);
                return;
            }

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
                HotkeyFunction?.Unregister();
                WasHotkeyChanged = true;
            }
            else
            {
                try
                {
                    HotkeyFunction?.Register(modifiers, key);
                    WasHotkeyChanged = true;
                }
                catch (InvalidOperationException ex)
                {
                    Log.Info($"Couldn't register hotkey modifier {modifiers} key {key} ex: " + ex.ToString());
                }
            }
        }

        private void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            ModifierKeys modifiers = Keyboard.Modifiers;
            switch (e.Key)
            {
                case Key.Back:
                case Key.Delete:
                    HotkeyFunction?.Unregister();
                    WasHotkeyChanged = true;
                    UpdateHotkeyRegistration();
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

        private void FilterCombinations(ref ModifierKeys modifiers, ref Key key)
        {
            // No modifier or shift only, AND a hotkey that needs another modifier
            if ((modifiers == ModifierKeys.Shift || modifiers == ModifierKeys.None) && needNonShiftModifier.Contains(key))
            {
                if (modifiers == ModifierKeys.None)
                {
                    // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                    if (needNonAltGrModifier.Contains(key) == false)
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
                    key = Key.None;
                    return;
                }
            }

            // Check all Ctrl+Alt keys
            if (modifiers == (ModifierKeys.Alt | ModifierKeys.Control) && needNonAltGrModifier.Contains(key))
            {
                // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                key = Key.None;
                return;
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (key == Key.LeftAlt || key == Key.RightAlt ||
                key == Key.LeftShift || key == Key.RightShift ||
                key == Key.LeftCtrl || key == Key.RightCtrl)
            {
                key = Key.None;
            }
        }

        /// <summary>
        /// Populates the ArrayLists specifying disallowed hotkeys
        /// such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign) etc.
        /// </summary>
        private void PopulateModifierLists()
        {
            // Ctrl+Alt + 0 - 9
            // Shift    + 0 - 9
            for (Key k = Key.D0; k <= Key.D9; k++)
            {
                needNonAltGrModifier.Add(k);
                needNonShiftModifier.Add(k);
            }

            // Shift + A - Z
            for (Key k = Key.A; k <= Key.Z; k++)
            {
                needNonShiftModifier.Add(k);
            }

            // Shift + Numpad keys
            for (Key k = Key.NumPad0; k <= Key.NumPad9; k++)
            {
                needNonShiftModifier.Add(k);
            }

            // Shift + Misc (,;<./ etc)
            for (Key k = Key.Oem1; k <= Key.OemBackslash; k++)
            {
                needNonShiftModifier.Add(k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Key k = Key.Space; k <= Key.Home; k++)
            {
                needNonShiftModifier.Add(k);
            }

            // Misc keys that we can't loop through
            needNonShiftModifier.Add(Key.Insert);
            needNonShiftModifier.Add(Key.Help);
            needNonShiftModifier.Add(Key.Multiply);
            needNonShiftModifier.Add(Key.Add);
            needNonShiftModifier.Add(Key.Subtract);
            needNonShiftModifier.Add(Key.Divide);
            needNonShiftModifier.Add(Key.Decimal);
            needNonShiftModifier.Add(Key.Return);
            needNonShiftModifier.Add(Key.Escape);
            needNonShiftModifier.Add(Key.NumLock);
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
                HotkeyFunction?.Unregister();
                WasHotkeyChanged = true;
            }
            else
            {
                modifiers = Keyboard.Modifiers;
                hotkey = e.Key;
                FilterCombinations(ref modifiers, ref hotkey);
                ChangeHotkey(modifiers, hotkey);
            }

            UpdateHotkeyRegistration();
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
                FilterCombinations(ref modifiers, ref hotkey);
                ChangeHotkey(modifiers, hotkey);
                UpdateHotkeyRegistration();
            }
            else if (hotkey == Key.None)
            {
                HotkeyFunction?.Unregister();
                WasHotkeyChanged = true;
                UpdateHotkeyRegistration();
            }
        }

        /// <summary>
        /// Prevents the letter/whatever entered to show up in the TextBox
        /// Without this, a "A" key press would appear as "aControl, Alt + A".
        /// </summary>
        private void HandlePreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = true;
    }
}
