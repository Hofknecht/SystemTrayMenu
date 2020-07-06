// <copyright file="SingleAppInstance.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    internal static class SingleAppInstance
    {
        internal static void Initialize()
        {
            if (IsAnyOtherInstancesofAppAlreadyRunning())
            {
                KillOtherInstancesOfApp();
                bool KillOtherInstancesOfApp()
                {
                    bool killedAProcess = false;
                    int ownPID = Process.GetCurrentProcess().Id;

                    try
                    {
                        foreach (Process p in Process.GetProcessesByName(
                                Process.GetCurrentProcess().ProcessName).
                            Where(p => p.Id != ownPID))
                        {
                            if (!p.CloseMainWindow())
                            {
                                p.Kill();
                            }

                            p.WaitForExit();
                            p.Close();
                            killedAProcess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is Win32Exception ||
                            ex is SystemException)
                        {
                            Log.Error("Run as single instance failed", ex);
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return killedAProcess;
                }
            }

            static bool IsAnyOtherInstancesofAppAlreadyRunning()
            {
                foreach (Process p in Process.GetProcessesByName(
                    Process.GetCurrentProcess().ProcessName).
                    Where(s => s.Id != Process.GetCurrentProcess().Id))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
