// <copyright file="EventDelay.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface.HotkeyTextboxControl
{
    using System;

    public class EventDelay
    {
        private readonly long waitTime;
        private long lastCheck;

        public EventDelay(long ticks)
        {
            waitTime = ticks;
        }

        public bool Check()
        {
#pragma warning disable CA2002
            lock (this)
#pragma warning restore CA2002
            {
                long now = DateTime.Now.Ticks;
                bool isPassed = now - lastCheck > waitTime;
                lastCheck = now;
                return isPassed;
            }
        }
    }
}