// <copyright file="AppContextMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using SystemTrayMenu.Helper.Updater;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;
    using SystemColors = System.Windows.SystemColors;

    internal class AppContextMenu
    {
        public event Action ClickedOpenLog;

        public ContextMenu Create()
        {
            ContextMenu menu = new()
            {
                Background = SystemColors.ControlBrush,
            };

            AddItem(menu, "Settings", () => SettingsWindow.ShowSingleInstance());
            AddSeperator(menu);
            AddItem(menu, "Log File", () => ClickedOpenLog?.Invoke());
            AddSeperator(menu);
            AddItem(menu, "Frequently Asked Questions", Config.ShowHelpFAQ);
            AddItem(menu, "Support SystemTrayMenu", Config.ShowSupportSystemTrayMenu);
            AddItem(menu, "About SystemTrayMenu", About);
#if TODO // GITHUBUPDATE
            AddItem(menu, "Check for updates", () => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(showWhenUpToDate: true));
#endif
            AddSeperator(menu);
            AddItem(menu, "Restart", AppRestart.ByAppContextMenu);
            AddItem(menu, "Exit app", () => Application.Current.Shutdown());

            return menu;
        }

        private static void AddSeperator(ContextMenu menu)
        {
            menu.Items.Add(new Separator());
        }

        private static void AddItem(
                ContextMenu menu,
                string text,
                Action actionClick)
        {
            menu.Items.Add(new MenuItem()
                {
                    Header = text,
                    Command = new ActionCommand((_) => actionClick()),
                });
        }

        private static void About()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                Assembly.GetEntryAssembly().Location);

            string moreInfo = versionInfo.LegalCopyright + Environment.NewLine;
            moreInfo += "Markus Hofknecht (mailto:Markus@Hofknecht.eu)" + Environment.NewLine;

            // Thanks for letting me being part of this project and that I am allowed to be listed here :-)
            moreInfo += "Peter Kirmeier (https://github.com/topeterk/)" + Environment.NewLine;

            moreInfo += "http://www.hofknecht.eu/systemtraymenu/" + Environment.NewLine;
            moreInfo += "https://github.com/Hofknecht/SystemTrayMenu" + Environment.NewLine;
            moreInfo += Environment.NewLine;
            moreInfo += "GNU GENERAL PUBLIC LICENSE" + Environment.NewLine;
            moreInfo += "(Version 3, 29 June 2007)" + Environment.NewLine;

            moreInfo += "Thanks for ideas, reporting issues and contributing!" + Environment.NewLine;
            moreInfo += "#123 Mordecai00, #125 Holgermh, #135 #153 #154 #164 jakkaas, #145 Pascal Aloy, #153 #158 #160 blackcrack,";
            moreInfo += "#162 HansieNL, #163 igorruckert, #171 kehoen, #186 Dtrieb, #188 #189 #191 #195 iJahangard, #195 #197 #225 #238 the-phuctran, ";
            moreInfo += "#205 kristofzerbe, #209 jonaskohl, #211 blacksparrow15, #220 #403 Yavuz E., #229 #230 #239 Peter O., #231 Ryonez, ";
            moreInfo += "#235 #242 243 #247, #271 Tom, #237 Torsten S., #240 video Patrick, #244 Gunter D., #246 #329 MACE4GITHUB, #259 #310 vanjac, ";
            moreInfo += "#262 terencemcdonnell, #269 petersnows25, #272 Peter M., #273 #274 ParasiteDelta, #275 #276 #278 donaldaken, ";
            moreInfo += "#277 Jan S., #282 akuznets, #283 #284 #289 RuSieg, #285 #286 dao-net, #288 William P., #294 #295 #296 Stefan Mahrer, ";
            moreInfo += "#225 #297 #299 #317 #321 #324 #330 #386 #390 #401 #402 #407 #409 #414 #416 #418 #428 #430 #443 chip33, ";
            moreInfo += "#298 phanirithvij, #306 wini2, #370 dna5589, #372 not-nef, #376 Michelle H., ";
            moreInfo += "#377 SoenkeHob, #380 #394 TransLucida, #384 #434 #435 boydfields, #386 visusys, #387 #411 #444 yrctw" + Environment.NewLine;
            moreInfo += "#446 timinformatica, #450 ppt-oldoerp, #453 fubaWoW, #454 WouterVanGoey" + Environment.NewLine;
            moreInfo += "#462 verdammt89x, #463 Dirk S." + Environment.NewLine;
            moreInfo += @"
Sponsors - Thank you!
------------------
* Stefan Mahrer
* boydfields
* RuSieg
* Ralf K.
* donaldaken
* Marc Speer
* Peter G.
* Traditional_Tap3954
* Maximilian H.
";
            AboutBox aboutBox = new()
            {
                AppTitle = versionInfo.ProductName,
                AppDescription = versionInfo.FileDescription,
                AppVersion = $"Version {versionInfo.FileVersion}",
                AppCopyright = versionInfo.LegalCopyright,
                AppMoreInfo = moreInfo,
            };
            aboutBox.ShowDialog();
        }
    }
}