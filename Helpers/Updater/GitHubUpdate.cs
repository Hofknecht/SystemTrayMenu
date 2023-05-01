// <copyright file="GitHubUpdate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers.Updater
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using System.Windows;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    public class GitHubUpdate
    {
        private static List<Dictionary<string, object>>? releases;
        private static UpdateWindow? newVersionWindow;

        /// <summary>
        /// Gets the latest release version name .
        /// </summary>
        public static string LatestVersionName
        {
            get
            {
                string result = "Unknown";

                if (releases == null)
                {
                    return result;
                }

                try
                {
                    result = releases[0]["tag_name"].ToString()!.Replace("v", string.Empty); // 0 = latest
                }
                catch (Exception ex)
                {
                    Log.Warn($"{nameof(LatestVersionName)} failed", ex);
                }

                return result;
            }
        }

        /// <summary>
        /// Opens the website on GitHub of the latest release version .
        /// </summary>
        public static void WebOpenLatestRelease() => Log.ProcessStart("https://github.com/Hofknecht/SystemTrayMenu/releases");

        public static void ActivateNewVersionFormOrCheckForUpdates(bool showWhenUpToDate)
        {
            if (newVersionWindow != null)
            {
                newVersionWindow!.HandleInvoke(() => newVersionWindow?.Activate());
            }
            else
            {
                CheckForUpdates(showWhenUpToDate);
            }
        }

        private static void CheckForUpdates(bool showWhenUpToDate)
        {
            string urlGithubReleases = @"http://api.github.com/repos/Hofknecht/SystemTrayMenu/releases";
            HttpClient client = new();

            // https://developer.github.com/v3/#user-agent-required
            client.DefaultRequestHeaders.Add("User-Agent", "SystemTrayMenu/" + Assembly.GetExecutingAssembly().GetName().Version!.ToString());

            // https://developer.github.com/v3/media/#request-specific-version
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3.text+json");

            try
            {
                string response = client.GetStringAsync(urlGithubReleases).Result;
                releases = response.FromJson<List<Dictionary<string, object>>>();
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(CheckForUpdates)} failed", ex);
            }

            if (releases == null)
            {
                Log.Info($"{nameof(CheckForUpdates)} failed.");
            }
            else
            {
                RemoveCurrentAndOlderVersions();
                ShowNewVersionOrUpToDateDialog(showWhenUpToDate);
            }
        }

        private static void RemoveCurrentAndOlderVersions()
        {
            if (releases != null)
            {
                int releasesCount = releases.Count;
                Version versionCurrent = Assembly.GetExecutingAssembly().GetName().Version!;
                for (int i = 0; i < releasesCount; i++)
                {
                    string? tagName = releases[i]["tag_name"].ToString();
                    if (tagName == null)
                    {
                        continue;
                    }

                    Version versionGitHub = new(tagName.Replace("v", string.Empty));
                    if (versionGitHub.CompareTo(versionCurrent) < 1)
                    {
                        releases.RemoveRange(i, releasesCount - i);
                        break;
                    }
                }
            }
        }

        private static void ShowNewVersionOrUpToDateDialog(bool showWhenUpToDate)
        {
            if (releases != null)
            {
                if (releases.Count > 0)
                {
                    newVersionWindow = new();
                    newVersionWindow.textBox.Text = GetChangelog();
                    newVersionWindow.Closed += (_, _) => newVersionWindow = null;
                    newVersionWindow.ShowDialog();
                }
                else if (showWhenUpToDate)
                {
                    MessageBox.Show(Translator.GetText("You have the latest version of SystemTrayMenu!"));
                }
            }
        }

        /// <summary>
        /// Returns the change log from current version up to the latest release version.
        /// </summary>
        /// <returns>Change log summary or error text.</returns>
        private static string GetChangelog()
        {
            string result = string.Empty;
            string errorstr = "An error occurred during update check!" + Environment.NewLine;

            if (releases == null)
            {
                return errorstr + "Could not receive changelog!";
            }

            try
            {
                for (int i = 0; i < releases.Count; i++)
                {
                    Dictionary<string, object> release = releases[i];
                    string? bodyText = release["body_text"].ToString();
                    if (bodyText == null)
                    {
                        continue;
                    }

                    result += release["name"].ToString()
                        + Environment.NewLine
                        + bodyText
                        .Replace("\n\n", Environment.NewLine)
                        .Replace("\n \n", Environment.NewLine)
                        + Environment.NewLine + Environment.NewLine;
                    if (i < releases.Count)
                    {
                        result += "--------------------------------------------------" +
                            "-------------------------------------------------------"
                            + Environment.NewLine;
                    }
                }

                result = result.Replace("\n", Environment.NewLine);
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(GetChangelog)}", ex);
                result = errorstr + ex.Message.ToString();
            }

            return result;
        }
    }
}
