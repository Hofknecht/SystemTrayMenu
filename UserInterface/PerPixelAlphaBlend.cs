// <copyright file="PerPixelAlphaBlend.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    internal static class PerPixelAlphaBlend
    {
        public static void SetBitmap(Bitmap bitmap, int left, int top, IntPtr handle, double opacityInPercentage)
        {
            int opacity = (int)(opacityInPercentage * 255);
            SetBitmap(bitmap, (byte)opacity, left, top, handle);
        }

        public static void SetBitmap(Bitmap bitmap, byte opacity, int left, int top, IntPtr handle)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
            }

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new(0, 0);
                Win32.Point topPos = new(left, top);
                Win32.BLENDFUNCTION blend = new();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    Win32.DeleteObject(hBitmap);
                }

                Win32.DeleteDC(memDc);
            }
        }
    }
}
