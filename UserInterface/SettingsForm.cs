// <copyright file="SettingsForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.HotkeyTextboxControl.HotkeyControl;

    public partial class SettingsForm : Form
    {
        private readonly string newHotKey = string.Empty;
        private bool inHotkey;
        private ColorConverter colorConverter = new ColorConverter();

        public SettingsForm()
        {
            InitializeComponent();

            // Initialize and replace here here, because designer always removes it
            InitializeTextBoxHotkeyAndReplacetextBoxHotkeyPlaceholder();
            void InitializeTextBoxHotkeyAndReplacetextBoxHotkeyPlaceholder()
            {
                textBoxHotkey = new HotkeyTextboxControl.HotkeyControl
                {
                    Hotkey = Keys.None,
                    HotkeyModifiers = Keys.None,
                    Name = "textBoxHotkey",
                    Size = new Size(200, 20),
                    Text = "None",
                };
                textBoxHotkey.Enter += new EventHandler(this.TextBoxHotkeyEnter);
                textBoxHotkey.Leave += new EventHandler(this.TextBoxHotkey_Leave);
                tableLayoutPanelHotkey.Controls.Remove(textBoxHotkeyPlaceholder);
                tableLayoutPanelHotkey.Controls.Add(textBoxHotkey, 0, 0);
            }

            // designer always resets it to 1
            this.tabControl.SelectedIndex = 0;

            Translate();
            void Translate()
            {
                Text = Translator.GetText("Settings");
                tabPageGeneral.Text = Translator.GetText("General");
                tabPageAdvanced.Text = Translator.GetText("Advanced");
                tabPageCustomize.Text = Translator.GetText("Customize");
                groupBoxFolder.Text = Translator.GetText("Folder");
                buttonChangeFolder.Text = Translator.GetText("Change folder");
                groupBoxUSB.Text = Translator.GetText("USB");
                buttonChangeRelativeFolder.Text = Translator.GetText("Change to relative folder");
                checkBoxStoreConfigAtAssemblyLocation.Text = Translator.GetText("Store config at assembly location");
                buttonOpenAssemblyLocation.Text = Translator.GetText("Open assembly location");
                groupBoxAutostart.Text = Translator.GetText("Autostart");
                checkBoxAutostart.Text = Translator.GetText("Launch on startup");
                groupBoxHotkey.Text = Translator.GetText("Hotkey");
                buttonHotkeyDefault.Text = Translator.GetText("Default");
                groupBoxLanguage.Text = Translator.GetText("Language");
                groupBoxClick.Text = Translator.GetText("Click");
                checkBoxOpenItemWithOneClick.Text = Translator.GetText("Single click to start item");
                groupBoxSizeAndLocation.Text = Translator.GetText("Size and location");
                checkBoxAppearAtMouseLocation.Text = Translator.GetText("Appear at mouse location");
                labelMaxMenuWidth.Text = Translator.GetText("Pixels maximum menu width");
                groupBoxStaysOpen.Text = Translator.GetText("Stays open");
                checkBoxStayOpenWhenItemClicked.Text = Translator.GetText("If an item was clicked");
                checkBoxStayOpenWhenFocusLost.Text = Translator.GetText("If the focus is lost and if the mouse is still on the menu");
                labelTimeUntilCloses.Text = Translator.GetText("Milliseconds until the menu closes if in this case the mouse then leaves the menu");
                groupBoxOpenSubmenus.Text = Translator.GetText("Time until a menu opens");
                labelTimeUntilOpen.Text = Translator.GetText("Milliseconds until a menu opens when the mouse is on it");
                buttonAdvancedDefault.Text = Translator.GetText("Default");
                groupBoxColors.Text = Translator.GetText("Colors Light Mode and Dark Mode");
                buttonDefaultColors.Text = Translator.GetText("Default");
                groupBoxDarkMode.Text = Translator.GetText("Dark Mode");
                checkBoxDarkModeAlwaysOn.Text = Translator.GetText("Dark Mode always active");
                labelPasteHtmlColorCodeOrDoubleClickIntoField.Text = Translator.GetText("To change a color paste a HTML Color Code or double click into a field.");
                labelTitle.Text = Translator.GetText("Title");
                labelBackground.Text = Translator.GetText("Background");
                labelSearchField.Text = Translator.GetText("Search field");
                labelOpenFolder.Text = Translator.GetText("Open folder");
                labelOpenFolderBorder.Text = Translator.GetText("Open folder border");
                labelSelectedItem.Text = Translator.GetText("Selected item");
                labelSelectedItemBorder.Text = Translator.GetText("Selected item border");
                labelWarning.Text = Translator.GetText("Warning");
                buttonDefaultColors.Text = Translator.GetText("Default Light Mode");
                buttonDefaultColorsDark.Text = Translator.GetText("Default Dark Mode");
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
                    Settings.Default.IsAutostartActivated;
            }

            InitializeHotkey();
            void InitializeHotkey()
            {
                textBoxHotkey.SetHotkey(Settings.Default.HotKey);
            }

            InitializeLanguage();
            void InitializeLanguage()
            {
                List<Language> dataSource = new List<Language>
                {
                    new Language() { Name = "čeština", Value = "cs" },
                    new Language() { Name = "Deutsch", Value = "de" },
                    new Language() { Name = "English", Value = "en" },
                    new Language() { Name = "Español", Value = "es" },
                    new Language() { Name = "Français", Value = "fr" },
                    new Language() { Name = "Italiano", Value = "it" },
                    new Language() { Name = "Nederlands", Value = "nl" },
                    new Language() { Name = "Português (Brasil)", Value = "pt-BR" },

                    // new Language() { Name = "русский", Value = "ru" },
                };
                comboBoxLanguage.DataSource = dataSource;
                comboBoxLanguage.DisplayMember = "Name";
                comboBoxLanguage.ValueMember = "Value";
                comboBoxLanguage.SelectedValue =
                    Settings.Default.CurrentCultureInfoName;
                if (comboBoxLanguage.SelectedValue == null)
                {
                    comboBoxLanguage.SelectedValue = "en";
                }
            }

            checkBoxStoreConfigAtAssemblyLocation.Checked = CustomSettingsProvider.IsActivatedConfigPathAssembly();

            checkBoxOpenItemWithOneClick.Checked = Settings.Default.OpenItemWithOneClick;
            checkBoxAppearAtMouseLocation.Checked = Settings.Default.AppearAtMouseLocation;

            numericUpDownMenuWidth.Minimum = 50;
            numericUpDownMenuWidth.Maximum = 500;
            numericUpDownMenuWidth.Increment = 10;
            numericUpDownMenuWidth.Value = Settings.Default.MaximumMenuWidth;

            checkBoxStayOpenWhenItemClicked.Checked = Settings.Default.StaysOpenWhenItemClicked;
            checkBoxStayOpenWhenFocusLost.Checked = Settings.Default.StaysOpenWhenFocusLost;

            numericUpDownTimeUntilClose.Minimum = 200;
            numericUpDownTimeUntilClose.Maximum = 5000;
            numericUpDownTimeUntilClose.Increment = 100;
            numericUpDownTimeUntilClose.Value = Settings.Default.TimeUntilCloses;

            numericUpDownTimeUntilOpens.Minimum = 20;
            numericUpDownTimeUntilOpens.Maximum = 1000;
            numericUpDownTimeUntilOpens.Increment = 10;
            numericUpDownTimeUntilOpens.Value = Settings.Default.TimeUntilOpens;

            checkBoxDarkModeAlwaysOn.Checked = Settings.Default.IsDarkModeAlwaysOn;
            textBoxColorSelectedItem.Text = Settings.Default.ColorSelectedItem;
            textBoxColorDarkModeSelecetedItem.Text = Settings.Default.ColorDarkModeSelecetedItem;
            textBoxColorSelectedItemBorder.Text = Settings.Default.ColorSelectedItemBorder;
            textBoxColorDarkModeSelectedItemBorder.Text = Settings.Default.ColorDarkModeSelectedItemBorder;
            textBoxColorOpenFolder.Text = Settings.Default.ColorOpenFolder;
            textBoxColorDarkModeOpenFolder.Text = Settings.Default.ColorDarkModeOpenFolder;
            textBoxColorOpenFolderBorder.Text = Settings.Default.ColorOpenFolderBorder;
            textBoxColorDarkModeOpenFolderBorder.Text = Settings.Default.ColorDarkModeOpenFolderBorder;
            textBoxColorWarning.Text = Settings.Default.ColorWarning;
            textBoxColorDarkModeWarning.Text = Settings.Default.ColorDarkModeWarning;
            textBoxColorTitle.Text = Settings.Default.ColorTitle;
            textBoxColorDarkModeTitle.Text = Settings.Default.ColorDarkModeTitle;
            textBoxColorBackground.Text = Settings.Default.ColorBackground;
            textBoxColorDarkModeBackground.Text = Settings.Default.ColorDarkModeBackground;
            textBoxColorSearchField.Text = Settings.Default.ColorSearchField;
            textBoxColorDarkModeSearchField.Text = Settings.Default.ColorDarkModeSearchField;
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
            Keys modifierKeyCode = HotkeyModifiersFromString(hotkeyString);
            Keys virtualKeyCode = HotkeyFromString(hotkeyString);
            if (!Keys.None.Equals(virtualKeyCode))
            {
                if (RegisterHotKey(modifierKeyCode, virtualKeyCode, handler) < 0)
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
                Settings.Default.HotKey,
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
                UnregisterHotkeys();
                success = RegisterHotkeys(false);
            }
            else if (dr == DialogResult.Ignore)
            {
                UnregisterHotkeys();
                success = RegisterHotkeys(true);
            }

            return success;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tabControl.Size = new Size(
                tabControl.Size.Width,
                tableLayoutPanelCustomize.Size.Height + 50);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            SaveAutostart();
            void SaveAutostart()
            {
                if (checkBoxAutostart.Checked)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    key.SetValue(
                        Assembly.GetExecutingAssembly().GetName().Name,
                        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    Settings.Default.IsAutostartActivated = true;
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    key.DeleteValue("SystemTrayMenu", false);
                    Settings.Default.IsAutostartActivated = false;
                }
            }

            SaveHotkey();
            void SaveHotkey()
            {
                Settings.Default.HotKey =
                    new KeysConverter().ConvertToInvariantString(
                    textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            }

            SaveLanguage();
            void SaveLanguage()
            {
                Settings.Default.CurrentCultureInfoName =
                    comboBoxLanguage.SelectedValue.ToString();
            }

            Settings.Default.OpenItemWithOneClick = checkBoxOpenItemWithOneClick.Checked;
            Settings.Default.AppearAtMouseLocation = checkBoxAppearAtMouseLocation.Checked;
            Settings.Default.MaximumMenuWidth = (int)numericUpDownMenuWidth.Value;
            Settings.Default.StaysOpenWhenItemClicked = checkBoxStayOpenWhenItemClicked.Checked;
            Settings.Default.StaysOpenWhenFocusLost = checkBoxStayOpenWhenFocusLost.Checked;
            Settings.Default.TimeUntilCloses = (int)numericUpDownTimeUntilClose.Value;
            Settings.Default.TimeUntilOpens = (int)numericUpDownTimeUntilOpens.Value;
            Settings.Default.IsDarkModeAlwaysOn = checkBoxDarkModeAlwaysOn.Checked;
            Settings.Default.ColorSelectedItem = textBoxColorSelectedItem.Text;
            Settings.Default.ColorDarkModeSelecetedItem = textBoxColorDarkModeSelecetedItem.Text;
            Settings.Default.ColorSelectedItemBorder = textBoxColorSelectedItemBorder.Text;
            Settings.Default.ColorDarkModeSelectedItemBorder = textBoxColorDarkModeSelectedItemBorder.Text;
            Settings.Default.ColorOpenFolder = textBoxColorOpenFolder.Text;
            Settings.Default.ColorDarkModeOpenFolder = textBoxColorDarkModeOpenFolder.Text;
            Settings.Default.ColorOpenFolderBorder = textBoxColorOpenFolderBorder.Text;
            Settings.Default.ColorDarkModeOpenFolderBorder = textBoxColorDarkModeOpenFolderBorder.Text;
            Settings.Default.ColorWarning = textBoxColorWarning.Text;
            Settings.Default.ColorDarkModeWarning = textBoxColorDarkModeWarning.Text;
            Settings.Default.ColorTitle = textBoxColorTitle.Text;
            Settings.Default.ColorDarkModeTitle = textBoxColorDarkModeTitle.Text;
            Settings.Default.ColorBackground = textBoxColorBackground.Text;
            Settings.Default.ColorDarkModeBackground = textBoxColorDarkModeBackground.Text;
            Settings.Default.ColorSearchField = textBoxColorSearchField.Text;
            Settings.Default.ColorDarkModeSearchField = textBoxColorDarkModeSearchField.Text;

            if (checkBoxStoreConfigAtAssemblyLocation.Checked)
            {
                CustomSettingsProvider.ActivateConfigPathAssembly();
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.Save();
                CustomSettingsProvider.DeactivateConfigPathAssembly();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonHotkeyDefault_Click(object sender, EventArgs e)
        {
            textBoxHotkey.SetHotkey("Ctrl+LWin");
        }

        private void ButtonAdvancedDefault_Click(object sender, EventArgs e)
        {
            checkBoxOpenItemWithOneClick.Checked = true;
            checkBoxAppearAtMouseLocation.Checked = false;
            numericUpDownMenuWidth.Value = 300;
            checkBoxStayOpenWhenItemClicked.Checked = true;
            checkBoxStayOpenWhenFocusLost.Checked = true;
            numericUpDownTimeUntilClose.Value = 1000;
            numericUpDownTimeUntilOpens.Value = 100;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            Config.SetFolderByUser(false);
            textBoxFolder.Text = Config.Path;
        }

        private void ButtonChangeRelativeFolder_Click(object sender, EventArgs e)
        {
            Settings.Default.PathDirectory = Path.GetRelativePath(
                Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName,
                Config.Path);
            textBoxFolder.Text = Config.Path;
        }

        private void ButtonOpenAssemblyLocation_Click(object sender, EventArgs e)
        {
            Log.ProcessStart(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName);
        }

        private void TextBoxHotkeyEnter(object sender, EventArgs e)
        {
            UnregisterHotkeys();
            inHotkey = true;
        }

        private void TextBoxHotkey_Leave(object sender, EventArgs e)
        {
            Settings.Default.HotKey =
                new KeysConverter().ConvertToInvariantString(
                textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            RegisterHotkeys();
            inHotkey = false;
        }

        private void CheckBoxStayOpenWhenFocusLost_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownTimeUntilClose.Enabled = checkBoxStayOpenWhenFocusLost.Checked;
        }

        private void TextBoxColorsChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = textBox.Text.Trim();

            try
            {
                Color color = (Color)colorConverter.ConvertFromString(textBox.Text);
                textBox.BackColor = color;
            }
            catch
            {
                textBox.Text = "#ffffff";
                textBox.BackColor = Color.White;
            }
        }

        private void TextBoxColorsDoubleClick(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            colorDialog.Color = textBox.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = ColorTranslator.ToHtml(colorDialog.Color);
                textBox.BackColor = colorDialog.Color;
            }
        }

        private void ButtonDefaultColors_Click(object sender, EventArgs e)
        {
            textBoxColorTitle.Text = "#f0ffff";
            textBoxColorOpenFolder.Text = "#C2F5DE";
            textBoxColorOpenFolderBorder.Text = "#99FFA5";
            textBoxColorBackground.Text = "#ffffff";
            textBoxColorSearchField.Text = "#ffffff";
            textBoxColorSelectedItem.Text = "#CCE8FF";
            textBoxColorSelectedItemBorder.Text = "#99D1FF";
            textBoxColorWarning.Text = "#FFCCE8";
        }

        private void ButtonDefaultColorsDark_Click(object sender, EventArgs e)
        {
            textBoxColorDarkModeTitle.Text = "#2B2B2B";
            textBoxColorDarkModeOpenFolder.Text = "#14412A";
            textBoxColorDarkModeOpenFolderBorder.Text = "#144B55";
            textBoxColorDarkModeBackground.Text = "#202020";
            textBoxColorDarkModeSearchField.Text = "#191919";
            textBoxColorDarkModeSelecetedItem.Text = "#333333";
            textBoxColorDarkModeSelectedItemBorder.Text = "#141D4B";
            textBoxColorDarkModeWarning.Text = "#4B1834";
        }
    }
}
