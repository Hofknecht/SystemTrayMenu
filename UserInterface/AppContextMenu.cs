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
    using SystemTrayMenu.Helper.Updater;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    internal class AppContextMenu
    {
        public event Action ClickedOpenLog;

        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new()
            {
                BackColor = SystemColors.Control,
            };

            AddItem(menu, "Settings", () => SettingsForm.ShowSingleInstance());
            AddSeperator(menu);
            AddItem(menu, "Log File", () => ClickedOpenLog?.Invoke());
            AddSeperator(menu);
            AddItem(menu, "Frequently Asked Questions", Config.ShowHelpFAQ);
            AddItem(menu, "Support SystemTrayMenu", Config.ShowSupportSystemTrayMenu);
            AddItem(menu, "About SystemTrayMenu", About);
            AddItem(menu, "Check for updates", () => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(showWhenUpToDate: true));
            AddSeperator(menu);
            AddItem(menu, "Restart", AppRestart.ByAppContextMenu);
            AddItem(menu, "Exit app", Application.Exit);

            return menu;
        }

        private static void AddSeperator(ContextMenuStrip menu)
        {
            menu.Items.Add(new ToolStripSeparator());
        }

        private static void AddItem(
                ContextMenuStrip menu,
                string text,
                Action actionClick)
        {
            ToolStripMenuItem toolStripMenuItem = new()
            {
                Text = Translator.GetText(text),
            };

            toolStripMenuItem.Click += (sender, e) => actionClick();
            menu.Items.Add(toolStripMenuItem);
        }

        private static void About()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                Assembly.GetEntryAssembly().Location);
            AboutBox aboutBox = new()
            {
                AppTitle = versionInfo.ProductName,
                AppDescription = versionInfo.FileDescription,
                AppVersion = $"Version {versionInfo.FileVersion}",
                AppCopyright = versionInfo.LegalCopyright,
                AppMoreInfo = versionInfo.LegalCopyright,
            };
            aboutBox.AppMoreInfo += Environment.NewLine;
            aboutBox.AppMoreInfo += "Markus Hofknecht (mailto:Markus@Hofknecht.eu)" + Environment.NewLine;

            // Thanks for letting me being part of this project and that I am allowed to be listed here :-)
            aboutBox.AppMoreInfo += "Peter Kirmeier (mai" + "lto:top" + "ete" + "rk@f" + "reen" + "et." + "de)" + Environment.NewLine;

            aboutBox.AppMoreInfo += "http://www.hofknecht.eu/systemtraymenu/" + Environment.NewLine;
            aboutBox.AppMoreInfo += "https://github.com/Hofknecht/SystemTrayMenu" + Environment.NewLine;
            aboutBox.AppMoreInfo += Environment.NewLine;
            aboutBox.AppMoreInfo += "GNU GENERAL PUBLIC LICENSE" + Environment.NewLine;
            aboutBox.AppMoreInfo += "(Version 3, 29 June 2007)" + Environment.NewLine;

            aboutBox.AppMoreInfo += "Thanks for ideas, reporting issues and contributing!" + Environment.NewLine;
            aboutBox.AppMoreInfo +=
                "#123 Mordecai00, " +
                "#125 Holgermh, " +
                "#135 #153 #154 #164 jakkaas, " +
                "#145 Pascal Aloy, " +
                "#153 #158 #160 blackcrack, " +
                "#162 HansieNL, " +
                "#163 igorruckert, " +
                "#171 kehoen, " +
                "#186 Dtrieb, " +
                "#188 #189 #191 #195 iJahangard, " +
                "#195 #197 #225 #238 the-phuctran, " +
                "#205 kristofzerbe, " +
                "#209 jonaskohl, " +
                "#211 blacksparrow15, " +
                "#220 #403 Yavuz E., " +
                "#229 #230 #239 Peter O., " +
                "#231 Ryonez, " +
                "#235 #242 243 #247, #271 Tom, " +
                "#237 Torsten S., " +
                "#240 video Patrick, " +
                "#244 Gunter D., " +
                "#246 #329 MACE4GITHUB, " +
                "#259 #310 vanjac, " +
                "#262 terencemcdonnell, " +
                "#269 petersnows25, " +
                "#272 Peter M., " +
                "#273 #274 ParasiteDelta, " +
                "#275 #276 #278 donaldaken, " +
                "#277 Jan S., " +
                "#282 akuznets, " +
                "#283 #284 #289 RuSieg, " +
                "#285 #286 dao-net, " +
                "#288 William P., " +
                "#294 #295 #296 Stefan Mahrer, " +
                "#225 #297 #299 #317 #321 #324 #330 #386 #390 #401 #402 #407 #409 #414 #416 #418 #428 #430 #443 chip33, " +
                "#298 phanirithvij, " +
                "#306 wini2, " +
                "#370 dna5589, " +
                "#372 not-nef, " +
                "#376 Michelle H., " +
                "#377 SoenkeHob, " +
                "#380 #394 TransLucida, " +
                "#384 #434 #435 boydfields, " +
                "#386 visusys, " +
                "#387 #411 #444 yrctw, " +
                "#446 timinformatica, " +
                "#450 ppt-oldoerp, " +
                "#453 fubaWoW, " +
                "#454 WouterVanGoey, " +
                "#462 verdammt89x, " +
                "#463 Dirk S., " +
                "#466 Dean-Corso, " +
                "#488 DailenG, " +
                "#490 TrampiPW, " +
                "#497 Aziz, " +
                "#499 spitzlbergerj, " +
                Environment.NewLine +
                Environment.NewLine;
            aboutBox.AppMoreInfo += "Sponsors - Thank you!" + Environment.NewLine;
            aboutBox.AppMoreInfo +=
                "Stefan Mahrer, " +
                "boydfields, " +
                "RuSieg, " +
                "igor-davidov, " +
                "Ralf K., " +
                "Tim K., " +
                "Georg W., " +
                "donaldaken, " +
                "Marc Speer, " +
                "Cito, " +
                "Peter G., " +
                "Traditional_Tap3954, " +
                "Maximilian H., " +
                "Jens B., " +
                "spitzlbergerj, " +
                Environment.NewLine;
            aboutBox.AppDetailsButton = true;
            aboutBox.ShowDialog();
        }
    }
}