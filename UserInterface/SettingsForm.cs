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
        private static SettingsForm settingsForm;
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
                    TabStop = false,
                };
                textBoxHotkey.Enter += new EventHandler(TextBoxHotkeyEnter);
                textBoxHotkey.Leave += new EventHandler(TextBoxHotkey_Leave);
                tableLayoutPanelHotkey.Controls.Remove(textBoxHotkeyPlaceholder);
                tableLayoutPanelHotkey.Controls.Add(textBoxHotkey, 0, 0);
            }

            // designer always resets it to 1
            tabControl.SelectedIndex = 0;

            CombineControls(textBoxColorIcons, pictureBoxIcons);
            CombineControls(textBoxColorBackground, pictureBoxBackground);
            CombineControls(textBoxColorBackgroundBorder, pictureBoxBackgroundBorder);
            CombineControls(textBoxColorSearchField, pictureBoxSearchField);
            CombineControls(textBoxColorOpenFolder, pictureBoxOpenFolder);
            CombineControls(textBoxColorOpenFolderBorder, pictureBoxOpenFolderBorder);
            CombineControls(textBoxColorSelectedItem, pictureBoxSelectedItem);
            CombineControls(textBoxColorSelectedItemBorder, pictureBoxSelectedItemBorder);
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

            CombineControls(textBoxColorIconsDarkMode, pictureBoxIconsDarkMode);
            CombineControls(textBoxColorBackgroundDarkMode, pictureBoxBackgroundDarkMode);
            CombineControls(textBoxColorBackgroundBorderDarkMode, pictureBoxBackgroundBorderDarkMode);
            CombineControls(textBoxColorSearchFieldDarkMode, pictureBoxSearchFieldDarkMode);
            CombineControls(textBoxColorOpenFolderDarkMode, pictureBoxOpenFolderDarkMode);
            CombineControls(textBoxColorOpenFolderBorderDarkMode, pictureBoxOpenFolderBorderDarkMode);
            CombineControls(textBoxColorSelecetedItemDarkMode, pictureColorBoxSelectedItemDarkMode);
            CombineControls(textBoxColorSelectedItemBorderDarkMode, pictureBoxSelectedItemBorderDarkMode);
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
                groupBoxFolder.Text = Translator.GetText("Directory");
                buttonChangeFolder.Text = Translator.GetText("Changing directory");
                buttonOpenFolder.Text = Translator.GetText("Open directory");
                checkBoxSetFolderByWindowsContextMenu.Text = Translator.GetText("Set by context menu ");
                groupBoxConfigAndLogfile.Text = Translator.GetText("Configuration and log files");
                buttonChangeRelativeFolder.Text = Translator.GetText("Relative directory");
                checkBoxSaveConfigInApplicationDirectory.Text = Translator.GetText("Save configuration file in application directory");
                checkBoxSaveLogFileInApplicationDirectory.Text = Translator.GetText("Saving log file in application directory");
                buttonOpenAssemblyLocation.Text = Translator.GetText("Open application directory");
                groupBoxAutostart.Text = Translator.GetText("App start");
                if (IsStartupTask())
                {
                    groupBoxAutostart.Text += $" ({Translator.GetText("Task Manager")})";
                }

                checkBoxAutostart.Text = Translator.GetText("Start with Windows");
                checkBoxCheckForUpdates.Text = Translator.GetText("Check for updates");
                buttonAddStartup.Text = Translator.GetText("Start with Windows");
                groupBoxHotkey.Text = Translator.GetText("Hotkey");
                buttonHotkeyDefault.Text = Translator.GetText("Default");
                groupBoxLanguage.Text = Translator.GetText("Language");
                buttonGeneralDefault.Text = Translator.GetText("Default");

                tabPageSizeAndLocation.Text = Translator.GetText("Size and location");
                groupBoxSize.Text = Translator.GetText("Sizes in percent");
                labelSizeInPercent.Text = Translator.GetText("Application size");
                labelIconSizeInPercent.Text = Translator.GetText("Icon size");
                labelRowHeightInPercentage.Text = Translator.GetText("Row height");
                labelMaxMenuWidth.Text = Translator.GetText("Maximum menu width");
                labelMaxMenuHeight.Text = Translator.GetText("Maximum menu height");
                groupBoxMenuAppearAt.Text = Translator.GetText("Main menu appears");
                radioButtonAppearAtTheBottomLeft.Text = Translator.GetText("Bottom left");
                radioButtonAppearAtTheBottomRight.Text = Translator.GetText("Bottom right");
                radioButtonUseCustomLocation.Text = Translator.GetText("Custom (drag it to the appropriate position)");
                radioButtonAppearAtMouseLocation.Text = Translator.GetText("At mouse location");
                groupBoxSubMenuAppearAt.Text = Translator.GetText("Sub menu appears");
                radioButtonNextToPreviousMenu.Text = Translator.GetText("Next to the previous one");
                radioButtonOverlapping.Text = Translator.GetText("Overlapping");
                labelOverlappingByPixelsOffset.Text = Translator.GetText("Offset by pixels");
                buttonSizeAndLocationDefault.Text = Translator.GetText("Default");

                tabPageAdvanced.Text = Translator.GetText("Expanded");
                groupBoxOptionalFeatures.Text = Translator.GetText("Optional Features");
                checkBoxResolveLinksToFolders.Text = Translator.GetText("Resolve links to folders and show content");
                checkBoxShowInTaskbar.Text = Translator.GetText("Show in Taskbar");
                checkBoxSendHotkeyInsteadKillOtherInstances.Text = Translator.GetText("Send hotkey to other instance");
                checkBoxSupportGamepad.Text = Translator.GetText("Support Gamepad");
                groupBoxClick.Text = Translator.GetText("Click");
                checkBoxOpenItemWithOneClick.Text = Translator.GetText("Single click to open an element");
                checkBoxOpenDirectoryWithOneClick.Text = Translator.GetText("Single click to open a directory");
                groupBoxDrag.Text = Translator.GetText("Drag");
                checkBoxDragDropItems.Text = Translator.GetText("Copy row element via drag and drop");
                checkBoxSwipeScrolling.Text = Translator.GetText("Scroll via swipe");
                groupBoxInternetShortcutIcons.Text = Translator.GetText("Directory of Internet Shortcut Icons");
                buttonChangeIcoFolder.Text = Translator.GetText("Changing directory");
                groupBoxSorting.Text = Translator.GetText("Sorting");
                radioButtonSortByTypeAndName.Text = Translator.GetText("Sorted by type (folder or file) and name");
                radioButtonSortByTypeAndDate.Text = Translator.GetText("Sorted by type (folder or file) and date");
                radioButtonSortByFileExtensionAndName.Text = Translator.GetText("Sorted by file extension and name");
                radioButtonSortByName.Text = Translator.GetText("Sorted by name");
                radioButtonSortByDate.Text = Translator.GetText("Sorted by date");
                groupBoxHiddenFilesAndFolders.Text = Translator.GetText("Hidden files and directories");
                radioButtonSystemSettingsShowHiddenFiles.Text = Translator.GetText("Use operating system settings");
                radioButtonNeverShowHiddenFiles.Text = Translator.GetText("Never show");
                radioButtonAlwaysShowHiddenFiles.Text = Translator.GetText("Always show");
                buttonAdvancedDefault.Text = Translator.GetText("Default");

                tabPageFolders.Text = Translator.GetText("Directories");
                groupBoxFoldersInRootFolder.Text = Translator.GetText("Add content of directory to root directory");
                checkBoxShowOnlyAsSearchResult.Text = Translator.GetText("Show only as search result");
                buttonAddFolderToRootFolder.Text = Translator.GetText("Add directory");
                buttonRemoveFolder.Text = Translator.GetText("Remove directory");
                ColumnFolder.HeaderText = Translator.GetText("Directory paths");
                ColumnRecursiveLevel.HeaderText = Translator.GetText("Recursive");
                ColumnOnlyFiles.HeaderText = Translator.GetText("Only Files");
                buttonAddSampleStartMenuFolder.Text = Translator.GetText("Add sample directory 'Start Menu'");
                buttonDefaultFolders.Text = Translator.GetText("Default");
                checkBoxGenerateShortcutsToDrives.Text = Translator.GetText("Generate drive shortcuts on startup");

                tabPageExpert.Text = Translator.GetText("Expert");
                groupBoxStaysOpen.Text = Translator.GetText("Menu stays open");
                checkBoxStayOpenWhenItemClicked.Text = Translator.GetText("If an element was clicked");
                checkBoxStayOpenWhenFocusLost.Text = Translator.GetText("If the focus is lost and the mouse is still on the menu");
                labelTimeUntilCloses.Text = Translator.GetText("Milliseconds until the menu closes if the mouse then leaves the menu");
                groupBoxOpenSubmenus.Text = Translator.GetText("Time until a menu opens");
                labelTimeUntilOpen.Text = Translator.GetText("Milliseconds until a menu opens when the mouse is on it");
                checkBoxStayOpenWhenFocusLostAfterEnterPressed.Text = Translator.GetText("If the focus is lost and the Enter key was pressed");
                labelTimeUntilClosesAfterEnterPressed.Text = Translator.GetText("Milliseconds until the menu closes if the menu is not reactivated");
                groupBoxCache.Text = Translator.GetText("Cache");
                labelClearCacheIfMoreThanThisNumberOfItems.Text = Translator.GetText("Clear cache if more than this number of items");
                groupBoxSearchPattern.Text = Translator.GetText("Filter menu by file type e.g.: *.exe|*.dll");
                buttonExpertDefault.Text = Translator.GetText("Default");

                tabPageCustomize.Text = Translator.GetText("Customize");
                groupBoxAppearance.Text = Translator.GetText("Appearance");
                checkBoxUseIconFromRootFolder.Text = Translator.GetText("Use icon from directory");
                checkBoxRoundCorners.Text = Translator.GetText("Round corners");
                checkBoxDarkModeAlwaysOn.Text = Translator.GetText("Color scheme dark always active");
                checkBoxUseFading.Text = Translator.GetText("Fading");
                checkBoxShowLinkOverlay.Text = Translator.GetText("Show link overlay");
                checkBoxShowDirectoryTitleAtTop.Text = Translator.GetText("Show directory title at top");
                checkBoxShowCountOfElementsBelow.Text = Translator.GetText("Show count of elements");
                checkBoxShowSearchBar.Text = Translator.GetText("Show search bar");
                checkBoxShowFunctionKeyOpenFolder.Text = Translator.GetText("Show function key 'Open Folder'");
                checkBoxShowFunctionKeyPinMenu.Text = Translator.GetText("Show function key 'Pin menu'");
                checkBoxShowFunctionKeySettings.Text = Translator.GetText("Show function key 'Settings'");
                checkBoxShowFunctionKeyRestart.Text = Translator.GetText("Show function key 'Restart'");
                buttonAppearanceDefault.Text = Translator.GetText("Default");
                groupBoxColorsLightMode.Text = Translator.GetText("Color scheme bright");
                groupBoxColorsDarkMode.Text = Translator.GetText("Color scheme dark");
                labelMenuLightMode.Text = Translator.GetText("App menu");
                labelMenuDarkMode.Text = Translator.GetText("App menu");
                labelScrollbarLightMode.Text = Translator.GetText("Scrollbar");
                labelScrollbarDarkMode.Text = Translator.GetText("Scrollbar");
                labelIcons.Text = Translator.GetText("Icons");
                labelIconsDarkMode.Text = Translator.GetText("Icons");
                labelBackground.Text = Translator.GetText("Background");
                labelBackgroundDarkMode.Text = Translator.GetText("Background");
                labelBackgroundBorder.Text = Translator.GetText("Border of menu");
                labelBackgroundBorderDarkMode.Text = Translator.GetText("Border of menu");
                labelSearchField.Text = Translator.GetText("Search field");
                labelSearchFieldDarkMode.Text = Translator.GetText("Search field");
                labelOpenFolder.Text = Translator.GetText("Opened directory");
                labelOpenFolderDarkMode.Text = Translator.GetText("Opened directory");
                labelOpenFolderBorder.Text = Translator.GetText("Border of opened directory");
                labelOpenFolderBorderDarkMode.Text = Translator.GetText("Border of opened directory");
                labelSelectedItem.Text = Translator.GetText("Selected element");
                labelSelectedItemDarkMode.Text = Translator.GetText("Selected element");
                labelSelectedItemBorder.Text = Translator.GetText("Border of selected element");
                labelSelectedItemBorderDarkMode.Text = Translator.GetText("Border of selected element");
                labelScrollbarBackground.Text = Translator.GetText("Background");
                labelColorDarkModeScrollbarBackground.Text = Translator.GetText("Background");
                labelSlider.Text = Translator.GetText("Slider");
                labelColorDarkModeSlider.Text = Translator.GetText("Slider");
                labelSliderDragging.Text = Translator.GetText("Slider while dragging");
                labelColorDarkModeSliderDragging.Text = Translator.GetText("Slider while dragging");
                labelSliderHover.Text = Translator.GetText("Slider while mouse hovers over it 1");
                labelColorDarkModeSliderHover.Text = Translator.GetText("Slider while mouse hovers over it 1");
                labelSliderArrowsAndTrackHover.Text = Translator.GetText("Slider while mouse hovers over it 2");
                labelColorDarkModeSliderArrowsAndTrackHover.Text = Translator.GetText("Slider while mouse hovers over it 2");
                labelArrow.Text = Translator.GetText("Arrow");
                labelColorDarkModeArrow.Text = Translator.GetText("Arrow");
                labelArrowClick.Text = Translator.GetText("Arrow when clicking");
                labelColorDarkModeArrowClick.Text = Translator.GetText("Arrow when clicking");
                labelArrowClickBackground.Text = Translator.GetText("Background of arrow when clicking");
                labelColorDarkModeArrowClickBackground.Text = Translator.GetText("Background of arrow when clicking");
                labelArrowHover.Text = Translator.GetText("Arrow while mouse hovers over it");
                labelColorDarkModeArrowHover.Text = Translator.GetText("Arrow while mouse hovers over it");
                labelArrowHoverBackground.Text = Translator.GetText("Background of arrow while mouse hovers over it");
                labelColorDarkModeArrowHoverBackground.Text = Translator.GetText("Background of arrow while mouse hovers over it");

                buttonColorsDefault.Text = Translator.GetText("Default");
                buttonColorsDefaultDarkMode.Text = Translator.GetText("Default");
                buttonOk.Text = Translator.GetText("OK");
                buttonCancel.Text = Translator.GetText("Abort");
            }

            textBoxFolder.Text = Config.Path;
            checkBoxSetFolderByWindowsContextMenu.Checked = Settings.Default.SetFolderByWindowsContextMenu;
            checkBoxSaveConfigInApplicationDirectory.Checked = CustomSettingsProvider.IsActivatedConfigPathAssembly();
            checkBoxSaveLogFileInApplicationDirectory.Checked = Settings.Default.SaveLogFileInApplicationDirectory;

            if (IsStartupTask())
            {
                checkBoxAutostart.Visible = false;
                labelStartupStatus.Text = string.Empty;
            }
            else
            {
                buttonAddStartup.Visible = false;
                labelStartupStatus.Visible = false;
                checkBoxAutostart.Checked = Settings.Default.IsAutostartActivated;
            }

            checkBoxCheckForUpdates.Checked = Settings.Default.CheckForUpdates;
            textBoxHotkey.SetHotkey(Settings.Default.HotKey);

            InitializeLanguage();
            void InitializeLanguage()
            {
                List<Language> dataSource = new()
                {
                    new Language() { Name = "Afrikaans", Value = "af" },
                    new Language() { Name = "Azərbaycan", Value = "az" },
                    new Language() { Name = "bahasa Indonesia", Value = "id" },
                    new Language() { Name = "català", Value = "ca" },
                    new Language() { Name = "čeština", Value = "cs" },
                    new Language() { Name = "Cymraeg", Value = "cy" },
                    new Language() { Name = "dansk", Value = "da" },
                    new Language() { Name = "Deutsch", Value = "de" },
                    new Language() { Name = "eesti keel", Value = "et" },
                    new Language() { Name = "English", Value = "en" },
                    new Language() { Name = "English (United Kingdom)", Value = "en-GB" },
                    new Language() { Name = "Español", Value = "es" },
                    new Language() { Name = "Esperanto", Value = "eo" },
                    new Language() { Name = "euskara", Value = "eu" },
                    new Language() { Name = "Filipino", Value = "fil" },
                    new Language() { Name = "Français", Value = "fr" },
                    new Language() { Name = "Italian", Value = "it" },
                    new Language() { Name = "galego", Value = "gl" },
                    new Language() { Name = "Hrvatski", Value = "hr" },
                    new Language() { Name = "Gaeilge", Value = "ga" },
                    new Language() { Name = "íslenskur", Value = "is" },
                    new Language() { Name = "kiswahili", Value = "sw" },
                    new Language() { Name = "Kreyòl ayisyen", Value = "ht" },
                    new Language() { Name = "Latinus", Value = "la" },
                    new Language() { Name = "latviski", Value = "lv" },
                    new Language() { Name = "lietuvių", Value = "lt" },
                    new Language() { Name = "Magyar", Value = "hu" },
                    new Language() { Name = "Malti", Value = "mt" },
                    new Language() { Name = "Melayu", Value = "ms" },
                    new Language() { Name = "Nederlands", Value = "nl" },
                    new Language() { Name = "norsk", Value = "nb" },
                    new Language() { Name = "Polski", Value = "pl" },
                    new Language() { Name = "Português (Brasil)", Value = "pt-BR" },
                    new Language() { Name = "português (Portugal)", Value = "pt-PT" },
                    new Language() { Name = "Română", Value = "ro" },
                    new Language() { Name = "shqiptare", Value = "sq" },
                    new Language() { Name = "Slovenščina", Value = "sl" },
                    new Language() { Name = "slovenský", Value = "sk" },
                    new Language() { Name = "Suorittaa loppuun", Value = "fi" },
                    new Language() { Name = "svenska", Value = "sv" },
                    new Language() { Name = "Tiếng Việt", Value = "vi" },
                    new Language() { Name = "Türkçe ", Value = "tr" },
                    new Language() { Name = "Ελληνικά", Value = "el" },
                    new Language() { Name = "беларуская", Value = "bg" },
                    new Language() { Name = "македонски", Value = "mk" },
                    new Language() { Name = "русский", Value = "ru" },
                    new Language() { Name = "Српски", Value = "sr" },
                    new Language() { Name = "український", Value = "uk" },
                    new Language() { Name = "ქართული", Value = "ka" },
                    new Language() { Name = "հայերեն", Value = "hy" },
                    new Language() { Name = "יידיש", Value = "yi" },
                    new Language() { Name = "עִברִית", Value = "he" },
                    new Language() { Name = "اردو", Value = "ur" },
                    new Language() { Name = "عربي", Value = "ar" },
                    new Language() { Name = "فارسی", Value = "fa" },
                    new Language() { Name = "हिन्दी", Value = "hi" },
                    new Language() { Name = "ગુજરાતી", Value = "gu" },
                    new Language() { Name = "தமிழ்", Value = "ta" },
                    new Language() { Name = "తెలుగు", Value = "te" },
                    new Language() { Name = "ಕನ್ನಡ", Value = "kn" },
                    new Language() { Name = "ไทย", Value = "th" },
                    new Language() { Name = "ພາສາລາວ", Value = "lo" },
                    new Language() { Name = "ខ្មែរ", Value = "km" },
                    new Language() { Name = "한국어", Value = "ko" },
                    new Language() { Name = "中文(正體)", Value = "zh-TW" },
                    new Language() { Name = "中文(简体)", Value = "zh-CN" },
                    new Language() { Name = "日本語", Value = "ja" },
                };
                comboBoxLanguage.DataSource = dataSource;
                comboBoxLanguage.DisplayMember = "Name";
                comboBoxLanguage.ValueMember = "Value";
                comboBoxLanguage.SelectedValue =
                    Settings.Default.CurrentCultureInfoName;
                comboBoxLanguage.SelectedValue ??= "en";
            }

            numericUpDownSizeInPercent.Minimum = 100;
            numericUpDownSizeInPercent.Maximum = 200;
            numericUpDownSizeInPercent.Increment = 5;
            numericUpDownSizeInPercent.MouseWheel += NumericUpDown_MouseWheel;
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

            numericUpDownSizeInPercent.Value = Settings.Default.SizeInPercent;

            numericUpDownIconSizeInPercent.Minimum = 50;
            numericUpDownIconSizeInPercent.Maximum = 200;
            numericUpDownIconSizeInPercent.Increment = 5;
            numericUpDownIconSizeInPercent.MouseWheel += NumericUpDown_MouseWheel;
            numericUpDownIconSizeInPercent.Value = Settings.Default.IconSizeInPercent;

            numericUpDownRowHeighteInPercentage.Minimum = 50;
            numericUpDownRowHeighteInPercentage.Maximum = 200;
            numericUpDownRowHeighteInPercentage.Increment = 5;
            numericUpDownRowHeighteInPercentage.MouseWheel += NumericUpDown_MouseWheel;
            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                numericUpDownRowHeighteInPercentage.Value = Settings.Default.RowHeighteInPercentageTouch;
            }
            else
            {
                numericUpDownRowHeighteInPercentage.Value = Settings.Default.RowHeighteInPercentage;
            }

            numericUpDownMenuWidth.Minimum = 0;
            numericUpDownMenuWidth.Maximum = 400;
            numericUpDownMenuWidth.Increment = 5;
            numericUpDownMenuWidth.Value = Settings.Default.WidthMaxInPercent;

            numericUpDownMenuHeight.Minimum = 25;
            numericUpDownMenuHeight.Maximum = 400;
            numericUpDownMenuHeight.Increment = 5;
            numericUpDownMenuHeight.Value = Settings.Default.HeightMaxInPercent;

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

            numericUpDownOverlappingOffsetPixels.Value = Settings.Default.OverlappingOffsetPixels;
            if (Settings.Default.AppearNextToPreviousMenu)
            {
                radioButtonNextToPreviousMenu.Checked = true;
                numericUpDownOverlappingOffsetPixels.Enabled = false;
            }
            else
            {
                radioButtonOverlapping.Checked = true;
                numericUpDownOverlappingOffsetPixels.Enabled = true;
            }

            checkBoxResolveLinksToFolders.Checked = Settings.Default.ResolveLinksToFolders;
            checkBoxShowInTaskbar.Checked = Settings.Default.ShowInTaskbar;
            checkBoxShowInTaskbar.CheckedChanged += ShowHintToFindSettings;
            checkBoxSendHotkeyInsteadKillOtherInstances.Checked = Settings.Default.SendHotkeyInsteadKillOtherInstances;
            checkBoxSupportGamepad.Checked = Settings.Default.SupportGamepad;
            checkBoxOpenItemWithOneClick.Checked = Settings.Default.OpenItemWithOneClick;
            checkBoxOpenDirectoryWithOneClick.Checked = Settings.Default.OpenDirectoryWithOneClick;

            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                checkBoxDragDropItems.Checked = Settings.Default.DragDropItemsEnabledTouch;
                checkBoxSwipeScrolling.Checked = Settings.Default.SwipeScrollingEnabledTouch;
            }
            else
            {
                checkBoxDragDropItems.Checked = Settings.Default.DragDropItemsEnabled;
                checkBoxSwipeScrolling.Checked = Settings.Default.SwipeScrollingEnabled;
            }

            textBoxIcoFolder.Text = Settings.Default.PathIcoDirectory;
            radioButtonSortByTypeAndName.Checked = Settings.Default.SortByTypeAndNameWindowsExplorerSort;
            radioButtonSortByTypeAndDate.Checked = Settings.Default.SortByTypeAndDate;
            radioButtonSortByFileExtensionAndName.Checked = Settings.Default.SortByFileExtensionAndName;
            radioButtonSortByName.Checked = Settings.Default.SortByName;
            radioButtonSortByDate.Checked = Settings.Default.SortByDate;
            radioButtonSystemSettingsShowHiddenFiles.Checked = Settings.Default.SystemSettingsShowHiddenFiles;
            radioButtonNeverShowHiddenFiles.Checked = Settings.Default.NeverShowHiddenFiles;
            radioButtonAlwaysShowHiddenFiles.Checked = Settings.Default.AlwaysShowHiddenFiles;

            checkBoxShowOnlyAsSearchResult.Checked = Settings.Default.ShowOnlyAsSearchResult;
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

            checkBoxGenerateShortcutsToDrives.Checked = Settings.Default.GenerateShortcutsToDrives;

            checkBoxStayOpenWhenItemClicked.Checked = Settings.Default.StaysOpenWhenItemClicked;
            checkBoxStayOpenWhenFocusLost.Checked = Settings.Default.StaysOpenWhenFocusLost;

            numericUpDownTimeUntilClose.Minimum = 200;
            numericUpDownTimeUntilClose.Maximum = 5000;
            numericUpDownTimeUntilClose.Increment = 10;
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

            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = Settings.Default.ClearCacheIfMoreThanThisNumberOfItems;

            textBoxSearchPattern.Text = Settings.Default.SearchPattern;

            checkBoxUseIconFromRootFolder.Checked = Settings.Default.UseIconFromRootFolder;
            checkBoxRoundCorners.Checked = Settings.Default.RoundCorners;
            checkBoxDarkModeAlwaysOn.Checked = Settings.Default.IsDarkModeAlwaysOn;
            checkBoxUseFading.Checked = Settings.Default.UseFading;
            checkBoxShowLinkOverlay.Checked = Settings.Default.ShowLinkOverlay;
            checkBoxShowDirectoryTitleAtTop.Checked = Settings.Default.ShowDirectoryTitleAtTop;
            checkBoxShowSearchBar.Checked = Settings.Default.ShowSearchBar;
            checkBoxShowCountOfElementsBelow.Checked = Settings.Default.ShowCountOfElementsBelow;
            checkBoxShowFunctionKeyOpenFolder.Checked = Settings.Default.ShowFunctionKeyOpenFolder;
            checkBoxShowFunctionKeyPinMenu.Checked = Settings.Default.ShowFunctionKeyPinMenu;
            checkBoxShowFunctionKeySettings.Checked = Settings.Default.ShowFunctionKeySettings;
            checkBoxShowFunctionKeyRestart.Checked = Settings.Default.ShowFunctionKeyRestart;
            checkBoxShowFunctionKeySettings.CheckedChanged += ShowHintToFindSettings;

            textBoxColorSelectedItem.Text = Settings.Default.ColorSelectedItem;
            textBoxColorSelecetedItemDarkMode.Text = Settings.Default.ColorDarkModeSelecetedItem;
            textBoxColorSelectedItemBorder.Text = Settings.Default.ColorSelectedItemBorder;
            textBoxColorSelectedItemBorderDarkMode.Text = Settings.Default.ColorDarkModeSelectedItemBorder;
            textBoxColorOpenFolder.Text = Settings.Default.ColorOpenFolder;
            textBoxColorOpenFolderDarkMode.Text = Settings.Default.ColorDarkModeOpenFolder;
            textBoxColorOpenFolderBorder.Text = Settings.Default.ColorOpenFolderBorder;
            textBoxColorOpenFolderBorderDarkMode.Text = Settings.Default.ColorDarkModeOpenFolderBorder;
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

        public string NewHotKey { get; } = string.Empty;

        /// <summary>
        /// Registers all hotkeys as configured, displaying a dialog in case of hotkey conflicts with other tools.
        /// </summary>
        /// <returns>Whether the hotkeys could be registered to the users content. This also applies if conflicts arise and the user decides to ignore these (i.e. not to register the conflicting hotkey).</returns>
        public static bool RegisterHotkeys()
        {
            return RegisterHotkeys(false);
        }

        public static void ShowSingleInstance()
        {
            if (IsOpen())
            {
                settingsForm.HandleInvoke(settingsForm.Activate);
            }
            else
            {
                settingsForm = new();
                settingsForm.ShowDialog();
            }
        }

        public static bool IsOpen()
        {
            return settingsForm != null;
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

        private static void AddSetFolderByWindowsContextMenu()
        {
            RegistryKey registryKeyContextMenu = null;
            RegistryKey registryKeyContextMenuCommand = null;

            try
            {
                registryKeyContextMenu = Registry.CurrentUser.CreateSubKey(MenuName);
                string binLocation = Environment.ProcessPath;
                if (registryKeyContextMenu != null)
                {
                    registryKeyContextMenu.SetValue(string.Empty, Translator.GetText("Set as directory"));
                    registryKeyContextMenu.SetValue("Icon", binLocation);
                }

                registryKeyContextMenuCommand = Registry.CurrentUser.CreateSubKey(Command);

                registryKeyContextMenuCommand?.SetValue(string.Empty, binLocation + " \"%1\"");

                Settings.Default.SetFolderByWindowsContextMenu = true;
            }
            catch (Exception ex)
            {
                Log.Warn("SaveSetFolderByWindowsContextMenu failed", ex);
            }
            finally
            {
                registryKeyContextMenu?.Close();

                registryKeyContextMenuCommand?.Close();
            }
        }

        private static void RemoveSetFolderByWindowsContextMenu()
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

                Settings.Default.SetFolderByWindowsContextMenu = false;
            }
            catch (Exception ex)
            {
                Log.Warn("DeleteSetFolderByWindowsContextMenu failed", ex);
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

        private void ShowHintToFindSettings(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked &&
                Settings.Default.ShowHintYouCanOpenSettingsInSystemtrayIconRightClick)
            {
                using HintYouCanOpenSettingsInSystemtrayIconRightClickForm hintForm = new();
                hintForm.ShowDialog();
                Settings.Default.ShowHintYouCanOpenSettingsInSystemtrayIconRightClick =
                    hintForm.GetShowHintAgain();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            AdjustControlMultilineIfNecessary(checkBoxStayOpenWhenFocusLost);
            dataGridViewFolders.ClearSelection();
            tabPageGeneral.AutoScrollMinSize = tableLayoutPanelGeneral.Size;
            tabPageSizeAndLocation.AutoScrollMinSize = tableLayoutPanelSizeAndLocation.Size;
            tabPageAdvanced.AutoScrollMinSize = tableLayoutPanelAdvanced.Size;
            tabPageFolders.AutoScrollMinSize = tableLayoutPanelFoldersInRootFolder.Size;
            tabPageExpert.AutoScrollMinSize = tableLayoutPanelExpert.Size;
            tabPageCustomize.AutoScrollMinSize = tableLayoutPanelCustomize.Size;
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tabControl.Dock = DockStyle.Fill;
            tabPageGeneral.Dock = DockStyle.Fill;
            tableLayoutPanelGeneral.Dock = DockStyle.Fill;
            tabPageSizeAndLocation.Dock = DockStyle.Fill;
            tableLayoutPanelSizeAndLocation.Dock = DockStyle.Fill;
            tabPageAdvanced.Dock = DockStyle.Fill;
            tableLayoutPanelAdvanced.Dock = DockStyle.Fill;
            tabPageFolders.Dock = DockStyle.Fill;
            tableLayoutPanelFoldersInRootFolder.Dock = DockStyle.Fill;
            tabPageExpert.Dock = DockStyle.Fill;
            tableLayoutPanelExpert.Dock = DockStyle.Fill;
            tabPageCustomize.Dock = DockStyle.Fill;
            tableLayoutPanelCustomize.Dock = DockStyle.Fill;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            Size size = Size;
            SuspendLayout();
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            Size = size;
            textBoxFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxHotkey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxIcoFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFolders.Dock = DockStyle.Fill;
            textBoxSearchPattern.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Opacity = 1;
            ResumeLayout();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (checkBoxSetFolderByWindowsContextMenu.Checked)
            {
                AddSetFolderByWindowsContextMenu();
            }
            else
            {
                RemoveSetFolderByWindowsContextMenu();
            }

            Settings.Default.SaveLogFileInApplicationDirectory = checkBoxSaveLogFileInApplicationDirectory.Checked;
            if (Settings.Default.SaveLogFileInApplicationDirectory)
            {
                try
                {
                    string fileNameToCheckWriteAccess = "CheckWriteAccess";
                    File.WriteAllText(fileNameToCheckWriteAccess, fileNameToCheckWriteAccess);
                    File.Delete(fileNameToCheckWriteAccess);
                    Settings.Default.SaveLogFileInApplicationDirectory = true;
                }
                catch (Exception ex)
                {
                    Settings.Default.SaveLogFileInApplicationDirectory = false;
                    Log.Warn($"Failed to save log file in application folder {Log.GetLogFilePath()}", ex);
                }
            }

            if (!IsStartupTask())
            {
                if (checkBoxAutostart.Checked)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    key.SetValue(
                        Assembly.GetExecutingAssembly().GetName().Name,
                        Environment.ProcessPath);

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

            Settings.Default.CheckForUpdates = checkBoxCheckForUpdates.Checked;

            Settings.Default.HotKey = new KeysConverter().ConvertToInvariantString(textBoxHotkey.Hotkey | textBoxHotkey.HotkeyModifiers);
            Settings.Default.CurrentCultureInfoName = comboBoxLanguage.SelectedValue.ToString();

            Settings.Default.SizeInPercent = (int)numericUpDownSizeInPercent.Value;
            Settings.Default.IconSizeInPercent = (int)numericUpDownIconSizeInPercent.Value;
            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                Settings.Default.RowHeighteInPercentageTouch = (int)numericUpDownRowHeighteInPercentage.Value;
            }
            else
            {
                Settings.Default.RowHeighteInPercentage = (int)numericUpDownRowHeighteInPercentage.Value;
            }

            Settings.Default.WidthMaxInPercent = (int)numericUpDownMenuWidth.Value;
            Settings.Default.HeightMaxInPercent = (int)numericUpDownMenuHeight.Value;

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

            Settings.Default.OverlappingOffsetPixels = (int)numericUpDownOverlappingOffsetPixels.Value;
            if (radioButtonNextToPreviousMenu.Checked)
            {
                Settings.Default.AppearNextToPreviousMenu = true;
            }
            else
            {
                Settings.Default.AppearNextToPreviousMenu = false;
            }

            Settings.Default.ResolveLinksToFolders = checkBoxResolveLinksToFolders.Checked;
            Settings.Default.ShowInTaskbar = checkBoxShowInTaskbar.Checked;
            Settings.Default.SendHotkeyInsteadKillOtherInstances = checkBoxSendHotkeyInsteadKillOtherInstances.Checked;
            Settings.Default.SupportGamepad = checkBoxSupportGamepad.Checked;
            Settings.Default.OpenItemWithOneClick = checkBoxOpenItemWithOneClick.Checked;
            Settings.Default.OpenDirectoryWithOneClick = checkBoxOpenDirectoryWithOneClick.Checked;

            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                Settings.Default.DragDropItemsEnabledTouch = checkBoxDragDropItems.Checked;
                Settings.Default.SwipeScrollingEnabledTouch = checkBoxSwipeScrolling.Checked;
            }
            else
            {
                Settings.Default.DragDropItemsEnabled = checkBoxDragDropItems.Checked;
                Settings.Default.SwipeScrollingEnabled = checkBoxSwipeScrolling.Checked;
            }

            Settings.Default.PathIcoDirectory = textBoxIcoFolder.Text;
            Settings.Default.SortByTypeAndNameWindowsExplorerSort = radioButtonSortByTypeAndName.Checked;
            Settings.Default.SortByTypeAndDate = radioButtonSortByTypeAndDate.Checked;
            Settings.Default.SortByFileExtensionAndName = radioButtonSortByFileExtensionAndName.Checked;
            Settings.Default.SortByName = radioButtonSortByName.Checked;
            Settings.Default.SortByDate = radioButtonSortByDate.Checked;
            Settings.Default.SystemSettingsShowHiddenFiles = radioButtonSystemSettingsShowHiddenFiles.Checked;
            Settings.Default.AlwaysShowHiddenFiles = radioButtonAlwaysShowHiddenFiles.Checked;
            Settings.Default.NeverShowHiddenFiles = radioButtonNeverShowHiddenFiles.Checked;

            Settings.Default.ShowOnlyAsSearchResult = checkBoxShowOnlyAsSearchResult.Checked;
            Settings.Default.PathsAddToMainMenu = string.Empty;
            foreach (DataGridViewRow row in dataGridViewFolders.Rows)
            {
                string pathAddToMainMenu = row.Cells[0].Value.ToString();
                bool recursiv = (bool)row.Cells[1].Value;
                bool onlyFiles = (bool)row.Cells[2].Value;
                Settings.Default.PathsAddToMainMenu += $"{pathAddToMainMenu} recursiv:{recursiv} onlyFiles:{onlyFiles}|";
            }

            Settings.Default.GenerateShortcutsToDrives = checkBoxGenerateShortcutsToDrives.Checked;

            Settings.Default.StaysOpenWhenItemClicked = checkBoxStayOpenWhenItemClicked.Checked;
            Settings.Default.StaysOpenWhenFocusLost = checkBoxStayOpenWhenFocusLost.Checked;
            Settings.Default.TimeUntilCloses = (int)numericUpDownTimeUntilClose.Value;
            Settings.Default.TimeUntilOpens = (int)numericUpDownTimeUntilOpens.Value;
            Settings.Default.StaysOpenWhenFocusLostAfterEnterPressed = checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked;
            Settings.Default.TimeUntilClosesAfterEnterPressed = (int)numericUpDownTimeUntilClosesAfterEnterPressed.Value;
            Settings.Default.ClearCacheIfMoreThanThisNumberOfItems = (int)numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value;
            Settings.Default.SearchPattern = textBoxSearchPattern.Text;

            Settings.Default.UseIconFromRootFolder = checkBoxUseIconFromRootFolder.Checked;
            Settings.Default.RoundCorners = checkBoxRoundCorners.Checked;
            Settings.Default.IsDarkModeAlwaysOn = checkBoxDarkModeAlwaysOn.Checked;
            Settings.Default.UseFading = checkBoxUseFading.Checked;
            Settings.Default.ShowLinkOverlay = checkBoxShowLinkOverlay.Checked;
            Settings.Default.ShowDirectoryTitleAtTop = checkBoxShowDirectoryTitleAtTop.Checked;
            Settings.Default.ShowSearchBar = checkBoxShowSearchBar.Checked;
            Settings.Default.ShowCountOfElementsBelow = checkBoxShowCountOfElementsBelow.Checked;
            Settings.Default.ShowFunctionKeyOpenFolder = checkBoxShowFunctionKeyOpenFolder.Checked;
            Settings.Default.ShowFunctionKeyPinMenu = checkBoxShowFunctionKeyPinMenu.Checked;
            Settings.Default.ShowFunctionKeySettings = checkBoxShowFunctionKeySettings.Checked;
            Settings.Default.ShowFunctionKeyRestart = checkBoxShowFunctionKeyRestart.Checked;

            if (checkBoxSaveConfigInApplicationDirectory.Checked)
            {
                CustomSettingsProvider.ActivateConfigPathAssembly();
                TrySettingsDefaultSave();
            }
            else
            {
                TrySettingsDefaultSave();
                CustomSettingsProvider.DeactivateConfigPathAssembly();
            }

            static void TrySettingsDefaultSave()
            {
                try
                {
                    Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    Log.Warn($"Failed to save configuration file in application folder {CustomSettingsProvider.ConfigPathAssembly}", ex);
                }
            }

            DialogResult = DialogResult.OK;
            AppRestart.ByConfigChange();
            Close();
        }

        private void ButtonAddStartup_Click(object sender, EventArgs e)
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
                    labelStartupStatus.Text = Translator.GetText("Deactivated");
                    break;
                case StartupTaskState.Enabled:
                case StartupTaskState.EnabledByPolicy:
                    labelStartupStatus.Text = Translator.GetText("Activated");
                    break;
                default:
                    break;
            }
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
            if (!string.IsNullOrEmpty(Config.Path))
            {
                Settings.Default.PathDirectory = Path.GetRelativePath(
                    Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName,
                    Config.Path);
                textBoxFolder.Text = Config.Path;
            }
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

        private void ButtonHotkeyDefault_Click(object sender, EventArgs e)
        {
            textBoxHotkey.SetHotkey("Ctrl+LWin");
        }

        private void ButtonGeneralDefault_Click(object sender, EventArgs e)
        {
            checkBoxSetFolderByWindowsContextMenu.Checked = false;
            checkBoxSaveConfigInApplicationDirectory.Checked = false;
            checkBoxSaveLogFileInApplicationDirectory.Checked = false;
            checkBoxAutostart.Checked = false;
            checkBoxCheckForUpdates.Checked = false;
        }

        private void ButtonChangeIcoFolder_Click(object sender, EventArgs e)
        {
            Config.SetFolderIcoByUser();
            textBoxIcoFolder.Text = Settings.Default.PathIcoDirectory;
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
            checkBoxShowOnlyAsSearchResult.Checked = false;
            dataGridViewFolders.Rows.Clear();
            checkBoxGenerateShortcutsToDrives.Checked = false;
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

        private void ButtonSizeAndLocationDefault_Click(object sender, EventArgs e)
        {
            numericUpDownSizeInPercent.Value = 100;
            numericUpDownIconSizeInPercent.Value = 100;
            numericUpDownRowHeighteInPercentage.Value = 100;
            numericUpDownMenuWidth.Value = 100;
            numericUpDownMenuHeight.Value = 100;

            radioButtonAppearAtTheBottomRight.Checked = false;
            radioButtonAppearAtTheBottomLeft.Checked = true;
            radioButtonUseCustomLocation.Checked = false;
            radioButtonAppearAtMouseLocation.Checked = false;

            radioButtonNextToPreviousMenu.Checked = true;
            numericUpDownOverlappingOffsetPixels.Value = 150;
        }

        private void ButtonAdvancedDefault_Click(object sender, EventArgs e)
        {
            checkBoxResolveLinksToFolders.Checked = true;
            checkBoxShowInTaskbar.Checked = true;
            checkBoxSendHotkeyInsteadKillOtherInstances.Checked = false;
            checkBoxSupportGamepad.Checked = false;
            checkBoxOpenItemWithOneClick.Checked = true;
            checkBoxOpenDirectoryWithOneClick.Checked = false;
            if (DllImports.NativeMethods.IsTouchEnabled())
            {
                checkBoxDragDropItems.Checked = false;
                checkBoxSwipeScrolling.Checked = true;
            }
            else
            {
                checkBoxDragDropItems.Checked = true;
                checkBoxSwipeScrolling.Checked = false;
            }

            textBoxIcoFolder.Text = Path.Combine(
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.ApplicationData), $"SystemTrayMenu"), "ico");
            if (!Directory.Exists(Settings.Default.PathIcoDirectory))
            {
                Directory.CreateDirectory(Settings.Default.PathIcoDirectory);
            }

            radioButtonSortByName.Checked = true;
            radioButtonSortByDate.Checked = false;
            radioButtonSystemSettingsShowHiddenFiles.Checked = true;
            radioButtonNeverShowHiddenFiles.Checked = false;
            radioButtonAlwaysShowHiddenFiles.Checked = false;
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
            numericUpDownTimeUntilClose.Value = 400;
            numericUpDownTimeUntilOpens.Value = 100;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked = true;
            numericUpDownTimeUntilClosesAfterEnterPressed.Value = 200;
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = 200;
            textBoxSearchPattern.Text = string.Empty;
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

        private void ButtonAppearanceDefault_Click(object sender, EventArgs e)
        {
            checkBoxUseIconFromRootFolder.Checked = false;
            checkBoxRoundCorners.Checked = false;
            checkBoxUseFading.Checked = false;
            checkBoxDarkModeAlwaysOn.Checked = true;
            checkBoxShowLinkOverlay.Checked = false;
            checkBoxShowDirectoryTitleAtTop.Checked = false;
            checkBoxShowSearchBar.Checked = true;
            checkBoxShowCountOfElementsBelow.Checked = false;
            checkBoxShowFunctionKeyOpenFolder.Checked = false;
            checkBoxShowFunctionKeyPinMenu.Checked = false;
            checkBoxShowFunctionKeySettings.Checked = false;
            checkBoxShowFunctionKeyRestart.Checked = false;
        }

        private void ButtonDefaultColors_Click(object sender, EventArgs e)
        {
            textBoxColorIcons.Text = "#95a0a6";
            textBoxColorOpenFolder.Text = "#C2F5DE";
            textBoxColorOpenFolderBorder.Text = "#99FFA5";
            textBoxColorBackground.Text = "#ffffff";
            textBoxColorBackgroundBorder.Text = "#000000";
            textBoxColorSearchField.Text = "#ffffff";
            textBoxColorSelectedItem.Text = "#CCE8FF";
            textBoxColorSelectedItemBorder.Text = "#99D1FF";
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
            textBoxColorIconsDarkMode.Text = "#95a0a6";
            textBoxColorOpenFolderDarkMode.Text = "#14412A";
            textBoxColorOpenFolderBorderDarkMode.Text = "#144B55";
            textBoxColorBackgroundDarkMode.Text = "#202020";
            textBoxColorBackgroundBorderDarkMode.Text = "#000000";
            textBoxColorSearchFieldDarkMode.Text = "#191919";
            textBoxColorSelecetedItemDarkMode.Text = "#333333";
            textBoxColorSelectedItemBorderDarkMode.Text = "#141D4B";
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

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBoxHotkey?.Dispose();
            settingsForm?.Dispose();
            settingsForm = null;
        }

        private void RadioButtonNextToPreviousMenu_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonOverlapping.CheckedChanged -= RadioButtonOverlapping_CheckedChanged;
            radioButtonOverlapping.Checked = false;
            radioButtonOverlapping.CheckedChanged += RadioButtonOverlapping_CheckedChanged;
            numericUpDownOverlappingOffsetPixels.Enabled = false;
        }

        private void RadioButtonOverlapping_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonNextToPreviousMenu.CheckedChanged -= RadioButtonNextToPreviousMenu_CheckedChanged;
            radioButtonNextToPreviousMenu.Checked = false;
            radioButtonNextToPreviousMenu.CheckedChanged += RadioButtonNextToPreviousMenu_CheckedChanged;
            numericUpDownOverlappingOffsetPixels.Enabled = true;
        }
    }
}
