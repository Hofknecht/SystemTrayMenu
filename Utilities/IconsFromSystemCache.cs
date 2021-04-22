// <copyright file="IconsFromSystemCache.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using SystemTrayMenu.DllImports;

    public static partial class IconsFromSystemCache
    {
        /// <summary>
        /// Get Icon from system cache.
        /// http://pinvoke.net/default.aspx/Interfaces/IShellItem.html?diff=y.
        /// https://github.com/Hofknecht/SystemTrayMenu/issues/149.
        /// </summary>
        /// <param name="filename">filename.</param>
        /// <returns>Icon.</returns>
        public static Icon GetIcon(string filename)
        {
            Icon icon = null;

            // GUID of IShellItem.
            Guid uuid = new Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe");

            try
            {
                NativeMethods.SHCreateItemFromParsingName(filename, IntPtr.Zero, uuid, out IShellItem ppsi);
                IntPtr hbitmap = IntPtr.Zero;
                ((IShellItemImageFactory)ppsi).GetImage(new SIZE(16, 16), SIIGBF.SIIGBF_ICONONLY, out hbitmap);

                Bitmap bitmap = GetBitmapFromHBitmap(hbitmap);
                NativeMethods.Gdi32DeleteObject(hbitmap);
                bitmap.MakeTransparent();
                IntPtr icH = bitmap.GetHicon();

                icon = (Icon)Icon.FromHandle(icH).Clone();
                NativeMethods.User32DestroyIcon(icH);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                if (ex is FileNotFoundException)
                {
                    Log.Warn($"filename:'{filename}'", ex);
                }
                else
                {
                    Log.Error($"filename:'{filename}'", ex);

                    // throw; // comment in to remove CA1031
                }
            }

            return icon;
        }

        /// <summary>
        /// Preserving Alpha channel
        /// https://stackoverflow.com/questions/4627376/use-native-hbitmap-in-c-sharp-while-preserving-alpha-channel-transparency/9291151#9291151.
        /// (when using "Bitmap image = Image.FromHbitmap(hbitmap);" alpha channel lost).
        /// </summary>
        /// <param name="nativeHBitmap">nativeHBitmap.</param>
        /// <returns>Bitmap.</returns>
        private static Bitmap GetBitmapFromHBitmap(IntPtr nativeHBitmap)
        {
            Bitmap bmp = Image.FromHbitmap(nativeHBitmap);

            if (Image.GetPixelFormatSize(bmp.PixelFormat) < 32)
            {
                return bmp;
            }

            if (IsAlphaBitmap(bmp, out BitmapData bmpData))
            {
                return GetlAlphaBitmapFromBitmapData(bmpData);
            }

            return bmp;
        }

        private static Bitmap GetlAlphaBitmapFromBitmapData(BitmapData bmpData)
        {
            return new Bitmap(
                    bmpData.Width,
                    bmpData.Height,
                    bmpData.Stride,
                    PixelFormat.Format32bppArgb,
                    bmpData.Scan0);
        }

        private static bool IsAlphaBitmap(Bitmap bmp, out BitmapData bmpData)
        {
            Rectangle bmBounds = new Rectangle(0, 0, bmp.Width, bmp.Height);

            bmpData = bmp.LockBits(bmBounds, ImageLockMode.ReadOnly, bmp.PixelFormat);

            try
            {
                for (int y = 0; y <= bmpData.Height - 1; y++)
                {
                    for (int x = 0; x <= bmpData.Width - 1; x++)
                    {
                        Color pixelColor = Color.FromArgb(
                            Marshal.ReadInt32(bmpData.Scan0, (bmpData.Stride * y) + (4 * x)));

                        if (pixelColor.A > 0 & pixelColor.A < 255)
                        {
                            return true;
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bmpData);
            }

            return false;
        }
    }
}
