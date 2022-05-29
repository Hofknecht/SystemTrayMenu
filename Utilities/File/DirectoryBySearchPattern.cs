// <copyright file="DirectoryBySearchPattern.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// see also: https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using.

namespace SystemTrayMenu.Utilities
{
    using System.Collections.Generic;

    public static class DirectoryBySearchPattern
    {
        public static string[] GetFiles(string path, string searchPatternCombined)
        {
            string[] searchPatterns = searchPatternCombined.Split('|');
            List<string> files = new();
            foreach (string searchPattern in searchPatterns)
            {
                files.AddRange(System.IO.Directory.GetFiles(path, searchPattern));
            }

            files.Sort();
            return files.ToArray();
        }
    }
}