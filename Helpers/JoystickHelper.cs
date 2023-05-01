// <copyright file="JoystickHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Reactive.Linq;
    using System.Windows.Input;
    using System.Windows.Threading;
    using DevDecoder.HIDDevices;
    using DevDecoder.HIDDevices.Controllers;
    using DevDecoder.HIDDevices.Converters;

    public class JoystickHelper : IDisposable
    {
        private readonly Dispatcher dispatchter = Dispatcher.CurrentDispatcher;
        private readonly Devices devices;
        private readonly IDisposable? subscriptionGamepads;
        private IDisposable? subscriptionGamepadControls;
        private Gamepad? gamepad;

        public JoystickHelper()
        {
            devices = new();
            subscriptionGamepads = devices.Controllers<Gamepad>().Subscribe(g =>
            {
                // If we already have a connected gamepad ignore any more.
                // ReSharper disable once AccessToDisposedClosure
                if (gamepad?.IsConnected == true)
                {
                    return;
                }

                gamepad = g;
                g.Connect();

                subscriptionGamepadControls = g.Changes.Subscribe(controls =>
                {
                    foreach (var control in controls)
                    {
                        if (control.PropertyName.Equals("BButton"))
                        {
                            if (g.BButton)
                            {
                                // TODO: Check if dispatcher is required or will be dispatched by keypressed any way
                                dispatchter.Invoke(() => KeyPressed?.Invoke(Key.Enter, ModifierKeys.None));
                            }
                        }
                        else if (control.PropertyName.Equals("Hat"))
                        {
                            Key key = Key.None;
                            switch (g.Hat)
                            {
                                case Direction.North: key = Key.Up; break;
                                case Direction.East: key = Key.Right; break;
                                case Direction.South: key = Key.Down; break;
                                case Direction.West: key = Key.Left; break;
                            }

                            if (key != Key.None)
                            {
                                // TODO: Check if dispatcher is required or will be dispatched by keypressed any way
                                dispatchter.Invoke(() => KeyPressed?.Invoke(key, ModifierKeys.None));
                            }
                        }
                    }
                });
            });
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
                subscriptionGamepads?.Dispose();
                subscriptionGamepadControls?.Dispose();
                gamepad?.Dispose();
                gamepad = null;
                devices.Dispose();
            }
        }
    }
}
