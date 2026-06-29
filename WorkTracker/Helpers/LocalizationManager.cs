using System.Globalization;
using WorkTracker.Resources.Localization;

namespace WorkTracker.Helpers
{
    public static class LocalizationManager
    {
        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            AppResources.Culture = culture;
        }
    }
}
