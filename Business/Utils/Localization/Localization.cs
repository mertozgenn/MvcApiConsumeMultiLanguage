using Business.Languages;
using Microsoft.Extensions.Localization;

namespace Business.Utils.Localization
{
    public class Localization
    {
        private static IStringLocalizer<Lang> _stringLocalizer;

        public Localization(IStringLocalizer<Lang> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public static string GetValue(string key)
        {
            return _stringLocalizer[key];
        }
    }
}
