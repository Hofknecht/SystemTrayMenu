// <copyright file="SingleAppInstance.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using SystemTrayMenu.UserInterface.HotkeyTextboxControl;
    using WindowsInput;
    using WindowsInput.Native;

    internal static class SingleAppInstance
    {
        internal static bool Initialize(bool killOtherInstances)
        {
            bool success = true;

            try
            {
                foreach (Process p in Process.GetProcessesByName(
                       Process.GetCurrentProcess().ProcessName).
                       Where(s => s.Id != Process.GetCurrentProcess().Id))
                {
                    if (!killOtherInstances)
                    {
                        Keys modifiers = HotkeyControl.HotkeyModifiersFromString(Properties.Settings.Default.HotKey);
                        Keys hotkey = HotkeyControl.HotkeyFromString(Properties.Settings.Default.HotKey);

                        try
                        {
                            VirtualKeyCode virtualKeyCodeModifiers = (VirtualKeyCode)Enum.Parse(
                                typeof(VirtualKeyCode), modifiers.ToString().ToUpperInvariant());
                            VirtualKeyCode virtualKeyCodeHotkey = (VirtualKeyCode)Enum.Parse(
                                typeof(VirtualKeyCode), hotkey.ToString().ToUpperInvariant());

                            new InputSimulator().Keyboard.ModifiedKeyStroke(virtualKeyCodeModifiers, virtualKeyCodeHotkey);
                            success = false;

                            // how to solve with several modifier keys?
                        }
                        catch (Exception ex)
                        {
                            Log.Warn("Send hoktey to other instance failed", ex);
                            killOtherInstances = true;
                        }
                    }

                    if (killOtherInstances)
                    {
                        try
                        {
                            if (!p.CloseMainWindow())
                            {
                                p.Kill();
                            }

                            p.WaitForExit();
                            p.Close();
                        }
                        catch (Exception ex)
                        {
                            Log.Error("Run as single instance failed", ex);
                            success = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Run as single instance failed", ex);
            }

            return success;
        }
    }
}
