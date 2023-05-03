// <copyright file="JoystickHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Threading;
    using System.Timers;
    using System.Windows.Input;
    using System.Windows.Threading;
    using HidSharp;
    using HidSharp.Reports;

    public class JoystickHelper : IDisposable
    {
        private readonly Dispatcher dispatchter = Dispatcher.CurrentDispatcher;
#if COLLECTUSAGES
        private readonly System.Collections.Generic.Dictionary<Usage, int> usagesCollection = new();
#endif
        private readonly System.Timers.Timer pollGamepad = new();
        private HidDevice? connectedDevice;

        public JoystickHelper()
        {
            pollGamepad.Interval = 200;
            DeviceList.Local.Changed += QueryAndConnect;
            QueryAndConnect(this, new ());
        }

        ~JoystickHelper() // the finalizer
        {
            Dispose(false);
        }

        public event Action<Key, ModifierKeys>? KeyPressed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DeviceList.Local.Changed -= QueryAndConnect;
                pollGamepad.Dispose();
                connectedDevice = null;
            }
        }

        private void QueryAndConnect(object? sender, DeviceListChangedEventArgs e)
        {
            bool stillConnected = false;

            foreach (var hidDevice in DeviceList.Local.GetHidDevices())
            {
                if (connectedDevice == hidDevice)
                {
                    stillConnected = true;
                    break;
                }
                else if (connectedDevice != null)
                {
                    // We are just checking if connected device is still there
                    continue;
                }

                try
                {
                    var reportDescriptor = hidDevice.GetReportDescriptor();
                    foreach (var ditem in reportDescriptor.DeviceItems)
                    {
                        foreach (uint deviceUsage in ditem.Usages.GetAllValues())
                        {
                            if (deviceUsage == (uint)Usage.GenericDesktopGamepad)
                            {
                                var options = new OpenConfiguration();
                                options.SetOption(OpenOption.Interruptible, true);
                                HidStream stream = hidDevice.Open();
                                stream.ReadTimeout = Timeout.Infinite;

                                var buffer = new byte[hidDevice.GetMaxInputReportLength()];
                                var inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();
                                inputReceiver.Start(stream);
                                inputReceiver.WaitHandle.WaitOne();

                                if (!inputReceiver.IsRunning)
                                {
                                    break;
                                }

                                var inputParser = ditem.CreateDeviceItemInputParser();
                                bool firstPoll = true;

                                connectedDevice = hidDevice;

                                pollGamepad.Elapsed += PollGamepad;
                                pollGamepad.Start();
                                void PollGamepad(object? sender, ElapsedEventArgs e)
                                {
                                    pollGamepad.Stop();

                                    try
                                    {
                                        bool wasPressedButton1 = false;
                                        bool wasPressedButton2 = false;
                                        bool wasPressedPadUp = false;
                                        bool wasPressedPadDown = false;
                                        bool wasPressedPadLeft = false;
                                        bool wasPressedPadRight = false;

                                        while (inputReceiver.TryRead(buffer, 0, out var report))
                                        {
                                            if (!inputParser.TryParseReport(buffer, 0, report))
                                            {
                                                continue;
                                            }

                                            while (inputParser.HasChanged)
                                            {
                                                var index = inputParser.GetNextChangedIndex();
                                                var dataValue = inputParser.GetValue(index);
                                                foreach (uint usage in dataValue.Usages)
                                                {
                                                    int logicalValue = dataValue.GetLogicalValue();
#if COLLECTUSAGES
                                                    if (!usagesCollection.ContainsKey((Usage)usage))
                                                    {
                                                        usagesCollection.Add((Usage)usage, 0);
                                                    }
                                                    else
                                                    {
                                                        usagesCollection[(Usage)usage]++;
                                                    }
#endif

                                                    // See page 14 and referenced subsections, e.g. Generic Desktop Controls
                                                    // https://www.usb.org/sites/default/files/documents/hut1_12v2.pdf
                                                    switch ((Usage)usage)
                                                    {
                                                        case Usage.Button1:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedButton1 = true;
                                                            }

                                                            break;
                                                        case Usage.Button2:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedButton2 = true;
                                                            }

                                                            break;
                                                        case Usage.GenericDesktopDPadUp:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedPadUp = true;
                                                            }

                                                            break;
                                                        case Usage.GenericDesktopDPadDown:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedPadDown = true;
                                                            }

                                                            break;
                                                        case Usage.GenericDesktopDPadLeft:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedPadLeft = true;
                                                            }

                                                            break;
                                                        case Usage.GenericDesktopDPadRight:
                                                            if (logicalValue != 0)
                                                            {
                                                                wasPressedPadRight = true;
                                                            }

                                                            break;
                                                        case Usage.GenericDesktopHatSwitch:
                                                        {
                                                            switch (hidDevice.VendorID)
                                                            {
                                                                case 1356: // Sony
                                                                    switch (logicalValue)
                                                                    {
                                                                        case 0: wasPressedPadUp = true; break;
                                                                        case 2: wasPressedPadRight = true; break;
                                                                        case 4: wasPressedPadDown = true; break;
                                                                        case 6: wasPressedPadLeft = true; break;
                                                                    }

                                                                    break;
                                                                default:
                                                                    switch (logicalValue)
                                                                    {
                                                                        case 1: wasPressedPadUp = true; break;
                                                                        case 3: wasPressedPadRight = true; break;
                                                                        case 5: wasPressedPadDown = true; break;
                                                                        case 7: wasPressedPadLeft = true; break;
                                                                    }

                                                                    break;
                                                                }

                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        // TODO: Check if dispatcher is required or will be dispatched by keypressed any way
                                        if (firstPoll)
                                        {
                                            firstPoll = false;
                                        }
                                        else if (wasPressedButton1 || wasPressedButton2)
                                        {
                                            dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Enter, ModifierKeys.None));
                                        }
                                        else if (wasPressedPadUp)
                                        {
                                            dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Up, ModifierKeys.None));
                                        }
                                        else if (wasPressedPadDown)
                                        {
                                            dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Down, ModifierKeys.None));
                                        }
                                        else if (wasPressedPadLeft)
                                        {
                                            dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Left, ModifierKeys.None));
                                        }
                                        else if (wasPressedPadRight)
                                        {
                                            dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Right, ModifierKeys.None));
                                        }

                                        pollGamepad.Start();
                                    }
                                    catch (Exception)
                                    {
                                        connectedDevice = null;
                                    }
                                }

                                // early exit
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // try again on next timer tick
                }
            }

            if (!stillConnected && connectedDevice != null)
            {
                pollGamepad.Stop();
                connectedDevice = null;
            }
        }
    }
}
