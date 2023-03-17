// <copyright file="SingleAppInstance.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using SystemTrayMenu.UserInterface.HotkeyTextboxControl;
    using WindowsInput;

    internal static class SingleAppInstance
    {
        internal static bool Initialize()
        {
            bool success = true;

            try
            {
                foreach (Process p in Process.GetProcessesByName(
                       Process.GetCurrentProcess().ProcessName).
                       Where(s => s.Id != Environment.ProcessId))
                {
                    if (Properties.Settings.Default.SendHotkeyInsteadKillOtherInstances)
                    {
                        Keys modifiers = HotkeyControl.HotkeyModifiersFromString(Properties.Settings.Default.HotKey);
                        Keys hotkey = HotkeyControl.HotkeyFromString(Properties.Settings.Default.HotKey);

                        try
                        {
                            List<VirtualKeyCode> virtualKeyCodesModifiers = new();
                            foreach (string key in modifiers.ToString().ToUpperInvariant().Split(", "))
                            {
                                if (key == "NONE")
                                {
                                    continue;
                                }

                                VirtualKeyCode virtualKeyCode = VirtualKeyCode.LWIN;
                                virtualKeyCode = key switch
                                {
                                    "ALT" => VirtualKeyCode.MENU,
                                    _ => (VirtualKeyCode)Enum.Parse(
                                                 typeof(VirtualKeyCode), key.ToUpperInvariant()),
                                };
                                virtualKeyCodesModifiers.Add(virtualKeyCode);
                            }

                            VirtualKeyCode virtualKeyCodeHotkey = 0;
                            if (Enum.IsDefined(typeof(VirtualKeyCode), (int)hotkey))
                            {
                                virtualKeyCodeHotkey = (VirtualKeyCode)(int)hotkey;
                            }

                            new InputSimulator().Keyboard.ModifiedKeyStroke(virtualKeyCodesModifiers, virtualKeyCodeHotkey);

                            success = false;
                        }
                        catch (Exception ex)
                        {
                            Log.Warn($"Send hoktey {Properties.Settings.Default.HotKey} to other instance failed", ex);
                        }
                    }

                    if (!Properties.Settings.Default.SendHotkeyInsteadKillOtherInstances)
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
