// <copyright file="LabelNoCopy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Workaround class for "Clipboard" issue on .Net Windows Forms Label (https://github.com/Hofknecht/SystemTrayMenu/issues/5)
    /// On Label MouseDoubleClick the framework will copy the title text into the clipboard.
    /// We avoid this by overriding the Text atrribute and use own _text attribute.
    /// Text will remain unset and clipboard copy will not take place but it is still possible to get/set Text attribute as usual from outside.
    /// (see: https://stackoverflow.com/questions/2519587/is-there-any-way-to-disable-the-double-click-to-copy-functionality-of-a-net-l)
    ///
    /// Note: When you have trouble with the Visual Studio Designer not showing the GUI properly, simply build once and reopen the Designer.
    /// This will place the required files into the Designer's cache and becomes able to show the GUI as usual.
    /// </summary>
    public class LabelNoCopy : Label
    {
        private string text;

        public override string Text
        {
            get => text;
            set
            {
                value ??= string.Empty;

                if (text != value)
                {
                    text = value;
                    Refresh();
                    OnTextChanged(EventArgs.Empty);
                }
            }
        }
    }
}
