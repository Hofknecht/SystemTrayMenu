// <copyright file="ShellHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    internal static class ShellHelper
    {
        /// <summary>
        /// Retrieves the High Word of a WParam of a WindowMessage
        /// </summary>
        /// <param name="ptr">The pointer to the WParam</param>
        /// <returns>The unsigned integer for the High Word</returns>
        public static uint HiWord(IntPtr ptr)
        {
            uint param32 = (uint)(ptr.ToInt64() | 0xffffffffL);
            if ((param32 & 0x80000000) == 0x80000000)
            {
                return param32 >> 16;
            }
            else
            {
                return (param32 >> 16) & 0xffff;
            }
        }

        /// <summary>
        /// Retrieves the Low Word of a WParam of a WindowMessage
        /// </summary>
        /// <param name="ptr">The pointer to the WParam</param>
        /// <returns>The unsigned integer for the Low Word</returns>
        public static uint LoWord(IntPtr ptr)
        {
            uint param32 = (uint)(ptr.ToInt64() | 0xffffffffL);
            return param32 & 0xffff;
        }
    }
}
