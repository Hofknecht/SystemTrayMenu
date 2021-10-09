// <copyright file="FileUrl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using Microsoft.Win32;

    public static class FileUrl
    {
        private static string browserPath = string.Empty;

        public static bool GetDefaultBrowserPath(out string browserPath)
        {
            bool valid = true;
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            string browserPathKey = @"$BROWSER$\shell\open\command";

            RegistryKey userChoiceKey;
            browserPath = FileUrl.browserPath;

            if (string.IsNullOrEmpty(browserPath))
            {
                // Read default browser path from userChoiceLKey
                userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

                // If user choice was not found, try machine default
                if (userChoiceKey == null)
                {
                    // Read default browser path from Win XP registry key
                    RegistryKey browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                    // If browser path wasn’t found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey =
                        Registry.CurrentUser.OpenSubKey(
                        urlAssociation, false);
                    }

                    if (browserKey != null)
                    {
                        string path = CleanifyBrowserPath(browserKey.GetValue(null) as string);
                        browserKey.Close();
                        browserPath = path;
                    }
                }
                else
                {
                    // user defined browser choice was found
                    string progId = userChoiceKey.GetValue("ProgId").ToString();
                    userChoiceKey.Close();

                    // now look up the path of the executable
                    string concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId, System.StringComparison.InvariantCulture);
                    RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false);
                    if (registryKey != null)
                    {
                        browserPath = CleanifyBrowserPath(registryKey.GetValue(null) as string);
                        registryKey.Close();
                    }
                }

                FileUrl.browserPath = browserPath;
            }

            if (string.IsNullOrEmpty(browserPath))
            {
                valid = false;
                Log.Info($"No default browser found!");
            }

            return valid;
        }

        private static string CleanifyBrowserPath(string p)
        {
            string[] url = p.Split('"');
            string clean = url[1];
            return clean;
        }
    }
}
