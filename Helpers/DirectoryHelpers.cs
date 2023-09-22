// <copyright file="DirectoryHelpers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Utilities;

    internal static class DirectoryHelpers
    {
        internal static void DiscoverItems(BackgroundWorker? worker, string path, ref MenuData menuData)
        {
            bool isNetworkRoot = false;
            try
            {
                isNetworkRoot = FileLnk.IsNetworkRoot(path);
                if (isNetworkRoot)
                {
                    DiscoverNetworkRootDirectories(path, ref menuData);
                }
                else
                {
                    DiscoverLocalDirectories(worker, path, ref menuData);
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{path}'", ex);
                if (ex is UnauthorizedAccessException)
                {
                    menuData.DirectoryState = MenuDataDirectoryState.NoAccess;
                    return;
                }
            }

            if (worker?.CancellationPending == true)
            {
                return;
            }

            if (menuData.Level == 0)
            {
                foreach (var additionalPath in GetAddionalPathsForMainMenu())
                {
                    GetDirectoriesAndFilesRecursive(ref menuData, additionalPath.Path, additionalPath.OnlyFiles, additionalPath.Recursive);
                }
            }

            RemoveHiddenOrReadIcons(worker, isNetworkRoot, ref menuData);

            if (menuData.RowDatas.Count == 0)
            {
                menuData.DirectoryState = MenuDataDirectoryState.Empty;
            }
            else
            {
                if (worker?.CancellationPending == true)
                {
                    return;
                }

                menuData.RowDatas = SortItems(menuData.RowDatas);
                menuData.DirectoryState = MenuDataDirectoryState.Valid;
            }
        }

        internal static IEnumerable<(string Path, bool Recursive, bool OnlyFiles)> GetAddionalPathsForMainMenu()
        {
            foreach (string pathAndRecursivString in Properties.Settings.Default.PathsAddToMainMenu.Split(@"|"))
            {
                if (string.IsNullOrEmpty(pathAndRecursivString))
                {
                    continue;
                }

                string pathAddForMainMenu = pathAndRecursivString.Split("recursiv:")[0].Trim();
                bool recursive = pathAndRecursivString.Split("recursiv:")[1].StartsWith("True");
                bool onlyFiles = pathAndRecursivString.Split("onlyFiles:")[1].StartsWith("True");
                yield return (Path: pathAddForMainMenu, Recursive: recursive, OnlyFiles: onlyFiles);
            }
        }

        internal static List<RowData> SortItems(List<RowData> rowDatas)
        {
            if (Properties.Settings.Default.SortByTypeAndNameWindowsExplorerSort)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.IsFolder)
                    .ThenBy(x => x.ColumnText, new WindowsExplorerSort()).ToList();
            }
            else if (Properties.Settings.Default.SortByTypeAndDate)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.IsFolder)
                    .ThenByDescending(x => x.FileInfo.LastWriteTime).ToList();
            }
            else if (Properties.Settings.Default.SortByFileExtensionAndName)
            {
                rowDatas = rowDatas.OrderBy(x => x.FileExtension).ThenBy(x => x.ColumnText).ToList();
            }
            else if (Properties.Settings.Default.SortByName)
            {
                rowDatas = rowDatas.OrderBy(x => x.ColumnText).ToList();
            }
            else if (Properties.Settings.Default.SortByDate)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.FileInfo.LastWriteTime).ToList();
            }

            return rowDatas;
        }

        private static void RemoveHiddenOrReadIcons(BackgroundWorker? worker, bool isNetworkRoot, ref MenuData menuData)
        {
            List<RowData> rowDatasToRemove = new();
            foreach (RowData rowData in menuData.RowDatas)
            {
                if (worker?.CancellationPending == true)
                {
                    return;
                }

                if (!isNetworkRoot)
                {
                    FolderOptions.ReadHiddenAttributes(rowData.Path, out bool hasHiddenFlag, out bool isDirectoryToHide);
                    if (isDirectoryToHide)
                    {
                        rowDatasToRemove.Add(rowData);
                        continue;
                    }

                    rowData.HiddenEntry = hasHiddenFlag;
                }

                rowData.LoadIcon(menuData.Level == 0);
            }

            menuData.RowDatas = menuData.RowDatas.Except(rowDatasToRemove).ToList();
        }

        private static void DiscoverNetworkRootDirectories(string path, ref MenuData menuData)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            cmd.Start();
            cmd.StandardInput.WriteLine($"net view {path}");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            cmd.Close();

            bool resolvedSomething = false;
            List<string> lines = output
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (lines.Count > 8)
            {
                foreach (string line in lines.Skip(6).SkipLast(2))
                {
                    int indexOfFirstSpace = line.IndexOf("  ", StringComparison.InvariantCulture);
                    if (indexOfFirstSpace > 0)
                    {
                        string directory = Path.Combine(path, line[..indexOfFirstSpace]);
                        menuData.RowDatas.Add(new RowData(true, false, menuData.Level, directory));
                        resolvedSomething = true;
                    }
                }
            }

            if (!resolvedSomething)
            {
                Log.Info($"Could not resolve network root folder: {path} , output:{output}");
            }
        }

        private static void DiscoverLocalDirectories(BackgroundWorker? worker, string path, ref MenuData menuData)
        {
            if (!Directory.Exists(path))
            {
                // Happens most likely when a shortcut is pointing to an absent target path
                Log.Info($"path:'{path}' does not exist");
                return;
            }

            foreach (var directory in Directory.GetDirectories(path))
            {
                if (worker?.CancellationPending == true)
                {
                    return;
                }

                menuData.RowDatas.Add(new RowData(true, false, menuData.Level, directory));
            }

            foreach (string file in GetFilesBySearchPattern(path, Config.SearchPattern))
            {
                if (worker?.CancellationPending == true)
                {
                    return;
                }

                menuData.RowDatas.Add(new RowData(false, false, menuData.Level, file));
            }
        }

        private static void GetDirectoriesAndFilesRecursive(
            ref MenuData menuData,
            string path,
            bool onlyFiles,
            bool recursiv)
        {
            try
            {
                foreach (string file in GetFilesBySearchPattern(path, Config.SearchPattern))
                {
                    menuData.RowDatas.Add(new RowData(false, true, menuData.Level, file));
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    if (!onlyFiles)
                    {
                        menuData.RowDatas.Add(new RowData(true, true, menuData.Level, directory));
                    }

                    if (recursiv)
                    {
                        GetDirectoriesAndFilesRecursive(ref menuData, directory, onlyFiles, recursiv);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"GetDirectoriesAndFilesRecursive path:'{path}'", ex);
            }
        }

        private static List<string> GetFilesBySearchPattern(string path, string searchPatternCombined)
        {
            string[] searchPatterns = searchPatternCombined.Split('|');
            List<string> files = new();
            foreach (string searchPattern in searchPatterns)
            {
                files.AddRange(Directory.GetFiles(path, searchPattern));
            }

            return files;
        }
    }
}
