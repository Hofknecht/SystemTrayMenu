using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.UserInterface
{
    /// <summary>
    /// Generic, self-contained About Box dialog
    /// </summary>
    /// <remarks>
    /// Jeff Atwood
    /// http://www.codinghorror.com
    /// converted to C# by Scott Ferguson
    /// http://www.forestmoon.com
    /// </remarks>
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            buttonOk.Text = Language.Translate("buttonOk");
            buttonDetails.Text = Language.Translate("buttonDetails");
            buttonSystemInfo.Text = Language.Translate("buttonSystemInfo");
        }

        private bool _IsPainted = false;
        private string _EntryAssemblyName;
        private string _CallingAssemblyName;
        private string _ExecutingAssemblyName;
        private Assembly _EntryAssembly;
        private NameValueCollection _EntryAssemblyAttribCollection;
        private int _MinWindowHeight;

        // <summary>
        // returns the entry assembly for the current application domain
        // </summary>
        // <remarks>
        // This is usually read-only, but in some weird cases (Smart Client apps) 
        // you won't have an entry assembly, so you may want to set this manually.
        // </remarks>
        public Assembly AppEntryAssembly
        {
            get => _EntryAssembly;
            set => _EntryAssembly = value;
        }

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
            if (!string.IsNullOrEmpty(a.Location))
            {
                assemblyLastWriteTime = File.GetLastWriteTime(a.Location);
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
        private static DateTime AssemblyBuildDate(Assembly a, bool ForceFileDate)
        {
            Version AssemblyVersion = a.GetName().Version;
            DateTime dt;

            if (ForceFileDate)
            {
                dt = AssemblyLastWriteTime(a);
            }
            else
            {
                dt = DateTime.Parse("01/01/2000", CultureInfo.InvariantCulture).AddDays(AssemblyVersion.Build).AddSeconds(AssemblyVersion.Revision * 2);
                if (TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)))
                {
                    dt = dt.AddHours(1);
                }
                if (dt > DateTime.Now || AssemblyVersion.Build < 730 || AssemblyVersion.Revision == 0)
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
            string TypeName;
            string Name;
            string Value;
            NameValueCollection nvc = new NameValueCollection();
            Regex r = new Regex(@"(\.Assembly|\.)(?<Name>[^.]*)Attribute$", RegexOptions.IgnoreCase);

            foreach (object attrib in a.GetCustomAttributes(false))
            {
                TypeName = attrib.GetType().ToString();
                Name = r.Match(TypeName).Groups["Name"].ToString();
                Value = "";
                switch (TypeName)
                {
                    case "System.CLSCompliantAttribute":
                        Value = ((CLSCompliantAttribute)attrib).IsCompliant.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Diagnostics.DebuggableAttribute":
                        Value = ((System.Diagnostics.DebuggableAttribute)attrib).IsJITTrackingEnabled.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyCompanyAttribute":
                        Value = ((AssemblyCompanyAttribute)attrib).Company.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyConfigurationAttribute":
                        Value = ((AssemblyConfigurationAttribute)attrib).Configuration.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyCopyrightAttribute":
                        Value = ((AssemblyCopyrightAttribute)attrib).Copyright.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDefaultAliasAttribute":
                        Value = ((AssemblyDefaultAliasAttribute)attrib).DefaultAlias.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDelaySignAttribute":
                        Value = ((AssemblyDelaySignAttribute)attrib).DelaySign.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyDescriptionAttribute":
                        Value = ((AssemblyDescriptionAttribute)attrib).Description.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyInformationalVersionAttribute":
                        Value = ((AssemblyInformationalVersionAttribute)attrib).InformationalVersion.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyKeyFileAttribute":
                        Value = ((AssemblyKeyFileAttribute)attrib).KeyFile.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyProductAttribute":
                        Value = ((AssemblyProductAttribute)attrib).Product.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyTrademarkAttribute":
                        Value = ((AssemblyTrademarkAttribute)attrib).Trademark.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Reflection.AssemblyTitleAttribute":
                        Value = ((AssemblyTitleAttribute)attrib).Title.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Resources.NeutralResourcesLanguageAttribute":
                        Value = ((System.Resources.NeutralResourcesLanguageAttribute)attrib).CultureName.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Resources.SatelliteContractVersionAttribute":
                        Value = ((System.Resources.SatelliteContractVersionAttribute)attrib).Version.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.ComCompatibleVersionAttribute":
                        {
                            System.Runtime.InteropServices.ComCompatibleVersionAttribute x;
                            x = ((System.Runtime.InteropServices.ComCompatibleVersionAttribute)attrib);
                            Value = x.MajorVersion + "." + x.MinorVersion + "." + x.RevisionNumber + "." + x.BuildNumber; break;
                        }
                    case "System.Runtime.InteropServices.ComVisibleAttribute":
                        Value = ((System.Runtime.InteropServices.ComVisibleAttribute)attrib).Value.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.GuidAttribute":
                        Value = ((System.Runtime.InteropServices.GuidAttribute)attrib).Value.ToString(CultureInfo.InvariantCulture); break;
                    case "System.Runtime.InteropServices.TypeLibVersionAttribute":
                        {
                            System.Runtime.InteropServices.TypeLibVersionAttribute x;
                            x = ((System.Runtime.InteropServices.TypeLibVersionAttribute)attrib);
                            Value = x.MajorVersion + "." + x.MinorVersion; break;
                        }
                    case "System.Security.AllowPartiallyTrustedCallersAttribute":
                        Value = "(Present)"; break;
                    default:
                        // debug.writeline("** unknown assembly attribute '" + TypeName + "'")
                        Value = TypeName; break;
                }

                if (nvc[Name] == null)
                {
                    nvc.Add(Name, Value);
                }
            }

            // add some extra values that are not in the AssemblyInfo, but nice to have
            // codebase
            try
            {
                nvc.Add("CodeBase", a.CodeBase.Replace("file:///", ""));
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
                nvc.Add("Location", a.Location);
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
                version = a.GetName().Version.ToString();
            }
            nvc.Add("Version", version);

            nvc.Add("FullName", a.FullName);

            return nvc;
        }

        // <summary>
        // reads an HKLM Windows Registry key value
        // </summary>
        private static string RegistryHklmValue(string KeyName, string SubKeyRef)
        {
            string strSysInfoPath = string.Empty;
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(KeyName);
                strSysInfoPath = (string)rk.GetValue(SubKeyRef, string.Empty);
            }
            catch (Exception ex)
            {
                if (ex is SecurityException ||
                    ex is UnauthorizedAccessException ||
                    ex is IOException)
                {
                    Log.Warn($"KeyName:'{KeyName}' SubKeyRef:'{SubKeyRef}'", ex);
                }
                else
                {
                    throw;
                }
            }

            return strSysInfoPath;
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
                MessageBox.Show("System Information is unavailable at this time." +
                    Environment.NewLine +
                    Environment.NewLine +
                    "(couldn't find path for Microsoft System Information Tool in the registry.)",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Log.ProcessStart(strSysInfoPath);
        }

        // <summary>
        // populate a listview with the specified key and value strings
        // </summary>
        private static void Populate(ListView lvw, string Key, string Value)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                ListViewItem lvi = new ListViewItem
                {
                    Text = Key
                };
                lvi.SubItems.Add(Value);
                lvw.Items.Add(lvi);
            }
        }

        // <summary>
        // populates the Application Information listview
        // </summary>
        private void PopulateAppInfo()
        {
            AppDomain d = AppDomain.CurrentDomain;
            Populate(AppInfoListView, "Application Name", d.SetupInformation.ApplicationName);
            Populate(AppInfoListView, "Application Base", d.SetupInformation.ApplicationBase);
            Populate(AppInfoListView, "Cache Path", d.SetupInformation.CachePath);
            Populate(AppInfoListView, "Configuration File", d.SetupInformation.ConfigurationFile);
            Populate(AppInfoListView, "Dynamic Base", d.SetupInformation.DynamicBase);
            Populate(AppInfoListView, "Friendly Name", d.FriendlyName);
            Populate(AppInfoListView, "License File", d.SetupInformation.LicenseFile);
            Populate(AppInfoListView, "private Bin Path", d.SetupInformation.PrivateBinPath);
            Populate(AppInfoListView, "Shadow Copy Directories", d.SetupInformation.ShadowCopyDirectories);
            Populate(AppInfoListView, " ", " ");
            Populate(AppInfoListView, "Entry Assembly", _EntryAssemblyName);
            Populate(AppInfoListView, "Executing Assembly", _ExecutingAssemblyName);
            Populate(AppInfoListView, "Calling Assembly", _CallingAssemblyName);
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
            AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.FindStringExact(_EntryAssemblyName);
        }

        // <summary>
        // populate Assembly Information listview with summary view for a specific assembly
        // </summary>
        private void PopulateAssemblySummary(Assembly a)
        {
            NameValueCollection nvc = AssemblyAttribs(a);

            string strAssemblyName = a.GetName().Name;

            ListViewItem lvi = new ListViewItem
            {
                Text = strAssemblyName,
                Tag = strAssemblyName
            };
            if (strAssemblyName == _CallingAssemblyName)
            {
                lvi.Text += " (calling)";
            }
            if (strAssemblyName == _ExecutingAssemblyName)
            {
                lvi.Text += " (executing)";
            }
            if (strAssemblyName == _EntryAssemblyName)
            {
                lvi.Text += " (entry)";
            }
            lvi.SubItems.Add(nvc["version"]);
            lvi.SubItems.Add(nvc["builddate"]);
            lvi.SubItems.Add(nvc["codebase"]);
            //lvi.SubItems.Add(AssemblyVersion(a))
            //lvi.SubItems.Add(AssemblyBuildDatestring(a, true))
            //lvi.SubItems.Add(AssemblyCodeBase(a))
            AssemblyInfoListView.Items.Add(lvi);
            AssemblyNamesComboBox.Items.Add(strAssemblyName);
        }

        // <summary>
        // retrieves a cached value from the entry assembly attribute lookup collection
        // </summary>
        private string EntryAssemblyAttrib(string strName)
        {
            if (_EntryAssemblyAttribCollection[strName] == null)
            {
                return "<Assembly: Assembly" + strName + "(\"\")>";
            }
            else
            {
                return _EntryAssemblyAttribCollection[strName].ToString(CultureInfo.InvariantCulture);
            }
        }

        // <summary>
        // Populate all the form labels with tokenized text
        // </summary>
        private void PopulateLabels()
        {
            // get entry assembly attribs
            _EntryAssemblyAttribCollection = AssemblyAttribs(_EntryAssembly);

            // set icon from parent, if present
            if (Owner == null)
            {
                //ImagePictureBox.Visible = false;
                //AppTitleLabel.Left = AppCopyrightLabel.Left;
                //AppDescriptionLabel.Left = AppCopyrightLabel.Left;
            }
            else
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
            s = s.Replace("%title%", EntryAssemblyAttrib("title"));
            s = s.Replace("%copyright%", EntryAssemblyAttrib("copyright"));
            s = s.Replace("%description%", EntryAssemblyAttrib("description"));
            s = s.Replace("%company%", EntryAssemblyAttrib("company"));
            s = s.Replace("%product%", EntryAssemblyAttrib("product"));
            s = s.Replace("%trademark%", EntryAssemblyAttrib("trademark"));
            s = s.Replace("%year%", DateTime.Now.Year.ToString(CultureInfo.InvariantCulture));
            s = s.Replace("%version%", EntryAssemblyAttrib("version"));
            s = s.Replace("%builddate%", EntryAssemblyAttrib("builddate"));
            return s;
        }

        // <summary>
        // populate details for a single assembly
        // </summary>
        private void PopulateAssemblyDetails(Assembly a, ListView lvw)
        {
            lvw.Items.Clear();

            // this assembly property is only available in framework versions 1.1+
            Populate(lvw, "Image Runtime Version", a.ImageRuntimeVersion);
            Populate(lvw, "Loaded from GAC", a.GlobalAssemblyCache.ToString(CultureInfo.InvariantCulture));

            NameValueCollection nvc = AssemblyAttribs(a);
            foreach (string strKey in nvc)
            {
                Populate(lvw, strKey, nvc[strKey]);
            }
        }

        // <summary>
        // matches assembly by Assembly.GetName.Name; returns nothing if no match
        // </summary>
        private Assembly MatchAssemblyByName(string AssemblyName)
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (a.GetName().Name == AssemblyName)
                {
                    return a;
                }
            }
            return null;
        }

        // <summary>
        // things to do when form is loaded
        // </summary>
        private void AboutBox_Load(object sender, EventArgs e)
        {
            // if the user didn't provide an assembly, try to guess which one is the entry assembly
            if (_EntryAssembly == null)
            {
                _EntryAssembly = Assembly.GetEntryAssembly();
            }
            if (_EntryAssembly == null)
            {
                _EntryAssembly = Assembly.GetExecutingAssembly();
            }

            _ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            _CallingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            // for web hosted apps, GetEntryAssembly = nothing
            _EntryAssemblyName = Assembly.GetEntryAssembly().GetName().Name;

            _MinWindowHeight = AppCopyrightLabel.Top + AppCopyrightLabel.Height + buttonOk.Height + 30;

            TabPanelDetails.Visible = false;
            if (!MoreRichTextBox.Visible)
            {
                Height = Height - MoreRichTextBox.Height;
            }
        }

        // <summary>
        // things to do when form is FIRST painted
        // </summary>
        private void AboutBox_Paint(object sender, PaintEventArgs e)
        {
            if (!_IsPainted)
            {
                _IsPainted = true;
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
            private readonly int _intCol;
            private readonly bool _IsAscending = true;

            public ListViewItemComparer()
            {
                _intCol = 0;
                _IsAscending = true;
            }

            public ListViewItemComparer(int column, bool ascending)
            {
                if (column < 0)
                {
                    _IsAscending = false;
                }
                else
                {
                    _IsAscending = ascending;
                }
                _intCol = Math.Abs(column) - 1;
            }

            public int Compare(object x, object y)
            {
                int intResult = string.Compare(
                    ((ListViewItem)x).SubItems[_intCol].Text,
                    ((ListViewItem)y).SubItems[_intCol].Text,
                    CultureInfo.InvariantCulture, CompareOptions.None);
                if (_IsAscending)
                {
                    return intResult;
                }
                else
                {
                    return -intResult;
                }
            }
        }

        private void TabPanelDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabPanelDetails.SelectedTab == TabPageAssemblyDetails)
            {
                AssemblyNamesComboBox.Focus();
            }
        }

    }
}