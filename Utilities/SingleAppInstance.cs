// <copyright file="SingleAppInstance.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;
    using SystemTrayMenu.Helpers;

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
                        string hotKeyString = Properties.Settings.Default.HotKey;
                        ModifierKeys modifiers = GlobalHotkeys.ModifierKeysFromString(hotKeyString);
                        Key hotkey = GlobalHotkeys.KeyFromString(hotKeyString);

                        try
                        {
#if TODO // HOTKEY - Maybe replace with sockets or pipes?
         //          E.g. https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-use-named-pipes-for-network-interprocess-communication
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
#endif
                        }
                        catch (Exception ex)
                        {
                            Log.Warn($"Send hoktey {hotKeyString} to other instance failed", ex);
                        }
                    }
                    else
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
