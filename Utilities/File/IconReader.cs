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
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.DllImports;

    /// <summary>
    /// Provides static methods to read system icons for folders and files.
    /// </summary>
    public static class IconReader
    {
        private static readonly ConcurrentDictionary<string, Icon?> IconDictPersistent = new();
        private static readonly ConcurrentDictionary<string, Icon?> IconDictCache = new();

        public enum IconSize
        {
            Large = 0, // 32x32 pixels
            Small = 1, // 16x16 pixels
        }

        // see https://github.com/Hofknecht/SystemTrayMenu/issues/209.
        public static bool IsPreloading { get; set; } = true;

        public static void ClearCacheWhenLimitReached()
        {
            if (IconDictCache.Count > Properties.Settings.Default.ClearCacheIfMoreThanThisNumberOfItems)
            {
                foreach (Icon? icon in IconDictCache.Values)
                {
                    icon?.Dispose();
                }

                IconDictCache.Clear();
                GC.Collect();
            }
        }

        public static void RemoveIconFromCache(string path)
        {
            if (IconDictPersistent.Remove(path, out Icon? iconToRemove))
            {
                iconToRemove?.Dispose();
            }
        }

        public static bool GetFileIconWithCache(
            string path,
            string resolvedPath,
            bool linkOverlay,
            bool checkPersistentFirst,
            Action<BitmapSource?> onIconLoaded)
        {
            bool cacheHit;
            Icon? icon;
            string key;
            string extension = Path.GetExtension(path);
            if (IsExtensionWithSameIcon(extension))
            {
                key = extension + linkOverlay;
            }
            else
            {
                key = path;
            }

            if (!DictIconCache(checkPersistentFirst).TryGetValue(key, out icon) &&
                !DictIconCache(!checkPersistentFirst).TryGetValue(key, out icon))
            {
                cacheHit = false;

                new Thread(UpdateIconInBackground).Start();
                void UpdateIconInBackground()
                {
                    Icon? icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFile);
                    BitmapSource? bitmap = icon?.ToBitmapSource();
                    bitmap?.Freeze();
                    onIconLoaded(bitmap);
                }

                Icon? FactoryIconFile(string keyExtension)
                {
                    return GetIcon(path, resolvedPath, linkOverlay, false);
                }
            }
            else
            {
                cacheHit = true;
                BitmapSource? bitmap = icon?.ToBitmapSource();
                bitmap?.Freeze();
                onIconLoaded(bitmap);
            }

            return cacheHit;
        }

        public static bool GetFolderIconWithCache(
            string path,
            bool linkOverlay,
            bool checkPersistentFirst,
            Action<BitmapSource?> onIconLoaded)
        {
            bool cacheHit;
            Icon? icon;
            string key = path;
            if (!DictIconCache(checkPersistentFirst).TryGetValue(key, out icon) &&
                !DictIconCache(!checkPersistentFirst).TryGetValue(key, out icon))
            {
                cacheHit = false;

                if (IsPreloading)
                {
                    cacheHit = true;
                    icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFolder);
                    BitmapSource? bitmap = icon?.ToBitmapSource();
                    bitmap?.Freeze();
                    onIconLoaded(bitmap);
                }
                else
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        Icon? icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFolder);
                        BitmapSource? bitmap = icon?.ToBitmapSource();
                        bitmap?.Freeze();
                        onIconLoaded(bitmap);
                    }
                }

                Icon? FactoryIconFolder(string keyExtension)
                {
                    return GetIcon(path, path, linkOverlay, true);
                }
            }
            else
            {
                cacheHit = true;
                BitmapSource? bitmap = icon?.ToBitmapSource();
                bitmap?.Freeze();
                onIconLoaded(bitmap);
            }

            return cacheHit;
        }

        public static Icon? GetIcon(string path, string resolvedPath, bool linkOverlay, bool isFolder, IconSize? forceSize = null)
        {
            IconSize size;
            if (forceSize.HasValue)
            {
                size = forceSize.Value;
            }
            else if (Scaling.Factor >= 1.25f ||
                Scaling.FactorByDpi >= 1.25f ||
                Properties.Settings.Default.IconSizeInPercent / 100f >= 1.25f)
            {
                // IconSize.Large returns another folder icon than windows explorer
                size = IconSize.Large;
            }
            else
            {
                size = IconSize.Small;
            }

            Icon? icon;
            if (Path.GetExtension(path).Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
            {
                icon = Icon.ExtractAssociatedIcon(path);
            }
            else if (File.Exists(resolvedPath) &&
                Path.GetExtension(resolvedPath).Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
            {
                icon = Icon.ExtractAssociatedIcon(resolvedPath);
                if (linkOverlay && icon != null)
                {
                    icon = AddIconOverlay(icon, Properties.Resources.LinkArrow);
                }
            }
            else
            {
                NativeMethods.SHFILEINFO shFileInfo = default;
                uint flags = GetFlags(linkOverlay, size);
                uint attribute = isFolder ? NativeMethods.FileAttributeDirectory : NativeMethods.FileAttributeNormal;
                IntPtr imageList = NativeMethods.Shell32SHGetFileInfo(path, attribute, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), flags);
                icon = GetIcon(path, linkOverlay, shFileInfo, imageList);
            }

            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            using Bitmap target = new(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
            using Graphics graphics = Graphics.FromImage(target);
            graphics.DrawIcon(originalIcon, 0, 0);
            graphics.DrawIcon(overlay, new(0, 0, originalIcon.Width + 2, originalIcon.Height + 2));
            target.MakeTransparent(target.GetPixel(1, 1));
            IntPtr hIcon = target.GetHicon();
            Icon icon = (Icon)Icon.FromHandle(hIcon).Clone();
            NativeMethods.User32DestroyIcon(hIcon);
            return icon;
        }

        private static ConcurrentDictionary<string, Icon?> DictIconCache(bool checkPersistentFirst)
            => checkPersistentFirst ? IconDictPersistent : IconDictCache;

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

        private static uint GetFlags(bool linkOverlay, IconSize size)
        {
            uint flags = NativeMethods.ShgfiIcon | NativeMethods.ShgfiSYSICONINDEX;
            if (linkOverlay)
            {
                flags += NativeMethods.ShgfiLINKOVERLAY;
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

        private static Icon? GetIcon(
            string path, bool linkOverlay, NativeMethods.SHFILEINFO shFileInfo, IntPtr imageList)
        {
            Icon? icon = null;
            if (imageList != IntPtr.Zero)
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shFileInfo.hIcon;
                }
                else
                {
                    hIcon = NativeMethods.ImageList_GetIcon(imageList, shFileInfo.iIcon, NativeMethods.IldTransparent);
                }

                try
                {
                    // Note: Destroying hIcon after FromHandle will invalidate the Icon, so we do NOT destroy it, despite the request from documentation:
                    //       https://learn.microsoft.com/en-us/dotnet/api/system.drawing.icon.fromhandle?view=dotnet-plat-ext-7.0
                    //       Reason is https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Icon.cs,555 (FromHandle)
                    //       It is not taking over the ownership, data will be deleted upon destroying the original icon, so a clone is required.
                    //       With Clone we actually get a new handle, so we can free up the original handle without killing our copy.
                    //       Using Clone will also restore the ownership of the new icon handle, so we do not have to call DestroyIcon on it by ourself.
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
