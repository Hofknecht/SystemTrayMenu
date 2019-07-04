using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SystemTrayMenu.Helper
{
    public class FileIni
    {
        Dictionary<string, string> values;
        public FileIni(string path)
        {
            values = File.ReadLines(path)
            .Where(line => (!String.IsNullOrWhiteSpace(line) && !line.StartsWith("#")))
            .Select(line => line.Split(new char[] { '=' }, 2, 0))
            .ToDictionary(parts => parts[0].Trim(), parts => parts.Length > 1 ? parts[1].Trim() : null);
        }
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
