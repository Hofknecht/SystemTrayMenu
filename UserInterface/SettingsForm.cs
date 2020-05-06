using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SystemTrayMenu.UserInterface.Controls;
using SystemTrayMenu.Utilities;
using static SystemTrayMenu.UserInterface.Controls.HotkeyControl;

namespace SystemTrayMenu.UserInterface
{
    public partial class SettingsForm : Form
    {
        public string NewHotKey => newHotKey;
        private string newHotKey = string.Empty;
        private bool _inHotkey = false;

        public SettingsForm()
        {
            InitializeComponent();

            Translate();
            void Translate()
            {
                Text = Translator.GetText("Settings");
                tabPageGeneral.Text = Translator.GetText("General");
                labelFolder.Text = Translator.GetText("Folder");
                labelAutostart.Text = Translator.GetText("Autostart");
                checkBoxAutostart.Text = Translator.GetText("Launch on startup");
                labelHotkey.Text = Translator.GetText("Hotkey");
                labelLanguage.Text = Translator.GetText("Language");
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
                //textBoxHotkey.Text = Properties.Settings.Default.HotKey;
            }

            InitializeLanguage();
            void InitializeLanguage()
            {
                var dataSource = new List<Language>();
                dataSource.Add(new Language() { Name = "English", Value = "en" });
                dataSource.Add(new Language() { Name = "Deutsch", Value = "de" });
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
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(
                tableLayoutPanelGeneral.Size.Width,
                tableLayoutPanelGeneral.Size.Height);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            SetAutostart();
            SetHotkey();
            SetLanguage();
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
                key.SetValue(Assembly.GetExecutingAssembly().GetName().Name,
                    Assembly.GetEntryAssembly().Location);
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


            //Keys keys1 = HotkeyControl.Hotkey;
            //   Hotkey
            //   Keys keys = HotkeyControl.ModifierKeys;
            //Keys keys2 = HotkeyControl.HotkeyToString(keys, keys);
        }

        private void SetLanguage()
        {
            Properties.Settings.Default.CurrentCultureInfoName =
                comboBoxLanguage.SelectedValue.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Config.SetFolderByUser(false);
            textBoxFolder.Text = Config.Path;
        }

        private void textBoxHotkey_Enter(object sender, EventArgs e)
        {
            HotkeyControl.UnregisterHotkeys();
            _inHotkey = true;
        }

        private void textBoxHotkey_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.HotKey =
                new KeysConverter().ConvertToInvariantString(
                textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            RegisterHotkeys();
            //MainForm.RegisterHotkeys();
            _inHotkey = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (!_inHotkey)
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

        #region hotkeys

        /// <summary>
        /// Helper method to cleanly register a hotkey
        /// </summary>
        /// <param name="failedKeys"></param>
        /// <param name="functionName"></param>
        /// <param name="hotkeyString"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private static bool RegisterHotkey(StringBuilder failedKeys, string hotkeyString, HotKeyHandler handler)
        {
            Keys modifierKeyCode = HotkeyControl.HotkeyModifiersFromString(hotkeyString);
            Keys virtualKeyCode = HotkeyControl.HotkeyFromString(hotkeyString);
            if (!Keys.None.Equals(virtualKeyCode))
            {
                if (HotkeyControl.RegisterHotKey(modifierKeyCode, virtualKeyCode, handler) < 0)
                {
#warning logging
                    //LOG.DebugFormat("Failed to register {0} to hotkey: {1}", functionName, hotkeyString);
                    if (failedKeys.Length > 0)
                    {
                        failedKeys.Append(", ");
                    }
                    failedKeys.Append(hotkeyString);
                    return false;
                }
#warning logging
                //LOG.DebugFormat("Registered {0} to hotkey: {1}", functionName, hotkeyString);
            }
            else
            {
#warning logging
                //LOG.InfoFormat("Skipping hotkey registration for {0}, no hotkey set!", functionName);
            }
            return true;
        }

        private static bool RegisterWrapper(StringBuilder failedKeys, HotKeyHandler handler, bool ignoreFailedRegistration)
        {
#warning todo with Properties.Settings.Default.HotKey
            //IniValue hotkeyValue = _conf.Values[configurationKey];
            try
            {
                bool success = RegisterHotkey(failedKeys,
                    //hotkeyValue.Value.ToString(), 
                    Properties.Settings.Default.HotKey,
                    handler);
                if (!success && ignoreFailedRegistration)
                {
#warning logging
                    //LOG.DebugFormat("Ignoring failed hotkey registration for {0}, with value '{1}', resetting to 'None'.", functionName, hotkeyValue);
#warning todo with Properties.Settings.Default.HotKey
                    //_conf.Values[configurationKey].Value = Keys.None.ToString();
                    //_conf.IsDirty = true;
                }
                return success;
            }
            catch (Exception ex)
            {
#warning logging
                //LOG.Warn(ex);
                //LOG.WarnFormat("Restoring default hotkey for {0}, stored under {1} from '{2}' to '{3}'", functionName, configurationKey, hotkeyValue.Value, hotkeyValue.Attributes.DefaultValue);

                // when getting an exception the key wasn't found: reset the hotkey value
                //hotkeyValue.UseValueOrDefault(null);
                //hotkeyValue.ContainingIniSection.IsDirty = true;
#warning todo set default Properties.Settings.Default.HotKey = 
                return RegisterHotkey(failedKeys,
                    //hotkeyValue.Value.ToString(), 
                    Properties.Settings.Default.HotKey,
                    handler);
            }
        }

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        public static bool RegisterHotkeys()
        {
            return RegisterHotkeys(false);
        }

        static void TEST()
        {
            MessageBox.Show("TEST");
        }

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <param name="ignoreFailedRegistration">if true, a failed hotkey registration will not be reported to the user - the hotkey will simply not be registered</param>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        private static bool RegisterHotkeys(bool ignoreFailedRegistration)
        {
            //if (_instance == null)
            //{
            //    return false;
            //}
            bool success = true;
            StringBuilder failedKeys = new StringBuilder();
            if (!RegisterWrapper(failedKeys, TEST, ignoreFailedRegistration))
            {
                success = false;
            }

            if (!success)
            {
                if (!ignoreFailedRegistration)
                {
                    success = HandleFailedHotkeyRegistration(failedKeys.ToString());
                }
                else
                {
#warning todo with Properties.Settings.Default.HotKey

                    // if failures have been ignored, the config has probably been updated
                    //if (_conf.IsDirty)
                    //{
                    //    IniConfig.Save();
                    //}
                }
            }
            return success || ignoreFailedRegistration;
        }

        ///// <summary>
        ///// Check if OneDrive is blocking hotkeys
        ///// </summary>
        ///// <returns>true if onedrive has hotkeys turned on</returns>
        //private static bool IsOneDriveBlockingHotkey()
        //{
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
        //}

        /// <summary>
        /// Displays a dialog for the user to choose how to handle hotkey registration failures: 
        /// retry (allowing to shut down the conflicting application before),
        /// ignore (not registering the conflicting hotkey and resetting the respective config to "None", i.e. not trying to register it again on next startup)
        /// abort (do nothing about it)
        /// </summary>
        /// <param name="failedKeys">comma separated list of the hotkeys that could not be registered, for display in dialog text</param>
        /// <returns></returns>
        private static bool HandleFailedHotkeyRegistration(string failedKeys)
        {
            bool success = false;
#warning todo
            //var warningTitle = Language.GetString(LangKey.warning);
            var warningTitle = "Warning";
            //var message = string.Format(Language.GetString(LangKey.warning_hotkeys), failedKeys, IsOneDriveBlockingHotkey() ? " (OneDrive)" : "");
            var message = Translator.GetText("Could not register the hot key.");
            //DialogResult dr = MessageBox.Show(Instance, message, warningTitle, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
            DialogResult dr = MessageBox.Show(message, warningTitle, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Retry)
            {
                //LOG.DebugFormat("Re-trying to register hotkeys");
                HotkeyControl.UnregisterHotkeys();
                success = RegisterHotkeys(false);
            }
            else if (dr == DialogResult.Ignore)
            {
                //LOG.DebugFormat("Ignoring failed hotkey registration");
                HotkeyControl.UnregisterHotkeys();
                success = RegisterHotkeys(true);
            }
            return success;
        }
        #endregion
    }

    public class Language
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
