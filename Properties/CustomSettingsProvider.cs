// <copyright file="CustomSettingsProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Properties
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    using SystemTrayMenu.Utilities;

    internal class CustomSettingsProvider : SettingsProvider
    {
        private const string NameOf = "name";
        private const string SerializeAs = "serializeAs";
        private const string Config = "configuration";
        private const string UserSettings = "userSettings";
        private const string Setting = "setting";

        private static readonly string? SettingsFullTypeName = typeof(Settings).FullName;

        private bool loaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSettingsProvider"/> class.
        /// Loads the file into memory.
        /// </summary>
        public CustomSettingsProvider()
        {
            SettingsDictionary = new Dictionary<string, SettingStruct>();
        }

        /// <summary>
        /// Gets the setting key this is returning must set before the settings are used.
        /// e.g. <c>Properties.Settings.Default.SettingsKey = @"C:\temp\user.config";</c>.
        /// </summary>
        public static string UserConfigPath => Path.Combine(
                Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $"SystemTrayMenu"),
                $"user-{Environment.MachineName}.config");

        public static string? ConfigPathAssembly
        {
            get
            {
                Assembly? assembly = Assembly.GetEntryAssembly();
                if (assembly != null)
                {
                    string? location = Directory.GetParent(assembly.Location)?.FullName;
                    if (location != null)
                    {
                        return Path.Combine(location, $"user.config");
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets override.
        /// </summary>
        public override string ApplicationName
        {
            get => Assembly.GetExecutingAssembly().ManifestModule.Name;

            set
            {
                // do nothing
            }
        }

        /// <summary>
        /// Gets or sets in memory storage of the settings values.
        /// </summary>
        private Dictionary<string, SettingStruct> SettingsDictionary { get; set; }

        public static bool IsActivatedConfigPathAssembly()
        {
            return IsConfigPathAssembly();
        }

        public static void ActivateConfigPathAssembly()
        {
            CreateEmptyConfigIfNotExists(ConfigPathAssembly);
        }

        public static void DeactivateConfigPathAssembly()
        {
            if (IsConfigPathAssembly())
            {
                try
                {
                    File.Delete(ConfigPathAssembly!);
                }
                catch (Exception ex)
                {
                    Log.Warn($"Could not delete {ConfigPathAssembly}", ex);
                }
            }
        }

        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="config">config.</param>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(ApplicationName, config);
        }

        /// <summary>
        /// Must override this, this is the bit that matches up the designer properties to the dictionary values.
        /// </summary>
        /// <param name="context">context.</param>
        /// <param name="collection">collection.</param>
        /// <returns>SettingsPropertyValueCollection.</returns>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            // load the file
            if (!loaded)
            {
                loaded = true;
                LoadValuesFromFile();
            }

            // collection that will be returned.
            SettingsPropertyValueCollection values = new();

            // itterate thought the properties we get from the designer, checking to see if the setting is in the dictionary
            foreach (SettingsProperty setting in collection)
            {
                SettingsPropertyValue value = new(setting)
                {
                    IsDirty = false,
                };

                // need the type of the value for the strong typing
                string? typename = setting.PropertyType.FullName;
                if (typename != null)
                {
                    Type? t = Type.GetType(typename);
                    if (t != null)
                    {
                        if (SettingsDictionary.ContainsKey(setting.Name))
                        {
                            value.SerializedValue = SettingsDictionary[setting.Name].Value;
                            value.PropertyValue = Convert.ChangeType(SettingsDictionary[setting.Name].Value, t, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            // use defaults in the case where there are no settings yet
                            value.SerializedValue = setting.DefaultValue;
                            value.PropertyValue = Convert.ChangeType(setting.DefaultValue, t, CultureInfo.InvariantCulture);
                        }

                        values.Add(value);
                    }
                }
            }

            return values;
        }

        /// <summary>
        /// Must override this, this is the bit that does the saving to file.  Called when Settings.Save() is called.
        /// </summary>
        /// <param name="context">context.</param>
        /// <param name="collection">collection.</param>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            // grab the values from the collection parameter and update the values in our dictionary.
            foreach (SettingsPropertyValue value in collection)
            {
                SettingStruct setting = new()
                {
                    Value = value.PropertyValue == null ? string.Empty : value.PropertyValue.ToString() ?? string.Empty,
                    Name = value.Name,
                    SerializeAs = value.Property.SerializeAs.ToString(),
                };

                if (!SettingsDictionary.ContainsKey(value.Name))
                {
                    SettingsDictionary.Add(value.Name, setting);
                }
                else
                {
                    SettingsDictionary[value.Name] = setting;
                }
            }

            // now that our local dictionary is up-to-date, save it to disk.
            SaveValuesToFile();
        }

        /// <summary>
        /// Creates an empty user.config file...looks like the one MS creates.
        /// This could be overkill a simple key/value pairing would probably do.
        /// </summary>
        private static void CreateEmptyConfigIfNotExists(string? path)
        {
            if (!File.Exists(path))
            {
                if (string.IsNullOrEmpty(SettingsFullTypeName))
                {
                    Log.Warn($"Failed to store config for group {SettingsFullTypeName ?? "<null>"}", new());
                    return;
                }

                string? dir = Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(dir) || string.IsNullOrEmpty(path))
                {
                    Log.Warn($"Failed to store config in directory {path ?? "<null>"}", new());
                    return;
                }

                // if the config file is not where it's supposed to be create a new one.
                XDocument doc = new();
                XDeclaration declaration = new("1.0", "utf-8", "true");
                XElement config = new(Config);
                XElement userSettings = new(UserSettings);
                XElement group = new(SettingsFullTypeName);
                userSettings.Add(group);
                config.Add(userSettings);
                doc.Add(config);
                doc.Declaration = declaration;

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                try
                {
                    doc.Save(path);
                }
                catch (Exception ex)
                {
                    Log.Warn($"Failed to store config at assembly location {path}", ex);
                }
            }
        }

        private static bool IsConfigPathAssembly()
        {
            bool isconfigPathAssembly = false;
            try
            {
                isconfigPathAssembly = File.Exists(ConfigPathAssembly);
            }
            catch (Exception ex)
            {
                Log.Warn("IsConfigPathAssembly failed", ex);
            }

            return isconfigPathAssembly;
        }

        private static XDocument? LoadOrGetNew(string path)
        {
            XDocument? xDocument = null;
            try
            {
                xDocument = XDocument.Load(path);
            }
            catch (Exception exceptionWarning)
            {
                Log.Warn($"Could not load {path}", exceptionWarning);
                try
                {
                    File.Delete(path);
                    CreateEmptyConfigIfNotExists(path);
                    xDocument = XDocument.Load(path);
                }
                catch (Exception exceptionError)
                {
                    Log.Error($"Could not delete and create {path}", exceptionError);
                }
            }

            return xDocument;
        }

        /// <summary>
        /// Loads the values of the file into memory.
        /// </summary>
        private void LoadValuesFromFile()
        {
            CreateEmptyConfigIfNotExists(UserConfigPath);

            // load the xml
            XDocument? configXml;
            if (IsConfigPathAssembly())
            {
                configXml = LoadOrGetNew(ConfigPathAssembly!);
            }
            else
            {
                configXml = LoadOrGetNew(UserConfigPath);
            }

            if (configXml != null && !string.IsNullOrEmpty(SettingsFullTypeName))
            {
                // get all of the <setting name="..." serializeAs="..."> elements.
                IEnumerable<XElement>? settingElements = configXml.Element(Config)?.Element(UserSettings)?.Element(SettingsFullTypeName)?.Elements(Setting);

                // iterate through, adding them to the dictionary, (checking for nulls, xml no likey nulls)
                // using "String" as default serializeAs...just in case, no real good reason.
                if (settingElements != null)
                {
                    foreach (XElement element in settingElements)
                    {
                        string? name = element.Attribute(NameOf)?.Value;
                        if (name != null)
                        {
                            string? serializeAs = element.Attribute(SerializeAs)?.Value;
                            SettingStruct newSetting = new()
                            {
                                Name = element.Attribute(NameOf) == null ? string.Empty : name,
                                SerializeAs = serializeAs ?? "String",
                                Value = element.Value ?? string.Empty,
                            };
                            SettingsDictionary.Add(name, newSetting);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the in memory dictionary to the user config file.
        /// </summary>
        private void SaveValuesToFile()
        {
            // load the current xml from the file.
            XDocument? configXml;
            if (IsConfigPathAssembly())
            {
                configXml = LoadOrGetNew(ConfigPathAssembly!);
            }
            else
            {
                configXml = LoadOrGetNew(UserConfigPath);
            }

            if (configXml != null && !string.IsNullOrEmpty(SettingsFullTypeName))
            {
                // get the settings group (e.g. <Company.Project.Desktop.Settings>)
                XElement? settingsSection = configXml.Element(Config)?.Element(UserSettings)?.Element(SettingsFullTypeName);

                // iterate though the dictionary, either updating the value or adding the new setting.
                foreach (KeyValuePair<string, SettingStruct> entry in SettingsDictionary)
                {
                    XElement? setting = settingsSection?.Elements().FirstOrDefault(e => e.Attribute(NameOf)?.Value == entry.Key);
                    if (setting == null)
                    {
                        // this can happen if a new setting is added via the .settings designer.
                        XElement newSetting = new(Setting);
                        newSetting.Add(new XAttribute(NameOf, entry.Value.Name));
                        newSetting.Add(new XAttribute(SerializeAs, entry.Value.SerializeAs));
                        newSetting.Value = entry.Value.Value ?? string.Empty;
                        settingsSection?.Add(newSetting);
                    }
                    else
                    {
                        // update the value if it exists.
                        setting.Value = entry.Value.Value ?? string.Empty;
                    }
                }

                if (IsConfigPathAssembly())
                {
                    configXml.Save(ConfigPathAssembly!);
                }

                configXml.Save(UserConfigPath);
            }
        }

        /// <summary>
        /// Helper struct.
        /// </summary>
        internal struct SettingStruct
        {
            internal string Name;
            internal string SerializeAs;
            internal string Value;
        }
    }
}
