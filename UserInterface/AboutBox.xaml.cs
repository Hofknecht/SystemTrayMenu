// <copyright file="AboutBox.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Win32;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// Logic of About window.
    /// </summary>
    public partial class AboutBox : Window
    {
        private static readonly Regex RegexUrl = new(@"(?#Protocol)(?:(?:ht|f)tp(?:s?)\:\/\/|~/|/)?(?#Username:Password)(?:\w+:\w+@)?(?#Subdomains)(?:(?:[-\w]+\.)+(?#TopLevel Domains)(?:com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|travel|[a-z]{2}))(?#Port)(?::[\d]{1,5})?(?#Directories)(?:(?:(?:/(?:[-\w~!$+|.,=]|%[a-f\d]{2})+)+|/)+|\?|#)?(?#Query)(?:(?:\?(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)(?:&(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)*)*(?#Anchor)(?:#(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)?");

        private string? entryAssemblyName;
        private string? callingAssemblyName;
        private string? executingAssemblyName;
        private NameValueCollection entryAssemblyAttribCollection = new();

        public AboutBox()
        {
            InitializeComponent();

            Loaded += AboutBox_Load;

            TabPanelDetails.Visibility = Visibility.Collapsed;
            buttonSystemInfo.Visibility = Visibility.Collapsed;
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
            get => (string)AppTitleLabel.Content;
            set => AppTitleLabel.Content = value;
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
            get => (string)AppDescriptionLabel.Content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppDescriptionLabel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AppDescriptionLabel.Visibility = Visibility.Visible;
                    AppDescriptionLabel.Content = value;
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
            get => (string)AppVersionLabel.Content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppVersionLabel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AppVersionLabel.Visibility = Visibility.Visible;
                    AppVersionLabel.Content = value;
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
            get => (string)AppCopyrightLabel.Content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    AppCopyrightLabel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AppCopyrightLabel.Visibility = Visibility.Visible;
                    AppCopyrightLabel.Content = value;
                }
            }
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
            get => new TextRange(MoreRichTextBox.Document.ContentStart, MoreRichTextBox.Document.ContentEnd).Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MoreRichTextBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MoreRichTextBox.Visibility = Visibility.Visible;
                    MoreRichTextBox.Document.Blocks.Clear();

                    Paragraph para = new ();

                    // Parse string to detect hyperlinks and add handlers to them
                    // See: https://mycsharp.de/forum/threads/97560/erledigt-dynamische-hyperlinks-in-wpf-flowdocument?page=1
                    int lastPos = 0;
                    foreach (Match match in RegexUrl.Matches(value).Cast<Match>())
                    {
                        if (match.Index != lastPos)
                        {
                            para.Inlines.Add(value[lastPos..match.Index]);
                        }

                        var link = new Hyperlink(new Run(match.Value))
                        {
                            NavigateUri = new Uri(match.Value),
                        };
                        link.Click += MoreRichTextBox_LinkClicked;

                        para.Inlines.Add(link);

                        lastPos = match.Index + match.Length;
                    }

                    if (lastPos < value.Length)
                    {
                        para.Inlines.Add(value[lastPos..]);
                    }

                    MoreRichTextBox.Document.Blocks.Add(para);
                }
            }
        }

        // <summary>
        // returns the entry assembly for the current application domain
        // </summary>
        // <remarks>
        // This is usually read-only, but in some weird cases (Smart Client apps)
        // you won't have an entry assembly, so you may want to set this manually.
        // </remarks>
        private Assembly? AppEntryAssembly { get; set; }

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
            Version? assemblyVersion = a.GetName().Version;
            DateTime dt;

            if (forceFileDate || assemblyVersion == null)
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
            Regex r = new(@"(\.Assembly|\.)(?<ColumnText>[^.]*)Attribute$", RegexOptions.IgnoreCase);

            foreach (object attrib in a.GetCustomAttributes(false))
            {
                typeName = attrib.GetType().ToString();
                name = r.Match(typeName).Groups["ColumnText"].ToString();
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
                    version = a.GetName().Version?.ToString() ?? version;
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
                RegistryKey? rk = Registry.LocalMachine.OpenSubKey(keyName);
                if (rk != null)
                {
                    strSysInfoPath = (string)rk.GetValue(subKeyRef, string.Empty)!;
                }
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
        private static void Populate(ListView lvw, string key, string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                lvw.Items.Add(new AssemblyDetailsListViewItem
                {
                    Key = key,
                    Value = value,
                });
            }
        }

        // <summary>
        // populate details for a single assembly
        // </summary>
        private static void PopulateAssemblyDetails(Assembly? a, ListView lvw)
        {
            lvw.Items.Clear();

            if (a != null)
            {
                Populate(lvw, "Image Runtime Version", a.ImageRuntimeVersion);

                NameValueCollection nvc = AssemblyAttribs(a);
                foreach (string strKey in nvc)
                {
                    Populate(lvw, strKey, nvc[strKey]);
                }
            }
        }

        // <summary>
        // matches assembly by Assembly.GetName.ColumnText; returns nothing if no match
        // </summary>
        private static Assembly? MatchAssemblyByName(string assemblyName)
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

        private void TabPanelDetails_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabPanelDetails.SelectedItem == TabPageAssemblyDetails)
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
                    Title,
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
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
            Populate(AppInfoListView, "Application ColumnText", Assembly.GetEntryAssembly()?.GetName().Name);
            Populate(AppInfoListView, "Application Base", d.SetupInformation.ApplicationBase);
            Populate(AppInfoListView, "Friendly ColumnText", d.FriendlyName);
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

            AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.Items.IndexOf(entryAssemblyName);
        }

        // <summary>
        // populate Assembly Information listview with summary view for a specific assembly
        // </summary>
        private void PopulateAssemblySummary(Assembly a)
        {
            NameValueCollection nvc = AssemblyAttribs(a);

            string strAssemblyName = a.GetName().Name ?? "?";
            string strAssemblyNameFull = strAssemblyName;
            if (strAssemblyName == callingAssemblyName)
            {
                strAssemblyNameFull += " (calling)";
            }
            else if (strAssemblyName == executingAssemblyName)
            {
                strAssemblyNameFull += " (executing)";
            }
            else if (strAssemblyName == entryAssemblyName)
            {
                strAssemblyNameFull += " (entry)";
            }

            AssemblyInfoListView.Items.Add(new AssemblyInfoListViewItem
            {
                Name = strAssemblyNameFull,
                Version = nvc["version"] ?? string.Empty,
                Built = nvc["builddate"] ?? string.Empty,
                CodeBase = nvc["codebase"] ?? string.Empty,
                Tag = strAssemblyName,
            });
            AssemblyNamesComboBox.Items.Add(strAssemblyName);
        }

        // <summary>
        // retrieves a cached value from the entry assembly attribute lookup collection
        // </summary>
        private string? EntryAssemblyAttrib(string strName)
        {
            if (entryAssemblyAttribCollection[strName] == null)
            {
                return "<Assembly: Assembly" + strName + "(\"\")>";
            }
            else
            {
                return entryAssemblyAttribCollection[strName]?.ToString(CultureInfo.InvariantCulture);
            }
        }

        // <summary>
        // Populate all the form labels with tokenized text
        // </summary>
        private void PopulateLabels()
        {
            // get entry assembly attribs
            entryAssemblyAttribCollection = AssemblyAttribs(AppEntryAssembly!);

            // replace all labels and window title
            Title = ReplaceTokens(Title);
            AppTitle = ReplaceTokens(AppTitle);
            if (AppDescriptionLabel.Visibility == Visibility.Visible)
            {
                AppDescription = ReplaceTokens(AppDescription);
            }

            if (AppCopyrightLabel.Visibility == Visibility.Visible)
            {
                AppCopyright = ReplaceTokens(AppCopyright);
            }

            if (AppVersionLabel.Visibility == Visibility.Visible)
            {
                AppVersion = ReplaceTokens(AppVersion);
            }

            if (AppDateLabel.Visibility == Visibility.Visible)
            {
                AppDateLabel.Content = ReplaceTokens((string)AppDateLabel.Content);
            }

            if (MoreRichTextBox.Visibility == Visibility.Visible)
            {
                AppMoreInfo = ReplaceTokens(AppMoreInfo);
            }
        }

        // <summary>
        // perform assemblyinfo to string replacements on labels
        // </summary>
        private string ReplaceTokens(string s)
        {
            return s.Replace("%title%", EntryAssemblyAttrib("title"), StringComparison.InvariantCulture)
                .Replace("%copyright%", EntryAssemblyAttrib("copyright"), StringComparison.InvariantCulture)
                .Replace("%description%", EntryAssemblyAttrib("description"), StringComparison.InvariantCulture)
                .Replace("%company%", EntryAssemblyAttrib("company"), StringComparison.InvariantCulture)
                .Replace("%product%", EntryAssemblyAttrib("product"), StringComparison.InvariantCulture)
                .Replace("%trademark%", EntryAssemblyAttrib("trademark"), StringComparison.InvariantCulture)
                .Replace("%year%", DateTime.Now.Year.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture)
                .Replace("%version%", EntryAssemblyAttrib("version"), StringComparison.InvariantCulture)
                .Replace("%builddate%", EntryAssemblyAttrib("builddate"), StringComparison.InvariantCulture);
        }

        // <summary>
        // things to do when form is loaded
        // </summary>
        private void AboutBox_Load(object sender, RoutedEventArgs e)
        {
            // if the user didn't provide an assembly, try to guess which one is the entry assembly
            AppEntryAssembly ??= Assembly.GetEntryAssembly()!;
            AppEntryAssembly ??= Assembly.GetExecutingAssembly();

            executingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            // for web hosted apps, GetEntryAssembly = nothing
            entryAssemblyName = Assembly.GetEntryAssembly()?.GetName().Name;

            TabPanelDetails.Visibility = Visibility.Collapsed;
            if (MoreRichTextBox.Visibility != Visibility.Visible)
            {
                Height -= MoreRichTextBox.Height;
            }

            Dispatcher.Invoke(
                DispatcherPriority.Loaded,
                new Action(delegate
                {
                    Cursor = Cursors.Wait;
                    PopulateLabels();
                    Cursor = null;
                }));
        }

        // <summary>
        // expand about dialog to show additional advanced details
        // </summary>
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MoreRichTextBox.Visibility = Visibility.Collapsed;
            TabPanelDetails.Visibility = Visibility.Visible;
            buttonSystemInfo.Visibility = Visibility.Visible;
            buttonDetails.Visibility = Visibility.Collapsed;
            UpdateLayout(); // Force AutoSize to update the height before switching to manual mode
            SizeToContent = SizeToContent.Manual;
            ResizeMode = ResizeMode.CanResizeWithGrip;
            TabPanelDetails.Height = double.NaN;
            if (Width < 580)
            {
                Width = 580;
            }

            PopulateAssemblies();
            PopulateAppInfo();
            Cursor = null;
        }

        // <summary>
        // for detailed system info, launch the external Microsoft system info app
        // </summary>
        private void SysInfoButton_Click(object sender, RoutedEventArgs e)
        {
            ShowSysInfo();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // <summary>
        // if an assembly is double-clicked, go to the detail page for that assembly
        // </summary>
        private void AssemblyInfoListView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssemblyInfoListView.SelectedItems.Count > 0)
            {
                string? strAssemblyName = Convert.ToString(((AssemblyInfoListViewItem?)AssemblyInfoListView.SelectedItems[0])?.Tag, CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(strAssemblyName))
                {
                    AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.Items.IndexOf(strAssemblyName);
                    TabPanelDetails.SelectedItem = TabPageAssemblyDetails;
                }
            }
        }

        // <summary>
        // if a new assembly is selected from the combo box, show details for that assembly
        // </summary>
        private void AssemblyNamesComboBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            string? strAssemblyName = Convert.ToString(AssemblyNamesComboBox.SelectedItem, CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(strAssemblyName))
            {
                PopulateAssemblyDetails(MatchAssemblyByName(strAssemblyName), AssemblyDetailsListView);
            }
        }

        // <summary>
        // sort the assembly list by column
        // </summary>
        private void AssemblyInfoListView_ColumnClick(object sender, RoutedEventArgs e)
        {
            AssemblyInfoListView.Items.SortDescriptions.Clear();
            AssemblyInfoListView.Items.SortDescriptions.Add(new SortDescription(
                ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString(),
                ListSortDirection.Ascending));
            AssemblyInfoListView.Items.Refresh();
        }

        // <summary>
        // launch any http:// or mailto: links clicked in the body of the rich text box
        // </summary>
        private void MoreRichTextBox_LinkClicked(object sender, RoutedEventArgs e)
        {
            Log.ProcessStart(((Hyperlink)sender).NavigateUri.ToString());
        }

        /// <summary>
        /// Type for ListView items.
        /// </summary>
        private class AssemblyDetailsListViewItem
        {
            public string Key { get; set; } = string.Empty;

            public string Value { get; set; } = string.Empty;
        }

        /// <summary>
        /// Type for ListView items.
        /// </summary>
        private class AssemblyInfoListViewItem
        {
            public string Name { get; set; } = string.Empty;

            public string Version { get; set; } = string.Empty;

            public string Built { get; set; } = string.Empty;

            public string CodeBase { get; set; } = string.Empty;

            public string Tag { get; set; } = string.Empty;
        }
    }
}
