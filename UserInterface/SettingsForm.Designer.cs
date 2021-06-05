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
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuHeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuHeight = new System.Windows.Forms.Label();
            this.checkBoxAppearAtMouseLocation = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelMaxMenuWidth = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuWidth = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuWidth = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverBackground = new System.Windows.Forms.TextBox();
            this.labelArrowHoverBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHover = new System.Windows.Forms.TextBox();
            this.labelArrowHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickBackground = new System.Windows.Forms.TextBox();
            this.labelArrowClickBackground = new System.Windows.Forms.Label();
            this.buttonColorsDefault = new System.Windows.Forms.Button();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClick = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClick = new System.Windows.Forms.TextBox();
            this.labelArrowClick = new System.Windows.Forms.Label();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrow = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrow = new System.Windows.Forms.TextBox();
            this.labelArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderArrowsAndTrackHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderArrowsAndTrackHover = new System.Windows.Forms.TextBox();
            this.labelSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderHover = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderHover = new System.Windows.Forms.TextBox();
            this.labelSliderHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDragging = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDragging = new System.Windows.Forms.TextBox();
            this.labelSliderDragging = new System.Windows.Forms.Label();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSlider = new System.Windows.Forms.PictureBox();
            this.textBoxColorSlider = new System.Windows.Forms.TextBox();
            this.labelSlider = new System.Windows.Forms.Label();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxScrollbarBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorScrollbarBackground = new System.Windows.Forms.TextBox();
            this.labelScrollbarBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.textBoxColorWarning = new System.Windows.Forms.TextBox();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItemBorder = new System.Windows.Forms.PictureBox();
            this.textBoxColorSelectedItemBorder = new System.Windows.Forms.TextBox();
            this.labelSelectedItemBorder = new System.Windows.Forms.Label();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItem = new System.Windows.Forms.PictureBox();
            this.textBoxColorSelectedItem = new System.Windows.Forms.TextBox();
            this.labelSelectedItem = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderBorder = new System.Windows.Forms.PictureBox();
            this.textBoxColorOpenFolderBorder = new System.Windows.Forms.TextBox();
            this.labelOpenFolderBorder = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolder = new System.Windows.Forms.PictureBox();
            this.textBoxColorOpenFolder = new System.Windows.Forms.TextBox();
            this.labelOpenFolder = new System.Windows.Forms.Label();
            this.labelScrollbarLightMode = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearchField = new System.Windows.Forms.PictureBox();
            this.textBoxColorSearchField = new System.Windows.Forms.TextBox();
            this.labelSearchField = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.textBoxColorBackground = new System.Windows.Forms.TextBox();
            this.labelBackground = new System.Windows.Forms.Label();
            this.labelMenuLightMode = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.textBoxColorTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxColorsDarkMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.buttonColorsDefaultDarkMode = new System.Windows.Forms.Button();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowHoverBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowClickBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowClickDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowClickDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrowClick = new System.Windows.Forms.Label();
            this.tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxArrowDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorArrowDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderArrowsAndTrackHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderArrowsAndTrackHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderHoverDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderHoverDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderHover = new System.Windows.Forms.Label();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDraggingDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDraggingDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSliderDragging = new System.Windows.Forms.Label();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSliderDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorSliderDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeSlider = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxScrollbarBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.textBoxColorScrollbarBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.labelColorDarkModeScrollbarBackground = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSelectedItemBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSelectedItemBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSelectedItemBorderDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureColorBoxSelectedItemDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSelectedItemDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSelecetedItemDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderBorderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelOpenFolderBorderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorOpenFolderBorderDarkMode = new System.Windows.Forms.TextBox();
            this.labelScrollbarDarkMode = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOpenFolderDarkMode = new System.Windows.Forms.PictureBox();
            this.labelOpenFolderDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorOpenFolderDarkMode = new System.Windows.Forms.TextBox();
            this.labelMenuDarkMode = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearchFieldDarkMode = new System.Windows.Forms.PictureBox();
            this.labelSearchFieldDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorSearchFieldDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackgroundDarkMode = new System.Windows.Forms.PictureBox();
            this.labelBackgroundDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorBackgroundDarkMode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTitleDarkMode = new System.Windows.Forms.PictureBox();
            this.labelTitleDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorTitleDarkMode = new System.Windows.Forms.TextBox();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxWarningDarkMode = new System.Windows.Forms.PictureBox();
            this.labelWarningDarkMode = new System.Windows.Forms.Label();
            this.textBoxColorWarningDarkMode = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
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
            this.tableLayoutPanel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackground)).BeginInit();
            this.tableLayoutPanel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHover)).BeginInit();
            this.tableLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackground)).BeginInit();
            this.tableLayoutPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClick)).BeginInit();
            this.tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).BeginInit();
            this.tableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHover)).BeginInit();
            this.tableLayoutPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHover)).BeginInit();
            this.tableLayoutPanel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDragging)).BeginInit();
            this.tableLayoutPanel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).BeginInit();
            this.tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackground)).BeginInit();
            this.tableLayoutPanel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorder)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItem)).BeginInit();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorder)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchField)).BeginInit();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.groupBoxColorsDarkMode.SuspendLayout();
            this.tableLayoutPanelDarkMode.SuspendLayout();
            this.tableLayoutPanel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverDarkMode)).BeginInit();
            this.tableLayoutPanel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanel36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickDarkMode)).BeginInit();
            this.tableLayoutPanel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDarkMode)).BeginInit();
            this.tableLayoutPanel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHoverDarkMode)).BeginInit();
            this.tableLayoutPanel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHoverDarkMode)).BeginInit();
            this.tableLayoutPanel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDraggingDarkMode)).BeginInit();
            this.tableLayoutPanel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDarkMode)).BeginInit();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorderDarkMode)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorBoxSelectedItemDarkMode)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorderDarkMode)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderDarkMode)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFieldDarkMode)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleDarkMode)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningDarkMode)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottom, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(434, 478);
            this.tableLayoutPanelMain.TabIndex = 0;
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
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 450);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(428, 25);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(267, 0);
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
            this.buttonCancel.Location = new System.Drawing.Point(348, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageAdvanced);
            this.tabControl.Controls.Add(this.tabPageCustomize);
            this.tabControl.Location = new System.Drawing.Point(6, 3);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(422, 441);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(414, 413);
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
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 5;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(408, 407);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.AutoSize = true;
            this.groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFolder.Controls.Add(this.tableLayoutPanelFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFolder.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFolder.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxFolder.Size = new System.Drawing.Size(400, 81);
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
            this.tableLayoutPanelFolder.Controls.Add(this.textBoxFolder, 0, 0);
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelChangeFolder, 0, 1);
            this.tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolder.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            this.tableLayoutPanelFolder.RowCount = 2;
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.Size = new System.Drawing.Size(394, 53);
            this.tableLayoutPanelFolder.TabIndex = 0;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.BackColor = System.Drawing.Color.White;
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFolder.Location = new System.Drawing.Point(6, 3);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(382, 16);
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
            this.tableLayoutPanelChangeFolder.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanelChangeFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelChangeFolder.Name = "tableLayoutPanelChangeFolder";
            this.tableLayoutPanelChangeFolder.RowCount = 1;
            this.tableLayoutPanelChangeFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(394, 31);
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
            this.buttonChangeFolder.Size = new System.Drawing.Size(94, 25);
            this.buttonChangeFolder.TabIndex = 0;
            this.buttonChangeFolder.Text = "Change Folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // groupBoxUSB
            // 
            this.groupBoxUSB.AutoSize = true;
            this.groupBoxUSB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxUSB.Controls.Add(this.tableLayoutPanelUSB);
            this.groupBoxUSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUSB.Location = new System.Drawing.Point(3, 90);
            this.groupBoxUSB.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxUSB.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxUSB.Name = "groupBoxUSB";
            this.groupBoxUSB.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxUSB.Size = new System.Drawing.Size(400, 84);
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
            this.tableLayoutPanelUSB.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelUSB.Name = "tableLayoutPanelUSB";
            this.tableLayoutPanelUSB.RowCount = 2;
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.Size = new System.Drawing.Size(394, 56);
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
            this.tableLayoutPanelRelativeFolderOpenAssembly.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelRelativeFolderOpenAssembly.TabIndex = 1;
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
            this.buttonOpenAssemblyLocation.Location = new System.Drawing.Point(212, 3);
            this.buttonOpenAssemblyLocation.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOpenAssemblyLocation.Name = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.Size = new System.Drawing.Size(179, 25);
            this.buttonOpenAssemblyLocation.TabIndex = 2;
            this.buttonOpenAssemblyLocation.Text = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.UseVisualStyleBackColor = true;
            this.buttonOpenAssemblyLocation.Click += new System.EventHandler(this.ButtonOpenAssemblyLocation_Click);
            // 
            // checkBoxStoreConfigAtAssemblyLocation
            // 
            this.checkBoxStoreConfigAtAssemblyLocation.AutoSize = true;
            this.checkBoxStoreConfigAtAssemblyLocation.Location = new System.Drawing.Point(3, 34);
            this.checkBoxStoreConfigAtAssemblyLocation.Name = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.Size = new System.Drawing.Size(249, 19);
            this.checkBoxStoreConfigAtAssemblyLocation.TabIndex = 1;
            this.checkBoxStoreConfigAtAssemblyLocation.Text = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutostart
            // 
            this.groupBoxAutostart.AutoSize = true;
            this.groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAutostart.Controls.Add(this.tableLayoutPanelAutostart);
            this.groupBoxAutostart.Location = new System.Drawing.Point(3, 180);
            this.groupBoxAutostart.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxAutostart.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxAutostart.Name = "groupBoxAutostart";
            this.groupBoxAutostart.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxAutostart.Size = new System.Drawing.Size(400, 53);
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
            this.tableLayoutPanelAutostart.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            this.tableLayoutPanelAutostart.RowCount = 1;
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Size = new System.Drawing.Size(394, 25);
            this.tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutostart.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(388, 19);
            this.checkBoxAutostart.TabIndex = 0;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            this.groupBoxHotkey.AutoSize = true;
            this.groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHotkey.Controls.Add(this.tableLayoutPanelHotkey);
            this.groupBoxHotkey.Location = new System.Drawing.Point(3, 239);
            this.groupBoxHotkey.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxHotkey.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxHotkey.Name = "groupBoxHotkey";
            this.groupBoxHotkey.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxHotkey.Size = new System.Drawing.Size(400, 59);
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
            this.tableLayoutPanelHotkey.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelHotkey.TabIndex = 0;
            // 
            // textBoxHotkeyPlaceholder
            // 
            this.textBoxHotkeyPlaceholder.Location = new System.Drawing.Point(3, 3);
            this.textBoxHotkeyPlaceholder.Name = "textBoxHotkeyPlaceholder";
            this.textBoxHotkeyPlaceholder.Size = new System.Drawing.Size(200, 23);
            this.textBoxHotkeyPlaceholder.TabIndex = 0;
            // 
            // buttonHotkeyDefault
            // 
            this.buttonHotkeyDefault.AutoSize = true;
            this.buttonHotkeyDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHotkeyDefault.Location = new System.Drawing.Point(262, 3);
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
            this.groupBoxLanguage.AutoSize = true;
            this.groupBoxLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLanguage.Controls.Add(this.tableLayoutPanelLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(3, 304);
            this.groupBoxLanguage.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxLanguage.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxLanguage.Size = new System.Drawing.Size(400, 57);
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
            this.tableLayoutPanelLanguage.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(200, 23);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanelAdvanced);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(414, 413);
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
            this.tableLayoutPanelAdvanced.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelAdvanced.Name = "tableLayoutPanelAdvanced";
            this.tableLayoutPanelAdvanced.RowCount = 5;
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.Size = new System.Drawing.Size(408, 407);
            this.tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxClick
            // 
            this.groupBoxClick.AutoSize = true;
            this.groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxClick.Controls.Add(this.tableLayoutPanelClick);
            this.groupBoxClick.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClick.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxClick.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxClick.Name = "groupBoxClick";
            this.groupBoxClick.Size = new System.Drawing.Size(400, 47);
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
            this.tableLayoutPanelClick.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelClick.Name = "tableLayoutPanelClick";
            this.tableLayoutPanelClick.RowCount = 1;
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClick.Size = new System.Drawing.Size(394, 25);
            this.tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(388, 19);
            this.checkBoxOpenItemWithOneClick.TabIndex = 0;
            this.checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // groupBoxSizeAndLocation
            // 
            this.groupBoxSizeAndLocation.AutoSize = true;
            this.groupBoxSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSizeAndLocation.Controls.Add(this.tableLayoutPanelSizeAndLocation);
            this.groupBoxSizeAndLocation.Location = new System.Drawing.Point(3, 56);
            this.groupBoxSizeAndLocation.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSizeAndLocation.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSizeAndLocation.Name = "groupBoxSizeAndLocation";
            this.groupBoxSizeAndLocation.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxSizeAndLocation.Size = new System.Drawing.Size(400, 108);
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
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.checkBoxAppearAtMouseLocation, 0, 0);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanelMaxMenuWidth, 0, 1);
            this.tableLayoutPanelSizeAndLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSizeAndLocation.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelSizeAndLocation.Name = "tableLayoutPanelSizeAndLocation";
            this.tableLayoutPanelSizeAndLocation.RowCount = 3;
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.Size = new System.Drawing.Size(394, 83);
            this.tableLayoutPanelSizeAndLocation.TabIndex = 0;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownMenuHeight
            // 
            this.numericUpDownMenuHeight.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownMenuHeight.Name = "numericUpDownMenuHeight";
            this.numericUpDownMenuHeight.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownMenuHeight.TabIndex = 1;
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
            // checkBoxAppearAtMouseLocation
            // 
            this.checkBoxAppearAtMouseLocation.AutoSize = true;
            this.checkBoxAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAppearAtMouseLocation.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAppearAtMouseLocation.Name = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.Size = new System.Drawing.Size(388, 19);
            this.checkBoxAppearAtMouseLocation.TabIndex = 0;
            this.checkBoxAppearAtMouseLocation.Text = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanelMaxMenuWidth.Location = new System.Drawing.Point(0, 25);
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
            // groupBoxStaysOpen
            // 
            this.groupBoxStaysOpen.AutoSize = true;
            this.groupBoxStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStaysOpen.Controls.Add(this.tableLayoutPanelStaysOpen);
            this.groupBoxStaysOpen.Location = new System.Drawing.Point(3, 170);
            this.groupBoxStaysOpen.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            this.groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxStaysOpen.Size = new System.Drawing.Size(400, 104);
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
            this.tableLayoutPanelStaysOpen.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelStaysOpen.Name = "tableLayoutPanelStaysOpen";
            this.tableLayoutPanelStaysOpen.RowCount = 3;
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(394, 79);
            this.tableLayoutPanelStaysOpen.TabIndex = 0;
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
            // 
            // groupBoxOpenSubmenus
            // 
            this.groupBoxOpenSubmenus.AutoSize = true;
            this.groupBoxOpenSubmenus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOpenSubmenus.Controls.Add(this.tableLayoutPanelTimeUntilOpen);
            this.groupBoxOpenSubmenus.Location = new System.Drawing.Point(3, 280);
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
            // buttonAdvancedDefault
            // 
            this.buttonAdvancedDefault.AutoSize = true;
            this.buttonAdvancedDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdvancedDefault.Location = new System.Drawing.Point(9, 346);
            this.buttonAdvancedDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonAdvancedDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonAdvancedDefault.Name = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.Size = new System.Drawing.Size(144, 25);
            this.buttonAdvancedDefault.TabIndex = 0;
            this.buttonAdvancedDefault.Text = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.UseVisualStyleBackColor = true;
            this.buttonAdvancedDefault.Click += new System.EventHandler(this.ButtonAdvancedDefault_Click);
            // 
            // tabPageCustomize
            // 
            this.tabPageCustomize.AutoScroll = true;
            this.tabPageCustomize.Controls.Add(this.tableLayoutPanelCustomize);
            this.tabPageCustomize.Location = new System.Drawing.Point(4, 24);
            this.tabPageCustomize.Name = "tabPageCustomize";
            this.tabPageCustomize.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomize.Size = new System.Drawing.Size(414, 413);
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
            this.tableLayoutPanelCustomize.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            this.tableLayoutPanelCustomize.RowCount = 2;
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.Size = new System.Drawing.Size(391, 1247);
            this.tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxColorsLightMode
            // 
            this.groupBoxColorsLightMode.AutoSize = true;
            this.groupBoxColorsLightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsLightMode.Controls.Add(this.tableLayoutPanelColorsAndDefault);
            this.groupBoxColorsLightMode.Location = new System.Drawing.Point(3, 3);
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
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel30, 0, 19);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel29, 0, 18);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel28, 0, 17);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.buttonColorsDefault, 0, 20);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel27, 0, 16);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel26, 0, 15);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel25, 0, 14);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel24, 0, 13);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel23, 0, 12);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel22, 0, 11);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel21, 0, 10);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel20, 0, 8);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel19, 0, 7);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel18, 0, 6);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel17, 0, 5);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel16, 0, 4);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelScrollbarLightMode, 0, 9);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel15, 0, 3);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel14, 0, 2);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelMenuLightMode, 0, 0);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanel5, 0, 1);
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
            this.tableLayoutPanelColorsAndDefault.Size = new System.Drawing.Size(379, 583);
            this.tableLayoutPanelColorsAndDefault.TabIndex = 0;
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.AutoSize = true;
            this.tableLayoutPanel30.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel30.ColumnCount = 3;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.Controls.Add(this.pictureBoxArrowHoverBackground, 0, 0);
            this.tableLayoutPanel30.Controls.Add(this.textBoxColorArrowHoverBackground, 1, 0);
            this.tableLayoutPanel30.Controls.Add(this.labelArrowHoverBackground, 2, 0);
            this.tableLayoutPanel30.Location = new System.Drawing.Point(3, 526);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 1;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel30.Size = new System.Drawing.Size(258, 23);
            this.tableLayoutPanel30.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackground
            // 
            this.pictureBoxArrowHoverBackground.BackColor = System.Drawing.Color.White;
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
            // 
            // labelArrowHoverBackground
            // 
            this.labelArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelArrowHoverBackground.AutoSize = true;
            this.labelArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            this.labelArrowHoverBackground.Name = "labelArrowHoverBackground";
            this.labelArrowHoverBackground.Size = new System.Drawing.Size(160, 15);
            this.labelArrowHoverBackground.TabIndex = 0;
            this.labelArrowHoverBackground.Text = "labelArrowHoverBackground";
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.AutoSize = true;
            this.tableLayoutPanel29.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel29.ColumnCount = 3;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel29.Controls.Add(this.pictureBoxArrowHover, 0, 0);
            this.tableLayoutPanel29.Controls.Add(this.textBoxColorArrowHover, 1, 0);
            this.tableLayoutPanel29.Controls.Add(this.labelArrowHover, 2, 0);
            this.tableLayoutPanel29.Location = new System.Drawing.Point(3, 497);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 1;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel29.Size = new System.Drawing.Size(194, 23);
            this.tableLayoutPanel29.TabIndex = 2;
            // 
            // pictureBoxArrowHover
            // 
            this.pictureBoxArrowHover.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.AutoSize = true;
            this.tableLayoutPanel28.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel28.ColumnCount = 3;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel28.Controls.Add(this.pictureBoxArrowClickBackground, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.textBoxColorArrowClickBackground, 1, 0);
            this.tableLayoutPanel28.Controls.Add(this.labelArrowClickBackground, 2, 0);
            this.tableLayoutPanel28.Location = new System.Drawing.Point(3, 468);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 1;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel28.Size = new System.Drawing.Size(252, 23);
            this.tableLayoutPanel28.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackground
            // 
            this.pictureBoxArrowClickBackground.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.AutoSize = true;
            this.tableLayoutPanel27.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel27.ColumnCount = 3;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.Controls.Add(this.pictureBoxArrowClick, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.textBoxColorArrowClick, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.labelArrowClick, 2, 0);
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel27.Size = new System.Drawing.Size(188, 23);
            this.tableLayoutPanel27.TabIndex = 2;
            // 
            // pictureBoxArrowClick
            // 
            this.pictureBoxArrowClick.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.AutoSize = true;
            this.tableLayoutPanel26.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel26.ColumnCount = 3;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel26.Controls.Add(this.pictureBoxArrow, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.textBoxColorArrow, 1, 0);
            this.tableLayoutPanel26.Controls.Add(this.labelArrow, 2, 0);
            this.tableLayoutPanel26.Location = new System.Drawing.Point(3, 410);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 1;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.Size = new System.Drawing.Size(162, 23);
            this.tableLayoutPanel26.TabIndex = 2;
            // 
            // pictureBoxArrow
            // 
            this.pictureBoxArrow.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.AutoSize = true;
            this.tableLayoutPanel25.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel25.ColumnCount = 3;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.Controls.Add(this.pictureBoxSliderArrowsAndTrackHover, 0, 0);
            this.tableLayoutPanel25.Controls.Add(this.textBoxColorSliderArrowsAndTrackHover, 1, 0);
            this.tableLayoutPanel25.Controls.Add(this.labelSliderArrowsAndTrackHover, 2, 0);
            this.tableLayoutPanel25.Location = new System.Drawing.Point(3, 381);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 1;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.Size = new System.Drawing.Size(277, 23);
            this.tableLayoutPanel25.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHover
            // 
            this.pictureBoxSliderArrowsAndTrackHover.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.AutoSize = true;
            this.tableLayoutPanel24.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel24.ColumnCount = 3;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.Controls.Add(this.pictureBoxSliderHover, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.textBoxColorSliderHover, 1, 0);
            this.tableLayoutPanel24.Controls.Add(this.labelSliderHover, 2, 0);
            this.tableLayoutPanel24.Location = new System.Drawing.Point(3, 352);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 1;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel24.Size = new System.Drawing.Size(191, 23);
            this.tableLayoutPanel24.TabIndex = 2;
            // 
            // pictureBoxSliderHover
            // 
            this.pictureBoxSliderHover.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.AutoSize = true;
            this.tableLayoutPanel23.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel23.ColumnCount = 3;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Controls.Add(this.pictureBoxSliderDragging, 0, 0);
            this.tableLayoutPanel23.Controls.Add(this.textBoxColorSliderDragging, 1, 0);
            this.tableLayoutPanel23.Controls.Add(this.labelSliderDragging, 2, 0);
            this.tableLayoutPanel23.Location = new System.Drawing.Point(3, 323);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 1;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(208, 23);
            this.tableLayoutPanel23.TabIndex = 2;
            // 
            // pictureBoxSliderDragging
            // 
            this.pictureBoxSliderDragging.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.AutoSize = true;
            this.tableLayoutPanel22.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel22.ColumnCount = 3;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Controls.Add(this.pictureBoxSlider, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.textBoxColorSlider, 1, 0);
            this.tableLayoutPanel22.Controls.Add(this.labelSlider, 2, 0);
            this.tableLayoutPanel22.Location = new System.Drawing.Point(3, 294);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel22.Size = new System.Drawing.Size(159, 23);
            this.tableLayoutPanel22.TabIndex = 2;
            // 
            // pictureBoxSlider
            // 
            this.pictureBoxSlider.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.AutoSize = true;
            this.tableLayoutPanel21.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel21.ColumnCount = 3;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Controls.Add(this.pictureBoxScrollbarBackground, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.textBoxColorScrollbarBackground, 1, 0);
            this.tableLayoutPanel21.Controls.Add(this.labelScrollbarBackground, 2, 0);
            this.tableLayoutPanel21.Location = new System.Drawing.Point(3, 265);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 1;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.Size = new System.Drawing.Size(240, 23);
            this.tableLayoutPanel21.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackground
            // 
            this.pictureBoxScrollbarBackground.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.AutoSize = true;
            this.tableLayoutPanel20.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.labelWarning, 2, 0);
            this.tableLayoutPanel20.Controls.Add(this.textBoxColorWarning, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.pictureBoxWarning, 0, 0);
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 221);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.Size = new System.Drawing.Size(175, 23);
            this.tableLayoutPanel20.TabIndex = 2;
            // 
            // labelWarning
            // 
            this.labelWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(95, 4);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(77, 15);
            this.labelWarning.TabIndex = 0;
            this.labelWarning.Text = "labelWarning";
            // 
            // textBoxColorWarning
            // 
            this.textBoxColorWarning.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorWarning.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorWarning.MaxLength = 12;
            this.textBoxColorWarning.Name = "textBoxColorWarning";
            this.textBoxColorWarning.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorWarning.TabIndex = 2;
            this.textBoxColorWarning.Text = "#ffffff";
            this.textBoxColorWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.BackColor = System.Drawing.Color.White;
            this.pictureBoxWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWarning.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWarning.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxWarning.TabIndex = 1;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.AutoSize = true;
            this.tableLayoutPanel19.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel19.ColumnCount = 3;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Controls.Add(this.pictureBoxSelectedItemBorder, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.textBoxColorSelectedItemBorder, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.labelSelectedItemBorder, 2, 0);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 192);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.Size = new System.Drawing.Size(233, 23);
            this.tableLayoutPanel19.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorder
            // 
            this.pictureBoxSelectedItemBorder.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.AutoSize = true;
            this.tableLayoutPanel18.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.pictureBoxSelectedItem, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.textBoxColorSelectedItem, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.labelSelectedItem, 2, 0);
            this.tableLayoutPanel18.Location = new System.Drawing.Point(3, 163);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.Size = new System.Drawing.Size(198, 23);
            this.tableLayoutPanel18.TabIndex = 2;
            // 
            // pictureBoxSelectedItem
            // 
            this.pictureBoxSelectedItem.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.AutoSize = true;
            this.tableLayoutPanel17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.pictureBoxOpenFolderBorder, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.textBoxColorOpenFolderBorder, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.labelOpenFolderBorder, 2, 0);
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 134);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.Size = new System.Drawing.Size(227, 23);
            this.tableLayoutPanel17.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorder
            // 
            this.pictureBoxOpenFolderBorder.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.AutoSize = true;
            this.tableLayoutPanel16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel16.ColumnCount = 3;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.pictureBoxOpenFolder, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.textBoxColorOpenFolder, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.labelOpenFolder, 2, 0);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.Size = new System.Drawing.Size(192, 23);
            this.tableLayoutPanel16.TabIndex = 2;
            // 
            // pictureBoxOpenFolder
            // 
            this.pictureBoxOpenFolder.BackColor = System.Drawing.Color.White;
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
            // labelScrollbarLightMode
            // 
            this.labelScrollbarLightMode.AutoSize = true;
            this.labelScrollbarLightMode.Location = new System.Drawing.Point(3, 247);
            this.labelScrollbarLightMode.Name = "labelScrollbarLightMode";
            this.labelScrollbarLightMode.Size = new System.Drawing.Size(136, 15);
            this.labelScrollbarLightMode.TabIndex = 3;
            this.labelScrollbarLightMode.Text = "labelScrollbarLightMode";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.AutoSize = true;
            this.tableLayoutPanel15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(this.pictureBoxSearchField, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.textBoxColorSearchField, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.labelSearchField, 2, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.Size = new System.Drawing.Size(190, 23);
            this.tableLayoutPanel15.TabIndex = 2;
            // 
            // pictureBoxSearchField
            // 
            this.pictureBoxSearchField.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.AutoSize = true;
            this.tableLayoutPanel14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.pictureBoxBackground, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.textBoxColorBackground, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.labelBackground, 2, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.Size = new System.Drawing.Size(194, 23);
            this.tableLayoutPanel14.TabIndex = 2;
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackColor = System.Drawing.Color.White;
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
            // labelMenuLightMode
            // 
            this.labelMenuLightMode.AutoSize = true;
            this.labelMenuLightMode.Location = new System.Drawing.Point(3, 0);
            this.labelMenuLightMode.Name = "labelMenuLightMode";
            this.labelMenuLightMode.Size = new System.Drawing.Size(121, 15);
            this.labelMenuLightMode.TabIndex = 3;
            this.labelMenuLightMode.Text = "labelMenuLightMode";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBoxTitle, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxColorTitle, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelTitle, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(152, 23);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackColor = System.Drawing.Color.White;
            this.pictureBoxTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxTitle.TabIndex = 1;
            this.pictureBoxTitle.TabStop = false;
            this.pictureBoxTitle.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // textBoxColorTitle
            // 
            this.textBoxColorTitle.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorTitle.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorTitle.MaxLength = 12;
            this.textBoxColorTitle.Name = "textBoxColorTitle";
            this.textBoxColorTitle.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorTitle.TabIndex = 2;
            this.textBoxColorTitle.Text = "#ffffff";
            this.textBoxColorTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(95, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(54, 15);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "labelTitle";
            // 
            // groupBoxColorsDarkMode
            // 
            this.groupBoxColorsDarkMode.AutoSize = true;
            this.groupBoxColorsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColorsDarkMode.Controls.Add(this.tableLayoutPanelDarkMode);
            this.groupBoxColorsDarkMode.Location = new System.Drawing.Point(3, 614);
            this.groupBoxColorsDarkMode.MaximumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsDarkMode.MinimumSize = new System.Drawing.Size(385, 0);
            this.groupBoxColorsDarkMode.Name = "groupBoxColorsDarkMode";
            this.groupBoxColorsDarkMode.Size = new System.Drawing.Size(385, 630);
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
            this.tableLayoutPanelDarkMode.Controls.Add(this.buttonColorsDefaultDarkMode, 0, 21);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel39, 0, 20);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel38, 0, 19);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel37, 0, 18);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel36, 0, 17);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel35, 0, 16);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel34, 0, 15);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel33, 0, 14);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel32, 0, 13);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel31, 0, 12);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel12, 0, 11);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel10, 0, 8);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel9, 0, 7);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel8, 0, 6);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelScrollbarDarkMode, 0, 10);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.tableLayoutPanelDarkMode.Controls.Add(this.labelMenuDarkMode, 0, 1);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel6, 0, 4);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanelDarkMode.Controls.Add(this.checkBoxDarkModeAlwaysOn, 0, 0);
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanel3, 0, 9);
            this.tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDarkMode.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            this.tableLayoutPanelDarkMode.RowCount = 22;
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
            this.tableLayoutPanelDarkMode.Size = new System.Drawing.Size(379, 608);
            this.tableLayoutPanelDarkMode.TabIndex = 0;
            // 
            // buttonColorsDefaultDarkMode
            // 
            this.buttonColorsDefaultDarkMode.AutoSize = true;
            this.buttonColorsDefaultDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonColorsDefaultDarkMode.Location = new System.Drawing.Point(3, 580);
            this.buttonColorsDefaultDarkMode.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonColorsDefaultDarkMode.Name = "buttonColorsDefaultDarkMode";
            this.buttonColorsDefaultDarkMode.Size = new System.Drawing.Size(180, 25);
            this.buttonColorsDefaultDarkMode.TabIndex = 2;
            this.buttonColorsDefaultDarkMode.Text = "buttonColorsDarkModeDefault";
            this.buttonColorsDefaultDarkMode.UseVisualStyleBackColor = true;
            this.buttonColorsDefaultDarkMode.Click += new System.EventHandler(this.ButtonDefaultColorsDark_Click);
            // 
            // tableLayoutPanel39
            // 
            this.tableLayoutPanel39.AutoSize = true;
            this.tableLayoutPanel39.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel39.ColumnCount = 3;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel39.Controls.Add(this.pictureBoxArrowHoverBackgroundDarkMode, 0, 0);
            this.tableLayoutPanel39.Controls.Add(this.textBoxColorArrowHoverBackgroundDarkMode, 1, 0);
            this.tableLayoutPanel39.Controls.Add(this.labelColorDarkModeArrowHoverBackground, 2, 0);
            this.tableLayoutPanel39.Location = new System.Drawing.Point(3, 551);
            this.tableLayoutPanel39.Name = "tableLayoutPanel39";
            this.tableLayoutPanel39.RowCount = 1;
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel39.Size = new System.Drawing.Size(342, 23);
            this.tableLayoutPanel39.TabIndex = 2;
            // 
            // pictureBoxArrowHoverBackgroundDarkMode
            // 
            this.pictureBoxArrowHoverBackgroundDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // labelColorDarkModeArrowHoverBackground
            // 
            this.labelColorDarkModeArrowHoverBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelColorDarkModeArrowHoverBackground.AutoSize = true;
            this.labelColorDarkModeArrowHoverBackground.Location = new System.Drawing.Point(95, 4);
            this.labelColorDarkModeArrowHoverBackground.Name = "labelColorDarkModeArrowHoverBackground";
            this.labelColorDarkModeArrowHoverBackground.Size = new System.Drawing.Size(244, 15);
            this.labelColorDarkModeArrowHoverBackground.TabIndex = 0;
            this.labelColorDarkModeArrowHoverBackground.Text = "labelColorDarkModeArrowHoverBackground";
            // 
            // tableLayoutPanel38
            // 
            this.tableLayoutPanel38.AutoSize = true;
            this.tableLayoutPanel38.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel38.ColumnCount = 3;
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.Controls.Add(this.pictureBoxArrowHoverDarkMode, 0, 0);
            this.tableLayoutPanel38.Controls.Add(this.textBoxColorArrowHoverDarkMode, 1, 0);
            this.tableLayoutPanel38.Controls.Add(this.labelColorDarkModeArrowHover, 2, 0);
            this.tableLayoutPanel38.Location = new System.Drawing.Point(3, 522);
            this.tableLayoutPanel38.Name = "tableLayoutPanel38";
            this.tableLayoutPanel38.RowCount = 1;
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel38.Size = new System.Drawing.Size(278, 23);
            this.tableLayoutPanel38.TabIndex = 2;
            // 
            // pictureBoxArrowHoverDarkMode
            // 
            this.pictureBoxArrowHoverDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.AutoSize = true;
            this.tableLayoutPanel37.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel37.ColumnCount = 3;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel37.Controls.Add(this.pictureBoxArrowClickBackgroundDarkMode, 0, 0);
            this.tableLayoutPanel37.Controls.Add(this.textBoxColorArrowClickBackgroundDarkMode, 1, 0);
            this.tableLayoutPanel37.Controls.Add(this.labelColorDarkModeArrowClickBackground, 2, 0);
            this.tableLayoutPanel37.Location = new System.Drawing.Point(3, 493);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 1;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel37.Size = new System.Drawing.Size(336, 23);
            this.tableLayoutPanel37.TabIndex = 2;
            // 
            // pictureBoxArrowClickBackgroundDarkMode
            // 
            this.pictureBoxArrowClickBackgroundDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel36
            // 
            this.tableLayoutPanel36.AutoSize = true;
            this.tableLayoutPanel36.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel36.ColumnCount = 3;
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel36.Controls.Add(this.pictureBoxArrowClickDarkMode, 0, 0);
            this.tableLayoutPanel36.Controls.Add(this.textBoxColorArrowClickDarkMode, 1, 0);
            this.tableLayoutPanel36.Controls.Add(this.labelColorDarkModeArrowClick, 2, 0);
            this.tableLayoutPanel36.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanel36.Name = "tableLayoutPanel36";
            this.tableLayoutPanel36.RowCount = 1;
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel36.Size = new System.Drawing.Size(272, 23);
            this.tableLayoutPanel36.TabIndex = 2;
            // 
            // pictureBoxArrowClickDarkMode
            // 
            this.pictureBoxArrowClickDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel35
            // 
            this.tableLayoutPanel35.AutoSize = true;
            this.tableLayoutPanel35.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel35.ColumnCount = 3;
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel35.Controls.Add(this.pictureBoxArrowDarkMode, 0, 0);
            this.tableLayoutPanel35.Controls.Add(this.textBoxColorArrowDarkMode, 1, 0);
            this.tableLayoutPanel35.Controls.Add(this.labelColorDarkModeArrow, 2, 0);
            this.tableLayoutPanel35.Location = new System.Drawing.Point(3, 435);
            this.tableLayoutPanel35.Name = "tableLayoutPanel35";
            this.tableLayoutPanel35.RowCount = 1;
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel35.Size = new System.Drawing.Size(246, 23);
            this.tableLayoutPanel35.TabIndex = 2;
            // 
            // pictureBoxArrowDarkMode
            // 
            this.pictureBoxArrowDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel34
            // 
            this.tableLayoutPanel34.AutoSize = true;
            this.tableLayoutPanel34.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel34.ColumnCount = 3;
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel34.Controls.Add(this.pictureBoxSliderArrowsAndTrackHoverDarkMode, 0, 0);
            this.tableLayoutPanel34.Controls.Add(this.textBoxColorSliderArrowsAndTrackHoverDarkMode, 1, 0);
            this.tableLayoutPanel34.Controls.Add(this.labelColorDarkModeSliderArrowsAndTrackHover, 2, 0);
            this.tableLayoutPanel34.Location = new System.Drawing.Point(3, 406);
            this.tableLayoutPanel34.Name = "tableLayoutPanel34";
            this.tableLayoutPanel34.RowCount = 1;
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel34.Size = new System.Drawing.Size(361, 23);
            this.tableLayoutPanel34.TabIndex = 2;
            // 
            // pictureBoxSliderArrowsAndTrackHoverDarkMode
            // 
            this.pictureBoxSliderArrowsAndTrackHoverDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.AutoSize = true;
            this.tableLayoutPanel33.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel33.ColumnCount = 3;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel33.Controls.Add(this.pictureBoxSliderHoverDarkMode, 0, 0);
            this.tableLayoutPanel33.Controls.Add(this.textBoxColorSliderHoverDarkMode, 1, 0);
            this.tableLayoutPanel33.Controls.Add(this.labelColorDarkModeSliderHover, 2, 0);
            this.tableLayoutPanel33.Location = new System.Drawing.Point(3, 377);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 1;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel33.Size = new System.Drawing.Size(275, 23);
            this.tableLayoutPanel33.TabIndex = 2;
            // 
            // pictureBoxSliderHoverDarkMode
            // 
            this.pictureBoxSliderHoverDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.AutoSize = true;
            this.tableLayoutPanel32.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel32.ColumnCount = 3;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.Controls.Add(this.pictureBoxSliderDraggingDarkMode, 0, 0);
            this.tableLayoutPanel32.Controls.Add(this.textBoxColorSliderDraggingDarkMode, 1, 0);
            this.tableLayoutPanel32.Controls.Add(this.labelColorDarkModeSliderDragging, 2, 0);
            this.tableLayoutPanel32.Location = new System.Drawing.Point(3, 348);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel32.Size = new System.Drawing.Size(292, 23);
            this.tableLayoutPanel32.TabIndex = 2;
            // 
            // pictureBoxSliderDraggingDarkMode
            // 
            this.pictureBoxSliderDraggingDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.AutoSize = true;
            this.tableLayoutPanel31.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel31.ColumnCount = 3;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.Controls.Add(this.pictureBoxSliderDarkMode, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.textBoxColorSliderDarkMode, 1, 0);
            this.tableLayoutPanel31.Controls.Add(this.labelColorDarkModeSlider, 2, 0);
            this.tableLayoutPanel31.Location = new System.Drawing.Point(3, 319);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel31.Size = new System.Drawing.Size(243, 23);
            this.tableLayoutPanel31.TabIndex = 2;
            // 
            // pictureBoxSliderDarkMode
            // 
            this.pictureBoxSliderDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.pictureBoxScrollbarBackgroundDarkMode, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.textBoxColorScrollbarBackgroundDarkMode, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.labelColorDarkModeScrollbarBackground, 2, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 290);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(324, 23);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // pictureBoxScrollbarBackgroundDarkMode
            // 
            this.pictureBoxScrollbarBackgroundDarkMode.BackColor = System.Drawing.Color.White;
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
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.pictureBoxSelectedItemBorderDarkMode, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelSelectedItemBorderDarkMode, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.textBoxColorSelectedItemBorderDarkMode, 1, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 217);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(288, 23);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // pictureBoxSelectedItemBorderDarkMode
            // 
            this.pictureBoxSelectedItemBorderDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.pictureColorBoxSelectedItemDarkMode, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.labelSelectedItemDarkMode, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.textBoxColorSelecetedItemDarkMode, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 188);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(253, 23);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // pictureColorBoxSelectedItemDarkMode
            // 
            this.pictureColorBoxSelectedItemDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.pictureBoxOpenFolderBorderDarkMode, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelOpenFolderBorderDarkMode, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.textBoxColorOpenFolderBorderDarkMode, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 159);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(282, 23);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // pictureBoxOpenFolderBorderDarkMode
            // 
            this.pictureBoxOpenFolderBorderDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // labelScrollbarDarkMode
            // 
            this.labelScrollbarDarkMode.AutoSize = true;
            this.labelScrollbarDarkMode.Location = new System.Drawing.Point(3, 272);
            this.labelScrollbarDarkMode.Name = "labelScrollbarDarkMode";
            this.labelScrollbarDarkMode.Size = new System.Drawing.Size(133, 15);
            this.labelScrollbarDarkMode.TabIndex = 3;
            this.labelScrollbarDarkMode.Text = "labelScrollbarDarkMode";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.pictureBoxOpenFolderDarkMode, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelOpenFolderDarkMode, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.textBoxColorOpenFolderDarkMode, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 130);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(247, 23);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // pictureBoxOpenFolderDarkMode
            // 
            this.pictureBoxOpenFolderDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // labelMenuDarkMode
            // 
            this.labelMenuDarkMode.AutoSize = true;
            this.labelMenuDarkMode.Location = new System.Drawing.Point(3, 25);
            this.labelMenuDarkMode.Name = "labelMenuDarkMode";
            this.labelMenuDarkMode.Size = new System.Drawing.Size(118, 15);
            this.labelMenuDarkMode.TabIndex = 3;
            this.labelMenuDarkMode.Text = "labelMenuDarkMode";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.pictureBoxSearchFieldDarkMode, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelSearchFieldDarkMode, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBoxColorSearchFieldDarkMode, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(245, 23);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // pictureBoxSearchFieldDarkMode
            // 
            this.pictureBoxSearchFieldDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxBackgroundDarkMode, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelBackgroundDarkMode, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxColorBackgroundDarkMode, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(249, 23);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // pictureBoxBackgroundDarkMode
            // 
            this.pictureBoxBackgroundDarkMode.BackColor = System.Drawing.Color.White;
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
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxTitleDarkMode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTitleDarkMode, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxColorTitleDarkMode, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 23);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pictureBoxTitleDarkMode
            // 
            this.pictureBoxTitleDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxTitleDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTitleDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitleDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTitleDarkMode.Name = "pictureBoxTitleDarkMode";
            this.pictureBoxTitleDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxTitleDarkMode.TabIndex = 1;
            this.pictureBoxTitleDarkMode.TabStop = false;
            this.pictureBoxTitleDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelTitleDarkMode
            // 
            this.labelTitleDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitleDarkMode.AutoSize = true;
            this.labelTitleDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelTitleDarkMode.Name = "labelTitleDarkMode";
            this.labelTitleDarkMode.Size = new System.Drawing.Size(109, 15);
            this.labelTitleDarkMode.TabIndex = 0;
            this.labelTitleDarkMode.Text = "labelTitleDarkMode";
            // 
            // textBoxColorTitleDarkMode
            // 
            this.textBoxColorTitleDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorTitleDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorTitleDarkMode.MaxLength = 12;
            this.textBoxColorTitleDarkMode.Name = "textBoxColorTitleDarkMode";
            this.textBoxColorTitleDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorTitleDarkMode.TabIndex = 2;
            this.textBoxColorTitleDarkMode.Text = "#ffffff";
            this.textBoxColorTitleDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            this.checkBoxDarkModeAlwaysOn.AutoSize = true;
            this.checkBoxDarkModeAlwaysOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(438, 19);
            this.checkBoxDarkModeAlwaysOn.TabIndex = 0;
            this.checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            this.checkBoxDarkModeAlwaysOn.CheckedChanged += new System.EventHandler(this.CheckBoxDarkModeAlwaysOnCheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBoxWarningDarkMode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelWarningDarkMode, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxColorWarningDarkMode, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 246);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(230, 23);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // pictureBoxWarningDarkMode
            // 
            this.pictureBoxWarningDarkMode.BackColor = System.Drawing.Color.White;
            this.pictureBoxWarningDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxWarningDarkMode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWarningDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWarningDarkMode.Name = "pictureBoxWarningDarkMode";
            this.pictureBoxWarningDarkMode.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxWarningDarkMode.TabIndex = 1;
            this.pictureBoxWarningDarkMode.TabStop = false;
            this.pictureBoxWarningDarkMode.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // labelWarningDarkMode
            // 
            this.labelWarningDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWarningDarkMode.AutoSize = true;
            this.labelWarningDarkMode.Location = new System.Drawing.Point(95, 4);
            this.labelWarningDarkMode.Name = "labelWarningDarkMode";
            this.labelWarningDarkMode.Size = new System.Drawing.Size(132, 15);
            this.labelWarningDarkMode.TabIndex = 0;
            this.labelWarningDarkMode.Text = "labelWarningDarkMode";
            // 
            // textBoxColorWarningDarkMode
            // 
            this.textBoxColorWarningDarkMode.Location = new System.Drawing.Point(23, 0);
            this.textBoxColorWarningDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxColorWarningDarkMode.MaxLength = 12;
            this.textBoxColorWarningDarkMode.Name = "textBoxColorWarningDarkMode";
            this.textBoxColorWarningDarkMode.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorWarningDarkMode.TabIndex = 2;
            this.textBoxColorWarningDarkMode.Text = "#ffffff";
            this.textBoxColorWarningDarkMode.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(438, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(438, 19);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1484, 1061);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
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
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackground)).EndInit();
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHover)).EndInit();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackground)).EndInit();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClick)).EndInit();
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).EndInit();
            this.tableLayoutPanel25.ResumeLayout(false);
            this.tableLayoutPanel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHover)).EndInit();
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHover)).EndInit();
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDragging)).EndInit();
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).EndInit();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackground)).EndInit();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorder)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItem)).EndInit();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorder)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchField)).EndInit();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.groupBoxColorsDarkMode.ResumeLayout(false);
            this.groupBoxColorsDarkMode.PerformLayout();
            this.tableLayoutPanelDarkMode.ResumeLayout(false);
            this.tableLayoutPanelDarkMode.PerformLayout();
            this.tableLayoutPanel39.ResumeLayout(false);
            this.tableLayoutPanel39.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverBackgroundDarkMode)).EndInit();
            this.tableLayoutPanel38.ResumeLayout(false);
            this.tableLayoutPanel38.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowHoverDarkMode)).EndInit();
            this.tableLayoutPanel37.ResumeLayout(false);
            this.tableLayoutPanel37.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickBackgroundDarkMode)).EndInit();
            this.tableLayoutPanel36.ResumeLayout(false);
            this.tableLayoutPanel36.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowClickDarkMode)).EndInit();
            this.tableLayoutPanel35.ResumeLayout(false);
            this.tableLayoutPanel35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDarkMode)).EndInit();
            this.tableLayoutPanel34.ResumeLayout(false);
            this.tableLayoutPanel34.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderArrowsAndTrackHoverDarkMode)).EndInit();
            this.tableLayoutPanel33.ResumeLayout(false);
            this.tableLayoutPanel33.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderHoverDarkMode)).EndInit();
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel32.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDraggingDarkMode)).EndInit();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSliderDarkMode)).EndInit();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrollbarBackgroundDarkMode)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemBorderDarkMode)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorBoxSelectedItemDarkMode)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderBorderDarkMode)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolderDarkMode)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFieldDarkMode)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundDarkMode)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleDarkMode)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningDarkMode)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelMenuLightMode;
        private System.Windows.Forms.Label labelMenuDarkMode;
        private System.Windows.Forms.Label labelScrollbarDarkMode;
        private System.Windows.Forms.Label labelScrollbarLightMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.PictureBox pictureBoxScrollbarBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorScrollbarBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeScrollbarBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItemBorderDarkMode;
        private System.Windows.Forms.Label labelSelectedItemBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.PictureBox pictureColorBoxSelectedItemDarkMode;
        private System.Windows.Forms.Label labelSelectedItemDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderBorderDarkMode;
        private System.Windows.Forms.Label labelOpenFolderBorderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderDarkMode;
        private System.Windows.Forms.Label labelOpenFolderDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox pictureBoxSearchFieldDarkMode;
        private System.Windows.Forms.Label labelSearchFieldDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundDarkMode;
        private System.Windows.Forms.Label labelBackgroundDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxTitleDarkMode;
        private System.Windows.Forms.Label labelTitleDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBoxWarningDarkMode;
        private System.Windows.Forms.Label labelWarningDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.PictureBox pictureBoxScrollbarBackground;
        private System.Windows.Forms.TextBox textBoxColorScrollbarBackground;
        private System.Windows.Forms.Label labelScrollbarBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItemBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.PictureBox pictureBoxSelectedItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolderBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.PictureBox pictureBoxOpenFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.PictureBox pictureBoxSearchField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickBackground;
        private System.Windows.Forms.TextBox textBoxColorArrowClickBackground;
        private System.Windows.Forms.Label labelArrowClickBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.PictureBox pictureBoxArrowClick;
        private System.Windows.Forms.TextBox textBoxColorArrowClick;
        private System.Windows.Forms.Label labelArrowClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        private System.Windows.Forms.PictureBox pictureBoxArrow;
        private System.Windows.Forms.TextBox textBoxColorArrow;
        private System.Windows.Forms.Label labelArrow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        private System.Windows.Forms.PictureBox pictureBoxSliderArrowsAndTrackHover;
        private System.Windows.Forms.TextBox textBoxColorSliderArrowsAndTrackHover;
        private System.Windows.Forms.Label labelSliderArrowsAndTrackHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private System.Windows.Forms.PictureBox pictureBoxSliderHover;
        private System.Windows.Forms.TextBox textBoxColorSliderHover;
        private System.Windows.Forms.Label labelSliderHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.PictureBox pictureBoxSliderDragging;
        private System.Windows.Forms.TextBox textBoxColorSliderDragging;
        private System.Windows.Forms.Label labelSliderDragging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.PictureBox pictureBoxSlider;
        private System.Windows.Forms.TextBox textBoxColorSlider;
        private System.Windows.Forms.Label labelSlider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverBackground;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverBackground;
        private System.Windows.Forms.Label labelArrowHoverBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.PictureBox pictureBoxArrowHover;
        private System.Windows.Forms.TextBox textBoxColorArrowHover;
        private System.Windows.Forms.Label labelArrowHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel39;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowHoverBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel38;
        private System.Windows.Forms.PictureBox pictureBoxArrowHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel37;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickBackgroundDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowClickBackgroundDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowClickBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel36;
        private System.Windows.Forms.PictureBox pictureBoxArrowClickDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowClickDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrowClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel35;
        private System.Windows.Forms.PictureBox pictureBoxArrowDarkMode;
        private System.Windows.Forms.TextBox textBoxColorArrowDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeArrow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel34;
        private System.Windows.Forms.PictureBox pictureBoxSliderArrowsAndTrackHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderArrowsAndTrackHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderArrowsAndTrackHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel33;
        private System.Windows.Forms.PictureBox pictureBoxSliderHoverDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderHoverDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderHover;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.PictureBox pictureBoxSliderDraggingDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderDraggingDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSliderDragging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.PictureBox pictureBoxSliderDarkMode;
        private System.Windows.Forms.TextBox textBoxColorSliderDarkMode;
        private System.Windows.Forms.Label labelColorDarkModeSlider;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button buttonColorsDefaultDarkMode;
    }
}