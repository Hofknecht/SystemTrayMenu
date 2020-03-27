using System;
using System.Diagnostics;
using System.Linq;

namespace SystemTrayMenu.Utilities
{
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
                            p.Kill();
                            p.WaitForExit();
                            killedAProcess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Run as single instance failed", ex);
                    }

                    return killedAProcess;
                }
            }
            bool IsAnyOtherInstancesofAppAlreadyRunning()
            {
                //string pid = Process.Id.ToString();
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
