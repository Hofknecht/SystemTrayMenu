using System.Globalization;
using System.Resources;
using System.Threading;
using SystemTrayMenu.Properties;

namespace SystemTrayMenu.Helper
{
    internal static class Language
    {
        internal static CultureInfo Culture;

        internal static void Initialize()
        {
            if (string.IsNullOrEmpty(
                Settings.Default.CurrentCultureInfoName))
            {
                Settings.Default.CurrentCultureInfoName = "en";
                CultureInfo currentCulture =
                    Thread.CurrentThread.CurrentCulture;
                foreach (string language in MenuDefines.Languages)
                {
                    string twoLetter = currentCulture.Name.
                    Substring(0, 2);
                    if (language == currentCulture.Name ||
                        language == twoLetter)
                    {
                        Settings.Default.
                            CurrentCultureInfoName = language;
                    }
                }
                Settings.Default.Save();
            }

            Culture = CultureInfo.CreateSpecificCulture(
                Settings.Default.CurrentCultureInfoName);
        }

        internal static string Translate(string id)
        {
            ResourceManager rm = new ResourceManager(
                "SystemTrayMenu.Resources.lang",
                typeof(Menu).Assembly);
            return rm.GetString(id, Culture);
        }
    }
}
