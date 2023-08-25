// <copyright file="HintYouCanOpenSettingsInSystemtrayIconRightClickForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    public partial class HintYouCanOpenSettingsInSystemtrayIconRightClickForm : Form
    {
        public HintYouCanOpenSettingsInSystemtrayIconRightClickForm()
        {
            InitializeComponent();
            Text = Translator.GetText("Hint");
            string hintText = "The settings menu can also be opened by right-clicking the icon in the system tray at the bottom right, in case you can no longer open it via the menu.";
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.Text = Translator.GetText(hintText);
            checkBoxDontShowThisHintAgain.Text = Translator.GetText("Don't show this hint again.");
            buttonOK.Text = Translator.GetText("OK");
        }

        internal bool GetShowHintAgain()
        {
            return !checkBoxDontShowThisHintAgain.Checked;
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
