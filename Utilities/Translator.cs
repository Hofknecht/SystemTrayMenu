using System.Globalization;
using System.Resources;
using System.Threading;
using SystemTrayMenu.Properties;
using SystemTrayMenu.UserInterface;

namespace SystemTrayMenu.Utilities
{
    internal static class Translator
    {
        internal static CultureInfo Culture;

        internal static void Initialize()
        {
            if (string.IsNullOrEmpty(
                Settings.Default.CurrentCultureInfoName))
            {
                Settings.Default.CurrentCultureInfoName = "en";
                Settings.Default.Save();
            }

            Culture = CultureInfo.CreateSpecificCulture(
                Settings.Default.CurrentCultureInfoName);
        }

        internal static string GetText(string id)
        {
            ResourceManager rm = new ResourceManager(
                "SystemTrayMenu.Resources.lang",
                typeof(Menu).Assembly);
            return rm.GetString(id, Culture);
        }
    }

    public class Language
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
