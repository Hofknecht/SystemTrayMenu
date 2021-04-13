// <copyright file="AppContextMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    internal class AppContextMenu
    {
        public event EventHandlerEmpty ClickedOpenLog;

        public event EventHandlerEmpty ClickedRestart;

        public event EventHandlerEmpty ClickedExit;

        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                BackColor = SystemColors.Control,
            };

            ToolStripMenuItem settings = new ToolStripMenuItem()
            {
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                Text = Translator.GetText("Settings"),
            };
            settings.Click += Settings_Click;
            static void Settings_Click(object sender, EventArgs e)
            {
                SettingsForm settingsForm = new SettingsForm();
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    AppRestart.ByConfigChange();
                }
            }

            menu.Items.Add(settings);

            ToolStripSeparator seperator = new ToolStripSeparator
            {
                BackColor = SystemColors.Control,
            };
            menu.Items.Add(seperator);

            ToolStripMenuItem openLog = new ToolStripMenuItem
            {
                Text = Translator.GetText("Log File"),
            };
            openLog.Click += OpenLog_Click;
            void OpenLog_Click(object sender, EventArgs e)
            {
                ClickedOpenLog?.Invoke();
            }

            menu.Items.Add(openLog);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem helpFAQ = new ToolStripMenuItem
            {
                Text = Translator.GetText("HelpFAQ"),
            };
            helpFAQ.Click += HelpFAQ_Click;
            static void HelpFAQ_Click(object sender, EventArgs e)
            {
                Config.ShowHelpFAQ();
            }

            menu.Items.Add(helpFAQ);

            ToolStripMenuItem about = new ToolStripMenuItem
            {
                Text = Translator.GetText("About"),
            };
            about.Click += About_Click;
            static void About_Click(object sender, EventArgs e)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                    Assembly.GetEntryAssembly().Location);
                AboutBox ab = new AboutBox
                {
                    AppTitle = versionInfo.ProductName,
                    AppDescription = versionInfo.FileDescription,
                    AppVersion = $"Version {versionInfo.FileVersion}",
                    AppCopyright = versionInfo.LegalCopyright,
                    AppMoreInfo = versionInfo.LegalCopyright,
                };
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "Markus Hofknecht (mailto:Markus@Hofknecht.eu)" + Environment.NewLine;
                ab.AppMoreInfo += "Tanja Hofknecht (mailto:Tanja@Hofknecht.eu)" + Environment.NewLine;

                // Thanks for letting me being part of this project and that I am allowed to be listed here :-)
                ab.AppMoreInfo += "Peter Kirmeier (mai" + "lto:top" + "ete" + "rk@f" + "reen" + "et." + "de)" + Environment.NewLine;

                ab.AppMoreInfo += "Pascal Aloy (mailto:paloy@wanadoo.fr)" + Environment.NewLine; // #145

                ab.AppMoreInfo += "http://www.hofknecht.eu/systemtraymenu/" + Environment.NewLine;
                ab.AppMoreInfo += "https://github.com/Hofknecht/SystemTrayMenu" + Environment.NewLine;
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "GNU GENERAL PUBLIC LICENSE" + Environment.NewLine;
                ab.AppMoreInfo += "(Version 3, 29 June 2007)" + Environment.NewLine;
                ab.AppDetailsButton = true;
                ab.ShowDialog();
            }

            menu.Items.Add(about);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem restart = new ToolStripMenuItem
            {
                Text = Translator.GetText("Restart"),
            };
            restart.Click += Restart_Click;
            void Restart_Click(object sender, EventArgs e)
            {
                ClickedRestart?.Invoke();
            }

            menu.Items.Add(restart);

            ToolStripMenuItem exit = new ToolStripMenuItem
            {
                Text = Translator.GetText("Exit"),
            };
            exit.Click += Exit_Click;
            void Exit_Click(object sender, EventArgs e)
            {
                ClickedExit?.Invoke();
            }

            menu.Items.Add(exit);

            return menu;
        }
    }
}