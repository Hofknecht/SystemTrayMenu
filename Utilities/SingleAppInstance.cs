using System;
using System.ComponentModel;
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
