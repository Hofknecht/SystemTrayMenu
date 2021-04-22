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
    using System.Threading.Tasks;
    using SystemTrayMenu.DllImports;
    using TAFactory.IconPack;

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

        public static Icon GetFileIconWithCache(string filePath)
        {
            Icon icon = null;
            string extension = Path.GetExtension(filePath);

            if (IsExtensionWitSameIcon(extension))
            {
                icon = DictIconCache.GetOrAdd(extension, GetIcon);
                Icon GetIcon(string keyExtension)
                {
                    return GetFileIconSTA(filePath);
                }
            }
            else
            {
                icon = GetFileIconSTA(filePath);
            }

            return icon;
        }

        public static Icon GetFolderIconSTA(string directoryPath)
        {
            Task<Icon> task = Task.Factory.StartNew(() => IconsFromSystemCache.GetIcon(directoryPath));
            return task.Result;
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

        private static bool IsExtensionWitSameIcon(string fileExtension)
        {
            bool isExtensionWitSameIcon = true;
            List<string> extensionsWithDiffIcons = new List<string>
                { string.Empty, ".EXE", ".LNK", ".ICO", ".URL" };
            if (extensionsWithDiffIcons.Contains(fileExtension.ToUpperInvariant()))
            {
                isExtensionWitSameIcon = false;
            }

            return isExtensionWitSameIcon;
        }

        private static Icon GetFileIconSTA(string filePath)
        {
            Task<Icon> task = Task.Factory.StartNew(() => IconsFromSystemCache.GetIcon(filePath));
            return task.Result;
        }
    }
}