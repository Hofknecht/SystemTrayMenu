﻿using SystemTrayMenu.UserInterface.HotkeyTextboxControl;

namespace SystemTrayMenu.UserInterface
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu = new System.Windows.Forms.CheckBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.checkBoxUseIconFromRootFolder = new System.Windows.Forms.CheckBox();
            this.groupBoxUSB = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelUSB = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRelativeFolderOpenAssembly = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeRelativeFolder = new System.Windows.Forms.Button();
            this.buttonOpenAssemblyLocation = new System.Windows.Forms.Button();
            this.checkBoxStoreConfigAtAssemblyLocation = new System.Windows.Forms.CheckBox();
            this.groupBoxAutostart = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAutostart = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.groupBoxHotkey = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelHotkey = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxHotkeyPlaceholder = new System.Windows.Forms.TextBox();
            this.buttonHotkeyDefault = new System.Windows.Forms.Button();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxClick = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelClick = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxOpenItemWithOneClick = new System.Windows.Forms.CheckBox();
            this.groupBoxSizeAndLocation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSizeAndLocation = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSizeInPercentage = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuHeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuHeight = new System.Windows.Forms.Label();
            this.tableLayoutPanelMaxMenuWidth = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuWidth = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuWidth = new System.Windows.Forms.Label();
            this.checkBoxAppearAtMouseLocation = new System.Windows.Forms.CheckBox();
            this.groupBoxStaysOpen = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStaysOpen = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxStayOpenWhenItemClicked = new System.Windows.Forms.CheckBox();
            this.checkBoxStayOpenWhenFocusLost = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelTimeUntilCloses = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimeUntilCloses = new System.Windows.Forms.Label();
            this.numericUpDownTimeUntilClose = new System.Windows.Forms.NumericUpDown();
            this.groupBoxOpenSubmenus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelTimeUntilOpen = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownTimeUntilOpens = new System.Windows.Forms.NumericUpDown();
            this.labelTimeUntilOpen = new System.Windows.Forms.Label();
            this.buttonAdvancedDefault = new System.Windows.Forms.Button();
            this.tabPageCustomize = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCustomize = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxColorsLightMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelColorsAndDefault = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelIcons = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIcons = new System.Windows.Forms.PictureBox();
            this.textBoxColorIcons = new System.Windows.Forms.TextBox();
            this.labelIcons = new System.Windows.Forms.Label();
            this.tableLayoutPanelBackgroundBorder = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundBorder = new System.Windows.Forms.PictureBox();
            this.textBoxColorBackgroundBorder = new System.Windows.Forms.TextBox();
            this.labelBackgroundBorder = new System.Windows.Forms.Label();
            this.labelMenuLightMode = new System.Windows.Forms.Label();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.textBoxColorTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorBackground = new System.Windows.Forms.TextBox();
            this.labelBackground = new System.Windows.Forms.Label();
            this.buttonColorsDefault = new System.Windows.Forms.Button();
            this.tableLayoutPanelArrowHoverBackground = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverBackground = new System.Windows.Forms.TextBox();
            this.labelArrowHoverBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowHover = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHover = new System.Windows.Forms.TextBox();
            this.labelArrowHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowClickBackground = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickBackground = new System.Windows.Forms.TextBox();
            this.labelArrowClickBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowClick = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClick = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClick = new System.Windows.Forms.TextBox();
            this.labelArrowClick = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrow = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrow = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrow = new System.Windows.Forms.TextBox();
            this.labelArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderArrowsAndTrackHover = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderArrowsAndTrackHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderArrowsAndTrackHover = new System.Windows.Forms.TextBox();
            this.labelSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderHover = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderHover = new System.Windows.Forms.TextBox();
            this.labelSliderHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderDragging = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDragging = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDragging = new System.Windows.Forms.TextBox();
            this.labelSliderDragging = new System.Windows.Forms.Label();
            this.tableLayoutPanelSlider = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSlider = new System.Windows.Forms.PictureBox();
            this.textBoxColorSlider = new System.Windows.Forms.TextBox();
            this.labelSlider = new System.Windows.Forms.Label();
            this.tableLayoutPanelScrollbarBackground = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxScrollbarBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorScrollbarBackground = new System.Windows.Forms.TextBox();
            this.labelScrollbarBackground = new System.Windows.Forms.Label();
            this.labelScrollbarLightMode = new System.Windows.Forms.Label();
            this.tableLayoutPanelWarning = new System.Windows.Forms.TableLayoutPanel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.textBoxColorWarning = new System.Windows.Forms.TextBox();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelSelectedItemBorder = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItemBorder = new System.Windows.Forms.PictureBox();
            this.textBoxColorSelectedItemBorder = new System.Windows.Forms.TextBox();
            this.labelSelectedItemBorder = new System.Windows.Forms.Label();
            this.tableLayoutPanelSelectedItem = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItem = new System.Windows.Forms.PictureBox();
            this.textBoxColorSelectedItem = new System.Windows.Forms.TextBox();
            this.labelSelectedItem = new System.Windows.Forms.Label();
            this.tableLayoutPanelOpenFolderBorder = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderBorder = new System.Windows.Forms.PictureBox();
            this.textBoxColorOpenFolderBorder = new System.Windows.Forms.TextBox();
            this.labelOpenFolderBorder = new System.Windows.Forms.Label();
            this.tableLayoutPanelOpenFolder = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolder = new System.Windows.Forms.PictureBox();
            this.textBoxColorOpenFolder = new System.Windows.Forms.TextBox();
            this.labelOpenFolder = new System.Windows.Forms.Label();
            this.tableLayoutPanelSearchField = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearchField = new System.Windows.Forms.PictureBox();
            this.textBoxColorSearchField = new System.Windows.Forms.TextBox();
            this.labelSearchField = new System.Windows.Forms.Label();
            this.groupBoxColorsDarkMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIconsDarkMode = new System.Windows.Forms.PictureBox();
            this.labelIconsDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorIconsDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelBackgroundBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorBackgroundBorderDarkMode = new System.Windows.Forms.TextBox();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            this.labelMenuDarkMode = new System.Windows.Forms.Label();
            this.tableLayoutPanelSearchFieldDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearchFieldDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSearchFieldDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSearchFieldDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelOpenFolderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelOpenFolderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorOpenFolderDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelOpenFolderBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelOpenFolderBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorOpenFolderBorderDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelSelectedItemDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureColorBoxSelectedItemDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSelectedItemDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSelecetedItemDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelSelectedItemBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItemBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSelectedItemBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSelectedItemBorderDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelWarningDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxWarningDarkMode = new System.Windows.Forms.PictureBox();
            this.labelWarningDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorWarningDarkMode = new System.Windows.Forms.TextBox();
            this.labelScrollbarDarkMode = new System.Windows.Forms.Label();
            this.tableLayoutPanelScrollbarBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxScrollbarBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorScrollbarBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeScrollbarBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSlider = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderDraggingDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDraggingDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDraggingDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderDragging = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowClickDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowClick = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowClickBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowClickBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowHover = new System.Windows.Forms.Label();
            this.tableLayoutPanelArrowHoverBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowHoverBackground = new System.Windows.Forms.Label();
            this.buttonColorsDefaultDarkMode = new System.Windows.Forms.Button();
            this.tableLayoutPanelTitleDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTitleDarkMode = new System.Windows.Forms.PictureBox();
            this.labelTitleDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorTitleDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.labelBackgroundDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tableLayoutPanelGeneral.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
            this.tableLayoutPanelFolder.SuspendLayout();
            this.tableLayoutPanelChangeFolder.SuspendLayout();
            this.groupBoxUSB.SuspendLayout();
            this.tableLayoutPanelUSB.SuspendLayout();
            this.tableLayoutPanelRelativeFolderOpenAssembly.SuspendLayout();
            this.groupBoxAutostart.SuspendLayout();
            this.tableLayoutPanelAutostart.SuspendLayout();
            this.groupBoxHotkey.SuspendLayout();
            this.tableLayoutPanelHotkey.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.tableLayoutPanelLanguage.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.tableLayoutPanelAdvanced.SuspendLayout();
            this.groupBoxClick.SuspendLayout();
            this.tableLayoutPanelClick.SuspendLayout();
            this.groupBoxSizeAndLocation.SuspendLayout();
            this.tableLayoutPanelSizeAndLocation.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeInPercentage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuHeight)).BeginInit();
            this.tableLayoutPanelMaxMenuWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).BeginInit();
            this.groupBoxStaysOpen.SuspendLayout();
            this.tableLayoutPanelStaysOpen.SuspendLayout();
            this.tableLayoutPanelTimeUntilCloses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClose)).BeginInit();
            this.groupBoxOpenSubmenus.SuspendLayout();
            this.tableLayoutPanelTimeUntilOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilOpens)).BeginInit();
            this.tabPageCustomize.SuspendLayout();
            this.tableLayoutPanelCustomize.SuspendLayout();
            this.groupBoxColorsLightMode.SuspendLayout();
            this.tableLayoutPanelColorsAndDefault.SuspendLayout();
            this.tableLayoutPanelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcons)).BeginInit();
            this.tableLayoutPanelBackgroundBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundBorder)).BeginInit();
            this.tableLayoutPanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.tableLayoutPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.tableLayoutPanelArrowHoverBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackground)).BeginInit();
            this.tableLayoutPanelArrowHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHover)).BeginInit();
            this.tableLayoutPanelArrowClickBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackground)).BeginInit();
            this.tableLayoutPanelArrowClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClick)).BeginInit();
            this.tableLayoutPanelArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).BeginInit();
            this.tableLayoutPanelSliderArrowsAndTrackHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHover)).BeginInit();
            this.tableLayoutPanelSliderHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHover)).BeginInit();
            this.tableLayoutPanelSliderDragging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDragging)).BeginInit();
            this.tableLayoutPanelSlider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).BeginInit();
            this.tableLayoutPanelScrollbarBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackground)).BeginInit();
            this.tableLayoutPanelWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.tableLayoutPanelSelectedItemBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorder)).BeginInit();
            this.tableLayoutPanelSelectedItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItem)).BeginInit();
            this.tableLayoutPanelOpenFolderBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorder)).BeginInit();
            this.tableLayoutPanelOpenFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).BeginInit();
            this.tableLayoutPanelSearchField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchField)).BeginInit();
            this.groupBoxColorsDarkMode.SuspendLayout();
            this.tableLayoutPanelDarkMode.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconsDarkMode)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundBorderDarkMode)).BeginInit();
            this.tableLayoutPanelSearchFieldDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFieldDarkMode)).BeginInit();
            this.tableLayoutPanelOpenFolderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderDarkMode)).BeginInit();
            this.tableLayoutPanelOpenFolderBorderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorderDarkMode)).BeginInit();
            this.tableLayoutPanelSelectedItemDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorBoxSelectedItemDarkMode)).BeginInit();
            this.tableLayoutPanelSelectedItemBorderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorderDarkMode)).BeginInit();
            this.tableLayoutPanelWarningDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningDarkMode)).BeginInit();
            this.tableLayoutPanelScrollbarBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanelSliderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDarkMode)).BeginInit();
            this.tableLayoutPanelSliderDraggingDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDraggingDarkMode)).BeginInit();
            this.tableLayoutPanelSliderHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHoverDarkMode)).BeginInit();
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHoverDarkMode)).BeginInit();
            this.tableLayoutPanelArrowDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDarkMode)).BeginInit();
            this.tableLayoutPanelArrowClickDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickDarkMode)).BeginInit();
            this.tableLayoutPanelArrowClickBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanelArrowHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverDarkMode)).BeginInit();
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanelTitleDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleDarkMode)).BeginInit();
            this.tableLayoutPanelBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottom, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(978, 1160);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageAdvanced);
            this.tabControl.Controls.Add(this.tabPageCustomize);
            this.tabControl.Location = new System.Drawing.Point(14, 7);
            this.tabControl.Margin = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(10, 10);
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(950, 1080);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(10, 65);
            this.tabPageGeneral.Margin = new System.Windows.Forms.Padding(7);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(7);
            this.tabPageGeneral.Size = new System.Drawing.Size(930, 1005);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "tabPageGeneral";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.AutoSize = true;
            this.tableLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelGeneral.ColumnCount = 1;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxFolder, 0, 0);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxUSB, 0, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxAutostart, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxHotkey, 0, 3);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxLanguage, 0, 4);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanelGeneral.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 5;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(916, 991);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.AutoSize = true;
            this.groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFolder.Controls.Add(this.tableLayoutPanelFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(7, 7);
            this.groupBoxFolder.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxFolder.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxFolder.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Padding = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.groupBoxFolder.Size = new System.Drawing.Size(900, 290);
            this.groupBoxFolder.TabIndex = 0;
            this.groupBoxFolder.TabStop = false;
            this.groupBoxFolder.Text = "groupBoxFolder";
            // 
            // tableLayoutPanelFolder
            // 
            this.tableLayoutPanelFolder.AutoSize = true;
            this.tableLayoutPanelFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFolder.ColumnCount = 1;
            this.tableLayoutPanelFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFolder.Controls.Add(this.checkBoxPossibilityToSelectFolderByWindowsContextMenu, 0, 3);
            this.tableLayoutPanelFolder.Controls.Add(this.textBoxFolder, 0, 0);
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelChangeFolder, 0, 1);
            this.tableLayoutPanelFolder.Controls.Add(this.checkBoxUseIconFromRootFolder, 0, 2);
            this.tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolder.Location = new System.Drawing.Point(7, 50);
            this.tableLayoutPanelFolder.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            this.tableLayoutPanelFolder.RowCount = 4;
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.Size = new System.Drawing.Size(886, 226);
            this.tableLayoutPanelFolder.TabIndex = 0;
            // 
            // checkBoxPossibilityToSelectFolderByWindowsContextMenu
            // 
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.AutoSize = true;
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.Location = new System.Drawing.Point(7, 178);
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.Name = "checkBoxPossibilityToSelectFolderByWindowsContextMenu";
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.Size = new System.Drawing.Size(637, 41);
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.TabIndex = 2;
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.Text = "PossibilityToSelectFolderByWindowsContextMenu";
            this.checkBoxPossibilityToSelectFolderByWindowsContextMenu.UseVisualStyleBackColor = true;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.BackColor = System.Drawing.Color.White;
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFolder.Location = new System.Drawing.Point(14, 7);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(1420, 36);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TabStop = false;
            // 
            // tableLayoutPanelChangeFolder
            // 
            this.tableLayoutPanelChangeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelChangeFolder.AutoSize = true;
            this.tableLayoutPanelChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelChangeFolder.ColumnCount = 2;
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChangeFolder.Controls.Add(this.buttonChangeFolder, 0, 0);
            this.tableLayoutPanelChangeFolder.Controls.Add(this.buttonOpenFolder, 1, 0);
            this.tableLayoutPanelChangeFolder.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanelChangeFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelChangeFolder.Name = "tableLayoutPanelChangeFolder";
            this.tableLayoutPanelChangeFolder.RowCount = 1;
            this.tableLayoutPanelChangeFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(1448, 66);
            this.tableLayoutPanelChangeFolder.TabIndex = 0;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChangeFolder.AutoSize = true;
            this.buttonChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeFolder.Location = new System.Drawing.Point(4, 7);
            this.buttonChangeFolder.Margin = new System.Windows.Forms.Padding(4, 7, 7, 7);
            this.buttonChangeFolder.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(200, 52);
            this.buttonChangeFolder.TabIndex = 0;
            this.buttonChangeFolder.Text = "Change Folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(218, 7);
            this.buttonOpenFolder.Margin = new System.Windows.Forms.Padding(7);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(200, 52);
            this.buttonOpenFolder.TabIndex = 1;
            this.buttonOpenFolder.Text = "Open Folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // checkBoxUseIconFromRootFolder
            // 
            this.checkBoxUseIconFromRootFolder.AutoSize = true;
            this.checkBoxUseIconFromRootFolder.Location = new System.Drawing.Point(7, 123);
            this.checkBoxUseIconFromRootFolder.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxUseIconFromRootFolder.Name = "checkBoxUseIconFromRootFolder";
            this.checkBoxUseIconFromRootFolder.Size = new System.Drawing.Size(444, 41);
            this.checkBoxUseIconFromRootFolder.TabIndex = 1;
            this.checkBoxUseIconFromRootFolder.Text = "checkBoxUseIconFromRootFolder";
            this.checkBoxUseIconFromRootFolder.UseVisualStyleBackColor = true;
            // 
            // groupBoxUSB
            // 
            this.groupBoxUSB.AutoSize = true;
            this.groupBoxUSB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxUSB.Controls.Add(this.tableLayoutPanelUSB);
            this.groupBoxUSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUSB.Location = new System.Drawing.Point(7, 311);
            this.groupBoxUSB.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxUSB.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxUSB.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxUSB.Name = "groupBoxUSB";
            this.groupBoxUSB.Padding = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.groupBoxUSB.Size = new System.Drawing.Size(900, 185);
            this.groupBoxUSB.TabIndex = 2;
            this.groupBoxUSB.TabStop = false;
            this.groupBoxUSB.Text = "groupBoxUSB";
            // 
            // tableLayoutPanelUSB
            // 
            this.tableLayoutPanelUSB.AutoSize = true;
            this.tableLayoutPanelUSB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelUSB.ColumnCount = 1;
            this.tableLayoutPanelUSB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelUSB.Controls.Add(this.tableLayoutPanelRelativeFolderOpenAssembly, 0, 0);
            this.tableLayoutPanelUSB.Controls.Add(this.checkBoxStoreConfigAtAssemblyLocation, 0, 1);
            this.tableLayoutPanelUSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUSB.Location = new System.Drawing.Point(7, 50);
            this.tableLayoutPanelUSB.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelUSB.Name = "tableLayoutPanelUSB";
            this.tableLayoutPanelUSB.RowCount = 2;
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.Size = new System.Drawing.Size(886, 121);
            this.tableLayoutPanelUSB.TabIndex = 3;
            // 
            // tableLayoutPanelRelativeFolderOpenAssembly
            // 
            this.tableLayoutPanelRelativeFolderOpenAssembly.AutoSize = true;
            this.tableLayoutPanelRelativeFolderOpenAssembly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnCount = 3;
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(this.buttonChangeRelativeFolder, 0, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(this.buttonOpenAssemblyLocation, 2, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRelativeFolderOpenAssembly.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Name = "tableLayoutPanelRelativeFolderOpenAssembly";
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowCount = 1;
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRelativeFolderOpenAssembly.Size = new System.Drawing.Size(886, 66);
            this.tableLayoutPanelRelativeFolderOpenAssembly.TabIndex = 1;
            // 
            // buttonChangeRelativeFolder
            // 
            this.buttonChangeRelativeFolder.AutoSize = true;
            this.buttonChangeRelativeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeRelativeFolder.Location = new System.Drawing.Point(4, 7);
            this.buttonChangeRelativeFolder.Margin = new System.Windows.Forms.Padding(4, 7, 7, 7);
            this.buttonChangeRelativeFolder.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonChangeRelativeFolder.Name = "buttonChangeRelativeFolder";
            this.buttonChangeRelativeFolder.Size = new System.Drawing.Size(286, 52);
            this.buttonChangeRelativeFolder.TabIndex = 0;
            this.buttonChangeRelativeFolder.Text = "ChangeRelativeFolder";
            this.buttonChangeRelativeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeRelativeFolder.Click += new System.EventHandler(this.ButtonChangeRelativeFolder_Click);
            // 
            // buttonOpenAssemblyLocation
            // 
            this.buttonOpenAssemblyLocation.AutoSize = true;
            this.buttonOpenAssemblyLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenAssemblyLocation.Location = new System.Drawing.Point(493, 7);
            this.buttonOpenAssemblyLocation.Margin = new System.Windows.Forms.Padding(7);
            this.buttonOpenAssemblyLocation.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonOpenAssemblyLocation.Name = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.Size = new System.Drawing.Size(386, 52);
            this.buttonOpenAssemblyLocation.TabIndex = 2;
            this.buttonOpenAssemblyLocation.Text = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.UseVisualStyleBackColor = true;
            this.buttonOpenAssemblyLocation.Click += new System.EventHandler(this.ButtonOpenAssemblyLocation_Click);
            // 
            // checkBoxStoreConfigAtAssemblyLocation
            // 
            this.checkBoxStoreConfigAtAssemblyLocation.AutoSize = true;
            this.checkBoxStoreConfigAtAssemblyLocation.Location = new System.Drawing.Point(7, 73);
            this.checkBoxStoreConfigAtAssemblyLocation.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxStoreConfigAtAssemblyLocation.Name = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.Size = new System.Drawing.Size(538, 41);
            this.checkBoxStoreConfigAtAssemblyLocation.TabIndex = 1;
            this.checkBoxStoreConfigAtAssemblyLocation.Text = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutostart
            // 
            this.groupBoxAutostart.AutoSize = true;
            this.groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAutostart.Controls.Add(this.tableLayoutPanelAutostart);
            this.groupBoxAutostart.Location = new System.Drawing.Point(7, 510);
            this.groupBoxAutostart.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxAutostart.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxAutostart.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxAutostart.Name = "groupBoxAutostart";
            this.groupBoxAutostart.Padding = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.groupBoxAutostart.Size = new System.Drawing.Size(900, 119);
            this.groupBoxAutostart.TabIndex = 0;
            this.groupBoxAutostart.TabStop = false;
            this.groupBoxAutostart.Text = "groupBoxAutostart";
            // 
            // tableLayoutPanelAutostart
            // 
            this.tableLayoutPanelAutostart.AutoSize = true;
            this.tableLayoutPanelAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAutostart.ColumnCount = 1;
            this.tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Controls.Add(this.checkBoxAutostart, 0, 0);
            this.tableLayoutPanelAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAutostart.Location = new System.Drawing.Point(7, 50);
            this.tableLayoutPanelAutostart.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            this.tableLayoutPanelAutostart.RowCount = 1;
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Size = new System.Drawing.Size(886, 55);
            this.tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutostart.Location = new System.Drawing.Point(7, 7);
            this.checkBoxAutostart.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(872, 41);
            this.checkBoxAutostart.TabIndex = 0;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            this.groupBoxHotkey.AutoSize = true;
            this.groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHotkey.Controls.Add(this.tableLayoutPanelHotkey);
            this.groupBoxHotkey.Location = new System.Drawing.Point(7, 643);
            this.groupBoxHotkey.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxHotkey.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxHotkey.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxHotkey.Name = "groupBoxHotkey";
            this.groupBoxHotkey.Padding = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.groupBoxHotkey.Size = new System.Drawing.Size(900, 130);
            this.groupBoxHotkey.TabIndex = 0;
            this.groupBoxHotkey.TabStop = false;
            this.groupBoxHotkey.Text = "groupBoxHotkey";
            // 
            // tableLayoutPanelHotkey
            // 
            this.tableLayoutPanelHotkey.AutoSize = true;
            this.tableLayoutPanelHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelHotkey.ColumnCount = 3;
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHotkey.Controls.Add(this.textBoxHotkeyPlaceholder, 1, 0);
            this.tableLayoutPanelHotkey.Controls.Add(this.buttonHotkeyDefault, 2, 0);
            this.tableLayoutPanelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHotkey.Location = new System.Drawing.Point(7, 50);
            this.tableLayoutPanelHotkey.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelHotkey.Name = "tableLayoutPanelHotkey";
            this.tableLayoutPanelHotkey.RowCount = 1;
            this.tableLayoutPanelHotkey.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHotkey.Size = new System.Drawing.Size(886, 66);
            this.tableLayoutPanelHotkey.TabIndex = 0;
            // 
            // textBoxHotkeyPlaceholder
            // 
            this.textBoxHotkeyPlaceholder.Location = new System.Drawing.Point(7, 7);
            this.textBoxHotkeyPlaceholder.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxHotkeyPlaceholder.Name = "textBoxHotkeyPlaceholder";
            this.textBoxHotkeyPlaceholder.Size = new System.Drawing.Size(231, 43);
            this.textBoxHotkeyPlaceholder.TabIndex = 0;
            // 
            // buttonHotkeyDefault
            // 
            this.buttonHotkeyDefault.AutoSize = true;
            this.buttonHotkeyDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHotkeyDefault.Location = new System.Drawing.Point(602, 7);
            this.buttonHotkeyDefault.Margin = new System.Windows.Forms.Padding(7);
            this.buttonHotkeyDefault.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonHotkeyDefault.Name = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.Size = new System.Drawing.Size(277, 52);
            this.buttonHotkeyDefault.TabIndex = 0;
            this.buttonHotkeyDefault.Text = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.UseVisualStyleBackColor = true;
            this.buttonHotkeyDefault.Click += new System.EventHandler(this.ButtonHotkeyDefault_Click);
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.AutoSize = true;
            this.groupBoxLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLanguage.Controls.Add(this.tableLayoutPanelLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(7, 787);
            this.groupBoxLanguage.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxLanguage.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxLanguage.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Padding = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.groupBoxLanguage.Size = new System.Drawing.Size(900, 123);
            this.groupBoxLanguage.TabIndex = 0;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "groupBoxLanguage";
            // 
            // tableLayoutPanelLanguage
            // 
            this.tableLayoutPanelLanguage.AutoSize = true;
            this.tableLayoutPanelLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelLanguage.ColumnCount = 2;
            this.tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLanguage.Controls.Add(this.comboBoxLanguage, 0, 0);
            this.tableLayoutPanelLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLanguage.Location = new System.Drawing.Point(7, 50);
            this.tableLayoutPanelLanguage.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelLanguage.Name = "tableLayoutPanelLanguage";
            this.tableLayoutPanelLanguage.RowCount = 1;
            this.tableLayoutPanelLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLanguage.Size = new System.Drawing.Size(886, 59);
            this.tableLayoutPanelLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(7, 7);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(7);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(445, 45);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanelAdvanced);
            this.tabPageAdvanced.Location = new System.Drawing.Point(10, 65);
            this.tabPageAdvanced.Margin = new System.Windows.Forms.Padding(7);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(7);
            this.tabPageAdvanced.Size = new System.Drawing.Size(930, 1015);
            this.tabPageAdvanced.TabIndex = 0;
            this.tabPageAdvanced.Text = "tabPageAdvanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAdvanced
            // 
            this.tableLayoutPanelAdvanced.AutoSize = true;
            this.tableLayoutPanelAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAdvanced.ColumnCount = 1;
            this.tableLayoutPanelAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxClick, 0, 0);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxSizeAndLocation, 0, 1);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxStaysOpen, 0, 2);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxOpenSubmenus, 0, 3);
            this.tableLayoutPanelAdvanced.Controls.Add(this.buttonAdvancedDefault, 0, 4);
            this.tableLayoutPanelAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAdvanced.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanelAdvanced.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelAdvanced.Name = "tableLayoutPanelAdvanced";
            this.tableLayoutPanelAdvanced.RowCount = 5;
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.Size = new System.Drawing.Size(916, 1001);
            this.tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxClick
            // 
            this.groupBoxClick.AutoSize = true;
            this.groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxClick.Controls.Add(this.tableLayoutPanelClick);
            this.groupBoxClick.Location = new System.Drawing.Point(7, 7);
            this.groupBoxClick.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxClick.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxClick.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxClick.Name = "groupBoxClick";
            this.groupBoxClick.Padding = new System.Windows.Forms.Padding(7);
            this.groupBoxClick.Size = new System.Drawing.Size(900, 105);
            this.groupBoxClick.TabIndex = 0;
            this.groupBoxClick.TabStop = false;
            this.groupBoxClick.Text = "groupBoxClick";
            // 
            // tableLayoutPanelClick
            // 
            this.tableLayoutPanelClick.AutoSize = true;
            this.tableLayoutPanelClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelClick.ColumnCount = 1;
            this.tableLayoutPanelClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxOpenItemWithOneClick, 0, 0);
            this.tableLayoutPanelClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClick.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelClick.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelClick.Name = "tableLayoutPanelClick";
            this.tableLayoutPanelClick.RowCount = 1;
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClick.Size = new System.Drawing.Size(886, 55);
            this.tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(7, 7);
            this.checkBoxOpenItemWithOneClick.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(872, 41);
            this.checkBoxOpenItemWithOneClick.TabIndex = 0;
            this.checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // groupBoxSizeAndLocation
            // 
            this.groupBoxSizeAndLocation.AutoSize = true;
            this.groupBoxSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSizeAndLocation.Controls.Add(this.tableLayoutPanelSizeAndLocation);
            this.groupBoxSizeAndLocation.Location = new System.Drawing.Point(7, 126);
            this.groupBoxSizeAndLocation.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxSizeAndLocation.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxSizeAndLocation.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxSizeAndLocation.Name = "groupBoxSizeAndLocation";
            this.groupBoxSizeAndLocation.Padding = new System.Windows.Forms.Padding(7, 7, 7, 14);
            this.groupBoxSizeAndLocation.Size = new System.Drawing.Size(900, 283);
            this.groupBoxSizeAndLocation.TabIndex = 0;
            this.groupBoxSizeAndLocation.TabStop = false;
            this.groupBoxSizeAndLocation.Text = "groupBoxSizeAndLocation";
            // 
            // tableLayoutPanelSizeAndLocation
            // 
            this.tableLayoutPanelSizeAndLocation.AutoSize = true;
            this.tableLayoutPanelSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSizeAndLocation.ColumnCount = 1;
            this.tableLayoutPanelSizeAndLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanelMaxMenuWidth, 0, 1);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.checkBoxAppearAtMouseLocation, 0, 3);
            this.tableLayoutPanelSizeAndLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSizeAndLocation.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelSizeAndLocation.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSizeAndLocation.Name = "tableLayoutPanelSizeAndLocation";
            this.tableLayoutPanelSizeAndLocation.RowCount = 4;
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.Size = new System.Drawing.Size(886, 226);
            this.tableLayoutPanelSizeAndLocation.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownSizeInPercentage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSize, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(886, 57);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numericUpDownSizeInPercentage
            // 
            this.numericUpDownSizeInPercentage.Location = new System.Drawing.Point(7, 7);
            this.numericUpDownSizeInPercentage.Margin = new System.Windows.Forms.Padding(7);
            this.numericUpDownSizeInPercentage.Name = "numericUpDownSizeInPercentage";
            this.numericUpDownSizeInPercentage.Size = new System.Drawing.Size(124, 43);
            this.numericUpDownSizeInPercentage.TabIndex = 1;
            this.numericUpDownSizeInPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownSizeInPercentage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSize
            // 
            this.labelSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(145, 10);
            this.labelSize.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSize.MaximumSize = new System.Drawing.Size(742, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(275, 37);
            this.labelSize.TabIndex = 0;
            this.labelSize.Text = "labelSizeInPercentage";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownMenuHeight, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxMenuHeight, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 114);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownMenuHeight
            // 
            this.numericUpDownMenuHeight.Location = new System.Drawing.Point(7, 7);
            this.numericUpDownMenuHeight.Margin = new System.Windows.Forms.Padding(7);
            this.numericUpDownMenuHeight.Name = "numericUpDownMenuHeight";
            this.numericUpDownMenuHeight.Size = new System.Drawing.Size(124, 43);
            this.numericUpDownMenuHeight.TabIndex = 1;
            this.numericUpDownMenuHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownMenuHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelMaxMenuHeight
            // 
            this.labelMaxMenuHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaxMenuHeight.AutoSize = true;
            this.labelMaxMenuHeight.Location = new System.Drawing.Point(145, 10);
            this.labelMaxMenuHeight.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelMaxMenuHeight.MaximumSize = new System.Drawing.Size(742, 0);
            this.labelMaxMenuHeight.Name = "labelMaxMenuHeight";
            this.labelMaxMenuHeight.Size = new System.Drawing.Size(273, 37);
            this.labelMaxMenuHeight.TabIndex = 0;
            this.labelMaxMenuHeight.Text = "labelMaxMenuHeight";
            // 
            // tableLayoutPanelMaxMenuWidth
            // 
            this.tableLayoutPanelMaxMenuWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMaxMenuWidth.AutoSize = true;
            this.tableLayoutPanelMaxMenuWidth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMaxMenuWidth.ColumnCount = 2;
            this.tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMaxMenuWidth.Controls.Add(this.numericUpDownMenuWidth, 0, 0);
            this.tableLayoutPanelMaxMenuWidth.Controls.Add(this.labelMaxMenuWidth, 1, 0);
            this.tableLayoutPanelMaxMenuWidth.Location = new System.Drawing.Point(0, 57);
            this.tableLayoutPanelMaxMenuWidth.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMaxMenuWidth.Name = "tableLayoutPanelMaxMenuWidth";
            this.tableLayoutPanelMaxMenuWidth.RowCount = 1;
            this.tableLayoutPanelMaxMenuWidth.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMaxMenuWidth.Size = new System.Drawing.Size(886, 57);
            this.tableLayoutPanelMaxMenuWidth.TabIndex = 0;
            // 
            // numericUpDownMenuWidth
            // 
            this.numericUpDownMenuWidth.Location = new System.Drawing.Point(7, 7);
            this.numericUpDownMenuWidth.Margin = new System.Windows.Forms.Padding(7);
            this.numericUpDownMenuWidth.Name = "numericUpDownMenuWidth";
            this.numericUpDownMenuWidth.Size = new System.Drawing.Size(124, 43);
            this.numericUpDownMenuWidth.TabIndex = 1;
            this.numericUpDownMenuWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownMenuWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelMaxMenuWidth
            // 
            this.labelMaxMenuWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaxMenuWidth.AutoSize = true;
            this.labelMaxMenuWidth.Location = new System.Drawing.Point(145, 10);
            this.labelMaxMenuWidth.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelMaxMenuWidth.MaximumSize = new System.Drawing.Size(742, 0);
            this.labelMaxMenuWidth.Name = "labelMaxMenuWidth";
            this.labelMaxMenuWidth.Size = new System.Drawing.Size(265, 37);
            this.labelMaxMenuWidth.TabIndex = 0;
            this.labelMaxMenuWidth.Text = "labelMaxMenuWidth";
            // 
            // checkBoxAppearAtMouseLocation
            // 
            this.checkBoxAppearAtMouseLocation.AutoSize = true;
            this.checkBoxAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAppearAtMouseLocation.Location = new System.Drawing.Point(7, 178);
            this.checkBoxAppearAtMouseLocation.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxAppearAtMouseLocation.Name = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.Size = new System.Drawing.Size(872, 41);
            this.checkBoxAppearAtMouseLocation.TabIndex = 0;
            this.checkBoxAppearAtMouseLocation.Text = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxStaysOpen
            // 
            this.groupBoxStaysOpen.AutoSize = true;
            this.groupBoxStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStaysOpen.Controls.Add(this.tableLayoutPanelStaysOpen);
            this.groupBoxStaysOpen.Location = new System.Drawing.Point(7, 423);
            this.groupBoxStaysOpen.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxStaysOpen.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxStaysOpen.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            this.groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(7, 7, 7, 14);
            this.groupBoxStaysOpen.Size = new System.Drawing.Size(900, 224);
            this.groupBoxStaysOpen.TabIndex = 0;
            this.groupBoxStaysOpen.TabStop = false;
            this.groupBoxStaysOpen.Text = "groupBoxStaysOpen";
            // 
            // tableLayoutPanelStaysOpen
            // 
            this.tableLayoutPanelStaysOpen.AutoSize = true;
            this.tableLayoutPanelStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelStaysOpen.ColumnCount = 1;
            this.tableLayoutPanelStaysOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenItemClicked, 0, 0);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenFocusLost, 0, 1);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.tableLayoutPanelTimeUntilCloses, 0, 2);
            this.tableLayoutPanelStaysOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStaysOpen.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelStaysOpen.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelStaysOpen.Name = "tableLayoutPanelStaysOpen";
            this.tableLayoutPanelStaysOpen.RowCount = 3;
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(886, 167);
            this.tableLayoutPanelStaysOpen.TabIndex = 0;
            // 
            // checkBoxStayOpenWhenItemClicked
            // 
            this.checkBoxStayOpenWhenItemClicked.AutoSize = true;
            this.checkBoxStayOpenWhenItemClicked.Checked = true;
            this.checkBoxStayOpenWhenItemClicked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenItemClicked.Location = new System.Drawing.Point(7, 7);
            this.checkBoxStayOpenWhenItemClicked.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxStayOpenWhenItemClicked.Name = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.Size = new System.Drawing.Size(480, 41);
            this.checkBoxStayOpenWhenItemClicked.TabIndex = 0;
            this.checkBoxStayOpenWhenItemClicked.Text = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.UseVisualStyleBackColor = true;
            // 
            // checkBoxStayOpenWhenFocusLost
            // 
            this.checkBoxStayOpenWhenFocusLost.AutoSize = true;
            this.checkBoxStayOpenWhenFocusLost.Checked = true;
            this.checkBoxStayOpenWhenFocusLost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenFocusLost.Location = new System.Drawing.Point(7, 62);
            this.checkBoxStayOpenWhenFocusLost.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxStayOpenWhenFocusLost.Name = "checkBoxStayOpenWhenFocusLost";
            this.checkBoxStayOpenWhenFocusLost.Size = new System.Drawing.Size(457, 41);
            this.checkBoxStayOpenWhenFocusLost.TabIndex = 0;
            this.checkBoxStayOpenWhenFocusLost.Text = "checkBoxStayOpenWhenFocusLost";
            this.checkBoxStayOpenWhenFocusLost.UseVisualStyleBackColor = true;
            this.checkBoxStayOpenWhenFocusLost.CheckedChanged += new System.EventHandler(this.CheckBoxStayOpenWhenFocusLost_CheckedChanged);
            // 
            // tableLayoutPanelTimeUntilCloses
            // 
            this.tableLayoutPanelTimeUntilCloses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelTimeUntilCloses.AutoSize = true;
            this.tableLayoutPanelTimeUntilCloses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTimeUntilCloses.ColumnCount = 2;
            this.tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTimeUntilCloses.Controls.Add(this.labelTimeUntilCloses, 1, 0);
            this.tableLayoutPanelTimeUntilCloses.Controls.Add(this.numericUpDownTimeUntilClose, 0, 0);
            this.tableLayoutPanelTimeUntilCloses.Location = new System.Drawing.Point(0, 110);
            this.tableLayoutPanelTimeUntilCloses.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTimeUntilCloses.Name = "tableLayoutPanelTimeUntilCloses";
            this.tableLayoutPanelTimeUntilCloses.RowCount = 1;
            this.tableLayoutPanelTimeUntilCloses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilCloses.Size = new System.Drawing.Size(886, 57);
            this.tableLayoutPanelTimeUntilCloses.TabIndex = 0;
            // 
            // labelTimeUntilCloses
            // 
            this.labelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilCloses.AutoSize = true;
            this.labelTimeUntilCloses.Location = new System.Drawing.Point(145, 10);
            this.labelTimeUntilCloses.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTimeUntilCloses.MaximumSize = new System.Drawing.Size(742, 0);
            this.labelTimeUntilCloses.Name = "labelTimeUntilCloses";
            this.labelTimeUntilCloses.Size = new System.Drawing.Size(266, 37);
            this.labelTimeUntilCloses.TabIndex = 0;
            this.labelTimeUntilCloses.Text = "labelTimeUntilCloses";
            // 
            // numericUpDownTimeUntilClose
            // 
            this.numericUpDownTimeUntilClose.Location = new System.Drawing.Point(7, 7);
            this.numericUpDownTimeUntilClose.Margin = new System.Windows.Forms.Padding(7);
            this.numericUpDownTimeUntilClose.Name = "numericUpDownTimeUntilClose";
            this.numericUpDownTimeUntilClose.Size = new System.Drawing.Size(124, 43);
            this.numericUpDownTimeUntilClose.TabIndex = 1;
            this.numericUpDownTimeUntilClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownTimeUntilClose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // groupBoxOpenSubmenus
            // 
            this.groupBoxOpenSubmenus.AutoSize = true;
            this.groupBoxOpenSubmenus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOpenSubmenus.Controls.Add(this.tableLayoutPanelTimeUntilOpen);
            this.groupBoxOpenSubmenus.Location = new System.Drawing.Point(7, 661);
            this.groupBoxOpenSubmenus.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxOpenSubmenus.MaximumSize = new System.Drawing.Size(900, 0);
            this.groupBoxOpenSubmenus.MinimumSize = new System.Drawing.Size(900, 0);
            this.groupBoxOpenSubmenus.Name = "groupBoxOpenSubmenus";
            this.groupBoxOpenSubmenus.Padding = new System.Windows.Forms.Padding(7, 7, 7, 14);
            this.groupBoxOpenSubmenus.Size = new System.Drawing.Size(900, 114);
            this.groupBoxOpenSubmenus.TabIndex = 0;
            this.groupBoxOpenSubmenus.TabStop = false;
            this.groupBoxOpenSubmenus.Text = "groupBoxOpenSubmenus";
            // 
            // tableLayoutPanelTimeUntilOpen
            // 
            this.tableLayoutPanelTimeUntilOpen.AutoSize = true;
            this.tableLayoutPanelTimeUntilOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTimeUntilOpen.ColumnCount = 2;
            this.tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilOpen.Controls.Add(this.numericUpDownTimeUntilOpens, 0, 0);
            this.tableLayoutPanelTimeUntilOpen.Controls.Add(this.labelTimeUntilOpen, 1, 0);
            this.tableLayoutPanelTimeUntilOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTimeUntilOpen.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelTimeUntilOpen.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelTimeUntilOpen.Name = "tableLayoutPanelTimeUntilOpen";
            this.tableLayoutPanelTimeUntilOpen.RowCount = 1;
            this.tableLayoutPanelTimeUntilOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilOpen.Size = new System.Drawing.Size(886, 57);
            this.tableLayoutPanelTimeUntilOpen.TabIndex = 0;
            // 
            // numericUpDownTimeUntilOpens
            // 
            this.numericUpDownTimeUntilOpens.Location = new System.Drawing.Point(7, 7);
            this.numericUpDownTimeUntilOpens.Margin = new System.Windows.Forms.Padding(7);
            this.numericUpDownTimeUntilOpens.Name = "numericUpDownTimeUntilOpens";
            this.numericUpDownTimeUntilOpens.Size = new System.Drawing.Size(124, 43);
            this.numericUpDownTimeUntilOpens.TabIndex = 2;
            this.numericUpDownTimeUntilOpens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownTimeUntilOpens.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelTimeUntilOpen
            // 
            this.labelTimeUntilOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilOpen.AutoSize = true;
            this.labelTimeUntilOpen.Location = new System.Drawing.Point(145, 10);
            this.labelTimeUntilOpen.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTimeUntilOpen.MaximumSize = new System.Drawing.Size(742, 0);
            this.labelTimeUntilOpen.Name = "labelTimeUntilOpen";
            this.labelTimeUntilOpen.Size = new System.Drawing.Size(255, 37);
            this.labelTimeUntilOpen.TabIndex = 0;
            this.labelTimeUntilOpen.Text = "labelTimeUntilOpen";
            // 
            // buttonAdvancedDefault
            // 
            this.buttonAdvancedDefault.AutoSize = true;
            this.buttonAdvancedDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdvancedDefault.Location = new System.Drawing.Point(20, 802);
            this.buttonAdvancedDefault.Margin = new System.Windows.Forms.Padding(20, 20, 7, 20);
            this.buttonAdvancedDefault.MinimumSize = new System.Drawing.Size(169, 56);
            this.buttonAdvancedDefault.Name = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.Size = new System.Drawing.Size(310, 56);
            this.buttonAdvancedDefault.TabIndex = 0;
            this.buttonAdvancedDefault.Text = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.UseVisualStyleBackColor = true;
            this.buttonAdvancedDefault.Click += new System.EventHandler(this.ButtonAdvancedDefault_Click);
            // 
            // tabPageCustomize
            // 
            this.tabPageCustomize.AutoScroll = true;
            this.tabPageCustomize.Controls.Add(this.tableLayoutPanelCustomize);
            this.tabPageCustomize.Location = new System.Drawing.Point(10, 65);
            this.tabPageCustomize.Margin = new System.Windows.Forms.Padding(7);
            this.tabPageCustomize.Name = "tabPageCustomize";
            this.tabPageCustomize.Padding = new System.Windows.Forms.Padding(7);
            this.tabPageCustomize.Size = new System.Drawing.Size(930, 1015);
            this.tabPageCustomize.TabIndex = 0;
            this.tabPageCustomize.Text = "tabPageCustomize";
            this.tabPageCustomize.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCustomize
            // 
            this.tableLayoutPanelCustomize.AutoSize = true;
            this.tableLayoutPanelCustomize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCustomize.ColumnCount = 1;
            this.tableLayoutPanelCustomize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColorsLightMode, 0, 0);
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColorsDarkMode, 0, 1);
            this.tableLayoutPanelCustomize.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanelCustomize.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            this.tableLayoutPanelCustomize.RowCount = 2;
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.Size = new System.Drawing.Size(880, 2983);
            this.tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxColorsLightMode
            // 
            this.groupBoxColorsLightMode.AutoSize = true;
            this.groupBoxColorsLightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsLightMode.Controls.Add(this.tableLayoutPanelColorsAndDefault);
            this.groupBoxColorsLightMode.Location = new System.Drawing.Point(7, 7);
            this.groupBoxColorsLightMode.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxColorsLightMode.MaximumSize = new System.Drawing.Size(866, 0);
            this.groupBoxColorsLightMode.MinimumSize = new System.Drawing.Size(866, 0);
            this.groupBoxColorsLightMode.Name = "groupBoxColorsLightMode";
            this.groupBoxColorsLightMode.Padding = new System.Windows.Forms.Padding(7);
            this.groupBoxColorsLightMode.Size = new System.Drawing.Size(866, 1450);
            this.groupBoxColorsLightMode.TabIndex = 0;
            this.groupBoxColorsLightMode.TabStop = false;
            this.groupBoxColorsLightMode.Text = "groupBoxColorsLightMode";
            // 
            // tableLayoutPanelColorsAndDefault
            // 
            this.tableLayoutPanelColorsAndDefault.AutoSize = true;
            this.tableLayoutPanelColorsAndDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorsAndDefault.ColumnCount = 1;
            this.tableLayoutPanelColorsAndDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 999F));
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelIcons, 0, 2);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelBackgroundBorder, 0, 4);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelMenuLightMode, 0, 0);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelTitle, 0, 1);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelBackground, 0, 3);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.buttonColorsDefault, 0, 22);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowHoverBackground, 0, 21);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowHover, 0, 20);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowClickBackground, 0, 19);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowClick, 0, 18);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrow, 0, 17);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderArrowsAndTrackHover, 0, 16);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderHover, 0, 15);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderDragging, 0, 14);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSlider, 0, 13);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelScrollbarBackground, 0, 12);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelScrollbarLightMode, 0, 11);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelWarning, 0, 10);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSelectedItemBorder, 0, 9);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSelectedItem, 0, 8);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelOpenFolderBorder, 0, 7);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelOpenFolder, 0, 6);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSearchField, 0, 5);
            this.tableLayoutPanelColorsAndDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColorsAndDefault.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelColorsAndDefault.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelColorsAndDefault.Name = "tableLayoutPanelColorsAndDefault";
            this.tableLayoutPanelColorsAndDefault.RowCount = 23;
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.Size = new System.Drawing.Size(852, 1400);
            this.tableLayoutPanelColorsAndDefault.TabIndex = 0;
            // 
            // tableLayoutPanelIcons
            // 
            this.tableLayoutPanelIcons.AutoSize = true;
            this.tableLayoutPanelIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelIcons.ColumnCount = 3;
            this.tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelIcons.Controls.Add(this.pictureBoxIcons, 0, 0);
            this.tableLayoutPanelIcons.Controls.Add(this.textBoxColorIcons, 1, 0);
            this.tableLayoutPanelIcons.Controls.Add(this.labelIcons, 2, 0);
            this.tableLayoutPanelIcons.Location = new System.Drawing.Point(7, 107);
            this.tableLayoutPanelIcons.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelIcons.Name = "tableLayoutPanelIcons";
            this.tableLayoutPanelIcons.RowCount = 1;
            this.tableLayoutPanelIcons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelIcons.Size = new System.Drawing.Size(349, 49);
            this.tableLayoutPanelIcons.TabIndex = 2;
            // 
            // pictureBoxIcons
            // 
            this.pictureBoxIcons.BackColor = System.Drawing.Color.White;
            this.pictureBoxIcons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIcons.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIcons.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIcons.Name = "pictureBoxIcons";
            this.pictureBoxIcons.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxIcons.TabIndex = 1;
            this.pictureBoxIcons.TabStop = false;
            this.pictureBoxIcons.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorIcons
            // 
            this.textBoxColorIcons.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorIcons.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorIcons.MaxLength = 12;
            this.textBoxColorIcons.Name = "textBoxColorIcons";
            this.textBoxColorIcons.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorIcons.TabIndex = 2;
            this.textBoxColorIcons.Text = "#ffffff";
            this.textBoxColorIcons.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorIcons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorIcons.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelIcons
            // 
            this.labelIcons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIcons.AutoSize = true;
            this.labelIcons.Location = new System.Drawing.Point(206, 6);
            this.labelIcons.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelIcons.Name = "labelIcons";
            this.labelIcons.Size = new System.Drawing.Size(136, 37);
            this.labelIcons.TabIndex = 0;
            this.labelIcons.Text = "labelIcons";
            // 
            // tableLayoutPanelBackgroundBorder
            // 
            this.tableLayoutPanelBackgroundBorder.AutoSize = true;
            this.tableLayoutPanelBackgroundBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBackgroundBorder.ColumnCount = 3;
            this.tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackgroundBorder.Controls.Add(this.pictureBoxBackgroundBorder, 0, 0);
            this.tableLayoutPanelBackgroundBorder.Controls.Add(this.textBoxColorBackgroundBorder, 1, 0);
            this.tableLayoutPanelBackgroundBorder.Controls.Add(this.labelBackgroundBorder, 2, 0);
            this.tableLayoutPanelBackgroundBorder.Location = new System.Drawing.Point(7, 233);
            this.tableLayoutPanelBackgroundBorder.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelBackgroundBorder.Name = "tableLayoutPanelBackgroundBorder";
            this.tableLayoutPanelBackgroundBorder.RowCount = 1;
            this.tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelBackgroundBorder.Size = new System.Drawing.Size(508, 49);
            this.tableLayoutPanelBackgroundBorder.TabIndex = 2;
            // 
            // pictureBoxBackgroundBorder
            // 
            this.pictureBoxBackgroundBorder.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackgroundBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackgroundBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackgroundBorder.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackgroundBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackgroundBorder.Name = "pictureBoxBackgroundBorder";
            this.pictureBoxBackgroundBorder.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxBackgroundBorder.TabIndex = 1;
            this.pictureBoxBackgroundBorder.TabStop = false;
            this.pictureBoxBackgroundBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorBackgroundBorder
            // 
            this.textBoxColorBackgroundBorder.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorBackgroundBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundBorder.MaxLength = 12;
            this.textBoxColorBackgroundBorder.Name = "textBoxColorBackgroundBorder";
            this.textBoxColorBackgroundBorder.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorBackgroundBorder.TabIndex = 2;
            this.textBoxColorBackgroundBorder.Text = "#ffffff";
            this.textBoxColorBackgroundBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackgroundBorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackgroundBorder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelBackgroundBorder
            // 
            this.labelBackgroundBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackgroundBorder.AutoSize = true;
            this.labelBackgroundBorder.Location = new System.Drawing.Point(206, 6);
            this.labelBackgroundBorder.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelBackgroundBorder.Name = "labelBackgroundBorder";
            this.labelBackgroundBorder.Size = new System.Drawing.Size(295, 37);
            this.labelBackgroundBorder.TabIndex = 0;
            this.labelBackgroundBorder.Text = "labelBackgroundBorder";
            // 
            // labelMenuLightMode
            // 
            this.labelMenuLightMode.AutoSize = true;
            this.labelMenuLightMode.Location = new System.Drawing.Point(7, 0);
            this.labelMenuLightMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelMenuLightMode.Name = "labelMenuLightMode";
            this.labelMenuLightMode.Size = new System.Drawing.Size(273, 37);
            this.labelMenuLightMode.TabIndex = 3;
            this.labelMenuLightMode.Text = "labelMenuLightMode";
            // 
            // tableLayoutPanelTitle
            // 
            this.tableLayoutPanelTitle.AutoSize = true;
            this.tableLayoutPanelTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTitle.ColumnCount = 3;
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.Controls.Add(this.pictureBoxTitle, 0, 0);
            this.tableLayoutPanelTitle.Controls.Add(this.textBoxColorTitle, 1, 0);
            this.tableLayoutPanelTitle.Controls.Add(this.labelTitle, 2, 0);
            this.tableLayoutPanelTitle.Location = new System.Drawing.Point(7, 44);
            this.tableLayoutPanelTitle.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelTitle.Name = "tableLayoutPanelTitle";
            this.tableLayoutPanelTitle.RowCount = 1;
            this.tableLayoutPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(339, 49);
            this.tableLayoutPanelTitle.TabIndex = 2;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackColor = System.Drawing.Color.White;
            this.pictureBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxTitle.TabIndex = 1;
            this.pictureBoxTitle.TabStop = false;
            this.pictureBoxTitle.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorTitle
            // 
            this.textBoxColorTitle.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorTitle.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorTitle.MaxLength = 12;
            this.textBoxColorTitle.Name = "textBoxColorTitle";
            this.textBoxColorTitle.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorTitle.TabIndex = 2;
            this.textBoxColorTitle.Text = "#ffffff";
            this.textBoxColorTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(206, 6);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(126, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "labelTitle";
            // 
            // tableLayoutPanelBackground
            // 
            this.tableLayoutPanelBackground.AutoSize = true;
            this.tableLayoutPanelBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBackground.ColumnCount = 3;
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.Controls.Add(this.pictureBoxBackground, 0, 0);
            this.tableLayoutPanelBackground.Controls.Add(this.textBoxColorBackground, 1, 0);
            this.tableLayoutPanelBackground.Controls.Add(this.labelBackground, 2, 0);
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(7, 170);
            this.tableLayoutPanelBackground.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 1;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(429, 49);
            this.tableLayoutPanelBackground.TabIndex = 2;
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxBackground.TabIndex = 1;
            this.pictureBoxBackground.TabStop = false;
            this.pictureBoxBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorBackground
            // 
            this.textBoxColorBackground.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackground.MaxLength = 12;
            this.textBoxColorBackground.Name = "textBoxColorBackground";
            this.textBoxColorBackground.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorBackground.TabIndex = 2;
            this.textBoxColorBackground.Text = "#ffffff";
            this.textBoxColorBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackground.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackground.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelBackground
            // 
            this.labelBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(206, 6);
            this.labelBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(216, 37);
            this.labelBackground.TabIndex = 0;
            this.labelBackground.Text = "labelBackground";
            // 
            // buttonColorsDefault
            // 
            this.buttonColorsDefault.AutoSize = true;
            this.buttonColorsDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColorsDefault.Location = new System.Drawing.Point(7, 1341);
            this.buttonColorsDefault.Margin = new System.Windows.Forms.Padding(7);
            this.buttonColorsDefault.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonColorsDefault.Name = "buttonColorsDefault";
            this.buttonColorsDefault.Size = new System.Drawing.Size(269, 52);
            this.buttonColorsDefault.TabIndex = 2;
            this.buttonColorsDefault.Text = "buttonColorsDefault";
            this.buttonColorsDefault.UseVisualStyleBackColor = true;
            this.buttonColorsDefault.Click += new System.EventHandler(this.ButtonDefaultColors_Click);
            // 
            // tableLayoutPanelArrowHoverBackground
            // 
            this.tableLayoutPanelArrowHoverBackground.AutoSize = true;
            this.tableLayoutPanelArrowHoverBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowHoverBackground.ColumnCount = 3;
            this.tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowHoverBackground.Controls.Add(this.pictureBoxArrowHoverBackground, 0, 0);
            this.tableLayoutPanelArrowHoverBackground.Controls.Add(this.textBoxColorArrowHoverBackground, 1, 0);
            this.tableLayoutPanelArrowHoverBackground.Controls.Add(this.labelArrowHoverBackground, 2, 0);
            this.tableLayoutPanelArrowHoverBackground.Location = new System.Drawing.Point(7, 1278);
            this.tableLayoutPanelArrowHoverBackground.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowHoverBackground.Name = "tableLayoutPanelArrowHoverBackground";
            this.tableLayoutPanelArrowHoverBackground.RowCount = 1;
            this.tableLayoutPanelArrowHoverBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverBackground.Size = new System.Drawing.Size(571, 49);
            this.tableLayoutPanelArrowHoverBackground.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackground
            // 
            this.pictureBoxArrowHoverBackground.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowHoverBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowHoverBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowHoverBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowHoverBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowHoverBackground.Name = "pictureBoxArrowHoverBackground";
            this.pictureBoxArrowHoverBackground.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowHoverBackground.TabIndex = 1;
            this.pictureBoxArrowHoverBackground.TabStop = false;
            this.pictureBoxArrowHoverBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverBackground
            // 
            this.textBoxColorArrowHoverBackground.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowHoverBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverBackground.MaxLength = 12;
            this.textBoxColorArrowHoverBackground.Name = "textBoxColorArrowHoverBackground";
            this.textBoxColorArrowHoverBackground.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowHoverBackground.TabIndex = 2;
            this.textBoxColorArrowHoverBackground.Text = "#ffffff";
            this.textBoxColorArrowHoverBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowHoverBackground.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowHoverBackground.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelArrowHoverBackground
            // 
            this.labelArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrowHoverBackground.AutoSize = true;
            this.labelArrowHoverBackground.Location = new System.Drawing.Point(206, 6);
            this.labelArrowHoverBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelArrowHoverBackground.MaximumSize = new System.Drawing.Size(630, 0);
            this.labelArrowHoverBackground.Name = "labelArrowHoverBackground";
            this.labelArrowHoverBackground.Size = new System.Drawing.Size(358, 37);
            this.labelArrowHoverBackground.TabIndex = 0;
            this.labelArrowHoverBackground.Text = "labelArrowHoverBackground";
            // 
            // tableLayoutPanelArrowHover
            // 
            this.tableLayoutPanelArrowHover.AutoSize = true;
            this.tableLayoutPanelArrowHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowHover.ColumnCount = 3;
            this.tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowHover.Controls.Add(this.pictureBoxArrowHover, 0, 0);
            this.tableLayoutPanelArrowHover.Controls.Add(this.textBoxColorArrowHover, 1, 0);
            this.tableLayoutPanelArrowHover.Controls.Add(this.labelArrowHover, 2, 0);
            this.tableLayoutPanelArrowHover.Location = new System.Drawing.Point(7, 1215);
            this.tableLayoutPanelArrowHover.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowHover.Name = "tableLayoutPanelArrowHover";
            this.tableLayoutPanelArrowHover.RowCount = 1;
            this.tableLayoutPanelArrowHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHover.Size = new System.Drawing.Size(430, 49);
            this.tableLayoutPanelArrowHover.TabIndex = 2;
            // 
            // pictureBoxArrowHover
            // 
            this.pictureBoxArrowHover.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowHover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowHover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowHover.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowHover.Name = "pictureBoxArrowHover";
            this.pictureBoxArrowHover.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowHover.TabIndex = 1;
            this.pictureBoxArrowHover.TabStop = false;
            this.pictureBoxArrowHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHover
            // 
            this.textBoxColorArrowHover.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHover.MaxLength = 12;
            this.textBoxColorArrowHover.Name = "textBoxColorArrowHover";
            this.textBoxColorArrowHover.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowHover.TabIndex = 2;
            this.textBoxColorArrowHover.Text = "#ffffff";
            this.textBoxColorArrowHover.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowHover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowHover.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelArrowHover
            // 
            this.labelArrowHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrowHover.AutoSize = true;
            this.labelArrowHover.Location = new System.Drawing.Point(206, 6);
            this.labelArrowHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelArrowHover.Name = "labelArrowHover";
            this.labelArrowHover.Size = new System.Drawing.Size(217, 37);
            this.labelArrowHover.TabIndex = 0;
            this.labelArrowHover.Text = "labelArrowHover";
            // 
            // tableLayoutPanelArrowClickBackground
            // 
            this.tableLayoutPanelArrowClickBackground.AutoSize = true;
            this.tableLayoutPanelArrowClickBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowClickBackground.ColumnCount = 3;
            this.tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowClickBackground.Controls.Add(this.pictureBoxArrowClickBackground, 0, 0);
            this.tableLayoutPanelArrowClickBackground.Controls.Add(this.textBoxColorArrowClickBackground, 1, 0);
            this.tableLayoutPanelArrowClickBackground.Controls.Add(this.labelArrowClickBackground, 2, 0);
            this.tableLayoutPanelArrowClickBackground.Location = new System.Drawing.Point(7, 1152);
            this.tableLayoutPanelArrowClickBackground.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowClickBackground.Name = "tableLayoutPanelArrowClickBackground";
            this.tableLayoutPanelArrowClickBackground.RowCount = 1;
            this.tableLayoutPanelArrowClickBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickBackground.Size = new System.Drawing.Size(556, 49);
            this.tableLayoutPanelArrowClickBackground.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackground
            // 
            this.pictureBoxArrowClickBackground.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowClickBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowClickBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowClickBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowClickBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowClickBackground.Name = "pictureBoxArrowClickBackground";
            this.pictureBoxArrowClickBackground.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowClickBackground.TabIndex = 1;
            this.pictureBoxArrowClickBackground.TabStop = false;
            this.pictureBoxArrowClickBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickBackground
            // 
            this.textBoxColorArrowClickBackground.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowClickBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickBackground.MaxLength = 12;
            this.textBoxColorArrowClickBackground.Name = "textBoxColorArrowClickBackground";
            this.textBoxColorArrowClickBackground.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowClickBackground.TabIndex = 2;
            this.textBoxColorArrowClickBackground.Text = "#ffffff";
            this.textBoxColorArrowClickBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowClickBackground.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowClickBackground.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelArrowClickBackground
            // 
            this.labelArrowClickBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrowClickBackground.AutoSize = true;
            this.labelArrowClickBackground.Location = new System.Drawing.Point(206, 6);
            this.labelArrowClickBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelArrowClickBackground.Name = "labelArrowClickBackground";
            this.labelArrowClickBackground.Size = new System.Drawing.Size(343, 37);
            this.labelArrowClickBackground.TabIndex = 0;
            this.labelArrowClickBackground.Text = "labelArrowClickBackground";
            // 
            // tableLayoutPanelArrowClick
            // 
            this.tableLayoutPanelArrowClick.AutoSize = true;
            this.tableLayoutPanelArrowClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowClick.ColumnCount = 3;
            this.tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowClick.Controls.Add(this.pictureBoxArrowClick, 0, 0);
            this.tableLayoutPanelArrowClick.Controls.Add(this.textBoxColorArrowClick, 1, 0);
            this.tableLayoutPanelArrowClick.Controls.Add(this.labelArrowClick, 2, 0);
            this.tableLayoutPanelArrowClick.Location = new System.Drawing.Point(7, 1089);
            this.tableLayoutPanelArrowClick.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowClick.Name = "tableLayoutPanelArrowClick";
            this.tableLayoutPanelArrowClick.RowCount = 1;
            this.tableLayoutPanelArrowClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClick.Size = new System.Drawing.Size(415, 49);
            this.tableLayoutPanelArrowClick.TabIndex = 2;
            // 
            // pictureBoxArrowClick
            // 
            this.pictureBoxArrowClick.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowClick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowClick.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowClick.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowClick.Name = "pictureBoxArrowClick";
            this.pictureBoxArrowClick.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowClick.TabIndex = 1;
            this.pictureBoxArrowClick.TabStop = false;
            this.pictureBoxArrowClick.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClick
            // 
            this.textBoxColorArrowClick.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowClick.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClick.MaxLength = 12;
            this.textBoxColorArrowClick.Name = "textBoxColorArrowClick";
            this.textBoxColorArrowClick.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowClick.TabIndex = 2;
            this.textBoxColorArrowClick.Text = "#ffffff";
            this.textBoxColorArrowClick.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowClick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowClick.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelArrowClick
            // 
            this.labelArrowClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrowClick.AutoSize = true;
            this.labelArrowClick.Location = new System.Drawing.Point(206, 6);
            this.labelArrowClick.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelArrowClick.Name = "labelArrowClick";
            this.labelArrowClick.Size = new System.Drawing.Size(202, 37);
            this.labelArrowClick.TabIndex = 0;
            this.labelArrowClick.Text = "labelArrowClick";
            // 
            // tableLayoutPanelArrow
            // 
            this.tableLayoutPanelArrow.AutoSize = true;
            this.tableLayoutPanelArrow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrow.ColumnCount = 3;
            this.tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrow.Controls.Add(this.pictureBoxArrow, 0, 0);
            this.tableLayoutPanelArrow.Controls.Add(this.textBoxColorArrow, 1, 0);
            this.tableLayoutPanelArrow.Controls.Add(this.labelArrow, 2, 0);
            this.tableLayoutPanelArrow.Location = new System.Drawing.Point(7, 1026);
            this.tableLayoutPanelArrow.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrow.Name = "tableLayoutPanelArrow";
            this.tableLayoutPanelArrow.RowCount = 1;
            this.tableLayoutPanelArrow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrow.Size = new System.Drawing.Size(359, 49);
            this.tableLayoutPanelArrow.TabIndex = 2;
            // 
            // pictureBoxArrow
            // 
            this.pictureBoxArrow.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrow.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrow.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrow.Name = "pictureBoxArrow";
            this.pictureBoxArrow.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrow.TabIndex = 1;
            this.pictureBoxArrow.TabStop = false;
            this.pictureBoxArrow.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrow
            // 
            this.textBoxColorArrow.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrow.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrow.MaxLength = 12;
            this.textBoxColorArrow.Name = "textBoxColorArrow";
            this.textBoxColorArrow.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrow.TabIndex = 2;
            this.textBoxColorArrow.Text = "#ffffff";
            this.textBoxColorArrow.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelArrow
            // 
            this.labelArrow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrow.AutoSize = true;
            this.labelArrow.Location = new System.Drawing.Point(206, 6);
            this.labelArrow.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelArrow.Name = "labelArrow";
            this.labelArrow.Size = new System.Drawing.Size(146, 37);
            this.labelArrow.TabIndex = 0;
            this.labelArrow.Text = "labelArrow";
            // 
            // tableLayoutPanelSliderArrowsAndTrackHover
            // 
            this.tableLayoutPanelSliderArrowsAndTrackHover.AutoSize = true;
            this.tableLayoutPanelSliderArrowsAndTrackHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderArrowsAndTrackHover.ColumnCount = 3;
            this.tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(this.pictureBoxSliderArrowsAndTrackHover, 0, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(this.textBoxColorSliderArrowsAndTrackHover, 1, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(this.labelSliderArrowsAndTrackHover, 2, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(7, 963);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Name = "tableLayoutPanelSliderArrowsAndTrackHover";
            this.tableLayoutPanelSliderArrowsAndTrackHover.RowCount = 1;
            this.tableLayoutPanelSliderArrowsAndTrackHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(616, 49);
            this.tableLayoutPanelSliderArrowsAndTrackHover.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHover
            // 
            this.pictureBoxSliderArrowsAndTrackHover.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderArrowsAndTrackHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderArrowsAndTrackHover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderArrowsAndTrackHover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderArrowsAndTrackHover.Name = "pictureBoxSliderArrowsAndTrackHover";
            this.pictureBoxSliderArrowsAndTrackHover.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderArrowsAndTrackHover.TabIndex = 1;
            this.pictureBoxSliderArrowsAndTrackHover.TabStop = false;
            this.pictureBoxSliderArrowsAndTrackHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderArrowsAndTrackHover
            // 
            this.textBoxColorSliderArrowsAndTrackHover.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderArrowsAndTrackHover.MaxLength = 12;
            this.textBoxColorSliderArrowsAndTrackHover.Name = "textBoxColorSliderArrowsAndTrackHover";
            this.textBoxColorSliderArrowsAndTrackHover.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderArrowsAndTrackHover.TabIndex = 2;
            this.textBoxColorSliderArrowsAndTrackHover.Text = "#ffffff";
            this.textBoxColorSliderArrowsAndTrackHover.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderArrowsAndTrackHover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderArrowsAndTrackHover.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSliderArrowsAndTrackHover
            // 
            this.labelSliderArrowsAndTrackHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSliderArrowsAndTrackHover.AutoSize = true;
            this.labelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(206, 6);
            this.labelSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSliderArrowsAndTrackHover.Name = "labelSliderArrowsAndTrackHover";
            this.labelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(403, 37);
            this.labelSliderArrowsAndTrackHover.TabIndex = 0;
            this.labelSliderArrowsAndTrackHover.Text = "labelSliderArrowsAndTrackHover";
            // 
            // tableLayoutPanelSliderHover
            // 
            this.tableLayoutPanelSliderHover.AutoSize = true;
            this.tableLayoutPanelSliderHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderHover.ColumnCount = 3;
            this.tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderHover.Controls.Add(this.pictureBoxSliderHover, 0, 0);
            this.tableLayoutPanelSliderHover.Controls.Add(this.textBoxColorSliderHover, 1, 0);
            this.tableLayoutPanelSliderHover.Controls.Add(this.labelSliderHover, 2, 0);
            this.tableLayoutPanelSliderHover.Location = new System.Drawing.Point(7, 900);
            this.tableLayoutPanelSliderHover.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderHover.Name = "tableLayoutPanelSliderHover";
            this.tableLayoutPanelSliderHover.RowCount = 1;
            this.tableLayoutPanelSliderHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderHover.Size = new System.Drawing.Size(426, 49);
            this.tableLayoutPanelSliderHover.TabIndex = 2;
            // 
            // pictureBoxSliderHover
            // 
            this.pictureBoxSliderHover.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderHover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderHover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderHover.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderHover.Name = "pictureBoxSliderHover";
            this.pictureBoxSliderHover.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderHover.TabIndex = 1;
            this.pictureBoxSliderHover.TabStop = false;
            this.pictureBoxSliderHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderHover
            // 
            this.textBoxColorSliderHover.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderHover.MaxLength = 12;
            this.textBoxColorSliderHover.Name = "textBoxColorSliderHover";
            this.textBoxColorSliderHover.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderHover.TabIndex = 2;
            this.textBoxColorSliderHover.Text = "#ffffff";
            this.textBoxColorSliderHover.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderHover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderHover.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSliderHover
            // 
            this.labelSliderHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSliderHover.AutoSize = true;
            this.labelSliderHover.Location = new System.Drawing.Point(206, 6);
            this.labelSliderHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSliderHover.Name = "labelSliderHover";
            this.labelSliderHover.Size = new System.Drawing.Size(213, 37);
            this.labelSliderHover.TabIndex = 0;
            this.labelSliderHover.Text = "labelSliderHover";
            // 
            // tableLayoutPanelSliderDragging
            // 
            this.tableLayoutPanelSliderDragging.AutoSize = true;
            this.tableLayoutPanelSliderDragging.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderDragging.ColumnCount = 3;
            this.tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderDragging.Controls.Add(this.pictureBoxSliderDragging, 0, 0);
            this.tableLayoutPanelSliderDragging.Controls.Add(this.textBoxColorSliderDragging, 1, 0);
            this.tableLayoutPanelSliderDragging.Controls.Add(this.labelSliderDragging, 2, 0);
            this.tableLayoutPanelSliderDragging.Location = new System.Drawing.Point(7, 837);
            this.tableLayoutPanelSliderDragging.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderDragging.Name = "tableLayoutPanelSliderDragging";
            this.tableLayoutPanelSliderDragging.RowCount = 1;
            this.tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelSliderDragging.Size = new System.Drawing.Size(467, 49);
            this.tableLayoutPanelSliderDragging.TabIndex = 2;
            // 
            // pictureBoxSliderDragging
            // 
            this.pictureBoxSliderDragging.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderDragging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderDragging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderDragging.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderDragging.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderDragging.Name = "pictureBoxSliderDragging";
            this.pictureBoxSliderDragging.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderDragging.TabIndex = 1;
            this.pictureBoxSliderDragging.TabStop = false;
            this.pictureBoxSliderDragging.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDragging
            // 
            this.textBoxColorSliderDragging.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderDragging.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDragging.MaxLength = 12;
            this.textBoxColorSliderDragging.Name = "textBoxColorSliderDragging";
            this.textBoxColorSliderDragging.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderDragging.TabIndex = 2;
            this.textBoxColorSliderDragging.Text = "#ffffff";
            this.textBoxColorSliderDragging.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderDragging.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderDragging.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSliderDragging
            // 
            this.labelSliderDragging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSliderDragging.AutoSize = true;
            this.labelSliderDragging.Location = new System.Drawing.Point(206, 6);
            this.labelSliderDragging.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSliderDragging.Name = "labelSliderDragging";
            this.labelSliderDragging.Size = new System.Drawing.Size(254, 37);
            this.labelSliderDragging.TabIndex = 0;
            this.labelSliderDragging.Text = "labelSliderDragging";
            // 
            // tableLayoutPanelSlider
            // 
            this.tableLayoutPanelSlider.AutoSize = true;
            this.tableLayoutPanelSlider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSlider.ColumnCount = 3;
            this.tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSlider.Controls.Add(this.pictureBoxSlider, 0, 0);
            this.tableLayoutPanelSlider.Controls.Add(this.textBoxColorSlider, 1, 0);
            this.tableLayoutPanelSlider.Controls.Add(this.labelSlider, 2, 0);
            this.tableLayoutPanelSlider.Location = new System.Drawing.Point(7, 774);
            this.tableLayoutPanelSlider.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSlider.Name = "tableLayoutPanelSlider";
            this.tableLayoutPanelSlider.RowCount = 1;
            this.tableLayoutPanelSlider.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSlider.Size = new System.Drawing.Size(355, 49);
            this.tableLayoutPanelSlider.TabIndex = 2;
            // 
            // pictureBoxSlider
            // 
            this.pictureBoxSlider.BackColor = System.Drawing.Color.White;
            this.pictureBoxSlider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSlider.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSlider.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSlider.Name = "pictureBoxSlider";
            this.pictureBoxSlider.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSlider.TabIndex = 1;
            this.pictureBoxSlider.TabStop = false;
            this.pictureBoxSlider.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSlider
            // 
            this.textBoxColorSlider.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSlider.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSlider.MaxLength = 12;
            this.textBoxColorSlider.Name = "textBoxColorSlider";
            this.textBoxColorSlider.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSlider.TabIndex = 2;
            this.textBoxColorSlider.Text = "#ffffff";
            this.textBoxColorSlider.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSlider.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSlider.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSlider
            // 
            this.labelSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSlider.AutoSize = true;
            this.labelSlider.Location = new System.Drawing.Point(206, 6);
            this.labelSlider.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSlider.Name = "labelSlider";
            this.labelSlider.Size = new System.Drawing.Size(142, 37);
            this.labelSlider.TabIndex = 0;
            this.labelSlider.Text = "labelSlider";
            // 
            // tableLayoutPanelScrollbarBackground
            // 
            this.tableLayoutPanelScrollbarBackground.AutoSize = true;
            this.tableLayoutPanelScrollbarBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelScrollbarBackground.ColumnCount = 3;
            this.tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelScrollbarBackground.Controls.Add(this.pictureBoxScrollbarBackground, 0, 0);
            this.tableLayoutPanelScrollbarBackground.Controls.Add(this.textBoxColorScrollbarBackground, 1, 0);
            this.tableLayoutPanelScrollbarBackground.Controls.Add(this.labelScrollbarBackground, 2, 0);
            this.tableLayoutPanelScrollbarBackground.Location = new System.Drawing.Point(7, 711);
            this.tableLayoutPanelScrollbarBackground.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelScrollbarBackground.Name = "tableLayoutPanelScrollbarBackground";
            this.tableLayoutPanelScrollbarBackground.RowCount = 1;
            this.tableLayoutPanelScrollbarBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrollbarBackground.Size = new System.Drawing.Size(533, 49);
            this.tableLayoutPanelScrollbarBackground.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackground
            // 
            this.pictureBoxScrollbarBackground.BackColor = System.Drawing.Color.White;
            this.pictureBoxScrollbarBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScrollbarBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxScrollbarBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScrollbarBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxScrollbarBackground.Name = "pictureBoxScrollbarBackground";
            this.pictureBoxScrollbarBackground.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxScrollbarBackground.TabIndex = 1;
            this.pictureBoxScrollbarBackground.TabStop = false;
            this.pictureBoxScrollbarBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorScrollbarBackground
            // 
            this.textBoxColorScrollbarBackground.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorScrollbarBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorScrollbarBackground.MaxLength = 12;
            this.textBoxColorScrollbarBackground.Name = "textBoxColorScrollbarBackground";
            this.textBoxColorScrollbarBackground.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorScrollbarBackground.TabIndex = 2;
            this.textBoxColorScrollbarBackground.Text = "#ffffff";
            this.textBoxColorScrollbarBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorScrollbarBackground.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorScrollbarBackground.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelScrollbarBackground
            // 
            this.labelScrollbarBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelScrollbarBackground.AutoSize = true;
            this.labelScrollbarBackground.Location = new System.Drawing.Point(206, 6);
            this.labelScrollbarBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelScrollbarBackground.Name = "labelScrollbarBackground";
            this.labelScrollbarBackground.Size = new System.Drawing.Size(320, 37);
            this.labelScrollbarBackground.TabIndex = 0;
            this.labelScrollbarBackground.Text = "labelScrollbarBackground";
            // 
            // labelScrollbarLightMode
            // 
            this.labelScrollbarLightMode.AutoSize = true;
            this.labelScrollbarLightMode.Location = new System.Drawing.Point(7, 667);
            this.labelScrollbarLightMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelScrollbarLightMode.Name = "labelScrollbarLightMode";
            this.labelScrollbarLightMode.Size = new System.Drawing.Size(309, 37);
            this.labelScrollbarLightMode.TabIndex = 3;
            this.labelScrollbarLightMode.Text = "labelScrollbarLightMode";
            // 
            // tableLayoutPanelWarning
            // 
            this.tableLayoutPanelWarning.AutoSize = true;
            this.tableLayoutPanelWarning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelWarning.ColumnCount = 3;
            this.tableLayoutPanelWarning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelWarning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelWarning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWarning.Controls.Add(this.labelWarning, 2, 0);
            this.tableLayoutPanelWarning.Controls.Add(this.textBoxColorWarning, 1, 0);
            this.tableLayoutPanelWarning.Controls.Add(this.pictureBoxWarning, 0, 0);
            this.tableLayoutPanelWarning.Location = new System.Drawing.Point(7, 611);
            this.tableLayoutPanelWarning.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelWarning.Name = "tableLayoutPanelWarning";
            this.tableLayoutPanelWarning.RowCount = 1;
            this.tableLayoutPanelWarning.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWarning.Size = new System.Drawing.Size(388, 49);
            this.tableLayoutPanelWarning.TabIndex = 2;
            // 
            // labelWarning
            // 
            this.labelWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(206, 6);
            this.labelWarning.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(175, 37);
            this.labelWarning.TabIndex = 0;
            this.labelWarning.Text = "labelWarning";
            // 
            // textBoxColorWarning
            // 
            this.textBoxColorWarning.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorWarning.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorWarning.MaxLength = 12;
            this.textBoxColorWarning.Name = "textBoxColorWarning";
            this.textBoxColorWarning.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorWarning.TabIndex = 2;
            this.textBoxColorWarning.Text = "#ffffff";
            this.textBoxColorWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorWarning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorWarning.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.BackColor = System.Drawing.Color.White;
            this.pictureBoxWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWarning.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWarning.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxWarning.TabIndex = 1;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // tableLayoutPanelSelectedItemBorder
            // 
            this.tableLayoutPanelSelectedItemBorder.AutoSize = true;
            this.tableLayoutPanelSelectedItemBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSelectedItemBorder.ColumnCount = 3;
            this.tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelectedItemBorder.Controls.Add(this.pictureBoxSelectedItemBorder, 0, 0);
            this.tableLayoutPanelSelectedItemBorder.Controls.Add(this.textBoxColorSelectedItemBorder, 1, 0);
            this.tableLayoutPanelSelectedItemBorder.Controls.Add(this.labelSelectedItemBorder, 2, 0);
            this.tableLayoutPanelSelectedItemBorder.Location = new System.Drawing.Point(7, 548);
            this.tableLayoutPanelSelectedItemBorder.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSelectedItemBorder.Name = "tableLayoutPanelSelectedItemBorder";
            this.tableLayoutPanelSelectedItemBorder.RowCount = 1;
            this.tableLayoutPanelSelectedItemBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemBorder.Size = new System.Drawing.Size(520, 49);
            this.tableLayoutPanelSelectedItemBorder.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorder
            // 
            this.pictureBoxSelectedItemBorder.BackColor = System.Drawing.Color.White;
            this.pictureBoxSelectedItemBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSelectedItemBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSelectedItemBorder.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSelectedItemBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSelectedItemBorder.Name = "pictureBoxSelectedItemBorder";
            this.pictureBoxSelectedItemBorder.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSelectedItemBorder.TabIndex = 1;
            this.pictureBoxSelectedItemBorder.TabStop = false;
            this.pictureBoxSelectedItemBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSelectedItemBorder
            // 
            this.textBoxColorSelectedItemBorder.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSelectedItemBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItemBorder.MaxLength = 12;
            this.textBoxColorSelectedItemBorder.Name = "textBoxColorSelectedItemBorder";
            this.textBoxColorSelectedItemBorder.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSelectedItemBorder.TabIndex = 2;
            this.textBoxColorSelectedItemBorder.Text = "#ffffff";
            this.textBoxColorSelectedItemBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItemBorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSelectedItemBorder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSelectedItemBorder
            // 
            this.labelSelectedItemBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemBorder.AutoSize = true;
            this.labelSelectedItemBorder.Location = new System.Drawing.Point(206, 6);
            this.labelSelectedItemBorder.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSelectedItemBorder.Name = "labelSelectedItemBorder";
            this.labelSelectedItemBorder.Size = new System.Drawing.Size(307, 37);
            this.labelSelectedItemBorder.TabIndex = 0;
            this.labelSelectedItemBorder.Text = "labelSelectedItemBorder";
            // 
            // tableLayoutPanelSelectedItem
            // 
            this.tableLayoutPanelSelectedItem.AutoSize = true;
            this.tableLayoutPanelSelectedItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSelectedItem.ColumnCount = 3;
            this.tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelectedItem.Controls.Add(this.pictureBoxSelectedItem, 0, 0);
            this.tableLayoutPanelSelectedItem.Controls.Add(this.textBoxColorSelectedItem, 1, 0);
            this.tableLayoutPanelSelectedItem.Controls.Add(this.labelSelectedItem, 2, 0);
            this.tableLayoutPanelSelectedItem.Location = new System.Drawing.Point(7, 485);
            this.tableLayoutPanelSelectedItem.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSelectedItem.Name = "tableLayoutPanelSelectedItem";
            this.tableLayoutPanelSelectedItem.RowCount = 1;
            this.tableLayoutPanelSelectedItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItem.Size = new System.Drawing.Size(441, 49);
            this.tableLayoutPanelSelectedItem.TabIndex = 2;
            // 
            // pictureBoxSelectedItem
            // 
            this.pictureBoxSelectedItem.BackColor = System.Drawing.Color.White;
            this.pictureBoxSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSelectedItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSelectedItem.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSelectedItem.Name = "pictureBoxSelectedItem";
            this.pictureBoxSelectedItem.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSelectedItem.TabIndex = 1;
            this.pictureBoxSelectedItem.TabStop = false;
            this.pictureBoxSelectedItem.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSelectedItem
            // 
            this.textBoxColorSelectedItem.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItem.MaxLength = 12;
            this.textBoxColorSelectedItem.Name = "textBoxColorSelectedItem";
            this.textBoxColorSelectedItem.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSelectedItem.TabIndex = 2;
            this.textBoxColorSelectedItem.Text = "#ffffff";
            this.textBoxColorSelectedItem.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSelectedItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSelectedItem
            // 
            this.labelSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItem.AutoSize = true;
            this.labelSelectedItem.Location = new System.Drawing.Point(206, 6);
            this.labelSelectedItem.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSelectedItem.Name = "labelSelectedItem";
            this.labelSelectedItem.Size = new System.Drawing.Size(228, 37);
            this.labelSelectedItem.TabIndex = 0;
            this.labelSelectedItem.Text = "labelSelectedItem";
            // 
            // tableLayoutPanelOpenFolderBorder
            // 
            this.tableLayoutPanelOpenFolderBorder.AutoSize = true;
            this.tableLayoutPanelOpenFolderBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOpenFolderBorder.ColumnCount = 3;
            this.tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOpenFolderBorder.Controls.Add(this.pictureBoxOpenFolderBorder, 0, 0);
            this.tableLayoutPanelOpenFolderBorder.Controls.Add(this.textBoxColorOpenFolderBorder, 1, 0);
            this.tableLayoutPanelOpenFolderBorder.Controls.Add(this.labelOpenFolderBorder, 2, 0);
            this.tableLayoutPanelOpenFolderBorder.Location = new System.Drawing.Point(7, 422);
            this.tableLayoutPanelOpenFolderBorder.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelOpenFolderBorder.Name = "tableLayoutPanelOpenFolderBorder";
            this.tableLayoutPanelOpenFolderBorder.RowCount = 1;
            this.tableLayoutPanelOpenFolderBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderBorder.Size = new System.Drawing.Size(507, 49);
            this.tableLayoutPanelOpenFolderBorder.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorder
            // 
            this.pictureBoxOpenFolderBorder.BackColor = System.Drawing.Color.White;
            this.pictureBoxOpenFolderBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOpenFolderBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpenFolderBorder.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOpenFolderBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxOpenFolderBorder.Name = "pictureBoxOpenFolderBorder";
            this.pictureBoxOpenFolderBorder.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxOpenFolderBorder.TabIndex = 1;
            this.pictureBoxOpenFolderBorder.TabStop = false;
            this.pictureBoxOpenFolderBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorOpenFolderBorder
            // 
            this.textBoxColorOpenFolderBorder.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorOpenFolderBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderBorder.Name = "textBoxColorOpenFolderBorder";
            this.textBoxColorOpenFolderBorder.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorOpenFolderBorder.TabIndex = 2;
            this.textBoxColorOpenFolderBorder.Text = "#ffffff";
            this.textBoxColorOpenFolderBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolderBorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorOpenFolderBorder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelOpenFolderBorder
            // 
            this.labelOpenFolderBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderBorder.AutoSize = true;
            this.labelOpenFolderBorder.Location = new System.Drawing.Point(206, 6);
            this.labelOpenFolderBorder.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelOpenFolderBorder.Name = "labelOpenFolderBorder";
            this.labelOpenFolderBorder.Size = new System.Drawing.Size(294, 37);
            this.labelOpenFolderBorder.TabIndex = 0;
            this.labelOpenFolderBorder.Text = "labelOpenFolderBorder";
            // 
            // tableLayoutPanelOpenFolder
            // 
            this.tableLayoutPanelOpenFolder.AutoSize = true;
            this.tableLayoutPanelOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOpenFolder.ColumnCount = 3;
            this.tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOpenFolder.Controls.Add(this.pictureBoxOpenFolder, 0, 0);
            this.tableLayoutPanelOpenFolder.Controls.Add(this.textBoxColorOpenFolder, 1, 0);
            this.tableLayoutPanelOpenFolder.Controls.Add(this.labelOpenFolder, 2, 0);
            this.tableLayoutPanelOpenFolder.Location = new System.Drawing.Point(7, 359);
            this.tableLayoutPanelOpenFolder.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelOpenFolder.Name = "tableLayoutPanelOpenFolder";
            this.tableLayoutPanelOpenFolder.RowCount = 1;
            this.tableLayoutPanelOpenFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolder.Size = new System.Drawing.Size(428, 49);
            this.tableLayoutPanelOpenFolder.TabIndex = 2;
            // 
            // pictureBoxOpenFolder
            // 
            this.pictureBoxOpenFolder.BackColor = System.Drawing.Color.White;
            this.pictureBoxOpenFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpenFolder.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxOpenFolder.Name = "pictureBoxOpenFolder";
            this.pictureBoxOpenFolder.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxOpenFolder.TabIndex = 1;
            this.pictureBoxOpenFolder.TabStop = false;
            this.pictureBoxOpenFolder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorOpenFolder
            // 
            this.textBoxColorOpenFolder.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolder.MaxLength = 12;
            this.textBoxColorOpenFolder.Name = "textBoxColorOpenFolder";
            this.textBoxColorOpenFolder.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorOpenFolder.TabIndex = 2;
            this.textBoxColorOpenFolder.Text = "#ffffff";
            this.textBoxColorOpenFolder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorOpenFolder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelOpenFolder
            // 
            this.labelOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolder.AutoSize = true;
            this.labelOpenFolder.Location = new System.Drawing.Point(206, 6);
            this.labelOpenFolder.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelOpenFolder.Name = "labelOpenFolder";
            this.labelOpenFolder.Size = new System.Drawing.Size(215, 37);
            this.labelOpenFolder.TabIndex = 0;
            this.labelOpenFolder.Text = "labelOpenFolder";
            // 
            // tableLayoutPanelSearchField
            // 
            this.tableLayoutPanelSearchField.AutoSize = true;
            this.tableLayoutPanelSearchField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSearchField.ColumnCount = 3;
            this.tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSearchField.Controls.Add(this.pictureBoxSearchField, 0, 0);
            this.tableLayoutPanelSearchField.Controls.Add(this.textBoxColorSearchField, 1, 0);
            this.tableLayoutPanelSearchField.Controls.Add(this.labelSearchField, 2, 0);
            this.tableLayoutPanelSearchField.Location = new System.Drawing.Point(7, 296);
            this.tableLayoutPanelSearchField.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSearchField.Name = "tableLayoutPanelSearchField";
            this.tableLayoutPanelSearchField.RowCount = 1;
            this.tableLayoutPanelSearchField.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearchField.Size = new System.Drawing.Size(423, 49);
            this.tableLayoutPanelSearchField.TabIndex = 2;
            // 
            // pictureBoxSearchField
            // 
            this.pictureBoxSearchField.BackColor = System.Drawing.Color.White;
            this.pictureBoxSearchField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSearchField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearchField.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSearchField.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSearchField.Name = "pictureBoxSearchField";
            this.pictureBoxSearchField.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSearchField.TabIndex = 1;
            this.pictureBoxSearchField.TabStop = false;
            this.pictureBoxSearchField.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSearchField
            // 
            this.textBoxColorSearchField.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSearchField.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSearchField.MaxLength = 12;
            this.textBoxColorSearchField.Name = "textBoxColorSearchField";
            this.textBoxColorSearchField.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSearchField.TabIndex = 2;
            this.textBoxColorSearchField.Text = "#ffffff";
            this.textBoxColorSearchField.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSearchField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSearchField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSearchField
            // 
            this.labelSearchField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSearchField.AutoSize = true;
            this.labelSearchField.Location = new System.Drawing.Point(206, 6);
            this.labelSearchField.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSearchField.Name = "labelSearchField";
            this.labelSearchField.Size = new System.Drawing.Size(210, 37);
            this.labelSearchField.TabIndex = 0;
            this.labelSearchField.Text = "labelSearchField";
            // 
            // groupBoxColorsDarkMode
            // 
            this.groupBoxColorsDarkMode.AutoSize = true;
            this.groupBoxColorsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsDarkMode.Controls.Add(this.tableLayoutPanelDarkMode);
            this.groupBoxColorsDarkMode.Location = new System.Drawing.Point(7, 1471);
            this.groupBoxColorsDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxColorsDarkMode.MaximumSize = new System.Drawing.Size(866, 0);
            this.groupBoxColorsDarkMode.MinimumSize = new System.Drawing.Size(866, 0);
            this.groupBoxColorsDarkMode.Name = "groupBoxColorsDarkMode";
            this.groupBoxColorsDarkMode.Padding = new System.Windows.Forms.Padding(7);
            this.groupBoxColorsDarkMode.Size = new System.Drawing.Size(866, 1505);
            this.groupBoxColorsDarkMode.TabIndex = 0;
            this.groupBoxColorsDarkMode.TabStop = false;
            this.groupBoxColorsDarkMode.Text = "groupBoxColorsDarkMode";
            // 
            // tableLayoutPanelDarkMode
            // 
            this.tableLayoutPanelDarkMode.AutoSize = true;
            this.tableLayoutPanelDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDarkMode.ColumnCount = 1;
            this.tableLayoutPanelDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 999F));
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanelDarkMode.Controls.Add(this.checkBoxDarkModeAlwaysOn, 0, 0);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelMenuDarkMode, 0, 1);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSearchFieldDarkMode, 0, 6);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelOpenFolderDarkMode, 0, 7);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelOpenFolderBorderDarkMode, 0, 8);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSelectedItemDarkMode, 0, 9);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSelectedItemBorderDarkMode, 0, 10);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelWarningDarkMode, 0, 11);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelScrollbarDarkMode, 0, 12);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelScrollbarBackgroundDarkMode, 0, 13);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderDarkMode, 0, 14);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderDraggingDarkMode, 0, 15);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderHoverDarkMode, 0, 16);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode, 0, 17);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowDarkMode, 0, 18);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowClickDarkMode, 0, 19);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowClickBackgroundDarkMode, 0, 20);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowHoverDarkMode, 0, 21);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowHoverBackgroundDarkMode, 0, 22);
            this.tableLayoutPanelDarkMode.Controls.Add(this.buttonColorsDefaultDarkMode, 0, 23);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelTitleDarkMode, 0, 2);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelBackgroundDarkMode, 0, 4);
            this.tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDarkMode.Location = new System.Drawing.Point(7, 43);
            this.tableLayoutPanelDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            this.tableLayoutPanelDarkMode.RowCount = 24;
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.Size = new System.Drawing.Size(852, 1455);
            this.tableLayoutPanelDarkMode.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBoxIconsDarkMode, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelIconsDarkMode, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxColorIconsDarkMode, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(7, 162);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(474, 49);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // pictureBoxIconsDarkMode
            // 
            this.pictureBoxIconsDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxIconsDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIconsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIconsDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIconsDarkMode.Name = "pictureBoxIconsDarkMode";
            this.pictureBoxIconsDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxIconsDarkMode.TabIndex = 1;
            this.pictureBoxIconsDarkMode.TabStop = false;
            this.pictureBoxIconsDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelIconsDarkMode
            // 
            this.labelIconsDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIconsDarkMode.AutoSize = true;
            this.labelIconsDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelIconsDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelIconsDarkMode.Name = "labelIconsDarkMode";
            this.labelIconsDarkMode.Size = new System.Drawing.Size(261, 37);
            this.labelIconsDarkMode.TabIndex = 0;
            this.labelIconsDarkMode.Text = "labelIconsDarkMode";
            // 
            // textBoxColorIconsDarkMode
            // 
            this.textBoxColorIconsDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorIconsDarkMode.MaxLength = 12;
            this.textBoxColorIconsDarkMode.Name = "textBoxColorIconsDarkMode";
            this.textBoxColorIconsDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorIconsDarkMode.TabIndex = 2;
            this.textBoxColorIconsDarkMode.Text = "#ffffff";
            this.textBoxColorIconsDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorIconsDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorIconsDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBoxBackgroundBorderDarkMode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelBackgroundBorderDarkMode, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxColorBackgroundBorderDarkMode, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 288);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(633, 49);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // pictureBoxBackgroundBorderDarkMode
            // 
            this.pictureBoxBackgroundBorderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackgroundBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackgroundBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackgroundBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackgroundBorderDarkMode.Name = "pictureBoxBackgroundBorderDarkMode";
            this.pictureBoxBackgroundBorderDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxBackgroundBorderDarkMode.TabIndex = 1;
            this.pictureBoxBackgroundBorderDarkMode.TabStop = false;
            this.pictureBoxBackgroundBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelBackgroundBorderDarkMode
            // 
            this.labelBackgroundBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackgroundBorderDarkMode.AutoSize = true;
            this.labelBackgroundBorderDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelBackgroundBorderDarkMode.Name = "labelBackgroundBorderDarkMode";
            this.labelBackgroundBorderDarkMode.Size = new System.Drawing.Size(420, 37);
            this.labelBackgroundBorderDarkMode.TabIndex = 0;
            this.labelBackgroundBorderDarkMode.Text = "labelBackgroundDarkModeBorder";
            // 
            // textBoxColorBackgroundBorderDarkMode
            // 
            this.textBoxColorBackgroundBorderDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundBorderDarkMode.MaxLength = 12;
            this.textBoxColorBackgroundBorderDarkMode.Name = "textBoxColorBackgroundBorderDarkMode";
            this.textBoxColorBackgroundBorderDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorBackgroundBorderDarkMode.TabIndex = 2;
            this.textBoxColorBackgroundBorderDarkMode.Text = "#ffffff";
            this.textBoxColorBackgroundBorderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackgroundBorderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackgroundBorderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            this.checkBoxDarkModeAlwaysOn.AutoSize = true;
            this.checkBoxDarkModeAlwaysOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(7, 7);
            this.checkBoxDarkModeAlwaysOn.Margin = new System.Windows.Forms.Padding(7);
            this.checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(985, 41);
            this.checkBoxDarkModeAlwaysOn.TabIndex = 0;
            this.checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            this.checkBoxDarkModeAlwaysOn.CheckedChanged += new System.EventHandler(this.CheckBoxDarkModeAlwaysOnCheckedChanged);
            // 
            // labelMenuDarkMode
            // 
            this.labelMenuDarkMode.AutoSize = true;
            this.labelMenuDarkMode.Location = new System.Drawing.Point(7, 55);
            this.labelMenuDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelMenuDarkMode.Name = "labelMenuDarkMode";
            this.labelMenuDarkMode.Size = new System.Drawing.Size(268, 37);
            this.labelMenuDarkMode.TabIndex = 3;
            this.labelMenuDarkMode.Text = "labelMenuDarkMode";
            // 
            // tableLayoutPanelSearchFieldDarkMode
            // 
            this.tableLayoutPanelSearchFieldDarkMode.AutoSize = true;
            this.tableLayoutPanelSearchFieldDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSearchFieldDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSearchFieldDarkMode.Controls.Add(this.pictureBoxSearchFieldDarkMode, 0, 0);
            this.tableLayoutPanelSearchFieldDarkMode.Controls.Add(this.labelSearchFieldDarkMode, 2, 0);
            this.tableLayoutPanelSearchFieldDarkMode.Controls.Add(this.textBoxColorSearchFieldDarkMode, 1, 0);
            this.tableLayoutPanelSearchFieldDarkMode.Location = new System.Drawing.Point(7, 351);
            this.tableLayoutPanelSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSearchFieldDarkMode.Name = "tableLayoutPanelSearchFieldDarkMode";
            this.tableLayoutPanelSearchFieldDarkMode.RowCount = 1;
            this.tableLayoutPanelSearchFieldDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearchFieldDarkMode.Size = new System.Drawing.Size(548, 49);
            this.tableLayoutPanelSearchFieldDarkMode.TabIndex = 2;
            // 
            // pictureBoxSearchFieldDarkMode
            // 
            this.pictureBoxSearchFieldDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSearchFieldDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSearchFieldDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearchFieldDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSearchFieldDarkMode.Name = "pictureBoxSearchFieldDarkMode";
            this.pictureBoxSearchFieldDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSearchFieldDarkMode.TabIndex = 1;
            this.pictureBoxSearchFieldDarkMode.TabStop = false;
            this.pictureBoxSearchFieldDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSearchFieldDarkMode
            // 
            this.labelSearchFieldDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSearchFieldDarkMode.AutoSize = true;
            this.labelSearchFieldDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSearchFieldDarkMode.Name = "labelSearchFieldDarkMode";
            this.labelSearchFieldDarkMode.Size = new System.Drawing.Size(335, 37);
            this.labelSearchFieldDarkMode.TabIndex = 0;
            this.labelSearchFieldDarkMode.Text = "labelSearchFieldDarkMode";
            // 
            // textBoxColorSearchFieldDarkMode
            // 
            this.textBoxColorSearchFieldDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSearchFieldDarkMode.MaxLength = 12;
            this.textBoxColorSearchFieldDarkMode.Name = "textBoxColorSearchFieldDarkMode";
            this.textBoxColorSearchFieldDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSearchFieldDarkMode.TabIndex = 2;
            this.textBoxColorSearchFieldDarkMode.Text = "#ffffff";
            this.textBoxColorSearchFieldDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSearchFieldDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSearchFieldDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelOpenFolderDarkMode
            // 
            this.tableLayoutPanelOpenFolderDarkMode.AutoSize = true;
            this.tableLayoutPanelOpenFolderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOpenFolderDarkMode.ColumnCount = 3;
            this.tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOpenFolderDarkMode.Controls.Add(this.pictureBoxOpenFolderDarkMode, 0, 0);
            this.tableLayoutPanelOpenFolderDarkMode.Controls.Add(this.labelOpenFolderDarkMode, 2, 0);
            this.tableLayoutPanelOpenFolderDarkMode.Controls.Add(this.textBoxColorOpenFolderDarkMode, 1, 0);
            this.tableLayoutPanelOpenFolderDarkMode.Location = new System.Drawing.Point(7, 414);
            this.tableLayoutPanelOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelOpenFolderDarkMode.Name = "tableLayoutPanelOpenFolderDarkMode";
            this.tableLayoutPanelOpenFolderDarkMode.RowCount = 1;
            this.tableLayoutPanelOpenFolderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderDarkMode.Size = new System.Drawing.Size(553, 49);
            this.tableLayoutPanelOpenFolderDarkMode.TabIndex = 2;
            // 
            // pictureBoxOpenFolderDarkMode
            // 
            this.pictureBoxOpenFolderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxOpenFolderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOpenFolderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpenFolderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxOpenFolderDarkMode.Name = "pictureBoxOpenFolderDarkMode";
            this.pictureBoxOpenFolderDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxOpenFolderDarkMode.TabIndex = 1;
            this.pictureBoxOpenFolderDarkMode.TabStop = false;
            this.pictureBoxOpenFolderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelOpenFolderDarkMode
            // 
            this.labelOpenFolderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderDarkMode.AutoSize = true;
            this.labelOpenFolderDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelOpenFolderDarkMode.Name = "labelOpenFolderDarkMode";
            this.labelOpenFolderDarkMode.Size = new System.Drawing.Size(340, 37);
            this.labelOpenFolderDarkMode.TabIndex = 0;
            this.labelOpenFolderDarkMode.Text = "labelOpenFolderDarkMode";
            // 
            // textBoxColorOpenFolderDarkMode
            // 
            this.textBoxColorOpenFolderDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderDarkMode.MaxLength = 12;
            this.textBoxColorOpenFolderDarkMode.Name = "textBoxColorOpenFolderDarkMode";
            this.textBoxColorOpenFolderDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorOpenFolderDarkMode.TabIndex = 2;
            this.textBoxColorOpenFolderDarkMode.Text = "#ffffff";
            this.textBoxColorOpenFolderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorOpenFolderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelOpenFolderBorderDarkMode
            // 
            this.tableLayoutPanelOpenFolderBorderDarkMode.AutoSize = true;
            this.tableLayoutPanelOpenFolderBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOpenFolderBorderDarkMode.ColumnCount = 3;
            this.tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(this.pictureBoxOpenFolderBorderDarkMode, 0, 0);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(this.labelOpenFolderBorderDarkMode, 2, 0);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(this.textBoxColorOpenFolderBorderDarkMode, 1, 0);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(7, 477);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Name = "tableLayoutPanelOpenFolderBorderDarkMode";
            this.tableLayoutPanelOpenFolderBorderDarkMode.RowCount = 1;
            this.tableLayoutPanelOpenFolderBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(632, 49);
            this.tableLayoutPanelOpenFolderBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorderDarkMode
            // 
            this.pictureBoxOpenFolderBorderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxOpenFolderBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOpenFolderBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpenFolderBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxOpenFolderBorderDarkMode.Name = "pictureBoxOpenFolderBorderDarkMode";
            this.pictureBoxOpenFolderBorderDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxOpenFolderBorderDarkMode.TabIndex = 1;
            this.pictureBoxOpenFolderBorderDarkMode.TabStop = false;
            this.pictureBoxOpenFolderBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelOpenFolderBorderDarkMode
            // 
            this.labelOpenFolderBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderBorderDarkMode.AutoSize = true;
            this.labelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelOpenFolderBorderDarkMode.Name = "labelOpenFolderBorderDarkMode";
            this.labelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(419, 37);
            this.labelOpenFolderBorderDarkMode.TabIndex = 0;
            this.labelOpenFolderBorderDarkMode.Text = "labelOpenFolderBorderDarkMode";
            // 
            // textBoxColorOpenFolderBorderDarkMode
            // 
            this.textBoxColorOpenFolderBorderDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderBorderDarkMode.Name = "textBoxColorOpenFolderBorderDarkMode";
            this.textBoxColorOpenFolderBorderDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorOpenFolderBorderDarkMode.TabIndex = 2;
            this.textBoxColorOpenFolderBorderDarkMode.Text = "#ffffff";
            this.textBoxColorOpenFolderBorderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolderBorderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorOpenFolderBorderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelSelectedItemDarkMode
            // 
            this.tableLayoutPanelSelectedItemDarkMode.AutoSize = true;
            this.tableLayoutPanelSelectedItemDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSelectedItemDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelectedItemDarkMode.Controls.Add(this.pictureColorBoxSelectedItemDarkMode, 0, 0);
            this.tableLayoutPanelSelectedItemDarkMode.Controls.Add(this.labelSelectedItemDarkMode, 2, 0);
            this.tableLayoutPanelSelectedItemDarkMode.Controls.Add(this.textBoxColorSelecetedItemDarkMode, 1, 0);
            this.tableLayoutPanelSelectedItemDarkMode.Location = new System.Drawing.Point(7, 540);
            this.tableLayoutPanelSelectedItemDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSelectedItemDarkMode.Name = "tableLayoutPanelSelectedItemDarkMode";
            this.tableLayoutPanelSelectedItemDarkMode.RowCount = 1;
            this.tableLayoutPanelSelectedItemDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemDarkMode.Size = new System.Drawing.Size(566, 49);
            this.tableLayoutPanelSelectedItemDarkMode.TabIndex = 2;
            // 
            // pictureColorBoxSelectedItemDarkMode
            // 
            this.pictureColorBoxSelectedItemDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureColorBoxSelectedItemDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorBoxSelectedItemDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorBoxSelectedItemDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureColorBoxSelectedItemDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureColorBoxSelectedItemDarkMode.Name = "pictureColorBoxSelectedItemDarkMode";
            this.pictureColorBoxSelectedItemDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureColorBoxSelectedItemDarkMode.TabIndex = 1;
            this.pictureColorBoxSelectedItemDarkMode.TabStop = false;
            this.pictureColorBoxSelectedItemDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSelectedItemDarkMode
            // 
            this.labelSelectedItemDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemDarkMode.AutoSize = true;
            this.labelSelectedItemDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelSelectedItemDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSelectedItemDarkMode.Name = "labelSelectedItemDarkMode";
            this.labelSelectedItemDarkMode.Size = new System.Drawing.Size(353, 37);
            this.labelSelectedItemDarkMode.TabIndex = 0;
            this.labelSelectedItemDarkMode.Text = "labelSelectedItemDarkMode";
            // 
            // textBoxColorSelecetedItemDarkMode
            // 
            this.textBoxColorSelecetedItemDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSelecetedItemDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelecetedItemDarkMode.MaxLength = 12;
            this.textBoxColorSelecetedItemDarkMode.Name = "textBoxColorSelecetedItemDarkMode";
            this.textBoxColorSelecetedItemDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSelecetedItemDarkMode.TabIndex = 2;
            this.textBoxColorSelecetedItemDarkMode.Text = "#ffffff";
            this.textBoxColorSelecetedItemDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelecetedItemDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSelecetedItemDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelSelectedItemBorderDarkMode
            // 
            this.tableLayoutPanelSelectedItemBorderDarkMode.AutoSize = true;
            this.tableLayoutPanelSelectedItemBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSelectedItemBorderDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(this.pictureBoxSelectedItemBorderDarkMode, 0, 0);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(this.labelSelectedItemBorderDarkMode, 2, 0);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(this.textBoxColorSelectedItemBorderDarkMode, 1, 0);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(7, 603);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Name = "tableLayoutPanelSelectedItemBorderDarkMode";
            this.tableLayoutPanelSelectedItemBorderDarkMode.RowCount = 1;
            this.tableLayoutPanelSelectedItemBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(645, 49);
            this.tableLayoutPanelSelectedItemBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorderDarkMode
            // 
            this.pictureBoxSelectedItemBorderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSelectedItemBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSelectedItemBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSelectedItemBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSelectedItemBorderDarkMode.Name = "pictureBoxSelectedItemBorderDarkMode";
            this.pictureBoxSelectedItemBorderDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSelectedItemBorderDarkMode.TabIndex = 1;
            this.pictureBoxSelectedItemBorderDarkMode.TabStop = false;
            this.pictureBoxSelectedItemBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSelectedItemBorderDarkMode
            // 
            this.labelSelectedItemBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemBorderDarkMode.AutoSize = true;
            this.labelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSelectedItemBorderDarkMode.Name = "labelSelectedItemBorderDarkMode";
            this.labelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(432, 37);
            this.labelSelectedItemBorderDarkMode.TabIndex = 0;
            this.labelSelectedItemBorderDarkMode.Text = "labelSelectedItemBorderDarkMode";
            // 
            // textBoxColorSelectedItemBorderDarkMode
            // 
            this.textBoxColorSelectedItemBorderDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItemBorderDarkMode.MaxLength = 12;
            this.textBoxColorSelectedItemBorderDarkMode.Name = "textBoxColorSelectedItemBorderDarkMode";
            this.textBoxColorSelectedItemBorderDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSelectedItemBorderDarkMode.TabIndex = 2;
            this.textBoxColorSelectedItemBorderDarkMode.Text = "#ffffff";
            this.textBoxColorSelectedItemBorderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItemBorderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSelectedItemBorderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelWarningDarkMode
            // 
            this.tableLayoutPanelWarningDarkMode.AutoSize = true;
            this.tableLayoutPanelWarningDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelWarningDarkMode.ColumnCount = 3;
            this.tableLayoutPanelWarningDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelWarningDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelWarningDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWarningDarkMode.Controls.Add(this.pictureBoxWarningDarkMode, 0, 0);
            this.tableLayoutPanelWarningDarkMode.Controls.Add(this.labelWarningDarkMode, 2, 0);
            this.tableLayoutPanelWarningDarkMode.Controls.Add(this.textBoxColorWarningDarkMode, 1, 0);
            this.tableLayoutPanelWarningDarkMode.Location = new System.Drawing.Point(7, 666);
            this.tableLayoutPanelWarningDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelWarningDarkMode.Name = "tableLayoutPanelWarningDarkMode";
            this.tableLayoutPanelWarningDarkMode.RowCount = 1;
            this.tableLayoutPanelWarningDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWarningDarkMode.Size = new System.Drawing.Size(513, 49);
            this.tableLayoutPanelWarningDarkMode.TabIndex = 2;
            // 
            // pictureBoxWarningDarkMode
            // 
            this.pictureBoxWarningDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxWarningDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWarningDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWarningDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWarningDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWarningDarkMode.Name = "pictureBoxWarningDarkMode";
            this.pictureBoxWarningDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxWarningDarkMode.TabIndex = 1;
            this.pictureBoxWarningDarkMode.TabStop = false;
            this.pictureBoxWarningDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelWarningDarkMode
            // 
            this.labelWarningDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWarningDarkMode.AutoSize = true;
            this.labelWarningDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelWarningDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelWarningDarkMode.Name = "labelWarningDarkMode";
            this.labelWarningDarkMode.Size = new System.Drawing.Size(300, 37);
            this.labelWarningDarkMode.TabIndex = 0;
            this.labelWarningDarkMode.Text = "labelWarningDarkMode";
            // 
            // textBoxColorWarningDarkMode
            // 
            this.textBoxColorWarningDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorWarningDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorWarningDarkMode.MaxLength = 12;
            this.textBoxColorWarningDarkMode.Name = "textBoxColorWarningDarkMode";
            this.textBoxColorWarningDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorWarningDarkMode.TabIndex = 2;
            this.textBoxColorWarningDarkMode.Text = "#ffffff";
            this.textBoxColorWarningDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorWarningDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorWarningDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelScrollbarDarkMode
            // 
            this.labelScrollbarDarkMode.AutoSize = true;
            this.labelScrollbarDarkMode.Location = new System.Drawing.Point(7, 722);
            this.labelScrollbarDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelScrollbarDarkMode.Name = "labelScrollbarDarkMode";
            this.labelScrollbarDarkMode.Size = new System.Drawing.Size(304, 37);
            this.labelScrollbarDarkMode.TabIndex = 3;
            this.labelScrollbarDarkMode.Text = "labelScrollbarDarkMode";
            // 
            // tableLayoutPanelScrollbarBackgroundDarkMode
            // 
            this.tableLayoutPanelScrollbarBackgroundDarkMode.AutoSize = true;
            this.tableLayoutPanelScrollbarBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelScrollbarBackgroundDarkMode.ColumnCount = 3;
            this.tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(this.pictureBoxScrollbarBackgroundDarkMode, 0, 0);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(this.textBoxColorScrollbarBackgroundDarkMode, 1, 0);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(this.labelColorDarkModeScrollbarBackground, 2, 0);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(7, 766);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Name = "tableLayoutPanelScrollbarBackgroundDarkMode";
            this.tableLayoutPanelScrollbarBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelScrollbarBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(723, 49);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackgroundDarkMode
            // 
            this.pictureBoxScrollbarBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxScrollbarBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScrollbarBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxScrollbarBackgroundDarkMode.Name = "pictureBoxScrollbarBackgroundDarkMode";
            this.pictureBoxScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxScrollbarBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxScrollbarBackgroundDarkMode.TabStop = false;
            this.pictureBoxScrollbarBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorScrollbarBackgroundDarkMode
            // 
            this.textBoxColorScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorScrollbarBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorScrollbarBackgroundDarkMode.Name = "textBoxColorScrollbarBackgroundDarkMode";
            this.textBoxColorScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorScrollbarBackgroundDarkMode.TabIndex = 2;
            this.textBoxColorScrollbarBackgroundDarkMode.Text = "#ffffff";
            this.textBoxColorScrollbarBackgroundDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorScrollbarBackgroundDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorScrollbarBackgroundDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeScrollbarBackground
            // 
            this.labelColorDarkModeScrollbarBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeScrollbarBackground.AutoSize = true;
            this.labelColorDarkModeScrollbarBackground.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeScrollbarBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeScrollbarBackground.Name = "labelColorDarkModeScrollbarBackground";
            this.labelColorDarkModeScrollbarBackground.Size = new System.Drawing.Size(510, 37);
            this.labelColorDarkModeScrollbarBackground.TabIndex = 0;
            this.labelColorDarkModeScrollbarBackground.Text = "labelColorDarkModeScrollbarBackground";
            // 
            // tableLayoutPanelSliderDarkMode
            // 
            this.tableLayoutPanelSliderDarkMode.AutoSize = true;
            this.tableLayoutPanelSliderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderDarkMode.Controls.Add(this.pictureBoxSliderDarkMode, 0, 0);
            this.tableLayoutPanelSliderDarkMode.Controls.Add(this.textBoxColorSliderDarkMode, 1, 0);
            this.tableLayoutPanelSliderDarkMode.Controls.Add(this.labelColorDarkModeSlider, 2, 0);
            this.tableLayoutPanelSliderDarkMode.Location = new System.Drawing.Point(7, 829);
            this.tableLayoutPanelSliderDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderDarkMode.Name = "tableLayoutPanelSliderDarkMode";
            this.tableLayoutPanelSliderDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDarkMode.Size = new System.Drawing.Size(545, 49);
            this.tableLayoutPanelSliderDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderDarkMode
            // 
            this.pictureBoxSliderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderDarkMode.Name = "pictureBoxSliderDarkMode";
            this.pictureBoxSliderDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderDarkMode.TabIndex = 1;
            this.pictureBoxSliderDarkMode.TabStop = false;
            this.pictureBoxSliderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDarkMode
            // 
            this.textBoxColorSliderDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDarkMode.MaxLength = 12;
            this.textBoxColorSliderDarkMode.Name = "textBoxColorSliderDarkMode";
            this.textBoxColorSliderDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderDarkMode.TabIndex = 2;
            this.textBoxColorSliderDarkMode.Text = "#ffffff";
            this.textBoxColorSliderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeSlider
            // 
            this.labelColorDarkModeSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeSlider.AutoSize = true;
            this.labelColorDarkModeSlider.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeSlider.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeSlider.Name = "labelColorDarkModeSlider";
            this.labelColorDarkModeSlider.Size = new System.Drawing.Size(332, 37);
            this.labelColorDarkModeSlider.TabIndex = 0;
            this.labelColorDarkModeSlider.Text = "labelColorDarkModeSlider";
            // 
            // tableLayoutPanelSliderDraggingDarkMode
            // 
            this.tableLayoutPanelSliderDraggingDarkMode.AutoSize = true;
            this.tableLayoutPanelSliderDraggingDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderDraggingDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderDraggingDarkMode.Controls.Add(this.pictureBoxSliderDraggingDarkMode, 0, 0);
            this.tableLayoutPanelSliderDraggingDarkMode.Controls.Add(this.textBoxColorSliderDraggingDarkMode, 1, 0);
            this.tableLayoutPanelSliderDraggingDarkMode.Controls.Add(this.labelColorDarkModeSliderDragging, 2, 0);
            this.tableLayoutPanelSliderDraggingDarkMode.Location = new System.Drawing.Point(7, 892);
            this.tableLayoutPanelSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderDraggingDarkMode.Name = "tableLayoutPanelSliderDraggingDarkMode";
            this.tableLayoutPanelSliderDraggingDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderDraggingDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDraggingDarkMode.Size = new System.Drawing.Size(657, 49);
            this.tableLayoutPanelSliderDraggingDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderDraggingDarkMode
            // 
            this.pictureBoxSliderDraggingDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderDraggingDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderDraggingDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderDraggingDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderDraggingDarkMode.Name = "pictureBoxSliderDraggingDarkMode";
            this.pictureBoxSliderDraggingDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderDraggingDarkMode.TabIndex = 1;
            this.pictureBoxSliderDraggingDarkMode.TabStop = false;
            this.pictureBoxSliderDraggingDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDraggingDarkMode
            // 
            this.textBoxColorSliderDraggingDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDraggingDarkMode.MaxLength = 12;
            this.textBoxColorSliderDraggingDarkMode.Name = "textBoxColorSliderDraggingDarkMode";
            this.textBoxColorSliderDraggingDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderDraggingDarkMode.TabIndex = 2;
            this.textBoxColorSliderDraggingDarkMode.Text = "#ffffff";
            this.textBoxColorSliderDraggingDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderDraggingDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderDraggingDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeSliderDragging
            // 
            this.labelColorDarkModeSliderDragging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeSliderDragging.AutoSize = true;
            this.labelColorDarkModeSliderDragging.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeSliderDragging.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeSliderDragging.Name = "labelColorDarkModeSliderDragging";
            this.labelColorDarkModeSliderDragging.Size = new System.Drawing.Size(444, 37);
            this.labelColorDarkModeSliderDragging.TabIndex = 0;
            this.labelColorDarkModeSliderDragging.Text = "labelColorDarkModeSliderDragging";
            // 
            // tableLayoutPanelSliderHoverDarkMode
            // 
            this.tableLayoutPanelSliderHoverDarkMode.AutoSize = true;
            this.tableLayoutPanelSliderHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderHoverDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderHoverDarkMode.Controls.Add(this.pictureBoxSliderHoverDarkMode, 0, 0);
            this.tableLayoutPanelSliderHoverDarkMode.Controls.Add(this.textBoxColorSliderHoverDarkMode, 1, 0);
            this.tableLayoutPanelSliderHoverDarkMode.Controls.Add(this.labelColorDarkModeSliderHover, 2, 0);
            this.tableLayoutPanelSliderHoverDarkMode.Location = new System.Drawing.Point(7, 955);
            this.tableLayoutPanelSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderHoverDarkMode.Name = "tableLayoutPanelSliderHoverDarkMode";
            this.tableLayoutPanelSliderHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderHoverDarkMode.Size = new System.Drawing.Size(616, 49);
            this.tableLayoutPanelSliderHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderHoverDarkMode
            // 
            this.pictureBoxSliderHoverDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderHoverDarkMode.Name = "pictureBoxSliderHoverDarkMode";
            this.pictureBoxSliderHoverDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderHoverDarkMode.TabIndex = 1;
            this.pictureBoxSliderHoverDarkMode.TabStop = false;
            this.pictureBoxSliderHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderHoverDarkMode
            // 
            this.textBoxColorSliderHoverDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderHoverDarkMode.MaxLength = 12;
            this.textBoxColorSliderHoverDarkMode.Name = "textBoxColorSliderHoverDarkMode";
            this.textBoxColorSliderHoverDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderHoverDarkMode.TabIndex = 2;
            this.textBoxColorSliderHoverDarkMode.Text = "#ffffff";
            this.textBoxColorSliderHoverDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderHoverDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderHoverDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeSliderHover
            // 
            this.labelColorDarkModeSliderHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeSliderHover.AutoSize = true;
            this.labelColorDarkModeSliderHover.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeSliderHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeSliderHover.Name = "labelColorDarkModeSliderHover";
            this.labelColorDarkModeSliderHover.Size = new System.Drawing.Size(403, 37);
            this.labelColorDarkModeSliderHover.TabIndex = 0;
            this.labelColorDarkModeSliderHover.Text = "labelColorDarkModeSliderHover";
            // 
            // tableLayoutPanelSliderArrowsAndTrackHoverDarkMode
            // 
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.AutoSize = true;
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnCount = 3;
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(this.pictureBoxSliderArrowsAndTrackHoverDarkMode, 0, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(this.textBoxColorSliderArrowsAndTrackHoverDarkMode, 1, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(this.labelColorDarkModeSliderArrowsAndTrackHover, 2, 0);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(7, 1018);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Name = "tableLayoutPanelSliderArrowsAndTrackHoverDarkMode";
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(806, 49);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHoverDarkMode
            // 
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Name = "pictureBoxSliderArrowsAndTrackHoverDarkMode";
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.TabIndex = 1;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.TabStop = false;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderArrowsAndTrackHoverDarkMode
            // 
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.MaxLength = 12;
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Name = "textBoxColorSliderArrowsAndTrackHoverDarkMode";
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.TabIndex = 2;
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Text = "#ffffff";
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeSliderArrowsAndTrackHover
            // 
            this.labelColorDarkModeSliderArrowsAndTrackHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeSliderArrowsAndTrackHover.AutoSize = true;
            this.labelColorDarkModeSliderArrowsAndTrackHover.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeSliderArrowsAndTrackHover.Name = "labelColorDarkModeSliderArrowsAndTrackHover";
            this.labelColorDarkModeSliderArrowsAndTrackHover.Size = new System.Drawing.Size(593, 37);
            this.labelColorDarkModeSliderArrowsAndTrackHover.TabIndex = 0;
            this.labelColorDarkModeSliderArrowsAndTrackHover.Text = "labelColorDarkModeSliderArrowsAndTrackHover";
            // 
            // tableLayoutPanelArrowDarkMode
            // 
            this.tableLayoutPanelArrowDarkMode.AutoSize = true;
            this.tableLayoutPanelArrowDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowDarkMode.ColumnCount = 3;
            this.tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowDarkMode.Controls.Add(this.pictureBoxArrowDarkMode, 0, 0);
            this.tableLayoutPanelArrowDarkMode.Controls.Add(this.textBoxColorArrowDarkMode, 1, 0);
            this.tableLayoutPanelArrowDarkMode.Controls.Add(this.labelColorDarkModeArrow, 2, 0);
            this.tableLayoutPanelArrowDarkMode.Location = new System.Drawing.Point(7, 1081);
            this.tableLayoutPanelArrowDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowDarkMode.Name = "tableLayoutPanelArrowDarkMode";
            this.tableLayoutPanelArrowDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowDarkMode.Size = new System.Drawing.Size(549, 49);
            this.tableLayoutPanelArrowDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowDarkMode
            // 
            this.pictureBoxArrowDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowDarkMode.Name = "pictureBoxArrowDarkMode";
            this.pictureBoxArrowDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowDarkMode.TabIndex = 1;
            this.pictureBoxArrowDarkMode.TabStop = false;
            this.pictureBoxArrowDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowDarkMode
            // 
            this.textBoxColorArrowDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowDarkMode.MaxLength = 12;
            this.textBoxColorArrowDarkMode.Name = "textBoxColorArrowDarkMode";
            this.textBoxColorArrowDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowDarkMode.TabIndex = 2;
            this.textBoxColorArrowDarkMode.Text = "#ffffff";
            this.textBoxColorArrowDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeArrow
            // 
            this.labelColorDarkModeArrow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrow.AutoSize = true;
            this.labelColorDarkModeArrow.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeArrow.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeArrow.Name = "labelColorDarkModeArrow";
            this.labelColorDarkModeArrow.Size = new System.Drawing.Size(336, 37);
            this.labelColorDarkModeArrow.TabIndex = 0;
            this.labelColorDarkModeArrow.Text = "labelColorDarkModeArrow";
            // 
            // tableLayoutPanelArrowClickDarkMode
            // 
            this.tableLayoutPanelArrowClickDarkMode.AutoSize = true;
            this.tableLayoutPanelArrowClickDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowClickDarkMode.ColumnCount = 3;
            this.tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowClickDarkMode.Controls.Add(this.pictureBoxArrowClickDarkMode, 0, 0);
            this.tableLayoutPanelArrowClickDarkMode.Controls.Add(this.textBoxColorArrowClickDarkMode, 1, 0);
            this.tableLayoutPanelArrowClickDarkMode.Controls.Add(this.labelColorDarkModeArrowClick, 2, 0);
            this.tableLayoutPanelArrowClickDarkMode.Location = new System.Drawing.Point(7, 1144);
            this.tableLayoutPanelArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowClickDarkMode.Name = "tableLayoutPanelArrowClickDarkMode";
            this.tableLayoutPanelArrowClickDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowClickDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickDarkMode.Size = new System.Drawing.Size(605, 49);
            this.tableLayoutPanelArrowClickDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowClickDarkMode
            // 
            this.pictureBoxArrowClickDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowClickDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowClickDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowClickDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowClickDarkMode.Name = "pictureBoxArrowClickDarkMode";
            this.pictureBoxArrowClickDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowClickDarkMode.TabIndex = 1;
            this.pictureBoxArrowClickDarkMode.TabStop = false;
            this.pictureBoxArrowClickDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickDarkMode
            // 
            this.textBoxColorArrowClickDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickDarkMode.MaxLength = 12;
            this.textBoxColorArrowClickDarkMode.Name = "textBoxColorArrowClickDarkMode";
            this.textBoxColorArrowClickDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowClickDarkMode.TabIndex = 2;
            this.textBoxColorArrowClickDarkMode.Text = "#ffffff";
            this.textBoxColorArrowClickDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowClickDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowClickDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeArrowClick
            // 
            this.labelColorDarkModeArrowClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrowClick.AutoSize = true;
            this.labelColorDarkModeArrowClick.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeArrowClick.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeArrowClick.Name = "labelColorDarkModeArrowClick";
            this.labelColorDarkModeArrowClick.Size = new System.Drawing.Size(392, 37);
            this.labelColorDarkModeArrowClick.TabIndex = 0;
            this.labelColorDarkModeArrowClick.Text = "labelColorDarkModeArrowClick";
            // 
            // tableLayoutPanelArrowClickBackgroundDarkMode
            // 
            this.tableLayoutPanelArrowClickBackgroundDarkMode.AutoSize = true;
            this.tableLayoutPanelArrowClickBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowClickBackgroundDarkMode.ColumnCount = 3;
            this.tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(this.pictureBoxArrowClickBackgroundDarkMode, 0, 0);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(this.textBoxColorArrowClickBackgroundDarkMode, 1, 0);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(this.labelColorDarkModeArrowClickBackground, 2, 0);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(7, 1207);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Name = "tableLayoutPanelArrowClickBackgroundDarkMode";
            this.tableLayoutPanelArrowClickBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowClickBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(746, 49);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackgroundDarkMode
            // 
            this.pictureBoxArrowClickBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowClickBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowClickBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowClickBackgroundDarkMode.Name = "pictureBoxArrowClickBackgroundDarkMode";
            this.pictureBoxArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowClickBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxArrowClickBackgroundDarkMode.TabStop = false;
            this.pictureBoxArrowClickBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickBackgroundDarkMode
            // 
            this.textBoxColorArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorArrowClickBackgroundDarkMode.Name = "textBoxColorArrowClickBackgroundDarkMode";
            this.textBoxColorArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowClickBackgroundDarkMode.TabIndex = 2;
            this.textBoxColorArrowClickBackgroundDarkMode.Text = "#ffffff";
            this.textBoxColorArrowClickBackgroundDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowClickBackgroundDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowClickBackgroundDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeArrowClickBackground
            // 
            this.labelColorDarkModeArrowClickBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrowClickBackground.AutoSize = true;
            this.labelColorDarkModeArrowClickBackground.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeArrowClickBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeArrowClickBackground.Name = "labelColorDarkModeArrowClickBackground";
            this.labelColorDarkModeArrowClickBackground.Size = new System.Drawing.Size(533, 37);
            this.labelColorDarkModeArrowClickBackground.TabIndex = 0;
            this.labelColorDarkModeArrowClickBackground.Text = "labelColorDarkModeArrowClickBackground";
            // 
            // tableLayoutPanelArrowHoverDarkMode
            // 
            this.tableLayoutPanelArrowHoverDarkMode.AutoSize = true;
            this.tableLayoutPanelArrowHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowHoverDarkMode.ColumnCount = 3;
            this.tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowHoverDarkMode.Controls.Add(this.pictureBoxArrowHoverDarkMode, 0, 0);
            this.tableLayoutPanelArrowHoverDarkMode.Controls.Add(this.textBoxColorArrowHoverDarkMode, 1, 0);
            this.tableLayoutPanelArrowHoverDarkMode.Controls.Add(this.labelColorDarkModeArrowHover, 2, 0);
            this.tableLayoutPanelArrowHoverDarkMode.Location = new System.Drawing.Point(7, 1270);
            this.tableLayoutPanelArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowHoverDarkMode.Name = "tableLayoutPanelArrowHoverDarkMode";
            this.tableLayoutPanelArrowHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverDarkMode.Size = new System.Drawing.Size(620, 49);
            this.tableLayoutPanelArrowHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowHoverDarkMode
            // 
            this.pictureBoxArrowHoverDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowHoverDarkMode.Name = "pictureBoxArrowHoverDarkMode";
            this.pictureBoxArrowHoverDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowHoverDarkMode.TabIndex = 1;
            this.pictureBoxArrowHoverDarkMode.TabStop = false;
            this.pictureBoxArrowHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverDarkMode
            // 
            this.textBoxColorArrowHoverDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverDarkMode.MaxLength = 12;
            this.textBoxColorArrowHoverDarkMode.Name = "textBoxColorArrowHoverDarkMode";
            this.textBoxColorArrowHoverDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowHoverDarkMode.TabIndex = 2;
            this.textBoxColorArrowHoverDarkMode.Text = "#ffffff";
            this.textBoxColorArrowHoverDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowHoverDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowHoverDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeArrowHover
            // 
            this.labelColorDarkModeArrowHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrowHover.AutoSize = true;
            this.labelColorDarkModeArrowHover.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeArrowHover.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeArrowHover.Name = "labelColorDarkModeArrowHover";
            this.labelColorDarkModeArrowHover.Size = new System.Drawing.Size(407, 37);
            this.labelColorDarkModeArrowHover.TabIndex = 0;
            this.labelColorDarkModeArrowHover.Text = "labelColorDarkModeArrowHover";
            // 
            // tableLayoutPanelArrowHoverBackgroundDarkMode
            // 
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.AutoSize = true;
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnCount = 3;
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(this.pictureBoxArrowHoverBackgroundDarkMode, 0, 0);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(this.textBoxColorArrowHoverBackgroundDarkMode, 1, 0);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(this.labelColorDarkModeArrowHoverBackground, 2, 0);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(7, 1333);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Name = "tableLayoutPanelArrowHoverBackgroundDarkMode";
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(761, 49);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackgroundDarkMode
            // 
            this.pictureBoxArrowHoverBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxArrowHoverBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxArrowHoverBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArrowHoverBackgroundDarkMode.Name = "pictureBoxArrowHoverBackgroundDarkMode";
            this.pictureBoxArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxArrowHoverBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxArrowHoverBackgroundDarkMode.TabStop = false;
            this.pictureBoxArrowHoverBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverBackgroundDarkMode
            // 
            this.textBoxColorArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorArrowHoverBackgroundDarkMode.Name = "textBoxColorArrowHoverBackgroundDarkMode";
            this.textBoxColorArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorArrowHoverBackgroundDarkMode.TabIndex = 2;
            this.textBoxColorArrowHoverBackgroundDarkMode.Text = "#ffffff";
            this.textBoxColorArrowHoverBackgroundDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorArrowHoverBackgroundDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorArrowHoverBackgroundDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelColorDarkModeArrowHoverBackground
            // 
            this.labelColorDarkModeArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrowHoverBackground.AutoSize = true;
            this.labelColorDarkModeArrowHoverBackground.Location = new System.Drawing.Point(206, 6);
            this.labelColorDarkModeArrowHoverBackground.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelColorDarkModeArrowHoverBackground.MaximumSize = new System.Drawing.Size(630, 0);
            this.labelColorDarkModeArrowHoverBackground.Name = "labelColorDarkModeArrowHoverBackground";
            this.labelColorDarkModeArrowHoverBackground.Size = new System.Drawing.Size(548, 37);
            this.labelColorDarkModeArrowHoverBackground.TabIndex = 0;
            this.labelColorDarkModeArrowHoverBackground.Text = "labelColorDarkModeArrowHoverBackground";
            // 
            // buttonColorsDefaultDarkMode
            // 
            this.buttonColorsDefaultDarkMode.AutoSize = true;
            this.buttonColorsDefaultDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColorsDefaultDarkMode.Location = new System.Drawing.Point(7, 1396);
            this.buttonColorsDefaultDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.buttonColorsDefaultDarkMode.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonColorsDefaultDarkMode.Name = "buttonColorsDefaultDarkMode";
            this.buttonColorsDefaultDarkMode.Size = new System.Drawing.Size(394, 52);
            this.buttonColorsDefaultDarkMode.TabIndex = 2;
            this.buttonColorsDefaultDarkMode.Text = "buttonColorsDarkModeDefault";
            this.buttonColorsDefaultDarkMode.UseVisualStyleBackColor = true;
            this.buttonColorsDefaultDarkMode.Click += new System.EventHandler(this.ButtonDefaultColorsDark_Click);
            // 
            // tableLayoutPanelTitleDarkMode
            // 
            this.tableLayoutPanelTitleDarkMode.AutoSize = true;
            this.tableLayoutPanelTitleDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTitleDarkMode.ColumnCount = 3;
            this.tableLayoutPanelTitleDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitleDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitleDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitleDarkMode.Controls.Add(this.pictureBoxTitleDarkMode, 0, 0);
            this.tableLayoutPanelTitleDarkMode.Controls.Add(this.labelTitleDarkMode, 2, 0);
            this.tableLayoutPanelTitleDarkMode.Controls.Add(this.textBoxColorTitleDarkMode, 1, 0);
            this.tableLayoutPanelTitleDarkMode.Location = new System.Drawing.Point(7, 99);
            this.tableLayoutPanelTitleDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelTitleDarkMode.Name = "tableLayoutPanelTitleDarkMode";
            this.tableLayoutPanelTitleDarkMode.RowCount = 1;
            this.tableLayoutPanelTitleDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTitleDarkMode.Size = new System.Drawing.Size(464, 49);
            this.tableLayoutPanelTitleDarkMode.TabIndex = 2;
            // 
            // pictureBoxTitleDarkMode
            // 
            this.pictureBoxTitleDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxTitleDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitleDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTitleDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitleDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTitleDarkMode.Name = "pictureBoxTitleDarkMode";
            this.pictureBoxTitleDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxTitleDarkMode.TabIndex = 1;
            this.pictureBoxTitleDarkMode.TabStop = false;
            this.pictureBoxTitleDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelTitleDarkMode
            // 
            this.labelTitleDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitleDarkMode.AutoSize = true;
            this.labelTitleDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelTitleDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTitleDarkMode.Name = "labelTitleDarkMode";
            this.labelTitleDarkMode.Size = new System.Drawing.Size(251, 37);
            this.labelTitleDarkMode.TabIndex = 0;
            this.labelTitleDarkMode.Text = "labelTitleDarkMode";
            // 
            // textBoxColorTitleDarkMode
            // 
            this.textBoxColorTitleDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorTitleDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorTitleDarkMode.MaxLength = 12;
            this.textBoxColorTitleDarkMode.Name = "textBoxColorTitleDarkMode";
            this.textBoxColorTitleDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorTitleDarkMode.TabIndex = 2;
            this.textBoxColorTitleDarkMode.Text = "#ffffff";
            this.textBoxColorTitleDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorTitleDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorTitleDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelBackgroundDarkMode
            // 
            this.tableLayoutPanelBackgroundDarkMode.AutoSize = true;
            this.tableLayoutPanelBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBackgroundDarkMode.ColumnCount = 3;
            this.tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackgroundDarkMode.Controls.Add(this.pictureBoxBackgroundDarkMode, 0, 0);
            this.tableLayoutPanelBackgroundDarkMode.Controls.Add(this.labelBackgroundDarkMode, 2, 0);
            this.tableLayoutPanelBackgroundDarkMode.Controls.Add(this.textBoxColorBackgroundDarkMode, 1, 0);
            this.tableLayoutPanelBackgroundDarkMode.Location = new System.Drawing.Point(7, 225);
            this.tableLayoutPanelBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelBackgroundDarkMode.Name = "tableLayoutPanelBackgroundDarkMode";
            this.tableLayoutPanelBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundDarkMode.Size = new System.Drawing.Size(554, 49);
            this.tableLayoutPanelBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxBackgroundDarkMode
            // 
            this.pictureBoxBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackgroundDarkMode.Name = "pictureBoxBackgroundDarkMode";
            this.pictureBoxBackgroundDarkMode.Size = new System.Drawing.Size(49, 49);
            this.pictureBoxBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxBackgroundDarkMode.TabStop = false;
            this.pictureBoxBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelBackgroundDarkMode
            // 
            this.labelBackgroundDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackgroundDarkMode.AutoSize = true;
            this.labelBackgroundDarkMode.Location = new System.Drawing.Point(206, 6);
            this.labelBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelBackgroundDarkMode.Name = "labelBackgroundDarkMode";
            this.labelBackgroundDarkMode.Size = new System.Drawing.Size(341, 37);
            this.labelBackgroundDarkMode.TabIndex = 0;
            this.labelBackgroundDarkMode.Text = "labelBackgroundDarkMode";
            // 
            // textBoxColorBackgroundDarkMode
            // 
            this.textBoxColorBackgroundDarkMode.Location = new System.Drawing.Point(49, 0);
            this.textBoxColorBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorBackgroundDarkMode.Name = "textBoxColorBackgroundDarkMode";
            this.textBoxColorBackgroundDarkMode.Size = new System.Drawing.Size(150, 43);
            this.textBoxColorBackgroundDarkMode.TabIndex = 2;
            this.textBoxColorBackgroundDarkMode.Text = "#ffffff";
            this.textBoxColorBackgroundDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackgroundDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackgroundDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelBottom.AutoSize = true;
            this.tableLayoutPanelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBottom.ColumnCount = 3;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.Controls.Add(this.buttonOk, 1, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(7, 1101);
            this.tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(964, 52);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(601, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonOk.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(169, 52);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(784, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(7, 0, 11, 0);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(169, 52);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(169, 52);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(3339, 2383);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tableLayoutPanelGeneral.ResumeLayout(false);
            this.tableLayoutPanelGeneral.PerformLayout();
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
            this.tableLayoutPanelFolder.ResumeLayout(false);
            this.tableLayoutPanelFolder.PerformLayout();
            this.tableLayoutPanelChangeFolder.ResumeLayout(false);
            this.tableLayoutPanelChangeFolder.PerformLayout();
            this.groupBoxUSB.ResumeLayout(false);
            this.groupBoxUSB.PerformLayout();
            this.tableLayoutPanelUSB.ResumeLayout(false);
            this.tableLayoutPanelUSB.PerformLayout();
            this.tableLayoutPanelRelativeFolderOpenAssembly.ResumeLayout(false);
            this.tableLayoutPanelRelativeFolderOpenAssembly.PerformLayout();
            this.groupBoxAutostart.ResumeLayout(false);
            this.groupBoxAutostart.PerformLayout();
            this.tableLayoutPanelAutostart.ResumeLayout(false);
            this.tableLayoutPanelAutostart.PerformLayout();
            this.groupBoxHotkey.ResumeLayout(false);
            this.groupBoxHotkey.PerformLayout();
            this.tableLayoutPanelHotkey.ResumeLayout(false);
            this.tableLayoutPanelHotkey.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxLanguage.PerformLayout();
            this.tableLayoutPanelLanguage.ResumeLayout(false);
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.tableLayoutPanelAdvanced.ResumeLayout(false);
            this.tableLayoutPanelAdvanced.PerformLayout();
            this.groupBoxClick.ResumeLayout(false);
            this.groupBoxClick.PerformLayout();
            this.tableLayoutPanelClick.ResumeLayout(false);
            this.tableLayoutPanelClick.PerformLayout();
            this.groupBoxSizeAndLocation.ResumeLayout(false);
            this.groupBoxSizeAndLocation.PerformLayout();
            this.tableLayoutPanelSizeAndLocation.ResumeLayout(false);
            this.tableLayoutPanelSizeAndLocation.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeInPercentage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuHeight)).EndInit();
            this.tableLayoutPanelMaxMenuWidth.ResumeLayout(false);
            this.tableLayoutPanelMaxMenuWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).EndInit();
            this.groupBoxStaysOpen.ResumeLayout(false);
            this.groupBoxStaysOpen.PerformLayout();
            this.tableLayoutPanelStaysOpen.ResumeLayout(false);
            this.tableLayoutPanelStaysOpen.PerformLayout();
            this.tableLayoutPanelTimeUntilCloses.ResumeLayout(false);
            this.tableLayoutPanelTimeUntilCloses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClose)).EndInit();
            this.groupBoxOpenSubmenus.ResumeLayout(false);
            this.groupBoxOpenSubmenus.PerformLayout();
            this.tableLayoutPanelTimeUntilOpen.ResumeLayout(false);
            this.tableLayoutPanelTimeUntilOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilOpens)).EndInit();
            this.tabPageCustomize.ResumeLayout(false);
            this.tabPageCustomize.PerformLayout();
            this.tableLayoutPanelCustomize.ResumeLayout(false);
            this.tableLayoutPanelCustomize.PerformLayout();
            this.groupBoxColorsLightMode.ResumeLayout(false);
            this.groupBoxColorsLightMode.PerformLayout();
            this.tableLayoutPanelColorsAndDefault.ResumeLayout(false);
            this.tableLayoutPanelColorsAndDefault.PerformLayout();
            this.tableLayoutPanelIcons.ResumeLayout(false);
            this.tableLayoutPanelIcons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcons)).EndInit();
            this.tableLayoutPanelBackgroundBorder.ResumeLayout(false);
            this.tableLayoutPanelBackgroundBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundBorder)).EndInit();
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.tableLayoutPanelBackground.ResumeLayout(false);
            this.tableLayoutPanelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.tableLayoutPanelArrowHoverBackground.ResumeLayout(false);
            this.tableLayoutPanelArrowHoverBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackground)).EndInit();
            this.tableLayoutPanelArrowHover.ResumeLayout(false);
            this.tableLayoutPanelArrowHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHover)).EndInit();
            this.tableLayoutPanelArrowClickBackground.ResumeLayout(false);
            this.tableLayoutPanelArrowClickBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackground)).EndInit();
            this.tableLayoutPanelArrowClick.ResumeLayout(false);
            this.tableLayoutPanelArrowClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClick)).EndInit();
            this.tableLayoutPanelArrow.ResumeLayout(false);
            this.tableLayoutPanelArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).EndInit();
            this.tableLayoutPanelSliderArrowsAndTrackHover.ResumeLayout(false);
            this.tableLayoutPanelSliderArrowsAndTrackHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHover)).EndInit();
            this.tableLayoutPanelSliderHover.ResumeLayout(false);
            this.tableLayoutPanelSliderHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHover)).EndInit();
            this.tableLayoutPanelSliderDragging.ResumeLayout(false);
            this.tableLayoutPanelSliderDragging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDragging)).EndInit();
            this.tableLayoutPanelSlider.ResumeLayout(false);
            this.tableLayoutPanelSlider.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).EndInit();
            this.tableLayoutPanelScrollbarBackground.ResumeLayout(false);
            this.tableLayoutPanelScrollbarBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackground)).EndInit();
            this.tableLayoutPanelWarning.ResumeLayout(false);
            this.tableLayoutPanelWarning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.tableLayoutPanelSelectedItemBorder.ResumeLayout(false);
            this.tableLayoutPanelSelectedItemBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorder)).EndInit();
            this.tableLayoutPanelSelectedItem.ResumeLayout(false);
            this.tableLayoutPanelSelectedItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItem)).EndInit();
            this.tableLayoutPanelOpenFolderBorder.ResumeLayout(false);
            this.tableLayoutPanelOpenFolderBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorder)).EndInit();
            this.tableLayoutPanelOpenFolder.ResumeLayout(false);
            this.tableLayoutPanelOpenFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).EndInit();
            this.tableLayoutPanelSearchField.ResumeLayout(false);
            this.tableLayoutPanelSearchField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchField)).EndInit();
            this.groupBoxColorsDarkMode.ResumeLayout(false);
            this.groupBoxColorsDarkMode.PerformLayout();
            this.tableLayoutPanelDarkMode.ResumeLayout(false);
            this.tableLayoutPanelDarkMode.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconsDarkMode)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundBorderDarkMode)).EndInit();
            this.tableLayoutPanelSearchFieldDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSearchFieldDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFieldDarkMode)).EndInit();
            this.tableLayoutPanelOpenFolderDarkMode.ResumeLayout(false);
            this.tableLayoutPanelOpenFolderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderDarkMode)).EndInit();
            this.tableLayoutPanelOpenFolderBorderDarkMode.ResumeLayout(false);
            this.tableLayoutPanelOpenFolderBorderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorderDarkMode)).EndInit();
            this.tableLayoutPanelSelectedItemDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSelectedItemDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorBoxSelectedItemDarkMode)).EndInit();
            this.tableLayoutPanelSelectedItemBorderDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSelectedItemBorderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorderDarkMode)).EndInit();
            this.tableLayoutPanelWarningDarkMode.ResumeLayout(false);
            this.tableLayoutPanelWarningDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningDarkMode)).EndInit();
            this.tableLayoutPanelScrollbarBackgroundDarkMode.ResumeLayout(false);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackgroundDarkMode)).EndInit();
            this.tableLayoutPanelSliderDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSliderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDarkMode)).EndInit();
            this.tableLayoutPanelSliderDraggingDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSliderDraggingDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDraggingDarkMode)).EndInit();
            this.tableLayoutPanelSliderHoverDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSliderHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHoverDarkMode)).EndInit();
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ResumeLayout(false);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHoverDarkMode)).EndInit();
            this.tableLayoutPanelArrowDarkMode.ResumeLayout(false);
            this.tableLayoutPanelArrowDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDarkMode)).EndInit();
            this.tableLayoutPanelArrowClickDarkMode.ResumeLayout(false);
            this.tableLayoutPanelArrowClickDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickDarkMode)).EndInit();
            this.tableLayoutPanelArrowClickBackgroundDarkMode.ResumeLayout(false);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackgroundDarkMode)).EndInit();
            this.tableLayoutPanelArrowHoverDarkMode.ResumeLayout(false);
            this.tableLayoutPanelArrowHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverDarkMode)).EndInit();
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.ResumeLayout(false);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackgroundDarkMode)).EndInit();
            this.tableLayoutPanelTitleDarkMode.ResumeLayout(false);
            this.tableLayoutPanelTitleDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleDarkMode)).EndInit();
            this.tableLayoutPanelBackgroundDarkMode.ResumeLayout(false);
            this.tableLayoutPanelBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).EndInit();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        //private System.Windows.Forms.TextBox textBoxHotkey;
        private HotkeyControl textBoxHotkey;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.Button buttonChangeFolder;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPageCustomize;
        private System.Windows.Forms.CheckBox checkBoxOpenItemWithOneClick;
        private System.Windows.Forms.CheckBox checkBoxDarkModeAlwaysOn;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.Label labelMaxMenuWidth;
        private System.Windows.Forms.Label labelTimeUntilOpen;
        private System.Windows.Forms.CheckBox checkBoxStayOpenWhenFocusLost;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private System.Windows.Forms.GroupBox groupBoxAutostart;
        private System.Windows.Forms.GroupBox groupBoxHotkey;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.GroupBox groupBoxStaysOpen;
        private System.Windows.Forms.GroupBox groupBoxClick;
        private System.Windows.Forms.GroupBox groupBoxSizeAndLocation;
        private System.Windows.Forms.GroupBox groupBoxOpenSubmenus;
        private System.Windows.Forms.GroupBox groupBoxColorsDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDarkMode;
        private System.Windows.Forms.GroupBox groupBoxColorsLightMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColorsAndDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCustomize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStaysOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeUntilCloses;
        private System.Windows.Forms.Label labelTimeUntilCloses;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAdvanced;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSizeAndLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMaxMenuWidth;
        private System.Windows.Forms.CheckBox checkBoxAppearAtMouseLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeUntilOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHotkey;
        private System.Windows.Forms.Button buttonHotkeyDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChangeFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAutostart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.TextBox textBoxHotkeyPlaceholder;
        private System.Windows.Forms.Button buttonAdvancedDefault;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeUntilClose;
        private System.Windows.Forms.NumericUpDown numericUpDownMenuWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeUntilOpens;
        private System.Windows.Forms.CheckBox checkBoxStayOpenWhenItemClicked;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox textBoxColorOpenFolder;
        private System.Windows.Forms.TextBox textBoxColorWarning;
        private System.Windows.Forms.TextBox textBoxColorBackground;
        private System.Windows.Forms.TextBox textBoxColorTitle;
        private System.Windows.Forms.TextBox textBoxColorSelectedItem;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderBorder;
        private System.Windows.Forms.TextBox textBoxColorWarningDarkMode;
        private System.Windows.Forms.TextBox textBoxColorBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorTitleDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSelecetedItemDarkMode;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSelectedItemBorder;
        private System.Windows.Forms.TextBox textBoxColorSelectedItemBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSearchFieldDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSearchField;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Label labelSearchField;
        private System.Windows.Forms.Label labelOpenFolder;
        private System.Windows.Forms.Label labelOpenFolderBorder;
        private System.Windows.Forms.Label labelSelectedItem;
        private System.Windows.Forms.Label labelSelectedItemBorder;
        private System.Windows.Forms.CheckBox checkBoxStoreConfigAtAssemblyLocation;
        private System.Windows.Forms.GroupBox groupBoxUSB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUSB;
        private System.Windows.Forms.Button buttonChangeRelativeFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRelativeFolderOpenAssembly;
        private System.Windows.Forms.Button buttonOpenAssemblyLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownMenuHeight;
        private System.Windows.Forms.Label labelMaxMenuHeight;
        private System.Windows.Forms.Button buttonColorsDefault;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label labelMenuLightMode;
        private System.Windows.Forms.Label labelMenuDarkMode;
        private System.Windows.Forms.Label labelScrollbarDarkMode;
        private System.Windows.Forms.Label labelScrollbarLightMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScrollbarBackgroundDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxScrollbarBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorScrollbarBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeScrollbarBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelectedItemBorderDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItemBorderDarkMode;
        private System.Windows.Forms.Label labelSelectedItemBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelectedItemDarkMode;
        private System.Windows.Forms.PictureBox pictureColorBoxSelectedItemDarkMode;
        private System.Windows.Forms.Label labelSelectedItemDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOpenFolderBorderDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderBorderDarkMode;
        private System.Windows.Forms.Label labelOpenFolderBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOpenFolderDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderDarkMode;
        private System.Windows.Forms.Label labelOpenFolderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchFieldDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSearchFieldDarkMode;
        private System.Windows.Forms.Label labelSearchFieldDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackgroundDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundDarkMode;
        private System.Windows.Forms.Label labelBackgroundDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitleDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxTitleDarkMode;
        private System.Windows.Forms.Label labelTitleDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWarningDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxWarningDarkMode;
        private System.Windows.Forms.Label labelWarningDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScrollbarBackground;
        private System.Windows.Forms.PictureBox pictureBoxScrollbarBackground;
        private System.Windows.Forms.TextBox textBoxColorScrollbarBackground;
        private System.Windows.Forms.Label labelScrollbarBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWarning;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelectedItemBorder;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItemBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelectedItem;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOpenFolderBorder;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOpenFolder;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchField;
        private System.Windows.Forms.PictureBox pictureBoxSearchField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackground;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowClickBackground;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickBackground;
        private System.Windows.Forms.TextBox textBoxColorArrowClickBackground;
        private System.Windows.Forms.Label labelArrowClickBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowClick;
        private System.Windows.Forms.PictureBox pictureBoxArrowClick;
        private System.Windows.Forms.TextBox textBoxColorArrowClick;
        private System.Windows.Forms.Label labelArrowClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrow;
        private System.Windows.Forms.PictureBox pictureBoxArrow;
        private System.Windows.Forms.TextBox textBoxColorArrow;
        private System.Windows.Forms.Label labelArrow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderArrowsAndTrackHover;
        private System.Windows.Forms.PictureBox pictureBoxSliderArrowsAndTrackHover;
        private System.Windows.Forms.TextBox textBoxColorSliderArrowsAndTrackHover;
        private System.Windows.Forms.Label labelSliderArrowsAndTrackHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderHover;
        private System.Windows.Forms.PictureBox pictureBoxSliderHover;
        private System.Windows.Forms.TextBox textBoxColorSliderHover;
        private System.Windows.Forms.Label labelSliderHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderDragging;
        private System.Windows.Forms.PictureBox pictureBoxSliderDragging;
        private System.Windows.Forms.TextBox textBoxColorSliderDragging;
        private System.Windows.Forms.Label labelSliderDragging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSlider;
        private System.Windows.Forms.PictureBox pictureBoxSlider;
        private System.Windows.Forms.TextBox textBoxColorSlider;
        private System.Windows.Forms.Label labelSlider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowHoverBackground;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverBackground;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverBackground;
        private System.Windows.Forms.Label labelArrowHoverBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowHover;
        private System.Windows.Forms.PictureBox pictureBoxArrowHover;
        private System.Windows.Forms.TextBox textBoxColorArrowHover;
        private System.Windows.Forms.Label labelArrowHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowHoverBackgroundDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowHoverBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowHoverDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowClickBackgroundDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowClickBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowClickBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowClickDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowClickDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArrowDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxArrowDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderArrowsAndTrackHoverDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSliderArrowsAndTrackHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderArrowsAndTrackHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderArrowsAndTrackHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderHoverDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSliderHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderDraggingDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSliderDraggingDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderDraggingDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderDragging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSliderDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxSliderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSlider;
        private System.Windows.Forms.Button buttonColorsDefaultDarkMode;
        private System.Windows.Forms.CheckBox checkBoxUseIconFromRootFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeInPercentage;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackgroundBorder;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundBorder;
        private System.Windows.Forms.TextBox textBoxColorBackgroundBorder;
        private System.Windows.Forms.Label labelBackgroundBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundBorderDarkMode;
        private System.Windows.Forms.Label labelBackgroundBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorBackgroundBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIcons;
        private System.Windows.Forms.PictureBox pictureBoxIcons;
        private System.Windows.Forms.TextBox textBoxColorIcons;
        private System.Windows.Forms.Label labelIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pictureBoxIconsDarkMode;
        private System.Windows.Forms.Label labelIconsDarkMode;
        private System.Windows.Forms.TextBox textBoxColorIconsDarkMode;
        private System.Windows.Forms.CheckBox checkBoxPossibilityToSelectFolderByWindowsContextMenu;
        private System.Windows.Forms.Button buttonOpenFolder;
    }
}