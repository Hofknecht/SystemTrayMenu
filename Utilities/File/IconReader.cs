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
    using SystemTrayMenu.DllImports;
    using TAFactory.IconPack;

    /// <summary>
    /// Provides static methods to read system icons for folders and files.
    /// </summary>
    public static class IconReader
    {
        private static readonly ConcurrentDictionary<string, Icon> DictIconCacheMainMenu = new();
        private static readonly ConcurrentDictionary<string, Icon> DictIconCacheSubMenus = new();

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

        // see https://github.com/Hofknecht/SystemTrayMenu/issues/209.
        public static bool MainPreload { get; set; }

        public static void Dispose(bool includingMainMenu = true)
        {
            if (includingMainMenu)
            {
                foreach (Icon icon in DictIconCacheMainMenu.Values)
                {
                    icon?.Dispose();
                }
            }

            foreach (Icon icon in DictIconCacheSubMenus.Values)
            {
                icon?.Dispose();
            }
        }

        public static bool ClearIfCacheTooBig()
        {
            bool cleared = false;
            if (DictIconCacheSubMenus.Count > Properties.Settings.Default.ClearCacheIfMoreThanThisNumberOfItems)
            {
                Dispose(false);
                DictIconCacheSubMenus.Clear();
                cleared = true;
            }

            return cleared;
        }

        public static Icon GetExtractAllIconsLastWithCache(
            string filePath,
            bool updateIconInBackground,
            bool isMainMenu,
            out bool loading)
        {
            bool linkOverlay = false;
            loading = false;
            string key = filePath;

            string extension = Path.GetExtension(filePath);

            if (IsExtensionWithSameIcon(extension))
            {
                key = extension + linkOverlay;
            }

            if (!DictIconCache(isMainMenu).TryGetValue(key, out Icon icon) &&
                !DictIconCache(!isMainMenu).TryGetValue(key, out icon))
            {
                icon = Resources.StaticResources.LoadingIcon;
                loading = true;

                if (updateIconInBackground)
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        DictIconCache(isMainMenu).GetOrAdd(key, GetExtractAllIconsLastSTA(filePath));
                    }
                }
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
                    Thread staThread = new(new ParameterizedThreadStart(StaThreadMethod));
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
                    StringBuilder executable = new(1024);
                    NativeMethods.Shell32FindExecutable(filePath, string.Empty, executable);

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

        public static Icon GetFileIconWithCache(
            string filePath,
            bool linkOverlay,
            bool updateIconInBackground,
            bool isMainMenu,
            out bool loading,
            string keyPath = "")
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

            if (!DictIconCache(isMainMenu).TryGetValue(key, out Icon icon) &&
                !DictIconCache(!isMainMenu).TryGetValue(key, out icon))
            {
                icon = Resources.StaticResources.LoadingIcon;
                loading = true;
                if (updateIconInBackground)
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        DictIconCache(isMainMenu).GetOrAdd(key, GetIconSTA(filePath, linkOverlay, size, null));
                    }
                }
            }

            return icon;
        }

        public static Icon GetFolderIconWithCache(
            string path,
            FolderType folderType,
            bool linkOverlay,
            bool updateIconInBackground,
            bool isMainMenu,
            out bool loading)
        {
            loading = false;

            // always IconSize.Small, because IconSize.Large returns another folder icon than windows explorer
            IconSize size = IconSize.Small;

            string key = path;

            if (!DictIconCache(isMainMenu).TryGetValue(key, out Icon icon) &&
                !DictIconCache(!isMainMenu).TryGetValue(key, out icon))
            {
                icon = Resources.StaticResources.LoadingIcon;
                loading = true;

                if (updateIconInBackground)
                {
                    if (MainPreload)
                    {
                        DictIconCache(isMainMenu).GetOrAdd(key, GetFolder);
                    }
                    else
                    {
                        new Thread(UpdateIconInBackground).Start();
                        void UpdateIconInBackground()
                        {
                            DictIconCache(isMainMenu).GetOrAdd(key, GetFolder);
                        }
                    }
                }
            }

            Icon GetFolder(string keyExtension)
            {
                return GetIconSTA(path, linkOverlay, size, folderType);
            }

            return icon;
        }

        public static Icon GetIconSTA(string path, bool linkOverlay, IconSize size, FolderType? folderType)
        {
            Icon icon = null;
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                icon = GetIcon(path, linkOverlay, size, folderType);
            }
            else
            {
                Thread staThread = new(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object obj)
                {
                    icon = GetIcon(path, linkOverlay, size, folderType);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(icon);
                staThread.Join();
            }

            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            Icon icon = null;
            if (originalIcon != null)
            {
                using Bitmap target = new(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
                using Graphics graphics = Graphics.FromImage(target);
                graphics.DrawIcon(originalIcon, 0, 0);
                graphics.DrawIcon(overlay, new(0, 0, originalIcon.Width + 2, originalIcon.Height + 2));
                target.MakeTransparent(target.GetPixel(1, 1));
                IntPtr hIcon = target.GetHicon();
                icon = (Icon)Icon.FromHandle(hIcon).Clone();
                NativeMethods.User32DestroyIcon(hIcon);
            }

            return icon;
        }

        private static ConcurrentDictionary<string, Icon> DictIconCache(bool isMainMenu)
        {
            if (isMainMenu)
            {
                return DictIconCacheMainMenu;
            }
            else
            {
                return DictIconCacheSubMenus;
            }
        }

        private static bool IsExtensionWithSameIcon(string fileExtension)
        {
            bool isExtensionWithSameIcon = true;
            List<string> extensionsWithDiffIcons = new() { string.Empty, ".EXE", ".LNK", ".ICO", ".URL" };
            if (extensionsWithDiffIcons.Contains(fileExtension.ToUpperInvariant()))
            {
                isExtensionWithSameIcon = false;
            }

            return isExtensionWithSameIcon;
        }

        private static Icon GetIcon(string path, bool linkOverlay, IconSize size, FolderType? type)
        {
            NativeMethods.SHFILEINFO shFileInfo = default;
            uint flags = GetFlags(linkOverlay, size, type);
            uint attribute = type == null ? NativeMethods.FileAttributeNormal :
                NativeMethods.FileAttributeDirectory;
            IntPtr imageList = NativeMethods.Shell32SHGetFileInfo(
                path, attribute, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), flags);
            return GetIcon(path, linkOverlay, shFileInfo, imageList);
        }

        private static uint GetFlags(bool linkOverlay, IconSize size, FolderType? folderType)
        {
            uint flags = NativeMethods.ShgfiIcon | NativeMethods.ShgfiSYSICONINDEX;
            if (linkOverlay)
            {
                flags += NativeMethods.ShgfiLINKOVERLAY;
            }

            if (folderType == FolderType.Open)
            {
                flags += NativeMethods.ShgfiOPENICON;
            }

            if (size == IconSize.Small)
            {
                flags += NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += NativeMethods.ShgfiLARGEICON;
            }

            return flags;
        }

        private static Icon GetIcon(
            string path, bool linkOverlay, NativeMethods.SHFILEINFO shFileInfo, IntPtr imageList)
        {
            Icon icon = null;
            if (imageList != IntPtr.Zero)
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shFileInfo.hIcon;
                }
                else
                {
                    hIcon = NativeMethods.ImageList_GetIcon(
                        imageList, shFileInfo.iIcon, NativeMethods.IldTransparent);
                }

                try
                {
                    icon = (Icon)Icon.FromHandle(hIcon).Clone();
                }
                catch (Exception ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                }

                if (!linkOverlay)
                {
                    NativeMethods.User32DestroyIcon(hIcon);
                }

                NativeMethods.User32DestroyIcon(shFileInfo.hIcon);
            }

            return icon;
        }
    }
}