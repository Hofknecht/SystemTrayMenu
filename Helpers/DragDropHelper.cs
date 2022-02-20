// <copyright file="DragDropHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.UserInterface;

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
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        public static void DragDrop(object sender, DragEventArgs e)
        {
            Menu menu = (Menu)sender;
            string path;
            if (menu != null)
            {
                RowData rowData = (RowData)menu.Tag;
                if (rowData != null)
                {
                    path = rowData.TargetFilePath;
                }
                else
                {
                    path = Config.Path;
                }
            }
            else
            {
                path = Config.Path;
            }

            object data = e.Data.GetData("UniformResourceLocator");
            MemoryStream ms = data as MemoryStream;
            byte[] bytes = ms.ToArray();
            Encoding encod = Encoding.ASCII;
            string url = encod.GetString(bytes);
            CreateShortcut(url.Replace("\0", string.Empty), path);
        }

        private static void CreateShortcut(string url, string pathToStoreFile)
        {
            string pathToStoreIcons = Path.Combine(pathToStoreFile, "ico");
            if (!Directory.Exists(pathToStoreIcons))
            {
                Directory.CreateDirectory(pathToStoreIcons);
            }

            Uri uri = new(url);
            string hostname = uri.Host.ToString();

            string pathIconPng = Path.Combine(pathToStoreIcons, $"{hostname}.png");

            string urlGoogleIconDownload = @"http://www.google.com/s2/favicons?sz=32&domain=" + url;
            HttpClient client = new();
            using (HttpResponseMessage response = client.GetAsync(urlGoogleIconDownload).Result)
            {
                using HttpContent content = response.Content;
                Stream stream = content.ReadAsStreamAsync().Result;
                using var fileStream = File.Create(pathIconPng);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }

            string pathIcon = Path.Combine(pathToStoreIcons, $"{hostname}.ico");
            ImagingHelper.ConvertToIcon(pathIconPng, pathIcon, 32);
            File.Delete(pathIconPng);

            string title = url;

            title = title.Replace("/", " ").
                Replace("https", string.Empty).
                Replace("http", string.Empty);

            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalid)
            {
                title = title.Replace(c.ToString(), string.Empty);
            }

            title = Truncate(title, 128); // max 255
            static string Truncate(string value, int maxLength)
            {
                if (!string.IsNullOrEmpty(value) &&
                    value.Length > maxLength)
                {
                    value = value[..maxLength];
                }

                return value;
            }

            using StreamWriter writer = new(pathToStoreFile + "\\" + title.Trim() + ".url");
            writer.WriteLine("[InternetShortcut]");
            writer.WriteLine($"URL={url.TrimEnd('\0')}");
            writer.WriteLine("IconIndex=0");
            writer.WriteLine($"HotKey=0");
            writer.WriteLine($"IDList=");
            writer.WriteLine($"IconFile={pathIcon}");
            writer.Flush();
        }
    }
}
