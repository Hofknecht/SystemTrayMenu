// <copyright file="FileIni.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Read *.ini files.
    /// </summary>
    public class FileIni
    {
        private readonly Dictionary<string, string> values;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileIni"/> class.
        /// </summary>
        /// <param name="path">path of *.ini file.</param>
        public FileIni(string path)
        {
            values = File.ReadLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line) &&
            !line.StartsWith("#", System.StringComparison.InvariantCulture))
            .Select(line => line.Split(new char[] { '=' }, 2, 0))
            .ToDictionary(parts => parts[0].Trim(), parts =>
            parts.Length > 1 ? parts[1].Trim() : null);
        }

        /// <summary>
        /// Get value of line in *.ini file.
        /// </summary>
        /// <param name="name">attribute name of line.</param>
        /// <param name="value">default value.</param>
        /// <returns>value of attribute name of line.</returns>
        public string Value(string name, string value = null)
        {
            if (values != null && values.ContainsKey(name))
            {
                return values[name];
            }

            return value;
        }
    }
}
