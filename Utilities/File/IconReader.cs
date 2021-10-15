// <copyright file="IconReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// see also: https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using.

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using TAFactory.IconPack;

    /// <summary>
    /// Provides static methods to read system icons for folders and files.
    /// </summary>
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

        public static bool SingleThread { get; set; }

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

        public static Icon GetExtractAllIconsLastWithCache(string filePath, bool updateIconInBackground, out bool loading)
        {
            bool linkOverlay = false;
            loading = false;
            string key = filePath;

            string extension = Path.GetExtension(filePath);

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
                        DictIconCache.GetOrAdd(key, GetExtractAllIconsLast);
                    }
                }
            }

            Icon GetExtractAllIconsLast(string keyExtension)
            {
                return GetExtractAllIconsLastSTA(filePath);
            }

            static Icon GetExtractAllIconsLastSTA(string filePath)
            {
                Icon icon = null;

                if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                {
                    icon = GetExtractAllIconsLast(filePath);
                }
                else
                {
                    Thread staThread = new Thread(new ParameterizedThreadStart(StaThreadMethod));
                    void StaThreadMethod(object obj)
                    {
                        icon = GetExtractAllIconsLast(filePath);
                    }

                    staThread.SetApartmentState(ApartmentState.STA);
                    staThread.Start(icon);
                    staThread.Join();
                }

                static Icon GetExtractAllIconsLast(string filePath)
                {
                    StringBuilder executable = new StringBuilder(1024);
                    DllImports.NativeMethods.Shell32FindExecutable(filePath, string.Empty, executable);

                    // icon = IconReader.GetFileIcon(executable, false);
                    // e.g. VS 2019 icon, need another icom in imagelist
                    List<Icon> extractedIcons = IconHelper.ExtractAllIcons(
                        executable.ToString());
                    return extractedIcons.Last();
                }

                return icon;
            }

            return icon;
        }

        public static Icon GetFileIconWithCache(string filePath, bool linkOverlay, bool updateIconInBackground, out bool loading, string keyPath = "")
        {
            loading = false;
            string extension = Path.GetExtension(filePath);
            IconSize size = IconSize.Small;
            if (Scaling.Factor > 1)
            {
                size = IconSize.Large;
            }

            string key = filePath;
            if (!string.IsNullOrEmpty(keyPath))
            {
                key = keyPath;
            }

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

            static Icon GetFileIconSTA(string filePath, bool linkOverlay, IconSize size = IconSize.Small)
            {
                Icon icon = null;

                if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                {
                    icon = GetFileIcon(filePath, linkOverlay, size);
                }
                else
                {
                    Thread staThread = new Thread(new ParameterizedThreadStart(StaThreadMethod));
                    void StaThreadMethod(object obj)
                    {
                        icon = GetFileIcon(filePath, linkOverlay, size);
                    }

                    staThread.SetApartmentState(ApartmentState.STA);
                    staThread.Start(icon);
                    staThread.Join();
                }

                return icon;
            }

            return icon;
        }

        public static Icon GetFolderIconWithCache(string path, FolderType folderType, bool linkOverlay, bool updateIconInBackground, out bool loading)
        {
            loading = false;

            // always IconSize.Small, because IconSize.Large returns another folder icon than windows explorer
            IconSize size = IconSize.Small;

            string key = path;

            if (!DictIconCache.TryGetValue(key, out Icon icon))
            {
                icon = LoadingIcon;
                loading = true;

                if (updateIconInBackground)
                {
                    if (SingleThread)
                    {
                        DictIconCache.GetOrAdd(key, GetFolder);
                    }
                    else
                    {
                        new Thread(UpdateIconInBackground).Start();
                        void UpdateIconInBackground()
                        {
                            DictIconCache.GetOrAdd(key, GetFolder);
                        }
                    }
                }
            }

            Icon GetFolder(string keyExtension)
            {
                return GetFolderIconSTA(path, folderType, linkOverlay, size);
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
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                icon = GetFolderIcon(
                    directoryPath,
                    folderType,
                    linkOverlay,
                    size);
            }
            else
            {
                Thread staThread = new Thread(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object obj)
                {
                    icon = GetFolderIcon(
                        directoryPath,
                        folderType,
                        linkOverlay,
                        size);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(icon);
                staThread.Join();
            }

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

            // Removed SHGFI_USEFILEATTRIBUTES, otherwise was wrong folder icon
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
                using Bitmap target = new Bitmap(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
                using Graphics graphics = Graphics.FromImage(target);
                graphics.DrawIcon(originalIcon, 0, 0);
                graphics.DrawIcon(overlay, 0, 0);
                target.MakeTransparent(target.GetPixel(1, 1));
                IntPtr hIcon = target.GetHicon();
                icon = (Icon)Icon.FromHandle(hIcon).Clone();
                DllImports.NativeMethods.User32DestroyIcon(hIcon);
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

        private static Icon GetFileIcon(string filePath, bool linkOverlay, IconSize size = IconSize.Small)
        {
            Icon icon = null;
            DllImports.NativeMethods.SHFILEINFO shfi = default;
            uint flags = DllImports.NativeMethods.ShgfiIcon | DllImports.NativeMethods.ShgfiSYSICONINDEX;

            if (linkOverlay)
            {
                flags += DllImports.NativeMethods.ShgfiLINKOVERLAY;
            }

            // Check the size specified for return.
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
                    // Get icon directly
                    hIcon = shfi.hIcon;
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
                    Log.Warn($"filePath:'{filePath}'", ex);
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