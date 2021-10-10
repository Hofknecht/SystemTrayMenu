// <copyright file="IconReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

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
        private static readonly ConcurrentDictionary<string, Icon> DictIconCache = new ConcurrentDictionary<string, Icon>();
        private static readonly Icon LoadingIcon = Properties.Resources.Loading;

        // private static readonly object ReadIcon = new object();
        public enum IconSize
        {
            Large = 0, // 32x32 pixels
            Small = 1, // 16x16 pixels
        }

        public enum FolderType
        {
            Open = 0,
            Closed = 1,
        }

        public static void Dispose()
        {
            foreach (Icon icon in DictIconCache.Values)
            {
                icon?.Dispose();
            }
        }

        public static bool ClearIfCacheTooBig()
        {
            bool cleared = false;
            if (DictIconCache.Count > 200)
            {
                Dispose();
                DictIconCache.Clear();
                cleared = true;
            }

            return cleared;
        }

        public static Icon GetFileIconWithCache(string filePath, bool linkOverlay, bool updateIconInBackground, out bool loading)
        {
            loading = false;
            string extension = Path.GetExtension(filePath);
            IconSize size = IconSize.Small;
            if (Scaling.Factor > 1)
            {
                size = IconSize.Large;
            }

            string key = filePath;
            if (IsExtensionWithSameIcon(extension))
            {
                key = extension + linkOverlay;
            }

            if (!DictIconCache.TryGetValue(key, out Icon icon))
            {
                icon = LoadingIcon;
                loading = true;

                if (updateIconInBackground)
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        DictIconCache.GetOrAdd(key, GetIcon);
                    }
                }
            }

            Icon GetIcon(string keyExtension)
            {
                return GetFileIconSTA(filePath, linkOverlay, size);
            }

            return icon;
        }

        public static Icon GetFolderIconSTA(
            string directoryPath,
            FolderType folderType,
            bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;

            Task<Icon> task = Task.Factory.StartNew(() => GetFolderIcon(
                directoryPath,
                folderType,
                linkOverlay,
                size));
            icon = task.Result;

            return icon;
        }

        public static Icon GetFolderIcon(
            string directoryPath,
            FolderType folderType,
            bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;

            // Need to add size check, although errors generated at present!
            // uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            // MH: Removed SHGFI_USEFILEATTRIBUTES, otherwise was wrong folder icon
            uint flags = DllImports.NativeMethods.ShgfiIcon; // | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (linkOverlay)
            {
                flags += DllImports.NativeMethods.ShgfiLINKOVERLAY;
            }

            if (folderType == FolderType.Open)
            {
                flags += DllImports.NativeMethods.ShgfiOPENICON;
            }

            if (size == IconSize.Small)
            {
                flags += DllImports.NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += DllImports.NativeMethods.ShgfiLARGEICON;
            }

            // Get the folder icon
            DllImports.NativeMethods.SHFILEINFO shfi = default;
            IntPtr success = DllImports.NativeMethods.Shell32SHGetFileInfo(
                directoryPath,
                DllImports.NativeMethods.FileAttributeDirectory,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            if (success != IntPtr.Zero &&
                shfi.hIcon != IntPtr.Zero)
            {
                try
                {
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DllImports.NativeMethods.User32DestroyIcon(shfi.hIcon);
                }
                catch (Exception ex)
                {
                    Log.Error($"directoryPath:'{directoryPath}'", ex);
                }
            }

            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            Icon icon = null;
            if (originalIcon != null)
            {
                using Bitmap target = new Bitmap(
                    originalIcon.Width,
                    originalIcon.Height,
                    PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(target);
                graphics.DrawIcon(originalIcon, 0, 0);
                graphics.DrawIcon(overlay, 0, 0);
                target.MakeTransparent(target.GetPixel(1, 1));
                icon = Icon.FromHandle(target.GetHicon());
            }

            return icon;
        }

        private static bool IsExtensionWithSameIcon(string fileExtension)
        {
            bool isExtensionWithSameIcon = true;
            List<string> extensionsWithDiffIcons = new List<string>
                { string.Empty, ".EXE", ".LNK", ".ICO", ".URL" };
            if (extensionsWithDiffIcons.Contains(fileExtension.ToUpperInvariant()))
            {
                isExtensionWithSameIcon = false;
            }

            return isExtensionWithSameIcon;
        }

        private static Icon GetFileIconSTA(string filePath, bool linkOverlay, IconSize size = IconSize.Small)
        {
            Icon icon = null;

            Task<Icon> task = Task.Factory.StartNew(() => GetFileIcon(filePath, linkOverlay, size));
            icon = task.Result;

            return icon;
        }

        private static Icon GetFileIcon(string filePath, bool linkOverlay, IconSize size = IconSize.Small)
        {
            Icon icon = null;
            DllImports.NativeMethods.SHFILEINFO shfi = default;
            uint flags = DllImports.NativeMethods.ShgfiIcon | DllImports.NativeMethods.ShgfiSYSICONINDEX;

            if (linkOverlay)
            {
                flags += DllImports.NativeMethods.ShgfiLINKOVERLAY;
            }

            /* Check the size specified for return. */
            if (size == IconSize.Small)
            {
                flags += DllImports.NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += DllImports.NativeMethods.ShgfiLARGEICON;
            }

            IntPtr hImageList = DllImports.NativeMethods.Shell32SHGetFileInfo(
                filePath,
                DllImports.NativeMethods.FileAttributeNormal,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            if (hImageList != IntPtr.Zero)
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

                try
                {
                    // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
                    icon = (Icon)Icon.FromHandle(hIcon).Clone();
                }
                catch (Exception ex)
                {
                    Log.Error($"filePath:'{filePath}'", ex);
                }

                // Cleanup
                if (!linkOverlay)
                {
                    DllImports.NativeMethods.User32DestroyIcon(hIcon);
                }

                DllImports.NativeMethods.User32DestroyIcon(shfi.hIcon);
            }

            return icon;
        }
    }
}