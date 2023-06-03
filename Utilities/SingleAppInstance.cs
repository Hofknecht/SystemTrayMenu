// <copyright file="SingleAppInstance.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using SystemTrayMenu.Business;

    internal static class SingleAppInstance
    {
        private const string IpcServiceName = nameof(SingleAppInstance);
        private const string IpcWakeupCmd = "wakeup";
        private const string IpcWakeupResponseOK = "OK";
        private static IpcPipe? ipcPipe;

        internal static event Action? Wakeup;

        internal static bool Initialize()
        {
            bool success = true;

            try
            {
                foreach (Process p in
                    Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).
                       Where(s => s.Id != Environment.ProcessId))
                {
                    try
                    {
                        if (Properties.Settings.Default.SendHotkeyInsteadKillOtherInstances)
                        {
                            // Instead of using hotkeys we use IPC via pipes
                            string pipeName = IpcServiceName + "-" + p.Id.ToString();
                            ipcPipe = new(1, pipeName);
                            string response = ipcPipe.SendToServer(IpcWakeupCmd) ?? string.Empty;
                            if (!string.Equals(response, IpcWakeupResponseOK))
                            {
                                throw new Exception("Error at IPC pipe \"" + pipeName + "\": \"" + response + "\"");
                            }

                            ipcPipe.Dispose();
                            ipcPipe = null;
                            success = false; // This is "success" but it means we cannot start this instance -> false
                        }
                        else
                        {
                            if (!p.CloseMainWindow())
                            {
                                p.Kill();
                            }

                            p.WaitForExit();
                            p.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Run as single instance failed", ex);
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Run as single instance failed", ex);
                success = false;
            }

            if (success)
            {
                // We are the only process running, so we are responsible for the IPC server
                ipcPipe = new(1, IpcServiceName + "-" + Environment.ProcessId.ToString());
                ipcPipe.StartServer((request) =>
                {
                    if (string.Equals(request, IpcWakeupCmd))
                    {
                        Wakeup?.Invoke();
                        return IpcWakeupResponseOK;
                    }

                    return string.Empty;
                });
            }

            return success;
        }

        internal static void Unload()
        {
            ipcPipe?.Dispose();
        }
    }
}
