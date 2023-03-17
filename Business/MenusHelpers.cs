// <copyright file="MenusHelpers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;

    internal static class MenusHelpers
    {
        internal static void GetItemsForMainMenu(BackgroundWorker worker, string path, ref MenuData menuData)
        {
            menuData.IsNetworkRoot = FileLnk.IsNetworkRoot(path);
            if (menuData.IsNetworkRoot)
            {
                GetNetworkRootDirectories(path, ref menuData);
            }
            else
            {
                GetDirectories(worker, path, ref menuData);
                GetFiles(worker, path, ref menuData);
            }
        }

        internal static void GetAddionalItemsForMainMenu(ref MenuData menuData)
        {
            if (menuData.Level != 0)
            {
                return;
            }

            foreach (var path in GetAddionalPathsForMainMenu())
            {
                GetDirectoriesAndFilesRecursive(ref menuData, path.Path, path.OnlyFiles, path.Recursive);
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

        internal static void ReadHiddenAndReadIcons(BackgroundWorker worker, ref MenuData menuData)
        {
            List<RowData> rowDatasToRemove = new();
            foreach (RowData rowData in menuData.RowDatas)
            {
                if (worker?.CancellationPending == true)
                {
                    return;
                }

                if (!menuData.IsNetworkRoot && FolderOptions.IsHidden(rowData))
                {
                    rowDatasToRemove.Add(rowData);
                    continue;
                }

                rowData.ReadIcon(true);
            }

            menuData.RowDatas = menuData.RowDatas.Except(rowDatasToRemove).ToList();
        }

        internal static void CheckIfValid(ref MenuData menuData)
        {
            if (menuData.Validity == MenuDataValidity.Undefined)
            {
                if (menuData.RowDatas.Count == 0)
                {
                    menuData.Validity = MenuDataValidity.Empty;
                }
                else
                {
                    menuData.Validity = MenuDataValidity.Valid;
                }
            }
        }

        internal static void SortItemsWhenValid(ref MenuData menuData)
        {
            if (menuData.Validity != MenuDataValidity.Valid)
            {
                return;
            }

            menuData.RowDatas = SortItems(menuData.RowDatas);
        }

        internal static List<RowData> SortItems(List<RowData> rowDatas)
        {
            if (Properties.Settings.Default.SortByTypeAndNameWindowsExplorerSort)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.IsFolder)
                    .ThenBy(x => x.Text, new WindowsExplorerSort()).ToList();
            }
            else if (Properties.Settings.Default.SortByTypeAndDate)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.IsFolder)
                    .ThenByDescending(x => x.FileInfo.LastWriteTime).ToList();
            }
            else if (Properties.Settings.Default.SortByFileExtensionAndName)
            {
                rowDatas = rowDatas.OrderBy(x => x.FileExtension).ThenBy(x => x.Text).ToList();
            }
            else if (Properties.Settings.Default.SortByName)
            {
                rowDatas = rowDatas.OrderBy(x => x.Text).ToList();
            }
            else if (Properties.Settings.Default.SortByDate)
            {
                rowDatas = rowDatas.OrderByDescending(x => x.FileInfo.LastWriteTime).ToList();
            }

            return rowDatas;
        }

        private static void GetNetworkRootDirectories(string path, ref MenuData menuData)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                bool resolvedSomething = false;
                cmd.Start();
                cmd.StandardInput.WriteLine($"net view {path}");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                string output = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();
                cmd.Close();
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
                            menuData.RowDatas.Add(new RowData(true, false, true, menuData.Level, directory));
                            resolvedSomething = true;
                        }
                    }
                }

                if (!resolvedSomething)
                {
                    Log.Info($"Could not resolve network root folder: {path} , output:{output}");
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{path}'", ex);
                if (ex is UnauthorizedAccessException)
                {
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
            }
        }

        private static void GetDirectories(BackgroundWorker worker, string path, ref MenuData menuData)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    if (worker?.CancellationPending == true)
                    {
                        return;
                    }

                    menuData.RowDatas.Add(new RowData(true, false, false, menuData.Level, directory));
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{path}'", ex);
                if (ex is UnauthorizedAccessException)
                {
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
            }
        }

        private static void GetFiles(BackgroundWorker worker, string path, ref MenuData menuData)
        {
            try
            {
                foreach (string file in DirectoryBySearchPattern.GetFiles(path, Config.SearchPattern))
                {
                    if (worker?.CancellationPending == true)
                    {
                        return;
                    }

                    menuData.RowDatas.Add(new RowData(false, false, false, menuData.Level, file));
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{path}'", ex);
                if (ex is UnauthorizedAccessException)
                {
                    menuData.Validity = MenuDataValidity.NoAccess;
                }
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
                foreach (string file in DirectoryBySearchPattern.GetFiles(path, Config.SearchPattern))
                {
                    menuData.RowDatas.Add(new RowData(false, true, false, menuData.Level, file));
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    if (!onlyFiles)
                    {
                        menuData.RowDatas.Add(new RowData(true, true, false, menuData.Level, directory));
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
    }
}