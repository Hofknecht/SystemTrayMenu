// <copyright file="DragDropHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Windows;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    public static class DragDropHelper
    {
        public static void DragEnter(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData("UniformResourceLocator");

            if (data is MemoryStream memoryStream)
            {
                byte[] bytes = memoryStream.ToArray();
                Encoding encod = Encoding.ASCII;
                string url = encod.GetString(bytes);
                if (!string.IsNullOrEmpty(url))
                {
                    e.Effects = DragDropEffects.Copy;
                }
            }
        }

        public static void DragDrop(object? sender, DragEventArgs e)
        {
            string path = ((Menu?)sender)?.RowDataParent?.ResolvedPath ?? Config.Path;
            object data = e.Data.GetData("UniformResourceLocator");
            if (data is not MemoryStream ms)
            {
                return;
            }

            byte[] bytes = ms.ToArray();
            Encoding encod = Encoding.ASCII;
            string url = encod.GetString(bytes);

            new Thread(CreateShortcutInBackground).Start();
            void CreateShortcutInBackground()
            {
                CreateShortcut(url.Replace("\0", string.Empty), path);
            }
        }

        private static void CreateShortcut(string url, string pathToStoreFile)
        {
            string title = GetUrlShortcutTitle(url);
            string fileNamePathShortcut = pathToStoreFile + "\\" + title.Trim() + ".url";
            WriteShortcut(url, null, fileNamePathShortcut);
            string pathIcon = DownloadUrlIcon(url);
            if (!string.IsNullOrEmpty(pathIcon))
            {
                WriteShortcut(url, pathIcon, fileNamePathShortcut);
            }
        }

        private static string GetUrlShortcutTitle(string url)
        {
            string title = url
                .Replace("/", " ")
                .Replace("https", string.Empty)
                .Replace("http", string.Empty);
            string invalid =
                new string(Path.GetInvalidFileNameChars()) +
                new string(Path.GetInvalidPathChars());
            foreach (char character in invalid)
            {
                title = title.Replace(character.ToString(), string.Empty);
            }

            title = Truncate(title, 128); // max 255
            return title;
        }

        private static string Truncate(string value, int maxLength)
        {
            if (!string.IsNullOrEmpty(value) &&
                value.Length > maxLength)
            {
                value = value[..maxLength];
            }

            return value;
        }

        private static void WriteShortcut(string url, string? pathIcon, string fileNamePathShortcut)
        {
            try
            {
                if (File.Exists(fileNamePathShortcut))
                {
                    File.Delete(fileNamePathShortcut);
                }

                StreamWriter writer = new(fileNamePathShortcut);
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine($"URL={url.TrimEnd('\0')}");
                writer.WriteLine("IconIndex=0");
                writer.WriteLine($"HotKey=0");
                writer.WriteLine($"IDList=");
                if (!string.IsNullOrEmpty(pathIcon))
                {
                    writer.WriteLine($"IconFile={pathIcon}");
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(WriteShortcut)} failed", ex);
            }
        }

        private static string DownloadUrlIcon(string url)
        {
            string pathIcon = string.Empty;
            string pathToStoreIcons = Properties.Settings.Default.PathIcoDirectory;
            Uri uri = new(url);
            string hostname = uri.Host.ToString();
            string pathIconPng = Path.Combine(pathToStoreIcons, $"{hostname}.png");
            string urlGoogleIconDownload = @"http://www.google.com/s2/favicons?sz=32&domain=" + url;
            HttpClient client = new();

            try
            {
                if (!Directory.Exists(pathToStoreIcons))
                {
                    Directory.CreateDirectory(pathToStoreIcons);
                }

                Stream stream = client.GetStreamAsync(urlGoogleIconDownload).Result;
                using var fileStream = File.Create(pathIconPng);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
                fileStream.Close();

                pathIcon = Path.Combine(pathToStoreIcons, $"{hostname}.ico");
                if (!ImagingHelper.ConvertToIcon(pathIconPng, pathIcon, 32))
                {
                    Log.Info("Failed to convert icon.");
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(DownloadUrlIcon)} failed", ex);
            }

            try
            {
                if (File.Exists(pathIconPng))
                {
                    File.Delete(pathIconPng);
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(DownloadUrlIcon)} failed to delete {pathIconPng}", ex);
            }

            return pathIcon;
        }
    }
}
