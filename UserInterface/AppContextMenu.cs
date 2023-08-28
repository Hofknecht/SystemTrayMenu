// <copyright file="AppContextMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Threading;
    using H.NotifyIcon.Core;
    using SystemTrayMenu.Helpers.Updater;
    using SystemTrayMenu.Utilities;

    internal class AppContextMenu
    {
        public PopupMenu Create()
        {
            PopupMenu menu = new();

            AddItem(menu, "Settings", () => SettingsWindow.ShowSingleInstance());
            AddSeperator(menu);
            AddItem(menu, "Log File", Log.OpenLogFile);
            AddSeperator(menu);
            AddItem(menu, "Frequently Asked Questions", Config.ShowHelpFAQ);
            AddItem(menu, "Support SystemTrayMenu", Config.ShowSupportSystemTrayMenu);
            AddItem(menu, "About SystemTrayMenu", About);
            AddItem(menu, "Check for updates", () => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(showWhenUpToDate: true));
            AddSeperator(menu);
            AddItem(menu, "Restart", AppRestart.ByAppContextMenu);
            AddItem(menu, "Exit app", () => Application.Current.Shutdown());

            return menu;
        }

        private static void AddSeperator(PopupMenu menu)
        {
            menu.Items.Add(new PopupMenuSeparator());
        }

        private static void AddItem(
                PopupMenu menu,
                string text,
                Action actionClick)
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            menu.Items.Add(new PopupMenuItem(
                text, new ((_, _) => dispatcher.Invoke(actionClick))));
        }

        private static void About()
        {
            string copyright = string.Empty;
            string productName = string.Empty;
            string fileDescription = string.Empty;
            string fileVersion = string.Empty;
            string? location = Assembly.GetEntryAssembly()?.Location;
            if (location != null)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(location);
                if (versionInfo.LegalCopyright != null)
                {
                    copyright = versionInfo.LegalCopyright;
                }

                if (versionInfo.ProductName != null)
                {
                    productName = versionInfo.ProductName;
                }

                if (versionInfo.FileDescription != null)
                {
                    fileDescription = versionInfo.FileDescription;
                }

                if (versionInfo.FileVersion != null)
                {
                    fileVersion = versionInfo.FileVersion;
                }
            }

            string moreInfo = copyright + Environment.NewLine;
            moreInfo += "Markus Hofknecht (mailto:Markus@Hofknecht.eu)" + Environment.NewLine;

            // Thanks for letting me being part of this project and that I am allowed to be listed here :-)
            moreInfo += "Peter Kirmeier (https://github.com/topeterk/)" + Environment.NewLine;

            moreInfo += "http://www.hofknecht.eu/systemtraymenu/" + Environment.NewLine;
            moreInfo += "https://github.com/Hofknecht/SystemTrayMenu" + Environment.NewLine;
            moreInfo += Environment.NewLine;
            moreInfo += "GNU GENERAL PUBLIC LICENSE" + Environment.NewLine;
            moreInfo += "(Version 3, 29 June 2007)" + Environment.NewLine;

            moreInfo += "Thanks for ideas, reporting issues and contributing!" + Environment.NewLine;
            moreInfo +=
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
            moreInfo += "Sponsors - Thank you!" + Environment.NewLine;
            moreInfo +=
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
            AboutBox aboutBox = new()
            {
                AppTitle = productName,
                AppDescription = fileDescription,
                AppVersion = $"Version {fileVersion}",
                AppCopyright = copyright,
                AppMoreInfo = moreInfo,
            };
            aboutBox.ShowDialog();
        }
    }
}