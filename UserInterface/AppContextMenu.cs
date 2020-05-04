using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SystemTrayMenu.UserInterface;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.Helper
{
    internal class AppContextMenu
    {
        public event EventHandlerEmpty ClickedOpenLog;
        public event EventHandlerEmpty ClickedRestart;
        public event EventHandlerEmpty ClickedExit;

        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly IList<int> _needNonShiftModifier = new List<int>();
        private readonly IList<int> _needNonAltGrModifier = new List<int>();

        /// <summary>
        /// Populates the ArrayLists specifying disallowed hotkeys
        /// such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign) etc
        /// </summary>
        private void PopulateModifierLists()
        {
            // Shift + 0 - 9, A - Z
            for (Keys k = Keys.D0; k <= Keys.Z; k++)
            {
                _needNonShiftModifier.Add((int)k);
            }

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++)
            {
                _needNonShiftModifier.Add((int)k);
            }

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++)
            {
                _needNonShiftModifier.Add((int)k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++)
            {
                _needNonShiftModifier.Add((int)k);
            }

            // Misc keys that we can't loop through
            _needNonShiftModifier.Add((int)Keys.Insert);
            _needNonShiftModifier.Add((int)Keys.Help);
            _needNonShiftModifier.Add((int)Keys.Multiply);
            _needNonShiftModifier.Add((int)Keys.Add);
            _needNonShiftModifier.Add((int)Keys.Subtract);
            _needNonShiftModifier.Add((int)Keys.Divide);
            _needNonShiftModifier.Add((int)Keys.Decimal);
            _needNonShiftModifier.Add((int)Keys.Return);
            _needNonShiftModifier.Add((int)Keys.Escape);
            _needNonShiftModifier.Add((int)Keys.NumLock);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++)
            {
                _needNonAltGrModifier.Add((int)k);
            }
        }
        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                BackColor = SystemColors.Control
            };

            ToolStripMenuItem settings = new ToolStripMenuItem()
            {
                ImageScaling = ToolStripItemImageScaling.SizeToFit,
                Text = Translator.GetText("Settings")
            };
            settings.Click += Settings_Click;
            void Settings_Click(object sender, EventArgs e)
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
                BackColor = SystemColors.Control
            };
            menu.Items.Add(seperator);

            ToolStripMenuItem openLog = new ToolStripMenuItem
            {
                Text = Translator.GetText("Log File")
            };
            openLog.Click += OpenLog_Click;
            void OpenLog_Click(object sender, EventArgs e)
            {
                ClickedOpenLog.Invoke();
            }
            menu.Items.Add(openLog);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem about = new ToolStripMenuItem
            {
                Text = Translator.GetText("About")
            };
            about.Click += About_Click;
            void About_Click(object sender, EventArgs e)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                    Assembly.GetEntryAssembly().Location);
                AboutBox ab = new AboutBox
                {
                    AppTitle = versionInfo.ProductName,
                    AppDescription = versionInfo.FileDescription,
                    AppVersion = $"Version {versionInfo.FileVersion}",
                    AppCopyright = versionInfo.LegalCopyright,
                    AppMoreInfo = versionInfo.LegalCopyright
                };
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "Markus Hofknecht (mailto:Markus@Hofknecht.eu)";
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "Tanja Kauth (mailto:Tanja@Hofknecht.eu)";
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "http://www.hofknecht.eu/systemtraymenu/";
                ab.AppMoreInfo += Environment.NewLine;
                ab.AppMoreInfo += "https://github.com/Hofknecht/SystemTrayMenu";
                ab.AppMoreInfo += Environment.NewLine;
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
                Text = Translator.GetText("Restart")
            };
            restart.Click += Restart_Click;
            void Restart_Click(object sender, EventArgs e)
            {
                ClickedRestart.Invoke();
            }
            menu.Items.Add(restart);

            ToolStripMenuItem exit = new ToolStripMenuItem
            {
                Text = Translator.GetText("Exit")
            };
            exit.Click += Exit_Click;
            void Exit_Click(object sender, EventArgs e)
            {
                ClickedExit.Invoke();
            }
            menu.Items.Add(exit);

            return menu;
        }

#warning verify if we need this
        private Keys GetModfiersForHotkey(Keys hotkey)
        {
            PopulateModifierLists();
            Keys _modifiers = Keys.None;

            string Text = string.Empty;
            bool bCalledProgramatically = false;

            // No hotkey set
            if (hotkey == Keys.None)
            {
                Text = "";
                return Keys.None;
            }

            // LWin/RWin doesn't work as hotkeys (neither do they work as modifier keys in .NET 2.0)
            if (hotkey == Keys.LWin || hotkey == Keys.RWin)
            {
                Text = "";
                return Keys.None;
            }

            // Only validate input if it comes from the user
            if (bCalledProgramatically == false)
            {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if ((_modifiers == Keys.Shift || _modifiers == Keys.None) && _needNonShiftModifier.Contains((int)hotkey))
                {
                    if (_modifiers == Keys.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (_needNonAltGrModifier.Contains((int)hotkey) == false)
                        {
                            _modifiers = Keys.Alt | Keys.Control;
                        }
                        else
                        {
                            // ... in that case, use Shift+Alt instead.
                            _modifiers = Keys.Alt | Keys.Shift;
                        }
                    }
                    else
                    {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        hotkey = Keys.None;
                        Text = "";
                        return Keys.None;
                    }
                }
                // Check all Ctrl+Alt keys
                if ((_modifiers == (Keys.Alt | Keys.Control)) && _needNonAltGrModifier.Contains((int)hotkey))
                {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    hotkey = Keys.None;
                    Text = "";
                    return Keys.None;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (hotkey == Keys.Menu /* Alt */ || hotkey == Keys.ShiftKey || hotkey == Keys.ControlKey)
            {
                hotkey = Keys.None;
            }

            return _modifiers;
            //Text = HotkeyToLocalizedString(_modifiers, _hotkey);
        }

        public static string HotkeyToLocalizedString(Keys modifierKeyCode, Keys virtualKeyCode)
        {
            return HotkeyModifiersToLocalizedString(modifierKeyCode) + GetKeyName(virtualKeyCode);
        }
        public static string HotkeyModifiersToLocalizedString(Keys modifierKeyCode)
        {
            StringBuilder hotkeyString = new StringBuilder();
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Alt)).Append(" + ");
            }
            if ((modifierKeyCode & Keys.Control) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Control)).Append(" + ");
            }
            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                hotkeyString.Append(GetKeyName(Keys.Shift)).Append(" + ");
            }
            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
            {
                hotkeyString.Append("Win").Append(" + ");
            }
            return hotkeyString.ToString();
        }

        private enum MapType : uint
        {
            MAPVK_VK_TO_VSC = 0, //The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
            MAPVK_VSC_TO_VK = 1, //The uCode parameter is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.
            MAPVK_VK_TO_CHAR = 2,     //The uCode parameter is a virtual-key code and is translated into an unshifted character value in the low order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.
            MAPVK_VSC_TO_VK_EX = 3, //The uCode parameter is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.
            MAPVK_VK_TO_VSC_EX = 4 //The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If the scan code is an extended scan code, the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code. If there is no translation, the function returns 0.
        }

        public static string GetKeyName(Keys givenKey)
        {
            StringBuilder keyName = new StringBuilder();
            const uint numpad = 55;

            Keys virtualKey = givenKey;
            string keyString;
            // Make VC's to real keys
            switch (virtualKey)
            {
                case Keys.Alt:
                    virtualKey = Keys.LMenu;
                    break;
                case Keys.Control:
                    virtualKey = Keys.ControlKey;
                    break;
                case Keys.Shift:
                    virtualKey = Keys.LShiftKey;
                    break;
                case Keys.Multiply:
                    GetKeyNameText(numpad << 16, keyName, 100);
                    keyString = keyName.ToString().Replace("*", "").Trim().ToLower();
                    if (keyString.IndexOf("(", StringComparison.Ordinal) >= 0)
                    {
                        return "* " + keyString;
                    }
                    keyString = keyString.Substring(0, 1).ToUpper() + keyString.Substring(1).ToLower();
                    return keyString + " *";
                case Keys.Divide:
                    GetKeyNameText(numpad << 16, keyName, 100);
                    keyString = keyName.ToString().Replace("*", "").Trim().ToLower();
                    if (keyString.IndexOf("(", StringComparison.Ordinal) >= 0)
                    {
                        return "/ " + keyString;
                    }
                    keyString = keyString.Substring(0, 1).ToUpper() + keyString.Substring(1).ToLower();
                    return keyString + " /";
            }
            uint scanCode = MapVirtualKey((uint)virtualKey, (uint)MapType.MAPVK_VK_TO_VSC);

            // because MapVirtualKey strips the extended bit for some keys
            switch (virtualKey)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down: // arrow keys
                case Keys.Prior:
                case Keys.Next: // page up and page down
                case Keys.End:
                case Keys.Home:
                case Keys.Insert:
                case Keys.Delete:
                case Keys.NumLock:
                    //Log.Debug("Modifying Extended bit");
                    scanCode |= 0x100; // set extended bit
                    break;
                case Keys.PrintScreen: // PrintScreen
                    scanCode = 311;
                    break;
                case Keys.Pause: // PrintScreen
                    scanCode = 69;
                    break;
            }
            scanCode |= 0x200;
            if (GetKeyNameText(scanCode << 16, keyName, 100) != 0)
            {
                string visibleName = keyName.ToString();
                if (visibleName.Length > 1)
                {
                    visibleName = visibleName.Substring(0, 1) + visibleName.Substring(1).ToLower();
                }
                return visibleName;
            }
            else
            {
                return givenKey.ToString();
            }
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize);

        /// <summary>
        /// https://www.codeproject.com/Tips/744914/
        /// Sorted-list-of-available-cultures-in-NET
        /// </summary>
        private static IEnumerable<CultureInfo> GetCultureList(
            CultureTypes cultureType = CultureTypes.SpecificCultures)
        {
            List<CultureInfo> cultureList = CultureInfo.GetCultures(cultureType).ToList();
            cultureList.Sort((p1, p2) => string.Compare(
                p1.NativeName, p2.NativeName, true, CultureInfo.InvariantCulture));
            return cultureList;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image)
        {
            int length = (int)Math.Round(
                16 * Scaling.Factor, 0,
                MidpointRounding.AwayFromZero);
            return ResizeImage(image, length, length);
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}