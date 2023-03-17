// <copyright file="GitHubUpdate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper.Updater
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net.Http;
    using System.Reflection;
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    public class GitHubUpdate
    {
        private static List<Dictionary<string, object>> releases;
        private static Form newVersionForm;

        public static void ActivateNewVersionFormOrCheckForUpdates(bool showWhenUpToDate)
        {
            if (newVersionForm != null)
            {
                newVersionForm.HandleInvoke(newVersionForm.Activate);
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
            client.DefaultRequestHeaders.Add("User-Agent", "SystemTrayMenu/" + Application.ProductVersion.ToString());

            // https://developer.github.com/v3/media/#request-specific-version
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3.text+json");

            try
            {
                using HttpResponseMessage response = client.GetAsync(urlGithubReleases).Result;
                using HttpContent content = response.Content;
                string responseString = content.ReadAsStringAsync().Result;
                releases = responseString.FromJson<List<Dictionary<string, object>>>();
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

            newVersionForm?.Dispose();
            newVersionForm = null;
        }

        private static void RemoveCurrentAndOlderVersions()
        {
            int releasesCount = releases.Count;
            Version versionCurrent = Assembly.GetExecutingAssembly().GetName().Version;
            for (int i = 0; i < releasesCount; i++)
            {
                string tagName = releases[i]["tag_name"].ToString();
                Version versionGitHub = new(tagName.Replace("v", string.Empty));
                if (versionGitHub.CompareTo(versionCurrent) < 1)
                {
                    releases.RemoveRange(i, releasesCount - i);
                    break;
                }
            }
        }

        private static void ShowNewVersionOrUpToDateDialog(bool showWhenUpToDate)
        {
            if (releases.Count > 0)
            {
                if (NewVersionDialog() == DialogResult.Yes)
                {
                    Log.ProcessStart("https://github.com/Hofknecht/SystemTrayMenu/releases");
                }
            }
            else if (showWhenUpToDate)
            {
                MessageBox.Show(Translator.GetText("You have the latest version of SystemTrayMenu!"));
            }
        }

        /// <summary>
        /// Creates a window to show changelog of new available versions.
        /// </summary>
        /// <param name="LatestVersionTitle">Name of latest release.</param>
        /// <param name="Changelog">Pathnotes.</param>
        /// <returns>OK = OK, Yes = Website, else = Cancel.</returns>
        private static DialogResult NewVersionDialog()
        {
            const int ClientPad = 15;
            newVersionForm = new()
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Icon = Config.GetAppIcon(),
                ShowInTaskbar = false,
            };
            newVersionForm.FormBorderStyle = FormBorderStyle.Sizable;
            newVersionForm.MaximizeBox = true;
            newVersionForm.MinimizeBox = false;
            newVersionForm.ClientSize = new Size(600, 400);
            newVersionForm.MinimumSize = newVersionForm.ClientSize;
            newVersionForm.Text = Translator.GetText("New version available!");

            Label label = new()
            {
                Size = new Size(newVersionForm.ClientSize.Width - ClientPad, 20),
                Location = new Point(ClientPad, ClientPad),
                Text = $"{Translator.GetText("Latest available version:")}    {GetLatestVersionName()}",
            };
            newVersionForm.Controls.Add(label);

            Button buttonOK = new()
            {
                DialogResult = DialogResult.OK,
                Name = "buttonOK",
            };
            buttonOK.Location = new Point(
                newVersionForm.ClientSize.Width - buttonOK.Size.Width - ClientPad,
                newVersionForm.ClientSize.Height - buttonOK.Size.Height - ClientPad);
            buttonOK.MinimumSize = new Size(75, 23);
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Text = Translator.GetText("OK");
            buttonOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOK.AutoSize = true;
            newVersionForm.Controls.Add(buttonOK);

            Button buttonGoToDownloadPage = new()
            {
                DialogResult = DialogResult.Yes,
                Name = "buttonGoToDownloadPage",
            };
            buttonGoToDownloadPage.Location = new Point(
                newVersionForm.ClientSize.Width - buttonGoToDownloadPage.Size.Width - ClientPad - buttonOK.Size.Width - ClientPad,
                newVersionForm.ClientSize.Height - buttonGoToDownloadPage.Size.Height - ClientPad);
            buttonGoToDownloadPage.MinimumSize = new Size(75, 23);
            buttonGoToDownloadPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonGoToDownloadPage.Text = Translator.GetText("Go to download page");
            buttonGoToDownloadPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonGoToDownloadPage.AutoSize = true;
            newVersionForm.Controls.Add(buttonGoToDownloadPage);

            TextBox textBox = new()
            {
                Location = new Point(ClientPad, label.Location.Y + label.Size.Height + 5),
            };
            textBox.Size = new Size(
                newVersionForm.ClientSize.Width - (ClientPad * 2),
                buttonOK.Location.Y - ClientPad - textBox.Location.Y);
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox.Multiline = true;
            textBox.Text = GetChangelog();
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            textBox.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            newVersionForm.Controls.Add(textBox);

            newVersionForm.AcceptButton = buttonOK;
            return newVersionForm.ShowDialog();
        }

        /// <summary>
        /// Returns the latest release version name.
        /// </summary>
        /// <returns>Version name.</returns>
        private static string GetLatestVersionName()
        {
            string result = "Unknown";

            if (releases == null)
            {
                return result;
            }

            try
            {
                result = releases[0]["tag_name"].ToString().Replace("v", string.Empty);
            }
            catch (Exception ex)
            {
                Log.Warn($"{nameof(GetLatestVersionName)} failed", ex);
            }

            return result;
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

                    result += release["name"].ToString()
                        + Environment.NewLine
                        + release["body_text"].ToString()
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