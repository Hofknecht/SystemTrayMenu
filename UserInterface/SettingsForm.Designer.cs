using SystemTrayMenu.UserInterface.HotkeyTextboxControl;

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
            this.buttonGeneralDefault = new System.Windows.Forms.Button();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.checkBoxSetFolderByWindowsContextMenu = new System.Windows.Forms.CheckBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelRelativeFolderOpenAssembly = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeRelativeFolder = new System.Windows.Forms.Button();
            this.buttonOpenAssemblyLocation = new System.Windows.Forms.Button();
            this.groupBoxConfigAndLogfile = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelConfigAndLogfile = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxSaveLogFileInApplicationDirectory = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveConfigInApplicationDirectory = new System.Windows.Forms.CheckBox();
            this.groupBoxAutostart = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelAutostart = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddStartup = new System.Windows.Forms.Button();
            this.labelStartupStatus = new System.Windows.Forms.Label();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.groupBoxHotkey = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelHotkey = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxHotkeyPlaceholder = new System.Windows.Forms.TextBox();
            this.buttonHotkeyDefault = new System.Windows.Forms.Button();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tabPageSizeAndLocation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSubMenuAppearAt = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownOverlappingOffsetPixels = new System.Windows.Forms.NumericUpDown();
            this.labelOverlappingByPixelsOffset = new System.Windows.Forms.Label();
            this.radioButtonOverlapping = new System.Windows.Forms.RadioButton();
            this.radioButtonNextToPreviousMenu = new System.Windows.Forms.RadioButton();
            this.buttonSizeAndLocationDefault = new System.Windows.Forms.Button();
            this.groupBoxMenuAppearAt = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMenuAppearAt = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonUseCustomLocation = new System.Windows.Forms.RadioButton();
            this.radioButtonAppearAtTheBottomLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonAppearAtTheBottomRight = new System.Windows.Forms.RadioButton();
            this.radioButtonAppearAtMouseLocation = new System.Windows.Forms.RadioButton();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSize = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelIconSizeInPercent = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownIconSizeInPercent = new System.Windows.Forms.NumericUpDown();
            this.labelIconSizeInPercent = new System.Windows.Forms.Label();
            this.tableLayoutPanelRowHeighteInPercentage = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownRowHeighteInPercentage = new System.Windows.Forms.NumericUpDown();
            this.labelRowHeightInPercentage = new System.Windows.Forms.Label();
            this.tableLayoutPanelSizeInPercent = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSizeInPercent = new System.Windows.Forms.NumericUpDown();
            this.labelSizeInPercent = new System.Windows.Forms.Label();
            this.tableLayoutPanelMenuHeight = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuHeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuHeight = new System.Windows.Forms.Label();
            this.tableLayoutPanelMaxMenuWidth = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuWidth = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuWidth = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxInternetShortcutIcons = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeIcoFolder = new System.Windows.Forms.Button();
            this.textBoxIcoFolder = new System.Windows.Forms.TextBox();
            this.groupBoxDrag = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxSwipeScrolling = new System.Windows.Forms.CheckBox();
            this.checkBoxDragDropItems = new System.Windows.Forms.CheckBox();
            this.groupBoxClick = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelClick = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxSendHotkeyInsteadKillOtherInstances = new System.Windows.Forms.CheckBox();
            this.checkBoxOpenDirectoryWithOneClick = new System.Windows.Forms.CheckBox();
            this.checkBoxOpenItemWithOneClick = new System.Windows.Forms.CheckBox();
            this.checkBoxShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.buttonAdvancedDefault = new System.Windows.Forms.Button();
            this.groupBoxSorting = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSorting = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonSortByTypeAndDate = new System.Windows.Forms.RadioButton();
            this.radioButtonSortByTypeAndName = new System.Windows.Forms.RadioButton();
            this.radioButtonSortByDate = new System.Windows.Forms.RadioButton();
            this.radioButtonSortByName = new System.Windows.Forms.RadioButton();
            this.groupBoxHiddenFilesAndFolders = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelHiddenFilesAndFolders = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonAlwaysShowHiddenFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonNeverShowHiddenFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonSystemSettingsShowHiddenFiles = new System.Windows.Forms.RadioButton();
            this.tabPageFolders = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelFoldersInRootFolder = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFoldersInRootFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolderToRootFoldersList = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelFolderToRootFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddFolderToRootFolder = new System.Windows.Forms.Button();
            this.buttonRemoveFolder = new System.Windows.Forms.Button();
            this.dataGridViewFolders = new System.Windows.Forms.DataGridView();
            this.ColumnFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRecursiveLevel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOnlyFiles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanelAddSampleStartMenuFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddSampleStartMenuFolder = new System.Windows.Forms.Button();
            this.checkBoxGenerateShortcutsToDrives = new System.Windows.Forms.CheckBox();
            this.checkBoxShowOnlyAsSearchResult = new System.Windows.Forms.CheckBox();
            this.buttonDefaultFolders = new System.Windows.Forms.Button();
            this.tabPageExpert = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelExpert = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSearchPattern = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSearchPattern = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearchPattern = new System.Windows.Forms.TextBox();
            this.groupBoxCache = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCache = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCacheMainMenu = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.TableLayoutPanel();
            this.labelClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.Label();
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.NumericUpDown();
            this.groupBoxStaysOpen = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStaysOpen = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.Label();
            this.numericUpDownTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStayOpenWhenItemClicked = new System.Windows.Forms.CheckBox();
            this.checkBoxStayOpenWhenFocusLost = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelTimeUntilCloses = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimeUntilCloses = new System.Windows.Forms.Label();
            this.numericUpDownTimeUntilClose = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed = new System.Windows.Forms.CheckBox();
            this.groupBoxOpenSubmenus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelTimeUntilOpen = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownTimeUntilOpens = new System.Windows.Forms.NumericUpDown();
            this.labelTimeUntilOpen = new System.Windows.Forms.Label();
            this.buttonExpertDefault = new System.Windows.Forms.Button();
            this.tabPageCustomize = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCustomize = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxColorsDarkMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelColorIconsDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIconsDarkMode = new System.Windows.Forms.PictureBox();
            this.labelIconsDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorIconsDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelColorBackgroundBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelBackgroundBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorBackgroundBorderDarkMode = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanelBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.labelBackgroundDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorBackgroundDarkMode = new System.Windows.Forms.TextBox();
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
            this.groupBoxAppearance = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAppearance = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxShowLinkOverlay = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCountOfElementsBelow = new System.Windows.Forms.CheckBox();
            this.checkBoxUseFading = new System.Windows.Forms.CheckBox();
            this.checkBoxUseIconFromRootFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFunctionKeysBelow = new System.Windows.Forms.CheckBox();
            this.buttonAppearanceDefault = new System.Windows.Forms.Button();
            this.checkBoxShowSearchBar = new System.Windows.Forms.CheckBox();
            this.checkBoxShowDirectoryTitleAtTop = new System.Windows.Forms.CheckBox();
            this.checkBoxRoundCorners = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
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
            this.tableLayoutPanelRelativeFolderOpenAssembly.SuspendLayout();
            this.groupBoxConfigAndLogfile.SuspendLayout();
            this.tableLayoutPanelConfigAndLogfile.SuspendLayout();
            this.groupBoxAutostart.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanelAutostart.SuspendLayout();
            this.groupBoxHotkey.SuspendLayout();
            this.tableLayoutPanelHotkey.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.tableLayoutPanelLanguage.SuspendLayout();
            this.tabPageSizeAndLocation.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxSubMenuAppearAt.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlappingOffsetPixels)).BeginInit();
            this.groupBoxMenuAppearAt.SuspendLayout();
            this.tableLayoutPanelMenuAppearAt.SuspendLayout();
            this.groupBoxSize.SuspendLayout();
            this.tableLayoutPanelSize.SuspendLayout();
            this.tableLayoutPanelIconSizeInPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconSizeInPercent)).BeginInit();
            this.tableLayoutPanelRowHeighteInPercentage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRowHeighteInPercentage)).BeginInit();
            this.tableLayoutPanelSizeInPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeInPercent)).BeginInit();
            this.tableLayoutPanelMenuHeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuHeight)).BeginInit();
            this.tableLayoutPanelMaxMenuWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).BeginInit();
            this.tabPageAdvanced.SuspendLayout();
            this.tableLayoutPanelAdvanced.SuspendLayout();
            this.groupBoxInternetShortcutIcons.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBoxDrag.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxClick.SuspendLayout();
            this.tableLayoutPanelClick.SuspendLayout();
            this.groupBoxSorting.SuspendLayout();
            this.tableLayoutPanelSorting.SuspendLayout();
            this.groupBoxHiddenFilesAndFolders.SuspendLayout();
            this.tableLayoutPanelHiddenFilesAndFolders.SuspendLayout();
            this.tabPageFolders.SuspendLayout();
            this.tableLayoutPanelFoldersInRootFolder.SuspendLayout();
            this.groupBoxFoldersInRootFolder.SuspendLayout();
            this.tableLayoutPanelFolderToRootFoldersList.SuspendLayout();
            this.tableLayoutPanelFolderToRootFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolders)).BeginInit();
            this.tableLayoutPanelAddSampleStartMenuFolder.SuspendLayout();
            this.tabPageExpert.SuspendLayout();
            this.tableLayoutPanelExpert.SuspendLayout();
            this.groupBoxSearchPattern.SuspendLayout();
            this.tableLayoutPanelSearchPattern.SuspendLayout();
            this.groupBoxCache.SuspendLayout();
            this.tableLayoutPanelCache.SuspendLayout();
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClearCacheIfMoreThanThisNumberOfItems)).BeginInit();
            this.groupBoxStaysOpen.SuspendLayout();
            this.tableLayoutPanelStaysOpen.SuspendLayout();
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClosesAfterEnterPressed)).BeginInit();
            this.tableLayoutPanelTimeUntilCloses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClose)).BeginInit();
            this.groupBoxOpenSubmenus.SuspendLayout();
            this.tableLayoutPanelTimeUntilOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilOpens)).BeginInit();
            this.tabPageCustomize.SuspendLayout();
            this.tableLayoutPanelCustomize.SuspendLayout();
            this.groupBoxColorsDarkMode.SuspendLayout();
            this.tableLayoutPanelDarkMode.SuspendLayout();
            this.tableLayoutPanelColorIconsDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconsDarkMode)).BeginInit();
            this.tableLayoutPanelColorBackgroundBorderDarkMode.SuspendLayout();
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
            this.tableLayoutPanelBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).BeginInit();
            this.groupBoxColorsLightMode.SuspendLayout();
            this.tableLayoutPanelColorsAndDefault.SuspendLayout();
            this.tableLayoutPanelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcons)).BeginInit();
            this.tableLayoutPanelBackgroundBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundBorder)).BeginInit();
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
            this.groupBoxAppearance.SuspendLayout();
            this.tableLayoutPanelAppearance.SuspendLayout();
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
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(432, 563);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageSizeAndLocation);
            this.tabControl.Controls.Add(this.tabPageAdvanced);
            this.tabControl.Controls.Add(this.tabPageFolders);
            this.tabControl.Controls.Add(this.tabPageExpert);
            this.tabControl.Controls.Add(this.tabPageCustomize);
            this.tabControl.Location = new System.Drawing.Point(6, 3);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(420, 523);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.AutoScroll = true;
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(412, 495);
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
            this.tableLayoutPanelGeneral.Controls.Add(this.buttonGeneralDefault, 0, 5);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxFolder, 0, 0);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxConfigAndLogfile, 0, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxAutostart, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxHotkey, 0, 3);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxLanguage, 0, 4);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneral.MinimumSize = new System.Drawing.Size(391, 445);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tableLayoutPanelGeneral.RowCount = 6;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(406, 489);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // buttonGeneralDefault
            // 
            this.buttonGeneralDefault.AutoSize = true;
            this.buttonGeneralDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGeneralDefault.Location = new System.Drawing.Point(9, 454);
            this.buttonGeneralDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonGeneralDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonGeneralDefault.Name = "buttonGeneralDefault";
            this.buttonGeneralDefault.Size = new System.Drawing.Size(131, 25);
            this.buttonGeneralDefault.TabIndex = 1;
            this.buttonGeneralDefault.Text = "buttonGeneralDefault";
            this.buttonGeneralDefault.UseVisualStyleBackColor = true;
            this.buttonGeneralDefault.Click += new System.EventHandler(this.ButtonGeneralDefault_Click);
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFolder.AutoSize = true;
            this.groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFolder.Controls.Add(this.tableLayoutPanelFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxFolder.Size = new System.Drawing.Size(398, 137);
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
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelChangeFolder, 0, 1);
            this.tableLayoutPanelFolder.Controls.Add(this.checkBoxSetFolderByWindowsContextMenu, 0, 2);
            this.tableLayoutPanelFolder.Controls.Add(this.textBoxFolder, 0, 0);
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelRelativeFolderOpenAssembly, 0, 3);
            this.tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolder.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            this.tableLayoutPanelFolder.RowCount = 4;
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.Size = new System.Drawing.Size(392, 109);
            this.tableLayoutPanelFolder.TabIndex = 0;
            // 
            // tableLayoutPanelChangeFolder
            // 
            this.tableLayoutPanelChangeFolder.AutoSize = true;
            this.tableLayoutPanelChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelChangeFolder.ColumnCount = 3;
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelChangeFolder.Controls.Add(this.buttonChangeFolder, 0, 0);
            this.tableLayoutPanelChangeFolder.Controls.Add(this.buttonOpenFolder, 2, 0);
            this.tableLayoutPanelChangeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelChangeFolder.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanelChangeFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelChangeFolder.Name = "tableLayoutPanelChangeFolder";
            this.tableLayoutPanelChangeFolder.RowCount = 1;
            this.tableLayoutPanelChangeFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(392, 31);
            this.tableLayoutPanelChangeFolder.TabIndex = 0;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChangeFolder.AutoSize = true;
            this.buttonChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonChangeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonChangeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(127, 25);
            this.buttonChangeFolder.TabIndex = 0;
            this.buttonChangeFolder.Text = "buttonChangeFolder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.AutoSize = true;
            this.buttonOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenFolder.Location = new System.Drawing.Point(274, 3);
            this.buttonOpenFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(115, 25);
            this.buttonOpenFolder.TabIndex = 3;
            this.buttonOpenFolder.Text = "buttonOpenFolder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // checkBoxSetFolderByWindowsContextMenu
            // 
            this.checkBoxSetFolderByWindowsContextMenu.AutoSize = true;
            this.checkBoxSetFolderByWindowsContextMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSetFolderByWindowsContextMenu.Location = new System.Drawing.Point(3, 56);
            this.checkBoxSetFolderByWindowsContextMenu.Name = "checkBoxSetFolderByWindowsContextMenu";
            this.checkBoxSetFolderByWindowsContextMenu.Size = new System.Drawing.Size(386, 19);
            this.checkBoxSetFolderByWindowsContextMenu.TabIndex = 5;
            this.checkBoxSetFolderByWindowsContextMenu.Text = "SetFolderByWindowsContextMenu";
            this.checkBoxSetFolderByWindowsContextMenu.UseVisualStyleBackColor = true;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.BackColor = System.Drawing.Color.White;
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFolder.Location = new System.Drawing.Point(6, 3);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxFolder.MaximumSize = new System.Drawing.Size(380, 0);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(380, 16);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TabStop = false;
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
            this.tableLayoutPanelRelativeFolderOpenAssembly.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Name = "tableLayoutPanelRelativeFolderOpenAssembly";
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowCount = 1;
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRelativeFolderOpenAssembly.Size = new System.Drawing.Size(392, 31);
            this.tableLayoutPanelRelativeFolderOpenAssembly.TabIndex = 0;
            // 
            // buttonChangeRelativeFolder
            // 
            this.buttonChangeRelativeFolder.AutoSize = true;
            this.buttonChangeRelativeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeRelativeFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonChangeRelativeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonChangeRelativeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonChangeRelativeFolder.Name = "buttonChangeRelativeFolder";
            this.buttonChangeRelativeFolder.Size = new System.Drawing.Size(132, 25);
            this.buttonChangeRelativeFolder.TabIndex = 0;
            this.buttonChangeRelativeFolder.Text = "ChangeRelativeFolder";
            this.buttonChangeRelativeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeRelativeFolder.Click += new System.EventHandler(this.ButtonChangeRelativeFolder_Click);
            // 
            // buttonOpenAssemblyLocation
            // 
            this.buttonOpenAssemblyLocation.AutoSize = true;
            this.buttonOpenAssemblyLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenAssemblyLocation.Location = new System.Drawing.Point(210, 3);
            this.buttonOpenAssemblyLocation.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOpenAssemblyLocation.Name = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.Size = new System.Drawing.Size(179, 25);
            this.buttonOpenAssemblyLocation.TabIndex = 0;
            this.buttonOpenAssemblyLocation.Text = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.UseVisualStyleBackColor = true;
            this.buttonOpenAssemblyLocation.Click += new System.EventHandler(this.ButtonOpenAssemblyLocation_Click);
            // 
            // groupBoxConfigAndLogfile
            // 
            this.groupBoxConfigAndLogfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxConfigAndLogfile.AutoSize = true;
            this.groupBoxConfigAndLogfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxConfigAndLogfile.Controls.Add(this.tableLayoutPanelConfigAndLogfile);
            this.groupBoxConfigAndLogfile.Location = new System.Drawing.Point(3, 146);
            this.groupBoxConfigAndLogfile.Name = "groupBoxConfigAndLogfile";
            this.groupBoxConfigAndLogfile.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxConfigAndLogfile.Size = new System.Drawing.Size(398, 78);
            this.groupBoxConfigAndLogfile.TabIndex = 0;
            this.groupBoxConfigAndLogfile.TabStop = false;
            this.groupBoxConfigAndLogfile.Text = "groupBoxConfigAndLogfile";
            // 
            // tableLayoutPanelConfigAndLogfile
            // 
            this.tableLayoutPanelConfigAndLogfile.AutoSize = true;
            this.tableLayoutPanelConfigAndLogfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelConfigAndLogfile.ColumnCount = 1;
            this.tableLayoutPanelConfigAndLogfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelConfigAndLogfile.Controls.Add(this.checkBoxSaveLogFileInApplicationDirectory, 0, 2);
            this.tableLayoutPanelConfigAndLogfile.Controls.Add(this.checkBoxSaveConfigInApplicationDirectory, 0, 1);
            this.tableLayoutPanelConfigAndLogfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelConfigAndLogfile.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelConfigAndLogfile.Name = "tableLayoutPanelConfigAndLogfile";
            this.tableLayoutPanelConfigAndLogfile.RowCount = 3;
            this.tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConfigAndLogfile.Size = new System.Drawing.Size(392, 50);
            this.tableLayoutPanelConfigAndLogfile.TabIndex = 0;
            // 
            // checkBoxSaveLogFileInApplicationDirectory
            // 
            this.checkBoxSaveLogFileInApplicationDirectory.AutoSize = true;
            this.checkBoxSaveLogFileInApplicationDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSaveLogFileInApplicationDirectory.Location = new System.Drawing.Point(3, 28);
            this.checkBoxSaveLogFileInApplicationDirectory.Name = "checkBoxSaveLogFileInApplicationDirectory";
            this.checkBoxSaveLogFileInApplicationDirectory.Size = new System.Drawing.Size(386, 19);
            this.checkBoxSaveLogFileInApplicationDirectory.TabIndex = 1;
            this.checkBoxSaveLogFileInApplicationDirectory.Text = "checkBoxSaveLogFileInApplicationDirectory";
            this.checkBoxSaveLogFileInApplicationDirectory.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveConfigInApplicationDirectory
            // 
            this.checkBoxSaveConfigInApplicationDirectory.AutoSize = true;
            this.checkBoxSaveConfigInApplicationDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSaveConfigInApplicationDirectory.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSaveConfigInApplicationDirectory.Name = "checkBoxSaveConfigInApplicationDirectory";
            this.checkBoxSaveConfigInApplicationDirectory.Size = new System.Drawing.Size(386, 19);
            this.checkBoxSaveConfigInApplicationDirectory.TabIndex = 0;
            this.checkBoxSaveConfigInApplicationDirectory.Text = "checkBoxSaveConfigInApplicationDirectory";
            this.checkBoxSaveConfigInApplicationDirectory.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutostart
            // 
            this.groupBoxAutostart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAutostart.AutoSize = true;
            this.groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAutostart.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxAutostart.Location = new System.Drawing.Point(3, 230);
            this.groupBoxAutostart.Name = "groupBoxAutostart";
            this.groupBoxAutostart.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxAutostart.Size = new System.Drawing.Size(398, 84);
            this.groupBoxAutostart.TabIndex = 0;
            this.groupBoxAutostart.TabStop = false;
            this.groupBoxAutostart.Text = "groupBoxAutostart";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.checkBoxCheckForUpdates, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanelAutostart, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(392, 56);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // checkBoxCheckForUpdates
            // 
            this.checkBoxCheckForUpdates.AutoSize = true;
            this.checkBoxCheckForUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCheckForUpdates.Location = new System.Drawing.Point(3, 34);
            this.checkBoxCheckForUpdates.Name = "checkBoxCheckForUpdates";
            this.checkBoxCheckForUpdates.Size = new System.Drawing.Size(386, 19);
            this.checkBoxCheckForUpdates.TabIndex = 10;
            this.checkBoxCheckForUpdates.Text = "checkBoxCheckForUpdates";
            this.checkBoxCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAutostart
            // 
            this.tableLayoutPanelAutostart.AutoSize = true;
            this.tableLayoutPanelAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAutostart.ColumnCount = 3;
            this.tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAutostart.Controls.Add(this.buttonAddStartup, 0, 0);
            this.tableLayoutPanelAutostart.Controls.Add(this.labelStartupStatus, 2, 0);
            this.tableLayoutPanelAutostart.Controls.Add(this.checkBoxAutostart, 0, 0);
            this.tableLayoutPanelAutostart.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelAutostart.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            this.tableLayoutPanelAutostart.RowCount = 1;
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAutostart.Size = new System.Drawing.Size(359, 31);
            this.tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // buttonAddStartup
            // 
            this.buttonAddStartup.AutoSize = true;
            this.buttonAddStartup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddStartup.Location = new System.Drawing.Point(135, 3);
            this.buttonAddStartup.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonAddStartup.Name = "buttonAddStartup";
            this.buttonAddStartup.Size = new System.Drawing.Size(113, 25);
            this.buttonAddStartup.TabIndex = 10;
            this.buttonAddStartup.Text = "buttonAddStartup";
            this.buttonAddStartup.UseVisualStyleBackColor = true;
            this.buttonAddStartup.Click += new System.EventHandler(this.ButtonAddStartup_Click);
            // 
            // labelStartupStatus
            // 
            this.labelStartupStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStartupStatus.AutoSize = true;
            this.labelStartupStatus.Location = new System.Drawing.Point(254, 8);
            this.labelStartupStatus.Name = "labelStartupStatus";
            this.labelStartupStatus.Size = new System.Drawing.Size(102, 15);
            this.labelStartupStatus.TabIndex = 2;
            this.labelStartupStatus.Text = "labelStartupStatus";
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutostart.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(126, 25);
            this.checkBoxAutostart.TabIndex = 9;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            this.groupBoxHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHotkey.AutoSize = true;
            this.groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHotkey.Controls.Add(this.tableLayoutPanelHotkey);
            this.groupBoxHotkey.Location = new System.Drawing.Point(3, 320);
            this.groupBoxHotkey.Name = "groupBoxHotkey";
            this.groupBoxHotkey.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxHotkey.Size = new System.Drawing.Size(398, 59);
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
            this.tableLayoutPanelHotkey.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelHotkey.Name = "tableLayoutPanelHotkey";
            this.tableLayoutPanelHotkey.RowCount = 1;
            this.tableLayoutPanelHotkey.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHotkey.Size = new System.Drawing.Size(392, 31);
            this.tableLayoutPanelHotkey.TabIndex = 0;
            // 
            // textBoxHotkeyPlaceholder
            // 
            this.textBoxHotkeyPlaceholder.Location = new System.Drawing.Point(3, 3);
            this.textBoxHotkeyPlaceholder.Name = "textBoxHotkeyPlaceholder";
            this.textBoxHotkeyPlaceholder.Size = new System.Drawing.Size(200, 23);
            this.textBoxHotkeyPlaceholder.TabIndex = 0;
            this.textBoxHotkeyPlaceholder.TabStop = false;
            // 
            // buttonHotkeyDefault
            // 
            this.buttonHotkeyDefault.AutoSize = true;
            this.buttonHotkeyDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHotkeyDefault.Location = new System.Drawing.Point(260, 3);
            this.buttonHotkeyDefault.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonHotkeyDefault.Name = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.Size = new System.Drawing.Size(129, 25);
            this.buttonHotkeyDefault.TabIndex = 0;
            this.buttonHotkeyDefault.Text = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.UseVisualStyleBackColor = true;
            this.buttonHotkeyDefault.Click += new System.EventHandler(this.ButtonHotkeyDefault_Click);
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLanguage.AutoSize = true;
            this.groupBoxLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLanguage.Controls.Add(this.tableLayoutPanelLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(3, 385);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxLanguage.Size = new System.Drawing.Size(398, 57);
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
            this.tableLayoutPanelLanguage.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelLanguage.Name = "tableLayoutPanelLanguage";
            this.tableLayoutPanelLanguage.RowCount = 1;
            this.tableLayoutPanelLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLanguage.Size = new System.Drawing.Size(392, 29);
            this.tableLayoutPanelLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(200, 23);
            this.comboBoxLanguage.TabIndex = 13;
            // 
            // tabPageSizeAndLocation
            // 
            this.tabPageSizeAndLocation.Controls.Add(this.tableLayoutPanel2);
            this.tabPageSizeAndLocation.Location = new System.Drawing.Point(4, 24);
            this.tabPageSizeAndLocation.Name = "tabPageSizeAndLocation";
            this.tabPageSizeAndLocation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSizeAndLocation.Size = new System.Drawing.Size(412, 495);
            this.tabPageSizeAndLocation.TabIndex = 3;
            this.tabPageSizeAndLocation.Text = "tabPageSizeAndLocation";
            this.tabPageSizeAndLocation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBoxSubMenuAppearAt, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonSizeAndLocationDefault, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxMenuAppearAt, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxSize, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(406, 489);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBoxSubMenuAppearAt
            // 
            this.groupBoxSubMenuAppearAt.AutoSize = true;
            this.groupBoxSubMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSubMenuAppearAt.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxSubMenuAppearAt.Location = new System.Drawing.Point(3, 307);
            this.groupBoxSubMenuAppearAt.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSubMenuAppearAt.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSubMenuAppearAt.Name = "groupBoxSubMenuAppearAt";
            this.groupBoxSubMenuAppearAt.Size = new System.Drawing.Size(400, 76);
            this.groupBoxSubMenuAppearAt.TabIndex = 2;
            this.groupBoxSubMenuAppearAt.TabStop = false;
            this.groupBoxSubMenuAppearAt.Text = "groupBoxSubMenuAppearAt";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonNextToPreviousMenu, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(394, 54);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownOverlappingOffsetPixels, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelOverlappingByPixelsOffset, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonOverlapping, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // numericUpDownOverlappingOffsetPixels
            // 
            this.numericUpDownOverlappingOffsetPixels.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownOverlappingOffsetPixels.Location = new System.Drawing.Point(162, 3);
            this.numericUpDownOverlappingOffsetPixels.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownOverlappingOffsetPixels.Name = "numericUpDownOverlappingOffsetPixels";
            this.numericUpDownOverlappingOffsetPixels.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownOverlappingOffsetPixels.TabIndex = 2;
            // 
            // labelOverlappingByPixelsOffset
            // 
            this.labelOverlappingByPixelsOffset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOverlappingByPixelsOffset.AutoSize = true;
            this.labelOverlappingByPixelsOffset.Location = new System.Drawing.Point(223, 7);
            this.labelOverlappingByPixelsOffset.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelOverlappingByPixelsOffset.Name = "labelOverlappingByPixelsOffset";
            this.labelOverlappingByPixelsOffset.Size = new System.Drawing.Size(64, 15);
            this.labelOverlappingByPixelsOffset.TabIndex = 3;
            this.labelOverlappingByPixelsOffset.Text = "labelOffset";
            // 
            // radioButtonOverlapping
            // 
            this.radioButtonOverlapping.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonOverlapping.AutoSize = true;
            this.radioButtonOverlapping.Location = new System.Drawing.Point(3, 5);
            this.radioButtonOverlapping.Name = "radioButtonOverlapping";
            this.radioButtonOverlapping.Size = new System.Drawing.Size(153, 19);
            this.radioButtonOverlapping.TabIndex = 1;
            this.radioButtonOverlapping.TabStop = true;
            this.radioButtonOverlapping.Text = "radioButtonOverlapping";
            this.radioButtonOverlapping.UseVisualStyleBackColor = true;
            this.radioButtonOverlapping.CheckedChanged += new System.EventHandler(this.RadioButtonOverlapping_CheckedChanged);
            // 
            // radioButtonNextToPreviousMenu
            // 
            this.radioButtonNextToPreviousMenu.AutoSize = true;
            this.radioButtonNextToPreviousMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonNextToPreviousMenu.Location = new System.Drawing.Point(3, 3);
            this.radioButtonNextToPreviousMenu.Name = "radioButtonNextToPreviousMenu";
            this.radioButtonNextToPreviousMenu.Size = new System.Drawing.Size(388, 19);
            this.radioButtonNextToPreviousMenu.TabIndex = 2;
            this.radioButtonNextToPreviousMenu.TabStop = true;
            this.radioButtonNextToPreviousMenu.Text = "radioButtonNextToPreviousMenu";
            this.radioButtonNextToPreviousMenu.UseVisualStyleBackColor = true;
            this.radioButtonNextToPreviousMenu.CheckedChanged += new System.EventHandler(this.RadioButtonNextToPreviousMenu_CheckedChanged);
            // 
            // buttonSizeAndLocationDefault
            // 
            this.buttonSizeAndLocationDefault.AutoSize = true;
            this.buttonSizeAndLocationDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSizeAndLocationDefault.Location = new System.Drawing.Point(9, 395);
            this.buttonSizeAndLocationDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonSizeAndLocationDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonSizeAndLocationDefault.Name = "buttonSizeAndLocationDefault";
            this.buttonSizeAndLocationDefault.Size = new System.Drawing.Size(179, 25);
            this.buttonSizeAndLocationDefault.TabIndex = 0;
            this.buttonSizeAndLocationDefault.Text = "buttonSizeAndLocationDefault";
            this.buttonSizeAndLocationDefault.UseVisualStyleBackColor = true;
            this.buttonSizeAndLocationDefault.Click += new System.EventHandler(this.ButtonSizeAndLocationDefault_Click);
            // 
            // groupBoxMenuAppearAt
            // 
            this.groupBoxMenuAppearAt.AutoSize = true;
            this.groupBoxMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxMenuAppearAt.Controls.Add(this.tableLayoutPanelMenuAppearAt);
            this.groupBoxMenuAppearAt.Location = new System.Drawing.Point(3, 179);
            this.groupBoxMenuAppearAt.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxMenuAppearAt.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxMenuAppearAt.Name = "groupBoxMenuAppearAt";
            this.groupBoxMenuAppearAt.Size = new System.Drawing.Size(400, 122);
            this.groupBoxMenuAppearAt.TabIndex = 1;
            this.groupBoxMenuAppearAt.TabStop = false;
            this.groupBoxMenuAppearAt.Text = "groupBoxMenuAppearAt";
            // 
            // tableLayoutPanelMenuAppearAt
            // 
            this.tableLayoutPanelMenuAppearAt.AutoSize = true;
            this.tableLayoutPanelMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuAppearAt.ColumnCount = 1;
            this.tableLayoutPanelMenuAppearAt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMenuAppearAt.Controls.Add(this.radioButtonUseCustomLocation, 0, 2);
            this.tableLayoutPanelMenuAppearAt.Controls.Add(this.radioButtonAppearAtTheBottomLeft, 0, 1);
            this.tableLayoutPanelMenuAppearAt.Controls.Add(this.radioButtonAppearAtTheBottomRight, 0, 0);
            this.tableLayoutPanelMenuAppearAt.Controls.Add(this.radioButtonAppearAtMouseLocation, 0, 3);
            this.tableLayoutPanelMenuAppearAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMenuAppearAt.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelMenuAppearAt.Name = "tableLayoutPanelMenuAppearAt";
            this.tableLayoutPanelMenuAppearAt.RowCount = 4;
            this.tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuAppearAt.Size = new System.Drawing.Size(394, 100);
            this.tableLayoutPanelMenuAppearAt.TabIndex = 1;
            // 
            // radioButtonUseCustomLocation
            // 
            this.radioButtonUseCustomLocation.AutoSize = true;
            this.radioButtonUseCustomLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonUseCustomLocation.Location = new System.Drawing.Point(3, 53);
            this.radioButtonUseCustomLocation.Name = "radioButtonUseCustomLocation";
            this.radioButtonUseCustomLocation.Size = new System.Drawing.Size(388, 19);
            this.radioButtonUseCustomLocation.TabIndex = 2;
            this.radioButtonUseCustomLocation.TabStop = true;
            this.radioButtonUseCustomLocation.Text = "radioButtonUseCustomLocation";
            this.radioButtonUseCustomLocation.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtTheBottomLeft
            // 
            this.radioButtonAppearAtTheBottomLeft.AutoSize = true;
            this.radioButtonAppearAtTheBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonAppearAtTheBottomLeft.Location = new System.Drawing.Point(3, 28);
            this.radioButtonAppearAtTheBottomLeft.Name = "radioButtonAppearAtTheBottomLeft";
            this.radioButtonAppearAtTheBottomLeft.Size = new System.Drawing.Size(388, 19);
            this.radioButtonAppearAtTheBottomLeft.TabIndex = 1;
            this.radioButtonAppearAtTheBottomLeft.TabStop = true;
            this.radioButtonAppearAtTheBottomLeft.Text = "radioButtonradioButtonAppearAtTheBottomLeft";
            this.radioButtonAppearAtTheBottomLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtTheBottomRight
            // 
            this.radioButtonAppearAtTheBottomRight.AutoSize = true;
            this.radioButtonAppearAtTheBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonAppearAtTheBottomRight.Location = new System.Drawing.Point(3, 3);
            this.radioButtonAppearAtTheBottomRight.Name = "radioButtonAppearAtTheBottomRight";
            this.radioButtonAppearAtTheBottomRight.Size = new System.Drawing.Size(388, 19);
            this.radioButtonAppearAtTheBottomRight.TabIndex = 2;
            this.radioButtonAppearAtTheBottomRight.TabStop = true;
            this.radioButtonAppearAtTheBottomRight.Text = "radioButtonAppearAtTheBottomRight";
            this.radioButtonAppearAtTheBottomRight.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtMouseLocation
            // 
            this.radioButtonAppearAtMouseLocation.AutoSize = true;
            this.radioButtonAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonAppearAtMouseLocation.Location = new System.Drawing.Point(3, 78);
            this.radioButtonAppearAtMouseLocation.Name = "radioButtonAppearAtMouseLocation";
            this.radioButtonAppearAtMouseLocation.Size = new System.Drawing.Size(388, 19);
            this.radioButtonAppearAtMouseLocation.TabIndex = 3;
            this.radioButtonAppearAtMouseLocation.TabStop = true;
            this.radioButtonAppearAtMouseLocation.Text = "radioButtonAppearAtMouseLocation";
            this.radioButtonAppearAtMouseLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxSize
            // 
            this.groupBoxSize.AutoSize = true;
            this.groupBoxSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSize.Controls.Add(this.tableLayoutPanelSize);
            this.groupBoxSize.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSize.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSize.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxSize.Size = new System.Drawing.Size(400, 170);
            this.groupBoxSize.TabIndex = 0;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "groupBoxSize";
            // 
            // tableLayoutPanelSize
            // 
            this.tableLayoutPanelSize.AutoSize = true;
            this.tableLayoutPanelSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSize.ColumnCount = 1;
            this.tableLayoutPanelSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSize.Controls.Add(this.tableLayoutPanelIconSizeInPercent, 0, 1);
            this.tableLayoutPanelSize.Controls.Add(this.tableLayoutPanelRowHeighteInPercentage, 0, 2);
            this.tableLayoutPanelSize.Controls.Add(this.tableLayoutPanelSizeInPercent, 0, 0);
            this.tableLayoutPanelSize.Controls.Add(this.tableLayoutPanelMenuHeight, 0, 4);
            this.tableLayoutPanelSize.Controls.Add(this.tableLayoutPanelMaxMenuWidth, 0, 3);
            this.tableLayoutPanelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSize.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelSize.Name = "tableLayoutPanelSize";
            this.tableLayoutPanelSize.RowCount = 5;
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSize.Size = new System.Drawing.Size(394, 145);
            this.tableLayoutPanelSize.TabIndex = 0;
            // 
            // tableLayoutPanelIconSizeInPercent
            // 
            this.tableLayoutPanelIconSizeInPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelIconSizeInPercent.AutoSize = true;
            this.tableLayoutPanelIconSizeInPercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelIconSizeInPercent.ColumnCount = 2;
            this.tableLayoutPanelIconSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelIconSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelIconSizeInPercent.Controls.Add(this.numericUpDownIconSizeInPercent, 0, 0);
            this.tableLayoutPanelIconSizeInPercent.Controls.Add(this.labelIconSizeInPercent, 1, 0);
            this.tableLayoutPanelIconSizeInPercent.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanelIconSizeInPercent.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelIconSizeInPercent.Name = "tableLayoutPanelIconSizeInPercent";
            this.tableLayoutPanelIconSizeInPercent.RowCount = 1;
            this.tableLayoutPanelIconSizeInPercent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelIconSizeInPercent.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelIconSizeInPercent.TabIndex = 1;
            // 
            // numericUpDownIconSizeInPercent
            // 
            this.numericUpDownIconSizeInPercent.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownIconSizeInPercent.Name = "numericUpDownIconSizeInPercent";
            this.numericUpDownIconSizeInPercent.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownIconSizeInPercent.TabIndex = 1;
            // 
            // labelIconSizeInPercent
            // 
            this.labelIconSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIconSizeInPercent.AutoSize = true;
            this.labelIconSizeInPercent.Location = new System.Drawing.Point(64, 7);
            this.labelIconSizeInPercent.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelIconSizeInPercent.Name = "labelIconSizeInPercent";
            this.labelIconSizeInPercent.Size = new System.Drawing.Size(125, 15);
            this.labelIconSizeInPercent.TabIndex = 0;
            this.labelIconSizeInPercent.Text = "labelIconSizeInPercent";
            // 
            // tableLayoutPanelRowHeighteInPercentage
            // 
            this.tableLayoutPanelRowHeighteInPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelRowHeighteInPercentage.AutoSize = true;
            this.tableLayoutPanelRowHeighteInPercentage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRowHeighteInPercentage.ColumnCount = 2;
            this.tableLayoutPanelRowHeighteInPercentage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRowHeighteInPercentage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRowHeighteInPercentage.Controls.Add(this.numericUpDownRowHeighteInPercentage, 0, 0);
            this.tableLayoutPanelRowHeighteInPercentage.Controls.Add(this.labelRowHeightInPercentage, 1, 0);
            this.tableLayoutPanelRowHeighteInPercentage.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanelRowHeighteInPercentage.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRowHeighteInPercentage.Name = "tableLayoutPanelRowHeighteInPercentage";
            this.tableLayoutPanelRowHeighteInPercentage.RowCount = 1;
            this.tableLayoutPanelRowHeighteInPercentage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRowHeighteInPercentage.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelRowHeighteInPercentage.TabIndex = 3;
            // 
            // numericUpDownRowHeighteInPercentage
            // 
            this.numericUpDownRowHeighteInPercentage.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownRowHeighteInPercentage.Name = "numericUpDownRowHeighteInPercentage";
            this.numericUpDownRowHeighteInPercentage.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownRowHeighteInPercentage.TabIndex = 1;
            // 
            // labelRowHeightInPercentage
            // 
            this.labelRowHeightInPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRowHeightInPercentage.AutoSize = true;
            this.labelRowHeightInPercentage.Location = new System.Drawing.Point(64, 7);
            this.labelRowHeightInPercentage.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelRowHeightInPercentage.Name = "labelRowHeightInPercentage";
            this.labelRowHeightInPercentage.Size = new System.Drawing.Size(166, 15);
            this.labelRowHeightInPercentage.TabIndex = 0;
            this.labelRowHeightInPercentage.Text = "labelRowHeighteInPercentage";
            // 
            // tableLayoutPanelSizeInPercent
            // 
            this.tableLayoutPanelSizeInPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSizeInPercent.AutoSize = true;
            this.tableLayoutPanelSizeInPercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSizeInPercent.ColumnCount = 2;
            this.tableLayoutPanelSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSizeInPercent.Controls.Add(this.numericUpDownSizeInPercent, 0, 0);
            this.tableLayoutPanelSizeInPercent.Controls.Add(this.labelSizeInPercent, 1, 0);
            this.tableLayoutPanelSizeInPercent.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSizeInPercent.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSizeInPercent.Name = "tableLayoutPanelSizeInPercent";
            this.tableLayoutPanelSizeInPercent.RowCount = 1;
            this.tableLayoutPanelSizeInPercent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeInPercent.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelSizeInPercent.TabIndex = 0;
            // 
            // numericUpDownSizeInPercent
            // 
            this.numericUpDownSizeInPercent.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownSizeInPercent.Name = "numericUpDownSizeInPercent";
            this.numericUpDownSizeInPercent.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownSizeInPercent.TabIndex = 1;
            this.numericUpDownSizeInPercent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownSizeInPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelSizeInPercent
            // 
            this.labelSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSizeInPercent.AutoSize = true;
            this.labelSizeInPercent.Location = new System.Drawing.Point(64, 7);
            this.labelSizeInPercent.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelSizeInPercent.Name = "labelSizeInPercent";
            this.labelSizeInPercent.Size = new System.Drawing.Size(102, 15);
            this.labelSizeInPercent.TabIndex = 0;
            this.labelSizeInPercent.Text = "labelSizeInPercent";
            // 
            // tableLayoutPanelMenuHeight
            // 
            this.tableLayoutPanelMenuHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMenuHeight.AutoSize = true;
            this.tableLayoutPanelMenuHeight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuHeight.ColumnCount = 2;
            this.tableLayoutPanelMenuHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuHeight.Controls.Add(this.numericUpDownMenuHeight, 0, 0);
            this.tableLayoutPanelMenuHeight.Controls.Add(this.labelMaxMenuHeight, 1, 0);
            this.tableLayoutPanelMenuHeight.Location = new System.Drawing.Point(0, 116);
            this.tableLayoutPanelMenuHeight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenuHeight.Name = "tableLayoutPanelMenuHeight";
            this.tableLayoutPanelMenuHeight.RowCount = 1;
            this.tableLayoutPanelMenuHeight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuHeight.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelMenuHeight.TabIndex = 0;
            // 
            // numericUpDownMenuHeight
            // 
            this.numericUpDownMenuHeight.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownMenuHeight.Name = "numericUpDownMenuHeight";
            this.numericUpDownMenuHeight.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownMenuHeight.TabIndex = 1;
            this.numericUpDownMenuHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownMenuHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelMaxMenuHeight
            // 
            this.labelMaxMenuHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaxMenuHeight.AutoSize = true;
            this.labelMaxMenuHeight.Location = new System.Drawing.Point(64, 7);
            this.labelMaxMenuHeight.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelMaxMenuHeight.Name = "labelMaxMenuHeight";
            this.labelMaxMenuHeight.Size = new System.Drawing.Size(122, 15);
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
            this.tableLayoutPanelMaxMenuWidth.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanelMaxMenuWidth.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMaxMenuWidth.Name = "tableLayoutPanelMaxMenuWidth";
            this.tableLayoutPanelMaxMenuWidth.RowCount = 1;
            this.tableLayoutPanelMaxMenuWidth.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMaxMenuWidth.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelMaxMenuWidth.TabIndex = 0;
            // 
            // numericUpDownMenuWidth
            // 
            this.numericUpDownMenuWidth.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownMenuWidth.Name = "numericUpDownMenuWidth";
            this.numericUpDownMenuWidth.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownMenuWidth.TabIndex = 1;
            this.numericUpDownMenuWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownMenuWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelMaxMenuWidth
            // 
            this.labelMaxMenuWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaxMenuWidth.AutoSize = true;
            this.labelMaxMenuWidth.Location = new System.Drawing.Point(64, 7);
            this.labelMaxMenuWidth.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelMaxMenuWidth.Name = "labelMaxMenuWidth";
            this.labelMaxMenuWidth.Size = new System.Drawing.Size(118, 15);
            this.labelMaxMenuWidth.TabIndex = 0;
            this.labelMaxMenuWidth.Text = "labelMaxMenuWidth";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.AutoScroll = true;
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanelAdvanced);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(412, 495);
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
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxInternetShortcutIcons, 0, 2);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxDrag, 0, 1);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxClick, 0, 0);
            this.tableLayoutPanelAdvanced.Controls.Add(this.buttonAdvancedDefault, 0, 5);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxSorting, 0, 3);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxHiddenFilesAndFolders, 0, 4);
            this.tableLayoutPanelAdvanced.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelAdvanced.Name = "tableLayoutPanelAdvanced";
            this.tableLayoutPanelAdvanced.RowCount = 6;
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.Size = new System.Drawing.Size(391, 567);
            this.tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxInternetShortcutIcons
            // 
            this.groupBoxInternetShortcutIcons.AutoSize = true;
            this.groupBoxInternetShortcutIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxInternetShortcutIcons.Controls.Add(this.tableLayoutPanel6);
            this.groupBoxInternetShortcutIcons.Location = new System.Drawing.Point(3, 209);
            this.groupBoxInternetShortcutIcons.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxInternetShortcutIcons.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxInternetShortcutIcons.Name = "groupBoxInternetShortcutIcons";
            this.groupBoxInternetShortcutIcons.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxInternetShortcutIcons.Size = new System.Drawing.Size(385, 81);
            this.groupBoxInternetShortcutIcons.TabIndex = 1;
            this.groupBoxInternetShortcutIcons.TabStop = false;
            this.groupBoxInternetShortcutIcons.Text = "groupBoxInternetShortcutIcons";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxIcoFolder, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(379, 53);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.buttonChangeIcoFolder, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(379, 31);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // buttonChangeIcoFolder
            // 
            this.buttonChangeIcoFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChangeIcoFolder.AutoSize = true;
            this.buttonChangeIcoFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeIcoFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonChangeIcoFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonChangeIcoFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonChangeIcoFolder.Name = "buttonChangeIcoFolder";
            this.buttonChangeIcoFolder.Size = new System.Drawing.Size(143, 25);
            this.buttonChangeIcoFolder.TabIndex = 0;
            this.buttonChangeIcoFolder.Text = "buttonChangeIcoFolder";
            this.buttonChangeIcoFolder.UseVisualStyleBackColor = true;
            this.buttonChangeIcoFolder.Click += new System.EventHandler(this.ButtonChangeIcoFolder_Click);
            // 
            // textBoxIcoFolder
            // 
            this.textBoxIcoFolder.BackColor = System.Drawing.Color.White;
            this.textBoxIcoFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIcoFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIcoFolder.Location = new System.Drawing.Point(6, 3);
            this.textBoxIcoFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxIcoFolder.MaximumSize = new System.Drawing.Size(380, 0);
            this.textBoxIcoFolder.Name = "textBoxIcoFolder";
            this.textBoxIcoFolder.ReadOnly = true;
            this.textBoxIcoFolder.Size = new System.Drawing.Size(367, 16);
            this.textBoxIcoFolder.TabIndex = 0;
            this.textBoxIcoFolder.TabStop = false;
            // 
            // groupBoxDrag
            // 
            this.groupBoxDrag.AutoSize = true;
            this.groupBoxDrag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxDrag.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxDrag.Location = new System.Drawing.Point(3, 131);
            this.groupBoxDrag.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxDrag.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxDrag.Name = "groupBoxDrag";
            this.groupBoxDrag.Size = new System.Drawing.Size(385, 72);
            this.groupBoxDrag.TabIndex = 4;
            this.groupBoxDrag.TabStop = false;
            this.groupBoxDrag.Text = "groupBoxDrag";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSwipeScrolling, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDragDropItems, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 50);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // checkBoxSwipeScrolling
            // 
            this.checkBoxSwipeScrolling.AutoSize = true;
            this.checkBoxSwipeScrolling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSwipeScrolling.Location = new System.Drawing.Point(3, 28);
            this.checkBoxSwipeScrolling.Name = "checkBoxSwipeScrolling";
            this.checkBoxSwipeScrolling.Size = new System.Drawing.Size(373, 19);
            this.checkBoxSwipeScrolling.TabIndex = 4;
            this.checkBoxSwipeScrolling.Text = "checkBoxSwipeScrolling";
            this.checkBoxSwipeScrolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxDragDropItems
            // 
            this.checkBoxDragDropItems.AutoSize = true;
            this.checkBoxDragDropItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDragDropItems.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDragDropItems.Name = "checkBoxDragDropItems";
            this.checkBoxDragDropItems.Size = new System.Drawing.Size(373, 19);
            this.checkBoxDragDropItems.TabIndex = 3;
            this.checkBoxDragDropItems.Text = "checkBoxDragDropItems";
            this.checkBoxDragDropItems.UseVisualStyleBackColor = true;
            // 
            // groupBoxClick
            // 
            this.groupBoxClick.AutoSize = true;
            this.groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxClick.Controls.Add(this.tableLayoutPanelClick);
            this.groupBoxClick.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClick.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxClick.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxClick.Name = "groupBoxClick";
            this.groupBoxClick.Size = new System.Drawing.Size(385, 122);
            this.groupBoxClick.TabIndex = 0;
            this.groupBoxClick.TabStop = false;
            this.groupBoxClick.Text = "groupBoxClick";
            // 
            // tableLayoutPanelClick
            // 
            this.tableLayoutPanelClick.AutoSize = true;
            this.tableLayoutPanelClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelClick.ColumnCount = 1;
            this.tableLayoutPanelClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxSendHotkeyInsteadKillOtherInstances, 0, 1);
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxOpenDirectoryWithOneClick, 0, 3);
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxOpenItemWithOneClick, 0, 2);
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxShowInTaskbar, 0, 0);
            this.tableLayoutPanelClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClick.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelClick.Name = "tableLayoutPanelClick";
            this.tableLayoutPanelClick.RowCount = 4;
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelClick.Size = new System.Drawing.Size(379, 100);
            this.tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxSendHotkeyInsteadKillOtherInstances
            // 
            this.checkBoxSendHotkeyInsteadKillOtherInstances.AutoSize = true;
            this.checkBoxSendHotkeyInsteadKillOtherInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSendHotkeyInsteadKillOtherInstances.Location = new System.Drawing.Point(3, 28);
            this.checkBoxSendHotkeyInsteadKillOtherInstances.MaximumSize = new System.Drawing.Size(330, 0);
            this.checkBoxSendHotkeyInsteadKillOtherInstances.Name = "checkBoxSendHotkeyInsteadKillOtherInstances";
            this.checkBoxSendHotkeyInsteadKillOtherInstances.Size = new System.Drawing.Size(330, 19);
            this.checkBoxSendHotkeyInsteadKillOtherInstances.TabIndex = 3;
            this.checkBoxSendHotkeyInsteadKillOtherInstances.Text = "checkBoxSendHotkeyInsteadKillOtherInstances";
            this.checkBoxSendHotkeyInsteadKillOtherInstances.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenDirectoryWithOneClick
            // 
            this.checkBoxOpenDirectoryWithOneClick.AutoSize = true;
            this.checkBoxOpenDirectoryWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenDirectoryWithOneClick.Location = new System.Drawing.Point(3, 78);
            this.checkBoxOpenDirectoryWithOneClick.Name = "checkBoxOpenDirectoryWithOneClick";
            this.checkBoxOpenDirectoryWithOneClick.Size = new System.Drawing.Size(373, 19);
            this.checkBoxOpenDirectoryWithOneClick.TabIndex = 2;
            this.checkBoxOpenDirectoryWithOneClick.Text = "checkBoxOpenDirectoryWithOneClick";
            this.checkBoxOpenDirectoryWithOneClick.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(3, 53);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(373, 19);
            this.checkBoxOpenItemWithOneClick.TabIndex = 0;
            this.checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowInTaskbar
            // 
            this.checkBoxShowInTaskbar.AutoSize = true;
            this.checkBoxShowInTaskbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowInTaskbar.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowInTaskbar.Name = "checkBoxShowInTaskbar";
            this.checkBoxShowInTaskbar.Size = new System.Drawing.Size(373, 19);
            this.checkBoxShowInTaskbar.TabIndex = 1;
            this.checkBoxShowInTaskbar.Text = "checkBoxShowInTaskbar";
            this.checkBoxShowInTaskbar.UseVisualStyleBackColor = true;
            // 
            // buttonAdvancedDefault
            // 
            this.buttonAdvancedDefault.AutoSize = true;
            this.buttonAdvancedDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdvancedDefault.Location = new System.Drawing.Point(9, 533);
            this.buttonAdvancedDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonAdvancedDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonAdvancedDefault.Name = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.Size = new System.Drawing.Size(144, 25);
            this.buttonAdvancedDefault.TabIndex = 0;
            this.buttonAdvancedDefault.Text = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.UseVisualStyleBackColor = true;
            this.buttonAdvancedDefault.Click += new System.EventHandler(this.ButtonAdvancedDefault_Click);
            // 
            // groupBoxSorting
            // 
            this.groupBoxSorting.AutoSize = true;
            this.groupBoxSorting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSorting.Controls.Add(this.tableLayoutPanelSorting);
            this.groupBoxSorting.Location = new System.Drawing.Point(3, 296);
            this.groupBoxSorting.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxSorting.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxSorting.Name = "groupBoxSorting";
            this.groupBoxSorting.Size = new System.Drawing.Size(385, 122);
            this.groupBoxSorting.TabIndex = 3;
            this.groupBoxSorting.TabStop = false;
            this.groupBoxSorting.Text = "groupBoxSorting";
            // 
            // tableLayoutPanelSorting
            // 
            this.tableLayoutPanelSorting.AutoSize = true;
            this.tableLayoutPanelSorting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSorting.ColumnCount = 1;
            this.tableLayoutPanelSorting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSorting.Controls.Add(this.radioButtonSortByTypeAndDate, 0, 1);
            this.tableLayoutPanelSorting.Controls.Add(this.radioButtonSortByTypeAndName, 0, 0);
            this.tableLayoutPanelSorting.Controls.Add(this.radioButtonSortByDate, 0, 3);
            this.tableLayoutPanelSorting.Controls.Add(this.radioButtonSortByName, 0, 2);
            this.tableLayoutPanelSorting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSorting.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelSorting.Name = "tableLayoutPanelSorting";
            this.tableLayoutPanelSorting.RowCount = 4;
            this.tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSorting.Size = new System.Drawing.Size(379, 100);
            this.tableLayoutPanelSorting.TabIndex = 1;
            // 
            // radioButtonSortByTypeAndDate
            // 
            this.radioButtonSortByTypeAndDate.AutoSize = true;
            this.radioButtonSortByTypeAndDate.Location = new System.Drawing.Point(3, 28);
            this.radioButtonSortByTypeAndDate.Name = "radioButtonSortByTypeAndDate";
            this.radioButtonSortByTypeAndDate.Size = new System.Drawing.Size(192, 19);
            this.radioButtonSortByTypeAndDate.TabIndex = 3;
            this.radioButtonSortByTypeAndDate.TabStop = true;
            this.radioButtonSortByTypeAndDate.Text = "radioButtonSortByTypeAndDate";
            this.radioButtonSortByTypeAndDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByTypeAndName
            // 
            this.radioButtonSortByTypeAndName.AutoSize = true;
            this.radioButtonSortByTypeAndName.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSortByTypeAndName.Name = "radioButtonSortByTypeAndName";
            this.radioButtonSortByTypeAndName.Size = new System.Drawing.Size(200, 19);
            this.radioButtonSortByTypeAndName.TabIndex = 4;
            this.radioButtonSortByTypeAndName.TabStop = true;
            this.radioButtonSortByTypeAndName.Text = "radioButtonSortByTypeAndName";
            this.radioButtonSortByTypeAndName.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByDate
            // 
            this.radioButtonSortByDate.AutoSize = true;
            this.radioButtonSortByDate.Location = new System.Drawing.Point(3, 78);
            this.radioButtonSortByDate.Name = "radioButtonSortByDate";
            this.radioButtonSortByDate.Size = new System.Drawing.Size(146, 19);
            this.radioButtonSortByDate.TabIndex = 1;
            this.radioButtonSortByDate.TabStop = true;
            this.radioButtonSortByDate.Text = "radioButtonSortByDate";
            this.radioButtonSortByDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByName
            // 
            this.radioButtonSortByName.AutoSize = true;
            this.radioButtonSortByName.Location = new System.Drawing.Point(3, 53);
            this.radioButtonSortByName.Name = "radioButtonSortByName";
            this.radioButtonSortByName.Size = new System.Drawing.Size(154, 19);
            this.radioButtonSortByName.TabIndex = 2;
            this.radioButtonSortByName.TabStop = true;
            this.radioButtonSortByName.Text = "radioButtonSortByName";
            this.radioButtonSortByName.UseVisualStyleBackColor = true;
            // 
            // groupBoxHiddenFilesAndFolders
            // 
            this.groupBoxHiddenFilesAndFolders.AutoSize = true;
            this.groupBoxHiddenFilesAndFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHiddenFilesAndFolders.Controls.Add(this.tableLayoutPanelHiddenFilesAndFolders);
            this.groupBoxHiddenFilesAndFolders.Location = new System.Drawing.Point(3, 424);
            this.groupBoxHiddenFilesAndFolders.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxHiddenFilesAndFolders.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxHiddenFilesAndFolders.Name = "groupBoxHiddenFilesAndFolders";
            this.groupBoxHiddenFilesAndFolders.Size = new System.Drawing.Size(385, 97);
            this.groupBoxHiddenFilesAndFolders.TabIndex = 2;
            this.groupBoxHiddenFilesAndFolders.TabStop = false;
            this.groupBoxHiddenFilesAndFolders.Text = "groupBoxHiddenFilesAndFolders";
            // 
            // tableLayoutPanelHiddenFilesAndFolders
            // 
            this.tableLayoutPanelHiddenFilesAndFolders.AutoSize = true;
            this.tableLayoutPanelHiddenFilesAndFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelHiddenFilesAndFolders.ColumnCount = 1;
            this.tableLayoutPanelHiddenFilesAndFolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHiddenFilesAndFolders.Controls.Add(this.radioButtonAlwaysShowHiddenFiles, 0, 2);
            this.tableLayoutPanelHiddenFilesAndFolders.Controls.Add(this.radioButtonNeverShowHiddenFiles, 0, 1);
            this.tableLayoutPanelHiddenFilesAndFolders.Controls.Add(this.radioButtonSystemSettingsShowHiddenFiles, 0, 0);
            this.tableLayoutPanelHiddenFilesAndFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHiddenFilesAndFolders.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelHiddenFilesAndFolders.Name = "tableLayoutPanelHiddenFilesAndFolders";
            this.tableLayoutPanelHiddenFilesAndFolders.RowCount = 3;
            this.tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHiddenFilesAndFolders.Size = new System.Drawing.Size(379, 75);
            this.tableLayoutPanelHiddenFilesAndFolders.TabIndex = 1;
            // 
            // radioButtonAlwaysShowHiddenFiles
            // 
            this.radioButtonAlwaysShowHiddenFiles.AutoSize = true;
            this.radioButtonAlwaysShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonAlwaysShowHiddenFiles.Location = new System.Drawing.Point(3, 53);
            this.radioButtonAlwaysShowHiddenFiles.Name = "radioButtonAlwaysShowHiddenFiles";
            this.radioButtonAlwaysShowHiddenFiles.Size = new System.Drawing.Size(373, 19);
            this.radioButtonAlwaysShowHiddenFiles.TabIndex = 2;
            this.radioButtonAlwaysShowHiddenFiles.TabStop = true;
            this.radioButtonAlwaysShowHiddenFiles.Text = "radioButtonAlwaysShowHiddenFiles";
            this.radioButtonAlwaysShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonNeverShowHiddenFiles
            // 
            this.radioButtonNeverShowHiddenFiles.AutoSize = true;
            this.radioButtonNeverShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonNeverShowHiddenFiles.Location = new System.Drawing.Point(3, 28);
            this.radioButtonNeverShowHiddenFiles.Name = "radioButtonNeverShowHiddenFiles";
            this.radioButtonNeverShowHiddenFiles.Size = new System.Drawing.Size(373, 19);
            this.radioButtonNeverShowHiddenFiles.TabIndex = 1;
            this.radioButtonNeverShowHiddenFiles.TabStop = true;
            this.radioButtonNeverShowHiddenFiles.Text = "radioButtonNeverShowHiddenFiles";
            this.radioButtonNeverShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonSystemSettingsShowHiddenFiles
            // 
            this.radioButtonSystemSettingsShowHiddenFiles.AutoSize = true;
            this.radioButtonSystemSettingsShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonSystemSettingsShowHiddenFiles.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSystemSettingsShowHiddenFiles.Name = "radioButtonSystemSettingsShowHiddenFiles";
            this.radioButtonSystemSettingsShowHiddenFiles.Size = new System.Drawing.Size(373, 19);
            this.radioButtonSystemSettingsShowHiddenFiles.TabIndex = 2;
            this.radioButtonSystemSettingsShowHiddenFiles.TabStop = true;
            this.radioButtonSystemSettingsShowHiddenFiles.Text = "radioButtonSystemSettingsShowHiddenFiles";
            this.radioButtonSystemSettingsShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // tabPageFolders
            // 
            this.tabPageFolders.Controls.Add(this.tableLayoutPanelFoldersInRootFolder);
            this.tabPageFolders.Location = new System.Drawing.Point(4, 24);
            this.tabPageFolders.Name = "tabPageFolders";
            this.tabPageFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFolders.Size = new System.Drawing.Size(412, 495);
            this.tabPageFolders.TabIndex = 2;
            this.tabPageFolders.Text = "tabPageFolders";
            this.tabPageFolders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelFoldersInRootFolder
            // 
            this.tableLayoutPanelFoldersInRootFolder.AutoSize = true;
            this.tableLayoutPanelFoldersInRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFoldersInRootFolder.ColumnCount = 1;
            this.tableLayoutPanelFoldersInRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFoldersInRootFolder.Controls.Add(this.groupBoxFoldersInRootFolder, 0, 0);
            this.tableLayoutPanelFoldersInRootFolder.Controls.Add(this.buttonDefaultFolders, 0, 1);
            this.tableLayoutPanelFoldersInRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFoldersInRootFolder.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelFoldersInRootFolder.Name = "tableLayoutPanelFoldersInRootFolder";
            this.tableLayoutPanelFoldersInRootFolder.RowCount = 2;
            this.tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFoldersInRootFolder.Size = new System.Drawing.Size(406, 489);
            this.tableLayoutPanelFoldersInRootFolder.TabIndex = 1;
            // 
            // groupBoxFoldersInRootFolder
            // 
            this.groupBoxFoldersInRootFolder.AutoSize = true;
            this.groupBoxFoldersInRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFoldersInRootFolder.Controls.Add(this.tableLayoutPanelFolderToRootFoldersList);
            this.groupBoxFoldersInRootFolder.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFoldersInRootFolder.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFoldersInRootFolder.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFoldersInRootFolder.Name = "groupBoxFoldersInRootFolder";
            this.groupBoxFoldersInRootFolder.Size = new System.Drawing.Size(400, 324);
            this.groupBoxFoldersInRootFolder.TabIndex = 0;
            this.groupBoxFoldersInRootFolder.TabStop = false;
            this.groupBoxFoldersInRootFolder.Text = "groupBoxFoldersInRootFolder";
            // 
            // tableLayoutPanelFolderToRootFoldersList
            // 
            this.tableLayoutPanelFolderToRootFoldersList.AutoSize = true;
            this.tableLayoutPanelFolderToRootFoldersList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFolderToRootFoldersList.ColumnCount = 1;
            this.tableLayoutPanelFolderToRootFoldersList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFolderToRootFoldersList.Controls.Add(this.tableLayoutPanelFolderToRootFolder, 0, 2);
            this.tableLayoutPanelFolderToRootFoldersList.Controls.Add(this.dataGridViewFolders, 0, 3);
            this.tableLayoutPanelFolderToRootFoldersList.Controls.Add(this.tableLayoutPanelAddSampleStartMenuFolder, 0, 4);
            this.tableLayoutPanelFolderToRootFoldersList.Controls.Add(this.checkBoxGenerateShortcutsToDrives, 0, 5);
            this.tableLayoutPanelFolderToRootFoldersList.Controls.Add(this.checkBoxShowOnlyAsSearchResult, 0, 0);
            this.tableLayoutPanelFolderToRootFoldersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolderToRootFoldersList.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelFolderToRootFoldersList.Name = "tableLayoutPanelFolderToRootFoldersList";
            this.tableLayoutPanelFolderToRootFoldersList.RowCount = 6;
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolderToRootFoldersList.Size = new System.Drawing.Size(394, 302);
            this.tableLayoutPanelFolderToRootFoldersList.TabIndex = 0;
            // 
            // tableLayoutPanelFolderToRootFolder
            // 
            this.tableLayoutPanelFolderToRootFolder.AutoSize = true;
            this.tableLayoutPanelFolderToRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFolderToRootFolder.ColumnCount = 3;
            this.tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFolderToRootFolder.Controls.Add(this.buttonAddFolderToRootFolder, 0, 0);
            this.tableLayoutPanelFolderToRootFolder.Controls.Add(this.buttonRemoveFolder, 2, 0);
            this.tableLayoutPanelFolderToRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolderToRootFolder.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanelFolderToRootFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelFolderToRootFolder.Name = "tableLayoutPanelFolderToRootFolder";
            this.tableLayoutPanelFolderToRootFolder.RowCount = 1;
            this.tableLayoutPanelFolderToRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFolderToRootFolder.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelFolderToRootFolder.TabIndex = 2;
            // 
            // buttonAddFolderToRootFolder
            // 
            this.buttonAddFolderToRootFolder.AutoSize = true;
            this.buttonAddFolderToRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddFolderToRootFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonAddFolderToRootFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonAddFolderToRootFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonAddFolderToRootFolder.Name = "buttonAddFolderToRootFolder";
            this.buttonAddFolderToRootFolder.Size = new System.Drawing.Size(178, 25);
            this.buttonAddFolderToRootFolder.TabIndex = 0;
            this.buttonAddFolderToRootFolder.Text = "buttonAddFolderToRootFolder";
            this.buttonAddFolderToRootFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolderToRootFolder.Click += new System.EventHandler(this.ButtonAddFolderToRootFolder_Click);
            // 
            // buttonRemoveFolder
            // 
            this.buttonRemoveFolder.AutoSize = true;
            this.buttonRemoveFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRemoveFolder.Location = new System.Drawing.Point(262, 3);
            this.buttonRemoveFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.buttonRemoveFolder.Size = new System.Drawing.Size(129, 25);
            this.buttonRemoveFolder.TabIndex = 1;
            this.buttonRemoveFolder.Text = "buttonRemoveFolder";
            this.buttonRemoveFolder.UseVisualStyleBackColor = true;
            this.buttonRemoveFolder.Click += new System.EventHandler(this.ButtonRemoveFolder_Click);
            // 
            // dataGridViewFolders
            // 
            this.dataGridViewFolders.AllowUserToAddRows = false;
            this.dataGridViewFolders.AllowUserToDeleteRows = false;
            this.dataGridViewFolders.AllowUserToResizeColumns = false;
            this.dataGridViewFolders.AllowUserToResizeRows = false;
            this.dataGridViewFolders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFolder,
            this.ColumnRecursiveLevel,
            this.ColumnOnlyFiles});
            this.dataGridViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFolders.Location = new System.Drawing.Point(3, 59);
            this.dataGridViewFolders.Name = "dataGridViewFolders";
            this.dataGridViewFolders.RowHeadersVisible = false;
            this.dataGridViewFolders.RowTemplate.Height = 25;
            this.dataGridViewFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFolders.Size = new System.Drawing.Size(388, 184);
            this.dataGridViewFolders.TabIndex = 6;
            this.dataGridViewFolders.TabStop = false;
            this.dataGridViewFolders.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridViewFolders_CellValidating);
            this.dataGridViewFolders.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewFolders_CurrentCellDirtyStateChanged);
            this.dataGridViewFolders.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewFolders_RowsAdded);
            this.dataGridViewFolders.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewFolders_RowsRemoved);
            this.dataGridViewFolders.SelectionChanged += new System.EventHandler(this.DataGridViewFolders_SelectionChanged);
            this.dataGridViewFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewFolders_MouseClick);
            // 
            // ColumnFolder
            // 
            this.ColumnFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFolder.HeaderText = "ColumnFolder";
            this.ColumnFolder.Name = "ColumnFolder";
            // 
            // ColumnRecursiveLevel
            // 
            this.ColumnRecursiveLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnRecursiveLevel.HeaderText = "ColumnRecursiveLevel";
            this.ColumnRecursiveLevel.Name = "ColumnRecursiveLevel";
            this.ColumnRecursiveLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRecursiveLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRecursiveLevel.Width = 152;
            // 
            // ColumnOnlyFiles
            // 
            this.ColumnOnlyFiles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnOnlyFiles.HeaderText = "ColumnOnlyFiles";
            this.ColumnOnlyFiles.Name = "ColumnOnlyFiles";
            this.ColumnOnlyFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOnlyFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnOnlyFiles.Width = 123;
            // 
            // tableLayoutPanelAddSampleStartMenuFolder
            // 
            this.tableLayoutPanelAddSampleStartMenuFolder.AutoSize = true;
            this.tableLayoutPanelAddSampleStartMenuFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAddSampleStartMenuFolder.ColumnCount = 2;
            this.tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAddSampleStartMenuFolder.Controls.Add(this.buttonAddSampleStartMenuFolder, 0, 0);
            this.tableLayoutPanelAddSampleStartMenuFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAddSampleStartMenuFolder.Location = new System.Drawing.Point(0, 246);
            this.tableLayoutPanelAddSampleStartMenuFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelAddSampleStartMenuFolder.Name = "tableLayoutPanelAddSampleStartMenuFolder";
            this.tableLayoutPanelAddSampleStartMenuFolder.RowCount = 1;
            this.tableLayoutPanelAddSampleStartMenuFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAddSampleStartMenuFolder.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelAddSampleStartMenuFolder.TabIndex = 3;
            // 
            // buttonAddSampleStartMenuFolder
            // 
            this.buttonAddSampleStartMenuFolder.AutoSize = true;
            this.buttonAddSampleStartMenuFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddSampleStartMenuFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonAddSampleStartMenuFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonAddSampleStartMenuFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonAddSampleStartMenuFolder.Name = "buttonAddSampleStartMenuFolder";
            this.buttonAddSampleStartMenuFolder.Size = new System.Drawing.Size(202, 25);
            this.buttonAddSampleStartMenuFolder.TabIndex = 2;
            this.buttonAddSampleStartMenuFolder.Text = "buttonAddSampleStartMenuFolder";
            this.buttonAddSampleStartMenuFolder.UseVisualStyleBackColor = true;
            this.buttonAddSampleStartMenuFolder.Click += new System.EventHandler(this.ButtonAddSampleStartMenuFolder_Click);
            // 
            // checkBoxGenerateShortcutsToDrives
            // 
            this.checkBoxGenerateShortcutsToDrives.AutoSize = true;
            this.checkBoxGenerateShortcutsToDrives.Location = new System.Drawing.Point(3, 280);
            this.checkBoxGenerateShortcutsToDrives.Name = "checkBoxGenerateShortcutsToDrives";
            this.checkBoxGenerateShortcutsToDrives.Size = new System.Drawing.Size(218, 19);
            this.checkBoxGenerateShortcutsToDrives.TabIndex = 7;
            this.checkBoxGenerateShortcutsToDrives.Text = "checkBoxGenerateShortcutsToDrives";
            this.checkBoxGenerateShortcutsToDrives.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowOnlyAsSearchResult
            // 
            this.checkBoxShowOnlyAsSearchResult.AutoSize = true;
            this.checkBoxShowOnlyAsSearchResult.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowOnlyAsSearchResult.Name = "checkBoxShowOnlyAsSearchResult";
            this.checkBoxShowOnlyAsSearchResult.Size = new System.Drawing.Size(211, 19);
            this.checkBoxShowOnlyAsSearchResult.TabIndex = 8;
            this.checkBoxShowOnlyAsSearchResult.Text = "checkBoxShowOnlyAsSearchResult";
            this.checkBoxShowOnlyAsSearchResult.UseVisualStyleBackColor = true;
            // 
            // buttonDefaultFolders
            // 
            this.buttonDefaultFolders.AutoSize = true;
            this.buttonDefaultFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDefaultFolders.Location = new System.Drawing.Point(9, 339);
            this.buttonDefaultFolders.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonDefaultFolders.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonDefaultFolders.Name = "buttonDefaultFolders";
            this.buttonDefaultFolders.Size = new System.Drawing.Size(129, 25);
            this.buttonDefaultFolders.TabIndex = 6;
            this.buttonDefaultFolders.Text = "buttonDefaultFolders";
            this.buttonDefaultFolders.UseVisualStyleBackColor = true;
            this.buttonDefaultFolders.Click += new System.EventHandler(this.ButtonClearFolders_Click);
            // 
            // tabPageExpert
            // 
            this.tabPageExpert.Controls.Add(this.tableLayoutPanelExpert);
            this.tabPageExpert.Location = new System.Drawing.Point(4, 24);
            this.tabPageExpert.Name = "tabPageExpert";
            this.tabPageExpert.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExpert.Size = new System.Drawing.Size(412, 495);
            this.tabPageExpert.TabIndex = 1;
            this.tabPageExpert.Text = "tabPageExpert";
            this.tabPageExpert.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelExpert
            // 
            this.tableLayoutPanelExpert.AutoSize = true;
            this.tableLayoutPanelExpert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelExpert.ColumnCount = 1;
            this.tableLayoutPanelExpert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelExpert.Controls.Add(this.groupBoxSearchPattern, 0, 3);
            this.tableLayoutPanelExpert.Controls.Add(this.groupBoxCache, 0, 2);
            this.tableLayoutPanelExpert.Controls.Add(this.groupBoxStaysOpen, 0, 1);
            this.tableLayoutPanelExpert.Controls.Add(this.groupBoxOpenSubmenus, 0, 0);
            this.tableLayoutPanelExpert.Controls.Add(this.buttonExpertDefault, 0, 4);
            this.tableLayoutPanelExpert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExpert.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelExpert.Name = "tableLayoutPanelExpert";
            this.tableLayoutPanelExpert.RowCount = 5;
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExpert.Size = new System.Drawing.Size(406, 489);
            this.tableLayoutPanelExpert.TabIndex = 1;
            // 
            // groupBoxSearchPattern
            // 
            this.groupBoxSearchPattern.AutoSize = true;
            this.groupBoxSearchPattern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSearchPattern.Controls.Add(this.tableLayoutPanelSearchPattern);
            this.groupBoxSearchPattern.Location = new System.Drawing.Point(3, 312);
            this.groupBoxSearchPattern.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSearchPattern.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSearchPattern.Name = "groupBoxSearchPattern";
            this.groupBoxSearchPattern.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxSearchPattern.Size = new System.Drawing.Size(400, 54);
            this.groupBoxSearchPattern.TabIndex = 2;
            this.groupBoxSearchPattern.TabStop = false;
            this.groupBoxSearchPattern.Text = "groupBoxSearchPattern";
            // 
            // tableLayoutPanelSearchPattern
            // 
            this.tableLayoutPanelSearchPattern.AutoSize = true;
            this.tableLayoutPanelSearchPattern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSearchPattern.ColumnCount = 1;
            this.tableLayoutPanelSearchPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearchPattern.Controls.Add(this.textBoxSearchPattern, 0, 0);
            this.tableLayoutPanelSearchPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSearchPattern.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelSearchPattern.Name = "tableLayoutPanelSearchPattern";
            this.tableLayoutPanelSearchPattern.RowCount = 1;
            this.tableLayoutPanelSearchPattern.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearchPattern.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelSearchPattern.TabIndex = 0;
            // 
            // textBoxSearchPattern
            // 
            this.textBoxSearchPattern.Location = new System.Drawing.Point(3, 3);
            this.textBoxSearchPattern.Name = "textBoxSearchPattern";
            this.textBoxSearchPattern.Size = new System.Drawing.Size(350, 23);
            this.textBoxSearchPattern.TabIndex = 1;
            this.textBoxSearchPattern.TabStop = false;
            // 
            // groupBoxCache
            // 
            this.groupBoxCache.AutoSize = true;
            this.groupBoxCache.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxCache.Controls.Add(this.tableLayoutPanelCache);
            this.groupBoxCache.Location = new System.Drawing.Point(3, 227);
            this.groupBoxCache.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxCache.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxCache.Name = "groupBoxCache";
            this.groupBoxCache.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxCache.Size = new System.Drawing.Size(400, 79);
            this.groupBoxCache.TabIndex = 1;
            this.groupBoxCache.TabStop = false;
            this.groupBoxCache.Text = "groupBoxCache";
            // 
            // tableLayoutPanelCache
            // 
            this.tableLayoutPanelCache.AutoSize = true;
            this.tableLayoutPanelCache.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCache.ColumnCount = 1;
            this.tableLayoutPanelCache.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCache.Controls.Add(this.checkBoxCacheMainMenu, 0, 0);
            this.tableLayoutPanelCache.Controls.Add(this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems, 0, 1);
            this.tableLayoutPanelCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCache.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelCache.Name = "tableLayoutPanelCache";
            this.tableLayoutPanelCache.RowCount = 2;
            this.tableLayoutPanelCache.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCache.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCache.Size = new System.Drawing.Size(394, 54);
            this.tableLayoutPanelCache.TabIndex = 0;
            // 
            // checkBoxCacheMainMenu
            // 
            this.checkBoxCacheMainMenu.AutoSize = true;
            this.checkBoxCacheMainMenu.Location = new System.Drawing.Point(3, 3);
            this.checkBoxCacheMainMenu.Name = "checkBoxCacheMainMenu";
            this.checkBoxCacheMainMenu.Size = new System.Drawing.Size(168, 19);
            this.checkBoxCacheMainMenu.TabIndex = 3;
            this.checkBoxCacheMainMenu.Text = "checkBoxCacheMainMenu";
            this.checkBoxCacheMainMenu.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems
            // 
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.AutoSize = true;
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnCount = 2;
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Controls.Add(this.labelClearCacheIfMoreThanThisNumberOfItems, 1, 0);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Controls.Add(this.numericUpDownClearCacheIfMoreThanThisNumberOfItems, 0, 0);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Name = "tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems";
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.RowCount = 1;
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.TabIndex = 3;
            // 
            // labelClearCacheIfMoreThanThisNumberOfItems
            // 
            this.labelClearCacheIfMoreThanThisNumberOfItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelClearCacheIfMoreThanThisNumberOfItems.AutoSize = true;
            this.labelClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(64, 7);
            this.labelClearCacheIfMoreThanThisNumberOfItems.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelClearCacheIfMoreThanThisNumberOfItems.Name = "labelClearCacheIfMoreThanThisNumberOfItems";
            this.labelClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(260, 15);
            this.labelClearCacheIfMoreThanThisNumberOfItems.TabIndex = 0;
            this.labelClearCacheIfMoreThanThisNumberOfItems.Text = "labelClearCacheIfMoreThanThisNumberOfItems";
            // 
            // numericUpDownClearCacheIfMoreThanThisNumberOfItems
            // 
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Name = "numericUpDownClearCacheIfMoreThanThisNumberOfItems";
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.TabIndex = 5;
            this.numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBoxStaysOpen
            // 
            this.groupBoxStaysOpen.AutoSize = true;
            this.groupBoxStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStaysOpen.Controls.Add(this.tableLayoutPanelStaysOpen);
            this.groupBoxStaysOpen.Location = new System.Drawing.Point(3, 63);
            this.groupBoxStaysOpen.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            this.groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxStaysOpen.Size = new System.Drawing.Size(400, 158);
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
            this.tableLayoutPanelStaysOpen.Controls.Add(this.tableLayoutPanelTimeUntilClosesAfterEnterPressed, 0, 4);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenItemClicked, 0, 0);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenFocusLost, 0, 1);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.tableLayoutPanelTimeUntilCloses, 0, 2);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenFocusLostAfterEnterPressed, 0, 3);
            this.tableLayoutPanelStaysOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStaysOpen.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelStaysOpen.Name = "tableLayoutPanelStaysOpen";
            this.tableLayoutPanelStaysOpen.RowCount = 5;
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(394, 133);
            this.tableLayoutPanelStaysOpen.TabIndex = 0;
            // 
            // tableLayoutPanelTimeUntilClosesAfterEnterPressed
            // 
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.AutoSize = true;
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnCount = 2;
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Controls.Add(this.labelTimeUntilClosesAfterEnterPressed, 1, 0);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Controls.Add(this.numericUpDownTimeUntilClosesAfterEnterPressed, 0, 0);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(0, 104);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Name = "tableLayoutPanelTimeUntilClosesAfterEnterPressed";
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.RowCount = 1;
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.TabIndex = 2;
            // 
            // labelTimeUntilClosesAfterEnterPressed
            // 
            this.labelTimeUntilClosesAfterEnterPressed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilClosesAfterEnterPressed.AutoSize = true;
            this.labelTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilClosesAfterEnterPressed.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelTimeUntilClosesAfterEnterPressed.Name = "labelTimeUntilClosesAfterEnterPressed";
            this.labelTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(210, 15);
            this.labelTimeUntilClosesAfterEnterPressed.TabIndex = 0;
            this.labelTimeUntilClosesAfterEnterPressed.Text = "labelTimeUntilClosesAfterEnterPressed";
            // 
            // numericUpDownTimeUntilClosesAfterEnterPressed
            // 
            this.numericUpDownTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownTimeUntilClosesAfterEnterPressed.Name = "numericUpDownTimeUntilClosesAfterEnterPressed";
            this.numericUpDownTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownTimeUntilClosesAfterEnterPressed.TabIndex = 1;
            // 
            // checkBoxStayOpenWhenItemClicked
            // 
            this.checkBoxStayOpenWhenItemClicked.AutoSize = true;
            this.checkBoxStayOpenWhenItemClicked.Checked = true;
            this.checkBoxStayOpenWhenItemClicked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenItemClicked.Location = new System.Drawing.Point(3, 3);
            this.checkBoxStayOpenWhenItemClicked.Name = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.Size = new System.Drawing.Size(222, 19);
            this.checkBoxStayOpenWhenItemClicked.TabIndex = 0;
            this.checkBoxStayOpenWhenItemClicked.Text = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.UseVisualStyleBackColor = true;
            // 
            // checkBoxStayOpenWhenFocusLost
            // 
            this.checkBoxStayOpenWhenFocusLost.AutoSize = true;
            this.checkBoxStayOpenWhenFocusLost.Checked = true;
            this.checkBoxStayOpenWhenFocusLost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenFocusLost.Location = new System.Drawing.Point(3, 28);
            this.checkBoxStayOpenWhenFocusLost.Name = "checkBoxStayOpenWhenFocusLost";
            this.checkBoxStayOpenWhenFocusLost.Size = new System.Drawing.Size(212, 19);
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
            this.tableLayoutPanelTimeUntilCloses.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanelTimeUntilCloses.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTimeUntilCloses.Name = "tableLayoutPanelTimeUntilCloses";
            this.tableLayoutPanelTimeUntilCloses.RowCount = 1;
            this.tableLayoutPanelTimeUntilCloses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilCloses.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelTimeUntilCloses.TabIndex = 0;
            // 
            // labelTimeUntilCloses
            // 
            this.labelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilCloses.AutoSize = true;
            this.labelTimeUntilCloses.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilCloses.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelTimeUntilCloses.Name = "labelTimeUntilCloses";
            this.labelTimeUntilCloses.Size = new System.Drawing.Size(117, 15);
            this.labelTimeUntilCloses.TabIndex = 0;
            this.labelTimeUntilCloses.Text = "labelTimeUntilCloses";
            // 
            // numericUpDownTimeUntilClose
            // 
            this.numericUpDownTimeUntilClose.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownTimeUntilClose.Name = "numericUpDownTimeUntilClose";
            this.numericUpDownTimeUntilClose.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownTimeUntilClose.TabIndex = 1;
            this.numericUpDownTimeUntilClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownTimeUntilClose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // checkBoxStayOpenWhenFocusLostAfterEnterPressed
            // 
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.AutoSize = true;
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked = true;
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.Location = new System.Drawing.Point(3, 82);
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.Name = "checkBoxStayOpenWhenFocusLostAfterEnterPressed";
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.Size = new System.Drawing.Size(305, 19);
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.TabIndex = 1;
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.Text = "checkBoxStayOpenWhenFocusLostAfterEnterPressed";
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.UseVisualStyleBackColor = true;
            this.checkBoxStayOpenWhenFocusLostAfterEnterPressed.CheckedChanged += new System.EventHandler(this.CheckBoxStayOpenWhenFocusLostAfterEnterPressed_CheckedChanged);
            // 
            // groupBoxOpenSubmenus
            // 
            this.groupBoxOpenSubmenus.AutoSize = true;
            this.groupBoxOpenSubmenus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOpenSubmenus.Controls.Add(this.tableLayoutPanelTimeUntilOpen);
            this.groupBoxOpenSubmenus.Location = new System.Drawing.Point(3, 3);
            this.groupBoxOpenSubmenus.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxOpenSubmenus.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxOpenSubmenus.Name = "groupBoxOpenSubmenus";
            this.groupBoxOpenSubmenus.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxOpenSubmenus.Size = new System.Drawing.Size(400, 54);
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
            this.tableLayoutPanelTimeUntilOpen.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelTimeUntilOpen.Name = "tableLayoutPanelTimeUntilOpen";
            this.tableLayoutPanelTimeUntilOpen.RowCount = 1;
            this.tableLayoutPanelTimeUntilOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilOpen.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelTimeUntilOpen.TabIndex = 0;
            // 
            // numericUpDownTimeUntilOpens
            // 
            this.numericUpDownTimeUntilOpens.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownTimeUntilOpens.Name = "numericUpDownTimeUntilOpens";
            this.numericUpDownTimeUntilOpens.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownTimeUntilOpens.TabIndex = 2;
            this.numericUpDownTimeUntilOpens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.numericUpDownTimeUntilOpens.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelTimeUntilOpen
            // 
            this.labelTimeUntilOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilOpen.AutoSize = true;
            this.labelTimeUntilOpen.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilOpen.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelTimeUntilOpen.Name = "labelTimeUntilOpen";
            this.labelTimeUntilOpen.Size = new System.Drawing.Size(112, 15);
            this.labelTimeUntilOpen.TabIndex = 0;
            this.labelTimeUntilOpen.Text = "labelTimeUntilOpen";
            // 
            // buttonExpertDefault
            // 
            this.buttonExpertDefault.AutoSize = true;
            this.buttonExpertDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExpertDefault.Location = new System.Drawing.Point(9, 378);
            this.buttonExpertDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonExpertDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonExpertDefault.Name = "buttonExpertDefault";
            this.buttonExpertDefault.Size = new System.Drawing.Size(124, 25);
            this.buttonExpertDefault.TabIndex = 0;
            this.buttonExpertDefault.Text = "buttonExpertDefault";
            this.buttonExpertDefault.UseVisualStyleBackColor = true;
            this.buttonExpertDefault.Click += new System.EventHandler(this.ButtonExpertDefault_Click);
            // 
            // tabPageCustomize
            // 
            this.tabPageCustomize.AutoScroll = true;
            this.tabPageCustomize.Controls.Add(this.tableLayoutPanelCustomize);
            this.tabPageCustomize.Location = new System.Drawing.Point(4, 24);
            this.tabPageCustomize.Name = "tabPageCustomize";
            this.tabPageCustomize.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomize.Size = new System.Drawing.Size(412, 495);
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
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColorsDarkMode, 0, 2);
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColorsLightMode, 0, 1);
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxAppearance, 0, 0);
            this.tableLayoutPanelCustomize.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            this.tableLayoutPanelCustomize.RowCount = 3;
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.Size = new System.Drawing.Size(391, 1506);
            this.tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxColorsDarkMode
            // 
            this.groupBoxColorsDarkMode.AutoSize = true;
            this.groupBoxColorsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsDarkMode.Controls.Add(this.tableLayoutPanelDarkMode);
            this.groupBoxColorsDarkMode.Location = new System.Drawing.Point(3, 898);
            this.groupBoxColorsDarkMode.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsDarkMode.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsDarkMode.Name = "groupBoxColorsDarkMode";
            this.groupBoxColorsDarkMode.Size = new System.Drawing.Size(385, 605);
            this.groupBoxColorsDarkMode.TabIndex = 0;
            this.groupBoxColorsDarkMode.TabStop = false;
            this.groupBoxColorsDarkMode.Text = "groupBoxColorsDarkMode";
            // 
            // tableLayoutPanelDarkMode
            // 
            this.tableLayoutPanelDarkMode.AutoSize = true;
            this.tableLayoutPanelDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDarkMode.ColumnCount = 1;
            this.tableLayoutPanelDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelColorIconsDarkMode, 0, 1);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelColorBackgroundBorderDarkMode, 0, 3);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelMenuDarkMode, 0, 0);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSearchFieldDarkMode, 0, 4);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelOpenFolderDarkMode, 0, 5);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelOpenFolderBorderDarkMode, 0, 6);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSelectedItemDarkMode, 0, 7);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSelectedItemBorderDarkMode, 0, 8);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelScrollbarDarkMode, 0, 9);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelScrollbarBackgroundDarkMode, 0, 10);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderDarkMode, 0, 11);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderDraggingDarkMode, 0, 12);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderHoverDarkMode, 0, 13);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode, 0, 14);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowDarkMode, 0, 15);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowClickDarkMode, 0, 16);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowClickBackgroundDarkMode, 0, 17);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowHoverDarkMode, 0, 18);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelArrowHoverBackgroundDarkMode, 0, 19);
            this.tableLayoutPanelDarkMode.Controls.Add(this.buttonColorsDefaultDarkMode, 0, 20);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelBackgroundDarkMode, 0, 2);
            this.tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDarkMode.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            this.tableLayoutPanelDarkMode.RowCount = 21;
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
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDarkMode.Size = new System.Drawing.Size(379, 583);
            this.tableLayoutPanelDarkMode.TabIndex = 0;
            // 
            // tableLayoutPanelColorIconsDarkMode
            // 
            this.tableLayoutPanelColorIconsDarkMode.AutoSize = true;
            this.tableLayoutPanelColorIconsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorIconsDarkMode.ColumnCount = 3;
            this.tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelColorIconsDarkMode.Controls.Add(this.pictureBoxIconsDarkMode, 0, 0);
            this.tableLayoutPanelColorIconsDarkMode.Controls.Add(this.labelIconsDarkMode, 2, 0);
            this.tableLayoutPanelColorIconsDarkMode.Controls.Add(this.textBoxColorIconsDarkMode, 1, 0);
            this.tableLayoutPanelColorIconsDarkMode.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelColorIconsDarkMode.Name = "tableLayoutPanelColorIconsDarkMode";
            this.tableLayoutPanelColorIconsDarkMode.RowCount = 1;
            this.tableLayoutPanelColorIconsDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorIconsDarkMode.Size = new System.Drawing.Size(213, 23);
            this.tableLayoutPanelColorIconsDarkMode.TabIndex = 2;
            // 
            // pictureBoxIconsDarkMode
            // 
            this.pictureBoxIconsDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxIconsDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIconsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIconsDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIconsDarkMode.Name = "pictureBoxIconsDarkMode";
            this.pictureBoxIconsDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxIconsDarkMode.TabIndex = 1;
            this.pictureBoxIconsDarkMode.TabStop = false;
            this.pictureBoxIconsDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelIconsDarkMode
            // 
            this.labelIconsDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIconsDarkMode.AutoSize = true;
            this.labelIconsDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelIconsDarkMode.Name = "labelIconsDarkMode";
            this.labelIconsDarkMode.Size = new System.Drawing.Size(115, 15);
            this.labelIconsDarkMode.TabIndex = 0;
            this.labelIconsDarkMode.Text = "labelIconsDarkMode";
            // 
            // textBoxColorIconsDarkMode
            // 
            this.textBoxColorIconsDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorIconsDarkMode.MaxLength = 12;
            this.textBoxColorIconsDarkMode.Name = "textBoxColorIconsDarkMode";
            this.textBoxColorIconsDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorIconsDarkMode.TabIndex = 2;
            this.textBoxColorIconsDarkMode.Text = "#ffffff";
            this.textBoxColorIconsDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorIconsDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorIconsDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // tableLayoutPanelColorBackgroundBorderDarkMode
            // 
            this.tableLayoutPanelColorBackgroundBorderDarkMode.AutoSize = true;
            this.tableLayoutPanelColorBackgroundBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorBackgroundBorderDarkMode.ColumnCount = 3;
            this.tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(this.pictureBoxBackgroundBorderDarkMode, 0, 0);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(this.labelBackgroundBorderDarkMode, 2, 0);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(this.textBoxColorBackgroundBorderDarkMode, 1, 0);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Name = "tableLayoutPanelColorBackgroundBorderDarkMode";
            this.tableLayoutPanelColorBackgroundBorderDarkMode.RowCount = 1;
            this.tableLayoutPanelColorBackgroundBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorBackgroundBorderDarkMode.Size = new System.Drawing.Size(284, 23);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxBackgroundBorderDarkMode
            // 
            this.pictureBoxBackgroundBorderDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackgroundBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackgroundBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackgroundBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackgroundBorderDarkMode.Name = "pictureBoxBackgroundBorderDarkMode";
            this.pictureBoxBackgroundBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxBackgroundBorderDarkMode.TabIndex = 1;
            this.pictureBoxBackgroundBorderDarkMode.TabStop = false;
            this.pictureBoxBackgroundBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelBackgroundBorderDarkMode
            // 
            this.labelBackgroundBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackgroundBorderDarkMode.AutoSize = true;
            this.labelBackgroundBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelBackgroundBorderDarkMode.Name = "labelBackgroundBorderDarkMode";
            this.labelBackgroundBorderDarkMode.Size = new System.Drawing.Size(186, 15);
            this.labelBackgroundBorderDarkMode.TabIndex = 0;
            this.labelBackgroundBorderDarkMode.Text = "labelBackgroundDarkModeBorder";
            // 
            // textBoxColorBackgroundBorderDarkMode
            // 
            this.textBoxColorBackgroundBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundBorderDarkMode.MaxLength = 12;
            this.textBoxColorBackgroundBorderDarkMode.Name = "textBoxColorBackgroundBorderDarkMode";
            this.textBoxColorBackgroundBorderDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorBackgroundBorderDarkMode.TabIndex = 2;
            this.textBoxColorBackgroundBorderDarkMode.Text = "#ffffff";
            this.textBoxColorBackgroundBorderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackgroundBorderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackgroundBorderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelMenuDarkMode
            // 
            this.labelMenuDarkMode.AutoSize = true;
            this.labelMenuDarkMode.Location = new System.Drawing.Point(3, 0);
            this.labelMenuDarkMode.Name = "labelMenuDarkMode";
            this.labelMenuDarkMode.Size = new System.Drawing.Size(118, 15);
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
            this.tableLayoutPanelSearchFieldDarkMode.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanelSearchFieldDarkMode.Name = "tableLayoutPanelSearchFieldDarkMode";
            this.tableLayoutPanelSearchFieldDarkMode.RowCount = 1;
            this.tableLayoutPanelSearchFieldDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearchFieldDarkMode.Size = new System.Drawing.Size(245, 23);
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
            this.pictureBoxSearchFieldDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSearchFieldDarkMode.TabIndex = 1;
            this.pictureBoxSearchFieldDarkMode.TabStop = false;
            this.pictureBoxSearchFieldDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSearchFieldDarkMode
            // 
            this.labelSearchFieldDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSearchFieldDarkMode.AutoSize = true;
            this.labelSearchFieldDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelSearchFieldDarkMode.Name = "labelSearchFieldDarkMode";
            this.labelSearchFieldDarkMode.Size = new System.Drawing.Size(147, 15);
            this.labelSearchFieldDarkMode.TabIndex = 0;
            this.labelSearchFieldDarkMode.Text = "labelSearchFieldDarkMode";
            // 
            // textBoxColorSearchFieldDarkMode
            // 
            this.textBoxColorSearchFieldDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSearchFieldDarkMode.MaxLength = 12;
            this.textBoxColorSearchFieldDarkMode.Name = "textBoxColorSearchFieldDarkMode";
            this.textBoxColorSearchFieldDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.tableLayoutPanelOpenFolderDarkMode.Location = new System.Drawing.Point(3, 134);
            this.tableLayoutPanelOpenFolderDarkMode.Name = "tableLayoutPanelOpenFolderDarkMode";
            this.tableLayoutPanelOpenFolderDarkMode.RowCount = 1;
            this.tableLayoutPanelOpenFolderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderDarkMode.Size = new System.Drawing.Size(247, 23);
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
            this.pictureBoxOpenFolderDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxOpenFolderDarkMode.TabIndex = 1;
            this.pictureBoxOpenFolderDarkMode.TabStop = false;
            this.pictureBoxOpenFolderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelOpenFolderDarkMode
            // 
            this.labelOpenFolderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderDarkMode.AutoSize = true;
            this.labelOpenFolderDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelOpenFolderDarkMode.Name = "labelOpenFolderDarkMode";
            this.labelOpenFolderDarkMode.Size = new System.Drawing.Size(149, 15);
            this.labelOpenFolderDarkMode.TabIndex = 0;
            this.labelOpenFolderDarkMode.Text = "labelOpenFolderDarkMode";
            // 
            // textBoxColorOpenFolderDarkMode
            // 
            this.textBoxColorOpenFolderDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderDarkMode.MaxLength = 12;
            this.textBoxColorOpenFolderDarkMode.Name = "textBoxColorOpenFolderDarkMode";
            this.textBoxColorOpenFolderDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.tableLayoutPanelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(3, 163);
            this.tableLayoutPanelOpenFolderBorderDarkMode.Name = "tableLayoutPanelOpenFolderBorderDarkMode";
            this.tableLayoutPanelOpenFolderBorderDarkMode.RowCount = 1;
            this.tableLayoutPanelOpenFolderBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(282, 23);
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
            this.pictureBoxOpenFolderBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxOpenFolderBorderDarkMode.TabIndex = 1;
            this.pictureBoxOpenFolderBorderDarkMode.TabStop = false;
            this.pictureBoxOpenFolderBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelOpenFolderBorderDarkMode
            // 
            this.labelOpenFolderBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderBorderDarkMode.AutoSize = true;
            this.labelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelOpenFolderBorderDarkMode.Name = "labelOpenFolderBorderDarkMode";
            this.labelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(184, 15);
            this.labelOpenFolderBorderDarkMode.TabIndex = 0;
            this.labelOpenFolderBorderDarkMode.Text = "labelOpenFolderBorderDarkMode";
            // 
            // textBoxColorOpenFolderBorderDarkMode
            // 
            this.textBoxColorOpenFolderBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderBorderDarkMode.Name = "textBoxColorOpenFolderBorderDarkMode";
            this.textBoxColorOpenFolderBorderDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.tableLayoutPanelSelectedItemDarkMode.Location = new System.Drawing.Point(3, 192);
            this.tableLayoutPanelSelectedItemDarkMode.Name = "tableLayoutPanelSelectedItemDarkMode";
            this.tableLayoutPanelSelectedItemDarkMode.RowCount = 1;
            this.tableLayoutPanelSelectedItemDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemDarkMode.Size = new System.Drawing.Size(253, 23);
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
            this.pictureColorBoxSelectedItemDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureColorBoxSelectedItemDarkMode.TabIndex = 1;
            this.pictureColorBoxSelectedItemDarkMode.TabStop = false;
            this.pictureColorBoxSelectedItemDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSelectedItemDarkMode
            // 
            this.labelSelectedItemDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemDarkMode.AutoSize = true;
            this.labelSelectedItemDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelSelectedItemDarkMode.Name = "labelSelectedItemDarkMode";
            this.labelSelectedItemDarkMode.Size = new System.Drawing.Size(155, 15);
            this.labelSelectedItemDarkMode.TabIndex = 0;
            this.labelSelectedItemDarkMode.Text = "labelSelectedItemDarkMode";
            // 
            // textBoxColorSelecetedItemDarkMode
            // 
            this.textBoxColorSelecetedItemDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSelecetedItemDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelecetedItemDarkMode.MaxLength = 12;
            this.textBoxColorSelecetedItemDarkMode.Name = "textBoxColorSelecetedItemDarkMode";
            this.textBoxColorSelecetedItemDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.tableLayoutPanelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(3, 221);
            this.tableLayoutPanelSelectedItemBorderDarkMode.Name = "tableLayoutPanelSelectedItemBorderDarkMode";
            this.tableLayoutPanelSelectedItemBorderDarkMode.RowCount = 1;
            this.tableLayoutPanelSelectedItemBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(288, 23);
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
            this.pictureBoxSelectedItemBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSelectedItemBorderDarkMode.TabIndex = 1;
            this.pictureBoxSelectedItemBorderDarkMode.TabStop = false;
            this.pictureBoxSelectedItemBorderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelSelectedItemBorderDarkMode
            // 
            this.labelSelectedItemBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemBorderDarkMode.AutoSize = true;
            this.labelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelSelectedItemBorderDarkMode.Name = "labelSelectedItemBorderDarkMode";
            this.labelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(190, 15);
            this.labelSelectedItemBorderDarkMode.TabIndex = 0;
            this.labelSelectedItemBorderDarkMode.Text = "labelSelectedItemBorderDarkMode";
            // 
            // textBoxColorSelectedItemBorderDarkMode
            // 
            this.textBoxColorSelectedItemBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItemBorderDarkMode.MaxLength = 12;
            this.textBoxColorSelectedItemBorderDarkMode.Name = "textBoxColorSelectedItemBorderDarkMode";
            this.textBoxColorSelectedItemBorderDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorSelectedItemBorderDarkMode.TabIndex = 2;
            this.textBoxColorSelectedItemBorderDarkMode.Text = "#ffffff";
            this.textBoxColorSelectedItemBorderDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItemBorderDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorSelectedItemBorderDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // labelScrollbarDarkMode
            // 
            this.labelScrollbarDarkMode.AutoSize = true;
            this.labelScrollbarDarkMode.Location = new System.Drawing.Point(3, 247);
            this.labelScrollbarDarkMode.Name = "labelScrollbarDarkMode";
            this.labelScrollbarDarkMode.Size = new System.Drawing.Size(133, 15);
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
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(3, 265);
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Name = "tableLayoutPanelScrollbarBackgroundDarkMode";
            this.tableLayoutPanelScrollbarBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelScrollbarBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(324, 23);
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
            this.pictureBoxScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxScrollbarBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxScrollbarBackgroundDarkMode.TabStop = false;
            this.pictureBoxScrollbarBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorScrollbarBackgroundDarkMode
            // 
            this.textBoxColorScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorScrollbarBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorScrollbarBackgroundDarkMode.Name = "textBoxColorScrollbarBackgroundDarkMode";
            this.textBoxColorScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeScrollbarBackground.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeScrollbarBackground.Name = "labelColorDarkModeScrollbarBackground";
            this.labelColorDarkModeScrollbarBackground.Size = new System.Drawing.Size(226, 15);
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
            this.tableLayoutPanelSliderDarkMode.Location = new System.Drawing.Point(3, 294);
            this.tableLayoutPanelSliderDarkMode.Name = "tableLayoutPanelSliderDarkMode";
            this.tableLayoutPanelSliderDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDarkMode.Size = new System.Drawing.Size(243, 23);
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
            this.pictureBoxSliderDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderDarkMode.TabIndex = 1;
            this.pictureBoxSliderDarkMode.TabStop = false;
            this.pictureBoxSliderDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDarkMode
            // 
            this.textBoxColorSliderDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDarkMode.MaxLength = 12;
            this.textBoxColorSliderDarkMode.Name = "textBoxColorSliderDarkMode";
            this.textBoxColorSliderDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeSlider.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeSlider.Name = "labelColorDarkModeSlider";
            this.labelColorDarkModeSlider.Size = new System.Drawing.Size(145, 15);
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
            this.tableLayoutPanelSliderDraggingDarkMode.Location = new System.Drawing.Point(3, 323);
            this.tableLayoutPanelSliderDraggingDarkMode.Name = "tableLayoutPanelSliderDraggingDarkMode";
            this.tableLayoutPanelSliderDraggingDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderDraggingDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDraggingDarkMode.Size = new System.Drawing.Size(292, 23);
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
            this.pictureBoxSliderDraggingDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderDraggingDarkMode.TabIndex = 1;
            this.pictureBoxSliderDraggingDarkMode.TabStop = false;
            this.pictureBoxSliderDraggingDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDraggingDarkMode
            // 
            this.textBoxColorSliderDraggingDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDraggingDarkMode.MaxLength = 12;
            this.textBoxColorSliderDraggingDarkMode.Name = "textBoxColorSliderDraggingDarkMode";
            this.textBoxColorSliderDraggingDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeSliderDragging.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeSliderDragging.Name = "labelColorDarkModeSliderDragging";
            this.labelColorDarkModeSliderDragging.Size = new System.Drawing.Size(194, 15);
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
            this.tableLayoutPanelSliderHoverDarkMode.Location = new System.Drawing.Point(3, 352);
            this.tableLayoutPanelSliderHoverDarkMode.Name = "tableLayoutPanelSliderHoverDarkMode";
            this.tableLayoutPanelSliderHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderHoverDarkMode.Size = new System.Drawing.Size(275, 23);
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
            this.pictureBoxSliderHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderHoverDarkMode.TabIndex = 1;
            this.pictureBoxSliderHoverDarkMode.TabStop = false;
            this.pictureBoxSliderHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderHoverDarkMode
            // 
            this.textBoxColorSliderHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderHoverDarkMode.MaxLength = 12;
            this.textBoxColorSliderHoverDarkMode.Name = "textBoxColorSliderHoverDarkMode";
            this.textBoxColorSliderHoverDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeSliderHover.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeSliderHover.Name = "labelColorDarkModeSliderHover";
            this.labelColorDarkModeSliderHover.Size = new System.Drawing.Size(177, 15);
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
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(3, 381);
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Name = "tableLayoutPanelSliderArrowsAndTrackHoverDarkMode";
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(361, 23);
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
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.TabIndex = 1;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.TabStop = false;
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderArrowsAndTrackHoverDarkMode
            // 
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.MaxLength = 12;
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Name = "textBoxColorSliderArrowsAndTrackHoverDarkMode";
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeSliderArrowsAndTrackHover.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeSliderArrowsAndTrackHover.Name = "labelColorDarkModeSliderArrowsAndTrackHover";
            this.labelColorDarkModeSliderArrowsAndTrackHover.Size = new System.Drawing.Size(263, 15);
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
            this.tableLayoutPanelArrowDarkMode.Location = new System.Drawing.Point(3, 410);
            this.tableLayoutPanelArrowDarkMode.Name = "tableLayoutPanelArrowDarkMode";
            this.tableLayoutPanelArrowDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowDarkMode.Size = new System.Drawing.Size(246, 23);
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
            this.pictureBoxArrowDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowDarkMode.TabIndex = 1;
            this.pictureBoxArrowDarkMode.TabStop = false;
            this.pictureBoxArrowDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowDarkMode
            // 
            this.textBoxColorArrowDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowDarkMode.MaxLength = 12;
            this.textBoxColorArrowDarkMode.Name = "textBoxColorArrowDarkMode";
            this.textBoxColorArrowDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeArrow.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrow.Name = "labelColorDarkModeArrow";
            this.labelColorDarkModeArrow.Size = new System.Drawing.Size(148, 15);
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
            this.tableLayoutPanelArrowClickDarkMode.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanelArrowClickDarkMode.Name = "tableLayoutPanelArrowClickDarkMode";
            this.tableLayoutPanelArrowClickDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowClickDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickDarkMode.Size = new System.Drawing.Size(272, 23);
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
            this.pictureBoxArrowClickDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowClickDarkMode.TabIndex = 1;
            this.pictureBoxArrowClickDarkMode.TabStop = false;
            this.pictureBoxArrowClickDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickDarkMode
            // 
            this.textBoxColorArrowClickDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickDarkMode.MaxLength = 12;
            this.textBoxColorArrowClickDarkMode.Name = "textBoxColorArrowClickDarkMode";
            this.textBoxColorArrowClickDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeArrowClick.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrowClick.Name = "labelColorDarkModeArrowClick";
            this.labelColorDarkModeArrowClick.Size = new System.Drawing.Size(174, 15);
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
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(3, 468);
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Name = "tableLayoutPanelArrowClickBackgroundDarkMode";
            this.tableLayoutPanelArrowClickBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowClickBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(336, 23);
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
            this.pictureBoxArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowClickBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxArrowClickBackgroundDarkMode.TabStop = false;
            this.pictureBoxArrowClickBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickBackgroundDarkMode
            // 
            this.textBoxColorArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorArrowClickBackgroundDarkMode.Name = "textBoxColorArrowClickBackgroundDarkMode";
            this.textBoxColorArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeArrowClickBackground.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrowClickBackground.Name = "labelColorDarkModeArrowClickBackground";
            this.labelColorDarkModeArrowClickBackground.Size = new System.Drawing.Size(238, 15);
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
            this.tableLayoutPanelArrowHoverDarkMode.Location = new System.Drawing.Point(3, 497);
            this.tableLayoutPanelArrowHoverDarkMode.Name = "tableLayoutPanelArrowHoverDarkMode";
            this.tableLayoutPanelArrowHoverDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverDarkMode.Size = new System.Drawing.Size(278, 23);
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
            this.pictureBoxArrowHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowHoverDarkMode.TabIndex = 1;
            this.pictureBoxArrowHoverDarkMode.TabStop = false;
            this.pictureBoxArrowHoverDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverDarkMode
            // 
            this.textBoxColorArrowHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverDarkMode.MaxLength = 12;
            this.textBoxColorArrowHoverDarkMode.Name = "textBoxColorArrowHoverDarkMode";
            this.textBoxColorArrowHoverDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeArrowHover.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrowHover.Name = "labelColorDarkModeArrowHover";
            this.labelColorDarkModeArrowHover.Size = new System.Drawing.Size(180, 15);
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
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(3, 526);
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Name = "tableLayoutPanelArrowHoverBackgroundDarkMode";
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(342, 23);
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
            this.pictureBoxArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowHoverBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxArrowHoverBackgroundDarkMode.TabStop = false;
            this.pictureBoxArrowHoverBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverBackgroundDarkMode
            // 
            this.textBoxColorArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorArrowHoverBackgroundDarkMode.Name = "textBoxColorArrowHoverBackgroundDarkMode";
            this.textBoxColorArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
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
            this.labelColorDarkModeArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrowHoverBackground.MaximumSize = new System.Drawing.Size(280, 0);
            this.labelColorDarkModeArrowHoverBackground.Name = "labelColorDarkModeArrowHoverBackground";
            this.labelColorDarkModeArrowHoverBackground.Size = new System.Drawing.Size(244, 15);
            this.labelColorDarkModeArrowHoverBackground.TabIndex = 0;
            this.labelColorDarkModeArrowHoverBackground.Text = "labelColorDarkModeArrowHoverBackground";
            // 
            // buttonColorsDefaultDarkMode
            // 
            this.buttonColorsDefaultDarkMode.AutoSize = true;
            this.buttonColorsDefaultDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColorsDefaultDarkMode.Location = new System.Drawing.Point(3, 555);
            this.buttonColorsDefaultDarkMode.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonColorsDefaultDarkMode.Name = "buttonColorsDefaultDarkMode";
            this.buttonColorsDefaultDarkMode.Size = new System.Drawing.Size(180, 25);
            this.buttonColorsDefaultDarkMode.TabIndex = 2;
            this.buttonColorsDefaultDarkMode.Text = "buttonColorsDarkModeDefault";
            this.buttonColorsDefaultDarkMode.UseVisualStyleBackColor = true;
            this.buttonColorsDefaultDarkMode.Click += new System.EventHandler(this.ButtonDefaultColorsDark_Click);
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
            this.tableLayoutPanelBackgroundDarkMode.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanelBackgroundDarkMode.Name = "tableLayoutPanelBackgroundDarkMode";
            this.tableLayoutPanelBackgroundDarkMode.RowCount = 1;
            this.tableLayoutPanelBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundDarkMode.Size = new System.Drawing.Size(249, 23);
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
            this.pictureBoxBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxBackgroundDarkMode.TabIndex = 1;
            this.pictureBoxBackgroundDarkMode.TabStop = false;
            this.pictureBoxBackgroundDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelBackgroundDarkMode
            // 
            this.labelBackgroundDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackgroundDarkMode.AutoSize = true;
            this.labelBackgroundDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelBackgroundDarkMode.Name = "labelBackgroundDarkMode";
            this.labelBackgroundDarkMode.Size = new System.Drawing.Size(151, 15);
            this.labelBackgroundDarkMode.TabIndex = 0;
            this.labelBackgroundDarkMode.Text = "labelBackgroundDarkMode";
            // 
            // textBoxColorBackgroundDarkMode
            // 
            this.textBoxColorBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundDarkMode.MaxLength = 12;
            this.textBoxColorBackgroundDarkMode.Name = "textBoxColorBackgroundDarkMode";
            this.textBoxColorBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorBackgroundDarkMode.TabIndex = 2;
            this.textBoxColorBackgroundDarkMode.Text = "#ffffff";
            this.textBoxColorBackgroundDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackgroundDarkMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyDown);
            this.textBoxColorBackgroundDarkMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopPlayingDingSoundEnterKeyPressed_KeyUp);
            // 
            // groupBoxColorsLightMode
            // 
            this.groupBoxColorsLightMode.AutoSize = true;
            this.groupBoxColorsLightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsLightMode.Controls.Add(this.tableLayoutPanelColorsAndDefault);
            this.groupBoxColorsLightMode.Location = new System.Drawing.Point(3, 287);
            this.groupBoxColorsLightMode.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsLightMode.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsLightMode.Name = "groupBoxColorsLightMode";
            this.groupBoxColorsLightMode.Size = new System.Drawing.Size(385, 605);
            this.groupBoxColorsLightMode.TabIndex = 0;
            this.groupBoxColorsLightMode.TabStop = false;
            this.groupBoxColorsLightMode.Text = "groupBoxColorsLightMode";
            // 
            // tableLayoutPanelColorsAndDefault
            // 
            this.tableLayoutPanelColorsAndDefault.AutoSize = true;
            this.tableLayoutPanelColorsAndDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorsAndDefault.ColumnCount = 1;
            this.tableLayoutPanelColorsAndDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelIcons, 0, 1);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelBackgroundBorder, 0, 3);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelMenuLightMode, 0, 0);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelBackground, 0, 2);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.buttonColorsDefault, 0, 20);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowHoverBackground, 0, 19);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowHover, 0, 18);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowClickBackground, 0, 17);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrowClick, 0, 16);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelArrow, 0, 15);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderArrowsAndTrackHover, 0, 14);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderHover, 0, 13);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSliderDragging, 0, 12);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSlider, 0, 11);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelScrollbarBackground, 0, 10);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelScrollbarLightMode, 0, 9);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSelectedItemBorder, 0, 8);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSelectedItem, 0, 7);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelOpenFolderBorder, 0, 6);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelOpenFolder, 0, 5);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelSearchField, 0, 4);
            this.tableLayoutPanelColorsAndDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColorsAndDefault.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelColorsAndDefault.Name = "tableLayoutPanelColorsAndDefault";
            this.tableLayoutPanelColorsAndDefault.RowCount = 21;
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
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelColorsAndDefault.Size = new System.Drawing.Size(379, 583);
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
            this.tableLayoutPanelIcons.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelIcons.Name = "tableLayoutPanelIcons";
            this.tableLayoutPanelIcons.RowCount = 1;
            this.tableLayoutPanelIcons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelIcons.Size = new System.Drawing.Size(158, 23);
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
            this.pictureBoxIcons.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxIcons.TabIndex = 1;
            this.pictureBoxIcons.TabStop = false;
            this.pictureBoxIcons.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorIcons
            // 
            this.textBoxColorIcons.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorIcons.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorIcons.MaxLength = 12;
            this.textBoxColorIcons.Name = "textBoxColorIcons";
            this.textBoxColorIcons.Size = new System.Drawing.Size(69, 23);
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
            this.labelIcons.Location = new System.Drawing.Point(95, 4);
            this.labelIcons.Name = "labelIcons";
            this.labelIcons.Size = new System.Drawing.Size(60, 15);
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
            this.tableLayoutPanelBackgroundBorder.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanelBackgroundBorder.Name = "tableLayoutPanelBackgroundBorder";
            this.tableLayoutPanelBackgroundBorder.RowCount = 1;
            this.tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelBackgroundBorder.Size = new System.Drawing.Size(229, 23);
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
            this.pictureBoxBackgroundBorder.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxBackgroundBorder.TabIndex = 1;
            this.pictureBoxBackgroundBorder.TabStop = false;
            this.pictureBoxBackgroundBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorBackgroundBorder
            // 
            this.textBoxColorBackgroundBorder.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorBackgroundBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackgroundBorder.MaxLength = 12;
            this.textBoxColorBackgroundBorder.Name = "textBoxColorBackgroundBorder";
            this.textBoxColorBackgroundBorder.Size = new System.Drawing.Size(69, 23);
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
            this.labelBackgroundBorder.Location = new System.Drawing.Point(95, 4);
            this.labelBackgroundBorder.Name = "labelBackgroundBorder";
            this.labelBackgroundBorder.Size = new System.Drawing.Size(131, 15);
            this.labelBackgroundBorder.TabIndex = 0;
            this.labelBackgroundBorder.Text = "labelBackgroundBorder";
            // 
            // labelMenuLightMode
            // 
            this.labelMenuLightMode.AutoSize = true;
            this.labelMenuLightMode.Location = new System.Drawing.Point(3, 0);
            this.labelMenuLightMode.Name = "labelMenuLightMode";
            this.labelMenuLightMode.Size = new System.Drawing.Size(121, 15);
            this.labelMenuLightMode.TabIndex = 3;
            this.labelMenuLightMode.Text = "labelMenuLightMode";
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
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 1;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(194, 23);
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
            this.pictureBoxBackground.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxBackground.TabIndex = 1;
            this.pictureBoxBackground.TabStop = false;
            this.pictureBoxBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorBackground
            // 
            this.textBoxColorBackground.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorBackground.MaxLength = 12;
            this.textBoxColorBackground.Name = "textBoxColorBackground";
            this.textBoxColorBackground.Size = new System.Drawing.Size(69, 23);
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
            this.labelBackground.Location = new System.Drawing.Point(95, 4);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(96, 15);
            this.labelBackground.TabIndex = 0;
            this.labelBackground.Text = "labelBackground";
            // 
            // buttonColorsDefault
            // 
            this.buttonColorsDefault.AutoSize = true;
            this.buttonColorsDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColorsDefault.Location = new System.Drawing.Point(3, 555);
            this.buttonColorsDefault.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonColorsDefault.Name = "buttonColorsDefault";
            this.buttonColorsDefault.Size = new System.Drawing.Size(125, 25);
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
            this.tableLayoutPanelArrowHoverBackground.Location = new System.Drawing.Point(3, 526);
            this.tableLayoutPanelArrowHoverBackground.Name = "tableLayoutPanelArrowHoverBackground";
            this.tableLayoutPanelArrowHoverBackground.RowCount = 1;
            this.tableLayoutPanelArrowHoverBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHoverBackground.Size = new System.Drawing.Size(258, 23);
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
            this.pictureBoxArrowHoverBackground.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowHoverBackground.TabIndex = 1;
            this.pictureBoxArrowHoverBackground.TabStop = false;
            this.pictureBoxArrowHoverBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHoverBackground
            // 
            this.textBoxColorArrowHoverBackground.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowHoverBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHoverBackground.MaxLength = 12;
            this.textBoxColorArrowHoverBackground.Name = "textBoxColorArrowHoverBackground";
            this.textBoxColorArrowHoverBackground.Size = new System.Drawing.Size(69, 23);
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
            this.labelArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            this.labelArrowHoverBackground.MaximumSize = new System.Drawing.Size(280, 0);
            this.labelArrowHoverBackground.Name = "labelArrowHoverBackground";
            this.labelArrowHoverBackground.Size = new System.Drawing.Size(160, 15);
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
            this.tableLayoutPanelArrowHover.Location = new System.Drawing.Point(3, 497);
            this.tableLayoutPanelArrowHover.Name = "tableLayoutPanelArrowHover";
            this.tableLayoutPanelArrowHover.RowCount = 1;
            this.tableLayoutPanelArrowHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowHover.Size = new System.Drawing.Size(194, 23);
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
            this.pictureBoxArrowHover.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowHover.TabIndex = 1;
            this.pictureBoxArrowHover.TabStop = false;
            this.pictureBoxArrowHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowHover
            // 
            this.textBoxColorArrowHover.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowHover.MaxLength = 12;
            this.textBoxColorArrowHover.Name = "textBoxColorArrowHover";
            this.textBoxColorArrowHover.Size = new System.Drawing.Size(69, 23);
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
            this.labelArrowHover.Location = new System.Drawing.Point(95, 4);
            this.labelArrowHover.Name = "labelArrowHover";
            this.labelArrowHover.Size = new System.Drawing.Size(96, 15);
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
            this.tableLayoutPanelArrowClickBackground.Location = new System.Drawing.Point(3, 468);
            this.tableLayoutPanelArrowClickBackground.Name = "tableLayoutPanelArrowClickBackground";
            this.tableLayoutPanelArrowClickBackground.RowCount = 1;
            this.tableLayoutPanelArrowClickBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClickBackground.Size = new System.Drawing.Size(252, 23);
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
            this.pictureBoxArrowClickBackground.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowClickBackground.TabIndex = 1;
            this.pictureBoxArrowClickBackground.TabStop = false;
            this.pictureBoxArrowClickBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClickBackground
            // 
            this.textBoxColorArrowClickBackground.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowClickBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClickBackground.MaxLength = 12;
            this.textBoxColorArrowClickBackground.Name = "textBoxColorArrowClickBackground";
            this.textBoxColorArrowClickBackground.Size = new System.Drawing.Size(69, 23);
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
            this.labelArrowClickBackground.Location = new System.Drawing.Point(95, 4);
            this.labelArrowClickBackground.Name = "labelArrowClickBackground";
            this.labelArrowClickBackground.Size = new System.Drawing.Size(154, 15);
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
            this.tableLayoutPanelArrowClick.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanelArrowClick.Name = "tableLayoutPanelArrowClick";
            this.tableLayoutPanelArrowClick.RowCount = 1;
            this.tableLayoutPanelArrowClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrowClick.Size = new System.Drawing.Size(188, 23);
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
            this.pictureBoxArrowClick.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrowClick.TabIndex = 1;
            this.pictureBoxArrowClick.TabStop = false;
            this.pictureBoxArrowClick.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrowClick
            // 
            this.textBoxColorArrowClick.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrowClick.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrowClick.MaxLength = 12;
            this.textBoxColorArrowClick.Name = "textBoxColorArrowClick";
            this.textBoxColorArrowClick.Size = new System.Drawing.Size(69, 23);
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
            this.labelArrowClick.Location = new System.Drawing.Point(95, 4);
            this.labelArrowClick.Name = "labelArrowClick";
            this.labelArrowClick.Size = new System.Drawing.Size(90, 15);
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
            this.tableLayoutPanelArrow.Location = new System.Drawing.Point(3, 410);
            this.tableLayoutPanelArrow.Name = "tableLayoutPanelArrow";
            this.tableLayoutPanelArrow.RowCount = 1;
            this.tableLayoutPanelArrow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelArrow.Size = new System.Drawing.Size(162, 23);
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
            this.pictureBoxArrow.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxArrow.TabIndex = 1;
            this.pictureBoxArrow.TabStop = false;
            this.pictureBoxArrow.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorArrow
            // 
            this.textBoxColorArrow.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorArrow.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorArrow.MaxLength = 12;
            this.textBoxColorArrow.Name = "textBoxColorArrow";
            this.textBoxColorArrow.Size = new System.Drawing.Size(69, 23);
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
            this.labelArrow.Location = new System.Drawing.Point(95, 4);
            this.labelArrow.Name = "labelArrow";
            this.labelArrow.Size = new System.Drawing.Size(64, 15);
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
            this.tableLayoutPanelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(3, 381);
            this.tableLayoutPanelSliderArrowsAndTrackHover.Name = "tableLayoutPanelSliderArrowsAndTrackHover";
            this.tableLayoutPanelSliderArrowsAndTrackHover.RowCount = 1;
            this.tableLayoutPanelSliderArrowsAndTrackHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(277, 23);
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
            this.pictureBoxSliderArrowsAndTrackHover.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderArrowsAndTrackHover.TabIndex = 1;
            this.pictureBoxSliderArrowsAndTrackHover.TabStop = false;
            this.pictureBoxSliderArrowsAndTrackHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderArrowsAndTrackHover
            // 
            this.textBoxColorSliderArrowsAndTrackHover.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderArrowsAndTrackHover.MaxLength = 12;
            this.textBoxColorSliderArrowsAndTrackHover.Name = "textBoxColorSliderArrowsAndTrackHover";
            this.textBoxColorSliderArrowsAndTrackHover.Size = new System.Drawing.Size(69, 23);
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
            this.labelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(95, 4);
            this.labelSliderArrowsAndTrackHover.Name = "labelSliderArrowsAndTrackHover";
            this.labelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(179, 15);
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
            this.tableLayoutPanelSliderHover.Location = new System.Drawing.Point(3, 352);
            this.tableLayoutPanelSliderHover.Name = "tableLayoutPanelSliderHover";
            this.tableLayoutPanelSliderHover.RowCount = 1;
            this.tableLayoutPanelSliderHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderHover.Size = new System.Drawing.Size(191, 23);
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
            this.pictureBoxSliderHover.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderHover.TabIndex = 1;
            this.pictureBoxSliderHover.TabStop = false;
            this.pictureBoxSliderHover.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderHover
            // 
            this.textBoxColorSliderHover.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderHover.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderHover.MaxLength = 12;
            this.textBoxColorSliderHover.Name = "textBoxColorSliderHover";
            this.textBoxColorSliderHover.Size = new System.Drawing.Size(69, 23);
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
            this.labelSliderHover.Location = new System.Drawing.Point(95, 4);
            this.labelSliderHover.Name = "labelSliderHover";
            this.labelSliderHover.Size = new System.Drawing.Size(93, 15);
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
            this.tableLayoutPanelSliderDragging.Location = new System.Drawing.Point(3, 323);
            this.tableLayoutPanelSliderDragging.Name = "tableLayoutPanelSliderDragging";
            this.tableLayoutPanelSliderDragging.RowCount = 1;
            this.tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelSliderDragging.Size = new System.Drawing.Size(208, 23);
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
            this.pictureBoxSliderDragging.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSliderDragging.TabIndex = 1;
            this.pictureBoxSliderDragging.TabStop = false;
            this.pictureBoxSliderDragging.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSliderDragging
            // 
            this.textBoxColorSliderDragging.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSliderDragging.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSliderDragging.MaxLength = 12;
            this.textBoxColorSliderDragging.Name = "textBoxColorSliderDragging";
            this.textBoxColorSliderDragging.Size = new System.Drawing.Size(69, 23);
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
            this.labelSliderDragging.Location = new System.Drawing.Point(95, 4);
            this.labelSliderDragging.Name = "labelSliderDragging";
            this.labelSliderDragging.Size = new System.Drawing.Size(110, 15);
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
            this.tableLayoutPanelSlider.Location = new System.Drawing.Point(3, 294);
            this.tableLayoutPanelSlider.Name = "tableLayoutPanelSlider";
            this.tableLayoutPanelSlider.RowCount = 1;
            this.tableLayoutPanelSlider.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSlider.Size = new System.Drawing.Size(159, 23);
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
            this.pictureBoxSlider.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSlider.TabIndex = 1;
            this.pictureBoxSlider.TabStop = false;
            this.pictureBoxSlider.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSlider
            // 
            this.textBoxColorSlider.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSlider.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSlider.MaxLength = 12;
            this.textBoxColorSlider.Name = "textBoxColorSlider";
            this.textBoxColorSlider.Size = new System.Drawing.Size(69, 23);
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
            this.labelSlider.Location = new System.Drawing.Point(95, 4);
            this.labelSlider.Name = "labelSlider";
            this.labelSlider.Size = new System.Drawing.Size(61, 15);
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
            this.tableLayoutPanelScrollbarBackground.Location = new System.Drawing.Point(3, 265);
            this.tableLayoutPanelScrollbarBackground.Name = "tableLayoutPanelScrollbarBackground";
            this.tableLayoutPanelScrollbarBackground.RowCount = 1;
            this.tableLayoutPanelScrollbarBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrollbarBackground.Size = new System.Drawing.Size(240, 23);
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
            this.pictureBoxScrollbarBackground.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxScrollbarBackground.TabIndex = 1;
            this.pictureBoxScrollbarBackground.TabStop = false;
            this.pictureBoxScrollbarBackground.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorScrollbarBackground
            // 
            this.textBoxColorScrollbarBackground.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorScrollbarBackground.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorScrollbarBackground.MaxLength = 12;
            this.textBoxColorScrollbarBackground.Name = "textBoxColorScrollbarBackground";
            this.textBoxColorScrollbarBackground.Size = new System.Drawing.Size(69, 23);
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
            this.labelScrollbarBackground.Location = new System.Drawing.Point(95, 4);
            this.labelScrollbarBackground.Name = "labelScrollbarBackground";
            this.labelScrollbarBackground.Size = new System.Drawing.Size(142, 15);
            this.labelScrollbarBackground.TabIndex = 0;
            this.labelScrollbarBackground.Text = "labelScrollbarBackground";
            // 
            // labelScrollbarLightMode
            // 
            this.labelScrollbarLightMode.AutoSize = true;
            this.labelScrollbarLightMode.Location = new System.Drawing.Point(3, 247);
            this.labelScrollbarLightMode.Name = "labelScrollbarLightMode";
            this.labelScrollbarLightMode.Size = new System.Drawing.Size(136, 15);
            this.labelScrollbarLightMode.TabIndex = 3;
            this.labelScrollbarLightMode.Text = "labelScrollbarLightMode";
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
            this.tableLayoutPanelSelectedItemBorder.Location = new System.Drawing.Point(3, 221);
            this.tableLayoutPanelSelectedItemBorder.Name = "tableLayoutPanelSelectedItemBorder";
            this.tableLayoutPanelSelectedItemBorder.RowCount = 1;
            this.tableLayoutPanelSelectedItemBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItemBorder.Size = new System.Drawing.Size(233, 23);
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
            this.pictureBoxSelectedItemBorder.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSelectedItemBorder.TabIndex = 1;
            this.pictureBoxSelectedItemBorder.TabStop = false;
            this.pictureBoxSelectedItemBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSelectedItemBorder
            // 
            this.textBoxColorSelectedItemBorder.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSelectedItemBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItemBorder.MaxLength = 12;
            this.textBoxColorSelectedItemBorder.Name = "textBoxColorSelectedItemBorder";
            this.textBoxColorSelectedItemBorder.Size = new System.Drawing.Size(69, 23);
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
            this.labelSelectedItemBorder.Location = new System.Drawing.Point(95, 4);
            this.labelSelectedItemBorder.Name = "labelSelectedItemBorder";
            this.labelSelectedItemBorder.Size = new System.Drawing.Size(135, 15);
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
            this.tableLayoutPanelSelectedItem.Location = new System.Drawing.Point(3, 192);
            this.tableLayoutPanelSelectedItem.Name = "tableLayoutPanelSelectedItem";
            this.tableLayoutPanelSelectedItem.RowCount = 1;
            this.tableLayoutPanelSelectedItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSelectedItem.Size = new System.Drawing.Size(198, 23);
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
            this.pictureBoxSelectedItem.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSelectedItem.TabIndex = 1;
            this.pictureBoxSelectedItem.TabStop = false;
            this.pictureBoxSelectedItem.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSelectedItem
            // 
            this.textBoxColorSelectedItem.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSelectedItem.MaxLength = 12;
            this.textBoxColorSelectedItem.Name = "textBoxColorSelectedItem";
            this.textBoxColorSelectedItem.Size = new System.Drawing.Size(69, 23);
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
            this.labelSelectedItem.Location = new System.Drawing.Point(95, 4);
            this.labelSelectedItem.Name = "labelSelectedItem";
            this.labelSelectedItem.Size = new System.Drawing.Size(100, 15);
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
            this.tableLayoutPanelOpenFolderBorder.Location = new System.Drawing.Point(3, 163);
            this.tableLayoutPanelOpenFolderBorder.Name = "tableLayoutPanelOpenFolderBorder";
            this.tableLayoutPanelOpenFolderBorder.RowCount = 1;
            this.tableLayoutPanelOpenFolderBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolderBorder.Size = new System.Drawing.Size(227, 23);
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
            this.pictureBoxOpenFolderBorder.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxOpenFolderBorder.TabIndex = 1;
            this.pictureBoxOpenFolderBorder.TabStop = false;
            this.pictureBoxOpenFolderBorder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorOpenFolderBorder
            // 
            this.textBoxColorOpenFolderBorder.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorOpenFolderBorder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolderBorder.Name = "textBoxColorOpenFolderBorder";
            this.textBoxColorOpenFolderBorder.Size = new System.Drawing.Size(69, 23);
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
            this.labelOpenFolderBorder.Location = new System.Drawing.Point(95, 4);
            this.labelOpenFolderBorder.Name = "labelOpenFolderBorder";
            this.labelOpenFolderBorder.Size = new System.Drawing.Size(129, 15);
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
            this.tableLayoutPanelOpenFolder.Location = new System.Drawing.Point(3, 134);
            this.tableLayoutPanelOpenFolder.Name = "tableLayoutPanelOpenFolder";
            this.tableLayoutPanelOpenFolder.RowCount = 1;
            this.tableLayoutPanelOpenFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOpenFolder.Size = new System.Drawing.Size(192, 23);
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
            this.pictureBoxOpenFolder.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxOpenFolder.TabIndex = 1;
            this.pictureBoxOpenFolder.TabStop = false;
            this.pictureBoxOpenFolder.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorOpenFolder
            // 
            this.textBoxColorOpenFolder.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorOpenFolder.MaxLength = 12;
            this.textBoxColorOpenFolder.Name = "textBoxColorOpenFolder";
            this.textBoxColorOpenFolder.Size = new System.Drawing.Size(69, 23);
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
            this.labelOpenFolder.Location = new System.Drawing.Point(95, 4);
            this.labelOpenFolder.Name = "labelOpenFolder";
            this.labelOpenFolder.Size = new System.Drawing.Size(94, 15);
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
            this.tableLayoutPanelSearchField.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanelSearchField.Name = "tableLayoutPanelSearchField";
            this.tableLayoutPanelSearchField.RowCount = 1;
            this.tableLayoutPanelSearchField.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearchField.Size = new System.Drawing.Size(190, 23);
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
            this.pictureBoxSearchField.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSearchField.TabIndex = 1;
            this.pictureBoxSearchField.TabStop = false;
            this.pictureBoxSearchField.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorSearchField
            // 
            this.textBoxColorSearchField.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorSearchField.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorSearchField.MaxLength = 12;
            this.textBoxColorSearchField.Name = "textBoxColorSearchField";
            this.textBoxColorSearchField.Size = new System.Drawing.Size(69, 23);
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
            this.labelSearchField.Location = new System.Drawing.Point(95, 4);
            this.labelSearchField.Name = "labelSearchField";
            this.labelSearchField.Size = new System.Drawing.Size(92, 15);
            this.labelSearchField.TabIndex = 0;
            this.labelSearchField.Text = "labelSearchField";
            // 
            // groupBoxAppearance
            // 
            this.groupBoxAppearance.AutoSize = true;
            this.groupBoxAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAppearance.Controls.Add(this.tableLayoutPanelAppearance);
            this.groupBoxAppearance.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAppearance.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxAppearance.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxAppearance.Name = "groupBoxAppearance";
            this.groupBoxAppearance.Size = new System.Drawing.Size(385, 278);
            this.groupBoxAppearance.TabIndex = 1;
            this.groupBoxAppearance.TabStop = false;
            this.groupBoxAppearance.Text = "groupBoxAppearance";
            // 
            // tableLayoutPanelAppearance
            // 
            this.tableLayoutPanelAppearance.AutoSize = true;
            this.tableLayoutPanelAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAppearance.ColumnCount = 1;
            this.tableLayoutPanelAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxShowLinkOverlay, 0, 4);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxShowCountOfElementsBelow, 0, 8);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxUseFading, 0, 3);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxUseIconFromRootFolder, 0, 0);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxShowFunctionKeysBelow, 0, 7);
            this.tableLayoutPanelAppearance.Controls.Add(this.buttonAppearanceDefault, 0, 9);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxShowSearchBar, 0, 6);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxShowDirectoryTitleAtTop, 0, 5);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxRoundCorners, 0, 1);
            this.tableLayoutPanelAppearance.Controls.Add(this.checkBoxDarkModeAlwaysOn, 0, 2);
            this.tableLayoutPanelAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAppearance.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelAppearance.Name = "tableLayoutPanelAppearance";
            this.tableLayoutPanelAppearance.RowCount = 10;
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAppearance.Size = new System.Drawing.Size(379, 256);
            this.tableLayoutPanelAppearance.TabIndex = 1;
            // 
            // checkBoxShowLinkOverlay
            // 
            this.checkBoxShowLinkOverlay.AutoSize = true;
            this.checkBoxShowLinkOverlay.Location = new System.Drawing.Point(3, 103);
            this.checkBoxShowLinkOverlay.Name = "checkBoxShowLinkOverlay";
            this.checkBoxShowLinkOverlay.Size = new System.Drawing.Size(168, 19);
            this.checkBoxShowLinkOverlay.TabIndex = 5;
            this.checkBoxShowLinkOverlay.Text = "checkBoxShowLinkOverlay";
            this.checkBoxShowLinkOverlay.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCountOfElementsBelow
            // 
            this.checkBoxShowCountOfElementsBelow.AutoSize = true;
            this.checkBoxShowCountOfElementsBelow.Location = new System.Drawing.Point(3, 203);
            this.checkBoxShowCountOfElementsBelow.Name = "checkBoxShowCountOfElementsBelow";
            this.checkBoxShowCountOfElementsBelow.Size = new System.Drawing.Size(232, 19);
            this.checkBoxShowCountOfElementsBelow.TabIndex = 4;
            this.checkBoxShowCountOfElementsBelow.Text = "checkBoxShowCountOfElementsBelow";
            this.checkBoxShowCountOfElementsBelow.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseFading
            // 
            this.checkBoxUseFading.AutoSize = true;
            this.checkBoxUseFading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUseFading.Location = new System.Drawing.Point(3, 78);
            this.checkBoxUseFading.Name = "checkBoxUseFading";
            this.checkBoxUseFading.Size = new System.Drawing.Size(373, 19);
            this.checkBoxUseFading.TabIndex = 5;
            this.checkBoxUseFading.Text = "checkBoxUseFading";
            this.checkBoxUseFading.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseIconFromRootFolder
            // 
            this.checkBoxUseIconFromRootFolder.AutoSize = true;
            this.checkBoxUseIconFromRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUseIconFromRootFolder.Location = new System.Drawing.Point(3, 3);
            this.checkBoxUseIconFromRootFolder.Name = "checkBoxUseIconFromRootFolder";
            this.checkBoxUseIconFromRootFolder.Size = new System.Drawing.Size(373, 19);
            this.checkBoxUseIconFromRootFolder.TabIndex = 4;
            this.checkBoxUseIconFromRootFolder.Text = "checkBoxUseIconFromRootFolder";
            this.checkBoxUseIconFromRootFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFunctionKeysBelow
            // 
            this.checkBoxShowFunctionKeysBelow.AutoSize = true;
            this.checkBoxShowFunctionKeysBelow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowFunctionKeysBelow.Location = new System.Drawing.Point(3, 178);
            this.checkBoxShowFunctionKeysBelow.Name = "checkBoxShowFunctionKeysBelow";
            this.checkBoxShowFunctionKeysBelow.Size = new System.Drawing.Size(373, 19);
            this.checkBoxShowFunctionKeysBelow.TabIndex = 3;
            this.checkBoxShowFunctionKeysBelow.Text = "checkBoxShowFunctionKeysBelow";
            this.checkBoxShowFunctionKeysBelow.UseVisualStyleBackColor = true;
            // 
            // buttonAppearanceDefault
            // 
            this.buttonAppearanceDefault.AutoSize = true;
            this.buttonAppearanceDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAppearanceDefault.Location = new System.Drawing.Point(3, 228);
            this.buttonAppearanceDefault.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonAppearanceDefault.Name = "buttonAppearanceDefault";
            this.buttonAppearanceDefault.Size = new System.Drawing.Size(154, 25);
            this.buttonAppearanceDefault.TabIndex = 3;
            this.buttonAppearanceDefault.Text = "buttonAppearanceDefault";
            this.buttonAppearanceDefault.UseVisualStyleBackColor = true;
            this.buttonAppearanceDefault.Click += new System.EventHandler(this.ButtonAppearanceDefault_Click);
            // 
            // checkBoxShowSearchBar
            // 
            this.checkBoxShowSearchBar.AutoSize = true;
            this.checkBoxShowSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowSearchBar.Location = new System.Drawing.Point(3, 153);
            this.checkBoxShowSearchBar.Name = "checkBoxShowSearchBar";
            this.checkBoxShowSearchBar.Size = new System.Drawing.Size(373, 19);
            this.checkBoxShowSearchBar.TabIndex = 2;
            this.checkBoxShowSearchBar.Text = "checkBoxShowSearchBar";
            this.checkBoxShowSearchBar.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDirectoryTitleAtTop
            // 
            this.checkBoxShowDirectoryTitleAtTop.AutoSize = true;
            this.checkBoxShowDirectoryTitleAtTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowDirectoryTitleAtTop.Location = new System.Drawing.Point(3, 128);
            this.checkBoxShowDirectoryTitleAtTop.Name = "checkBoxShowDirectoryTitleAtTop";
            this.checkBoxShowDirectoryTitleAtTop.Size = new System.Drawing.Size(373, 19);
            this.checkBoxShowDirectoryTitleAtTop.TabIndex = 1;
            this.checkBoxShowDirectoryTitleAtTop.Text = "checkBoxShowDirectoryTitleAtTop";
            this.checkBoxShowDirectoryTitleAtTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoundCorners
            // 
            this.checkBoxRoundCorners.AutoSize = true;
            this.checkBoxRoundCorners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRoundCorners.Location = new System.Drawing.Point(3, 28);
            this.checkBoxRoundCorners.Name = "checkBoxRoundCorners";
            this.checkBoxRoundCorners.Size = new System.Drawing.Size(373, 19);
            this.checkBoxRoundCorners.TabIndex = 4;
            this.checkBoxRoundCorners.Text = "checkBoxRoundCorners";
            this.checkBoxRoundCorners.UseVisualStyleBackColor = true;
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            this.checkBoxDarkModeAlwaysOn.AutoSize = true;
            this.checkBoxDarkModeAlwaysOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(3, 53);
            this.checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(373, 19);
            this.checkBoxDarkModeAlwaysOn.TabIndex = 0;
            this.checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            this.checkBoxDarkModeAlwaysOn.CheckedChanged += new System.EventHandler(this.CheckBoxDarkModeAlwaysOnCheckedChanged);
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
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 532);
            this.tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(426, 25);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(265, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonOk.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 25);
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
            this.buttonCancel.Location = new System.Drawing.Point(346, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Abort";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(995, 554);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
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
            this.tableLayoutPanelRelativeFolderOpenAssembly.ResumeLayout(false);
            this.tableLayoutPanelRelativeFolderOpenAssembly.PerformLayout();
            this.groupBoxConfigAndLogfile.ResumeLayout(false);
            this.groupBoxConfigAndLogfile.PerformLayout();
            this.tableLayoutPanelConfigAndLogfile.ResumeLayout(false);
            this.tableLayoutPanelConfigAndLogfile.PerformLayout();
            this.groupBoxAutostart.ResumeLayout(false);
            this.groupBoxAutostart.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanelAutostart.ResumeLayout(false);
            this.tableLayoutPanelAutostart.PerformLayout();
            this.groupBoxHotkey.ResumeLayout(false);
            this.groupBoxHotkey.PerformLayout();
            this.tableLayoutPanelHotkey.ResumeLayout(false);
            this.tableLayoutPanelHotkey.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxLanguage.PerformLayout();
            this.tableLayoutPanelLanguage.ResumeLayout(false);
            this.tabPageSizeAndLocation.ResumeLayout(false);
            this.tabPageSizeAndLocation.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxSubMenuAppearAt.ResumeLayout(false);
            this.groupBoxSubMenuAppearAt.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlappingOffsetPixels)).EndInit();
            this.groupBoxMenuAppearAt.ResumeLayout(false);
            this.groupBoxMenuAppearAt.PerformLayout();
            this.tableLayoutPanelMenuAppearAt.ResumeLayout(false);
            this.tableLayoutPanelMenuAppearAt.PerformLayout();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            this.tableLayoutPanelSize.ResumeLayout(false);
            this.tableLayoutPanelSize.PerformLayout();
            this.tableLayoutPanelIconSizeInPercent.ResumeLayout(false);
            this.tableLayoutPanelIconSizeInPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIconSizeInPercent)).EndInit();
            this.tableLayoutPanelRowHeighteInPercentage.ResumeLayout(false);
            this.tableLayoutPanelRowHeighteInPercentage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRowHeighteInPercentage)).EndInit();
            this.tableLayoutPanelSizeInPercent.ResumeLayout(false);
            this.tableLayoutPanelSizeInPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeInPercent)).EndInit();
            this.tableLayoutPanelMenuHeight.ResumeLayout(false);
            this.tableLayoutPanelMenuHeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuHeight)).EndInit();
            this.tableLayoutPanelMaxMenuWidth.ResumeLayout(false);
            this.tableLayoutPanelMaxMenuWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).EndInit();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.tableLayoutPanelAdvanced.ResumeLayout(false);
            this.tableLayoutPanelAdvanced.PerformLayout();
            this.groupBoxInternetShortcutIcons.ResumeLayout(false);
            this.groupBoxInternetShortcutIcons.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupBoxDrag.ResumeLayout(false);
            this.groupBoxDrag.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxClick.ResumeLayout(false);
            this.groupBoxClick.PerformLayout();
            this.tableLayoutPanelClick.ResumeLayout(false);
            this.tableLayoutPanelClick.PerformLayout();
            this.groupBoxSorting.ResumeLayout(false);
            this.groupBoxSorting.PerformLayout();
            this.tableLayoutPanelSorting.ResumeLayout(false);
            this.tableLayoutPanelSorting.PerformLayout();
            this.groupBoxHiddenFilesAndFolders.ResumeLayout(false);
            this.groupBoxHiddenFilesAndFolders.PerformLayout();
            this.tableLayoutPanelHiddenFilesAndFolders.ResumeLayout(false);
            this.tableLayoutPanelHiddenFilesAndFolders.PerformLayout();
            this.tabPageFolders.ResumeLayout(false);
            this.tabPageFolders.PerformLayout();
            this.tableLayoutPanelFoldersInRootFolder.ResumeLayout(false);
            this.tableLayoutPanelFoldersInRootFolder.PerformLayout();
            this.groupBoxFoldersInRootFolder.ResumeLayout(false);
            this.groupBoxFoldersInRootFolder.PerformLayout();
            this.tableLayoutPanelFolderToRootFoldersList.ResumeLayout(false);
            this.tableLayoutPanelFolderToRootFoldersList.PerformLayout();
            this.tableLayoutPanelFolderToRootFolder.ResumeLayout(false);
            this.tableLayoutPanelFolderToRootFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolders)).EndInit();
            this.tableLayoutPanelAddSampleStartMenuFolder.ResumeLayout(false);
            this.tableLayoutPanelAddSampleStartMenuFolder.PerformLayout();
            this.tabPageExpert.ResumeLayout(false);
            this.tabPageExpert.PerformLayout();
            this.tableLayoutPanelExpert.ResumeLayout(false);
            this.tableLayoutPanelExpert.PerformLayout();
            this.groupBoxSearchPattern.ResumeLayout(false);
            this.groupBoxSearchPattern.PerformLayout();
            this.tableLayoutPanelSearchPattern.ResumeLayout(false);
            this.tableLayoutPanelSearchPattern.PerformLayout();
            this.groupBoxCache.ResumeLayout(false);
            this.groupBoxCache.PerformLayout();
            this.tableLayoutPanelCache.ResumeLayout(false);
            this.tableLayoutPanelCache.PerformLayout();
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ResumeLayout(false);
            this.tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClearCacheIfMoreThanThisNumberOfItems)).EndInit();
            this.groupBoxStaysOpen.ResumeLayout(false);
            this.groupBoxStaysOpen.PerformLayout();
            this.tableLayoutPanelStaysOpen.ResumeLayout(false);
            this.tableLayoutPanelStaysOpen.PerformLayout();
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.ResumeLayout(false);
            this.tableLayoutPanelTimeUntilClosesAfterEnterPressed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClosesAfterEnterPressed)).EndInit();
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
            this.groupBoxColorsDarkMode.ResumeLayout(false);
            this.groupBoxColorsDarkMode.PerformLayout();
            this.tableLayoutPanelDarkMode.ResumeLayout(false);
            this.tableLayoutPanelDarkMode.PerformLayout();
            this.tableLayoutPanelColorIconsDarkMode.ResumeLayout(false);
            this.tableLayoutPanelColorIconsDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconsDarkMode)).EndInit();
            this.tableLayoutPanelColorBackgroundBorderDarkMode.ResumeLayout(false);
            this.tableLayoutPanelColorBackgroundBorderDarkMode.PerformLayout();
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
            this.tableLayoutPanelBackgroundDarkMode.ResumeLayout(false);
            this.tableLayoutPanelBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).EndInit();
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
            this.groupBoxAppearance.ResumeLayout(false);
            this.groupBoxAppearance.PerformLayout();
            this.tableLayoutPanelAppearance.ResumeLayout(false);
            this.tableLayoutPanelAppearance.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxSize;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMaxMenuWidth;
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
        private System.Windows.Forms.TextBox textBoxColorBackground;
        private System.Windows.Forms.TextBox textBoxColorSelectedItem;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderBorder;
        private System.Windows.Forms.TextBox textBoxColorBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSelecetedItemDarkMode;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSelectedItemBorder;
        private System.Windows.Forms.TextBox textBoxColorSelectedItemBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSearchFieldDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSearchField;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Label labelSearchField;
        private System.Windows.Forms.Label labelOpenFolder;
        private System.Windows.Forms.Label labelOpenFolderBorder;
        private System.Windows.Forms.Label labelSelectedItem;
        private System.Windows.Forms.Label labelSelectedItemBorder;
        private System.Windows.Forms.CheckBox checkBoxSaveConfigInApplicationDirectory;
        private System.Windows.Forms.GroupBox groupBoxConfigAndLogfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfigAndLogfile;
        private System.Windows.Forms.Button buttonChangeRelativeFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRelativeFolderOpenAssembly;
        private System.Windows.Forms.Button buttonOpenAssemblyLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMenuHeight;
        private System.Windows.Forms.Label labelMaxMenuHeight;
        private System.Windows.Forms.Button buttonColorsDefault;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScrollbarBackground;
        private System.Windows.Forms.PictureBox pictureBoxScrollbarBackground;
        private System.Windows.Forms.TextBox textBoxColorScrollbarBackground;
        private System.Windows.Forms.Label labelScrollbarBackground;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSizeInPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeInPercent;
        private System.Windows.Forms.Label labelSizeInPercent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackgroundBorder;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundBorder;
        private System.Windows.Forms.TextBox textBoxColorBackgroundBorder;
        private System.Windows.Forms.Label labelBackgroundBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColorBackgroundBorderDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundBorderDarkMode;
        private System.Windows.Forms.Label labelBackgroundBorderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorBackgroundBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIcons;
        private System.Windows.Forms.PictureBox pictureBoxIcons;
        private System.Windows.Forms.TextBox textBoxColorIcons;
        private System.Windows.Forms.Label labelIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColorIconsDarkMode;
        private System.Windows.Forms.PictureBox pictureBoxIconsDarkMode;
        private System.Windows.Forms.Label labelIconsDarkMode;
        private System.Windows.Forms.TextBox textBoxColorIconsDarkMode;
        private System.Windows.Forms.CheckBox checkBoxSetFolderByWindowsContextMenu;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonAddStartup;
        private System.Windows.Forms.Label labelStartupStatus;
        private System.Windows.Forms.TabPage tabPageExpert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExpert;
        private System.Windows.Forms.Button buttonExpertDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeUntilClosesAfterEnterPressed;
        private System.Windows.Forms.Label labelTimeUntilClosesAfterEnterPressed;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeUntilClosesAfterEnterPressed;
        private System.Windows.Forms.CheckBox checkBoxStayOpenWhenFocusLostAfterEnterPressed;
        private System.Windows.Forms.CheckBox checkBoxShowInTaskbar;
        private System.Windows.Forms.TabPage tabPageFolders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFoldersInRootFolder;
        private System.Windows.Forms.GroupBox groupBoxFoldersInRootFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFolderToRootFoldersList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFolderToRootFolder;
        private System.Windows.Forms.Button buttonAddFolderToRootFolder;
        private System.Windows.Forms.Button buttonRemoveFolder;
        private System.Windows.Forms.DataGridView dataGridViewFolders;
        private System.Windows.Forms.Button buttonDefaultFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRecursiveLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOnlyFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems;
        private System.Windows.Forms.NumericUpDown numericUpDownClearCacheIfMoreThanThisNumberOfItems;
        private System.Windows.Forms.Label labelClearCacheIfMoreThanThisNumberOfItems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAddSampleStartMenuFolder;
        private System.Windows.Forms.Button buttonAddSampleStartMenuFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRowHeighteInPercentage;
        private System.Windows.Forms.NumericUpDown numericUpDownRowHeighteInPercentage;
        private System.Windows.Forms.Label labelRowHeightInPercentage;
        private System.Windows.Forms.CheckBox checkBoxRoundCorners;
        private System.Windows.Forms.GroupBox groupBoxAppearance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAppearance;
        private System.Windows.Forms.GroupBox groupBoxMenuAppearAt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuAppearAt;
        private System.Windows.Forms.RadioButton radioButtonAppearAtTheBottomLeft;
        private System.Windows.Forms.RadioButton radioButtonAppearAtTheBottomRight;
        private System.Windows.Forms.RadioButton radioButtonAppearAtMouseLocation;
        private System.Windows.Forms.RadioButton radioButtonUseCustomLocation;
        private System.Windows.Forms.CheckBox checkBoxGenerateShortcutsToDrives;
        private System.Windows.Forms.GroupBox groupBoxCache;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCache;
        private System.Windows.Forms.CheckBox checkBoxCacheMainMenu;
        private System.Windows.Forms.TabPage tabPageSizeAndLocation;
        private System.Windows.Forms.GroupBox groupBoxHiddenFilesAndFolders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHiddenFilesAndFolders;
        private System.Windows.Forms.RadioButton radioButtonAlwaysShowHiddenFiles;
        private System.Windows.Forms.RadioButton radioButtonNeverShowHiddenFiles;
        private System.Windows.Forms.RadioButton radioButtonSystemSettingsShowHiddenFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSizeAndLocationDefault;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyAsSearchResult;
        private System.Windows.Forms.CheckBox checkBoxOpenDirectoryWithOneClick;
        private System.Windows.Forms.GroupBox groupBoxSubMenuAppearAt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelOverlappingByPixelsOffset;
        private System.Windows.Forms.RadioButton radioButtonOverlapping;
        private System.Windows.Forms.RadioButton radioButtonNextToPreviousMenu;
        private System.Windows.Forms.NumericUpDown numericUpDownOverlappingOffsetPixels;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIconSizeInPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownIconSizeInPercent;
        private System.Windows.Forms.Label labelIconSizeInPercent;
        private System.Windows.Forms.CheckBox checkBoxUseFading;
        private System.Windows.Forms.Button buttonAppearanceDefault;
        private System.Windows.Forms.CheckBox checkBoxSendHotkeyInsteadKillOtherInstances;
        private System.Windows.Forms.GroupBox groupBoxSorting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSorting;
        private System.Windows.Forms.RadioButton radioButtonSortByDate;
        private System.Windows.Forms.RadioButton radioButtonSortByName;
        private System.Windows.Forms.GroupBox groupBoxDrag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxSwipeScrolling;
        private System.Windows.Forms.CheckBox checkBoxDragDropItems;
        private System.Windows.Forms.GroupBox groupBoxSearchPattern;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchPattern;
        private System.Windows.Forms.TextBox textBoxSearchPattern;
        private System.Windows.Forms.CheckBox checkBoxShowFunctionKeysBelow;
        private System.Windows.Forms.CheckBox checkBoxShowSearchBar;
        private System.Windows.Forms.CheckBox checkBoxShowDirectoryTitleAtTop;
        private System.Windows.Forms.CheckBox checkBoxShowCountOfElementsBelow;
        private System.Windows.Forms.CheckBox checkBoxSaveLogFileInApplicationDirectory;
        private System.Windows.Forms.CheckBox checkBoxShowLinkOverlay;
        private System.Windows.Forms.GroupBox groupBoxInternetShortcutIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button buttonChangeIcoFolder;
        private System.Windows.Forms.TextBox textBoxIcoFolder;
        private System.Windows.Forms.RadioButton radioButtonSortByTypeAndDate;
        private System.Windows.Forms.RadioButton radioButtonSortByTypeAndName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox checkBoxCheckForUpdates;
        private System.Windows.Forms.Button buttonGeneralDefault;
    }
}