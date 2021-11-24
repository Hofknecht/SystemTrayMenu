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
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface.FolderBrowseDialog;
    using SystemTrayMenu.Utilities;
    using Windows.ApplicationModel;
    using static SystemTrayMenu.UserInterface.HotkeyTextboxControl.HotkeyControl;

    public partial class SettingsForm : Form
    {
        private const string MenuName = @"Software\Classes\directory\shell\SystemTrayMenu_SetAsRootFolder";
        private const string Command = @"Software\Classes\directory\shell\SystemTrayMenu_SetAsRootFolder\command";

        private static readonly Icon SystemTrayMenu = Resources.SystemTrayMenu;
        private readonly ColorConverter colorConverter = new();
        private bool inHotkey;

        public SettingsForm()
        {
            InitializeComponent();
            Icon = SystemTrayMenu;

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
                textBoxHotkey.TabStop = false;
                textBoxHotkey.Enter += new EventHandler(TextBoxHotkeyEnter);
                textBoxHotkey.Leave += new EventHandler(TextBoxHotkey_Leave);
                tableLayoutPanelHotkey.Controls.Remove(textBoxHotkeyPlaceholder);
                tableLayoutPanelHotkey.Controls.Add(textBoxHotkey, 0, 0);
            }

            // designer always resets it to 1
            tabControl.SelectedIndex = 0;

            CombineControls(textBoxColorTitle, pictureBoxTitle);
            CombineControls(textBoxColorIcons, pictureBoxIcons);
            CombineControls(textBoxColorBackground, pictureBoxBackground);
            CombineControls(textBoxColorBackgroundBorder, pictureBoxBackgroundBorder);
            CombineControls(textBoxColorSearchField, pictureBoxSearchField);
            CombineControls(textBoxColorOpenFolder, pictureBoxOpenFolder);
            CombineControls(textBoxColorOpenFolderBorder, pictureBoxOpenFolderBorder);
            CombineControls(textBoxColorSelectedItem, pictureBoxSelectedItem);
            CombineControls(textBoxColorSelectedItemBorder, pictureBoxSelectedItemBorder);
            CombineControls(textBoxColorWarning, pictureBoxWarning);
            CombineControls(textBoxColorScrollbarBackground, pictureBoxScrollbarBackground);
            CombineControls(textBoxColorSlider, pictureBoxSlider);
            CombineControls(textBoxColorSliderDragging, pictureBoxSliderDragging);
            CombineControls(textBoxColorSliderHover, pictureBoxSliderHover);
            CombineControls(textBoxColorSliderArrowsAndTrackHover, pictureBoxSliderArrowsAndTrackHover);
            CombineControls(textBoxColorArrow, pictureBoxArrow);
            CombineControls(textBoxColorArrowClick, pictureBoxArrowClick);
            CombineControls(textBoxColorArrowClickBackground, pictureBoxArrowClickBackground);
            CombineControls(textBoxColorArrowHover, pictureBoxArrowHover);
            CombineControls(textBoxColorArrowHoverBackground, pictureBoxArrowHoverBackground);

            CombineControls(textBoxColorTitleDarkMode, pictureBoxTitleDarkMode);
            CombineControls(textBoxColorIconsDarkMode, pictureBoxIconsDarkMode);
            CombineControls(textBoxColorBackgroundDarkMode, pictureBoxBackgroundDarkMode);
            CombineControls(textBoxColorBackgroundBorderDarkMode, pictureBoxBackgroundBorderDarkMode);
            CombineControls(textBoxColorSearchFieldDarkMode, pictureBoxSearchFieldDarkMode);
            CombineControls(textBoxColorOpenFolderDarkMode, pictureBoxOpenFolderDarkMode);
            CombineControls(textBoxColorOpenFolderBorderDarkMode, pictureBoxOpenFolderBorderDarkMode);
            CombineControls(textBoxColorSelecetedItemDarkMode, pictureColorBoxSelectedItemDarkMode);
            CombineControls(textBoxColorSelectedItemBorderDarkMode, pictureBoxSelectedItemBorderDarkMode);
            CombineControls(textBoxColorWarningDarkMode, pictureBoxWarningDarkMode);
            CombineControls(textBoxColorScrollbarBackgroundDarkMode, pictureBoxScrollbarBackgroundDarkMode);
            CombineControls(textBoxColorSliderDarkMode, pictureBoxSliderDarkMode);
            CombineControls(textBoxColorSliderDraggingDarkMode, pictureBoxSliderDraggingDarkMode);
            CombineControls(textBoxColorSliderHoverDarkMode, pictureBoxSliderHoverDarkMode);
            CombineControls(textBoxColorSliderArrowsAndTrackHoverDarkMode, pictureBoxSliderArrowsAndTrackHoverDarkMode);
            CombineControls(textBoxColorArrowDarkMode, pictureBoxArrowDarkMode);
            CombineControls(textBoxColorArrowClickDarkMode, pictureBoxArrowClickDarkMode);
            CombineControls(textBoxColorArrowClickBackgroundDarkMode, pictureBoxArrowClickBackgroundDarkMode);
            CombineControls(textBoxColorArrowHoverDarkMode, pictureBoxArrowHoverDarkMode);
            CombineControls(textBoxColorArrowHoverBackgroundDarkMode, pictureBoxArrowHoverBackgroundDarkMode);
            void CombineControls(Control textBoxColor, Control pictureBox)
            {
                textBoxColor.Tag = pictureBox;
                pictureBox.Tag = textBoxColor;
            }

            Translate();
            void Translate()
            {
                Text = Translator.GetText("Settings");
                tabPageGeneral.Text = Translator.GetText("General");
                tabPageAdvanced.Text = Translator.GetText("Advanced");
                tabPageExpert.Text = Translator.GetText("Expert");
                tabPageCustomize.Text = Translator.GetText("Customize");
                groupBoxFolder.Text = Translator.GetText("Folder");
                buttonChangeFolder.Text = Translator.GetText("Change folder");
                buttonOpenFolder.Text = Translator.GetText("Open Folder");
                checkBoxUseIconFromRootFolder.Text = Translator.GetText("Use icon from folder");
                checkBoxPossibilityToSelectFolderByWindowsContextMenu.Text = Translator.GetText("Set by context menu ");
                groupBoxUSB.Text = Translator.GetText("USB");
                buttonChangeRelativeFolder.Text = Translator.GetText("Change to relative folder");
                checkBoxStoreConfigAtAssemblyLocation.Text = Translator.GetText("Store config at the assembly location");
                buttonOpenAssemblyLocation.Text = Translator.GetText("Open the assembly location");
                groupBoxAutostart.Text = Translator.GetText("Autostart");
                if (IsStartupTask())
                {
                    groupBoxAutostart.Text += $" ({Translator.GetText("Task Manger")})";
                }

                checkBoxAutostart.Text = Translator.GetText("Launch on startup");
                buttonAddTaskManagerStartupTask.Text = Translator.GetText("Launch on startup");
                groupBoxHotkey.Text = Translator.GetText("Hotkey");
                buttonHotkeyDefault.Text = Translator.GetText("Default");
                groupBoxLanguage.Text = Translator.GetText("Language");
                tabControlFolders.Text = Translator.GetText("Folders");
                groupBoxFoldersInRootFolder.Text = Translator.GetText("Add folders to main menu");
                buttonAddFolderToRootFolder.Text = Translator.GetText("Add folder");
                buttonRemoveFolder.Text = Translator.GetText("Remove folder");
                ColumnFolder.HeaderText = Translator.GetText("Folder paths");
                ColumnRecursiveLevel.HeaderText = Translator.GetText("Recursive");
                ColumnOnlyFiles.HeaderText = Translator.GetText("Only Files");
                buttonAddSampleStartMenuFolder.Text = Translator.GetText("Add sample 'Start Menu' folder");
                buttonDefaultFolders.Text = Translator.GetText("Default");
                checkBoxCacheMainMenu.Text = Translator.GetText("Cache main menu");
                labelClearCacheIfMoreThanThisNumberOfItems.Text = Translator.GetText("Clear cache if more than this number of items");
                groupBoxClick.Text = Translator.GetText("Click");
                checkBoxShowInTaskbar.Text = Translator.GetText("Show in Taskbar");
                checkBoxOpenItemWithOneClick.Text = Translator.GetText("Single click to start item");
                groupBoxSize.Text = Translator.GetText("Size");
                labelSizeInPercentage.Text = $"% {Translator.GetText("Size")}";
                labelRowHeightInPercentage.Text = $"% {Translator.GetText("Row height in percentage")}";
                labelMaxMenuWidth.Text = Translator.GetText("Pixels maximum menu width");
                labelMaxMenuHeight.Text = Translator.GetText("Pixels maximum menu height");
                groupBoxMenuAppearAt.Text = Translator.GetText("Main menu appears at");
                radioButtonAppearAtTheBottomLeft.Text = Translator.GetText("Bottom left");
                radioButtonAppearAtTheBottomRight.Text = Translator.GetText("Bottom right");
                radioButtonUseCustomLocation.Text = Translator.GetText("Custom (drag it to the appropriate place)");
                radioButtonAppearAtMouseLocation.Text = Translator.GetText("Mouse location");
                checkBoxRefreshLocationEachTime.Text = Translator.GetText("Update the position every time the menu opens");
                buttonAdvancedDefault.Text = Translator.GetText("Default");
                groupBoxStaysOpen.Text = Translator.GetText("Stays open");
                checkBoxStayOpenWhenItemClicked.Text = Translator.GetText("If an item was clicked");
                checkBoxStayOpenWhenFocusLost.Text = Translator.GetText("If the focus is lost and if the mouse is still on the menu");
                labelTimeUntilCloses.Text = Translator.GetText("Milliseconds until the menu closes if in this case the mouse then leaves the menu");
                groupBoxOpenSubmenus.Text = Translator.GetText("Time until a menu opens");
                labelTimeUntilOpen.Text = Translator.GetText("Milliseconds until a menu opens when the mouse is on it");
                checkBoxStayOpenWhenFocusLostAfterEnterPressed.Text = Translator.GetText("If the focus is lost and the Enter key was pressed");
                labelTimeUntilClosesAfterEnterPressed.Text = Translator.GetText("Milliseconds until the menu closes if in this case the menu is not reactivated");
                buttonExpertDefault.Text = Translator.GetText("Default");
                groupBoxAppearance.Text = Translator.GetText("Appearance");
                checkBoxRoundCorners.Text = Translator.GetText("Round corners");
                checkBoxDarkModeAlwaysOn.Text = Translator.GetText("Dark Mode always active");
                groupBoxColorsLightMode.Text = Translator.GetText("Colors Light Mode");
                groupBoxColorsDarkMode.Text = Translator.GetText("Colors Dark Mode");
                labelMenuLightMode.Text = Translator.GetText("Menu");
                labelMenuDarkMode.Text = Translator.GetText("Menu");
                labelScrollbarLightMode.Text = Translator.GetText("Scrollbar");
                labelScrollbarDarkMode.Text = Translator.GetText("Scrollbar");
                labelTitle.Text = Translator.GetText("Title");
                labelTitleDarkMode.Text = Translator.GetText("Title");
                labelIcons.Text = Translator.GetText("Icons");
                labelIconsDarkMode.Text = Translator.GetText("Icons");
                labelBackground.Text = Translator.GetText("Background");
                labelBackgroundDarkMode.Text = Translator.GetText("Background");
                labelBackgroundBorder.Text = Translator.GetText("Border of menu");
                labelBackgroundBorderDarkMode.Text = Translator.GetText("Border of menu");
                labelSearchField.Text = Translator.GetText("Search field");
                labelSearchFieldDarkMode.Text = Translator.GetText("Search field");
                labelOpenFolder.Text = Translator.GetText("Opened folder");
                labelOpenFolderDarkMode.Text = Translator.GetText("Opened folder");
                labelOpenFolderBorder.Text = Translator.GetText("Border of opened folder");
                labelOpenFolderBorderDarkMode.Text = Translator.GetText("Border of opened folder");
                labelSelectedItem.Text = Translator.GetText("Selected item");
                labelSelectedItemDarkMode.Text = Translator.GetText("Selected item");
                labelSelectedItemBorder.Text = Translator.GetText("Border of selected item");
                labelSelectedItemBorderDarkMode.Text = Translator.GetText("Border of selected item");
                labelWarning.Text = Translator.GetText("Warning");
                labelWarningDarkMode.Text = Translator.GetText("Warning");
                labelScrollbarBackground.Text = Translator.GetText("Background");
                labelColorDarkModeScrollbarBackground.Text = Translator.GetText("Background");
                labelSlider.Text = Translator.GetText("Slider");
                labelColorDarkModeSlider.Text = Translator.GetText("Slider");
                labelSliderDragging.Text = Translator.GetText("Slider while dragging");
                labelColorDarkModeSliderDragging.Text = Translator.GetText("Slider while dragging");
                labelSliderHover.Text = Translator.GetText("Slider while mouse hovers 1");
                labelColorDarkModeSliderHover.Text = Translator.GetText("Slider while mouse hovers 1");
                labelSliderArrowsAndTrackHover.Text = Translator.GetText("Slider while mouse hovers 2");
                labelColorDarkModeSliderArrowsAndTrackHover.Text = Translator.GetText("Slider while mouse hovers 2");
                labelArrow.Text = Translator.GetText("Arrow");
                labelColorDarkModeArrow.Text = Translator.GetText("Arrow");
                labelArrowClick.Text = Translator.GetText("Arrow when clicking");
                labelColorDarkModeArrowClick.Text = Translator.GetText("Arrow when clicking");
                labelArrowClickBackground.Text = Translator.GetText("Background of arrow when clicking");
                labelColorDarkModeArrowClickBackground.Text = Translator.GetText("Background of arrow when clicking");
                labelArrowHover.Text = Translator.GetText("Arrow while mouse hovers");
                labelColorDarkModeArrowHover.Text = Translator.GetText("Arrow while mouse hovers");
                labelArrowHoverBackground.Text = Translator.GetText("Background of arrow while mouse hovers");
                labelColorDarkModeArrowHoverBackground.Text = Translator.GetText("Background of arrow while mouse hovers");

                buttonColorsDefault.Text = Translator.GetText("Default");
                buttonColorsDefaultDarkMode.Text = Translator.GetText("Default");
                buttonOk.Text = Translator.GetText("buttonOk");
                buttonCancel.Text = Translator.GetText("buttonCancel");
            }

            InitializeFolder();
            void InitializeFolder()
            {
                textBoxFolder.Text = Config.Path;
                checkBoxUseIconFromRootFolder.Checked =
                    Settings.Default.UseIconFromRootFolder;
                checkBoxPossibilityToSelectFolderByWindowsContextMenu.Checked =
                    Settings.Default.PossibilityToSelectFolderByWindowsContextMenu;
            }

            InitializeAutostart();
            void InitializeAutostart()
            {
                if (IsStartupTask())
                {
                    checkBoxAutostart.Visible = false;
                    labelStartupTaskStatus.Text = string.Empty;
                }
                else
                {
                    buttonAddTaskManagerStartupTask.Visible = false;
                    labelStartupTaskStatus.Visible = false;
                    checkBoxAutostart.Checked = Settings.Default.IsAutostartActivated;
                }
            }

            InitializeHotkey();
            void InitializeHotkey()
            {
                textBoxHotkey.SetHotkey(Settings.Default.HotKey);
            }

            InitializeLanguage();
            void InitializeLanguage()
            {
                List<Language> dataSource = new()
                {
                    new Language() { Name = "čeština", Value = "cs" },
                    new Language() { Name = "Deutsch", Value = "de" },
                    new Language() { Name = "English", Value = "en" },
                    new Language() { Name = "Español", Value = "es" },
                    new Language() { Name = "Français", Value = "fr" },
                    new Language() { Name = "Italiano", Value = "it" },
                    new Language() { Name = "Nederlands", Value = "nl" },
                    new Language() { Name = "Português (Brasil)", Value = "pt-BR" },
                    new Language() { Name = "Türkçe ", Value = "tr" },
                    new Language() { Name = "中文(简体)", Value = "zh-CN" },
                    new Language() { Name = "日本語", Value = "ja" },
                    new Language() { Name = "한국어", Value = "ko" },
                    new Language() { Name = "русский", Value = "ru" },
                    new Language() { Name = "Tiếng Việt", Value = "vi" },
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

            try
            {
                foreach (string pathAndRecursivString in Settings.Default.PathsAddToMainMenu.Split(@"|"))
                {
                    if (string.IsNullOrEmpty(pathAndRecursivString))
                    {
                        continue;
                    }

                    string pathAddToMainMenu = pathAndRecursivString.Split("recursiv:")[0].Trim();
                    bool recursive = pathAndRecursivString.Split("recursiv:")[1].StartsWith("True");
                    bool onlyFiles = pathAndRecursivString.Split("onlyFiles:")[1].StartsWith("True");
                    dataGridViewFolders.Rows.Add(pathAddToMainMenu, recursive, onlyFiles);
                }
            }
            catch (Exception ex)
            {
                Log.Warn("PathsAddToMainMenu", ex);
            }

            checkBoxCacheMainMenu.Checked = Settings.Default.CacheMainMenu;
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = Settings.Default.ClearCacheIfMoreThanThisNumberOfItems;

            checkBoxShowInTaskbar.Checked = Settings.Default.ShowInTaskbar;
            checkBoxOpenItemWithOneClick.Checked = Settings.Default.OpenItemWithOneClick;

            numericUpDownSizeInPercentage.Minimum = 100;
            numericUpDownSizeInPercentage.Maximum = 200;
            numericUpDownSizeInPercentage.Increment = 25;
            numericUpDownSizeInPercentage.MouseWheel += NumericUpDown_MouseWheel;
            void NumericUpDown_MouseWheel(object sender, MouseEventArgs e)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                decimal newValue = numericUpDown.Value;
                if (e.Delta > 0)
                {
                    newValue += numericUpDown.Increment;
                    if (newValue > numericUpDown.Maximum)
                    {
                        newValue = (int)numericUpDown.Maximum;
                    }
                }
                else
                {
                    newValue -= numericUpDown.Increment;
                    if (newValue < numericUpDown.Minimum)
                    {
                        newValue = (int)numericUpDown.Minimum;
                    }
                }

                numericUpDown.Value = newValue;
                ((HandledMouseEventArgs)e).Handled = true;
            }

            numericUpDownSizeInPercentage.Value = Settings.Default.SizeInPercentage;

            numericUpDownRowHeighteInPercentage.Minimum = 50;
            numericUpDownRowHeighteInPercentage.Maximum = 200;
            numericUpDownRowHeighteInPercentage.Increment = 25;
            numericUpDownRowHeighteInPercentage.MouseWheel += NumericUpDown_MouseWheel;
            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                numericUpDownRowHeighteInPercentage.Value = Settings.Default.RowHeighteInPercentageTouch;
            }
            else
            {
                numericUpDownRowHeighteInPercentage.Value = Settings.Default.RowHeighteInPercentage;
            }

            numericUpDownMenuWidth.Minimum = 50;
            numericUpDownMenuWidth.Maximum = 1000;
            numericUpDownMenuWidth.Increment = 10;
            numericUpDownMenuWidth.Value = Settings.Default.MaximumMenuWidth;

            numericUpDownMenuHeight.Minimum = 200;
            numericUpDownMenuHeight.Maximum = 4000;
            numericUpDownMenuHeight.Increment = 10;
            numericUpDownMenuHeight.Value = Settings.Default.MaximumMenuHeight;

            if (Settings.Default.UseCustomLocation)
            {
                radioButtonUseCustomLocation.Checked = true;
            }
            else if (Settings.Default.AppearAtMouseLocation)
            {
                radioButtonAppearAtMouseLocation.Checked = true;
            }
            else if (Settings.Default.AppearAtTheBottomLeft)
            {
                radioButtonAppearAtTheBottomLeft.Checked = true;
            }
            else
            {
                radioButtonAppearAtTheBottomRight.Checked = true;
            }

            checkBoxRefreshLocationEachTime.Checked = Settings.Default.RefreshLocationEachTime;

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

            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked = Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed;

            numericUpDownTimeUntilClosesAfterEnterPressed.Minimum = 20;
            numericUpDownTimeUntilClosesAfterEnterPressed.Maximum = 1000;
            numericUpDownTimeUntilClosesAfterEnterPressed.Increment = 10;
            numericUpDownTimeUntilClosesAfterEnterPressed.Value = Settings.Default.TimeUntilClosesAfterEnterPressed;

            checkBoxRoundCorners.Checked = Settings.Default.RoundCorners;
            checkBoxDarkModeAlwaysOn.Checked = Settings.Default.IsDarkModeAlwaysOn;

            textBoxColorSelectedItem.Text = Settings.Default.ColorSelectedItem;
            textBoxColorSelecetedItemDarkMode.Text = Settings.Default.ColorDarkModeSelecetedItem;
            textBoxColorSelectedItemBorder.Text = Settings.Default.ColorSelectedItemBorder;
            textBoxColorSelectedItemBorderDarkMode.Text = Settings.Default.ColorDarkModeSelectedItemBorder;
            textBoxColorOpenFolder.Text = Settings.Default.ColorOpenFolder;
            textBoxColorOpenFolderDarkMode.Text = Settings.Default.ColorDarkModeOpenFolder;
            textBoxColorOpenFolderBorder.Text = Settings.Default.ColorOpenFolderBorder;
            textBoxColorOpenFolderBorderDarkMode.Text = Settings.Default.ColorDarkModeOpenFolderBorder;
            textBoxColorWarning.Text = Settings.Default.ColorWarning;
            textBoxColorWarningDarkMode.Text = Settings.Default.ColorDarkModeWarning;
            textBoxColorTitle.Text = Settings.Default.ColorTitle;
            textBoxColorTitleDarkMode.Text = Settings.Default.ColorDarkModeTitle;
            textBoxColorIcons.Text = Settings.Default.ColorIcons;
            textBoxColorIconsDarkMode.Text = Settings.Default.ColorDarkModeIcons;
            textBoxColorBackground.Text = Settings.Default.ColorBackground;
            textBoxColorBackgroundDarkMode.Text = Settings.Default.ColorDarkModeBackground;
            textBoxColorBackgroundBorder.Text = Settings.Default.ColorBackgroundBorder;
            textBoxColorBackgroundBorderDarkMode.Text = Settings.Default.ColorDarkModeBackgroundBorder;
            textBoxColorSearchField.Text = Settings.Default.ColorSearchField;
            textBoxColorSearchFieldDarkMode.Text = Settings.Default.ColorDarkModeSearchField;

            textBoxColorScrollbarBackground.Text = Settings.Default.ColorScrollbarBackground;
            textBoxColorSlider.Text = Settings.Default.ColorSlider;
            textBoxColorSliderDragging.Text = Settings.Default.ColorSliderDragging;
            textBoxColorSliderHover.Text = Settings.Default.ColorSliderHover;
            textBoxColorSliderArrowsAndTrackHover.Text = Settings.Default.ColorSliderArrowsAndTrackHover;
            textBoxColorArrow.Text = Settings.Default.ColorArrow;
            textBoxColorArrowClick.Text = Settings.Default.ColorArrowClick;
            textBoxColorArrowClickBackground.Text = Settings.Default.ColorArrowClickBackground;
            textBoxColorArrowHover.Text = Settings.Default.ColorArrowHover;
            textBoxColorArrowHoverBackground.Text = Settings.Default.ColorArrowHoverBackground;
            textBoxColorScrollbarBackgroundDarkMode.Text = Settings.Default.ColorScrollbarBackgroundDarkMode;
            textBoxColorSliderDarkMode.Text = Settings.Default.ColorSliderDarkMode;
            textBoxColorSliderDraggingDarkMode.Text = Settings.Default.ColorSliderDraggingDarkMode;
            textBoxColorSliderHoverDarkMode.Text = Settings.Default.ColorSliderHoverDarkMode;
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Text = Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode;
            textBoxColorArrowDarkMode.Text = Settings.Default.ColorArrowDarkMode;
            textBoxColorArrowClickDarkMode.Text = Settings.Default.ColorArrowClickDarkMode;
            textBoxColorArrowClickBackgroundDarkMode.Text = Settings.Default.ColorArrowClickBackgroundDarkMode;
            textBoxColorArrowHoverDarkMode.Text = Settings.Default.ColorArrowHoverDarkMode;
            textBoxColorArrowHoverBackgroundDarkMode.Text = Settings.Default.ColorArrowHoverBackgroundDarkMode;
        }

        /// <summary>
        /// Gets NewHotKey.
        /// </summary>
        public string NewHotKey { get; } = string.Empty;

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
            StringBuilder failedKeys = new();
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

        private static void AdjustControlMultilineIfNecessary(Control control)
        {
            if (control.Width > control.Parent.Width)
            {
                control.MaximumSize = new Size(control.Parent.Width, 0);
                control.MinimumSize = new Size(0, control.Height * 2);
            }
        }

        private static void AddPossibilityToSelectFolderByWindowsContextMenu()
        {
            RegistryKey registryKeyContextMenu = null;
            RegistryKey registryKeyContextMenuCommand = null;

            try
            {
                registryKeyContextMenu = Registry.CurrentUser.CreateSubKey(MenuName);
                string binLocation = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                if (registryKeyContextMenu != null)
                {
                    registryKeyContextMenu.SetValue(string.Empty, Translator.GetText("Set as SystemTrayMenu folder"));
                    registryKeyContextMenu.SetValue("Icon", binLocation);
                }

                registryKeyContextMenuCommand = Registry.CurrentUser.CreateSubKey(Command);

                if (registryKeyContextMenuCommand != null)
                {
                    registryKeyContextMenuCommand.SetValue(string.Empty, binLocation + " \"%1\"");
                }

                Settings.Default.PossibilityToSelectFolderByWindowsContextMenu = true;
            }
            catch (Exception ex)
            {
                Log.Warn("SavePossibilityToSelectFolderByWindowsContextMenu failed", ex);
            }
            finally
            {
                if (registryKeyContextMenu != null)
                {
                    registryKeyContextMenu.Close();
                }

                if (registryKeyContextMenuCommand != null)
                {
                    registryKeyContextMenuCommand.Close();
                }
            }
        }

        private static void RemovePossibilityToSelectFolderByWindowsContextMenu()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(Command);
                if (registryKey != null)
                {
                    registryKey.Close();
                    Registry.CurrentUser.DeleteSubKey(Command);
                }

                registryKey = Registry.CurrentUser.OpenSubKey(MenuName);
                if (registryKey != null)
                {
                    registryKey.Close();
                    Registry.CurrentUser.DeleteSubKey(MenuName);
                }

                Settings.Default.PossibilityToSelectFolderByWindowsContextMenu = false;
            }
            catch (Exception ex)
            {
                Log.Warn("DeletePossibilityToSelectFolderByWindowsContextMenu failed", ex);
            }
        }

        private static bool IsStartupTask()
        {
            bool useStartupTask = false;
#if RELEASEPACKAGE
            useStartupTask = true;
#endif
            return useStartupTask;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            AdjustControlMultilineIfNecessary(checkBoxStayOpenWhenFocusLost);

            tabControl.Size = new Size(
                tabControl.Size.Width,
                tableLayoutPanelGeneral.Size.Height + (int)(50 * Scaling.Factor));

            dataGridViewFolders.ClearSelection();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Settings.Default.UseIconFromRootFolder = checkBoxUseIconFromRootFolder.Checked;

            if (!IsStartupTask())
            {
                SaveAutostartRegistryEntry();
            }

            SaveHotkey();
            void SaveHotkey()
            {
                Settings.Default.HotKey = new KeysConverter().ConvertToInvariantString(
                    textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            }

            SaveLanguage();
            void SaveLanguage()
            {
                Settings.Default.CurrentCultureInfoName = comboBoxLanguage.SelectedValue.ToString();
                Translator.Initialize();
            }

            PossibilityToSelectFolderByWindowsContextMenu();
            void PossibilityToSelectFolderByWindowsContextMenu()
            {
                if (checkBoxPossibilityToSelectFolderByWindowsContextMenu.Checked)
                {
                    AddPossibilityToSelectFolderByWindowsContextMenu();
                }
                else
                {
                    RemovePossibilityToSelectFolderByWindowsContextMenu();
                }
            }

            SaveFolders();
            void SaveFolders()
            {
                Settings.Default.PathsAddToMainMenu = string.Empty;
                foreach (DataGridViewRow row in dataGridViewFolders.Rows)
                {
                    string pathAddToMainMenu = row.Cells[0].Value.ToString();
                    bool recursiv = (bool)row.Cells[1].Value;
                    bool onlyFiles = (bool)row.Cells[2].Value;
                    Settings.Default.PathsAddToMainMenu += $"{pathAddToMainMenu} recursiv:{recursiv} onlyFiles:{onlyFiles}|";
                }
            }

            Settings.Default.CacheMainMenu = checkBoxCacheMainMenu.Checked;
            Settings.Default.ClearCacheIfMoreThanThisNumberOfItems = (int)numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value;

            Settings.Default.ShowInTaskbar = checkBoxShowInTaskbar.Checked;
            Settings.Default.OpenItemWithOneClick = checkBoxOpenItemWithOneClick.Checked;

            Settings.Default.SizeInPercentage = (int)numericUpDownSizeInPercentage.Value;
            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                Settings.Default.RowHeighteInPercentageTouch = (int)numericUpDownRowHeighteInPercentage.Value;
            }
            else
            {
                Settings.Default.RowHeighteInPercentage = (int)numericUpDownRowHeighteInPercentage.Value;
            }

            Settings.Default.MaximumMenuWidth = (int)numericUpDownMenuWidth.Value;
            Settings.Default.MaximumMenuHeight = (int)numericUpDownMenuHeight.Value;

            if (radioButtonUseCustomLocation.Checked)
            {
                Settings.Default.UseCustomLocation = true;
                Settings.Default.AppearAtMouseLocation = false;
                Settings.Default.AppearAtTheBottomLeft = false;
            }
            else if (radioButtonAppearAtMouseLocation.Checked)
            {
                Settings.Default.UseCustomLocation = false;
                Settings.Default.AppearAtMouseLocation = true;
                Settings.Default.AppearAtTheBottomLeft = false;
            }
            else if (radioButtonAppearAtTheBottomLeft.Checked)
            {
                Settings.Default.UseCustomLocation = false;
                Settings.Default.AppearAtMouseLocation = false;
                Settings.Default.AppearAtTheBottomLeft = true;
            }
            else
            {
                Settings.Default.UseCustomLocation = false;
                Settings.Default.AppearAtMouseLocation = false;
                Settings.Default.AppearAtTheBottomLeft = false;
            }

            Settings.Default.RefreshLocationEachTime = checkBoxRefreshLocationEachTime.Checked;

            Settings.Default.StaysOpenWhenItemClicked = checkBoxStayOpenWhenItemClicked.Checked;
            Settings.Default.StaysOpenWhenFocusLost = checkBoxStayOpenWhenFocusLost.Checked;
            Settings.Default.TimeUntilCloses = (int)numericUpDownTimeUntilClose.Value;
            Settings.Default.TimeUntilOpens = (int)numericUpDownTimeUntilOpens.Value;
            Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed = checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked;
            Settings.Default.TimeUntilClosesAfterEnterPressed = (int)numericUpDownTimeUntilClosesAfterEnterPressed.Value;

            Settings.Default.RoundCorners = checkBoxRoundCorners.Checked;
            Settings.Default.IsDarkModeAlwaysOn = checkBoxDarkModeAlwaysOn.Checked;

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

        private void SaveAutostartRegistryEntry()
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

        private void ButtonAddTaskManagerStartupTask_Click(object sender, EventArgs e)
        {
            _ = AddStartUpAsync();
            async Task AddStartUpAsync()
            {
                // Pass the task ID you specified in the appxmanifest file
                StartupTask startupTask = await StartupTask.GetAsync("MyStartupId");
                Log.Info($"Autostart {startupTask.State}.");

                switch (startupTask.State)
                {
                    case StartupTaskState.Enabled:
                    case StartupTaskState.EnabledByPolicy:
                        UpdateLabelStartupStatus(startupTask.State);
                        break;
                    case StartupTaskState.Disabled:
                        // Task is disabled but can be enabled.
                        StartupTaskState newState = await startupTask.RequestEnableAsync();
                        UpdateLabelStartupStatus(newState);
                        break;
                    case StartupTaskState.DisabledByUser:
                        UpdateLabelStartupStatus(startupTask.State);
                        break;
                    case StartupTaskState.DisabledByPolicy:
                        UpdateLabelStartupStatus(startupTask.State);
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateLabelStartupStatus(StartupTaskState newState)
        {
            switch (newState)
            {
                case StartupTaskState.Disabled:
                case StartupTaskState.DisabledByUser:
                case StartupTaskState.DisabledByPolicy:
                    labelStartupTaskStatus.Text = Translator.GetText("Deactivated");
                    break;
                case StartupTaskState.Enabled:
                case StartupTaskState.EnabledByPolicy:
                    labelStartupTaskStatus.Text = Translator.GetText("Activated");
                    break;
                default:
                    break;
            }
        }

        private void ButtonHotkeyDefault_Click(object sender, EventArgs e)
        {
            textBoxHotkey.SetHotkey("Ctrl+LWin");
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            Config.SetFolderByUser(false);
            textBoxFolder.Text = Config.Path;
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            Log.ProcessStart("explorer.exe", Config.Path, true);
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

        private void ButtonAddSampleStartMenuFolder_Click(object sender, EventArgs e)
        {
            dataGridViewFolders.Rows.Clear();
            string folderPathCommonStartMenu = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            dataGridViewFolders.Rows.Add(folderPathCommonStartMenu, true, true);
            dataGridViewFolders.ClearSelection();
        }

        private void ButtonClearFolders_Click(object sender, EventArgs e)
        {
            dataGridViewFolders.Rows.Clear();
            checkBoxCacheMainMenu.Checked = true;
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = 200;
        }

        private void ButtonAddFolderToRootFolder_Click(object sender, EventArgs e)
        {
            using FolderDialog dialog = new();
            dialog.InitialFolder = Config.Path;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataGridViewFolders.Rows.Add(dialog.Folder, false, true);
            }

            dataGridViewFolders.ClearSelection();
        }

        private void ButtonRemoveFolder_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewFolders.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dataGridViewFolders.Rows.RemoveAt(dataGridViewFolders.SelectedRows[0].Index);
                }
            }

            dataGridViewFolders.ClearSelection();
        }

        private void DataGridViewFolders_SelectionChanged(object sender, EventArgs e)
        {
            buttonRemoveFolder.Enabled = dataGridViewFolders.SelectedRows.Count > 0;
        }

        private void DataGridViewFolders_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewFolders.HitTest(e.X, e.Y).RowIndex < 0)
            {
                dataGridViewFolders.ClearSelection();
            }
        }

        private void DataGridViewFolders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridViewFolders.CancelEdit();
            }
        }

        private void DataGridViewFolders_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            EnableButtonAddStartMenu();
        }

        private void DataGridViewFolders_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnableButtonAddStartMenu();
        }

        private void DataGridViewFolders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            EnableButtonAddStartMenu();
        }

        private void EnableButtonAddStartMenu()
        {
            bool doesStartMenuFolderExist = false;
            foreach (DataGridViewRow row in dataGridViewFolders.Rows)
            {
                string folderPathCommonStartMenu = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                string pathAddToMainMenu = row.Cells[0].Value.ToString();
                bool recursiv = (bool)row.Cells[1].EditedFormattedValue;
                bool onlyFiles = (bool)row.Cells[2].EditedFormattedValue;
                if (folderPathCommonStartMenu == pathAddToMainMenu &&
                    recursiv == true &&
                    onlyFiles == true)
                {
                    doesStartMenuFolderExist = true;
                }
            }

            buttonAddSampleStartMenuFolder.Enabled = !doesStartMenuFolderExist;
        }

        private void ButtonAdvancedDefault_Click(object sender, EventArgs e)
        {
            checkBoxOpenItemWithOneClick.Checked = true;
            radioButtonAppearAtMouseLocation.Checked = false;
            numericUpDownSizeInPercentage.Value = 100;
            numericUpDownRowHeighteInPercentage.Value = 100;
            numericUpDownMenuWidth.Value = 300;
            numericUpDownMenuHeight.Value = 600;
            checkBoxShowInTaskbar.Checked = false;
            radioButtonAppearAtTheBottomRight.Checked = true;
            radioButtonAppearAtTheBottomLeft.Checked = false;
            radioButtonUseCustomLocation.Checked = false;
            radioButtonAppearAtMouseLocation.Checked = false;
            checkBoxRefreshLocationEachTime.Checked = false;
        }

        private void CheckBoxStayOpenWhenFocusLost_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownTimeUntilClose.Enabled = checkBoxStayOpenWhenFocusLost.Checked;
        }

        private void CheckBoxStayOpenWhenFocusLostAfterEnterPressed_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownTimeUntilClosesAfterEnterPressed.Enabled = checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked;
        }

        private void ButtonExpertDefault_Click(object sender, EventArgs e)
        {
            checkBoxStayOpenWhenItemClicked.Checked = true;
            checkBoxStayOpenWhenFocusLost.Checked = true;
            numericUpDownTimeUntilClose.Value = 500;
            numericUpDownTimeUntilOpens.Value = 100;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked = true;
            numericUpDownTimeUntilClosesAfterEnterPressed.Value = 200;
        }

        private void TextBoxColorsChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            PictureBox pictureBox = (PictureBox)textBox.Tag;
            pictureBox.BackColor = GetConvertFromStringOrDefault(textBox.Text.Trim());

            SaveColorsTemporarily();
        }

        private Color GetConvertFromStringOrDefault(string text)
        {
            try
            {
                return (Color)colorConverter.ConvertFromString(text);
            }
            catch
            {
                return Color.White;
            }
        }

        private void SaveColorsTemporarily()
        {
            if (Visible)
            {
                Settings.Default.ColorSelectedItem = textBoxColorSelectedItem.Text;
                Settings.Default.ColorDarkModeSelecetedItem = textBoxColorSelecetedItemDarkMode.Text;
                Settings.Default.ColorSelectedItemBorder = textBoxColorSelectedItemBorder.Text;
                Settings.Default.ColorDarkModeSelectedItemBorder = textBoxColorSelectedItemBorderDarkMode.Text;
                Settings.Default.ColorOpenFolder = textBoxColorOpenFolder.Text;
                Settings.Default.ColorDarkModeOpenFolder = textBoxColorOpenFolderDarkMode.Text;
                Settings.Default.ColorOpenFolderBorder = textBoxColorOpenFolderBorder.Text;
                Settings.Default.ColorDarkModeOpenFolderBorder = textBoxColorOpenFolderBorderDarkMode.Text;
                Settings.Default.ColorWarning = textBoxColorWarning.Text;
                Settings.Default.ColorDarkModeWarning = textBoxColorWarningDarkMode.Text;
                Settings.Default.ColorTitle = textBoxColorTitle.Text;
                Settings.Default.ColorDarkModeTitle = textBoxColorTitleDarkMode.Text;
                Settings.Default.ColorIcons = textBoxColorIcons.Text;
                Settings.Default.ColorDarkModeIcons = textBoxColorIconsDarkMode.Text;
                Settings.Default.ColorBackground = textBoxColorBackground.Text;
                Settings.Default.ColorDarkModeBackground = textBoxColorBackgroundDarkMode.Text;
                Settings.Default.ColorBackgroundBorder = textBoxColorBackgroundBorder.Text;
                Settings.Default.ColorDarkModeBackgroundBorder = textBoxColorBackgroundBorderDarkMode.Text;
                Settings.Default.ColorSearchField = textBoxColorSearchField.Text;
                Settings.Default.ColorDarkModeSearchField = textBoxColorSearchFieldDarkMode.Text;
                Settings.Default.ColorScrollbarBackground = textBoxColorScrollbarBackground.Text;
                Settings.Default.ColorSlider = textBoxColorSlider.Text;
                Settings.Default.ColorSliderDragging = textBoxColorSliderDragging.Text;
                Settings.Default.ColorSliderHover = textBoxColorSliderHover.Text;
                Settings.Default.ColorSliderArrowsAndTrackHover = textBoxColorSliderArrowsAndTrackHover.Text;
                Settings.Default.ColorArrow = textBoxColorArrow.Text;
                Settings.Default.ColorArrowClick = textBoxColorArrowClick.Text;
                Settings.Default.ColorArrowClickBackground = textBoxColorArrowClickBackground.Text;
                Settings.Default.ColorArrowHover = textBoxColorArrowHover.Text;
                Settings.Default.ColorArrowHoverBackground = textBoxColorArrowHoverBackground.Text;
                Settings.Default.ColorScrollbarBackgroundDarkMode = textBoxColorScrollbarBackgroundDarkMode.Text;
                Settings.Default.ColorSliderDarkMode = textBoxColorSliderDarkMode.Text;
                Settings.Default.ColorSliderDraggingDarkMode = textBoxColorSliderDraggingDarkMode.Text;
                Settings.Default.ColorSliderHoverDarkMode = textBoxColorSliderHoverDarkMode.Text;
                Settings.Default.ColorSliderArrowsAndTrackHoverDarkMode = textBoxColorSliderArrowsAndTrackHoverDarkMode.Text;
                Settings.Default.ColorArrowDarkMode = textBoxColorArrowDarkMode.Text;
                Settings.Default.ColorArrowClickDarkMode = textBoxColorArrowClickDarkMode.Text;
                Settings.Default.ColorArrowClickBackgroundDarkMode = textBoxColorArrowClickBackgroundDarkMode.Text;
                Settings.Default.ColorArrowHoverDarkMode = textBoxColorArrowHoverDarkMode.Text;
                Settings.Default.ColorArrowHoverBackgroundDarkMode = textBoxColorArrowHoverBackgroundDarkMode.Text;

                Config.InitializeColors(false);
            }
        }

        private void CheckBoxDarkModeAlwaysOnCheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.IsDarkModeAlwaysOn = checkBoxDarkModeAlwaysOn.Checked;
            Config.ResetReadDarkModeDone();
            SaveColorsTemporarily();
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            TextBox textBox = (TextBox)pictureBox.Tag;
            colorDialog.Color = pictureBox.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = ColorTranslator.ToHtml(colorDialog.Color);
                pictureBox.BackColor = colorDialog.Color;
            }
        }

        private void ButtonDefaultColors_Click(object sender, EventArgs e)
        {
            textBoxColorTitle.Text = "#f0ffff";
            textBoxColorIcons.Text = "#95a0a6";
            textBoxColorOpenFolder.Text = "#C2F5DE";
            textBoxColorOpenFolderBorder.Text = "#99FFA5";
            textBoxColorBackground.Text = "#ffffff";
            textBoxColorBackgroundBorder.Text = "#000000";
            textBoxColorSearchField.Text = "#ffffff";
            textBoxColorSelectedItem.Text = "#CCE8FF";
            textBoxColorSelectedItemBorder.Text = "#99D1FF";
            textBoxColorWarning.Text = "#FFCCE8";
            textBoxColorArrow.Text = "#606060";
            textBoxColorArrowHoverBackground.Text = "#dadada";
            textBoxColorArrowHover.Text = "#000000";
            textBoxColorArrowClick.Text = "#ffffff";
            textBoxColorArrowClickBackground.Text = "#606060";
            textBoxColorSliderArrowsAndTrackHover.Text = "#c0c0c0";
            textBoxColorSlider.Text = "#cdcdcd";
            textBoxColorSliderHover.Text = "#a6a6a6";
            textBoxColorSliderDragging.Text = "#606060";
            textBoxColorScrollbarBackground.Text = "#f0f0f0";
        }

        private void ButtonDefaultColorsDark_Click(object sender, EventArgs e)
        {
            textBoxColorTitleDarkMode.Text = "#2B2B2B";
            textBoxColorIconsDarkMode.Text = "#95a0a6";
            textBoxColorOpenFolderDarkMode.Text = "#14412A";
            textBoxColorOpenFolderBorderDarkMode.Text = "#144B55";
            textBoxColorBackgroundDarkMode.Text = "#202020";
            textBoxColorBackgroundBorderDarkMode.Text = "#000000";
            textBoxColorSearchFieldDarkMode.Text = "#191919";
            textBoxColorSelecetedItemDarkMode.Text = "#333333";
            textBoxColorSelectedItemBorderDarkMode.Text = "#141D4B";
            textBoxColorWarningDarkMode.Text = "#4B1834";
            textBoxColorArrowDarkMode.Text = "#676767";
            textBoxColorArrowHoverBackgroundDarkMode.Text = "#373737";
            textBoxColorArrowHoverDarkMode.Text = "#676767";
            textBoxColorArrowClickDarkMode.Text = "#171717";
            textBoxColorArrowClickBackgroundDarkMode.Text = "#a6a6a6";
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Text = "#4d4d4d";
            textBoxColorSliderDarkMode.Text = "#4d4d4d";
            textBoxColorSliderHoverDarkMode.Text = "#7a7a7a";
            textBoxColorSliderDraggingDarkMode.Text = "#a6a6a6";
            textBoxColorScrollbarBackgroundDarkMode.Text = "#171717";
        }

        private void StopPlayingDingSoundEnterKeyPressed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void StopPlayingDingSoundEnterKeyPressed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
