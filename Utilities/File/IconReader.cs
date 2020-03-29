using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.Utilities
{
    // from https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using
    // added ImageList_GetIcon, IconCache, AddIconOverlay

    /// <summary>
    /// Provides static methods to read system icons for both folders and files.
    /// </summary>
    /// <example>
    /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
    /// </example>
    public static class IconReader
    {
        private static readonly ConcurrentDictionary<string, Icon> dictIconCache = new ConcurrentDictionary<string, Icon>();

        public enum IconSize
        {
            Large = 0, //32x32 pixels
            Small = 1 //16x16 pixels
        }

        public enum FolderType
        {
            Open = 0,
            Closed = 1
        }

        public static void Dispose()
        {
            foreach (Icon icon in dictIconCache.Values)
            {
                icon.Dispose();
            }
        }

        public static Icon GetFileIconWithCache(string filePath, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;
            string extension = Path.GetExtension(filePath);

            if (IsExtensionWitSameIcon(extension))
            {
                icon = dictIconCache.GetOrAdd(extension, GetIcon);
                Icon GetIcon(string keyExtension)
                {
                    return GetFileIcon(filePath, linkOverlay, size);
                }
            }
            else
            {
                icon = GetFileIcon(filePath, linkOverlay, size);
            }

            return icon;
        }

        private static bool IsExtensionWitSameIcon(string fileExtension)
        {
            bool isExtensionWitSameIcon = true;
            List<string> extensionsWithDiffIcons = new List<string>
                { ".EXE", ".LNK", ".ICO", ".URL" };
            if (extensionsWithDiffIcons.Contains(fileExtension.ToUpperInvariant()))
            {
                isExtensionWitSameIcon = false;
            }
            return isExtensionWitSameIcon;
        }

        private static Icon GetFileIcon(string filePath, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;
            DllImports.NativeMethods.SHFILEINFO shfi = new DllImports.NativeMethods.SHFILEINFO();
            uint flags = DllImports.NativeMethods.ShgfiIcon | DllImports.NativeMethods.ShgfiSYSICONINDEX;

            //MH: Removed, otherwise wrong icon
            // | Shell32.SHGFI_USEFILEATTRIBUTES ;

            if (true == linkOverlay)
            {
                flags += DllImports.NativeMethods.ShgfiLINKOVERLAY;
            }

            /* Check the size specified for return. */
            if (IconSize.Small == size)
            {
                flags += DllImports.NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += DllImports.NativeMethods.ShgfiLARGEICON;
            }

            IntPtr hImageList = DllImports.NativeMethods.Shell32SHGetFileInfo(filePath,
                DllImports.NativeMethods.FileAttributeNormal,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            if (hImageList != IntPtr.Zero) // got valid handle?
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shfi.hIcon; // Get icon directly
                }
                else
                {
                    // Get icon from .ink without overlay
                    hIcon = DllImports.NativeMethods.ImageList_GetIcon(hImageList, shfi.iIcon, DllImports.NativeMethods.IldTransparent);
                }

                icon = (Icon)Icon.FromHandle(hIcon).Clone();

                // Cleanup
                if (!linkOverlay)
                {
                    DllImports.NativeMethods.User32DestroyIcon(hIcon);
                }

                DllImports.NativeMethods.User32DestroyIcon(shfi.hIcon);
            }

            return icon;
        }

        public static Icon GetFolderIcon(string directoryPath,
            FolderType folderType, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;

            // Need to add size check, although errors generated at present!
            //uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            //MH: Removed SHGFI_USEFILEATTRIBUTES, otherwise was wrong folder icon
            uint flags = DllImports.NativeMethods.ShgfiIcon; // | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (true == linkOverlay)
            {
                flags += DllImports.NativeMethods.ShgfiLINKOVERLAY;
            }

            if (FolderType.Open == folderType)
            {
                flags += DllImports.NativeMethods.ShgfiOPENICON;
            }

            if (IconSize.Small == size)
            {
                flags += DllImports.NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += DllImports.NativeMethods.ShgfiLARGEICON;
            }

            // Get the folder icon
            DllImports.NativeMethods.SHFILEINFO shfi = new DllImports.NativeMethods.SHFILEINFO();
            IntPtr Success = DllImports.NativeMethods.Shell32SHGetFileInfo(directoryPath,
                DllImports.NativeMethods.FileAttributeDirectory,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            if (Success != IntPtr.Zero) // got valid handle?
            {
                Icon.FromHandle(shfi.hIcon);
                icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                DllImports.NativeMethods.User32DestroyIcon(shfi.hIcon);
            }

            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            Icon icon = null;
            if (originalIcon != null)
            {
                using (Bitmap target = new Bitmap(
                    originalIcon.Width, originalIcon.Height,
                    PixelFormat.Format32bppArgb))
                {
                    Graphics graphics = Graphics.FromImage(target);
                    graphics.DrawIcon(originalIcon, 0, 0);
                    graphics.DrawIcon(overlay, 0, 0);
                    target.MakeTransparent(target.GetPixel(1, 1));
                    icon = Icon.FromHandle(target.GetHicon());
                }
            }

            return icon;
        }
    }
}