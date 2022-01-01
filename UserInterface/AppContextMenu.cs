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

        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new()
            {
                BackColor = SystemColors.Control,
            };

            ToolStripMenuItem settings = new()
            {
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                Text = Translator.GetText("Settings"),
            };

            settings.Click += (sender, e) => SettingsForm.ShowSingleInstance();

            menu.Items.Add(settings);

            ToolStripSeparator seperator = new()
            {
                BackColor = SystemColors.Control,
            };
            menu.Items.Add(seperator);

            ToolStripMenuItem openLog = new()
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

            ToolStripMenuItem helpFAQ = new()
            {
                Text = Translator.GetText("HelpFAQ"),
            };
            helpFAQ.Click += HelpFAQ_Click;
            static void HelpFAQ_Click(object sender, EventArgs e)
            {
                Config.ShowHelpFAQ();
            }

            menu.Items.Add(helpFAQ);

            ToolStripMenuItem about = new()
            {
                Text = Translator.GetText("About"),
            };
            about.Click += About_Click;
            static void About_Click(object sender, EventArgs e)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                    Assembly.GetEntryAssembly().Location);
                AboutBox ab = new()
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

                ab.AppMoreInfo += "http://www.hofknecht.eu/systemtraymenu/" + Environment.NewLine;
                ab.AppMoreInfo += "https://github.com/Hofknecht/SystemTrayMenu" + Environment.NewLine;
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "GNU GENERAL PUBLIC LICENSE" + Environment.NewLine;
                ab.AppMoreInfo += "(Version 3, 29 June 2007)" + Environment.NewLine;

                ab.AppMoreInfo += "Thanks for ideas, reporting issues and contributing!" + Environment.NewLine;
                ab.AppMoreInfo += "#123 Mordecai00, #125 Holgermh, #135 #153 #154 #164 jakkaas, #145 Pascal Aloy, #153 #158 #160 blackcrack,";
                ab.AppMoreInfo += "#162 HansieNL, #163 igorruckert, #171 kehoen, #186 Dtrieb, #188 #189 #191 #195 iJahangard, #195 #197 #238 the-phuctran, ";
                ab.AppMoreInfo += "#205 kristofzerbe, #209 jonaskohl, #211 blacksparrow15, #220 Yavuz E., #229 #230 #239 Peter O., #231 Ryonez, ";
                ab.AppMoreInfo += "#235 #242 243 #247, #271 Tom, #237 Torsten S., #240 video Patrick, #244 Gunter D., #246 MACE4GITHUB, #259 vanjac, ";
                ab.AppMoreInfo += "#262 terencemcdonnell, #269 petersnows25, #272 Peter M., #273 #274 ParasiteDelta, #275 #276 #278 donaldaken, ";
                ab.AppMoreInfo += "#277 Jan S., #282 akuznets," + Environment.NewLine;
                ab.AppDetailsButton = true;
                ab.ShowDialog();
            }

            menu.Items.Add(about);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem restart = new()
            {
                Text = Translator.GetText("Restart"),
            };
            restart.Click += Restart_Click;
            void Restart_Click(object sender, EventArgs e)
            {
                AppRestart.ByAppContextMenu();
            }

            menu.Items.Add(restart);

            ToolStripMenuItem exit = new()
            {
                Text = Translator.GetText("Exit"),
            };
            exit.Click += Exit_Click;
            void Exit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            menu.Items.Add(exit);

            return menu;
        }
    }
}