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
            tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPageGeneral = new System.Windows.Forms.TabPage();
            tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            buttonGeneralDefault = new System.Windows.Forms.Button();
            groupBoxFolder = new System.Windows.Forms.GroupBox();
            tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            buttonChangeFolder = new System.Windows.Forms.Button();
            buttonOpenFolder = new System.Windows.Forms.Button();
            checkBoxSetFolderByWindowsContextMenu = new System.Windows.Forms.CheckBox();
            textBoxFolder = new System.Windows.Forms.TextBox();
            tableLayoutPanelRelativeFolderOpenAssembly = new System.Windows.Forms.TableLayoutPanel();
            buttonChangeRelativeFolder = new System.Windows.Forms.Button();
            buttonOpenAssemblyLocation = new System.Windows.Forms.Button();
            groupBoxConfigAndLogfile = new System.Windows.Forms.GroupBox();
            tableLayoutPanelConfigAndLogfile = new System.Windows.Forms.TableLayoutPanel();
            checkBoxSaveLogFileInApplicationDirectory = new System.Windows.Forms.CheckBox();
            checkBoxSaveConfigInApplicationDirectory = new System.Windows.Forms.CheckBox();
            groupBoxAutostart = new System.Windows.Forms.GroupBox();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            checkBoxCheckForUpdates = new System.Windows.Forms.CheckBox();
            tableLayoutPanelAutostart = new System.Windows.Forms.TableLayoutPanel();
            buttonAddStartup = new System.Windows.Forms.Button();
            labelStartupStatus = new System.Windows.Forms.Label();
            checkBoxAutostart = new System.Windows.Forms.CheckBox();
            groupBoxHotkey = new System.Windows.Forms.GroupBox();
            tableLayoutPanelHotkey = new System.Windows.Forms.TableLayoutPanel();
            textBoxHotkeyPlaceholder = new System.Windows.Forms.TextBox();
            buttonHotkeyDefault = new System.Windows.Forms.Button();
            groupBoxLanguage = new System.Windows.Forms.GroupBox();
            tableLayoutPanelLanguage = new System.Windows.Forms.TableLayoutPanel();
            comboBoxLanguage = new System.Windows.Forms.ComboBox();
            tabPageSizeAndLocation = new System.Windows.Forms.TabPage();
            tableLayoutPanelSizeAndLocation = new System.Windows.Forms.TableLayoutPanel();
            groupBoxSubMenuAppearAt = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownOverlappingOffsetPixels = new System.Windows.Forms.NumericUpDown();
            labelOverlappingByPixelsOffset = new System.Windows.Forms.Label();
            radioButtonOverlapping = new System.Windows.Forms.RadioButton();
            radioButtonNextToPreviousMenu = new System.Windows.Forms.RadioButton();
            buttonSizeAndLocationDefault = new System.Windows.Forms.Button();
            groupBoxMenuAppearAt = new System.Windows.Forms.GroupBox();
            tableLayoutPanelMenuAppearAt = new System.Windows.Forms.TableLayoutPanel();
            radioButtonUseCustomLocation = new System.Windows.Forms.RadioButton();
            radioButtonAppearAtTheBottomLeft = new System.Windows.Forms.RadioButton();
            radioButtonAppearAtTheBottomRight = new System.Windows.Forms.RadioButton();
            radioButtonAppearAtMouseLocation = new System.Windows.Forms.RadioButton();
            groupBoxSize = new System.Windows.Forms.GroupBox();
            tableLayoutPanelSize = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelIconSizeInPercent = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownIconSizeInPercent = new System.Windows.Forms.NumericUpDown();
            labelIconSizeInPercent = new System.Windows.Forms.Label();
            tableLayoutPanelRowHeighteInPercentage = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownRowHeighteInPercentage = new System.Windows.Forms.NumericUpDown();
            labelRowHeightInPercentage = new System.Windows.Forms.Label();
            tableLayoutPanelSizeInPercent = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownSizeInPercent = new System.Windows.Forms.NumericUpDown();
            labelSizeInPercent = new System.Windows.Forms.Label();
            tableLayoutPanelMenuHeight = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownMenuHeight = new System.Windows.Forms.NumericUpDown();
            labelMaxMenuHeight = new System.Windows.Forms.Label();
            tableLayoutPanelMaxMenuWidth = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownMenuWidth = new System.Windows.Forms.NumericUpDown();
            labelMaxMenuWidth = new System.Windows.Forms.Label();
            tabPageAdvanced = new System.Windows.Forms.TabPage();
            tableLayoutPanelAdvanced = new System.Windows.Forms.TableLayoutPanel();
            groupBoxOptionalFeatures = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            checkBoxShowInTaskbar = new System.Windows.Forms.CheckBox();
            checkBoxSendHotkeyInsteadKillOtherInstances = new System.Windows.Forms.CheckBox();
            checkBoxSupportGamepad = new System.Windows.Forms.CheckBox();
            checkBoxResolveLinksToFolders = new System.Windows.Forms.CheckBox();
            groupBoxInternetShortcutIcons = new System.Windows.Forms.GroupBox();
            tableLayoutPanelInternetShortcutIcons = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelChangeIcoFolder = new System.Windows.Forms.TableLayoutPanel();
            buttonChangeIcoFolder = new System.Windows.Forms.Button();
            textBoxIcoFolder = new System.Windows.Forms.TextBox();
            groupBoxDrag = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            checkBoxSwipeScrolling = new System.Windows.Forms.CheckBox();
            checkBoxDragDropItems = new System.Windows.Forms.CheckBox();
            buttonAdvancedDefault = new System.Windows.Forms.Button();
            groupBoxSorting = new System.Windows.Forms.GroupBox();
            tableLayoutPanelSorting = new System.Windows.Forms.TableLayoutPanel();
            radioButtonSortByFileExtensionAndName = new System.Windows.Forms.RadioButton();
            radioButtonSortByTypeAndDate = new System.Windows.Forms.RadioButton();
            radioButtonSortByTypeAndName = new System.Windows.Forms.RadioButton();
            radioButtonSortByDate = new System.Windows.Forms.RadioButton();
            radioButtonSortByName = new System.Windows.Forms.RadioButton();
            groupBoxHiddenFilesAndFolders = new System.Windows.Forms.GroupBox();
            tableLayoutPanelHiddenFilesAndFolders = new System.Windows.Forms.TableLayoutPanel();
            radioButtonAlwaysShowHiddenFiles = new System.Windows.Forms.RadioButton();
            radioButtonNeverShowHiddenFiles = new System.Windows.Forms.RadioButton();
            radioButtonSystemSettingsShowHiddenFiles = new System.Windows.Forms.RadioButton();
            groupBoxClick = new System.Windows.Forms.GroupBox();
            tableLayoutPanelClick = new System.Windows.Forms.TableLayoutPanel();
            checkBoxOpenDirectoryWithOneClick = new System.Windows.Forms.CheckBox();
            checkBoxOpenItemWithOneClick = new System.Windows.Forms.CheckBox();
            tabPageFolders = new System.Windows.Forms.TabPage();
            tableLayoutPanelFoldersInRootFolder = new System.Windows.Forms.TableLayoutPanel();
            groupBoxFoldersInRootFolder = new System.Windows.Forms.GroupBox();
            tableLayoutPanelFolderToRootFoldersList = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelFolderToRootFolder = new System.Windows.Forms.TableLayoutPanel();
            buttonAddFolderToRootFolder = new System.Windows.Forms.Button();
            buttonRemoveFolder = new System.Windows.Forms.Button();
            dataGridViewFolders = new System.Windows.Forms.DataGridView();
            ColumnFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnRecursiveLevel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ColumnOnlyFiles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            tableLayoutPanelAddSampleStartMenuFolder = new System.Windows.Forms.TableLayoutPanel();
            buttonAddSampleStartMenuFolder = new System.Windows.Forms.Button();
            checkBoxGenerateShortcutsToDrives = new System.Windows.Forms.CheckBox();
            checkBoxShowOnlyAsSearchResult = new System.Windows.Forms.CheckBox();
            buttonDefaultFolders = new System.Windows.Forms.Button();
            tabPageExpert = new System.Windows.Forms.TabPage();
            tableLayoutPanelExpert = new System.Windows.Forms.TableLayoutPanel();
            groupBoxSearchPattern = new System.Windows.Forms.GroupBox();
            tableLayoutPanelSearchPattern = new System.Windows.Forms.TableLayoutPanel();
            textBoxSearchPattern = new System.Windows.Forms.TextBox();
            groupBoxCache = new System.Windows.Forms.GroupBox();
            tableLayoutPanelCache = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.TableLayoutPanel();
            labelClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.Label();
            numericUpDownClearCacheIfMoreThanThisNumberOfItems = new System.Windows.Forms.NumericUpDown();
            groupBoxStaysOpen = new System.Windows.Forms.GroupBox();
            tableLayoutPanelStaysOpen = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.TableLayoutPanel();
            labelTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.Label();
            numericUpDownTimeUntilClosesAfterEnterPressed = new System.Windows.Forms.NumericUpDown();
            checkBoxStayOpenWhenItemClicked = new System.Windows.Forms.CheckBox();
            checkBoxStayOpenWhenFocusLost = new System.Windows.Forms.CheckBox();
            tableLayoutPanelTimeUntilCloses = new System.Windows.Forms.TableLayoutPanel();
            labelTimeUntilCloses = new System.Windows.Forms.Label();
            numericUpDownTimeUntilClose = new System.Windows.Forms.NumericUpDown();
            checkBoxStayOpenWhenFocusLostAfterEnterPressed = new System.Windows.Forms.CheckBox();
            groupBoxOpenSubmenus = new System.Windows.Forms.GroupBox();
            tableLayoutPanelTimeUntilOpen = new System.Windows.Forms.TableLayoutPanel();
            numericUpDownTimeUntilOpens = new System.Windows.Forms.NumericUpDown();
            labelTimeUntilOpen = new System.Windows.Forms.Label();
            buttonExpertDefault = new System.Windows.Forms.Button();
            tabPageCustomize = new System.Windows.Forms.TabPage();
            tableLayoutPanelCustomize = new System.Windows.Forms.TableLayoutPanel();
            groupBoxColorsDarkMode = new System.Windows.Forms.GroupBox();
            tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelColorIconsDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxIconsDarkMode = new System.Windows.Forms.PictureBox();
            labelIconsDarkMode = new System.Windows.Forms.Label();
            textBoxColorIconsDarkMode = new System.Windows.Forms.TextBox();
            tableLayoutPanelColorBackgroundBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxBackgroundBorderDarkMode = new System.Windows.Forms.PictureBox();
            labelBackgroundBorderDarkMode = new System.Windows.Forms.Label();
            textBoxColorBackgroundBorderDarkMode = new System.Windows.Forms.TextBox();
            labelMenuDarkMode = new System.Windows.Forms.Label();
            tableLayoutPanelSearchFieldDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSearchFieldDarkMode = new System.Windows.Forms.PictureBox();
            labelSearchFieldDarkMode = new System.Windows.Forms.Label();
            textBoxColorSearchFieldDarkMode = new System.Windows.Forms.TextBox();
            tableLayoutPanelOpenFolderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxOpenFolderDarkMode = new System.Windows.Forms.PictureBox();
            labelOpenFolderDarkMode = new System.Windows.Forms.Label();
            textBoxColorOpenFolderDarkMode = new System.Windows.Forms.TextBox();
            tableLayoutPanelOpenFolderBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxOpenFolderBorderDarkMode = new System.Windows.Forms.PictureBox();
            labelOpenFolderBorderDarkMode = new System.Windows.Forms.Label();
            textBoxColorOpenFolderBorderDarkMode = new System.Windows.Forms.TextBox();
            tableLayoutPanelSelectedItemDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureColorBoxSelectedItemDarkMode = new System.Windows.Forms.PictureBox();
            labelSelectedItemDarkMode = new System.Windows.Forms.Label();
            textBoxColorSelecetedItemDarkMode = new System.Windows.Forms.TextBox();
            tableLayoutPanelSelectedItemBorderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSelectedItemBorderDarkMode = new System.Windows.Forms.PictureBox();
            labelSelectedItemBorderDarkMode = new System.Windows.Forms.Label();
            textBoxColorSelectedItemBorderDarkMode = new System.Windows.Forms.TextBox();
            labelScrollbarDarkMode = new System.Windows.Forms.Label();
            tableLayoutPanelScrollbarBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxScrollbarBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorScrollbarBackgroundDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeScrollbarBackground = new System.Windows.Forms.Label();
            tableLayoutPanelSliderDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorSliderDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeSlider = new System.Windows.Forms.Label();
            tableLayoutPanelSliderDraggingDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderDraggingDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorSliderDraggingDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeSliderDragging = new System.Windows.Forms.Label();
            tableLayoutPanelSliderHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderHoverDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorSliderHoverDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeSliderHover = new System.Windows.Forms.Label();
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            tableLayoutPanelArrowDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorArrowDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeArrow = new System.Windows.Forms.Label();
            tableLayoutPanelArrowClickDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowClickDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorArrowClickDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeArrowClick = new System.Windows.Forms.Label();
            tableLayoutPanelArrowClickBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowClickBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorArrowClickBackgroundDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeArrowClickBackground = new System.Windows.Forms.Label();
            tableLayoutPanelArrowHoverDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowHoverDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorArrowHoverDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeArrowHover = new System.Windows.Forms.Label();
            tableLayoutPanelArrowHoverBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowHoverBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            textBoxColorArrowHoverBackgroundDarkMode = new System.Windows.Forms.TextBox();
            labelColorDarkModeArrowHoverBackground = new System.Windows.Forms.Label();
            buttonColorsDefaultDarkMode = new System.Windows.Forms.Button();
            tableLayoutPanelBackgroundDarkMode = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            labelBackgroundDarkMode = new System.Windows.Forms.Label();
            textBoxColorBackgroundDarkMode = new System.Windows.Forms.TextBox();
            groupBoxColorsLightMode = new System.Windows.Forms.GroupBox();
            tableLayoutPanelColorsAndDefault = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelIcons = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxIcons = new System.Windows.Forms.PictureBox();
            textBoxColorIcons = new System.Windows.Forms.TextBox();
            labelIcons = new System.Windows.Forms.Label();
            tableLayoutPanelBackgroundBorder = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxBackgroundBorder = new System.Windows.Forms.PictureBox();
            textBoxColorBackgroundBorder = new System.Windows.Forms.TextBox();
            labelBackgroundBorder = new System.Windows.Forms.Label();
            labelMenuLightMode = new System.Windows.Forms.Label();
            tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxBackground = new System.Windows.Forms.PictureBox();
            textBoxColorBackground = new System.Windows.Forms.TextBox();
            labelBackground = new System.Windows.Forms.Label();
            buttonColorsDefault = new System.Windows.Forms.Button();
            tableLayoutPanelArrowHoverBackground = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowHoverBackground = new System.Windows.Forms.PictureBox();
            textBoxColorArrowHoverBackground = new System.Windows.Forms.TextBox();
            labelArrowHoverBackground = new System.Windows.Forms.Label();
            tableLayoutPanelArrowHover = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowHover = new System.Windows.Forms.PictureBox();
            textBoxColorArrowHover = new System.Windows.Forms.TextBox();
            labelArrowHover = new System.Windows.Forms.Label();
            tableLayoutPanelArrowClickBackground = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowClickBackground = new System.Windows.Forms.PictureBox();
            textBoxColorArrowClickBackground = new System.Windows.Forms.TextBox();
            labelArrowClickBackground = new System.Windows.Forms.Label();
            tableLayoutPanelArrowClick = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrowClick = new System.Windows.Forms.PictureBox();
            textBoxColorArrowClick = new System.Windows.Forms.TextBox();
            labelArrowClick = new System.Windows.Forms.Label();
            tableLayoutPanelArrow = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxArrow = new System.Windows.Forms.PictureBox();
            textBoxColorArrow = new System.Windows.Forms.TextBox();
            labelArrow = new System.Windows.Forms.Label();
            tableLayoutPanelSliderArrowsAndTrackHover = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderArrowsAndTrackHover = new System.Windows.Forms.PictureBox();
            textBoxColorSliderArrowsAndTrackHover = new System.Windows.Forms.TextBox();
            labelSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            tableLayoutPanelSliderHover = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderHover = new System.Windows.Forms.PictureBox();
            textBoxColorSliderHover = new System.Windows.Forms.TextBox();
            labelSliderHover = new System.Windows.Forms.Label();
            tableLayoutPanelSliderDragging = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSliderDragging = new System.Windows.Forms.PictureBox();
            textBoxColorSliderDragging = new System.Windows.Forms.TextBox();
            labelSliderDragging = new System.Windows.Forms.Label();
            tableLayoutPanelSlider = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSlider = new System.Windows.Forms.PictureBox();
            textBoxColorSlider = new System.Windows.Forms.TextBox();
            labelSlider = new System.Windows.Forms.Label();
            tableLayoutPanelScrollbarBackground = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxScrollbarBackground = new System.Windows.Forms.PictureBox();
            textBoxColorScrollbarBackground = new System.Windows.Forms.TextBox();
            labelScrollbarBackground = new System.Windows.Forms.Label();
            labelScrollbarLightMode = new System.Windows.Forms.Label();
            tableLayoutPanelSelectedItemBorder = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSelectedItemBorder = new System.Windows.Forms.PictureBox();
            textBoxColorSelectedItemBorder = new System.Windows.Forms.TextBox();
            labelSelectedItemBorder = new System.Windows.Forms.Label();
            tableLayoutPanelSelectedItem = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSelectedItem = new System.Windows.Forms.PictureBox();
            textBoxColorSelectedItem = new System.Windows.Forms.TextBox();
            labelSelectedItem = new System.Windows.Forms.Label();
            tableLayoutPanelOpenFolderBorder = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxOpenFolderBorder = new System.Windows.Forms.PictureBox();
            textBoxColorOpenFolderBorder = new System.Windows.Forms.TextBox();
            labelOpenFolderBorder = new System.Windows.Forms.Label();
            tableLayoutPanelOpenFolder = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxOpenFolder = new System.Windows.Forms.PictureBox();
            textBoxColorOpenFolder = new System.Windows.Forms.TextBox();
            labelOpenFolder = new System.Windows.Forms.Label();
            tableLayoutPanelSearchField = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSearchField = new System.Windows.Forms.PictureBox();
            textBoxColorSearchField = new System.Windows.Forms.TextBox();
            labelSearchField = new System.Windows.Forms.Label();
            groupBoxAppearance = new System.Windows.Forms.GroupBox();
            tableLayoutPanelAppearance = new System.Windows.Forms.TableLayoutPanel();
            checkBoxShowFunctionKeyPinMenu = new System.Windows.Forms.CheckBox();
            checkBoxShowFunctionKeySettings = new System.Windows.Forms.CheckBox();
            checkBoxShowFunctionKeyRestart = new System.Windows.Forms.CheckBox();
            checkBoxShowLinkOverlay = new System.Windows.Forms.CheckBox();
            checkBoxUseFading = new System.Windows.Forms.CheckBox();
            checkBoxUseIconFromRootFolder = new System.Windows.Forms.CheckBox();
            checkBoxShowSearchBar = new System.Windows.Forms.CheckBox();
            checkBoxShowDirectoryTitleAtTop = new System.Windows.Forms.CheckBox();
            checkBoxRoundCorners = new System.Windows.Forms.CheckBox();
            checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            buttonAppearanceDefault = new System.Windows.Forms.Button();
            checkBoxShowCountOfElementsBelow = new System.Windows.Forms.CheckBox();
            checkBoxShowFunctionKeyOpenFolder = new System.Windows.Forms.CheckBox();
            tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            buttonOk = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            colorDialog = new System.Windows.Forms.ColorDialog();
            tableLayoutPanelMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            tableLayoutPanelGeneral.SuspendLayout();
            groupBoxFolder.SuspendLayout();
            tableLayoutPanelFolder.SuspendLayout();
            tableLayoutPanelChangeFolder.SuspendLayout();
            tableLayoutPanelRelativeFolderOpenAssembly.SuspendLayout();
            groupBoxConfigAndLogfile.SuspendLayout();
            tableLayoutPanelConfigAndLogfile.SuspendLayout();
            groupBoxAutostart.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanelAutostart.SuspendLayout();
            groupBoxHotkey.SuspendLayout();
            tableLayoutPanelHotkey.SuspendLayout();
            groupBoxLanguage.SuspendLayout();
            tableLayoutPanelLanguage.SuspendLayout();
            tabPageSizeAndLocation.SuspendLayout();
            tableLayoutPanelSizeAndLocation.SuspendLayout();
            groupBoxSubMenuAppearAt.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOverlappingOffsetPixels).BeginInit();
            groupBoxMenuAppearAt.SuspendLayout();
            tableLayoutPanelMenuAppearAt.SuspendLayout();
            groupBoxSize.SuspendLayout();
            tableLayoutPanelSize.SuspendLayout();
            tableLayoutPanelIconSizeInPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIconSizeInPercent).BeginInit();
            tableLayoutPanelRowHeighteInPercentage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowHeighteInPercentage).BeginInit();
            tableLayoutPanelSizeInPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSizeInPercent).BeginInit();
            tableLayoutPanelMenuHeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenuHeight).BeginInit();
            tableLayoutPanelMaxMenuWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenuWidth).BeginInit();
            tabPageAdvanced.SuspendLayout();
            tableLayoutPanelAdvanced.SuspendLayout();
            groupBoxOptionalFeatures.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBoxInternetShortcutIcons.SuspendLayout();
            tableLayoutPanelInternetShortcutIcons.SuspendLayout();
            tableLayoutPanelChangeIcoFolder.SuspendLayout();
            groupBoxDrag.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxSorting.SuspendLayout();
            tableLayoutPanelSorting.SuspendLayout();
            groupBoxHiddenFilesAndFolders.SuspendLayout();
            tableLayoutPanelHiddenFilesAndFolders.SuspendLayout();
            groupBoxClick.SuspendLayout();
            tableLayoutPanelClick.SuspendLayout();
            tabPageFolders.SuspendLayout();
            tableLayoutPanelFoldersInRootFolder.SuspendLayout();
            groupBoxFoldersInRootFolder.SuspendLayout();
            tableLayoutPanelFolderToRootFoldersList.SuspendLayout();
            tableLayoutPanelFolderToRootFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFolders).BeginInit();
            tableLayoutPanelAddSampleStartMenuFolder.SuspendLayout();
            tabPageExpert.SuspendLayout();
            tableLayoutPanelExpert.SuspendLayout();
            groupBoxSearchPattern.SuspendLayout();
            tableLayoutPanelSearchPattern.SuspendLayout();
            groupBoxCache.SuspendLayout();
            tableLayoutPanelCache.SuspendLayout();
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownClearCacheIfMoreThanThisNumberOfItems).BeginInit();
            groupBoxStaysOpen.SuspendLayout();
            tableLayoutPanelStaysOpen.SuspendLayout();
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilClosesAfterEnterPressed).BeginInit();
            tableLayoutPanelTimeUntilCloses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilClose).BeginInit();
            groupBoxOpenSubmenus.SuspendLayout();
            tableLayoutPanelTimeUntilOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilOpens).BeginInit();
            tabPageCustomize.SuspendLayout();
            tableLayoutPanelCustomize.SuspendLayout();
            groupBoxColorsDarkMode.SuspendLayout();
            tableLayoutPanelDarkMode.SuspendLayout();
            tableLayoutPanelColorIconsDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIconsDarkMode).BeginInit();
            tableLayoutPanelColorBackgroundBorderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundBorderDarkMode).BeginInit();
            tableLayoutPanelSearchFieldDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchFieldDarkMode).BeginInit();
            tableLayoutPanelOpenFolderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderDarkMode).BeginInit();
            tableLayoutPanelOpenFolderBorderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderBorderDarkMode).BeginInit();
            tableLayoutPanelSelectedItemDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureColorBoxSelectedItemDarkMode).BeginInit();
            tableLayoutPanelSelectedItemBorderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItemBorderDarkMode).BeginInit();
            tableLayoutPanelScrollbarBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScrollbarBackgroundDarkMode).BeginInit();
            tableLayoutPanelSliderDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDarkMode).BeginInit();
            tableLayoutPanelSliderDraggingDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDraggingDarkMode).BeginInit();
            tableLayoutPanelSliderHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderHoverDarkMode).BeginInit();
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderArrowsAndTrackHoverDarkMode).BeginInit();
            tableLayoutPanelArrowDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowDarkMode).BeginInit();
            tableLayoutPanelArrowClickDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickDarkMode).BeginInit();
            tableLayoutPanelArrowClickBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickBackgroundDarkMode).BeginInit();
            tableLayoutPanelArrowHoverDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverDarkMode).BeginInit();
            tableLayoutPanelArrowHoverBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverBackgroundDarkMode).BeginInit();
            tableLayoutPanelBackgroundDarkMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundDarkMode).BeginInit();
            groupBoxColorsLightMode.SuspendLayout();
            tableLayoutPanelColorsAndDefault.SuspendLayout();
            tableLayoutPanelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcons).BeginInit();
            tableLayoutPanelBackgroundBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundBorder).BeginInit();
            tableLayoutPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            tableLayoutPanelArrowHoverBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverBackground).BeginInit();
            tableLayoutPanelArrowHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHover).BeginInit();
            tableLayoutPanelArrowClickBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickBackground).BeginInit();
            tableLayoutPanelArrowClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClick).BeginInit();
            tableLayoutPanelArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrow).BeginInit();
            tableLayoutPanelSliderArrowsAndTrackHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderArrowsAndTrackHover).BeginInit();
            tableLayoutPanelSliderHover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderHover).BeginInit();
            tableLayoutPanelSliderDragging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDragging).BeginInit();
            tableLayoutPanelSlider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSlider).BeginInit();
            tableLayoutPanelScrollbarBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScrollbarBackground).BeginInit();
            tableLayoutPanelSelectedItemBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItemBorder).BeginInit();
            tableLayoutPanelSelectedItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItem).BeginInit();
            tableLayoutPanelOpenFolderBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderBorder).BeginInit();
            tableLayoutPanelOpenFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolder).BeginInit();
            tableLayoutPanelSearchField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchField).BeginInit();
            groupBoxAppearance.SuspendLayout();
            tableLayoutPanelAppearance.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.AutoSize = true;
            tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(tabControl, 0, 0);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelBottom, 0, 1);
            tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMain.Size = new System.Drawing.Size(432, 553);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageSizeAndLocation);
            tabControl.Controls.Add(tabPageAdvanced);
            tabControl.Controls.Add(tabPageFolders);
            tabControl.Controls.Add(tabPageExpert);
            tabControl.Controls.Add(tabPageCustomize);
            tabControl.Location = new System.Drawing.Point(6, 3);
            tabControl.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 2;
            tabControl.Size = new System.Drawing.Size(420, 513);
            tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.AutoScroll = true;
            tabPageGeneral.Controls.Add(tableLayoutPanelGeneral);
            tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            tabPageGeneral.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            tabPageGeneral.Size = new System.Drawing.Size(412, 485);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "tabPageGeneral";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneral
            // 
            tableLayoutPanelGeneral.AutoSize = true;
            tableLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelGeneral.ColumnCount = 1;
            tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelGeneral.Controls.Add(buttonGeneralDefault, 0, 5);
            tableLayoutPanelGeneral.Controls.Add(groupBoxFolder, 0, 0);
            tableLayoutPanelGeneral.Controls.Add(groupBoxConfigAndLogfile, 0, 1);
            tableLayoutPanelGeneral.Controls.Add(groupBoxAutostart, 0, 2);
            tableLayoutPanelGeneral.Controls.Add(groupBoxHotkey, 0, 3);
            tableLayoutPanelGeneral.Controls.Add(groupBoxLanguage, 0, 4);
            tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            tableLayoutPanelGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelGeneral.RowCount = 6;
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelGeneral.Size = new System.Drawing.Size(377, 458);
            tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // buttonGeneralDefault
            // 
            buttonGeneralDefault.AutoSize = true;
            buttonGeneralDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonGeneralDefault.Location = new System.Drawing.Point(9, 424);
            buttonGeneralDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            buttonGeneralDefault.MinimumSize = new System.Drawing.Size(75, 25);
            buttonGeneralDefault.Name = "buttonGeneralDefault";
            buttonGeneralDefault.Size = new System.Drawing.Size(131, 25);
            buttonGeneralDefault.TabIndex = 1;
            buttonGeneralDefault.Text = "buttonGeneralDefault";
            buttonGeneralDefault.UseVisualStyleBackColor = true;
            buttonGeneralDefault.Click += ButtonGeneralDefault_Click;
            // 
            // groupBoxFolder
            // 
            groupBoxFolder.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxFolder.AutoSize = true;
            groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxFolder.Controls.Add(tableLayoutPanelFolder);
            groupBoxFolder.Location = new System.Drawing.Point(3, 3);
            groupBoxFolder.Name = "groupBoxFolder";
            groupBoxFolder.Size = new System.Drawing.Size(365, 131);
            groupBoxFolder.TabIndex = 0;
            groupBoxFolder.TabStop = false;
            groupBoxFolder.Text = "groupBoxFolder";
            // 
            // tableLayoutPanelFolder
            // 
            tableLayoutPanelFolder.AutoSize = true;
            tableLayoutPanelFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelFolder.ColumnCount = 1;
            tableLayoutPanelFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelFolder.Controls.Add(tableLayoutPanelChangeFolder, 0, 1);
            tableLayoutPanelFolder.Controls.Add(checkBoxSetFolderByWindowsContextMenu, 0, 2);
            tableLayoutPanelFolder.Controls.Add(textBoxFolder, 0, 0);
            tableLayoutPanelFolder.Controls.Add(tableLayoutPanelRelativeFolderOpenAssembly, 0, 3);
            tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelFolder.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            tableLayoutPanelFolder.RowCount = 4;
            tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolder.Size = new System.Drawing.Size(359, 109);
            tableLayoutPanelFolder.TabIndex = 0;
            // 
            // tableLayoutPanelChangeFolder
            // 
            tableLayoutPanelChangeFolder.AutoSize = true;
            tableLayoutPanelChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelChangeFolder.ColumnCount = 3;
            tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelChangeFolder.Controls.Add(buttonChangeFolder, 0, 0);
            tableLayoutPanelChangeFolder.Controls.Add(buttonOpenFolder, 2, 0);
            tableLayoutPanelChangeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelChangeFolder.Location = new System.Drawing.Point(0, 22);
            tableLayoutPanelChangeFolder.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelChangeFolder.Name = "tableLayoutPanelChangeFolder";
            tableLayoutPanelChangeFolder.RowCount = 1;
            tableLayoutPanelChangeFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(359, 31);
            tableLayoutPanelChangeFolder.TabIndex = 0;
            // 
            // buttonChangeFolder
            // 
            buttonChangeFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonChangeFolder.AutoSize = true;
            buttonChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonChangeFolder.Location = new System.Drawing.Point(2, 3);
            buttonChangeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            buttonChangeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonChangeFolder.Name = "buttonChangeFolder";
            buttonChangeFolder.Size = new System.Drawing.Size(127, 25);
            buttonChangeFolder.TabIndex = 0;
            buttonChangeFolder.Text = "buttonChangeFolder";
            buttonChangeFolder.UseVisualStyleBackColor = true;
            buttonChangeFolder.Click += ButtonChange_Click;
            // 
            // buttonOpenFolder
            // 
            buttonOpenFolder.AutoSize = true;
            buttonOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOpenFolder.Location = new System.Drawing.Point(241, 3);
            buttonOpenFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonOpenFolder.Name = "buttonOpenFolder";
            buttonOpenFolder.Size = new System.Drawing.Size(115, 25);
            buttonOpenFolder.TabIndex = 3;
            buttonOpenFolder.Text = "buttonOpenFolder";
            buttonOpenFolder.UseVisualStyleBackColor = true;
            buttonOpenFolder.Click += ButtonOpenFolder_Click;
            // 
            // checkBoxSetFolderByWindowsContextMenu
            // 
            checkBoxSetFolderByWindowsContextMenu.AutoSize = true;
            checkBoxSetFolderByWindowsContextMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxSetFolderByWindowsContextMenu.Location = new System.Drawing.Point(3, 56);
            checkBoxSetFolderByWindowsContextMenu.Name = "checkBoxSetFolderByWindowsContextMenu";
            checkBoxSetFolderByWindowsContextMenu.Size = new System.Drawing.Size(353, 19);
            checkBoxSetFolderByWindowsContextMenu.TabIndex = 5;
            checkBoxSetFolderByWindowsContextMenu.Text = "SetFolderByWindowsContextMenu";
            checkBoxSetFolderByWindowsContextMenu.UseVisualStyleBackColor = true;
            // 
            // textBoxFolder
            // 
            textBoxFolder.BackColor = System.Drawing.Color.White;
            textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxFolder.Location = new System.Drawing.Point(6, 3);
            textBoxFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            textBoxFolder.Name = "textBoxFolder";
            textBoxFolder.ReadOnly = true;
            textBoxFolder.Size = new System.Drawing.Size(277, 16);
            textBoxFolder.TabIndex = 0;
            textBoxFolder.TabStop = false;
            // 
            // tableLayoutPanelRelativeFolderOpenAssembly
            // 
            tableLayoutPanelRelativeFolderOpenAssembly.AutoSize = true;
            tableLayoutPanelRelativeFolderOpenAssembly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelRelativeFolderOpenAssembly.ColumnCount = 3;
            tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(buttonChangeRelativeFolder, 0, 0);
            tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(buttonOpenAssemblyLocation, 2, 0);
            tableLayoutPanelRelativeFolderOpenAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelRelativeFolderOpenAssembly.Location = new System.Drawing.Point(0, 78);
            tableLayoutPanelRelativeFolderOpenAssembly.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelRelativeFolderOpenAssembly.Name = "tableLayoutPanelRelativeFolderOpenAssembly";
            tableLayoutPanelRelativeFolderOpenAssembly.RowCount = 1;
            tableLayoutPanelRelativeFolderOpenAssembly.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelRelativeFolderOpenAssembly.Size = new System.Drawing.Size(359, 31);
            tableLayoutPanelRelativeFolderOpenAssembly.TabIndex = 0;
            // 
            // buttonChangeRelativeFolder
            // 
            buttonChangeRelativeFolder.AutoSize = true;
            buttonChangeRelativeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonChangeRelativeFolder.Location = new System.Drawing.Point(2, 3);
            buttonChangeRelativeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            buttonChangeRelativeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonChangeRelativeFolder.Name = "buttonChangeRelativeFolder";
            buttonChangeRelativeFolder.Size = new System.Drawing.Size(132, 25);
            buttonChangeRelativeFolder.TabIndex = 0;
            buttonChangeRelativeFolder.Text = "ChangeRelativeFolder";
            buttonChangeRelativeFolder.UseVisualStyleBackColor = true;
            buttonChangeRelativeFolder.Click += ButtonChangeRelativeFolder_Click;
            // 
            // buttonOpenAssemblyLocation
            // 
            buttonOpenAssemblyLocation.AutoSize = true;
            buttonOpenAssemblyLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOpenAssemblyLocation.Location = new System.Drawing.Point(177, 3);
            buttonOpenAssemblyLocation.MinimumSize = new System.Drawing.Size(75, 23);
            buttonOpenAssemblyLocation.Name = "buttonOpenAssemblyLocation";
            buttonOpenAssemblyLocation.Size = new System.Drawing.Size(179, 25);
            buttonOpenAssemblyLocation.TabIndex = 0;
            buttonOpenAssemblyLocation.Text = "buttonOpenAssemblyLocation";
            buttonOpenAssemblyLocation.UseVisualStyleBackColor = true;
            buttonOpenAssemblyLocation.Click += ButtonOpenAssemblyLocation_Click;
            // 
            // groupBoxConfigAndLogfile
            // 
            groupBoxConfigAndLogfile.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxConfigAndLogfile.AutoSize = true;
            groupBoxConfigAndLogfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxConfigAndLogfile.Controls.Add(tableLayoutPanelConfigAndLogfile);
            groupBoxConfigAndLogfile.Location = new System.Drawing.Point(3, 140);
            groupBoxConfigAndLogfile.Name = "groupBoxConfigAndLogfile";
            groupBoxConfigAndLogfile.Size = new System.Drawing.Size(365, 72);
            groupBoxConfigAndLogfile.TabIndex = 0;
            groupBoxConfigAndLogfile.TabStop = false;
            groupBoxConfigAndLogfile.Text = "groupBoxConfigAndLogfile";
            // 
            // tableLayoutPanelConfigAndLogfile
            // 
            tableLayoutPanelConfigAndLogfile.AutoSize = true;
            tableLayoutPanelConfigAndLogfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelConfigAndLogfile.ColumnCount = 1;
            tableLayoutPanelConfigAndLogfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelConfigAndLogfile.Controls.Add(checkBoxSaveLogFileInApplicationDirectory, 0, 2);
            tableLayoutPanelConfigAndLogfile.Controls.Add(checkBoxSaveConfigInApplicationDirectory, 0, 1);
            tableLayoutPanelConfigAndLogfile.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelConfigAndLogfile.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelConfigAndLogfile.Name = "tableLayoutPanelConfigAndLogfile";
            tableLayoutPanelConfigAndLogfile.RowCount = 3;
            tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfigAndLogfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfigAndLogfile.Size = new System.Drawing.Size(359, 50);
            tableLayoutPanelConfigAndLogfile.TabIndex = 0;
            // 
            // checkBoxSaveLogFileInApplicationDirectory
            // 
            checkBoxSaveLogFileInApplicationDirectory.AutoSize = true;
            checkBoxSaveLogFileInApplicationDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxSaveLogFileInApplicationDirectory.Location = new System.Drawing.Point(3, 28);
            checkBoxSaveLogFileInApplicationDirectory.Name = "checkBoxSaveLogFileInApplicationDirectory";
            checkBoxSaveLogFileInApplicationDirectory.Size = new System.Drawing.Size(353, 19);
            checkBoxSaveLogFileInApplicationDirectory.TabIndex = 1;
            checkBoxSaveLogFileInApplicationDirectory.Text = "checkBoxSaveLogFileInApplicationDirectory";
            checkBoxSaveLogFileInApplicationDirectory.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveConfigInApplicationDirectory
            // 
            checkBoxSaveConfigInApplicationDirectory.AutoSize = true;
            checkBoxSaveConfigInApplicationDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxSaveConfigInApplicationDirectory.Location = new System.Drawing.Point(3, 3);
            checkBoxSaveConfigInApplicationDirectory.Name = "checkBoxSaveConfigInApplicationDirectory";
            checkBoxSaveConfigInApplicationDirectory.Size = new System.Drawing.Size(353, 19);
            checkBoxSaveConfigInApplicationDirectory.TabIndex = 0;
            checkBoxSaveConfigInApplicationDirectory.Text = "checkBoxSaveConfigInApplicationDirectory";
            checkBoxSaveConfigInApplicationDirectory.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutostart
            // 
            groupBoxAutostart.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxAutostart.AutoSize = true;
            groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxAutostart.Controls.Add(tableLayoutPanel5);
            groupBoxAutostart.Location = new System.Drawing.Point(3, 218);
            groupBoxAutostart.Name = "groupBoxAutostart";
            groupBoxAutostart.Size = new System.Drawing.Size(365, 78);
            groupBoxAutostart.TabIndex = 0;
            groupBoxAutostart.TabStop = false;
            groupBoxAutostart.Text = "groupBoxAutostart";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.AutoSize = true;
            tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(checkBoxCheckForUpdates, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanelAutostart, 0, 0);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.Size = new System.Drawing.Size(359, 56);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // checkBoxCheckForUpdates
            // 
            checkBoxCheckForUpdates.AutoSize = true;
            checkBoxCheckForUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxCheckForUpdates.Location = new System.Drawing.Point(3, 34);
            checkBoxCheckForUpdates.Name = "checkBoxCheckForUpdates";
            checkBoxCheckForUpdates.Size = new System.Drawing.Size(353, 19);
            checkBoxCheckForUpdates.TabIndex = 10;
            checkBoxCheckForUpdates.Text = "checkBoxCheckForUpdates";
            checkBoxCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAutostart
            // 
            tableLayoutPanelAutostart.AutoSize = true;
            tableLayoutPanelAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelAutostart.ColumnCount = 3;
            tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAutostart.Controls.Add(buttonAddStartup, 0, 0);
            tableLayoutPanelAutostart.Controls.Add(labelStartupStatus, 2, 0);
            tableLayoutPanelAutostart.Controls.Add(checkBoxAutostart, 0, 0);
            tableLayoutPanelAutostart.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelAutostart.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            tableLayoutPanelAutostart.RowCount = 1;
            tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelAutostart.Size = new System.Drawing.Size(359, 31);
            tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // buttonAddStartup
            // 
            buttonAddStartup.AutoSize = true;
            buttonAddStartup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAddStartup.Location = new System.Drawing.Point(135, 3);
            buttonAddStartup.MinimumSize = new System.Drawing.Size(75, 23);
            buttonAddStartup.Name = "buttonAddStartup";
            buttonAddStartup.Size = new System.Drawing.Size(113, 25);
            buttonAddStartup.TabIndex = 10;
            buttonAddStartup.Text = "buttonAddStartup";
            buttonAddStartup.UseVisualStyleBackColor = true;
            buttonAddStartup.Click += ButtonAddStartup_Click;
            // 
            // labelStartupStatus
            // 
            labelStartupStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelStartupStatus.AutoSize = true;
            labelStartupStatus.Location = new System.Drawing.Point(254, 8);
            labelStartupStatus.Name = "labelStartupStatus";
            labelStartupStatus.Size = new System.Drawing.Size(102, 15);
            labelStartupStatus.TabIndex = 2;
            labelStartupStatus.Text = "labelStartupStatus";
            // 
            // checkBoxAutostart
            // 
            checkBoxAutostart.AutoSize = true;
            checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxAutostart.Location = new System.Drawing.Point(3, 3);
            checkBoxAutostart.Name = "checkBoxAutostart";
            checkBoxAutostart.Size = new System.Drawing.Size(126, 25);
            checkBoxAutostart.TabIndex = 9;
            checkBoxAutostart.Text = "checkBoxAutostart";
            checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            groupBoxHotkey.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxHotkey.AutoSize = true;
            groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxHotkey.Controls.Add(tableLayoutPanelHotkey);
            groupBoxHotkey.Location = new System.Drawing.Point(3, 302);
            groupBoxHotkey.Name = "groupBoxHotkey";
            groupBoxHotkey.Size = new System.Drawing.Size(365, 53);
            groupBoxHotkey.TabIndex = 0;
            groupBoxHotkey.TabStop = false;
            groupBoxHotkey.Text = "groupBoxHotkey";
            // 
            // tableLayoutPanelHotkey
            // 
            tableLayoutPanelHotkey.AutoSize = true;
            tableLayoutPanelHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelHotkey.ColumnCount = 3;
            tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelHotkey.Controls.Add(textBoxHotkeyPlaceholder, 1, 0);
            tableLayoutPanelHotkey.Controls.Add(buttonHotkeyDefault, 2, 0);
            tableLayoutPanelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelHotkey.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelHotkey.Name = "tableLayoutPanelHotkey";
            tableLayoutPanelHotkey.RowCount = 1;
            tableLayoutPanelHotkey.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelHotkey.Size = new System.Drawing.Size(359, 31);
            tableLayoutPanelHotkey.TabIndex = 0;
            // 
            // textBoxHotkeyPlaceholder
            // 
            textBoxHotkeyPlaceholder.Location = new System.Drawing.Point(3, 3);
            textBoxHotkeyPlaceholder.Name = "textBoxHotkeyPlaceholder";
            textBoxHotkeyPlaceholder.Size = new System.Drawing.Size(131, 23);
            textBoxHotkeyPlaceholder.TabIndex = 0;
            textBoxHotkeyPlaceholder.TabStop = false;
            // 
            // buttonHotkeyDefault
            // 
            buttonHotkeyDefault.AutoSize = true;
            buttonHotkeyDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonHotkeyDefault.Location = new System.Drawing.Point(227, 3);
            buttonHotkeyDefault.MinimumSize = new System.Drawing.Size(75, 23);
            buttonHotkeyDefault.Name = "buttonHotkeyDefault";
            buttonHotkeyDefault.Size = new System.Drawing.Size(129, 25);
            buttonHotkeyDefault.TabIndex = 0;
            buttonHotkeyDefault.Text = "buttonHotkeyDefault";
            buttonHotkeyDefault.UseVisualStyleBackColor = true;
            buttonHotkeyDefault.Click += ButtonHotkeyDefault_Click;
            // 
            // groupBoxLanguage
            // 
            groupBoxLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxLanguage.AutoSize = true;
            groupBoxLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxLanguage.Controls.Add(tableLayoutPanelLanguage);
            groupBoxLanguage.Location = new System.Drawing.Point(3, 361);
            groupBoxLanguage.Name = "groupBoxLanguage";
            groupBoxLanguage.Size = new System.Drawing.Size(365, 51);
            groupBoxLanguage.TabIndex = 0;
            groupBoxLanguage.TabStop = false;
            groupBoxLanguage.Text = "groupBoxLanguage";
            // 
            // tableLayoutPanelLanguage
            // 
            tableLayoutPanelLanguage.AutoSize = true;
            tableLayoutPanelLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelLanguage.ColumnCount = 2;
            tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelLanguage.Controls.Add(comboBoxLanguage, 0, 0);
            tableLayoutPanelLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelLanguage.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelLanguage.Name = "tableLayoutPanelLanguage";
            tableLayoutPanelLanguage.RowCount = 1;
            tableLayoutPanelLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelLanguage.Size = new System.Drawing.Size(359, 29);
            tableLayoutPanelLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new System.Drawing.Size(200, 23);
            comboBoxLanguage.TabIndex = 13;
            // 
            // tabPageSizeAndLocation
            // 
            tabPageSizeAndLocation.AutoScroll = true;
            tabPageSizeAndLocation.Controls.Add(tableLayoutPanelSizeAndLocation);
            tabPageSizeAndLocation.Location = new System.Drawing.Point(4, 24);
            tabPageSizeAndLocation.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            tabPageSizeAndLocation.Name = "tabPageSizeAndLocation";
            tabPageSizeAndLocation.Padding = new System.Windows.Forms.Padding(3);
            tabPageSizeAndLocation.Size = new System.Drawing.Size(412, 485);
            tabPageSizeAndLocation.TabIndex = 3;
            tabPageSizeAndLocation.Text = "tabPageSizeAndLocation";
            tabPageSizeAndLocation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSizeAndLocation
            // 
            tableLayoutPanelSizeAndLocation.AutoSize = true;
            tableLayoutPanelSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSizeAndLocation.ColumnCount = 1;
            tableLayoutPanelSizeAndLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSizeAndLocation.Controls.Add(groupBoxSubMenuAppearAt, 0, 2);
            tableLayoutPanelSizeAndLocation.Controls.Add(buttonSizeAndLocationDefault, 0, 3);
            tableLayoutPanelSizeAndLocation.Controls.Add(groupBoxMenuAppearAt, 0, 1);
            tableLayoutPanelSizeAndLocation.Controls.Add(groupBoxSize, 0, 0);
            tableLayoutPanelSizeAndLocation.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelSizeAndLocation.Name = "tableLayoutPanelSizeAndLocation";
            tableLayoutPanelSizeAndLocation.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelSizeAndLocation.RowCount = 4;
            tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSizeAndLocation.Size = new System.Drawing.Size(308, 426);
            tableLayoutPanelSizeAndLocation.TabIndex = 1;
            // 
            // groupBoxSubMenuAppearAt
            // 
            groupBoxSubMenuAppearAt.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSubMenuAppearAt.AutoSize = true;
            groupBoxSubMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxSubMenuAppearAt.Controls.Add(tableLayoutPanel3);
            groupBoxSubMenuAppearAt.Location = new System.Drawing.Point(3, 304);
            groupBoxSubMenuAppearAt.Name = "groupBoxSubMenuAppearAt";
            groupBoxSubMenuAppearAt.Size = new System.Drawing.Size(296, 76);
            groupBoxSubMenuAppearAt.TabIndex = 2;
            groupBoxSubMenuAppearAt.TabStop = false;
            groupBoxSubMenuAppearAt.Text = "groupBoxSubMenuAppearAt";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Controls.Add(radioButtonNextToPreviousMenu, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.Size = new System.Drawing.Size(290, 54);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(numericUpDownOverlappingOffsetPixels, 1, 0);
            tableLayoutPanel4.Controls.Add(labelOverlappingByPixelsOffset, 2, 0);
            tableLayoutPanel4.Controls.Add(radioButtonOverlapping, 0, 0);
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 25);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // numericUpDownOverlappingOffsetPixels
            // 
            numericUpDownOverlappingOffsetPixels.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownOverlappingOffsetPixels.Location = new System.Drawing.Point(162, 3);
            numericUpDownOverlappingOffsetPixels.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDownOverlappingOffsetPixels.Name = "numericUpDownOverlappingOffsetPixels";
            numericUpDownOverlappingOffsetPixels.Size = new System.Drawing.Size(55, 23);
            numericUpDownOverlappingOffsetPixels.TabIndex = 2;
            // 
            // labelOverlappingByPixelsOffset
            // 
            labelOverlappingByPixelsOffset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelOverlappingByPixelsOffset.AutoSize = true;
            labelOverlappingByPixelsOffset.Location = new System.Drawing.Point(223, 7);
            labelOverlappingByPixelsOffset.MaximumSize = new System.Drawing.Size(330, 0);
            labelOverlappingByPixelsOffset.Name = "labelOverlappingByPixelsOffset";
            labelOverlappingByPixelsOffset.Size = new System.Drawing.Size(64, 15);
            labelOverlappingByPixelsOffset.TabIndex = 3;
            labelOverlappingByPixelsOffset.Text = "labelOffset";
            // 
            // radioButtonOverlapping
            // 
            radioButtonOverlapping.Anchor = System.Windows.Forms.AnchorStyles.Left;
            radioButtonOverlapping.AutoSize = true;
            radioButtonOverlapping.Location = new System.Drawing.Point(3, 5);
            radioButtonOverlapping.Name = "radioButtonOverlapping";
            radioButtonOverlapping.Size = new System.Drawing.Size(153, 19);
            radioButtonOverlapping.TabIndex = 1;
            radioButtonOverlapping.TabStop = true;
            radioButtonOverlapping.Text = "radioButtonOverlapping";
            radioButtonOverlapping.UseVisualStyleBackColor = true;
            radioButtonOverlapping.CheckedChanged += RadioButtonOverlapping_CheckedChanged;
            // 
            // radioButtonNextToPreviousMenu
            // 
            radioButtonNextToPreviousMenu.AutoSize = true;
            radioButtonNextToPreviousMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonNextToPreviousMenu.Location = new System.Drawing.Point(3, 3);
            radioButtonNextToPreviousMenu.Name = "radioButtonNextToPreviousMenu";
            radioButtonNextToPreviousMenu.Size = new System.Drawing.Size(284, 19);
            radioButtonNextToPreviousMenu.TabIndex = 2;
            radioButtonNextToPreviousMenu.TabStop = true;
            radioButtonNextToPreviousMenu.Text = "radioButtonNextToPreviousMenu";
            radioButtonNextToPreviousMenu.UseVisualStyleBackColor = true;
            radioButtonNextToPreviousMenu.CheckedChanged += RadioButtonNextToPreviousMenu_CheckedChanged;
            // 
            // buttonSizeAndLocationDefault
            // 
            buttonSizeAndLocationDefault.AutoSize = true;
            buttonSizeAndLocationDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonSizeAndLocationDefault.Location = new System.Drawing.Point(9, 392);
            buttonSizeAndLocationDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            buttonSizeAndLocationDefault.MinimumSize = new System.Drawing.Size(75, 25);
            buttonSizeAndLocationDefault.Name = "buttonSizeAndLocationDefault";
            buttonSizeAndLocationDefault.Size = new System.Drawing.Size(179, 25);
            buttonSizeAndLocationDefault.TabIndex = 0;
            buttonSizeAndLocationDefault.Text = "buttonSizeAndLocationDefault";
            buttonSizeAndLocationDefault.UseVisualStyleBackColor = true;
            buttonSizeAndLocationDefault.Click += ButtonSizeAndLocationDefault_Click;
            // 
            // groupBoxMenuAppearAt
            // 
            groupBoxMenuAppearAt.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxMenuAppearAt.AutoSize = true;
            groupBoxMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxMenuAppearAt.Controls.Add(tableLayoutPanelMenuAppearAt);
            groupBoxMenuAppearAt.Location = new System.Drawing.Point(3, 176);
            groupBoxMenuAppearAt.Name = "groupBoxMenuAppearAt";
            groupBoxMenuAppearAt.Size = new System.Drawing.Size(296, 122);
            groupBoxMenuAppearAt.TabIndex = 1;
            groupBoxMenuAppearAt.TabStop = false;
            groupBoxMenuAppearAt.Text = "groupBoxMenuAppearAt";
            // 
            // tableLayoutPanelMenuAppearAt
            // 
            tableLayoutPanelMenuAppearAt.AutoSize = true;
            tableLayoutPanelMenuAppearAt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMenuAppearAt.ColumnCount = 1;
            tableLayoutPanelMenuAppearAt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMenuAppearAt.Controls.Add(radioButtonUseCustomLocation, 0, 2);
            tableLayoutPanelMenuAppearAt.Controls.Add(radioButtonAppearAtTheBottomLeft, 0, 1);
            tableLayoutPanelMenuAppearAt.Controls.Add(radioButtonAppearAtTheBottomRight, 0, 0);
            tableLayoutPanelMenuAppearAt.Controls.Add(radioButtonAppearAtMouseLocation, 0, 3);
            tableLayoutPanelMenuAppearAt.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMenuAppearAt.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelMenuAppearAt.Name = "tableLayoutPanelMenuAppearAt";
            tableLayoutPanelMenuAppearAt.RowCount = 4;
            tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMenuAppearAt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMenuAppearAt.Size = new System.Drawing.Size(290, 100);
            tableLayoutPanelMenuAppearAt.TabIndex = 1;
            // 
            // radioButtonUseCustomLocation
            // 
            radioButtonUseCustomLocation.AutoSize = true;
            radioButtonUseCustomLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonUseCustomLocation.Location = new System.Drawing.Point(3, 53);
            radioButtonUseCustomLocation.Name = "radioButtonUseCustomLocation";
            radioButtonUseCustomLocation.Size = new System.Drawing.Size(284, 19);
            radioButtonUseCustomLocation.TabIndex = 2;
            radioButtonUseCustomLocation.TabStop = true;
            radioButtonUseCustomLocation.Text = "radioButtonUseCustomLocation";
            radioButtonUseCustomLocation.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtTheBottomLeft
            // 
            radioButtonAppearAtTheBottomLeft.AutoSize = true;
            radioButtonAppearAtTheBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonAppearAtTheBottomLeft.Location = new System.Drawing.Point(3, 28);
            radioButtonAppearAtTheBottomLeft.Name = "radioButtonAppearAtTheBottomLeft";
            radioButtonAppearAtTheBottomLeft.Size = new System.Drawing.Size(284, 19);
            radioButtonAppearAtTheBottomLeft.TabIndex = 1;
            radioButtonAppearAtTheBottomLeft.TabStop = true;
            radioButtonAppearAtTheBottomLeft.Text = "radioButtonradioButtonAppearAtTheBottomLeft";
            radioButtonAppearAtTheBottomLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtTheBottomRight
            // 
            radioButtonAppearAtTheBottomRight.AutoSize = true;
            radioButtonAppearAtTheBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonAppearAtTheBottomRight.Location = new System.Drawing.Point(3, 3);
            radioButtonAppearAtTheBottomRight.Name = "radioButtonAppearAtTheBottomRight";
            radioButtonAppearAtTheBottomRight.Size = new System.Drawing.Size(284, 19);
            radioButtonAppearAtTheBottomRight.TabIndex = 2;
            radioButtonAppearAtTheBottomRight.TabStop = true;
            radioButtonAppearAtTheBottomRight.Text = "radioButtonAppearAtTheBottomRight";
            radioButtonAppearAtTheBottomRight.UseVisualStyleBackColor = true;
            // 
            // radioButtonAppearAtMouseLocation
            // 
            radioButtonAppearAtMouseLocation.AutoSize = true;
            radioButtonAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonAppearAtMouseLocation.Location = new System.Drawing.Point(3, 78);
            radioButtonAppearAtMouseLocation.Name = "radioButtonAppearAtMouseLocation";
            radioButtonAppearAtMouseLocation.Size = new System.Drawing.Size(284, 19);
            radioButtonAppearAtMouseLocation.TabIndex = 3;
            radioButtonAppearAtMouseLocation.TabStop = true;
            radioButtonAppearAtMouseLocation.Text = "radioButtonAppearAtMouseLocation";
            radioButtonAppearAtMouseLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxSize
            // 
            groupBoxSize.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSize.AutoSize = true;
            groupBoxSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxSize.Controls.Add(tableLayoutPanelSize);
            groupBoxSize.Location = new System.Drawing.Point(3, 3);
            groupBoxSize.Name = "groupBoxSize";
            groupBoxSize.Size = new System.Drawing.Size(296, 167);
            groupBoxSize.TabIndex = 0;
            groupBoxSize.TabStop = false;
            groupBoxSize.Text = "groupBoxSize";
            // 
            // tableLayoutPanelSize
            // 
            tableLayoutPanelSize.AutoSize = true;
            tableLayoutPanelSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSize.ColumnCount = 1;
            tableLayoutPanelSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSize.Controls.Add(tableLayoutPanelIconSizeInPercent, 0, 1);
            tableLayoutPanelSize.Controls.Add(tableLayoutPanelRowHeighteInPercentage, 0, 2);
            tableLayoutPanelSize.Controls.Add(tableLayoutPanelSizeInPercent, 0, 0);
            tableLayoutPanelSize.Controls.Add(tableLayoutPanelMenuHeight, 0, 4);
            tableLayoutPanelSize.Controls.Add(tableLayoutPanelMaxMenuWidth, 0, 3);
            tableLayoutPanelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelSize.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelSize.Name = "tableLayoutPanelSize";
            tableLayoutPanelSize.RowCount = 5;
            tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSize.Size = new System.Drawing.Size(290, 145);
            tableLayoutPanelSize.TabIndex = 0;
            // 
            // tableLayoutPanelIconSizeInPercent
            // 
            tableLayoutPanelIconSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelIconSizeInPercent.AutoSize = true;
            tableLayoutPanelIconSizeInPercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelIconSizeInPercent.ColumnCount = 2;
            tableLayoutPanelIconSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelIconSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelIconSizeInPercent.Controls.Add(numericUpDownIconSizeInPercent, 0, 0);
            tableLayoutPanelIconSizeInPercent.Controls.Add(labelIconSizeInPercent, 1, 0);
            tableLayoutPanelIconSizeInPercent.Location = new System.Drawing.Point(0, 29);
            tableLayoutPanelIconSizeInPercent.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelIconSizeInPercent.Name = "tableLayoutPanelIconSizeInPercent";
            tableLayoutPanelIconSizeInPercent.RowCount = 1;
            tableLayoutPanelIconSizeInPercent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelIconSizeInPercent.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanelIconSizeInPercent.TabIndex = 1;
            // 
            // numericUpDownIconSizeInPercent
            // 
            numericUpDownIconSizeInPercent.Location = new System.Drawing.Point(3, 3);
            numericUpDownIconSizeInPercent.Name = "numericUpDownIconSizeInPercent";
            numericUpDownIconSizeInPercent.Size = new System.Drawing.Size(55, 23);
            numericUpDownIconSizeInPercent.TabIndex = 1;
            // 
            // labelIconSizeInPercent
            // 
            labelIconSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelIconSizeInPercent.AutoSize = true;
            labelIconSizeInPercent.Location = new System.Drawing.Point(64, 7);
            labelIconSizeInPercent.MaximumSize = new System.Drawing.Size(330, 0);
            labelIconSizeInPercent.Name = "labelIconSizeInPercent";
            labelIconSizeInPercent.Size = new System.Drawing.Size(125, 15);
            labelIconSizeInPercent.TabIndex = 0;
            labelIconSizeInPercent.Text = "labelIconSizeInPercent";
            // 
            // tableLayoutPanelRowHeighteInPercentage
            // 
            tableLayoutPanelRowHeighteInPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelRowHeighteInPercentage.AutoSize = true;
            tableLayoutPanelRowHeighteInPercentage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelRowHeighteInPercentage.ColumnCount = 2;
            tableLayoutPanelRowHeighteInPercentage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelRowHeighteInPercentage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelRowHeighteInPercentage.Controls.Add(numericUpDownRowHeighteInPercentage, 0, 0);
            tableLayoutPanelRowHeighteInPercentage.Controls.Add(labelRowHeightInPercentage, 1, 0);
            tableLayoutPanelRowHeighteInPercentage.Location = new System.Drawing.Point(0, 58);
            tableLayoutPanelRowHeighteInPercentage.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelRowHeighteInPercentage.Name = "tableLayoutPanelRowHeighteInPercentage";
            tableLayoutPanelRowHeighteInPercentage.RowCount = 1;
            tableLayoutPanelRowHeighteInPercentage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelRowHeighteInPercentage.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanelRowHeighteInPercentage.TabIndex = 3;
            // 
            // numericUpDownRowHeighteInPercentage
            // 
            numericUpDownRowHeighteInPercentage.Location = new System.Drawing.Point(3, 3);
            numericUpDownRowHeighteInPercentage.Name = "numericUpDownRowHeighteInPercentage";
            numericUpDownRowHeighteInPercentage.Size = new System.Drawing.Size(55, 23);
            numericUpDownRowHeighteInPercentage.TabIndex = 1;
            // 
            // labelRowHeightInPercentage
            // 
            labelRowHeightInPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelRowHeightInPercentage.AutoSize = true;
            labelRowHeightInPercentage.Location = new System.Drawing.Point(64, 7);
            labelRowHeightInPercentage.MaximumSize = new System.Drawing.Size(330, 0);
            labelRowHeightInPercentage.Name = "labelRowHeightInPercentage";
            labelRowHeightInPercentage.Size = new System.Drawing.Size(166, 15);
            labelRowHeightInPercentage.TabIndex = 0;
            labelRowHeightInPercentage.Text = "labelRowHeighteInPercentage";
            // 
            // tableLayoutPanelSizeInPercent
            // 
            tableLayoutPanelSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelSizeInPercent.AutoSize = true;
            tableLayoutPanelSizeInPercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSizeInPercent.ColumnCount = 2;
            tableLayoutPanelSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSizeInPercent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSizeInPercent.Controls.Add(numericUpDownSizeInPercent, 0, 0);
            tableLayoutPanelSizeInPercent.Controls.Add(labelSizeInPercent, 1, 0);
            tableLayoutPanelSizeInPercent.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelSizeInPercent.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelSizeInPercent.Name = "tableLayoutPanelSizeInPercent";
            tableLayoutPanelSizeInPercent.RowCount = 1;
            tableLayoutPanelSizeInPercent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSizeInPercent.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanelSizeInPercent.TabIndex = 0;
            // 
            // numericUpDownSizeInPercent
            // 
            numericUpDownSizeInPercent.Location = new System.Drawing.Point(3, 3);
            numericUpDownSizeInPercent.Name = "numericUpDownSizeInPercent";
            numericUpDownSizeInPercent.Size = new System.Drawing.Size(55, 23);
            numericUpDownSizeInPercent.TabIndex = 1;
            numericUpDownSizeInPercent.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            numericUpDownSizeInPercent.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSizeInPercent
            // 
            labelSizeInPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSizeInPercent.AutoSize = true;
            labelSizeInPercent.Location = new System.Drawing.Point(64, 7);
            labelSizeInPercent.MaximumSize = new System.Drawing.Size(330, 0);
            labelSizeInPercent.Name = "labelSizeInPercent";
            labelSizeInPercent.Size = new System.Drawing.Size(102, 15);
            labelSizeInPercent.TabIndex = 0;
            labelSizeInPercent.Text = "labelSizeInPercent";
            // 
            // tableLayoutPanelMenuHeight
            // 
            tableLayoutPanelMenuHeight.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelMenuHeight.AutoSize = true;
            tableLayoutPanelMenuHeight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMenuHeight.ColumnCount = 2;
            tableLayoutPanelMenuHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMenuHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMenuHeight.Controls.Add(numericUpDownMenuHeight, 0, 0);
            tableLayoutPanelMenuHeight.Controls.Add(labelMaxMenuHeight, 1, 0);
            tableLayoutPanelMenuHeight.Location = new System.Drawing.Point(0, 116);
            tableLayoutPanelMenuHeight.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelMenuHeight.Name = "tableLayoutPanelMenuHeight";
            tableLayoutPanelMenuHeight.RowCount = 1;
            tableLayoutPanelMenuHeight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMenuHeight.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanelMenuHeight.TabIndex = 0;
            // 
            // numericUpDownMenuHeight
            // 
            numericUpDownMenuHeight.Location = new System.Drawing.Point(3, 3);
            numericUpDownMenuHeight.Name = "numericUpDownMenuHeight";
            numericUpDownMenuHeight.Size = new System.Drawing.Size(55, 23);
            numericUpDownMenuHeight.TabIndex = 1;
            numericUpDownMenuHeight.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            numericUpDownMenuHeight.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelMaxMenuHeight
            // 
            labelMaxMenuHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelMaxMenuHeight.AutoSize = true;
            labelMaxMenuHeight.Location = new System.Drawing.Point(64, 7);
            labelMaxMenuHeight.MaximumSize = new System.Drawing.Size(330, 0);
            labelMaxMenuHeight.Name = "labelMaxMenuHeight";
            labelMaxMenuHeight.Size = new System.Drawing.Size(122, 15);
            labelMaxMenuHeight.TabIndex = 0;
            labelMaxMenuHeight.Text = "labelMaxMenuHeight";
            // 
            // tableLayoutPanelMaxMenuWidth
            // 
            tableLayoutPanelMaxMenuWidth.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelMaxMenuWidth.AutoSize = true;
            tableLayoutPanelMaxMenuWidth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMaxMenuWidth.ColumnCount = 2;
            tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelMaxMenuWidth.Controls.Add(numericUpDownMenuWidth, 0, 0);
            tableLayoutPanelMaxMenuWidth.Controls.Add(labelMaxMenuWidth, 1, 0);
            tableLayoutPanelMaxMenuWidth.Location = new System.Drawing.Point(0, 87);
            tableLayoutPanelMaxMenuWidth.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelMaxMenuWidth.Name = "tableLayoutPanelMaxMenuWidth";
            tableLayoutPanelMaxMenuWidth.RowCount = 1;
            tableLayoutPanelMaxMenuWidth.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelMaxMenuWidth.Size = new System.Drawing.Size(290, 29);
            tableLayoutPanelMaxMenuWidth.TabIndex = 0;
            // 
            // numericUpDownMenuWidth
            // 
            numericUpDownMenuWidth.Location = new System.Drawing.Point(3, 3);
            numericUpDownMenuWidth.Name = "numericUpDownMenuWidth";
            numericUpDownMenuWidth.Size = new System.Drawing.Size(55, 23);
            numericUpDownMenuWidth.TabIndex = 1;
            numericUpDownMenuWidth.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            numericUpDownMenuWidth.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelMaxMenuWidth
            // 
            labelMaxMenuWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelMaxMenuWidth.AutoSize = true;
            labelMaxMenuWidth.Location = new System.Drawing.Point(64, 7);
            labelMaxMenuWidth.MaximumSize = new System.Drawing.Size(330, 0);
            labelMaxMenuWidth.Name = "labelMaxMenuWidth";
            labelMaxMenuWidth.Size = new System.Drawing.Size(118, 15);
            labelMaxMenuWidth.TabIndex = 0;
            labelMaxMenuWidth.Text = "labelMaxMenuWidth";
            // 
            // tabPageAdvanced
            // 
            tabPageAdvanced.AutoScroll = true;
            tabPageAdvanced.Controls.Add(tableLayoutPanelAdvanced);
            tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            tabPageAdvanced.Name = "tabPageAdvanced";
            tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            tabPageAdvanced.Size = new System.Drawing.Size(412, 485);
            tabPageAdvanced.TabIndex = 0;
            tabPageAdvanced.Text = "tabPageAdvanced";
            tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAdvanced
            // 
            tableLayoutPanelAdvanced.AutoSize = true;
            tableLayoutPanelAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelAdvanced.ColumnCount = 1;
            tableLayoutPanelAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelAdvanced.Controls.Add(groupBoxOptionalFeatures, 0, 0);
            tableLayoutPanelAdvanced.Controls.Add(groupBoxInternetShortcutIcons, 0, 3);
            tableLayoutPanelAdvanced.Controls.Add(groupBoxDrag, 0, 2);
            tableLayoutPanelAdvanced.Controls.Add(buttonAdvancedDefault, 0, 6);
            tableLayoutPanelAdvanced.Controls.Add(groupBoxSorting, 0, 4);
            tableLayoutPanelAdvanced.Controls.Add(groupBoxHiddenFilesAndFolders, 0, 5);
            tableLayoutPanelAdvanced.Controls.Add(groupBoxClick, 0, 1);
            tableLayoutPanelAdvanced.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelAdvanced.Name = "tableLayoutPanelAdvanced";
            tableLayoutPanelAdvanced.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelAdvanced.RowCount = 7;
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAdvanced.Size = new System.Drawing.Size(301, 670);
            tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxOptionalFeatures
            // 
            groupBoxOptionalFeatures.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxOptionalFeatures.AutoSize = true;
            groupBoxOptionalFeatures.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxOptionalFeatures.Controls.Add(tableLayoutPanel2);
            groupBoxOptionalFeatures.Location = new System.Drawing.Point(3, 3);
            groupBoxOptionalFeatures.Name = "groupBoxOptionalFeatures";
            groupBoxOptionalFeatures.Size = new System.Drawing.Size(289, 122);
            groupBoxOptionalFeatures.TabIndex = 1;
            groupBoxOptionalFeatures.TabStop = false;
            groupBoxOptionalFeatures.Text = "groupBoxOptionalFeatures";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(checkBoxShowInTaskbar, 0, 1);
            tableLayoutPanel2.Controls.Add(checkBoxSendHotkeyInsteadKillOtherInstances, 0, 2);
            tableLayoutPanel2.Controls.Add(checkBoxSupportGamepad, 0, 3);
            tableLayoutPanel2.Controls.Add(checkBoxResolveLinksToFolders, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(283, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBoxShowInTaskbar
            // 
            checkBoxShowInTaskbar.AutoSize = true;
            checkBoxShowInTaskbar.Location = new System.Drawing.Point(3, 28);
            checkBoxShowInTaskbar.Name = "checkBoxShowInTaskbar";
            checkBoxShowInTaskbar.Size = new System.Drawing.Size(155, 19);
            checkBoxShowInTaskbar.TabIndex = 1;
            checkBoxShowInTaskbar.Text = "checkBoxShowInTaskbar";
            checkBoxShowInTaskbar.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendHotkeyInsteadKillOtherInstances
            // 
            checkBoxSendHotkeyInsteadKillOtherInstances.AutoSize = true;
            checkBoxSendHotkeyInsteadKillOtherInstances.Location = new System.Drawing.Point(3, 53);
            checkBoxSendHotkeyInsteadKillOtherInstances.MaximumSize = new System.Drawing.Size(330, 0);
            checkBoxSendHotkeyInsteadKillOtherInstances.Name = "checkBoxSendHotkeyInsteadKillOtherInstances";
            checkBoxSendHotkeyInsteadKillOtherInstances.Size = new System.Drawing.Size(274, 19);
            checkBoxSendHotkeyInsteadKillOtherInstances.TabIndex = 3;
            checkBoxSendHotkeyInsteadKillOtherInstances.Text = "checkBoxSendHotkeyInsteadKillOtherInstances";
            checkBoxSendHotkeyInsteadKillOtherInstances.UseVisualStyleBackColor = true;
            // 
            // checkBoxSupportGamepad
            // 
            checkBoxSupportGamepad.AutoSize = true;
            checkBoxSupportGamepad.Location = new System.Drawing.Point(3, 78);
            checkBoxSupportGamepad.Name = "checkBoxSupportGamepad";
            checkBoxSupportGamepad.Size = new System.Drawing.Size(170, 19);
            checkBoxSupportGamepad.TabIndex = 4;
            checkBoxSupportGamepad.Text = "checkBoxSupportGamepad";
            checkBoxSupportGamepad.UseVisualStyleBackColor = true;
            // 
            // checkBoxResolveLinksToFolders
            // 
            checkBoxResolveLinksToFolders.AutoSize = true;
            checkBoxResolveLinksToFolders.Location = new System.Drawing.Point(3, 3);
            checkBoxResolveLinksToFolders.Name = "checkBoxResolveLinksToFolders";
            checkBoxResolveLinksToFolders.Size = new System.Drawing.Size(194, 19);
            checkBoxResolveLinksToFolders.TabIndex = 1;
            checkBoxResolveLinksToFolders.Text = "checkBoxResolveLinksToFolders";
            checkBoxResolveLinksToFolders.UseVisualStyleBackColor = true;
            // 
            // groupBoxInternetShortcutIcons
            // 
            groupBoxInternetShortcutIcons.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxInternetShortcutIcons.AutoSize = true;
            groupBoxInternetShortcutIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxInternetShortcutIcons.Controls.Add(tableLayoutPanelInternetShortcutIcons);
            groupBoxInternetShortcutIcons.Location = new System.Drawing.Point(3, 287);
            groupBoxInternetShortcutIcons.Name = "groupBoxInternetShortcutIcons";
            groupBoxInternetShortcutIcons.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            groupBoxInternetShortcutIcons.Size = new System.Drawing.Size(289, 81);
            groupBoxInternetShortcutIcons.TabIndex = 1;
            groupBoxInternetShortcutIcons.TabStop = false;
            groupBoxInternetShortcutIcons.Text = "groupBoxInternetShortcutIcons";
            // 
            // tableLayoutPanelInternetShortcutIcons
            // 
            tableLayoutPanelInternetShortcutIcons.AutoSize = true;
            tableLayoutPanelInternetShortcutIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelInternetShortcutIcons.ColumnCount = 1;
            tableLayoutPanelInternetShortcutIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelInternetShortcutIcons.Controls.Add(tableLayoutPanelChangeIcoFolder, 0, 1);
            tableLayoutPanelInternetShortcutIcons.Controls.Add(textBoxIcoFolder, 0, 0);
            tableLayoutPanelInternetShortcutIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelInternetShortcutIcons.Location = new System.Drawing.Point(3, 22);
            tableLayoutPanelInternetShortcutIcons.Name = "tableLayoutPanelInternetShortcutIcons";
            tableLayoutPanelInternetShortcutIcons.RowCount = 2;
            tableLayoutPanelInternetShortcutIcons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelInternetShortcutIcons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelInternetShortcutIcons.Size = new System.Drawing.Size(283, 53);
            tableLayoutPanelInternetShortcutIcons.TabIndex = 0;
            // 
            // tableLayoutPanelChangeIcoFolder
            // 
            tableLayoutPanelChangeIcoFolder.AutoSize = true;
            tableLayoutPanelChangeIcoFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelChangeIcoFolder.ColumnCount = 2;
            tableLayoutPanelChangeIcoFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelChangeIcoFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelChangeIcoFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelChangeIcoFolder.Controls.Add(buttonChangeIcoFolder, 0, 0);
            tableLayoutPanelChangeIcoFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelChangeIcoFolder.Location = new System.Drawing.Point(0, 22);
            tableLayoutPanelChangeIcoFolder.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelChangeIcoFolder.Name = "tableLayoutPanelChangeIcoFolder";
            tableLayoutPanelChangeIcoFolder.RowCount = 1;
            tableLayoutPanelChangeIcoFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelChangeIcoFolder.Size = new System.Drawing.Size(283, 31);
            tableLayoutPanelChangeIcoFolder.TabIndex = 0;
            // 
            // buttonChangeIcoFolder
            // 
            buttonChangeIcoFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonChangeIcoFolder.AutoSize = true;
            buttonChangeIcoFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonChangeIcoFolder.Location = new System.Drawing.Point(2, 3);
            buttonChangeIcoFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            buttonChangeIcoFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonChangeIcoFolder.Name = "buttonChangeIcoFolder";
            buttonChangeIcoFolder.Size = new System.Drawing.Size(143, 25);
            buttonChangeIcoFolder.TabIndex = 0;
            buttonChangeIcoFolder.Text = "buttonChangeIcoFolder";
            buttonChangeIcoFolder.UseVisualStyleBackColor = true;
            buttonChangeIcoFolder.Click += ButtonChangeIcoFolder_Click;
            // 
            // textBoxIcoFolder
            // 
            textBoxIcoFolder.BackColor = System.Drawing.Color.White;
            textBoxIcoFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxIcoFolder.Location = new System.Drawing.Point(6, 3);
            textBoxIcoFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            textBoxIcoFolder.Name = "textBoxIcoFolder";
            textBoxIcoFolder.ReadOnly = true;
            textBoxIcoFolder.Size = new System.Drawing.Size(271, 16);
            textBoxIcoFolder.TabIndex = 0;
            textBoxIcoFolder.TabStop = false;
            // 
            // groupBoxDrag
            // 
            groupBoxDrag.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxDrag.AutoSize = true;
            groupBoxDrag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxDrag.Controls.Add(tableLayoutPanel1);
            groupBoxDrag.Location = new System.Drawing.Point(3, 209);
            groupBoxDrag.Name = "groupBoxDrag";
            groupBoxDrag.Size = new System.Drawing.Size(289, 72);
            groupBoxDrag.TabIndex = 4;
            groupBoxDrag.TabStop = false;
            groupBoxDrag.Text = "groupBoxDrag";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(checkBoxSwipeScrolling, 0, 1);
            tableLayoutPanel1.Controls.Add(checkBoxDragDropItems, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(283, 50);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // checkBoxSwipeScrolling
            // 
            checkBoxSwipeScrolling.AutoSize = true;
            checkBoxSwipeScrolling.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxSwipeScrolling.Location = new System.Drawing.Point(3, 28);
            checkBoxSwipeScrolling.Name = "checkBoxSwipeScrolling";
            checkBoxSwipeScrolling.Size = new System.Drawing.Size(277, 19);
            checkBoxSwipeScrolling.TabIndex = 4;
            checkBoxSwipeScrolling.Text = "checkBoxSwipeScrolling";
            checkBoxSwipeScrolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxDragDropItems
            // 
            checkBoxDragDropItems.AutoSize = true;
            checkBoxDragDropItems.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxDragDropItems.Location = new System.Drawing.Point(3, 3);
            checkBoxDragDropItems.Name = "checkBoxDragDropItems";
            checkBoxDragDropItems.Size = new System.Drawing.Size(277, 19);
            checkBoxDragDropItems.TabIndex = 3;
            checkBoxDragDropItems.Text = "checkBoxDragDropItems";
            checkBoxDragDropItems.UseVisualStyleBackColor = true;
            // 
            // buttonAdvancedDefault
            // 
            buttonAdvancedDefault.AutoSize = true;
            buttonAdvancedDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAdvancedDefault.Location = new System.Drawing.Point(9, 636);
            buttonAdvancedDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            buttonAdvancedDefault.MinimumSize = new System.Drawing.Size(75, 25);
            buttonAdvancedDefault.Name = "buttonAdvancedDefault";
            buttonAdvancedDefault.Size = new System.Drawing.Size(144, 25);
            buttonAdvancedDefault.TabIndex = 0;
            buttonAdvancedDefault.Text = "buttonAdvancedDefault";
            buttonAdvancedDefault.UseVisualStyleBackColor = true;
            buttonAdvancedDefault.Click += ButtonAdvancedDefault_Click;
            // 
            // groupBoxSorting
            // 
            groupBoxSorting.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSorting.AutoSize = true;
            groupBoxSorting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxSorting.Controls.Add(tableLayoutPanelSorting);
            groupBoxSorting.Location = new System.Drawing.Point(3, 374);
            groupBoxSorting.Name = "groupBoxSorting";
            groupBoxSorting.Size = new System.Drawing.Size(289, 147);
            groupBoxSorting.TabIndex = 3;
            groupBoxSorting.TabStop = false;
            groupBoxSorting.Text = "groupBoxSorting";
            // 
            // tableLayoutPanelSorting
            // 
            tableLayoutPanelSorting.AutoSize = true;
            tableLayoutPanelSorting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSorting.ColumnCount = 1;
            tableLayoutPanelSorting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSorting.Controls.Add(radioButtonSortByFileExtensionAndName, 0, 2);
            tableLayoutPanelSorting.Controls.Add(radioButtonSortByTypeAndDate, 0, 1);
            tableLayoutPanelSorting.Controls.Add(radioButtonSortByTypeAndName, 0, 0);
            tableLayoutPanelSorting.Controls.Add(radioButtonSortByDate, 0, 4);
            tableLayoutPanelSorting.Controls.Add(radioButtonSortByName, 0, 3);
            tableLayoutPanelSorting.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelSorting.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelSorting.Name = "tableLayoutPanelSorting";
            tableLayoutPanelSorting.RowCount = 5;
            tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSorting.Size = new System.Drawing.Size(283, 125);
            tableLayoutPanelSorting.TabIndex = 1;
            // 
            // radioButtonSortByFileExtensionAndName
            // 
            radioButtonSortByFileExtensionAndName.AutoSize = true;
            radioButtonSortByFileExtensionAndName.Location = new System.Drawing.Point(3, 53);
            radioButtonSortByFileExtensionAndName.Name = "radioButtonSortByFileExtensionAndName";
            radioButtonSortByFileExtensionAndName.Size = new System.Drawing.Size(245, 19);
            radioButtonSortByFileExtensionAndName.TabIndex = 5;
            radioButtonSortByFileExtensionAndName.TabStop = true;
            radioButtonSortByFileExtensionAndName.Text = "radioButtonSortByFileExtensionAndName";
            radioButtonSortByFileExtensionAndName.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByTypeAndDate
            // 
            radioButtonSortByTypeAndDate.AutoSize = true;
            radioButtonSortByTypeAndDate.Location = new System.Drawing.Point(3, 28);
            radioButtonSortByTypeAndDate.Name = "radioButtonSortByTypeAndDate";
            radioButtonSortByTypeAndDate.Size = new System.Drawing.Size(192, 19);
            radioButtonSortByTypeAndDate.TabIndex = 3;
            radioButtonSortByTypeAndDate.TabStop = true;
            radioButtonSortByTypeAndDate.Text = "radioButtonSortByTypeAndDate";
            radioButtonSortByTypeAndDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByTypeAndName
            // 
            radioButtonSortByTypeAndName.AutoSize = true;
            radioButtonSortByTypeAndName.Location = new System.Drawing.Point(3, 3);
            radioButtonSortByTypeAndName.Name = "radioButtonSortByTypeAndName";
            radioButtonSortByTypeAndName.Size = new System.Drawing.Size(200, 19);
            radioButtonSortByTypeAndName.TabIndex = 4;
            radioButtonSortByTypeAndName.TabStop = true;
            radioButtonSortByTypeAndName.Text = "radioButtonSortByTypeAndName";
            radioButtonSortByTypeAndName.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByDate
            // 
            radioButtonSortByDate.AutoSize = true;
            radioButtonSortByDate.Location = new System.Drawing.Point(3, 103);
            radioButtonSortByDate.Name = "radioButtonSortByDate";
            radioButtonSortByDate.Size = new System.Drawing.Size(146, 19);
            radioButtonSortByDate.TabIndex = 1;
            radioButtonSortByDate.TabStop = true;
            radioButtonSortByDate.Text = "radioButtonSortByDate";
            radioButtonSortByDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortByName
            // 
            radioButtonSortByName.AutoSize = true;
            radioButtonSortByName.Location = new System.Drawing.Point(3, 78);
            radioButtonSortByName.Name = "radioButtonSortByName";
            radioButtonSortByName.Size = new System.Drawing.Size(154, 19);
            radioButtonSortByName.TabIndex = 2;
            radioButtonSortByName.TabStop = true;
            radioButtonSortByName.Text = "radioButtonSortByName";
            radioButtonSortByName.UseVisualStyleBackColor = true;
            // 
            // groupBoxHiddenFilesAndFolders
            // 
            groupBoxHiddenFilesAndFolders.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxHiddenFilesAndFolders.AutoSize = true;
            groupBoxHiddenFilesAndFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxHiddenFilesAndFolders.Controls.Add(tableLayoutPanelHiddenFilesAndFolders);
            groupBoxHiddenFilesAndFolders.Location = new System.Drawing.Point(3, 527);
            groupBoxHiddenFilesAndFolders.Name = "groupBoxHiddenFilesAndFolders";
            groupBoxHiddenFilesAndFolders.Size = new System.Drawing.Size(289, 97);
            groupBoxHiddenFilesAndFolders.TabIndex = 2;
            groupBoxHiddenFilesAndFolders.TabStop = false;
            groupBoxHiddenFilesAndFolders.Text = "groupBoxHiddenFilesAndFolders";
            // 
            // tableLayoutPanelHiddenFilesAndFolders
            // 
            tableLayoutPanelHiddenFilesAndFolders.AutoSize = true;
            tableLayoutPanelHiddenFilesAndFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelHiddenFilesAndFolders.ColumnCount = 1;
            tableLayoutPanelHiddenFilesAndFolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelHiddenFilesAndFolders.Controls.Add(radioButtonAlwaysShowHiddenFiles, 0, 2);
            tableLayoutPanelHiddenFilesAndFolders.Controls.Add(radioButtonNeverShowHiddenFiles, 0, 1);
            tableLayoutPanelHiddenFilesAndFolders.Controls.Add(radioButtonSystemSettingsShowHiddenFiles, 0, 0);
            tableLayoutPanelHiddenFilesAndFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelHiddenFilesAndFolders.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelHiddenFilesAndFolders.Name = "tableLayoutPanelHiddenFilesAndFolders";
            tableLayoutPanelHiddenFilesAndFolders.RowCount = 3;
            tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelHiddenFilesAndFolders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelHiddenFilesAndFolders.Size = new System.Drawing.Size(283, 75);
            tableLayoutPanelHiddenFilesAndFolders.TabIndex = 1;
            // 
            // radioButtonAlwaysShowHiddenFiles
            // 
            radioButtonAlwaysShowHiddenFiles.AutoSize = true;
            radioButtonAlwaysShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonAlwaysShowHiddenFiles.Location = new System.Drawing.Point(3, 53);
            radioButtonAlwaysShowHiddenFiles.Name = "radioButtonAlwaysShowHiddenFiles";
            radioButtonAlwaysShowHiddenFiles.Size = new System.Drawing.Size(277, 19);
            radioButtonAlwaysShowHiddenFiles.TabIndex = 2;
            radioButtonAlwaysShowHiddenFiles.TabStop = true;
            radioButtonAlwaysShowHiddenFiles.Text = "radioButtonAlwaysShowHiddenFiles";
            radioButtonAlwaysShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonNeverShowHiddenFiles
            // 
            radioButtonNeverShowHiddenFiles.AutoSize = true;
            radioButtonNeverShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonNeverShowHiddenFiles.Location = new System.Drawing.Point(3, 28);
            radioButtonNeverShowHiddenFiles.Name = "radioButtonNeverShowHiddenFiles";
            radioButtonNeverShowHiddenFiles.Size = new System.Drawing.Size(277, 19);
            radioButtonNeverShowHiddenFiles.TabIndex = 1;
            radioButtonNeverShowHiddenFiles.TabStop = true;
            radioButtonNeverShowHiddenFiles.Text = "radioButtonNeverShowHiddenFiles";
            radioButtonNeverShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonSystemSettingsShowHiddenFiles
            // 
            radioButtonSystemSettingsShowHiddenFiles.AutoSize = true;
            radioButtonSystemSettingsShowHiddenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            radioButtonSystemSettingsShowHiddenFiles.Location = new System.Drawing.Point(3, 3);
            radioButtonSystemSettingsShowHiddenFiles.Name = "radioButtonSystemSettingsShowHiddenFiles";
            radioButtonSystemSettingsShowHiddenFiles.Size = new System.Drawing.Size(277, 19);
            radioButtonSystemSettingsShowHiddenFiles.TabIndex = 2;
            radioButtonSystemSettingsShowHiddenFiles.TabStop = true;
            radioButtonSystemSettingsShowHiddenFiles.Text = "radioButtonSystemSettingsShowHiddenFiles";
            radioButtonSystemSettingsShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // groupBoxClick
            // 
            groupBoxClick.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxClick.AutoSize = true;
            groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxClick.Controls.Add(tableLayoutPanelClick);
            groupBoxClick.Location = new System.Drawing.Point(3, 131);
            groupBoxClick.Name = "groupBoxClick";
            groupBoxClick.Size = new System.Drawing.Size(289, 72);
            groupBoxClick.TabIndex = 0;
            groupBoxClick.TabStop = false;
            groupBoxClick.Text = "groupBoxClick";
            // 
            // tableLayoutPanelClick
            // 
            tableLayoutPanelClick.AutoSize = true;
            tableLayoutPanelClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelClick.ColumnCount = 1;
            tableLayoutPanelClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelClick.Controls.Add(checkBoxOpenDirectoryWithOneClick, 0, 1);
            tableLayoutPanelClick.Controls.Add(checkBoxOpenItemWithOneClick, 0, 0);
            tableLayoutPanelClick.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelClick.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelClick.Name = "tableLayoutPanelClick";
            tableLayoutPanelClick.RowCount = 2;
            tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelClick.Size = new System.Drawing.Size(283, 50);
            tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxOpenDirectoryWithOneClick
            // 
            checkBoxOpenDirectoryWithOneClick.AutoSize = true;
            checkBoxOpenDirectoryWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxOpenDirectoryWithOneClick.Location = new System.Drawing.Point(3, 28);
            checkBoxOpenDirectoryWithOneClick.Name = "checkBoxOpenDirectoryWithOneClick";
            checkBoxOpenDirectoryWithOneClick.Size = new System.Drawing.Size(277, 19);
            checkBoxOpenDirectoryWithOneClick.TabIndex = 2;
            checkBoxOpenDirectoryWithOneClick.Text = "checkBoxOpenDirectoryWithOneClick";
            checkBoxOpenDirectoryWithOneClick.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            checkBoxOpenItemWithOneClick.AutoSize = true;
            checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(3, 3);
            checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(277, 19);
            checkBoxOpenItemWithOneClick.TabIndex = 0;
            checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // tabPageFolders
            // 
            tabPageFolders.Controls.Add(tableLayoutPanelFoldersInRootFolder);
            tabPageFolders.Location = new System.Drawing.Point(4, 24);
            tabPageFolders.Name = "tabPageFolders";
            tabPageFolders.Padding = new System.Windows.Forms.Padding(3);
            tabPageFolders.Size = new System.Drawing.Size(412, 485);
            tabPageFolders.TabIndex = 2;
            tabPageFolders.Text = "tabPageFolders";
            tabPageFolders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelFoldersInRootFolder
            // 
            tableLayoutPanelFoldersInRootFolder.AutoSize = true;
            tableLayoutPanelFoldersInRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelFoldersInRootFolder.ColumnCount = 1;
            tableLayoutPanelFoldersInRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelFoldersInRootFolder.Controls.Add(groupBoxFoldersInRootFolder, 0, 0);
            tableLayoutPanelFoldersInRootFolder.Controls.Add(buttonDefaultFolders, 0, 1);
            tableLayoutPanelFoldersInRootFolder.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelFoldersInRootFolder.Name = "tableLayoutPanelFoldersInRootFolder";
            tableLayoutPanelFoldersInRootFolder.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelFoldersInRootFolder.RowCount = 2;
            tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFoldersInRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelFoldersInRootFolder.Size = new System.Drawing.Size(345, 415);
            tableLayoutPanelFoldersInRootFolder.TabIndex = 1;
            // 
            // groupBoxFoldersInRootFolder
            // 
            groupBoxFoldersInRootFolder.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxFoldersInRootFolder.AutoSize = true;
            groupBoxFoldersInRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxFoldersInRootFolder.Controls.Add(tableLayoutPanelFolderToRootFoldersList);
            groupBoxFoldersInRootFolder.Location = new System.Drawing.Point(3, 3);
            groupBoxFoldersInRootFolder.Name = "groupBoxFoldersInRootFolder";
            groupBoxFoldersInRootFolder.Size = new System.Drawing.Size(333, 366);
            groupBoxFoldersInRootFolder.TabIndex = 0;
            groupBoxFoldersInRootFolder.TabStop = false;
            groupBoxFoldersInRootFolder.Text = "groupBoxFoldersInRootFolder";
            // 
            // tableLayoutPanelFolderToRootFoldersList
            // 
            tableLayoutPanelFolderToRootFoldersList.AutoSize = true;
            tableLayoutPanelFolderToRootFoldersList.ColumnCount = 1;
            tableLayoutPanelFolderToRootFoldersList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelFolderToRootFoldersList.Controls.Add(tableLayoutPanelFolderToRootFolder, 0, 2);
            tableLayoutPanelFolderToRootFoldersList.Controls.Add(dataGridViewFolders, 0, 3);
            tableLayoutPanelFolderToRootFoldersList.Controls.Add(tableLayoutPanelAddSampleStartMenuFolder, 0, 4);
            tableLayoutPanelFolderToRootFoldersList.Controls.Add(checkBoxGenerateShortcutsToDrives, 0, 5);
            tableLayoutPanelFolderToRootFoldersList.Controls.Add(checkBoxShowOnlyAsSearchResult, 0, 0);
            tableLayoutPanelFolderToRootFoldersList.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelFolderToRootFoldersList.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelFolderToRootFoldersList.Name = "tableLayoutPanelFolderToRootFoldersList";
            tableLayoutPanelFolderToRootFoldersList.RowCount = 6;
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolderToRootFoldersList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelFolderToRootFoldersList.Size = new System.Drawing.Size(327, 344);
            tableLayoutPanelFolderToRootFoldersList.TabIndex = 0;
            // 
            // tableLayoutPanelFolderToRootFolder
            // 
            tableLayoutPanelFolderToRootFolder.AutoSize = true;
            tableLayoutPanelFolderToRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelFolderToRootFolder.ColumnCount = 3;
            tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelFolderToRootFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelFolderToRootFolder.Controls.Add(buttonAddFolderToRootFolder, 0, 0);
            tableLayoutPanelFolderToRootFolder.Controls.Add(buttonRemoveFolder, 2, 0);
            tableLayoutPanelFolderToRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelFolderToRootFolder.Location = new System.Drawing.Point(0, 25);
            tableLayoutPanelFolderToRootFolder.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelFolderToRootFolder.Name = "tableLayoutPanelFolderToRootFolder";
            tableLayoutPanelFolderToRootFolder.RowCount = 1;
            tableLayoutPanelFolderToRootFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelFolderToRootFolder.Size = new System.Drawing.Size(327, 31);
            tableLayoutPanelFolderToRootFolder.TabIndex = 2;
            // 
            // buttonAddFolderToRootFolder
            // 
            buttonAddFolderToRootFolder.AutoSize = true;
            buttonAddFolderToRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAddFolderToRootFolder.Location = new System.Drawing.Point(2, 3);
            buttonAddFolderToRootFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            buttonAddFolderToRootFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonAddFolderToRootFolder.Name = "buttonAddFolderToRootFolder";
            buttonAddFolderToRootFolder.Size = new System.Drawing.Size(178, 25);
            buttonAddFolderToRootFolder.TabIndex = 0;
            buttonAddFolderToRootFolder.Text = "buttonAddFolderToRootFolder";
            buttonAddFolderToRootFolder.UseVisualStyleBackColor = true;
            buttonAddFolderToRootFolder.Click += ButtonAddFolderToRootFolder_Click;
            // 
            // buttonRemoveFolder
            // 
            buttonRemoveFolder.AutoSize = true;
            buttonRemoveFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonRemoveFolder.Location = new System.Drawing.Point(195, 3);
            buttonRemoveFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonRemoveFolder.Name = "buttonRemoveFolder";
            buttonRemoveFolder.Size = new System.Drawing.Size(129, 25);
            buttonRemoveFolder.TabIndex = 1;
            buttonRemoveFolder.Text = "buttonRemoveFolder";
            buttonRemoveFolder.UseVisualStyleBackColor = true;
            buttonRemoveFolder.Click += ButtonRemoveFolder_Click;
            // 
            // dataGridViewFolders
            // 
            dataGridViewFolders.AllowUserToAddRows = false;
            dataGridViewFolders.AllowUserToDeleteRows = false;
            dataGridViewFolders.AllowUserToResizeColumns = false;
            dataGridViewFolders.AllowUserToResizeRows = false;
            dataGridViewFolders.BackgroundColor = System.Drawing.Color.White;
            dataGridViewFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ColumnFolder, ColumnRecursiveLevel, ColumnOnlyFiles });
            dataGridViewFolders.Location = new System.Drawing.Point(3, 59);
            dataGridViewFolders.Name = "dataGridViewFolders";
            dataGridViewFolders.RowHeadersVisible = false;
            dataGridViewFolders.RowTemplate.Height = 25;
            dataGridViewFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFolders.Size = new System.Drawing.Size(321, 226);
            dataGridViewFolders.TabIndex = 6;
            dataGridViewFolders.TabStop = false;
            dataGridViewFolders.CellValidating += DataGridViewFolders_CellValidating;
            dataGridViewFolders.CurrentCellDirtyStateChanged += DataGridViewFolders_CurrentCellDirtyStateChanged;
            dataGridViewFolders.RowsAdded += DataGridViewFolders_RowsAdded;
            dataGridViewFolders.RowsRemoved += DataGridViewFolders_RowsRemoved;
            dataGridViewFolders.SelectionChanged += DataGridViewFolders_SelectionChanged;
            dataGridViewFolders.MouseClick += DataGridViewFolders_MouseClick;
            // 
            // ColumnFolder
            // 
            ColumnFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ColumnFolder.HeaderText = "ColumnFolder";
            ColumnFolder.Name = "ColumnFolder";
            // 
            // ColumnRecursiveLevel
            // 
            ColumnRecursiveLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColumnRecursiveLevel.HeaderText = "ColumnRecursiveLevel";
            ColumnRecursiveLevel.Name = "ColumnRecursiveLevel";
            ColumnRecursiveLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ColumnRecursiveLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            ColumnRecursiveLevel.Width = 152;
            // 
            // ColumnOnlyFiles
            // 
            ColumnOnlyFiles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColumnOnlyFiles.HeaderText = "ColumnOnlyFiles";
            ColumnOnlyFiles.Name = "ColumnOnlyFiles";
            ColumnOnlyFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ColumnOnlyFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            ColumnOnlyFiles.Width = 123;
            // 
            // tableLayoutPanelAddSampleStartMenuFolder
            // 
            tableLayoutPanelAddSampleStartMenuFolder.AutoSize = true;
            tableLayoutPanelAddSampleStartMenuFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelAddSampleStartMenuFolder.ColumnCount = 2;
            tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAddSampleStartMenuFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelAddSampleStartMenuFolder.Controls.Add(buttonAddSampleStartMenuFolder, 0, 0);
            tableLayoutPanelAddSampleStartMenuFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAddSampleStartMenuFolder.Location = new System.Drawing.Point(0, 288);
            tableLayoutPanelAddSampleStartMenuFolder.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelAddSampleStartMenuFolder.Name = "tableLayoutPanelAddSampleStartMenuFolder";
            tableLayoutPanelAddSampleStartMenuFolder.RowCount = 1;
            tableLayoutPanelAddSampleStartMenuFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAddSampleStartMenuFolder.Size = new System.Drawing.Size(327, 31);
            tableLayoutPanelAddSampleStartMenuFolder.TabIndex = 3;
            // 
            // buttonAddSampleStartMenuFolder
            // 
            buttonAddSampleStartMenuFolder.AutoSize = true;
            buttonAddSampleStartMenuFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAddSampleStartMenuFolder.Location = new System.Drawing.Point(2, 3);
            buttonAddSampleStartMenuFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            buttonAddSampleStartMenuFolder.MinimumSize = new System.Drawing.Size(75, 23);
            buttonAddSampleStartMenuFolder.Name = "buttonAddSampleStartMenuFolder";
            buttonAddSampleStartMenuFolder.Size = new System.Drawing.Size(202, 25);
            buttonAddSampleStartMenuFolder.TabIndex = 2;
            buttonAddSampleStartMenuFolder.Text = "buttonAddSampleStartMenuFolder";
            buttonAddSampleStartMenuFolder.UseVisualStyleBackColor = true;
            buttonAddSampleStartMenuFolder.Click += ButtonAddSampleStartMenuFolder_Click;
            // 
            // checkBoxGenerateShortcutsToDrives
            // 
            checkBoxGenerateShortcutsToDrives.AutoSize = true;
            checkBoxGenerateShortcutsToDrives.Location = new System.Drawing.Point(3, 322);
            checkBoxGenerateShortcutsToDrives.Name = "checkBoxGenerateShortcutsToDrives";
            checkBoxGenerateShortcutsToDrives.Size = new System.Drawing.Size(218, 19);
            checkBoxGenerateShortcutsToDrives.TabIndex = 7;
            checkBoxGenerateShortcutsToDrives.Text = "checkBoxGenerateShortcutsToDrives";
            checkBoxGenerateShortcutsToDrives.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowOnlyAsSearchResult
            // 
            checkBoxShowOnlyAsSearchResult.AutoSize = true;
            checkBoxShowOnlyAsSearchResult.Location = new System.Drawing.Point(3, 3);
            checkBoxShowOnlyAsSearchResult.Name = "checkBoxShowOnlyAsSearchResult";
            checkBoxShowOnlyAsSearchResult.Size = new System.Drawing.Size(211, 19);
            checkBoxShowOnlyAsSearchResult.TabIndex = 8;
            checkBoxShowOnlyAsSearchResult.Text = "checkBoxShowOnlyAsSearchResult";
            checkBoxShowOnlyAsSearchResult.UseVisualStyleBackColor = true;
            // 
            // buttonDefaultFolders
            // 
            buttonDefaultFolders.AutoSize = true;
            buttonDefaultFolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonDefaultFolders.Location = new System.Drawing.Point(9, 381);
            buttonDefaultFolders.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            buttonDefaultFolders.MinimumSize = new System.Drawing.Size(75, 25);
            buttonDefaultFolders.Name = "buttonDefaultFolders";
            buttonDefaultFolders.Size = new System.Drawing.Size(129, 25);
            buttonDefaultFolders.TabIndex = 6;
            buttonDefaultFolders.Text = "buttonDefaultFolders";
            buttonDefaultFolders.UseVisualStyleBackColor = true;
            buttonDefaultFolders.Click += ButtonClearFolders_Click;
            // 
            // tabPageExpert
            // 
            tabPageExpert.Controls.Add(tableLayoutPanelExpert);
            tabPageExpert.Location = new System.Drawing.Point(4, 24);
            tabPageExpert.Name = "tabPageExpert";
            tabPageExpert.Padding = new System.Windows.Forms.Padding(3);
            tabPageExpert.Size = new System.Drawing.Size(412, 485);
            tabPageExpert.TabIndex = 1;
            tabPageExpert.Text = "tabPageExpert";
            tabPageExpert.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelExpert
            // 
            tableLayoutPanelExpert.AutoSize = true;
            tableLayoutPanelExpert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelExpert.ColumnCount = 1;
            tableLayoutPanelExpert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelExpert.Controls.Add(groupBoxSearchPattern, 0, 3);
            tableLayoutPanelExpert.Controls.Add(groupBoxCache, 0, 2);
            tableLayoutPanelExpert.Controls.Add(groupBoxStaysOpen, 0, 1);
            tableLayoutPanelExpert.Controls.Add(groupBoxOpenSubmenus, 0, 0);
            tableLayoutPanelExpert.Controls.Add(buttonExpertDefault, 0, 4);
            tableLayoutPanelExpert.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelExpert.Name = "tableLayoutPanelExpert";
            tableLayoutPanelExpert.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelExpert.RowCount = 5;
            tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelExpert.Size = new System.Drawing.Size(345, 387);
            tableLayoutPanelExpert.TabIndex = 1;
            // 
            // groupBoxSearchPattern
            // 
            groupBoxSearchPattern.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSearchPattern.AutoSize = true;
            groupBoxSearchPattern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxSearchPattern.Controls.Add(tableLayoutPanelSearchPattern);
            groupBoxSearchPattern.Location = new System.Drawing.Point(3, 287);
            groupBoxSearchPattern.Name = "groupBoxSearchPattern";
            groupBoxSearchPattern.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            groupBoxSearchPattern.Size = new System.Drawing.Size(333, 54);
            groupBoxSearchPattern.TabIndex = 2;
            groupBoxSearchPattern.TabStop = false;
            groupBoxSearchPattern.Text = "groupBoxSearchPattern";
            // 
            // tableLayoutPanelSearchPattern
            // 
            tableLayoutPanelSearchPattern.AutoSize = true;
            tableLayoutPanelSearchPattern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSearchPattern.ColumnCount = 1;
            tableLayoutPanelSearchPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSearchPattern.Controls.Add(textBoxSearchPattern, 0, 0);
            tableLayoutPanelSearchPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelSearchPattern.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelSearchPattern.Name = "tableLayoutPanelSearchPattern";
            tableLayoutPanelSearchPattern.RowCount = 1;
            tableLayoutPanelSearchPattern.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSearchPattern.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelSearchPattern.TabIndex = 0;
            // 
            // textBoxSearchPattern
            // 
            textBoxSearchPattern.Location = new System.Drawing.Point(3, 3);
            textBoxSearchPattern.Name = "textBoxSearchPattern";
            textBoxSearchPattern.Size = new System.Drawing.Size(311, 23);
            textBoxSearchPattern.TabIndex = 1;
            textBoxSearchPattern.TabStop = false;
            // 
            // groupBoxCache
            // 
            groupBoxCache.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxCache.AutoSize = true;
            groupBoxCache.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxCache.Controls.Add(tableLayoutPanelCache);
            groupBoxCache.Location = new System.Drawing.Point(3, 227);
            groupBoxCache.Name = "groupBoxCache";
            groupBoxCache.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            groupBoxCache.Size = new System.Drawing.Size(333, 54);
            groupBoxCache.TabIndex = 1;
            groupBoxCache.TabStop = false;
            groupBoxCache.Text = "groupBoxCache";
            // 
            // tableLayoutPanelCache
            // 
            tableLayoutPanelCache.AutoSize = true;
            tableLayoutPanelCache.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelCache.ColumnCount = 1;
            tableLayoutPanelCache.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelCache.Controls.Add(tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems, 0, 0);
            tableLayoutPanelCache.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelCache.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelCache.Name = "tableLayoutPanelCache";
            tableLayoutPanelCache.RowCount = 1;
            tableLayoutPanelCache.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelCache.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelCache.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelCache.TabIndex = 0;
            // 
            // tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems
            // 
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.AutoSize = true;
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnCount = 2;
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Controls.Add(labelClearCacheIfMoreThanThisNumberOfItems, 1, 0);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Controls.Add(numericUpDownClearCacheIfMoreThanThisNumberOfItems, 0, 0);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Name = "tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems";
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.RowCount = 1;
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.TabIndex = 3;
            // 
            // labelClearCacheIfMoreThanThisNumberOfItems
            // 
            labelClearCacheIfMoreThanThisNumberOfItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelClearCacheIfMoreThanThisNumberOfItems.AutoSize = true;
            labelClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(64, 7);
            labelClearCacheIfMoreThanThisNumberOfItems.MaximumSize = new System.Drawing.Size(330, 0);
            labelClearCacheIfMoreThanThisNumberOfItems.Name = "labelClearCacheIfMoreThanThisNumberOfItems";
            labelClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(260, 15);
            labelClearCacheIfMoreThanThisNumberOfItems.TabIndex = 0;
            labelClearCacheIfMoreThanThisNumberOfItems.Text = "labelClearCacheIfMoreThanThisNumberOfItems";
            // 
            // numericUpDownClearCacheIfMoreThanThisNumberOfItems
            // 
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Location = new System.Drawing.Point(3, 3);
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Name = "numericUpDownClearCacheIfMoreThanThisNumberOfItems";
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Size = new System.Drawing.Size(55, 23);
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.TabIndex = 5;
            numericUpDownClearCacheIfMoreThanThisNumberOfItems.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // groupBoxStaysOpen
            // 
            groupBoxStaysOpen.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxStaysOpen.AutoSize = true;
            groupBoxStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxStaysOpen.Controls.Add(tableLayoutPanelStaysOpen);
            groupBoxStaysOpen.Location = new System.Drawing.Point(3, 63);
            groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            groupBoxStaysOpen.Size = new System.Drawing.Size(333, 158);
            groupBoxStaysOpen.TabIndex = 0;
            groupBoxStaysOpen.TabStop = false;
            groupBoxStaysOpen.Text = "groupBoxStaysOpen";
            // 
            // tableLayoutPanelStaysOpen
            // 
            tableLayoutPanelStaysOpen.AutoSize = true;
            tableLayoutPanelStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelStaysOpen.ColumnCount = 1;
            tableLayoutPanelStaysOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelStaysOpen.Controls.Add(tableLayoutPanelTimeUntilClosesAfterEnterPressed, 0, 4);
            tableLayoutPanelStaysOpen.Controls.Add(checkBoxStayOpenWhenItemClicked, 0, 0);
            tableLayoutPanelStaysOpen.Controls.Add(checkBoxStayOpenWhenFocusLost, 0, 1);
            tableLayoutPanelStaysOpen.Controls.Add(tableLayoutPanelTimeUntilCloses, 0, 2);
            tableLayoutPanelStaysOpen.Controls.Add(checkBoxStayOpenWhenFocusLostAfterEnterPressed, 0, 3);
            tableLayoutPanelStaysOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelStaysOpen.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelStaysOpen.Name = "tableLayoutPanelStaysOpen";
            tableLayoutPanelStaysOpen.RowCount = 5;
            tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(327, 133);
            tableLayoutPanelStaysOpen.TabIndex = 0;
            // 
            // tableLayoutPanelTimeUntilClosesAfterEnterPressed
            // 
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.AutoSize = true;
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnCount = 2;
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Controls.Add(labelTimeUntilClosesAfterEnterPressed, 1, 0);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Controls.Add(numericUpDownTimeUntilClosesAfterEnterPressed, 0, 0);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(0, 104);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Name = "tableLayoutPanelTimeUntilClosesAfterEnterPressed";
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.RowCount = 1;
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.TabIndex = 2;
            // 
            // labelTimeUntilClosesAfterEnterPressed
            // 
            labelTimeUntilClosesAfterEnterPressed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelTimeUntilClosesAfterEnterPressed.AutoSize = true;
            labelTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(64, 7);
            labelTimeUntilClosesAfterEnterPressed.MaximumSize = new System.Drawing.Size(300, 0);
            labelTimeUntilClosesAfterEnterPressed.Name = "labelTimeUntilClosesAfterEnterPressed";
            labelTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(210, 15);
            labelTimeUntilClosesAfterEnterPressed.TabIndex = 0;
            labelTimeUntilClosesAfterEnterPressed.Text = "labelTimeUntilClosesAfterEnterPressed";
            // 
            // numericUpDownTimeUntilClosesAfterEnterPressed
            // 
            numericUpDownTimeUntilClosesAfterEnterPressed.Location = new System.Drawing.Point(3, 3);
            numericUpDownTimeUntilClosesAfterEnterPressed.Name = "numericUpDownTimeUntilClosesAfterEnterPressed";
            numericUpDownTimeUntilClosesAfterEnterPressed.Size = new System.Drawing.Size(55, 23);
            numericUpDownTimeUntilClosesAfterEnterPressed.TabIndex = 1;
            // 
            // checkBoxStayOpenWhenItemClicked
            // 
            checkBoxStayOpenWhenItemClicked.AutoSize = true;
            checkBoxStayOpenWhenItemClicked.Checked = true;
            checkBoxStayOpenWhenItemClicked.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxStayOpenWhenItemClicked.Location = new System.Drawing.Point(3, 3);
            checkBoxStayOpenWhenItemClicked.Name = "checkBoxStayOpenWhenItemClicked";
            checkBoxStayOpenWhenItemClicked.Size = new System.Drawing.Size(222, 19);
            checkBoxStayOpenWhenItemClicked.TabIndex = 0;
            checkBoxStayOpenWhenItemClicked.Text = "checkBoxStayOpenWhenItemClicked";
            checkBoxStayOpenWhenItemClicked.UseVisualStyleBackColor = true;
            // 
            // checkBoxStayOpenWhenFocusLost
            // 
            checkBoxStayOpenWhenFocusLost.AutoSize = true;
            checkBoxStayOpenWhenFocusLost.Checked = true;
            checkBoxStayOpenWhenFocusLost.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxStayOpenWhenFocusLost.Location = new System.Drawing.Point(3, 28);
            checkBoxStayOpenWhenFocusLost.Name = "checkBoxStayOpenWhenFocusLost";
            checkBoxStayOpenWhenFocusLost.Size = new System.Drawing.Size(212, 19);
            checkBoxStayOpenWhenFocusLost.TabIndex = 0;
            checkBoxStayOpenWhenFocusLost.Text = "checkBoxStayOpenWhenFocusLost";
            checkBoxStayOpenWhenFocusLost.UseVisualStyleBackColor = true;
            checkBoxStayOpenWhenFocusLost.CheckedChanged += CheckBoxStayOpenWhenFocusLost_CheckedChanged;
            // 
            // tableLayoutPanelTimeUntilCloses
            // 
            tableLayoutPanelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelTimeUntilCloses.AutoSize = true;
            tableLayoutPanelTimeUntilCloses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelTimeUntilCloses.ColumnCount = 2;
            tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTimeUntilCloses.Controls.Add(labelTimeUntilCloses, 1, 0);
            tableLayoutPanelTimeUntilCloses.Controls.Add(numericUpDownTimeUntilClose, 0, 0);
            tableLayoutPanelTimeUntilCloses.Location = new System.Drawing.Point(0, 50);
            tableLayoutPanelTimeUntilCloses.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelTimeUntilCloses.Name = "tableLayoutPanelTimeUntilCloses";
            tableLayoutPanelTimeUntilCloses.RowCount = 1;
            tableLayoutPanelTimeUntilCloses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelTimeUntilCloses.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelTimeUntilCloses.TabIndex = 0;
            // 
            // labelTimeUntilCloses
            // 
            labelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelTimeUntilCloses.AutoSize = true;
            labelTimeUntilCloses.Location = new System.Drawing.Point(64, 7);
            labelTimeUntilCloses.MaximumSize = new System.Drawing.Size(300, 0);
            labelTimeUntilCloses.Name = "labelTimeUntilCloses";
            labelTimeUntilCloses.Size = new System.Drawing.Size(117, 15);
            labelTimeUntilCloses.TabIndex = 0;
            labelTimeUntilCloses.Text = "labelTimeUntilCloses";
            // 
            // numericUpDownTimeUntilClose
            // 
            numericUpDownTimeUntilClose.Location = new System.Drawing.Point(3, 3);
            numericUpDownTimeUntilClose.Name = "numericUpDownTimeUntilClose";
            numericUpDownTimeUntilClose.Size = new System.Drawing.Size(55, 23);
            numericUpDownTimeUntilClose.TabIndex = 1;
            numericUpDownTimeUntilClose.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            numericUpDownTimeUntilClose.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // checkBoxStayOpenWhenFocusLostAfterEnterPressed
            // 
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.AutoSize = true;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Checked = true;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Location = new System.Drawing.Point(3, 82);
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Name = "checkBoxStayOpenWhenFocusLostAfterEnterPressed";
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Size = new System.Drawing.Size(305, 19);
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.TabIndex = 1;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.Text = "checkBoxStayOpenWhenFocusLostAfterEnterPressed";
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.UseVisualStyleBackColor = true;
            checkBoxStayOpenWhenFocusLostAfterEnterPressed.CheckedChanged += CheckBoxStayOpenWhenFocusLostAfterEnterPressed_CheckedChanged;
            // 
            // groupBoxOpenSubmenus
            // 
            groupBoxOpenSubmenus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxOpenSubmenus.AutoSize = true;
            groupBoxOpenSubmenus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxOpenSubmenus.Controls.Add(tableLayoutPanelTimeUntilOpen);
            groupBoxOpenSubmenus.Location = new System.Drawing.Point(3, 3);
            groupBoxOpenSubmenus.Name = "groupBoxOpenSubmenus";
            groupBoxOpenSubmenus.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            groupBoxOpenSubmenus.Size = new System.Drawing.Size(333, 54);
            groupBoxOpenSubmenus.TabIndex = 0;
            groupBoxOpenSubmenus.TabStop = false;
            groupBoxOpenSubmenus.Text = "groupBoxOpenSubmenus";
            // 
            // tableLayoutPanelTimeUntilOpen
            // 
            tableLayoutPanelTimeUntilOpen.AutoSize = true;
            tableLayoutPanelTimeUntilOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelTimeUntilOpen.ColumnCount = 2;
            tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelTimeUntilOpen.Controls.Add(numericUpDownTimeUntilOpens, 0, 0);
            tableLayoutPanelTimeUntilOpen.Controls.Add(labelTimeUntilOpen, 1, 0);
            tableLayoutPanelTimeUntilOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelTimeUntilOpen.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelTimeUntilOpen.Name = "tableLayoutPanelTimeUntilOpen";
            tableLayoutPanelTimeUntilOpen.RowCount = 1;
            tableLayoutPanelTimeUntilOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelTimeUntilOpen.Size = new System.Drawing.Size(327, 29);
            tableLayoutPanelTimeUntilOpen.TabIndex = 0;
            // 
            // numericUpDownTimeUntilOpens
            // 
            numericUpDownTimeUntilOpens.Location = new System.Drawing.Point(3, 3);
            numericUpDownTimeUntilOpens.Name = "numericUpDownTimeUntilOpens";
            numericUpDownTimeUntilOpens.Size = new System.Drawing.Size(55, 23);
            numericUpDownTimeUntilOpens.TabIndex = 2;
            numericUpDownTimeUntilOpens.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            numericUpDownTimeUntilOpens.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelTimeUntilOpen
            // 
            labelTimeUntilOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelTimeUntilOpen.AutoSize = true;
            labelTimeUntilOpen.Location = new System.Drawing.Point(64, 7);
            labelTimeUntilOpen.MaximumSize = new System.Drawing.Size(330, 0);
            labelTimeUntilOpen.Name = "labelTimeUntilOpen";
            labelTimeUntilOpen.Size = new System.Drawing.Size(112, 15);
            labelTimeUntilOpen.TabIndex = 0;
            labelTimeUntilOpen.Text = "labelTimeUntilOpen";
            // 
            // buttonExpertDefault
            // 
            buttonExpertDefault.AutoSize = true;
            buttonExpertDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonExpertDefault.Location = new System.Drawing.Point(9, 353);
            buttonExpertDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            buttonExpertDefault.MinimumSize = new System.Drawing.Size(75, 25);
            buttonExpertDefault.Name = "buttonExpertDefault";
            buttonExpertDefault.Size = new System.Drawing.Size(124, 25);
            buttonExpertDefault.TabIndex = 0;
            buttonExpertDefault.Text = "buttonExpertDefault";
            buttonExpertDefault.UseVisualStyleBackColor = true;
            buttonExpertDefault.Click += ButtonExpertDefault_Click;
            // 
            // tabPageCustomize
            // 
            tabPageCustomize.AutoScroll = true;
            tabPageCustomize.Controls.Add(tableLayoutPanelCustomize);
            tabPageCustomize.Location = new System.Drawing.Point(4, 24);
            tabPageCustomize.Name = "tabPageCustomize";
            tabPageCustomize.Padding = new System.Windows.Forms.Padding(3);
            tabPageCustomize.Size = new System.Drawing.Size(412, 485);
            tabPageCustomize.TabIndex = 0;
            tabPageCustomize.Text = "tabPageCustomize";
            tabPageCustomize.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCustomize
            // 
            tableLayoutPanelCustomize.AutoSize = true;
            tableLayoutPanelCustomize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelCustomize.ColumnCount = 1;
            tableLayoutPanelCustomize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelCustomize.Controls.Add(groupBoxColorsDarkMode, 0, 2);
            tableLayoutPanelCustomize.Controls.Add(groupBoxColorsLightMode, 0, 1);
            tableLayoutPanelCustomize.Controls.Add(groupBoxAppearance, 0, 0);
            tableLayoutPanelCustomize.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            tableLayoutPanelCustomize.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            tableLayoutPanelCustomize.RowCount = 3;
            tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelCustomize.Size = new System.Drawing.Size(385, 1581);
            tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxColorsDarkMode
            // 
            groupBoxColorsDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxColorsDarkMode.AutoSize = true;
            groupBoxColorsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxColorsDarkMode.Controls.Add(tableLayoutPanelDarkMode);
            groupBoxColorsDarkMode.Location = new System.Drawing.Point(3, 973);
            groupBoxColorsDarkMode.Name = "groupBoxColorsDarkMode";
            groupBoxColorsDarkMode.Size = new System.Drawing.Size(373, 605);
            groupBoxColorsDarkMode.TabIndex = 0;
            groupBoxColorsDarkMode.TabStop = false;
            groupBoxColorsDarkMode.Text = "groupBoxColorsDarkMode";
            // 
            // tableLayoutPanelDarkMode
            // 
            tableLayoutPanelDarkMode.AutoSize = true;
            tableLayoutPanelDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelDarkMode.ColumnCount = 1;
            tableLayoutPanelDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelColorIconsDarkMode, 0, 1);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelColorBackgroundBorderDarkMode, 0, 3);
            tableLayoutPanelDarkMode.Controls.Add(labelMenuDarkMode, 0, 0);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSearchFieldDarkMode, 0, 4);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelOpenFolderDarkMode, 0, 5);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelOpenFolderBorderDarkMode, 0, 6);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSelectedItemDarkMode, 0, 7);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSelectedItemBorderDarkMode, 0, 8);
            tableLayoutPanelDarkMode.Controls.Add(labelScrollbarDarkMode, 0, 9);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelScrollbarBackgroundDarkMode, 0, 10);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSliderDarkMode, 0, 11);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSliderDraggingDarkMode, 0, 12);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSliderHoverDarkMode, 0, 13);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelSliderArrowsAndTrackHoverDarkMode, 0, 14);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelArrowDarkMode, 0, 15);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelArrowClickDarkMode, 0, 16);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelArrowClickBackgroundDarkMode, 0, 17);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelArrowHoverDarkMode, 0, 18);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelArrowHoverBackgroundDarkMode, 0, 19);
            tableLayoutPanelDarkMode.Controls.Add(buttonColorsDefaultDarkMode, 0, 20);
            tableLayoutPanelDarkMode.Controls.Add(tableLayoutPanelBackgroundDarkMode, 0, 2);
            tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelDarkMode.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            tableLayoutPanelDarkMode.RowCount = 21;
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelDarkMode.Size = new System.Drawing.Size(367, 583);
            tableLayoutPanelDarkMode.TabIndex = 0;
            // 
            // tableLayoutPanelColorIconsDarkMode
            // 
            tableLayoutPanelColorIconsDarkMode.AutoSize = true;
            tableLayoutPanelColorIconsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelColorIconsDarkMode.ColumnCount = 3;
            tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelColorIconsDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelColorIconsDarkMode.Controls.Add(pictureBoxIconsDarkMode, 0, 0);
            tableLayoutPanelColorIconsDarkMode.Controls.Add(labelIconsDarkMode, 2, 0);
            tableLayoutPanelColorIconsDarkMode.Controls.Add(textBoxColorIconsDarkMode, 1, 0);
            tableLayoutPanelColorIconsDarkMode.Location = new System.Drawing.Point(3, 18);
            tableLayoutPanelColorIconsDarkMode.Name = "tableLayoutPanelColorIconsDarkMode";
            tableLayoutPanelColorIconsDarkMode.RowCount = 1;
            tableLayoutPanelColorIconsDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorIconsDarkMode.Size = new System.Drawing.Size(213, 23);
            tableLayoutPanelColorIconsDarkMode.TabIndex = 2;
            // 
            // pictureBoxIconsDarkMode
            // 
            pictureBoxIconsDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxIconsDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxIconsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxIconsDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxIconsDarkMode.Name = "pictureBoxIconsDarkMode";
            pictureBoxIconsDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxIconsDarkMode.TabIndex = 1;
            pictureBoxIconsDarkMode.TabStop = false;
            pictureBoxIconsDarkMode.Click += PictureBoxClick;
            // 
            // labelIconsDarkMode
            // 
            labelIconsDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelIconsDarkMode.AutoSize = true;
            labelIconsDarkMode.Location = new System.Drawing.Point(95, 4);
            labelIconsDarkMode.Name = "labelIconsDarkMode";
            labelIconsDarkMode.Size = new System.Drawing.Size(115, 15);
            labelIconsDarkMode.TabIndex = 0;
            labelIconsDarkMode.Text = "labelIconsDarkMode";
            // 
            // textBoxColorIconsDarkMode
            // 
            textBoxColorIconsDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorIconsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorIconsDarkMode.MaxLength = 12;
            textBoxColorIconsDarkMode.Name = "textBoxColorIconsDarkMode";
            textBoxColorIconsDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorIconsDarkMode.TabIndex = 2;
            textBoxColorIconsDarkMode.Text = "#ffffff";
            textBoxColorIconsDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorIconsDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorIconsDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // tableLayoutPanelColorBackgroundBorderDarkMode
            // 
            tableLayoutPanelColorBackgroundBorderDarkMode.AutoSize = true;
            tableLayoutPanelColorBackgroundBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelColorBackgroundBorderDarkMode.ColumnCount = 3;
            tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelColorBackgroundBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(pictureBoxBackgroundBorderDarkMode, 0, 0);
            tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(labelBackgroundBorderDarkMode, 2, 0);
            tableLayoutPanelColorBackgroundBorderDarkMode.Controls.Add(textBoxColorBackgroundBorderDarkMode, 1, 0);
            tableLayoutPanelColorBackgroundBorderDarkMode.Location = new System.Drawing.Point(3, 76);
            tableLayoutPanelColorBackgroundBorderDarkMode.Name = "tableLayoutPanelColorBackgroundBorderDarkMode";
            tableLayoutPanelColorBackgroundBorderDarkMode.RowCount = 1;
            tableLayoutPanelColorBackgroundBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorBackgroundBorderDarkMode.Size = new System.Drawing.Size(284, 23);
            tableLayoutPanelColorBackgroundBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxBackgroundBorderDarkMode
            // 
            pictureBoxBackgroundBorderDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxBackgroundBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxBackgroundBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxBackgroundBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxBackgroundBorderDarkMode.Name = "pictureBoxBackgroundBorderDarkMode";
            pictureBoxBackgroundBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxBackgroundBorderDarkMode.TabIndex = 1;
            pictureBoxBackgroundBorderDarkMode.TabStop = false;
            pictureBoxBackgroundBorderDarkMode.Click += PictureBoxClick;
            // 
            // labelBackgroundBorderDarkMode
            // 
            labelBackgroundBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelBackgroundBorderDarkMode.AutoSize = true;
            labelBackgroundBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            labelBackgroundBorderDarkMode.Name = "labelBackgroundBorderDarkMode";
            labelBackgroundBorderDarkMode.Size = new System.Drawing.Size(186, 15);
            labelBackgroundBorderDarkMode.TabIndex = 0;
            labelBackgroundBorderDarkMode.Text = "labelBackgroundDarkModeBorder";
            // 
            // textBoxColorBackgroundBorderDarkMode
            // 
            textBoxColorBackgroundBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorBackgroundBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorBackgroundBorderDarkMode.MaxLength = 12;
            textBoxColorBackgroundBorderDarkMode.Name = "textBoxColorBackgroundBorderDarkMode";
            textBoxColorBackgroundBorderDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorBackgroundBorderDarkMode.TabIndex = 2;
            textBoxColorBackgroundBorderDarkMode.Text = "#ffffff";
            textBoxColorBackgroundBorderDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorBackgroundBorderDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorBackgroundBorderDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelMenuDarkMode
            // 
            labelMenuDarkMode.AutoSize = true;
            labelMenuDarkMode.Location = new System.Drawing.Point(3, 0);
            labelMenuDarkMode.Name = "labelMenuDarkMode";
            labelMenuDarkMode.Size = new System.Drawing.Size(118, 15);
            labelMenuDarkMode.TabIndex = 3;
            labelMenuDarkMode.Text = "labelMenuDarkMode";
            // 
            // tableLayoutPanelSearchFieldDarkMode
            // 
            tableLayoutPanelSearchFieldDarkMode.AutoSize = true;
            tableLayoutPanelSearchFieldDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSearchFieldDarkMode.ColumnCount = 3;
            tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSearchFieldDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSearchFieldDarkMode.Controls.Add(pictureBoxSearchFieldDarkMode, 0, 0);
            tableLayoutPanelSearchFieldDarkMode.Controls.Add(labelSearchFieldDarkMode, 2, 0);
            tableLayoutPanelSearchFieldDarkMode.Controls.Add(textBoxColorSearchFieldDarkMode, 1, 0);
            tableLayoutPanelSearchFieldDarkMode.Location = new System.Drawing.Point(3, 105);
            tableLayoutPanelSearchFieldDarkMode.Name = "tableLayoutPanelSearchFieldDarkMode";
            tableLayoutPanelSearchFieldDarkMode.RowCount = 1;
            tableLayoutPanelSearchFieldDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSearchFieldDarkMode.Size = new System.Drawing.Size(245, 23);
            tableLayoutPanelSearchFieldDarkMode.TabIndex = 2;
            // 
            // pictureBoxSearchFieldDarkMode
            // 
            pictureBoxSearchFieldDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSearchFieldDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSearchFieldDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSearchFieldDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSearchFieldDarkMode.Name = "pictureBoxSearchFieldDarkMode";
            pictureBoxSearchFieldDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSearchFieldDarkMode.TabIndex = 1;
            pictureBoxSearchFieldDarkMode.TabStop = false;
            pictureBoxSearchFieldDarkMode.Click += PictureBoxClick;
            // 
            // labelSearchFieldDarkMode
            // 
            labelSearchFieldDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSearchFieldDarkMode.AutoSize = true;
            labelSearchFieldDarkMode.Location = new System.Drawing.Point(95, 4);
            labelSearchFieldDarkMode.Name = "labelSearchFieldDarkMode";
            labelSearchFieldDarkMode.Size = new System.Drawing.Size(147, 15);
            labelSearchFieldDarkMode.TabIndex = 0;
            labelSearchFieldDarkMode.Text = "labelSearchFieldDarkMode";
            // 
            // textBoxColorSearchFieldDarkMode
            // 
            textBoxColorSearchFieldDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSearchFieldDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSearchFieldDarkMode.MaxLength = 12;
            textBoxColorSearchFieldDarkMode.Name = "textBoxColorSearchFieldDarkMode";
            textBoxColorSearchFieldDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSearchFieldDarkMode.TabIndex = 2;
            textBoxColorSearchFieldDarkMode.Text = "#ffffff";
            textBoxColorSearchFieldDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSearchFieldDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSearchFieldDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // tableLayoutPanelOpenFolderDarkMode
            // 
            tableLayoutPanelOpenFolderDarkMode.AutoSize = true;
            tableLayoutPanelOpenFolderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelOpenFolderDarkMode.ColumnCount = 3;
            tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelOpenFolderDarkMode.Controls.Add(pictureBoxOpenFolderDarkMode, 0, 0);
            tableLayoutPanelOpenFolderDarkMode.Controls.Add(labelOpenFolderDarkMode, 2, 0);
            tableLayoutPanelOpenFolderDarkMode.Controls.Add(textBoxColorOpenFolderDarkMode, 1, 0);
            tableLayoutPanelOpenFolderDarkMode.Location = new System.Drawing.Point(3, 134);
            tableLayoutPanelOpenFolderDarkMode.Name = "tableLayoutPanelOpenFolderDarkMode";
            tableLayoutPanelOpenFolderDarkMode.RowCount = 1;
            tableLayoutPanelOpenFolderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelOpenFolderDarkMode.Size = new System.Drawing.Size(247, 23);
            tableLayoutPanelOpenFolderDarkMode.TabIndex = 2;
            // 
            // pictureBoxOpenFolderDarkMode
            // 
            pictureBoxOpenFolderDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxOpenFolderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxOpenFolderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxOpenFolderDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxOpenFolderDarkMode.Name = "pictureBoxOpenFolderDarkMode";
            pictureBoxOpenFolderDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxOpenFolderDarkMode.TabIndex = 1;
            pictureBoxOpenFolderDarkMode.TabStop = false;
            pictureBoxOpenFolderDarkMode.Click += PictureBoxClick;
            // 
            // labelOpenFolderDarkMode
            // 
            labelOpenFolderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelOpenFolderDarkMode.AutoSize = true;
            labelOpenFolderDarkMode.Location = new System.Drawing.Point(95, 4);
            labelOpenFolderDarkMode.Name = "labelOpenFolderDarkMode";
            labelOpenFolderDarkMode.Size = new System.Drawing.Size(149, 15);
            labelOpenFolderDarkMode.TabIndex = 0;
            labelOpenFolderDarkMode.Text = "labelOpenFolderDarkMode";
            // 
            // textBoxColorOpenFolderDarkMode
            // 
            textBoxColorOpenFolderDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorOpenFolderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorOpenFolderDarkMode.MaxLength = 12;
            textBoxColorOpenFolderDarkMode.Name = "textBoxColorOpenFolderDarkMode";
            textBoxColorOpenFolderDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorOpenFolderDarkMode.TabIndex = 2;
            textBoxColorOpenFolderDarkMode.Text = "#ffffff";
            textBoxColorOpenFolderDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorOpenFolderDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorOpenFolderDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // tableLayoutPanelOpenFolderBorderDarkMode
            // 
            tableLayoutPanelOpenFolderBorderDarkMode.AutoSize = true;
            tableLayoutPanelOpenFolderBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelOpenFolderBorderDarkMode.ColumnCount = 3;
            tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(pictureBoxOpenFolderBorderDarkMode, 0, 0);
            tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(labelOpenFolderBorderDarkMode, 2, 0);
            tableLayoutPanelOpenFolderBorderDarkMode.Controls.Add(textBoxColorOpenFolderBorderDarkMode, 1, 0);
            tableLayoutPanelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(3, 163);
            tableLayoutPanelOpenFolderBorderDarkMode.Name = "tableLayoutPanelOpenFolderBorderDarkMode";
            tableLayoutPanelOpenFolderBorderDarkMode.RowCount = 1;
            tableLayoutPanelOpenFolderBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(282, 23);
            tableLayoutPanelOpenFolderBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorderDarkMode
            // 
            pictureBoxOpenFolderBorderDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxOpenFolderBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxOpenFolderBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxOpenFolderBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxOpenFolderBorderDarkMode.Name = "pictureBoxOpenFolderBorderDarkMode";
            pictureBoxOpenFolderBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxOpenFolderBorderDarkMode.TabIndex = 1;
            pictureBoxOpenFolderBorderDarkMode.TabStop = false;
            pictureBoxOpenFolderBorderDarkMode.Click += PictureBoxClick;
            // 
            // labelOpenFolderBorderDarkMode
            // 
            labelOpenFolderBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelOpenFolderBorderDarkMode.AutoSize = true;
            labelOpenFolderBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            labelOpenFolderBorderDarkMode.Name = "labelOpenFolderBorderDarkMode";
            labelOpenFolderBorderDarkMode.Size = new System.Drawing.Size(184, 15);
            labelOpenFolderBorderDarkMode.TabIndex = 0;
            labelOpenFolderBorderDarkMode.Text = "labelOpenFolderBorderDarkMode";
            // 
            // textBoxColorOpenFolderBorderDarkMode
            // 
            textBoxColorOpenFolderBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorOpenFolderBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorOpenFolderBorderDarkMode.Name = "textBoxColorOpenFolderBorderDarkMode";
            textBoxColorOpenFolderBorderDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorOpenFolderBorderDarkMode.TabIndex = 2;
            textBoxColorOpenFolderBorderDarkMode.Text = "#ffffff";
            textBoxColorOpenFolderBorderDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorOpenFolderBorderDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorOpenFolderBorderDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // tableLayoutPanelSelectedItemDarkMode
            // 
            tableLayoutPanelSelectedItemDarkMode.AutoSize = true;
            tableLayoutPanelSelectedItemDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSelectedItemDarkMode.ColumnCount = 3;
            tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSelectedItemDarkMode.Controls.Add(pictureColorBoxSelectedItemDarkMode, 0, 0);
            tableLayoutPanelSelectedItemDarkMode.Controls.Add(labelSelectedItemDarkMode, 2, 0);
            tableLayoutPanelSelectedItemDarkMode.Controls.Add(textBoxColorSelecetedItemDarkMode, 1, 0);
            tableLayoutPanelSelectedItemDarkMode.Location = new System.Drawing.Point(3, 192);
            tableLayoutPanelSelectedItemDarkMode.Name = "tableLayoutPanelSelectedItemDarkMode";
            tableLayoutPanelSelectedItemDarkMode.RowCount = 1;
            tableLayoutPanelSelectedItemDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSelectedItemDarkMode.Size = new System.Drawing.Size(253, 23);
            tableLayoutPanelSelectedItemDarkMode.TabIndex = 2;
            // 
            // pictureColorBoxSelectedItemDarkMode
            // 
            pictureColorBoxSelectedItemDarkMode.BackColor = System.Drawing.Color.White;
            pictureColorBoxSelectedItemDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureColorBoxSelectedItemDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureColorBoxSelectedItemDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureColorBoxSelectedItemDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureColorBoxSelectedItemDarkMode.Name = "pictureColorBoxSelectedItemDarkMode";
            pictureColorBoxSelectedItemDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureColorBoxSelectedItemDarkMode.TabIndex = 1;
            pictureColorBoxSelectedItemDarkMode.TabStop = false;
            pictureColorBoxSelectedItemDarkMode.Click += PictureBoxClick;
            // 
            // labelSelectedItemDarkMode
            // 
            labelSelectedItemDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSelectedItemDarkMode.AutoSize = true;
            labelSelectedItemDarkMode.Location = new System.Drawing.Point(95, 4);
            labelSelectedItemDarkMode.Name = "labelSelectedItemDarkMode";
            labelSelectedItemDarkMode.Size = new System.Drawing.Size(155, 15);
            labelSelectedItemDarkMode.TabIndex = 0;
            labelSelectedItemDarkMode.Text = "labelSelectedItemDarkMode";
            // 
            // textBoxColorSelecetedItemDarkMode
            // 
            textBoxColorSelecetedItemDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSelecetedItemDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSelecetedItemDarkMode.MaxLength = 12;
            textBoxColorSelecetedItemDarkMode.Name = "textBoxColorSelecetedItemDarkMode";
            textBoxColorSelecetedItemDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSelecetedItemDarkMode.TabIndex = 2;
            textBoxColorSelecetedItemDarkMode.Text = "#ffffff";
            textBoxColorSelecetedItemDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSelecetedItemDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSelecetedItemDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // tableLayoutPanelSelectedItemBorderDarkMode
            // 
            tableLayoutPanelSelectedItemBorderDarkMode.AutoSize = true;
            tableLayoutPanelSelectedItemBorderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSelectedItemBorderDarkMode.ColumnCount = 3;
            tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemBorderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(pictureBoxSelectedItemBorderDarkMode, 0, 0);
            tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(labelSelectedItemBorderDarkMode, 2, 0);
            tableLayoutPanelSelectedItemBorderDarkMode.Controls.Add(textBoxColorSelectedItemBorderDarkMode, 1, 0);
            tableLayoutPanelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(3, 221);
            tableLayoutPanelSelectedItemBorderDarkMode.Name = "tableLayoutPanelSelectedItemBorderDarkMode";
            tableLayoutPanelSelectedItemBorderDarkMode.RowCount = 1;
            tableLayoutPanelSelectedItemBorderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(288, 23);
            tableLayoutPanelSelectedItemBorderDarkMode.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorderDarkMode
            // 
            pictureBoxSelectedItemBorderDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSelectedItemBorderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSelectedItemBorderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSelectedItemBorderDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSelectedItemBorderDarkMode.Name = "pictureBoxSelectedItemBorderDarkMode";
            pictureBoxSelectedItemBorderDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSelectedItemBorderDarkMode.TabIndex = 1;
            pictureBoxSelectedItemBorderDarkMode.TabStop = false;
            pictureBoxSelectedItemBorderDarkMode.Click += PictureBoxClick;
            // 
            // labelSelectedItemBorderDarkMode
            // 
            labelSelectedItemBorderDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSelectedItemBorderDarkMode.AutoSize = true;
            labelSelectedItemBorderDarkMode.Location = new System.Drawing.Point(95, 4);
            labelSelectedItemBorderDarkMode.Name = "labelSelectedItemBorderDarkMode";
            labelSelectedItemBorderDarkMode.Size = new System.Drawing.Size(190, 15);
            labelSelectedItemBorderDarkMode.TabIndex = 0;
            labelSelectedItemBorderDarkMode.Text = "labelSelectedItemBorderDarkMode";
            // 
            // textBoxColorSelectedItemBorderDarkMode
            // 
            textBoxColorSelectedItemBorderDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSelectedItemBorderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSelectedItemBorderDarkMode.MaxLength = 12;
            textBoxColorSelectedItemBorderDarkMode.Name = "textBoxColorSelectedItemBorderDarkMode";
            textBoxColorSelectedItemBorderDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSelectedItemBorderDarkMode.TabIndex = 2;
            textBoxColorSelectedItemBorderDarkMode.Text = "#ffffff";
            textBoxColorSelectedItemBorderDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSelectedItemBorderDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSelectedItemBorderDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelScrollbarDarkMode
            // 
            labelScrollbarDarkMode.AutoSize = true;
            labelScrollbarDarkMode.Location = new System.Drawing.Point(3, 247);
            labelScrollbarDarkMode.Name = "labelScrollbarDarkMode";
            labelScrollbarDarkMode.Size = new System.Drawing.Size(133, 15);
            labelScrollbarDarkMode.TabIndex = 3;
            labelScrollbarDarkMode.Text = "labelScrollbarDarkMode";
            // 
            // tableLayoutPanelScrollbarBackgroundDarkMode
            // 
            tableLayoutPanelScrollbarBackgroundDarkMode.AutoSize = true;
            tableLayoutPanelScrollbarBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelScrollbarBackgroundDarkMode.ColumnCount = 3;
            tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelScrollbarBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(pictureBoxScrollbarBackgroundDarkMode, 0, 0);
            tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(textBoxColorScrollbarBackgroundDarkMode, 1, 0);
            tableLayoutPanelScrollbarBackgroundDarkMode.Controls.Add(labelColorDarkModeScrollbarBackground, 2, 0);
            tableLayoutPanelScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(3, 265);
            tableLayoutPanelScrollbarBackgroundDarkMode.Name = "tableLayoutPanelScrollbarBackgroundDarkMode";
            tableLayoutPanelScrollbarBackgroundDarkMode.RowCount = 1;
            tableLayoutPanelScrollbarBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(324, 23);
            tableLayoutPanelScrollbarBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackgroundDarkMode
            // 
            pictureBoxScrollbarBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxScrollbarBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxScrollbarBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxScrollbarBackgroundDarkMode.Name = "pictureBoxScrollbarBackgroundDarkMode";
            pictureBoxScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxScrollbarBackgroundDarkMode.TabIndex = 1;
            pictureBoxScrollbarBackgroundDarkMode.TabStop = false;
            pictureBoxScrollbarBackgroundDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorScrollbarBackgroundDarkMode
            // 
            textBoxColorScrollbarBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorScrollbarBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorScrollbarBackgroundDarkMode.MaxLength = 12;
            textBoxColorScrollbarBackgroundDarkMode.Name = "textBoxColorScrollbarBackgroundDarkMode";
            textBoxColorScrollbarBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorScrollbarBackgroundDarkMode.TabIndex = 2;
            textBoxColorScrollbarBackgroundDarkMode.Text = "#ffffff";
            textBoxColorScrollbarBackgroundDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorScrollbarBackgroundDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorScrollbarBackgroundDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeScrollbarBackground
            // 
            labelColorDarkModeScrollbarBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeScrollbarBackground.AutoSize = true;
            labelColorDarkModeScrollbarBackground.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeScrollbarBackground.Name = "labelColorDarkModeScrollbarBackground";
            labelColorDarkModeScrollbarBackground.Size = new System.Drawing.Size(226, 15);
            labelColorDarkModeScrollbarBackground.TabIndex = 0;
            labelColorDarkModeScrollbarBackground.Text = "labelColorDarkModeScrollbarBackground";
            // 
            // tableLayoutPanelSliderDarkMode
            // 
            tableLayoutPanelSliderDarkMode.AutoSize = true;
            tableLayoutPanelSliderDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderDarkMode.ColumnCount = 3;
            tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderDarkMode.Controls.Add(pictureBoxSliderDarkMode, 0, 0);
            tableLayoutPanelSliderDarkMode.Controls.Add(textBoxColorSliderDarkMode, 1, 0);
            tableLayoutPanelSliderDarkMode.Controls.Add(labelColorDarkModeSlider, 2, 0);
            tableLayoutPanelSliderDarkMode.Location = new System.Drawing.Point(3, 294);
            tableLayoutPanelSliderDarkMode.Name = "tableLayoutPanelSliderDarkMode";
            tableLayoutPanelSliderDarkMode.RowCount = 1;
            tableLayoutPanelSliderDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderDarkMode.Size = new System.Drawing.Size(243, 23);
            tableLayoutPanelSliderDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderDarkMode
            // 
            pictureBoxSliderDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSliderDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderDarkMode.Name = "pictureBoxSliderDarkMode";
            pictureBoxSliderDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderDarkMode.TabIndex = 1;
            pictureBoxSliderDarkMode.TabStop = false;
            pictureBoxSliderDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorSliderDarkMode
            // 
            textBoxColorSliderDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderDarkMode.MaxLength = 12;
            textBoxColorSliderDarkMode.Name = "textBoxColorSliderDarkMode";
            textBoxColorSliderDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderDarkMode.TabIndex = 2;
            textBoxColorSliderDarkMode.Text = "#ffffff";
            textBoxColorSliderDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeSlider
            // 
            labelColorDarkModeSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeSlider.AutoSize = true;
            labelColorDarkModeSlider.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeSlider.Name = "labelColorDarkModeSlider";
            labelColorDarkModeSlider.Size = new System.Drawing.Size(145, 15);
            labelColorDarkModeSlider.TabIndex = 0;
            labelColorDarkModeSlider.Text = "labelColorDarkModeSlider";
            // 
            // tableLayoutPanelSliderDraggingDarkMode
            // 
            tableLayoutPanelSliderDraggingDarkMode.AutoSize = true;
            tableLayoutPanelSliderDraggingDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderDraggingDarkMode.ColumnCount = 3;
            tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDraggingDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderDraggingDarkMode.Controls.Add(pictureBoxSliderDraggingDarkMode, 0, 0);
            tableLayoutPanelSliderDraggingDarkMode.Controls.Add(textBoxColorSliderDraggingDarkMode, 1, 0);
            tableLayoutPanelSliderDraggingDarkMode.Controls.Add(labelColorDarkModeSliderDragging, 2, 0);
            tableLayoutPanelSliderDraggingDarkMode.Location = new System.Drawing.Point(3, 323);
            tableLayoutPanelSliderDraggingDarkMode.Name = "tableLayoutPanelSliderDraggingDarkMode";
            tableLayoutPanelSliderDraggingDarkMode.RowCount = 1;
            tableLayoutPanelSliderDraggingDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderDraggingDarkMode.Size = new System.Drawing.Size(292, 23);
            tableLayoutPanelSliderDraggingDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderDraggingDarkMode
            // 
            pictureBoxSliderDraggingDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSliderDraggingDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderDraggingDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderDraggingDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderDraggingDarkMode.Name = "pictureBoxSliderDraggingDarkMode";
            pictureBoxSliderDraggingDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderDraggingDarkMode.TabIndex = 1;
            pictureBoxSliderDraggingDarkMode.TabStop = false;
            pictureBoxSliderDraggingDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorSliderDraggingDarkMode
            // 
            textBoxColorSliderDraggingDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderDraggingDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderDraggingDarkMode.MaxLength = 12;
            textBoxColorSliderDraggingDarkMode.Name = "textBoxColorSliderDraggingDarkMode";
            textBoxColorSliderDraggingDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderDraggingDarkMode.TabIndex = 2;
            textBoxColorSliderDraggingDarkMode.Text = "#ffffff";
            textBoxColorSliderDraggingDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderDraggingDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderDraggingDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeSliderDragging
            // 
            labelColorDarkModeSliderDragging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeSliderDragging.AutoSize = true;
            labelColorDarkModeSliderDragging.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeSliderDragging.Name = "labelColorDarkModeSliderDragging";
            labelColorDarkModeSliderDragging.Size = new System.Drawing.Size(194, 15);
            labelColorDarkModeSliderDragging.TabIndex = 0;
            labelColorDarkModeSliderDragging.Text = "labelColorDarkModeSliderDragging";
            // 
            // tableLayoutPanelSliderHoverDarkMode
            // 
            tableLayoutPanelSliderHoverDarkMode.AutoSize = true;
            tableLayoutPanelSliderHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderHoverDarkMode.ColumnCount = 3;
            tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderHoverDarkMode.Controls.Add(pictureBoxSliderHoverDarkMode, 0, 0);
            tableLayoutPanelSliderHoverDarkMode.Controls.Add(textBoxColorSliderHoverDarkMode, 1, 0);
            tableLayoutPanelSliderHoverDarkMode.Controls.Add(labelColorDarkModeSliderHover, 2, 0);
            tableLayoutPanelSliderHoverDarkMode.Location = new System.Drawing.Point(3, 352);
            tableLayoutPanelSliderHoverDarkMode.Name = "tableLayoutPanelSliderHoverDarkMode";
            tableLayoutPanelSliderHoverDarkMode.RowCount = 1;
            tableLayoutPanelSliderHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderHoverDarkMode.Size = new System.Drawing.Size(275, 23);
            tableLayoutPanelSliderHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderHoverDarkMode
            // 
            pictureBoxSliderHoverDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSliderHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderHoverDarkMode.Name = "pictureBoxSliderHoverDarkMode";
            pictureBoxSliderHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderHoverDarkMode.TabIndex = 1;
            pictureBoxSliderHoverDarkMode.TabStop = false;
            pictureBoxSliderHoverDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorSliderHoverDarkMode
            // 
            textBoxColorSliderHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderHoverDarkMode.MaxLength = 12;
            textBoxColorSliderHoverDarkMode.Name = "textBoxColorSliderHoverDarkMode";
            textBoxColorSliderHoverDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderHoverDarkMode.TabIndex = 2;
            textBoxColorSliderHoverDarkMode.Text = "#ffffff";
            textBoxColorSliderHoverDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderHoverDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderHoverDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeSliderHover
            // 
            labelColorDarkModeSliderHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeSliderHover.AutoSize = true;
            labelColorDarkModeSliderHover.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeSliderHover.Name = "labelColorDarkModeSliderHover";
            labelColorDarkModeSliderHover.Size = new System.Drawing.Size(177, 15);
            labelColorDarkModeSliderHover.TabIndex = 0;
            labelColorDarkModeSliderHover.Text = "labelColorDarkModeSliderHover";
            // 
            // tableLayoutPanelSliderArrowsAndTrackHoverDarkMode
            // 
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.AutoSize = true;
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnCount = 3;
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(pictureBoxSliderArrowsAndTrackHoverDarkMode, 0, 0);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(textBoxColorSliderArrowsAndTrackHoverDarkMode, 1, 0);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Controls.Add(labelColorDarkModeSliderArrowsAndTrackHover, 2, 0);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(3, 381);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Name = "tableLayoutPanelSliderArrowsAndTrackHoverDarkMode";
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowCount = 1;
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(361, 23);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHoverDarkMode
            // 
            pictureBoxSliderArrowsAndTrackHoverDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxSliderArrowsAndTrackHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Name = "pictureBoxSliderArrowsAndTrackHoverDarkMode";
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderArrowsAndTrackHoverDarkMode.TabIndex = 1;
            pictureBoxSliderArrowsAndTrackHoverDarkMode.TabStop = false;
            pictureBoxSliderArrowsAndTrackHoverDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorSliderArrowsAndTrackHoverDarkMode
            // 
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderArrowsAndTrackHoverDarkMode.MaxLength = 12;
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Name = "textBoxColorSliderArrowsAndTrackHoverDarkMode";
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderArrowsAndTrackHoverDarkMode.TabIndex = 2;
            textBoxColorSliderArrowsAndTrackHoverDarkMode.Text = "#ffffff";
            textBoxColorSliderArrowsAndTrackHoverDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderArrowsAndTrackHoverDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderArrowsAndTrackHoverDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeSliderArrowsAndTrackHover
            // 
            labelColorDarkModeSliderArrowsAndTrackHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeSliderArrowsAndTrackHover.AutoSize = true;
            labelColorDarkModeSliderArrowsAndTrackHover.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeSliderArrowsAndTrackHover.Name = "labelColorDarkModeSliderArrowsAndTrackHover";
            labelColorDarkModeSliderArrowsAndTrackHover.Size = new System.Drawing.Size(263, 15);
            labelColorDarkModeSliderArrowsAndTrackHover.TabIndex = 0;
            labelColorDarkModeSliderArrowsAndTrackHover.Text = "labelColorDarkModeSliderArrowsAndTrackHover";
            // 
            // tableLayoutPanelArrowDarkMode
            // 
            tableLayoutPanelArrowDarkMode.AutoSize = true;
            tableLayoutPanelArrowDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowDarkMode.ColumnCount = 3;
            tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowDarkMode.Controls.Add(pictureBoxArrowDarkMode, 0, 0);
            tableLayoutPanelArrowDarkMode.Controls.Add(textBoxColorArrowDarkMode, 1, 0);
            tableLayoutPanelArrowDarkMode.Controls.Add(labelColorDarkModeArrow, 2, 0);
            tableLayoutPanelArrowDarkMode.Location = new System.Drawing.Point(3, 410);
            tableLayoutPanelArrowDarkMode.Name = "tableLayoutPanelArrowDarkMode";
            tableLayoutPanelArrowDarkMode.RowCount = 1;
            tableLayoutPanelArrowDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowDarkMode.Size = new System.Drawing.Size(246, 23);
            tableLayoutPanelArrowDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowDarkMode
            // 
            pictureBoxArrowDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxArrowDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowDarkMode.Name = "pictureBoxArrowDarkMode";
            pictureBoxArrowDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowDarkMode.TabIndex = 1;
            pictureBoxArrowDarkMode.TabStop = false;
            pictureBoxArrowDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorArrowDarkMode
            // 
            textBoxColorArrowDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowDarkMode.MaxLength = 12;
            textBoxColorArrowDarkMode.Name = "textBoxColorArrowDarkMode";
            textBoxColorArrowDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowDarkMode.TabIndex = 2;
            textBoxColorArrowDarkMode.Text = "#ffffff";
            textBoxColorArrowDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeArrow
            // 
            labelColorDarkModeArrow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeArrow.AutoSize = true;
            labelColorDarkModeArrow.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeArrow.Name = "labelColorDarkModeArrow";
            labelColorDarkModeArrow.Size = new System.Drawing.Size(148, 15);
            labelColorDarkModeArrow.TabIndex = 0;
            labelColorDarkModeArrow.Text = "labelColorDarkModeArrow";
            // 
            // tableLayoutPanelArrowClickDarkMode
            // 
            tableLayoutPanelArrowClickDarkMode.AutoSize = true;
            tableLayoutPanelArrowClickDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowClickDarkMode.ColumnCount = 3;
            tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowClickDarkMode.Controls.Add(pictureBoxArrowClickDarkMode, 0, 0);
            tableLayoutPanelArrowClickDarkMode.Controls.Add(textBoxColorArrowClickDarkMode, 1, 0);
            tableLayoutPanelArrowClickDarkMode.Controls.Add(labelColorDarkModeArrowClick, 2, 0);
            tableLayoutPanelArrowClickDarkMode.Location = new System.Drawing.Point(3, 439);
            tableLayoutPanelArrowClickDarkMode.Name = "tableLayoutPanelArrowClickDarkMode";
            tableLayoutPanelArrowClickDarkMode.RowCount = 1;
            tableLayoutPanelArrowClickDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowClickDarkMode.Size = new System.Drawing.Size(272, 23);
            tableLayoutPanelArrowClickDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowClickDarkMode
            // 
            pictureBoxArrowClickDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxArrowClickDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowClickDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowClickDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowClickDarkMode.Name = "pictureBoxArrowClickDarkMode";
            pictureBoxArrowClickDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowClickDarkMode.TabIndex = 1;
            pictureBoxArrowClickDarkMode.TabStop = false;
            pictureBoxArrowClickDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorArrowClickDarkMode
            // 
            textBoxColorArrowClickDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowClickDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowClickDarkMode.MaxLength = 12;
            textBoxColorArrowClickDarkMode.Name = "textBoxColorArrowClickDarkMode";
            textBoxColorArrowClickDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowClickDarkMode.TabIndex = 2;
            textBoxColorArrowClickDarkMode.Text = "#ffffff";
            textBoxColorArrowClickDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowClickDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowClickDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeArrowClick
            // 
            labelColorDarkModeArrowClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeArrowClick.AutoSize = true;
            labelColorDarkModeArrowClick.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeArrowClick.Name = "labelColorDarkModeArrowClick";
            labelColorDarkModeArrowClick.Size = new System.Drawing.Size(174, 15);
            labelColorDarkModeArrowClick.TabIndex = 0;
            labelColorDarkModeArrowClick.Text = "labelColorDarkModeArrowClick";
            // 
            // tableLayoutPanelArrowClickBackgroundDarkMode
            // 
            tableLayoutPanelArrowClickBackgroundDarkMode.AutoSize = true;
            tableLayoutPanelArrowClickBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowClickBackgroundDarkMode.ColumnCount = 3;
            tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(pictureBoxArrowClickBackgroundDarkMode, 0, 0);
            tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(textBoxColorArrowClickBackgroundDarkMode, 1, 0);
            tableLayoutPanelArrowClickBackgroundDarkMode.Controls.Add(labelColorDarkModeArrowClickBackground, 2, 0);
            tableLayoutPanelArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(3, 468);
            tableLayoutPanelArrowClickBackgroundDarkMode.Name = "tableLayoutPanelArrowClickBackgroundDarkMode";
            tableLayoutPanelArrowClickBackgroundDarkMode.RowCount = 1;
            tableLayoutPanelArrowClickBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(336, 23);
            tableLayoutPanelArrowClickBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackgroundDarkMode
            // 
            pictureBoxArrowClickBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxArrowClickBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowClickBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowClickBackgroundDarkMode.Name = "pictureBoxArrowClickBackgroundDarkMode";
            pictureBoxArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowClickBackgroundDarkMode.TabIndex = 1;
            pictureBoxArrowClickBackgroundDarkMode.TabStop = false;
            pictureBoxArrowClickBackgroundDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorArrowClickBackgroundDarkMode
            // 
            textBoxColorArrowClickBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowClickBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowClickBackgroundDarkMode.MaxLength = 12;
            textBoxColorArrowClickBackgroundDarkMode.Name = "textBoxColorArrowClickBackgroundDarkMode";
            textBoxColorArrowClickBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowClickBackgroundDarkMode.TabIndex = 2;
            textBoxColorArrowClickBackgroundDarkMode.Text = "#ffffff";
            textBoxColorArrowClickBackgroundDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowClickBackgroundDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowClickBackgroundDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeArrowClickBackground
            // 
            labelColorDarkModeArrowClickBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeArrowClickBackground.AutoSize = true;
            labelColorDarkModeArrowClickBackground.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeArrowClickBackground.Name = "labelColorDarkModeArrowClickBackground";
            labelColorDarkModeArrowClickBackground.Size = new System.Drawing.Size(238, 15);
            labelColorDarkModeArrowClickBackground.TabIndex = 0;
            labelColorDarkModeArrowClickBackground.Text = "labelColorDarkModeArrowClickBackground";
            // 
            // tableLayoutPanelArrowHoverDarkMode
            // 
            tableLayoutPanelArrowHoverDarkMode.AutoSize = true;
            tableLayoutPanelArrowHoverDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowHoverDarkMode.ColumnCount = 3;
            tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowHoverDarkMode.Controls.Add(pictureBoxArrowHoverDarkMode, 0, 0);
            tableLayoutPanelArrowHoverDarkMode.Controls.Add(textBoxColorArrowHoverDarkMode, 1, 0);
            tableLayoutPanelArrowHoverDarkMode.Controls.Add(labelColorDarkModeArrowHover, 2, 0);
            tableLayoutPanelArrowHoverDarkMode.Location = new System.Drawing.Point(3, 497);
            tableLayoutPanelArrowHoverDarkMode.Name = "tableLayoutPanelArrowHoverDarkMode";
            tableLayoutPanelArrowHoverDarkMode.RowCount = 1;
            tableLayoutPanelArrowHoverDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowHoverDarkMode.Size = new System.Drawing.Size(278, 23);
            tableLayoutPanelArrowHoverDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowHoverDarkMode
            // 
            pictureBoxArrowHoverDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxArrowHoverDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowHoverDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowHoverDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowHoverDarkMode.Name = "pictureBoxArrowHoverDarkMode";
            pictureBoxArrowHoverDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowHoverDarkMode.TabIndex = 1;
            pictureBoxArrowHoverDarkMode.TabStop = false;
            pictureBoxArrowHoverDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorArrowHoverDarkMode
            // 
            textBoxColorArrowHoverDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowHoverDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowHoverDarkMode.MaxLength = 12;
            textBoxColorArrowHoverDarkMode.Name = "textBoxColorArrowHoverDarkMode";
            textBoxColorArrowHoverDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowHoverDarkMode.TabIndex = 2;
            textBoxColorArrowHoverDarkMode.Text = "#ffffff";
            textBoxColorArrowHoverDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowHoverDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowHoverDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeArrowHover
            // 
            labelColorDarkModeArrowHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeArrowHover.AutoSize = true;
            labelColorDarkModeArrowHover.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeArrowHover.Name = "labelColorDarkModeArrowHover";
            labelColorDarkModeArrowHover.Size = new System.Drawing.Size(180, 15);
            labelColorDarkModeArrowHover.TabIndex = 0;
            labelColorDarkModeArrowHover.Text = "labelColorDarkModeArrowHover";
            // 
            // tableLayoutPanelArrowHoverBackgroundDarkMode
            // 
            tableLayoutPanelArrowHoverBackgroundDarkMode.AutoSize = true;
            tableLayoutPanelArrowHoverBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnCount = 3;
            tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(pictureBoxArrowHoverBackgroundDarkMode, 0, 0);
            tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(textBoxColorArrowHoverBackgroundDarkMode, 1, 0);
            tableLayoutPanelArrowHoverBackgroundDarkMode.Controls.Add(labelColorDarkModeArrowHoverBackground, 2, 0);
            tableLayoutPanelArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(3, 526);
            tableLayoutPanelArrowHoverBackgroundDarkMode.Name = "tableLayoutPanelArrowHoverBackgroundDarkMode";
            tableLayoutPanelArrowHoverBackgroundDarkMode.RowCount = 1;
            tableLayoutPanelArrowHoverBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(342, 23);
            tableLayoutPanelArrowHoverBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackgroundDarkMode
            // 
            pictureBoxArrowHoverBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxArrowHoverBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowHoverBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowHoverBackgroundDarkMode.Name = "pictureBoxArrowHoverBackgroundDarkMode";
            pictureBoxArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowHoverBackgroundDarkMode.TabIndex = 1;
            pictureBoxArrowHoverBackgroundDarkMode.TabStop = false;
            pictureBoxArrowHoverBackgroundDarkMode.Click += PictureBoxClick;
            // 
            // textBoxColorArrowHoverBackgroundDarkMode
            // 
            textBoxColorArrowHoverBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowHoverBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowHoverBackgroundDarkMode.MaxLength = 12;
            textBoxColorArrowHoverBackgroundDarkMode.Name = "textBoxColorArrowHoverBackgroundDarkMode";
            textBoxColorArrowHoverBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowHoverBackgroundDarkMode.TabIndex = 2;
            textBoxColorArrowHoverBackgroundDarkMode.Text = "#ffffff";
            textBoxColorArrowHoverBackgroundDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowHoverBackgroundDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowHoverBackgroundDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelColorDarkModeArrowHoverBackground
            // 
            labelColorDarkModeArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelColorDarkModeArrowHoverBackground.AutoSize = true;
            labelColorDarkModeArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            labelColorDarkModeArrowHoverBackground.MaximumSize = new System.Drawing.Size(280, 0);
            labelColorDarkModeArrowHoverBackground.Name = "labelColorDarkModeArrowHoverBackground";
            labelColorDarkModeArrowHoverBackground.Size = new System.Drawing.Size(244, 15);
            labelColorDarkModeArrowHoverBackground.TabIndex = 0;
            labelColorDarkModeArrowHoverBackground.Text = "labelColorDarkModeArrowHoverBackground";
            // 
            // buttonColorsDefaultDarkMode
            // 
            buttonColorsDefaultDarkMode.AutoSize = true;
            buttonColorsDefaultDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonColorsDefaultDarkMode.Location = new System.Drawing.Point(3, 555);
            buttonColorsDefaultDarkMode.MinimumSize = new System.Drawing.Size(75, 23);
            buttonColorsDefaultDarkMode.Name = "buttonColorsDefaultDarkMode";
            buttonColorsDefaultDarkMode.Size = new System.Drawing.Size(180, 25);
            buttonColorsDefaultDarkMode.TabIndex = 2;
            buttonColorsDefaultDarkMode.Text = "buttonColorsDarkModeDefault";
            buttonColorsDefaultDarkMode.UseVisualStyleBackColor = true;
            buttonColorsDefaultDarkMode.Click += ButtonDefaultColorsDark_Click;
            // 
            // tableLayoutPanelBackgroundDarkMode
            // 
            tableLayoutPanelBackgroundDarkMode.AutoSize = true;
            tableLayoutPanelBackgroundDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBackgroundDarkMode.ColumnCount = 3;
            tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackgroundDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelBackgroundDarkMode.Controls.Add(pictureBoxBackgroundDarkMode, 0, 0);
            tableLayoutPanelBackgroundDarkMode.Controls.Add(labelBackgroundDarkMode, 2, 0);
            tableLayoutPanelBackgroundDarkMode.Controls.Add(textBoxColorBackgroundDarkMode, 1, 0);
            tableLayoutPanelBackgroundDarkMode.Location = new System.Drawing.Point(3, 47);
            tableLayoutPanelBackgroundDarkMode.Name = "tableLayoutPanelBackgroundDarkMode";
            tableLayoutPanelBackgroundDarkMode.RowCount = 1;
            tableLayoutPanelBackgroundDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelBackgroundDarkMode.Size = new System.Drawing.Size(249, 23);
            tableLayoutPanelBackgroundDarkMode.TabIndex = 2;
            // 
            // pictureBoxBackgroundDarkMode
            // 
            pictureBoxBackgroundDarkMode.BackColor = System.Drawing.Color.White;
            pictureBoxBackgroundDarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxBackgroundDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxBackgroundDarkMode.Location = new System.Drawing.Point(0, 0);
            pictureBoxBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxBackgroundDarkMode.Name = "pictureBoxBackgroundDarkMode";
            pictureBoxBackgroundDarkMode.Size = new System.Drawing.Size(23, 23);
            pictureBoxBackgroundDarkMode.TabIndex = 1;
            pictureBoxBackgroundDarkMode.TabStop = false;
            pictureBoxBackgroundDarkMode.Click += PictureBoxClick;
            // 
            // labelBackgroundDarkMode
            // 
            labelBackgroundDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelBackgroundDarkMode.AutoSize = true;
            labelBackgroundDarkMode.Location = new System.Drawing.Point(95, 4);
            labelBackgroundDarkMode.Name = "labelBackgroundDarkMode";
            labelBackgroundDarkMode.Size = new System.Drawing.Size(151, 15);
            labelBackgroundDarkMode.TabIndex = 0;
            labelBackgroundDarkMode.Text = "labelBackgroundDarkMode";
            // 
            // textBoxColorBackgroundDarkMode
            // 
            textBoxColorBackgroundDarkMode.Location = new System.Drawing.Point(23, 0);
            textBoxColorBackgroundDarkMode.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorBackgroundDarkMode.MaxLength = 12;
            textBoxColorBackgroundDarkMode.Name = "textBoxColorBackgroundDarkMode";
            textBoxColorBackgroundDarkMode.Size = new System.Drawing.Size(69, 23);
            textBoxColorBackgroundDarkMode.TabIndex = 2;
            textBoxColorBackgroundDarkMode.Text = "#ffffff";
            textBoxColorBackgroundDarkMode.TextChanged += TextBoxColorsChanged;
            textBoxColorBackgroundDarkMode.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorBackgroundDarkMode.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // groupBoxColorsLightMode
            // 
            groupBoxColorsLightMode.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxColorsLightMode.AutoSize = true;
            groupBoxColorsLightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxColorsLightMode.Controls.Add(tableLayoutPanelColorsAndDefault);
            groupBoxColorsLightMode.Location = new System.Drawing.Point(3, 362);
            groupBoxColorsLightMode.Name = "groupBoxColorsLightMode";
            groupBoxColorsLightMode.Size = new System.Drawing.Size(373, 605);
            groupBoxColorsLightMode.TabIndex = 0;
            groupBoxColorsLightMode.TabStop = false;
            groupBoxColorsLightMode.Text = "groupBoxColorsLightMode";
            // 
            // tableLayoutPanelColorsAndDefault
            // 
            tableLayoutPanelColorsAndDefault.AutoSize = true;
            tableLayoutPanelColorsAndDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelColorsAndDefault.ColumnCount = 1;
            tableLayoutPanelColorsAndDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelIcons, 0, 1);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelBackgroundBorder, 0, 3);
            tableLayoutPanelColorsAndDefault.Controls.Add(labelMenuLightMode, 0, 0);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelBackground, 0, 2);
            tableLayoutPanelColorsAndDefault.Controls.Add(buttonColorsDefault, 0, 20);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelArrowHoverBackground, 0, 19);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelArrowHover, 0, 18);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelArrowClickBackground, 0, 17);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelArrowClick, 0, 16);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelArrow, 0, 15);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSliderArrowsAndTrackHover, 0, 14);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSliderHover, 0, 13);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSliderDragging, 0, 12);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSlider, 0, 11);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelScrollbarBackground, 0, 10);
            tableLayoutPanelColorsAndDefault.Controls.Add(labelScrollbarLightMode, 0, 9);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSelectedItemBorder, 0, 8);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSelectedItem, 0, 7);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelOpenFolderBorder, 0, 6);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelOpenFolder, 0, 5);
            tableLayoutPanelColorsAndDefault.Controls.Add(tableLayoutPanelSearchField, 0, 4);
            tableLayoutPanelColorsAndDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelColorsAndDefault.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelColorsAndDefault.Name = "tableLayoutPanelColorsAndDefault";
            tableLayoutPanelColorsAndDefault.RowCount = 21;
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelColorsAndDefault.Size = new System.Drawing.Size(367, 583);
            tableLayoutPanelColorsAndDefault.TabIndex = 0;
            // 
            // tableLayoutPanelIcons
            // 
            tableLayoutPanelIcons.AutoSize = true;
            tableLayoutPanelIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelIcons.ColumnCount = 3;
            tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelIcons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelIcons.Controls.Add(pictureBoxIcons, 0, 0);
            tableLayoutPanelIcons.Controls.Add(textBoxColorIcons, 1, 0);
            tableLayoutPanelIcons.Controls.Add(labelIcons, 2, 0);
            tableLayoutPanelIcons.Location = new System.Drawing.Point(3, 18);
            tableLayoutPanelIcons.Name = "tableLayoutPanelIcons";
            tableLayoutPanelIcons.RowCount = 1;
            tableLayoutPanelIcons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelIcons.Size = new System.Drawing.Size(158, 23);
            tableLayoutPanelIcons.TabIndex = 2;
            // 
            // pictureBoxIcons
            // 
            pictureBoxIcons.BackColor = System.Drawing.Color.White;
            pictureBoxIcons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxIcons.Location = new System.Drawing.Point(0, 0);
            pictureBoxIcons.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxIcons.Name = "pictureBoxIcons";
            pictureBoxIcons.Size = new System.Drawing.Size(23, 23);
            pictureBoxIcons.TabIndex = 1;
            pictureBoxIcons.TabStop = false;
            pictureBoxIcons.Click += PictureBoxClick;
            // 
            // textBoxColorIcons
            // 
            textBoxColorIcons.Location = new System.Drawing.Point(23, 0);
            textBoxColorIcons.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorIcons.MaxLength = 12;
            textBoxColorIcons.Name = "textBoxColorIcons";
            textBoxColorIcons.Size = new System.Drawing.Size(69, 23);
            textBoxColorIcons.TabIndex = 2;
            textBoxColorIcons.Text = "#ffffff";
            textBoxColorIcons.TextChanged += TextBoxColorsChanged;
            textBoxColorIcons.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorIcons.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelIcons
            // 
            labelIcons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelIcons.AutoSize = true;
            labelIcons.Location = new System.Drawing.Point(95, 4);
            labelIcons.Name = "labelIcons";
            labelIcons.Size = new System.Drawing.Size(60, 15);
            labelIcons.TabIndex = 0;
            labelIcons.Text = "labelIcons";
            // 
            // tableLayoutPanelBackgroundBorder
            // 
            tableLayoutPanelBackgroundBorder.AutoSize = true;
            tableLayoutPanelBackgroundBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBackgroundBorder.ColumnCount = 3;
            tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackgroundBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelBackgroundBorder.Controls.Add(pictureBoxBackgroundBorder, 0, 0);
            tableLayoutPanelBackgroundBorder.Controls.Add(textBoxColorBackgroundBorder, 1, 0);
            tableLayoutPanelBackgroundBorder.Controls.Add(labelBackgroundBorder, 2, 0);
            tableLayoutPanelBackgroundBorder.Location = new System.Drawing.Point(3, 76);
            tableLayoutPanelBackgroundBorder.Name = "tableLayoutPanelBackgroundBorder";
            tableLayoutPanelBackgroundBorder.RowCount = 1;
            tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelBackgroundBorder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanelBackgroundBorder.Size = new System.Drawing.Size(229, 23);
            tableLayoutPanelBackgroundBorder.TabIndex = 2;
            // 
            // pictureBoxBackgroundBorder
            // 
            pictureBoxBackgroundBorder.BackColor = System.Drawing.Color.White;
            pictureBoxBackgroundBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxBackgroundBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxBackgroundBorder.Location = new System.Drawing.Point(0, 0);
            pictureBoxBackgroundBorder.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxBackgroundBorder.Name = "pictureBoxBackgroundBorder";
            pictureBoxBackgroundBorder.Size = new System.Drawing.Size(23, 23);
            pictureBoxBackgroundBorder.TabIndex = 1;
            pictureBoxBackgroundBorder.TabStop = false;
            pictureBoxBackgroundBorder.Click += PictureBoxClick;
            // 
            // textBoxColorBackgroundBorder
            // 
            textBoxColorBackgroundBorder.Location = new System.Drawing.Point(23, 0);
            textBoxColorBackgroundBorder.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorBackgroundBorder.MaxLength = 12;
            textBoxColorBackgroundBorder.Name = "textBoxColorBackgroundBorder";
            textBoxColorBackgroundBorder.Size = new System.Drawing.Size(69, 23);
            textBoxColorBackgroundBorder.TabIndex = 2;
            textBoxColorBackgroundBorder.Text = "#ffffff";
            textBoxColorBackgroundBorder.TextChanged += TextBoxColorsChanged;
            textBoxColorBackgroundBorder.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorBackgroundBorder.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelBackgroundBorder
            // 
            labelBackgroundBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelBackgroundBorder.AutoSize = true;
            labelBackgroundBorder.Location = new System.Drawing.Point(95, 4);
            labelBackgroundBorder.Name = "labelBackgroundBorder";
            labelBackgroundBorder.Size = new System.Drawing.Size(131, 15);
            labelBackgroundBorder.TabIndex = 0;
            labelBackgroundBorder.Text = "labelBackgroundBorder";
            // 
            // labelMenuLightMode
            // 
            labelMenuLightMode.AutoSize = true;
            labelMenuLightMode.Location = new System.Drawing.Point(3, 0);
            labelMenuLightMode.Name = "labelMenuLightMode";
            labelMenuLightMode.Size = new System.Drawing.Size(121, 15);
            labelMenuLightMode.TabIndex = 3;
            labelMenuLightMode.Text = "labelMenuLightMode";
            // 
            // tableLayoutPanelBackground
            // 
            tableLayoutPanelBackground.AutoSize = true;
            tableLayoutPanelBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBackground.ColumnCount = 3;
            tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelBackground.Controls.Add(pictureBoxBackground, 0, 0);
            tableLayoutPanelBackground.Controls.Add(textBoxColorBackground, 1, 0);
            tableLayoutPanelBackground.Controls.Add(labelBackground, 2, 0);
            tableLayoutPanelBackground.Location = new System.Drawing.Point(3, 47);
            tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            tableLayoutPanelBackground.RowCount = 1;
            tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanelBackground.Size = new System.Drawing.Size(194, 23);
            tableLayoutPanelBackground.TabIndex = 2;
            // 
            // pictureBoxBackground
            // 
            pictureBoxBackground.BackColor = System.Drawing.Color.White;
            pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            pictureBoxBackground.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxBackground.Name = "pictureBoxBackground";
            pictureBoxBackground.Size = new System.Drawing.Size(23, 23);
            pictureBoxBackground.TabIndex = 1;
            pictureBoxBackground.TabStop = false;
            pictureBoxBackground.Click += PictureBoxClick;
            // 
            // textBoxColorBackground
            // 
            textBoxColorBackground.Location = new System.Drawing.Point(23, 0);
            textBoxColorBackground.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorBackground.MaxLength = 12;
            textBoxColorBackground.Name = "textBoxColorBackground";
            textBoxColorBackground.Size = new System.Drawing.Size(69, 23);
            textBoxColorBackground.TabIndex = 2;
            textBoxColorBackground.Text = "#ffffff";
            textBoxColorBackground.TextChanged += TextBoxColorsChanged;
            textBoxColorBackground.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorBackground.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelBackground
            // 
            labelBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelBackground.AutoSize = true;
            labelBackground.Location = new System.Drawing.Point(95, 4);
            labelBackground.Name = "labelBackground";
            labelBackground.Size = new System.Drawing.Size(96, 15);
            labelBackground.TabIndex = 0;
            labelBackground.Text = "labelBackground";
            // 
            // buttonColorsDefault
            // 
            buttonColorsDefault.AutoSize = true;
            buttonColorsDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonColorsDefault.Location = new System.Drawing.Point(3, 555);
            buttonColorsDefault.MinimumSize = new System.Drawing.Size(75, 23);
            buttonColorsDefault.Name = "buttonColorsDefault";
            buttonColorsDefault.Size = new System.Drawing.Size(125, 25);
            buttonColorsDefault.TabIndex = 2;
            buttonColorsDefault.Text = "buttonColorsDefault";
            buttonColorsDefault.UseVisualStyleBackColor = true;
            buttonColorsDefault.Click += ButtonDefaultColors_Click;
            // 
            // tableLayoutPanelArrowHoverBackground
            // 
            tableLayoutPanelArrowHoverBackground.AutoSize = true;
            tableLayoutPanelArrowHoverBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowHoverBackground.ColumnCount = 3;
            tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHoverBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowHoverBackground.Controls.Add(pictureBoxArrowHoverBackground, 0, 0);
            tableLayoutPanelArrowHoverBackground.Controls.Add(textBoxColorArrowHoverBackground, 1, 0);
            tableLayoutPanelArrowHoverBackground.Controls.Add(labelArrowHoverBackground, 2, 0);
            tableLayoutPanelArrowHoverBackground.Location = new System.Drawing.Point(3, 526);
            tableLayoutPanelArrowHoverBackground.Name = "tableLayoutPanelArrowHoverBackground";
            tableLayoutPanelArrowHoverBackground.RowCount = 1;
            tableLayoutPanelArrowHoverBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowHoverBackground.Size = new System.Drawing.Size(258, 23);
            tableLayoutPanelArrowHoverBackground.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackground
            // 
            pictureBoxArrowHoverBackground.BackColor = System.Drawing.Color.White;
            pictureBoxArrowHoverBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowHoverBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowHoverBackground.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowHoverBackground.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowHoverBackground.Name = "pictureBoxArrowHoverBackground";
            pictureBoxArrowHoverBackground.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowHoverBackground.TabIndex = 1;
            pictureBoxArrowHoverBackground.TabStop = false;
            pictureBoxArrowHoverBackground.Click += PictureBoxClick;
            // 
            // textBoxColorArrowHoverBackground
            // 
            textBoxColorArrowHoverBackground.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowHoverBackground.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowHoverBackground.MaxLength = 12;
            textBoxColorArrowHoverBackground.Name = "textBoxColorArrowHoverBackground";
            textBoxColorArrowHoverBackground.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowHoverBackground.TabIndex = 2;
            textBoxColorArrowHoverBackground.Text = "#ffffff";
            textBoxColorArrowHoverBackground.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowHoverBackground.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowHoverBackground.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelArrowHoverBackground
            // 
            labelArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelArrowHoverBackground.AutoSize = true;
            labelArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            labelArrowHoverBackground.MaximumSize = new System.Drawing.Size(280, 0);
            labelArrowHoverBackground.Name = "labelArrowHoverBackground";
            labelArrowHoverBackground.Size = new System.Drawing.Size(160, 15);
            labelArrowHoverBackground.TabIndex = 0;
            labelArrowHoverBackground.Text = "labelArrowHoverBackground";
            // 
            // tableLayoutPanelArrowHover
            // 
            tableLayoutPanelArrowHover.AutoSize = true;
            tableLayoutPanelArrowHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowHover.ColumnCount = 3;
            tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowHover.Controls.Add(pictureBoxArrowHover, 0, 0);
            tableLayoutPanelArrowHover.Controls.Add(textBoxColorArrowHover, 1, 0);
            tableLayoutPanelArrowHover.Controls.Add(labelArrowHover, 2, 0);
            tableLayoutPanelArrowHover.Location = new System.Drawing.Point(3, 497);
            tableLayoutPanelArrowHover.Name = "tableLayoutPanelArrowHover";
            tableLayoutPanelArrowHover.RowCount = 1;
            tableLayoutPanelArrowHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowHover.Size = new System.Drawing.Size(194, 23);
            tableLayoutPanelArrowHover.TabIndex = 2;
            // 
            // pictureBoxArrowHover
            // 
            pictureBoxArrowHover.BackColor = System.Drawing.Color.White;
            pictureBoxArrowHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowHover.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowHover.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowHover.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowHover.Name = "pictureBoxArrowHover";
            pictureBoxArrowHover.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowHover.TabIndex = 1;
            pictureBoxArrowHover.TabStop = false;
            pictureBoxArrowHover.Click += PictureBoxClick;
            // 
            // textBoxColorArrowHover
            // 
            textBoxColorArrowHover.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowHover.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowHover.MaxLength = 12;
            textBoxColorArrowHover.Name = "textBoxColorArrowHover";
            textBoxColorArrowHover.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowHover.TabIndex = 2;
            textBoxColorArrowHover.Text = "#ffffff";
            textBoxColorArrowHover.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowHover.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowHover.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelArrowHover
            // 
            labelArrowHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelArrowHover.AutoSize = true;
            labelArrowHover.Location = new System.Drawing.Point(95, 4);
            labelArrowHover.Name = "labelArrowHover";
            labelArrowHover.Size = new System.Drawing.Size(96, 15);
            labelArrowHover.TabIndex = 0;
            labelArrowHover.Text = "labelArrowHover";
            // 
            // tableLayoutPanelArrowClickBackground
            // 
            tableLayoutPanelArrowClickBackground.AutoSize = true;
            tableLayoutPanelArrowClickBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowClickBackground.ColumnCount = 3;
            tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClickBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowClickBackground.Controls.Add(pictureBoxArrowClickBackground, 0, 0);
            tableLayoutPanelArrowClickBackground.Controls.Add(textBoxColorArrowClickBackground, 1, 0);
            tableLayoutPanelArrowClickBackground.Controls.Add(labelArrowClickBackground, 2, 0);
            tableLayoutPanelArrowClickBackground.Location = new System.Drawing.Point(3, 468);
            tableLayoutPanelArrowClickBackground.Name = "tableLayoutPanelArrowClickBackground";
            tableLayoutPanelArrowClickBackground.RowCount = 1;
            tableLayoutPanelArrowClickBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowClickBackground.Size = new System.Drawing.Size(252, 23);
            tableLayoutPanelArrowClickBackground.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackground
            // 
            pictureBoxArrowClickBackground.BackColor = System.Drawing.Color.White;
            pictureBoxArrowClickBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowClickBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowClickBackground.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowClickBackground.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowClickBackground.Name = "pictureBoxArrowClickBackground";
            pictureBoxArrowClickBackground.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowClickBackground.TabIndex = 1;
            pictureBoxArrowClickBackground.TabStop = false;
            pictureBoxArrowClickBackground.Click += PictureBoxClick;
            // 
            // textBoxColorArrowClickBackground
            // 
            textBoxColorArrowClickBackground.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowClickBackground.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowClickBackground.MaxLength = 12;
            textBoxColorArrowClickBackground.Name = "textBoxColorArrowClickBackground";
            textBoxColorArrowClickBackground.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowClickBackground.TabIndex = 2;
            textBoxColorArrowClickBackground.Text = "#ffffff";
            textBoxColorArrowClickBackground.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowClickBackground.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowClickBackground.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelArrowClickBackground
            // 
            labelArrowClickBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelArrowClickBackground.AutoSize = true;
            labelArrowClickBackground.Location = new System.Drawing.Point(95, 4);
            labelArrowClickBackground.Name = "labelArrowClickBackground";
            labelArrowClickBackground.Size = new System.Drawing.Size(154, 15);
            labelArrowClickBackground.TabIndex = 0;
            labelArrowClickBackground.Text = "labelArrowClickBackground";
            // 
            // tableLayoutPanelArrowClick
            // 
            tableLayoutPanelArrowClick.AutoSize = true;
            tableLayoutPanelArrowClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrowClick.ColumnCount = 3;
            tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrowClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrowClick.Controls.Add(pictureBoxArrowClick, 0, 0);
            tableLayoutPanelArrowClick.Controls.Add(textBoxColorArrowClick, 1, 0);
            tableLayoutPanelArrowClick.Controls.Add(labelArrowClick, 2, 0);
            tableLayoutPanelArrowClick.Location = new System.Drawing.Point(3, 439);
            tableLayoutPanelArrowClick.Name = "tableLayoutPanelArrowClick";
            tableLayoutPanelArrowClick.RowCount = 1;
            tableLayoutPanelArrowClick.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrowClick.Size = new System.Drawing.Size(188, 23);
            tableLayoutPanelArrowClick.TabIndex = 2;
            // 
            // pictureBoxArrowClick
            // 
            pictureBoxArrowClick.BackColor = System.Drawing.Color.White;
            pictureBoxArrowClick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrowClick.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrowClick.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrowClick.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrowClick.Name = "pictureBoxArrowClick";
            pictureBoxArrowClick.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrowClick.TabIndex = 1;
            pictureBoxArrowClick.TabStop = false;
            pictureBoxArrowClick.Click += PictureBoxClick;
            // 
            // textBoxColorArrowClick
            // 
            textBoxColorArrowClick.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrowClick.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrowClick.MaxLength = 12;
            textBoxColorArrowClick.Name = "textBoxColorArrowClick";
            textBoxColorArrowClick.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrowClick.TabIndex = 2;
            textBoxColorArrowClick.Text = "#ffffff";
            textBoxColorArrowClick.TextChanged += TextBoxColorsChanged;
            textBoxColorArrowClick.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrowClick.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelArrowClick
            // 
            labelArrowClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelArrowClick.AutoSize = true;
            labelArrowClick.Location = new System.Drawing.Point(95, 4);
            labelArrowClick.Name = "labelArrowClick";
            labelArrowClick.Size = new System.Drawing.Size(90, 15);
            labelArrowClick.TabIndex = 0;
            labelArrowClick.Text = "labelArrowClick";
            // 
            // tableLayoutPanelArrow
            // 
            tableLayoutPanelArrow.AutoSize = true;
            tableLayoutPanelArrow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelArrow.ColumnCount = 3;
            tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelArrow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelArrow.Controls.Add(pictureBoxArrow, 0, 0);
            tableLayoutPanelArrow.Controls.Add(textBoxColorArrow, 1, 0);
            tableLayoutPanelArrow.Controls.Add(labelArrow, 2, 0);
            tableLayoutPanelArrow.Location = new System.Drawing.Point(3, 410);
            tableLayoutPanelArrow.Name = "tableLayoutPanelArrow";
            tableLayoutPanelArrow.RowCount = 1;
            tableLayoutPanelArrow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelArrow.Size = new System.Drawing.Size(162, 23);
            tableLayoutPanelArrow.TabIndex = 2;
            // 
            // pictureBoxArrow
            // 
            pictureBoxArrow.BackColor = System.Drawing.Color.White;
            pictureBoxArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxArrow.Location = new System.Drawing.Point(0, 0);
            pictureBoxArrow.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxArrow.Name = "pictureBoxArrow";
            pictureBoxArrow.Size = new System.Drawing.Size(23, 23);
            pictureBoxArrow.TabIndex = 1;
            pictureBoxArrow.TabStop = false;
            pictureBoxArrow.Click += PictureBoxClick;
            // 
            // textBoxColorArrow
            // 
            textBoxColorArrow.Location = new System.Drawing.Point(23, 0);
            textBoxColorArrow.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorArrow.MaxLength = 12;
            textBoxColorArrow.Name = "textBoxColorArrow";
            textBoxColorArrow.Size = new System.Drawing.Size(69, 23);
            textBoxColorArrow.TabIndex = 2;
            textBoxColorArrow.Text = "#ffffff";
            textBoxColorArrow.TextChanged += TextBoxColorsChanged;
            textBoxColorArrow.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorArrow.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelArrow
            // 
            labelArrow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelArrow.AutoSize = true;
            labelArrow.Location = new System.Drawing.Point(95, 4);
            labelArrow.Name = "labelArrow";
            labelArrow.Size = new System.Drawing.Size(64, 15);
            labelArrow.TabIndex = 0;
            labelArrow.Text = "labelArrow";
            // 
            // tableLayoutPanelSliderArrowsAndTrackHover
            // 
            tableLayoutPanelSliderArrowsAndTrackHover.AutoSize = true;
            tableLayoutPanelSliderArrowsAndTrackHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderArrowsAndTrackHover.ColumnCount = 3;
            tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderArrowsAndTrackHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(pictureBoxSliderArrowsAndTrackHover, 0, 0);
            tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(textBoxColorSliderArrowsAndTrackHover, 1, 0);
            tableLayoutPanelSliderArrowsAndTrackHover.Controls.Add(labelSliderArrowsAndTrackHover, 2, 0);
            tableLayoutPanelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(3, 381);
            tableLayoutPanelSliderArrowsAndTrackHover.Name = "tableLayoutPanelSliderArrowsAndTrackHover";
            tableLayoutPanelSliderArrowsAndTrackHover.RowCount = 1;
            tableLayoutPanelSliderArrowsAndTrackHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(277, 23);
            tableLayoutPanelSliderArrowsAndTrackHover.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHover
            // 
            pictureBoxSliderArrowsAndTrackHover.BackColor = System.Drawing.Color.White;
            pictureBoxSliderArrowsAndTrackHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderArrowsAndTrackHover.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderArrowsAndTrackHover.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderArrowsAndTrackHover.Name = "pictureBoxSliderArrowsAndTrackHover";
            pictureBoxSliderArrowsAndTrackHover.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderArrowsAndTrackHover.TabIndex = 1;
            pictureBoxSliderArrowsAndTrackHover.TabStop = false;
            pictureBoxSliderArrowsAndTrackHover.Click += PictureBoxClick;
            // 
            // textBoxColorSliderArrowsAndTrackHover
            // 
            textBoxColorSliderArrowsAndTrackHover.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderArrowsAndTrackHover.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderArrowsAndTrackHover.MaxLength = 12;
            textBoxColorSliderArrowsAndTrackHover.Name = "textBoxColorSliderArrowsAndTrackHover";
            textBoxColorSliderArrowsAndTrackHover.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderArrowsAndTrackHover.TabIndex = 2;
            textBoxColorSliderArrowsAndTrackHover.Text = "#ffffff";
            textBoxColorSliderArrowsAndTrackHover.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderArrowsAndTrackHover.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderArrowsAndTrackHover.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSliderArrowsAndTrackHover
            // 
            labelSliderArrowsAndTrackHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSliderArrowsAndTrackHover.AutoSize = true;
            labelSliderArrowsAndTrackHover.Location = new System.Drawing.Point(95, 4);
            labelSliderArrowsAndTrackHover.Name = "labelSliderArrowsAndTrackHover";
            labelSliderArrowsAndTrackHover.Size = new System.Drawing.Size(179, 15);
            labelSliderArrowsAndTrackHover.TabIndex = 0;
            labelSliderArrowsAndTrackHover.Text = "labelSliderArrowsAndTrackHover";
            // 
            // tableLayoutPanelSliderHover
            // 
            tableLayoutPanelSliderHover.AutoSize = true;
            tableLayoutPanelSliderHover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderHover.ColumnCount = 3;
            tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderHover.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderHover.Controls.Add(pictureBoxSliderHover, 0, 0);
            tableLayoutPanelSliderHover.Controls.Add(textBoxColorSliderHover, 1, 0);
            tableLayoutPanelSliderHover.Controls.Add(labelSliderHover, 2, 0);
            tableLayoutPanelSliderHover.Location = new System.Drawing.Point(3, 352);
            tableLayoutPanelSliderHover.Name = "tableLayoutPanelSliderHover";
            tableLayoutPanelSliderHover.RowCount = 1;
            tableLayoutPanelSliderHover.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderHover.Size = new System.Drawing.Size(191, 23);
            tableLayoutPanelSliderHover.TabIndex = 2;
            // 
            // pictureBoxSliderHover
            // 
            pictureBoxSliderHover.BackColor = System.Drawing.Color.White;
            pictureBoxSliderHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderHover.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderHover.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderHover.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderHover.Name = "pictureBoxSliderHover";
            pictureBoxSliderHover.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderHover.TabIndex = 1;
            pictureBoxSliderHover.TabStop = false;
            pictureBoxSliderHover.Click += PictureBoxClick;
            // 
            // textBoxColorSliderHover
            // 
            textBoxColorSliderHover.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderHover.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderHover.MaxLength = 12;
            textBoxColorSliderHover.Name = "textBoxColorSliderHover";
            textBoxColorSliderHover.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderHover.TabIndex = 2;
            textBoxColorSliderHover.Text = "#ffffff";
            textBoxColorSliderHover.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderHover.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderHover.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSliderHover
            // 
            labelSliderHover.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSliderHover.AutoSize = true;
            labelSliderHover.Location = new System.Drawing.Point(95, 4);
            labelSliderHover.Name = "labelSliderHover";
            labelSliderHover.Size = new System.Drawing.Size(93, 15);
            labelSliderHover.TabIndex = 0;
            labelSliderHover.Text = "labelSliderHover";
            // 
            // tableLayoutPanelSliderDragging
            // 
            tableLayoutPanelSliderDragging.AutoSize = true;
            tableLayoutPanelSliderDragging.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSliderDragging.ColumnCount = 3;
            tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSliderDragging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSliderDragging.Controls.Add(pictureBoxSliderDragging, 0, 0);
            tableLayoutPanelSliderDragging.Controls.Add(textBoxColorSliderDragging, 1, 0);
            tableLayoutPanelSliderDragging.Controls.Add(labelSliderDragging, 2, 0);
            tableLayoutPanelSliderDragging.Location = new System.Drawing.Point(3, 323);
            tableLayoutPanelSliderDragging.Name = "tableLayoutPanelSliderDragging";
            tableLayoutPanelSliderDragging.RowCount = 1;
            tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSliderDragging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanelSliderDragging.Size = new System.Drawing.Size(208, 23);
            tableLayoutPanelSliderDragging.TabIndex = 2;
            // 
            // pictureBoxSliderDragging
            // 
            pictureBoxSliderDragging.BackColor = System.Drawing.Color.White;
            pictureBoxSliderDragging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSliderDragging.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSliderDragging.Location = new System.Drawing.Point(0, 0);
            pictureBoxSliderDragging.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSliderDragging.Name = "pictureBoxSliderDragging";
            pictureBoxSliderDragging.Size = new System.Drawing.Size(23, 23);
            pictureBoxSliderDragging.TabIndex = 1;
            pictureBoxSliderDragging.TabStop = false;
            pictureBoxSliderDragging.Click += PictureBoxClick;
            // 
            // textBoxColorSliderDragging
            // 
            textBoxColorSliderDragging.Location = new System.Drawing.Point(23, 0);
            textBoxColorSliderDragging.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSliderDragging.MaxLength = 12;
            textBoxColorSliderDragging.Name = "textBoxColorSliderDragging";
            textBoxColorSliderDragging.Size = new System.Drawing.Size(69, 23);
            textBoxColorSliderDragging.TabIndex = 2;
            textBoxColorSliderDragging.Text = "#ffffff";
            textBoxColorSliderDragging.TextChanged += TextBoxColorsChanged;
            textBoxColorSliderDragging.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSliderDragging.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSliderDragging
            // 
            labelSliderDragging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSliderDragging.AutoSize = true;
            labelSliderDragging.Location = new System.Drawing.Point(95, 4);
            labelSliderDragging.Name = "labelSliderDragging";
            labelSliderDragging.Size = new System.Drawing.Size(110, 15);
            labelSliderDragging.TabIndex = 0;
            labelSliderDragging.Text = "labelSliderDragging";
            // 
            // tableLayoutPanelSlider
            // 
            tableLayoutPanelSlider.AutoSize = true;
            tableLayoutPanelSlider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSlider.ColumnCount = 3;
            tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSlider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSlider.Controls.Add(pictureBoxSlider, 0, 0);
            tableLayoutPanelSlider.Controls.Add(textBoxColorSlider, 1, 0);
            tableLayoutPanelSlider.Controls.Add(labelSlider, 2, 0);
            tableLayoutPanelSlider.Location = new System.Drawing.Point(3, 294);
            tableLayoutPanelSlider.Name = "tableLayoutPanelSlider";
            tableLayoutPanelSlider.RowCount = 1;
            tableLayoutPanelSlider.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSlider.Size = new System.Drawing.Size(159, 23);
            tableLayoutPanelSlider.TabIndex = 2;
            // 
            // pictureBoxSlider
            // 
            pictureBoxSlider.BackColor = System.Drawing.Color.White;
            pictureBoxSlider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSlider.Location = new System.Drawing.Point(0, 0);
            pictureBoxSlider.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSlider.Name = "pictureBoxSlider";
            pictureBoxSlider.Size = new System.Drawing.Size(23, 23);
            pictureBoxSlider.TabIndex = 1;
            pictureBoxSlider.TabStop = false;
            pictureBoxSlider.Click += PictureBoxClick;
            // 
            // textBoxColorSlider
            // 
            textBoxColorSlider.Location = new System.Drawing.Point(23, 0);
            textBoxColorSlider.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSlider.MaxLength = 12;
            textBoxColorSlider.Name = "textBoxColorSlider";
            textBoxColorSlider.Size = new System.Drawing.Size(69, 23);
            textBoxColorSlider.TabIndex = 2;
            textBoxColorSlider.Text = "#ffffff";
            textBoxColorSlider.TextChanged += TextBoxColorsChanged;
            textBoxColorSlider.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSlider.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSlider
            // 
            labelSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSlider.AutoSize = true;
            labelSlider.Location = new System.Drawing.Point(95, 4);
            labelSlider.Name = "labelSlider";
            labelSlider.Size = new System.Drawing.Size(61, 15);
            labelSlider.TabIndex = 0;
            labelSlider.Text = "labelSlider";
            // 
            // tableLayoutPanelScrollbarBackground
            // 
            tableLayoutPanelScrollbarBackground.AutoSize = true;
            tableLayoutPanelScrollbarBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelScrollbarBackground.ColumnCount = 3;
            tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelScrollbarBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelScrollbarBackground.Controls.Add(pictureBoxScrollbarBackground, 0, 0);
            tableLayoutPanelScrollbarBackground.Controls.Add(textBoxColorScrollbarBackground, 1, 0);
            tableLayoutPanelScrollbarBackground.Controls.Add(labelScrollbarBackground, 2, 0);
            tableLayoutPanelScrollbarBackground.Location = new System.Drawing.Point(3, 265);
            tableLayoutPanelScrollbarBackground.Name = "tableLayoutPanelScrollbarBackground";
            tableLayoutPanelScrollbarBackground.RowCount = 1;
            tableLayoutPanelScrollbarBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelScrollbarBackground.Size = new System.Drawing.Size(240, 23);
            tableLayoutPanelScrollbarBackground.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackground
            // 
            pictureBoxScrollbarBackground.BackColor = System.Drawing.Color.White;
            pictureBoxScrollbarBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxScrollbarBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxScrollbarBackground.Location = new System.Drawing.Point(0, 0);
            pictureBoxScrollbarBackground.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxScrollbarBackground.Name = "pictureBoxScrollbarBackground";
            pictureBoxScrollbarBackground.Size = new System.Drawing.Size(23, 23);
            pictureBoxScrollbarBackground.TabIndex = 1;
            pictureBoxScrollbarBackground.TabStop = false;
            pictureBoxScrollbarBackground.Click += PictureBoxClick;
            // 
            // textBoxColorScrollbarBackground
            // 
            textBoxColorScrollbarBackground.Location = new System.Drawing.Point(23, 0);
            textBoxColorScrollbarBackground.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorScrollbarBackground.MaxLength = 12;
            textBoxColorScrollbarBackground.Name = "textBoxColorScrollbarBackground";
            textBoxColorScrollbarBackground.Size = new System.Drawing.Size(69, 23);
            textBoxColorScrollbarBackground.TabIndex = 2;
            textBoxColorScrollbarBackground.Text = "#ffffff";
            textBoxColorScrollbarBackground.TextChanged += TextBoxColorsChanged;
            textBoxColorScrollbarBackground.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorScrollbarBackground.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelScrollbarBackground
            // 
            labelScrollbarBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelScrollbarBackground.AutoSize = true;
            labelScrollbarBackground.Location = new System.Drawing.Point(95, 4);
            labelScrollbarBackground.Name = "labelScrollbarBackground";
            labelScrollbarBackground.Size = new System.Drawing.Size(142, 15);
            labelScrollbarBackground.TabIndex = 0;
            labelScrollbarBackground.Text = "labelScrollbarBackground";
            // 
            // labelScrollbarLightMode
            // 
            labelScrollbarLightMode.AutoSize = true;
            labelScrollbarLightMode.Location = new System.Drawing.Point(3, 247);
            labelScrollbarLightMode.Name = "labelScrollbarLightMode";
            labelScrollbarLightMode.Size = new System.Drawing.Size(136, 15);
            labelScrollbarLightMode.TabIndex = 3;
            labelScrollbarLightMode.Text = "labelScrollbarLightMode";
            // 
            // tableLayoutPanelSelectedItemBorder
            // 
            tableLayoutPanelSelectedItemBorder.AutoSize = true;
            tableLayoutPanelSelectedItemBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSelectedItemBorder.ColumnCount = 3;
            tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItemBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSelectedItemBorder.Controls.Add(pictureBoxSelectedItemBorder, 0, 0);
            tableLayoutPanelSelectedItemBorder.Controls.Add(textBoxColorSelectedItemBorder, 1, 0);
            tableLayoutPanelSelectedItemBorder.Controls.Add(labelSelectedItemBorder, 2, 0);
            tableLayoutPanelSelectedItemBorder.Location = new System.Drawing.Point(3, 221);
            tableLayoutPanelSelectedItemBorder.Name = "tableLayoutPanelSelectedItemBorder";
            tableLayoutPanelSelectedItemBorder.RowCount = 1;
            tableLayoutPanelSelectedItemBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSelectedItemBorder.Size = new System.Drawing.Size(233, 23);
            tableLayoutPanelSelectedItemBorder.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorder
            // 
            pictureBoxSelectedItemBorder.BackColor = System.Drawing.Color.White;
            pictureBoxSelectedItemBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSelectedItemBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSelectedItemBorder.Location = new System.Drawing.Point(0, 0);
            pictureBoxSelectedItemBorder.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSelectedItemBorder.Name = "pictureBoxSelectedItemBorder";
            pictureBoxSelectedItemBorder.Size = new System.Drawing.Size(23, 23);
            pictureBoxSelectedItemBorder.TabIndex = 1;
            pictureBoxSelectedItemBorder.TabStop = false;
            pictureBoxSelectedItemBorder.Click += PictureBoxClick;
            // 
            // textBoxColorSelectedItemBorder
            // 
            textBoxColorSelectedItemBorder.Location = new System.Drawing.Point(23, 0);
            textBoxColorSelectedItemBorder.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSelectedItemBorder.MaxLength = 12;
            textBoxColorSelectedItemBorder.Name = "textBoxColorSelectedItemBorder";
            textBoxColorSelectedItemBorder.Size = new System.Drawing.Size(69, 23);
            textBoxColorSelectedItemBorder.TabIndex = 2;
            textBoxColorSelectedItemBorder.Text = "#ffffff";
            textBoxColorSelectedItemBorder.TextChanged += TextBoxColorsChanged;
            textBoxColorSelectedItemBorder.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSelectedItemBorder.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSelectedItemBorder
            // 
            labelSelectedItemBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSelectedItemBorder.AutoSize = true;
            labelSelectedItemBorder.Location = new System.Drawing.Point(95, 4);
            labelSelectedItemBorder.Name = "labelSelectedItemBorder";
            labelSelectedItemBorder.Size = new System.Drawing.Size(135, 15);
            labelSelectedItemBorder.TabIndex = 0;
            labelSelectedItemBorder.Text = "labelSelectedItemBorder";
            // 
            // tableLayoutPanelSelectedItem
            // 
            tableLayoutPanelSelectedItem.AutoSize = true;
            tableLayoutPanelSelectedItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSelectedItem.ColumnCount = 3;
            tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSelectedItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSelectedItem.Controls.Add(pictureBoxSelectedItem, 0, 0);
            tableLayoutPanelSelectedItem.Controls.Add(textBoxColorSelectedItem, 1, 0);
            tableLayoutPanelSelectedItem.Controls.Add(labelSelectedItem, 2, 0);
            tableLayoutPanelSelectedItem.Location = new System.Drawing.Point(3, 192);
            tableLayoutPanelSelectedItem.Name = "tableLayoutPanelSelectedItem";
            tableLayoutPanelSelectedItem.RowCount = 1;
            tableLayoutPanelSelectedItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSelectedItem.Size = new System.Drawing.Size(198, 23);
            tableLayoutPanelSelectedItem.TabIndex = 2;
            // 
            // pictureBoxSelectedItem
            // 
            pictureBoxSelectedItem.BackColor = System.Drawing.Color.White;
            pictureBoxSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSelectedItem.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSelectedItem.Location = new System.Drawing.Point(0, 0);
            pictureBoxSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSelectedItem.Name = "pictureBoxSelectedItem";
            pictureBoxSelectedItem.Size = new System.Drawing.Size(23, 23);
            pictureBoxSelectedItem.TabIndex = 1;
            pictureBoxSelectedItem.TabStop = false;
            pictureBoxSelectedItem.Click += PictureBoxClick;
            // 
            // textBoxColorSelectedItem
            // 
            textBoxColorSelectedItem.Location = new System.Drawing.Point(23, 0);
            textBoxColorSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSelectedItem.MaxLength = 12;
            textBoxColorSelectedItem.Name = "textBoxColorSelectedItem";
            textBoxColorSelectedItem.Size = new System.Drawing.Size(69, 23);
            textBoxColorSelectedItem.TabIndex = 2;
            textBoxColorSelectedItem.Text = "#ffffff";
            textBoxColorSelectedItem.TextChanged += TextBoxColorsChanged;
            textBoxColorSelectedItem.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSelectedItem.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSelectedItem
            // 
            labelSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSelectedItem.AutoSize = true;
            labelSelectedItem.Location = new System.Drawing.Point(95, 4);
            labelSelectedItem.Name = "labelSelectedItem";
            labelSelectedItem.Size = new System.Drawing.Size(100, 15);
            labelSelectedItem.TabIndex = 0;
            labelSelectedItem.Text = "labelSelectedItem";
            // 
            // tableLayoutPanelOpenFolderBorder
            // 
            tableLayoutPanelOpenFolderBorder.AutoSize = true;
            tableLayoutPanelOpenFolderBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelOpenFolderBorder.ColumnCount = 3;
            tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolderBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelOpenFolderBorder.Controls.Add(pictureBoxOpenFolderBorder, 0, 0);
            tableLayoutPanelOpenFolderBorder.Controls.Add(textBoxColorOpenFolderBorder, 1, 0);
            tableLayoutPanelOpenFolderBorder.Controls.Add(labelOpenFolderBorder, 2, 0);
            tableLayoutPanelOpenFolderBorder.Location = new System.Drawing.Point(3, 163);
            tableLayoutPanelOpenFolderBorder.Name = "tableLayoutPanelOpenFolderBorder";
            tableLayoutPanelOpenFolderBorder.RowCount = 1;
            tableLayoutPanelOpenFolderBorder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelOpenFolderBorder.Size = new System.Drawing.Size(227, 23);
            tableLayoutPanelOpenFolderBorder.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorder
            // 
            pictureBoxOpenFolderBorder.BackColor = System.Drawing.Color.White;
            pictureBoxOpenFolderBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxOpenFolderBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxOpenFolderBorder.Location = new System.Drawing.Point(0, 0);
            pictureBoxOpenFolderBorder.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxOpenFolderBorder.Name = "pictureBoxOpenFolderBorder";
            pictureBoxOpenFolderBorder.Size = new System.Drawing.Size(23, 23);
            pictureBoxOpenFolderBorder.TabIndex = 1;
            pictureBoxOpenFolderBorder.TabStop = false;
            pictureBoxOpenFolderBorder.Click += PictureBoxClick;
            // 
            // textBoxColorOpenFolderBorder
            // 
            textBoxColorOpenFolderBorder.Location = new System.Drawing.Point(23, 0);
            textBoxColorOpenFolderBorder.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorOpenFolderBorder.Name = "textBoxColorOpenFolderBorder";
            textBoxColorOpenFolderBorder.Size = new System.Drawing.Size(69, 23);
            textBoxColorOpenFolderBorder.TabIndex = 2;
            textBoxColorOpenFolderBorder.Text = "#ffffff";
            textBoxColorOpenFolderBorder.TextChanged += TextBoxColorsChanged;
            textBoxColorOpenFolderBorder.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorOpenFolderBorder.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelOpenFolderBorder
            // 
            labelOpenFolderBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelOpenFolderBorder.AutoSize = true;
            labelOpenFolderBorder.Location = new System.Drawing.Point(95, 4);
            labelOpenFolderBorder.Name = "labelOpenFolderBorder";
            labelOpenFolderBorder.Size = new System.Drawing.Size(129, 15);
            labelOpenFolderBorder.TabIndex = 0;
            labelOpenFolderBorder.Text = "labelOpenFolderBorder";
            // 
            // tableLayoutPanelOpenFolder
            // 
            tableLayoutPanelOpenFolder.AutoSize = true;
            tableLayoutPanelOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelOpenFolder.ColumnCount = 3;
            tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelOpenFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelOpenFolder.Controls.Add(pictureBoxOpenFolder, 0, 0);
            tableLayoutPanelOpenFolder.Controls.Add(textBoxColorOpenFolder, 1, 0);
            tableLayoutPanelOpenFolder.Controls.Add(labelOpenFolder, 2, 0);
            tableLayoutPanelOpenFolder.Location = new System.Drawing.Point(3, 134);
            tableLayoutPanelOpenFolder.Name = "tableLayoutPanelOpenFolder";
            tableLayoutPanelOpenFolder.RowCount = 1;
            tableLayoutPanelOpenFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelOpenFolder.Size = new System.Drawing.Size(192, 23);
            tableLayoutPanelOpenFolder.TabIndex = 2;
            // 
            // pictureBoxOpenFolder
            // 
            pictureBoxOpenFolder.BackColor = System.Drawing.Color.White;
            pictureBoxOpenFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxOpenFolder.Location = new System.Drawing.Point(0, 0);
            pictureBoxOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxOpenFolder.Name = "pictureBoxOpenFolder";
            pictureBoxOpenFolder.Size = new System.Drawing.Size(23, 23);
            pictureBoxOpenFolder.TabIndex = 1;
            pictureBoxOpenFolder.TabStop = false;
            pictureBoxOpenFolder.Click += PictureBoxClick;
            // 
            // textBoxColorOpenFolder
            // 
            textBoxColorOpenFolder.Location = new System.Drawing.Point(23, 0);
            textBoxColorOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorOpenFolder.MaxLength = 12;
            textBoxColorOpenFolder.Name = "textBoxColorOpenFolder";
            textBoxColorOpenFolder.Size = new System.Drawing.Size(69, 23);
            textBoxColorOpenFolder.TabIndex = 2;
            textBoxColorOpenFolder.Text = "#ffffff";
            textBoxColorOpenFolder.TextChanged += TextBoxColorsChanged;
            textBoxColorOpenFolder.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorOpenFolder.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelOpenFolder
            // 
            labelOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelOpenFolder.AutoSize = true;
            labelOpenFolder.Location = new System.Drawing.Point(95, 4);
            labelOpenFolder.Name = "labelOpenFolder";
            labelOpenFolder.Size = new System.Drawing.Size(94, 15);
            labelOpenFolder.TabIndex = 0;
            labelOpenFolder.Text = "labelOpenFolder";
            // 
            // tableLayoutPanelSearchField
            // 
            tableLayoutPanelSearchField.AutoSize = true;
            tableLayoutPanelSearchField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelSearchField.ColumnCount = 3;
            tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelSearchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSearchField.Controls.Add(pictureBoxSearchField, 0, 0);
            tableLayoutPanelSearchField.Controls.Add(textBoxColorSearchField, 1, 0);
            tableLayoutPanelSearchField.Controls.Add(labelSearchField, 2, 0);
            tableLayoutPanelSearchField.Location = new System.Drawing.Point(3, 105);
            tableLayoutPanelSearchField.Name = "tableLayoutPanelSearchField";
            tableLayoutPanelSearchField.RowCount = 1;
            tableLayoutPanelSearchField.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSearchField.Size = new System.Drawing.Size(190, 23);
            tableLayoutPanelSearchField.TabIndex = 2;
            // 
            // pictureBoxSearchField
            // 
            pictureBoxSearchField.BackColor = System.Drawing.Color.White;
            pictureBoxSearchField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSearchField.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxSearchField.Location = new System.Drawing.Point(0, 0);
            pictureBoxSearchField.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxSearchField.Name = "pictureBoxSearchField";
            pictureBoxSearchField.Size = new System.Drawing.Size(23, 23);
            pictureBoxSearchField.TabIndex = 1;
            pictureBoxSearchField.TabStop = false;
            pictureBoxSearchField.Click += PictureBoxClick;
            // 
            // textBoxColorSearchField
            // 
            textBoxColorSearchField.Location = new System.Drawing.Point(23, 0);
            textBoxColorSearchField.Margin = new System.Windows.Forms.Padding(0);
            textBoxColorSearchField.MaxLength = 12;
            textBoxColorSearchField.Name = "textBoxColorSearchField";
            textBoxColorSearchField.Size = new System.Drawing.Size(69, 23);
            textBoxColorSearchField.TabIndex = 2;
            textBoxColorSearchField.Text = "#ffffff";
            textBoxColorSearchField.TextChanged += TextBoxColorsChanged;
            textBoxColorSearchField.KeyDown += StopPlayingDingSoundEnterKeyPressed_KeyDown;
            textBoxColorSearchField.KeyUp += StopPlayingDingSoundEnterKeyPressed_KeyUp;
            // 
            // labelSearchField
            // 
            labelSearchField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelSearchField.AutoSize = true;
            labelSearchField.Location = new System.Drawing.Point(95, 4);
            labelSearchField.Name = "labelSearchField";
            labelSearchField.Size = new System.Drawing.Size(92, 15);
            labelSearchField.TabIndex = 0;
            labelSearchField.Text = "labelSearchField";
            // 
            // groupBoxAppearance
            // 
            groupBoxAppearance.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxAppearance.AutoSize = true;
            groupBoxAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBoxAppearance.Controls.Add(tableLayoutPanelAppearance);
            groupBoxAppearance.Location = new System.Drawing.Point(3, 3);
            groupBoxAppearance.Name = "groupBoxAppearance";
            groupBoxAppearance.Size = new System.Drawing.Size(373, 353);
            groupBoxAppearance.TabIndex = 1;
            groupBoxAppearance.TabStop = false;
            groupBoxAppearance.Text = "groupBoxAppearance";
            // 
            // tableLayoutPanelAppearance
            // 
            tableLayoutPanelAppearance.AutoSize = true;
            tableLayoutPanelAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelAppearance.ColumnCount = 1;
            tableLayoutPanelAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowFunctionKeyPinMenu, 0, 8);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowFunctionKeySettings, 0, 9);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowFunctionKeyRestart, 0, 10);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowLinkOverlay, 0, 4);
            tableLayoutPanelAppearance.Controls.Add(checkBoxUseFading, 0, 3);
            tableLayoutPanelAppearance.Controls.Add(checkBoxUseIconFromRootFolder, 0, 0);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowSearchBar, 0, 6);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowDirectoryTitleAtTop, 0, 5);
            tableLayoutPanelAppearance.Controls.Add(checkBoxRoundCorners, 0, 1);
            tableLayoutPanelAppearance.Controls.Add(checkBoxDarkModeAlwaysOn, 0, 2);
            tableLayoutPanelAppearance.Controls.Add(buttonAppearanceDefault, 0, 12);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowCountOfElementsBelow, 0, 11);
            tableLayoutPanelAppearance.Controls.Add(checkBoxShowFunctionKeyOpenFolder, 0, 7);
            tableLayoutPanelAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelAppearance.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelAppearance.Name = "tableLayoutPanelAppearance";
            tableLayoutPanelAppearance.RowCount = 13;
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelAppearance.Size = new System.Drawing.Size(367, 331);
            tableLayoutPanelAppearance.TabIndex = 1;
            // 
            // checkBoxShowFunctionKeyPinMenu
            // 
            checkBoxShowFunctionKeyPinMenu.AutoSize = true;
            checkBoxShowFunctionKeyPinMenu.Location = new System.Drawing.Point(3, 203);
            checkBoxShowFunctionKeyPinMenu.Name = "checkBoxShowFunctionKeyPinMenu";
            checkBoxShowFunctionKeyPinMenu.Size = new System.Drawing.Size(220, 19);
            checkBoxShowFunctionKeyPinMenu.TabIndex = 4;
            checkBoxShowFunctionKeyPinMenu.Text = "checkBoxShowFunctionKeyPinMenu";
            checkBoxShowFunctionKeyPinMenu.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFunctionKeySettings
            // 
            checkBoxShowFunctionKeySettings.AutoSize = true;
            checkBoxShowFunctionKeySettings.Location = new System.Drawing.Point(3, 228);
            checkBoxShowFunctionKeySettings.Name = "checkBoxShowFunctionKeySettings";
            checkBoxShowFunctionKeySettings.Size = new System.Drawing.Size(214, 19);
            checkBoxShowFunctionKeySettings.TabIndex = 5;
            checkBoxShowFunctionKeySettings.Text = "checkBoxShowFunctionKeySettings";
            checkBoxShowFunctionKeySettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFunctionKeyRestart
            // 
            checkBoxShowFunctionKeyRestart.AutoSize = true;
            checkBoxShowFunctionKeyRestart.Location = new System.Drawing.Point(3, 253);
            checkBoxShowFunctionKeyRestart.Name = "checkBoxShowFunctionKeyRestart";
            checkBoxShowFunctionKeyRestart.Size = new System.Drawing.Size(208, 19);
            checkBoxShowFunctionKeyRestart.TabIndex = 6;
            checkBoxShowFunctionKeyRestart.Text = "checkBoxShowFunctionKeyRestart";
            checkBoxShowFunctionKeyRestart.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowLinkOverlay
            // 
            checkBoxShowLinkOverlay.AutoSize = true;
            checkBoxShowLinkOverlay.Location = new System.Drawing.Point(3, 103);
            checkBoxShowLinkOverlay.Name = "checkBoxShowLinkOverlay";
            checkBoxShowLinkOverlay.Size = new System.Drawing.Size(168, 19);
            checkBoxShowLinkOverlay.TabIndex = 5;
            checkBoxShowLinkOverlay.Text = "checkBoxShowLinkOverlay";
            checkBoxShowLinkOverlay.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseFading
            // 
            checkBoxUseFading.AutoSize = true;
            checkBoxUseFading.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxUseFading.Location = new System.Drawing.Point(3, 78);
            checkBoxUseFading.Name = "checkBoxUseFading";
            checkBoxUseFading.Size = new System.Drawing.Size(361, 19);
            checkBoxUseFading.TabIndex = 5;
            checkBoxUseFading.Text = "checkBoxUseFading";
            checkBoxUseFading.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseIconFromRootFolder
            // 
            checkBoxUseIconFromRootFolder.AutoSize = true;
            checkBoxUseIconFromRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxUseIconFromRootFolder.Location = new System.Drawing.Point(3, 3);
            checkBoxUseIconFromRootFolder.Name = "checkBoxUseIconFromRootFolder";
            checkBoxUseIconFromRootFolder.Size = new System.Drawing.Size(361, 19);
            checkBoxUseIconFromRootFolder.TabIndex = 4;
            checkBoxUseIconFromRootFolder.Text = "checkBoxUseIconFromRootFolder";
            checkBoxUseIconFromRootFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSearchBar
            // 
            checkBoxShowSearchBar.AutoSize = true;
            checkBoxShowSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxShowSearchBar.Location = new System.Drawing.Point(3, 153);
            checkBoxShowSearchBar.Name = "checkBoxShowSearchBar";
            checkBoxShowSearchBar.Size = new System.Drawing.Size(361, 19);
            checkBoxShowSearchBar.TabIndex = 2;
            checkBoxShowSearchBar.Text = "checkBoxShowSearchBar";
            checkBoxShowSearchBar.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDirectoryTitleAtTop
            // 
            checkBoxShowDirectoryTitleAtTop.AutoSize = true;
            checkBoxShowDirectoryTitleAtTop.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxShowDirectoryTitleAtTop.Location = new System.Drawing.Point(3, 128);
            checkBoxShowDirectoryTitleAtTop.Name = "checkBoxShowDirectoryTitleAtTop";
            checkBoxShowDirectoryTitleAtTop.Size = new System.Drawing.Size(361, 19);
            checkBoxShowDirectoryTitleAtTop.TabIndex = 1;
            checkBoxShowDirectoryTitleAtTop.Text = "checkBoxShowDirectoryTitleAtTop";
            checkBoxShowDirectoryTitleAtTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoundCorners
            // 
            checkBoxRoundCorners.AutoSize = true;
            checkBoxRoundCorners.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxRoundCorners.Location = new System.Drawing.Point(3, 28);
            checkBoxRoundCorners.Name = "checkBoxRoundCorners";
            checkBoxRoundCorners.Size = new System.Drawing.Size(361, 19);
            checkBoxRoundCorners.TabIndex = 4;
            checkBoxRoundCorners.Text = "checkBoxRoundCorners";
            checkBoxRoundCorners.UseVisualStyleBackColor = true;
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            checkBoxDarkModeAlwaysOn.AutoSize = true;
            checkBoxDarkModeAlwaysOn.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(3, 53);
            checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(361, 19);
            checkBoxDarkModeAlwaysOn.TabIndex = 0;
            checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            checkBoxDarkModeAlwaysOn.CheckedChanged += CheckBoxDarkModeAlwaysOnCheckedChanged;
            // 
            // buttonAppearanceDefault
            // 
            buttonAppearanceDefault.AutoSize = true;
            buttonAppearanceDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAppearanceDefault.Location = new System.Drawing.Point(3, 303);
            buttonAppearanceDefault.MinimumSize = new System.Drawing.Size(75, 23);
            buttonAppearanceDefault.Name = "buttonAppearanceDefault";
            buttonAppearanceDefault.Size = new System.Drawing.Size(154, 25);
            buttonAppearanceDefault.TabIndex = 3;
            buttonAppearanceDefault.Text = "buttonAppearanceDefault";
            buttonAppearanceDefault.UseVisualStyleBackColor = true;
            buttonAppearanceDefault.Click += ButtonAppearanceDefault_Click;
            // 
            // checkBoxShowCountOfElementsBelow
            // 
            checkBoxShowCountOfElementsBelow.AutoSize = true;
            checkBoxShowCountOfElementsBelow.Location = new System.Drawing.Point(3, 278);
            checkBoxShowCountOfElementsBelow.Name = "checkBoxShowCountOfElementsBelow";
            checkBoxShowCountOfElementsBelow.Size = new System.Drawing.Size(232, 19);
            checkBoxShowCountOfElementsBelow.TabIndex = 4;
            checkBoxShowCountOfElementsBelow.Text = "checkBoxShowCountOfElementsBelow";
            checkBoxShowCountOfElementsBelow.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFunctionKeyOpenFolder
            // 
            checkBoxShowFunctionKeyOpenFolder.AutoSize = true;
            checkBoxShowFunctionKeyOpenFolder.Location = new System.Drawing.Point(3, 178);
            checkBoxShowFunctionKeyOpenFolder.Name = "checkBoxShowFunctionKeyOpenFolder";
            checkBoxShowFunctionKeyOpenFolder.Size = new System.Drawing.Size(234, 19);
            checkBoxShowFunctionKeyOpenFolder.TabIndex = 3;
            checkBoxShowFunctionKeyOpenFolder.Text = "checkBoxShowFunctionKeyOpenFolder";
            checkBoxShowFunctionKeyOpenFolder.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelBottom
            // 
            tableLayoutPanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanelBottom.AutoSize = true;
            tableLayoutPanelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBottom.ColumnCount = 3;
            tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelBottom.Controls.Add(buttonOk, 1, 0);
            tableLayoutPanelBottom.Controls.Add(buttonCancel, 2, 0);
            tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 522);
            tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 1;
            tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelBottom.Size = new System.Drawing.Size(426, 25);
            tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.AutoSize = true;
            buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Location = new System.Drawing.Point(265, 0);
            buttonOk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            buttonOk.MinimumSize = new System.Drawing.Size(75, 23);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 25);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButtonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(346, 0);
            buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 25);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Abort";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1080, 577);
            Controls.Add(tableLayoutPanelMain);
            Name = "SettingsForm";
            Opacity = 0D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings";
            FormClosed += SettingsForm_FormClosed;
            Load += SettingsForm_Load;
            Shown += SettingsForm_Shown;
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            tableLayoutPanelGeneral.ResumeLayout(false);
            tableLayoutPanelGeneral.PerformLayout();
            groupBoxFolder.ResumeLayout(false);
            groupBoxFolder.PerformLayout();
            tableLayoutPanelFolder.ResumeLayout(false);
            tableLayoutPanelFolder.PerformLayout();
            tableLayoutPanelChangeFolder.ResumeLayout(false);
            tableLayoutPanelChangeFolder.PerformLayout();
            tableLayoutPanelRelativeFolderOpenAssembly.ResumeLayout(false);
            tableLayoutPanelRelativeFolderOpenAssembly.PerformLayout();
            groupBoxConfigAndLogfile.ResumeLayout(false);
            groupBoxConfigAndLogfile.PerformLayout();
            tableLayoutPanelConfigAndLogfile.ResumeLayout(false);
            tableLayoutPanelConfigAndLogfile.PerformLayout();
            groupBoxAutostart.ResumeLayout(false);
            groupBoxAutostart.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanelAutostart.ResumeLayout(false);
            tableLayoutPanelAutostart.PerformLayout();
            groupBoxHotkey.ResumeLayout(false);
            groupBoxHotkey.PerformLayout();
            tableLayoutPanelHotkey.ResumeLayout(false);
            tableLayoutPanelHotkey.PerformLayout();
            groupBoxLanguage.ResumeLayout(false);
            groupBoxLanguage.PerformLayout();
            tableLayoutPanelLanguage.ResumeLayout(false);
            tabPageSizeAndLocation.ResumeLayout(false);
            tabPageSizeAndLocation.PerformLayout();
            tableLayoutPanelSizeAndLocation.ResumeLayout(false);
            tableLayoutPanelSizeAndLocation.PerformLayout();
            groupBoxSubMenuAppearAt.ResumeLayout(false);
            groupBoxSubMenuAppearAt.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOverlappingOffsetPixels).EndInit();
            groupBoxMenuAppearAt.ResumeLayout(false);
            groupBoxMenuAppearAt.PerformLayout();
            tableLayoutPanelMenuAppearAt.ResumeLayout(false);
            tableLayoutPanelMenuAppearAt.PerformLayout();
            groupBoxSize.ResumeLayout(false);
            groupBoxSize.PerformLayout();
            tableLayoutPanelSize.ResumeLayout(false);
            tableLayoutPanelSize.PerformLayout();
            tableLayoutPanelIconSizeInPercent.ResumeLayout(false);
            tableLayoutPanelIconSizeInPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIconSizeInPercent).EndInit();
            tableLayoutPanelRowHeighteInPercentage.ResumeLayout(false);
            tableLayoutPanelRowHeighteInPercentage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowHeighteInPercentage).EndInit();
            tableLayoutPanelSizeInPercent.ResumeLayout(false);
            tableLayoutPanelSizeInPercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSizeInPercent).EndInit();
            tableLayoutPanelMenuHeight.ResumeLayout(false);
            tableLayoutPanelMenuHeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenuHeight).EndInit();
            tableLayoutPanelMaxMenuWidth.ResumeLayout(false);
            tableLayoutPanelMaxMenuWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMenuWidth).EndInit();
            tabPageAdvanced.ResumeLayout(false);
            tabPageAdvanced.PerformLayout();
            tableLayoutPanelAdvanced.ResumeLayout(false);
            tableLayoutPanelAdvanced.PerformLayout();
            groupBoxOptionalFeatures.ResumeLayout(false);
            groupBoxOptionalFeatures.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBoxInternetShortcutIcons.ResumeLayout(false);
            groupBoxInternetShortcutIcons.PerformLayout();
            tableLayoutPanelInternetShortcutIcons.ResumeLayout(false);
            tableLayoutPanelInternetShortcutIcons.PerformLayout();
            tableLayoutPanelChangeIcoFolder.ResumeLayout(false);
            tableLayoutPanelChangeIcoFolder.PerformLayout();
            groupBoxDrag.ResumeLayout(false);
            groupBoxDrag.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBoxSorting.ResumeLayout(false);
            groupBoxSorting.PerformLayout();
            tableLayoutPanelSorting.ResumeLayout(false);
            tableLayoutPanelSorting.PerformLayout();
            groupBoxHiddenFilesAndFolders.ResumeLayout(false);
            groupBoxHiddenFilesAndFolders.PerformLayout();
            tableLayoutPanelHiddenFilesAndFolders.ResumeLayout(false);
            tableLayoutPanelHiddenFilesAndFolders.PerformLayout();
            groupBoxClick.ResumeLayout(false);
            groupBoxClick.PerformLayout();
            tableLayoutPanelClick.ResumeLayout(false);
            tableLayoutPanelClick.PerformLayout();
            tabPageFolders.ResumeLayout(false);
            tabPageFolders.PerformLayout();
            tableLayoutPanelFoldersInRootFolder.ResumeLayout(false);
            tableLayoutPanelFoldersInRootFolder.PerformLayout();
            groupBoxFoldersInRootFolder.ResumeLayout(false);
            groupBoxFoldersInRootFolder.PerformLayout();
            tableLayoutPanelFolderToRootFoldersList.ResumeLayout(false);
            tableLayoutPanelFolderToRootFoldersList.PerformLayout();
            tableLayoutPanelFolderToRootFolder.ResumeLayout(false);
            tableLayoutPanelFolderToRootFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFolders).EndInit();
            tableLayoutPanelAddSampleStartMenuFolder.ResumeLayout(false);
            tableLayoutPanelAddSampleStartMenuFolder.PerformLayout();
            tabPageExpert.ResumeLayout(false);
            tabPageExpert.PerformLayout();
            tableLayoutPanelExpert.ResumeLayout(false);
            tableLayoutPanelExpert.PerformLayout();
            groupBoxSearchPattern.ResumeLayout(false);
            groupBoxSearchPattern.PerformLayout();
            tableLayoutPanelSearchPattern.ResumeLayout(false);
            tableLayoutPanelSearchPattern.PerformLayout();
            groupBoxCache.ResumeLayout(false);
            groupBoxCache.PerformLayout();
            tableLayoutPanelCache.ResumeLayout(false);
            tableLayoutPanelCache.PerformLayout();
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.ResumeLayout(false);
            tableLayoutPanelClearCacheIfMoreThanThisNumberOfItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownClearCacheIfMoreThanThisNumberOfItems).EndInit();
            groupBoxStaysOpen.ResumeLayout(false);
            groupBoxStaysOpen.PerformLayout();
            tableLayoutPanelStaysOpen.ResumeLayout(false);
            tableLayoutPanelStaysOpen.PerformLayout();
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.ResumeLayout(false);
            tableLayoutPanelTimeUntilClosesAfterEnterPressed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilClosesAfterEnterPressed).EndInit();
            tableLayoutPanelTimeUntilCloses.ResumeLayout(false);
            tableLayoutPanelTimeUntilCloses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilClose).EndInit();
            groupBoxOpenSubmenus.ResumeLayout(false);
            groupBoxOpenSubmenus.PerformLayout();
            tableLayoutPanelTimeUntilOpen.ResumeLayout(false);
            tableLayoutPanelTimeUntilOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeUntilOpens).EndInit();
            tabPageCustomize.ResumeLayout(false);
            tabPageCustomize.PerformLayout();
            tableLayoutPanelCustomize.ResumeLayout(false);
            tableLayoutPanelCustomize.PerformLayout();
            groupBoxColorsDarkMode.ResumeLayout(false);
            groupBoxColorsDarkMode.PerformLayout();
            tableLayoutPanelDarkMode.ResumeLayout(false);
            tableLayoutPanelDarkMode.PerformLayout();
            tableLayoutPanelColorIconsDarkMode.ResumeLayout(false);
            tableLayoutPanelColorIconsDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIconsDarkMode).EndInit();
            tableLayoutPanelColorBackgroundBorderDarkMode.ResumeLayout(false);
            tableLayoutPanelColorBackgroundBorderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundBorderDarkMode).EndInit();
            tableLayoutPanelSearchFieldDarkMode.ResumeLayout(false);
            tableLayoutPanelSearchFieldDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchFieldDarkMode).EndInit();
            tableLayoutPanelOpenFolderDarkMode.ResumeLayout(false);
            tableLayoutPanelOpenFolderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderDarkMode).EndInit();
            tableLayoutPanelOpenFolderBorderDarkMode.ResumeLayout(false);
            tableLayoutPanelOpenFolderBorderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderBorderDarkMode).EndInit();
            tableLayoutPanelSelectedItemDarkMode.ResumeLayout(false);
            tableLayoutPanelSelectedItemDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureColorBoxSelectedItemDarkMode).EndInit();
            tableLayoutPanelSelectedItemBorderDarkMode.ResumeLayout(false);
            tableLayoutPanelSelectedItemBorderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItemBorderDarkMode).EndInit();
            tableLayoutPanelScrollbarBackgroundDarkMode.ResumeLayout(false);
            tableLayoutPanelScrollbarBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScrollbarBackgroundDarkMode).EndInit();
            tableLayoutPanelSliderDarkMode.ResumeLayout(false);
            tableLayoutPanelSliderDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDarkMode).EndInit();
            tableLayoutPanelSliderDraggingDarkMode.ResumeLayout(false);
            tableLayoutPanelSliderDraggingDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDraggingDarkMode).EndInit();
            tableLayoutPanelSliderHoverDarkMode.ResumeLayout(false);
            tableLayoutPanelSliderHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderHoverDarkMode).EndInit();
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.ResumeLayout(false);
            tableLayoutPanelSliderArrowsAndTrackHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderArrowsAndTrackHoverDarkMode).EndInit();
            tableLayoutPanelArrowDarkMode.ResumeLayout(false);
            tableLayoutPanelArrowDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowDarkMode).EndInit();
            tableLayoutPanelArrowClickDarkMode.ResumeLayout(false);
            tableLayoutPanelArrowClickDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickDarkMode).EndInit();
            tableLayoutPanelArrowClickBackgroundDarkMode.ResumeLayout(false);
            tableLayoutPanelArrowClickBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickBackgroundDarkMode).EndInit();
            tableLayoutPanelArrowHoverDarkMode.ResumeLayout(false);
            tableLayoutPanelArrowHoverDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverDarkMode).EndInit();
            tableLayoutPanelArrowHoverBackgroundDarkMode.ResumeLayout(false);
            tableLayoutPanelArrowHoverBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverBackgroundDarkMode).EndInit();
            tableLayoutPanelBackgroundDarkMode.ResumeLayout(false);
            tableLayoutPanelBackgroundDarkMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundDarkMode).EndInit();
            groupBoxColorsLightMode.ResumeLayout(false);
            groupBoxColorsLightMode.PerformLayout();
            tableLayoutPanelColorsAndDefault.ResumeLayout(false);
            tableLayoutPanelColorsAndDefault.PerformLayout();
            tableLayoutPanelIcons.ResumeLayout(false);
            tableLayoutPanelIcons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcons).EndInit();
            tableLayoutPanelBackgroundBorder.ResumeLayout(false);
            tableLayoutPanelBackgroundBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackgroundBorder).EndInit();
            tableLayoutPanelBackground.ResumeLayout(false);
            tableLayoutPanelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).EndInit();
            tableLayoutPanelArrowHoverBackground.ResumeLayout(false);
            tableLayoutPanelArrowHoverBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHoverBackground).EndInit();
            tableLayoutPanelArrowHover.ResumeLayout(false);
            tableLayoutPanelArrowHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowHover).EndInit();
            tableLayoutPanelArrowClickBackground.ResumeLayout(false);
            tableLayoutPanelArrowClickBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClickBackground).EndInit();
            tableLayoutPanelArrowClick.ResumeLayout(false);
            tableLayoutPanelArrowClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrowClick).EndInit();
            tableLayoutPanelArrow.ResumeLayout(false);
            tableLayoutPanelArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArrow).EndInit();
            tableLayoutPanelSliderArrowsAndTrackHover.ResumeLayout(false);
            tableLayoutPanelSliderArrowsAndTrackHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderArrowsAndTrackHover).EndInit();
            tableLayoutPanelSliderHover.ResumeLayout(false);
            tableLayoutPanelSliderHover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderHover).EndInit();
            tableLayoutPanelSliderDragging.ResumeLayout(false);
            tableLayoutPanelSliderDragging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSliderDragging).EndInit();
            tableLayoutPanelSlider.ResumeLayout(false);
            tableLayoutPanelSlider.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSlider).EndInit();
            tableLayoutPanelScrollbarBackground.ResumeLayout(false);
            tableLayoutPanelScrollbarBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScrollbarBackground).EndInit();
            tableLayoutPanelSelectedItemBorder.ResumeLayout(false);
            tableLayoutPanelSelectedItemBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItemBorder).EndInit();
            tableLayoutPanelSelectedItem.ResumeLayout(false);
            tableLayoutPanelSelectedItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedItem).EndInit();
            tableLayoutPanelOpenFolderBorder.ResumeLayout(false);
            tableLayoutPanelOpenFolderBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolderBorder).EndInit();
            tableLayoutPanelOpenFolder.ResumeLayout(false);
            tableLayoutPanelOpenFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpenFolder).EndInit();
            tableLayoutPanelSearchField.ResumeLayout(false);
            tableLayoutPanelSearchField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchField).EndInit();
            groupBoxAppearance.ResumeLayout(false);
            groupBoxAppearance.PerformLayout();
            tableLayoutPanelAppearance.ResumeLayout(false);
            tableLayoutPanelAppearance.PerformLayout();
            tableLayoutPanelBottom.ResumeLayout(false);
            tableLayoutPanelBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageSizeAndLocation;
        private System.Windows.Forms.GroupBox groupBoxHiddenFilesAndFolders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHiddenFilesAndFolders;
        private System.Windows.Forms.RadioButton radioButtonAlwaysShowHiddenFiles;
        private System.Windows.Forms.RadioButton radioButtonNeverShowHiddenFiles;
        private System.Windows.Forms.RadioButton radioButtonSystemSettingsShowHiddenFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSizeAndLocation;
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
        private System.Windows.Forms.CheckBox checkBoxShowFunctionKeyOpenFolder;
        private System.Windows.Forms.CheckBox checkBoxShowSearchBar;
        private System.Windows.Forms.CheckBox checkBoxShowDirectoryTitleAtTop;
        private System.Windows.Forms.CheckBox checkBoxShowCountOfElementsBelow;
        private System.Windows.Forms.CheckBox checkBoxSaveLogFileInApplicationDirectory;
        private System.Windows.Forms.CheckBox checkBoxShowLinkOverlay;
        private System.Windows.Forms.GroupBox groupBoxInternetShortcutIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInternetShortcutIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChangeIcoFolder;
        private System.Windows.Forms.Button buttonChangeIcoFolder;
        private System.Windows.Forms.TextBox textBoxIcoFolder;
        private System.Windows.Forms.RadioButton radioButtonSortByTypeAndDate;
        private System.Windows.Forms.RadioButton radioButtonSortByTypeAndName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox checkBoxCheckForUpdates;
        private System.Windows.Forms.Button buttonGeneralDefault;
        private System.Windows.Forms.CheckBox checkBoxShowFunctionKeyPinMenu;
        private System.Windows.Forms.CheckBox checkBoxShowFunctionKeySettings;
        private System.Windows.Forms.CheckBox checkBoxShowFunctionKeyRestart;
        private System.Windows.Forms.CheckBox checkBoxSupportGamepad;
        private System.Windows.Forms.GroupBox groupBoxOptionalFeatures;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxResolveLinksToFolders;
        private System.Windows.Forms.RadioButton radioButtonSortByFileExtensionAndName;
    }
}