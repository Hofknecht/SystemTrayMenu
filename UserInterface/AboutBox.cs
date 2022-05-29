// <copyright file="AboutBox.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// Generic, self-contained About Box dialog.
    /// </summary>
    /// <remarks>
    /// Jeff Atwood
    /// http://www.codinghorror.com
    /// converted to C# by Scott Ferguson
    /// http://www.forestmoon.com
    /// .
    /// </remarks>
    internal partial class AboutBox : Form
    {
        private bool isPainted;
        private string entryAssemblyName;
        private string callingAssemblyName;
        private string executingAssemblyName;
        private NameValueCollection entryAssemblyAttribCollection;

        public AboutBox()
        {
            InitializeComponent();
            buttonOk.Text = Translator.GetText("OK");
            buttonDetails.Text = Translator.GetText("Details");
            buttonSystemInfo.Text = Translator.GetText("System Info");
            Text = Translator.GetText("About SystemTrayMenu");
        }

        // <summary>
        // returns the entry assembly for the current application domain
        // </summary>
        // <remarks>
        // This is usually read-only, but in some weird cases (Smart Client apps)
        // you won't have an entry assembly, so you may want to set this manually.
        // </remarks>
        public Assembly AppEntryAssembly { get; set; }

        // <summary>
        // single line of text to show in the application title section of the about box dialog
        // </summary>
        // <remarks>
        // defaults to "%title%"
        // %title% = Assembly: AssemblyTitle
        // </remarks>
        public string AppTitle
        {
            get => AppTitleLabel.Text;
            set => AppTitleLabel.Text = value;
        }

        // <summary>
        // single line of text to show in the description section of the about box dialog
        // </summary>
        // <remarks>
        // defaults to "%description%"
        // %description% = Assembly: AssemblyDescription
        // </remarks>
        public string AppDescription
        {
            get => AppDescriptionLabel.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppDescriptionLabel.Visible = false;
                }
                else
                {
                    AppDescriptionLabel.Visible = true;
                    AppDescriptionLabel.Text = value;
                }
            }
        }

        // <summary>
        // single line of text to show in the version section of the about dialog
        // </summary>
        // <remarks>
        // defaults to "Version %version%"
        // %version% = Assembly: AssemblyVersion
        // </remarks>
        public string AppVersion
        {
            get => AppVersionLabel.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppVersionLabel.Visible = false;
                }
                else
                {
                    AppVersionLabel.Visible = true;
                    AppVersionLabel.Text = value;
                }
            }
        }

        // <summary>
        // single line of text to show in the copyright section of the about dialog
        // </summary>
        // <remarks>
        // defaults to "Copyright © %year%, %company%"
        // %company% = Assembly: AssemblyCompany
        // %year% = current 4-digit year
        // </remarks>
        public string AppCopyright
        {
            get => AppCopyrightLabel.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppCopyrightLabel.Visible = false;
                }
                else
                {
                    AppCopyrightLabel.Visible = true;
                    AppCopyrightLabel.Text = value;
                }
            }
        }

        // <summary>
        // intended for the default 32x32 application icon to appear in the upper left of the about dialog
        // </summary>
        // <remarks>
        // if you open this form using .ShowDialog(Owner), the icon can be derived from the owning form
        // </remarks>
        public Image AppImage
        {
            get => ImagePictureBox.Image;
            set => ImagePictureBox.Image = value;
        }

        // <summary>
        // multiple lines of miscellaneous text to show in rich text box
        // </summary>
        // <remarks>
        // defaults to "%product% is %copyright%, %trademark%"
        // %product% = Assembly: AssemblyProduct
        // %copyright% = Assembly: AssemblyCopyright
        // %trademark% = Assembly: AssemblyTrademark
        // </remarks>
        public string AppMoreInfo
        {
            get => MoreRichTextBox.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MoreRichTextBox.Visible = false;
                }
                else
                {
                    MoreRichTextBox.Visible = true;
                    MoreRichTextBox.Text = value;
                }
            }
        }

        // <summary>
        // determines if the "Details" (advanced assembly details) button is shown
        // </summary>
        public bool AppDetailsButton
        {
            get => buttonDetails.Visible;
            set => buttonDetails.Visible = value;
        }

        // <summary>
        // exception-safe retrieval of LastWriteTime for this assembly.
        // </summary>
        // <returns>File.GetLastWriteTime, or DateTime.MaxValue if exception was encountered.</returns>
        private static DateTime AssemblyLastWriteTime(Assembly a)
        {
            DateTime assemblyLastWriteTime = DateTime.MaxValue;

            // Location property not available for dynamic assemblies
            if (!a.IsDynamic)
            {
                if (!string.IsNullOrEmpty(a.Location))
                {
                    assemblyLastWriteTime = File.GetLastWriteTime(a.Location);
                }
            }

            return assemblyLastWriteTime;
        }

        // <summary>
        // returns DateTime this Assembly was last built. Will attempt to calculate from build number, if possible.
        // If not, the actual LastWriteTime on the assembly file will be returned.
        // </summary>
        // <param name="a">Assembly to get build date for</param>
        // <param name="ForceFileDate">Don't attempt to use the build number to calculate the date</param>
        // <returns>DateTime this assembly was last built</returns>
        private static DateTime AssemblyBuildDate(Assembly a, bool forceFileDate)
        {
            Version assemblyVersion = a.GetName().Version;
            DateTime dt;

            if (forceFileDate)
            {
                dt = AssemblyLastWriteTime(a);
            }
            else
            {
                dt = DateTime.Parse("01/01/2000", CultureInfo.InvariantCulture).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);
#pragma warning disable CS0618
                if (TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)))
#pragma warning restore CS0618
                {
                    dt = dt.AddHours(1);
                }

                if (dt > DateTime.Now || assemblyVersion.Build < 730 || assemblyVersion.Revision == 0)
                {
                    dt = AssemblyLastWriteTime(a);
                }
            }

            return dt;
        }

        // <summary>
        // returns string name / string value pair of all attribs
        // for specified assembly
        // </summary>
        // <remarks>
        // note that Assembly* values are pulled from AssemblyInfo file in project folder
        //
        // Trademark       = AssemblyTrademark string
        // Debuggable      = true
        // GUID            = 7FDF68D5-8C6F-44C9-B391-117B5AFB5467
        // CLSCompliant    = true
        // Product         = AssemblyProduct string
        // Copyright       = AssemblyCopyright string
        // Company         = AssemblyCompany string
        // Description     = AssemblyDescription string
        // Title           = AssemblyTitle string
        // </remarks>
        private static NameValueCollection AssemblyAttribs(Assembly a)
        {
            string typeName;
            string name;
            string value;
            NameValueCollection nvc = new();
            Regex r = new(@"(\.Assembly|\.)(?<Name>[^.]*)Attribute$", RegexOptions.IgnoreCase);

            foreach (object attrib in a.GetCustomAttributes(false))
            {
                typeName = attrib.GetType().ToString();
                name = r.Match(typeName).Groups["Name"].ToString();
                value = string.Empty;
                switch (typeName)
                {
                    case "System.CLSCompliantAttribute":
                        value = ((CLSCompliantAttribute)attrib).IsCompliant.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Diagnostics.DebuggableAttribute":
                        value = ((System.Diagnostics.DebuggableAttribute)attrib).IsJITTrackingEnabled.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyCompanyAttribute":
                        value = ((AssemblyCompanyAttribute)attrib).Company.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyConfigurationAttribute":
                        value = ((AssemblyConfigurationAttribute)attrib).Configuration.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyCopyrightAttribute":
                        value = ((AssemblyCopyrightAttribute)attrib).Copyright.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDefaultAliasAttribute":
                        value = ((AssemblyDefaultAliasAttribute)attrib).DefaultAlias.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDelaySignAttribute":
                        value = ((AssemblyDelaySignAttribute)attrib).DelaySign.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDescriptionAttribute":
                        value = ((AssemblyDescriptionAttribute)attrib).Description.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyInformationalVersionAttribute":
                        value = ((AssemblyInformationalVersionAttribute)attrib).InformationalVersion.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyKeyFileAttribute":
                        value = ((AssemblyKeyFileAttribute)attrib).KeyFile.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyProductAttribute":
                        value = ((AssemblyProductAttribute)attrib).Product.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyTrademarkAttribute":
                        value = ((AssemblyTrademarkAttribute)attrib).Trademark.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyTitleAttribute":
                        value = ((AssemblyTitleAttribute)attrib).Title.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Resources.NeutralResourcesLanguageAttribute":
                        value = ((System.Resources.NeutralResourcesLanguageAttribute)attrib).CultureName.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Resources.SatelliteContractVersionAttribute":
                        value = ((System.Resources.SatelliteContractVersionAttribute)attrib).Version.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.ComCompatibleVersionAttribute":
                        {
                            System.Runtime.InteropServices.ComCompatibleVersionAttribute x;
                            x = (System.Runtime.InteropServices.ComCompatibleVersionAttribute)attrib;
                            value = x.MajorVersion + "." + x.MinorVersion + "." + x.RevisionNumber + "." + x.BuildNumber;
                            break;
                        }

                    case "System.Runtime.InteropServices.ComVisibleAttribute":
                        value = ((System.Runtime.InteropServices.ComVisibleAttribute)attrib).Value.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.GuidAttribute":
                        value = ((System.Runtime.InteropServices.GuidAttribute)attrib).Value.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.TypeLibVersionAttribute":
                        {
                            System.Runtime.InteropServices.TypeLibVersionAttribute x;
                            x = (System.Runtime.InteropServices.TypeLibVersionAttribute)attrib;
                            value = x.MajorVersion + "." + x.MinorVersion;
                            break;
                        }

                    case "System.Security.AllowPartiallyTrustedCallersAttribute":
                        value = "(Present)"; break;
                    default:
                        // debug.writeline("** unknown assembly attribute '" + TypeName + "'")
                        value = typeName; break;
                }

                if (nvc[name] == null)
                {
                    nvc.Add(name, value);
                }
            }

            // add some extra values that are not in the AssemblyInfo, but nice to have
            // codebase
            try
            {
                if (!a.IsDynamic)
                {
                    nvc.Add("CodeBase", a.Location.Replace("file:///", string.Empty, StringComparison.InvariantCulture));
                }
            }
            catch (NotSupportedException)
            {
                nvc.Add("CodeBase", "(not supported)");
            }

            // build date
            DateTime dt = AssemblyBuildDate(a, false);
            if (dt == DateTime.MaxValue)
            {
                nvc.Add("BuildDate", "(unknown)");
            }
            else
            {
                nvc.Add("BuildDate", dt.ToString("yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture));
            }

            // location
            try
            {
                if (!a.IsDynamic)
                {
                    nvc.Add("Location", a.Location);
                }
            }
            catch (NotSupportedException)
            {
                nvc.Add("Location", "(not supported)");
            }

            string version = "(unknown)";
            AssemblyName assemblyName = a.GetName();
            if (assemblyName.Version != null &&
                (assemblyName.Version.Major != 0 || assemblyName.Version.Minor != 0))
            {
                if (!a.IsDynamic)
                {
                    version = a.GetName().Version.ToString();
                }
            }

            nvc.Add("Version", version);

            if (!a.IsDynamic)
            {
                nvc.Add("FullName", a.FullName);
            }

            return nvc;
        }

        // <summary>
        // reads an HKLM Windows Registry key value
        // </summary>
        private static string RegistryHklmValue(string keyName, string subKeyRef)
        {
            string strSysInfoPath = string.Empty;
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(keyName);
                strSysInfoPath = (string)rk.GetValue(subKeyRef, string.Empty);
            }
            catch (Exception ex)
            {
                Log.Warn($"KeyName:'{keyName}' SubKeyRef:'{subKeyRef}'", ex);
            }

            return strSysInfoPath;
        }

        // <summary>
        // populate a listview with the specified key and value strings
        // </summary>
        private static void Populate(ListView lvw, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                ListViewItem lvi = new()
                {
                    Text = key,
                };
                lvi.SubItems.Add(value);
                lvw.Items.Add(lvi);
            }
        }

        // <summary>
        // populate details for a single assembly
        // </summary>
        private static void PopulateAssemblyDetails(Assembly a, ListView lvw)
        {
            lvw.Items.Clear();

            Populate(lvw, "Image Runtime Version", a.ImageRuntimeVersion);

            NameValueCollection nvc = AssemblyAttribs(a);
            foreach (string strKey in nvc)
            {
                Populate(lvw, strKey, nvc[strKey]);
            }
        }

        // <summary>
        // matches assembly by Assembly.GetName.Name; returns nothing if no match
        // </summary>
        private static Assembly MatchAssemblyByName(string assemblyName)
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (a.GetName().Name == assemblyName)
                {
                    return a;
                }
            }

            return null;
        }

        private void TabPanelDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabPanelDetails.SelectedTab == TabPageAssemblyDetails)
            {
                AssemblyNamesComboBox.Focus();
            }
        }

        // <summary>
        // launch the MSInfo "system information" application (works on XP, 2003, and Vista)
        // </summary>
        private void ShowSysInfo()
        {
            string strSysInfoPath = RegistryHklmValue(@"SOFTWARE\Microsoft\Shared Tools Location", "MSINFO");
            if (string.IsNullOrEmpty(strSysInfoPath))
            {
                strSysInfoPath = RegistryHklmValue(@"SOFTWARE\Microsoft\Shared Tools\MSINFO", "PATH");
            }

            if (string.IsNullOrEmpty(strSysInfoPath))
            {
                MessageBox.Show(
                    "System Information is unavailable at this time." +
                    Environment.NewLine + Environment.NewLine +
                    "(couldn't find path for Microsoft System Information Tool in the registry.)",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Log.ProcessStart(strSysInfoPath);
        }

        // <summary>
        // populates the Application Information listview
        // </summary>
        private void PopulateAppInfo()
        {
            AppDomain d = AppDomain.CurrentDomain;
            Populate(AppInfoListView, "Application Name", Assembly.GetEntryAssembly().GetName().Name);
            Populate(AppInfoListView, "Application Base", d.SetupInformation.ApplicationBase);
            Populate(AppInfoListView, "Friendly Name", d.FriendlyName);
            Populate(AppInfoListView, " ", " ");
            Populate(AppInfoListView, "Entry Assembly", entryAssemblyName);
            Populate(AppInfoListView, "Executing Assembly", executingAssemblyName);
            Populate(AppInfoListView, "Calling Assembly", callingAssemblyName);
        }

        // <summary>
        // populate Assembly Information listview with ALL assemblies
        // </summary>
        private void PopulateAssemblies()
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                PopulateAssemblySummary(a);
            }

            AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.FindStringExact(entryAssemblyName);
        }

        // <summary>
        // populate Assembly Information listview with summary view for a specific assembly
        // </summary>
        private void PopulateAssemblySummary(Assembly a)
        {
            NameValueCollection nvc = AssemblyAttribs(a);

            string strAssemblyName = a.GetName().Name;

            ListViewItem lvi = new()
            {
                Text = strAssemblyName,
                Tag = strAssemblyName,
            };
            if (strAssemblyName == callingAssemblyName)
            {
                lvi.Text += " (calling)";
            }

            if (strAssemblyName == executingAssemblyName)
            {
                lvi.Text += " (executing)";
            }

            if (strAssemblyName == entryAssemblyName)
            {
                lvi.Text += " (entry)";
            }

            lvi.SubItems.Add(nvc["version"]);
            lvi.SubItems.Add(nvc["builddate"]);
            lvi.SubItems.Add(nvc["codebase"]);
            AssemblyInfoListView.Items.Add(lvi);
            AssemblyNamesComboBox.Items.Add(strAssemblyName);
        }

        // <summary>
        // retrieves a cached value from the entry assembly attribute lookup collection
        // </summary>
        private string EntryAssemblyAttrib(string strName)
        {
            if (entryAssemblyAttribCollection[strName] == null)
            {
                return "<Assembly: Assembly" + strName + "(\"\")>";
            }
            else
            {
                return entryAssemblyAttribCollection[strName].ToString(CultureInfo.InvariantCulture);
            }
        }

        // <summary>
        // Populate all the form labels with tokenized text
        // </summary>
        private void PopulateLabels()
        {
            // get entry assembly attribs
            entryAssemblyAttribCollection = AssemblyAttribs(AppEntryAssembly);

            // set icon from parent, if present
            if (Owner != null)
            {
                Icon = Owner.Icon;
                ImagePictureBox.Image = Icon.ToBitmap();
            }

            // replace all labels and window title
            Text = ReplaceTokens(Text);
            AppTitleLabel.Text = ReplaceTokens(AppTitleLabel.Text);
            if (AppDescriptionLabel.Visible)
            {
                AppDescriptionLabel.Text = ReplaceTokens(AppDescriptionLabel.Text);
            }

            if (AppCopyrightLabel.Visible)
            {
                AppCopyrightLabel.Text = ReplaceTokens(AppCopyrightLabel.Text);
            }

            if (AppVersionLabel.Visible)
            {
                AppVersionLabel.Text = ReplaceTokens(AppVersionLabel.Text);
            }

            if (AppDateLabel.Visible)
            {
                AppDateLabel.Text = ReplaceTokens(AppDateLabel.Text);
            }

            if (MoreRichTextBox.Visible)
            {
                MoreRichTextBox.Text = ReplaceTokens(MoreRichTextBox.Text);
            }
        }

        // <summary>
        // perform assemblyinfo to string replacements on labels
        // </summary>
        private string ReplaceTokens(string s)
        {
            s = s.Replace("%title%", EntryAssemblyAttrib("title"), StringComparison.InvariantCulture);
            s = s.Replace("%copyright%", EntryAssemblyAttrib("copyright"), StringComparison.InvariantCulture);
            s = s.Replace("%description%", EntryAssemblyAttrib("description"), StringComparison.InvariantCulture);
            s = s.Replace("%company%", EntryAssemblyAttrib("company"), StringComparison.InvariantCulture);
            s = s.Replace("%product%", EntryAssemblyAttrib("product"), StringComparison.InvariantCulture);
            s = s.Replace("%trademark%", EntryAssemblyAttrib("trademark"), StringComparison.InvariantCulture);
            s = s.Replace("%year%", DateTime.Now.Year.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture);
            s = s.Replace("%version%", EntryAssemblyAttrib("version"), StringComparison.InvariantCulture);
            s = s.Replace("%builddate%", EntryAssemblyAttrib("builddate"), StringComparison.InvariantCulture);
            return s;
        }

        // <summary>
        // things to do when form is loaded
        // </summary>
        private void AboutBox_Load(object sender, EventArgs e)
        {
            // if the user didn't provide an assembly, try to guess which one is the entry assembly
            if (AppEntryAssembly == null)
            {
                AppEntryAssembly = Assembly.GetEntryAssembly();
            }

            if (AppEntryAssembly == null)
            {
                AppEntryAssembly = Assembly.GetExecutingAssembly();
            }

            executingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            // for web hosted apps, GetEntryAssembly = nothing
            entryAssemblyName = Assembly.GetEntryAssembly().GetName().Name;

            TabPanelDetails.Visible = false;
            if (!MoreRichTextBox.Visible)
            {
                Height -= MoreRichTextBox.Height;
            }
        }

        // <summary>
        // things to do when form is FIRST painted
        // </summary>
        private void AboutBox_Paint(object sender, PaintEventArgs e)
        {
            if (!isPainted)
            {
                isPainted = true;
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                PopulateLabels();
                Cursor.Current = Cursors.Default;
            }
        }

        // <summary>
        // expand about dialog to show additional advanced details
        // </summary>
        private void DetailsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            buttonDetails.Visible = false;
            SuspendLayout();
            MaximizeBox = true;
            FormBorderStyle = FormBorderStyle.Sizable;
            TabPanelDetails.Dock = DockStyle.Fill;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            AutoSize = false;
            SizeGripStyle = SizeGripStyle.Show;
            Size = new Size(580, Size.Height);
            MoreRichTextBox.Visible = false;
            TabPanelDetails.Visible = true;
            buttonSystemInfo.Visible = true;
            PopulateAssemblies();
            PopulateAppInfo();
            CenterToParent();
            ResumeLayout();
            Cursor.Current = Cursors.Default;
        }

        // <summary>
        // for detailed system info, launch the external Microsoft system info app
        // </summary>
        private void SysInfoButton_Click(object sender, EventArgs e)
        {
            ShowSysInfo();
        }

        // <summary>
        // if an assembly is double-clicked, go to the detail page for that assembly
        // </summary>
        private void AssemblyInfoListView_DoubleClick(object sender, EventArgs e)
        {
            string strAssemblyName;
            if (AssemblyInfoListView.SelectedItems.Count > 0)
            {
                strAssemblyName = Convert.ToString(AssemblyInfoListView.SelectedItems[0].Tag, CultureInfo.InvariantCulture);
                AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.FindStringExact(strAssemblyName);
                TabPanelDetails.SelectedTab = TabPageAssemblyDetails;
            }
        }

        // <summary>
        // if a new assembly is selected from the combo box, show details for that assembly
        // </summary>
        private void AssemblyNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strAssemblyName = Convert.ToString(AssemblyNamesComboBox.SelectedItem, CultureInfo.InvariantCulture);
            PopulateAssemblyDetails(MatchAssemblyByName(strAssemblyName), AssemblyDetailsListView);
        }

        // <summary>
        // sort the assembly list by column
        // </summary>
        private void AssemblyInfoListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int intTargetCol = e.Column + 1;

            if (AssemblyInfoListView.Tag != null)
            {
                if (Math.Abs(Convert.ToInt32(AssemblyInfoListView.Tag, CultureInfo.InvariantCulture)) == intTargetCol)
                {
                    intTargetCol = -Convert.ToInt32(AssemblyInfoListView.Tag, CultureInfo.InvariantCulture);
                }
            }

            AssemblyInfoListView.Tag = intTargetCol;
            AssemblyInfoListView.ListViewItemSorter = new ListViewItemComparer(intTargetCol, true);
        }

        // <summary>
        // launch any http:// or mailto: links clicked in the body of the rich text box
        // </summary>
        private void MoreRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Log.ProcessStart(e.LinkText);
        }

        // <summary>
        // things to do when the selected tab is changed
        // </summary>
        private class ListViewItemComparer : System.Collections.IComparer
        {
            private readonly int intCol;
            private readonly bool isAscending = true;

            public ListViewItemComparer()
            {
                intCol = 0;
                isAscending = true;
            }

            public ListViewItemComparer(int column, bool ascending)
            {
                if (column < 0)
                {
                    isAscending = false;
                }
                else
                {
                    isAscending = ascending;
                }

                intCol = Math.Abs(column) - 1;
            }

            public int Compare(object x, object y)
            {
                int intResult = string.Compare(
                    ((ListViewItem)x).SubItems[intCol].Text,
                    ((ListViewItem)y).SubItems[intCol].Text,
                    StringComparison.Ordinal);
                if (isAscending)
                {
                    return intResult;
                }
                else
                {
                    return -intResult;
                }
            }
        }
    }
}