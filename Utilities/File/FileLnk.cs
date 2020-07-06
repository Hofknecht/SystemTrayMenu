namespace SystemTrayMenu.Utilities
{
    using Shell32;
    using System;
    using System.IO;
    using System.Threading;

    internal class FileLnk
    {
        public static string GetResolvedFileName(string shortcutFilename)
        {
            string resolvedFilename = string.Empty;
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                resolvedFilename = GetShortcutFileNamePath(shortcutFilename);
            }
            else
            {
                Thread staThread = new Thread(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object obj)
                {
                    resolvedFilename = GetShortcutFileNamePath(shortcutFilename);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(shortcutFilename);
                staThread.Join();
            }

            return resolvedFilename;
        }


        private static string GetShortcutFileNamePath(object shortcutFilename)
        {
            string resolvedFilename = string.Empty;
            string pathOnly = Path.GetDirectoryName((string)shortcutFilename);
            string filenameOnly = Path.GetFileName((string)shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                try
                {
                    ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                    if (string.IsNullOrEmpty(link.Path))
                    {
                        resolvedFilename = link.Target.Path;
                    }
                    else
                    {
                        resolvedFilename = link.Path;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Log.Warn($"shortcutFilename:'{shortcutFilename}'", ex);
                }
            }

            return resolvedFilename;
        }

        public static bool IsDirectory(string filePath)
        {
            bool isDirectory = false;
            if (Directory.Exists(filePath))
            {
                FileAttributes attributes = File.GetAttributes(filePath);
                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isDirectory = true;
                }
            }

            return isDirectory;
        }

        public static bool IsNetworkRoot(string path)
        {
            return !System.IO.File.Exists(path) &&
                path.StartsWith(@"\\", StringComparison.InvariantCulture) &&
                !path.Substring(2).Contains(@"\", StringComparison.InvariantCulture);
        }
    }
}