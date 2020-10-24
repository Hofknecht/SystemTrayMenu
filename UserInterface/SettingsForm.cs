// <copyright file="SettingsForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.UserInterface.HotkeyTextboxControl;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.HotkeyTextboxControl.HotkeyControl;

    public partial class SettingsForm : Form
    {
        private readonly string newHotKey = string.Empty;
        private bool inHotkey = false;

        public SettingsForm()
        {
            InitializeComponent();

            Translate();
            void Translate()
            {
                Text = Translator.GetText("Settings");
                tabPageGeneral.Text = Translator.GetText("General");
                tabPageExpert.Text = Translator.GetText("Expert");
                labelFolder.Text = Translator.GetText("Folder");
                labelAutostart.Text = Translator.GetText("Autostart");
                checkBoxAutostart.Text = Translator.GetText("Launch on startup");
                labelHotkey.Text = Translator.GetText("Hotkey");
                labelLanguage.Text = Translator.GetText("Language");
                checkBoxOpenItemWithOneClick.Text = Translator.GetText("Single click to start item");
                checkBoxDarkModeAlwaysOn.Text = Translator.GetText("Dark Mode always active");
                buttonOk.Text = Translator.GetText("buttonOk");
                buttonCancel.Text = Translator.GetText("buttonCancel");
            }

            InitializeFolder();
            void InitializeFolder()
            {
                textBoxFolder.Text = Config.Path;
            }

            InitializeAutostart();
            void InitializeAutostart()
            {
                checkBoxAutostart.Checked =
                    Properties.Settings.Default.IsAutostartActivated;
            }

            InitializeHotkey();
            void InitializeHotkey()
            {
                textBoxHotkey.SetHotkey(Properties.Settings.Default.HotKey);
            }

            InitializeLanguage();
            void InitializeLanguage()
            {
                List<Language> dataSource = new List<Language>
                {
                    new Language() { Name = "English", Value = "en" },
                    new Language() { Name = "Deutsch", Value = "de" },
                };
                comboBoxLanguage.DataSource = dataSource;
                comboBoxLanguage.DisplayMember = "Name";
                comboBoxLanguage.ValueMember = "Value";
                comboBoxLanguage.SelectedValue =
                    Properties.Settings.Default.CurrentCultureInfoName;
                if (comboBoxLanguage.SelectedValue == null)
                {
                    comboBoxLanguage.SelectedValue = "en";
                }
            }

            checkBoxOpenItemWithOneClick.Checked = Properties.Settings.Default.OpenItemWithOneClick;
            checkBoxDarkModeAlwaysOn.Checked = Properties.Settings.Default.IsDarkModeAlwaysOn;
        }

        public string NewHotKey => newHotKey;

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        public static bool RegisterHotkeys()
        {
            return RegisterHotkeys(false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (!inHotkey)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        /// <summary>
        /// Helper method to cleanly register a hotkey.
        /// </summary>
        /// <param name="failedKeys">failedKeys.</param>
        /// <param name="hotkeyString">hotkeyString.</param>
        /// <param name="handler">handler.</param>
        /// <returns>bool success.</returns>
        private static bool RegisterHotkey(StringBuilder failedKeys, string hotkeyString, HotKeyHandler handler)
        {
            Keys modifierKeyCode = HotkeyControl.HotkeyModifiersFromString(hotkeyString);
            Keys virtualKeyCode = HotkeyControl.HotkeyFromString(hotkeyString);
            if (!Keys.None.Equals(virtualKeyCode))
            {
                if (HotkeyControl.RegisterHotKey(modifierKeyCode, virtualKeyCode, handler) < 0)
                {
                    if (failedKeys.Length > 0)
                    {
                        failedKeys.Append(", ");
                    }

                    failedKeys.Append(hotkeyString);
                    return false;
                }
            }

            return true;
        }

        private static bool RegisterWrapper(StringBuilder failedKeys, HotKeyHandler handler)
        {
            bool success = RegisterHotkey(
                failedKeys,
                Properties.Settings.Default.HotKey,
                handler);
            return success;
        }

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <param name="ignoreFailedRegistration">if true, a failed hotkey registration will not be reported to the user - the hotkey will simply not be registered.</param>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        private static bool RegisterHotkeys(bool ignoreFailedRegistration)
        {
            // if (_instance == null)
            // {
            //    return false;
            // }
            bool success = true;
            StringBuilder failedKeys = new StringBuilder();
            if (!RegisterWrapper(failedKeys, Handler))
            {
                success = false;
            }

            if (!success)
            {
                if (!ignoreFailedRegistration)
                {
                    success = HandleFailedHotkeyRegistration(failedKeys.ToString());
                }
            }

            return success || ignoreFailedRegistration;
        }

        private static void Handler()
        {
        }

        ///// <summary>
        ///// Check if OneDrive is blocking hotkeys
        ///// </summary>
        ///// <returns>true if onedrive has hotkeys turned on</returns>
        // private static bool IsOneDriveBlockingHotkey()
        // {
        //    if (!Environment.OSVersion.IsWindows10())
        //    {
        //        return false;
        //    }
        //    var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    var oneDriveSettingsPath = Path.Combine(localAppData, @"Microsoft\OneDrive\settings\Personal");
        //    if (!Directory.Exists(oneDriveSettingsPath))
        //    {
        //        return false;
        //    }
        //    var oneDriveSettingsFile = Directory.GetFiles(oneDriveSettingsPath, "*_screenshot.dat").FirstOrDefault();
        //    if (!File.Exists(oneDriveSettingsFile))
        //    {
        //        return false;
        //    }
        //    var screenshotSetting = File.ReadAllLines(oneDriveSettingsFile).Skip(1).Take(1).First();
        //    return "2".Equals(screenshotSetting);
        // }

        /// <summary>
        /// Displays a dialog for the user to choose how to handle hotkey registration failures:
        /// retry (allowing to shut down the conflicting application before),
        /// ignore (not registering the conflicting hotkey and resetting the respective config to "None", i.e. not trying to register it again on next startup)
        /// abort (do nothing about it).
        /// </summary>
        /// <param name="failedKeys">comma separated list of the hotkeys that could not be registered, for display in dialog text.</param>
        /// <returns>bool success.</returns>
        private static bool HandleFailedHotkeyRegistration(string failedKeys)
        {
            bool success = false;
            string warningTitle = Translator.GetText("Warning");
            string message = Translator.GetText("Could not register the hot key.") + failedKeys;
            DialogResult dr = MessageBox.Show(message, warningTitle, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Retry)
            {
                // LOG.DebugFormat("Re-trying to register hotkeys");
                HotkeyControl.UnregisterHotkeys();
                success = RegisterHotkeys(false);
            }
            else if (dr == DialogResult.Ignore)
            {
                // LOG.DebugFormat("Ignoring failed hotkey registration");
                HotkeyControl.UnregisterHotkeys();
                success = RegisterHotkeys(true);
            }

            return success;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tabControlExpert.Size = new Size(
                tableLayoutPanelGeneral.Size.Width,
                tableLayoutPanelGeneral.Size.Height);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            SetAutostart();
            SetHotkey();
            SetLanguage();
            SetExpertOptions();
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetAutostart()
        {
            if (checkBoxAutostart.Checked)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(
                    Assembly.GetExecutingAssembly().GetName().Name,
                    System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Properties.Settings.Default.IsAutostartActivated = true;
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("SystemTrayMenu", false);
                Properties.Settings.Default.IsAutostartActivated = false;
            }
        }

        private void SetHotkey()
        {
            Properties.Settings.Default.HotKey =
                new KeysConverter().ConvertToInvariantString(
                textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
        }

        private void SetLanguage()
        {
            Properties.Settings.Default.CurrentCultureInfoName =
                comboBoxLanguage.SelectedValue.ToString();
        }

        private void SetExpertOptions()
        {
            Properties.Settings.Default.OpenItemWithOneClick = checkBoxOpenItemWithOneClick.Checked;
            Properties.Settings.Default.IsDarkModeAlwaysOn = checkBoxDarkModeAlwaysOn.Checked;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            Config.SetFolderByUser(false);
            textBoxFolder.Text = Config.Path;
        }

        private void TextBoxHotkeyEnter(object sender, EventArgs e)
        {
            HotkeyControl.UnregisterHotkeys();
            inHotkey = true;
        }

        private void TextBoxHotkey_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.HotKey =
                new KeysConverter().ConvertToInvariantString(
                textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            RegisterHotkeys();
            inHotkey = false;
        }
    }
}
