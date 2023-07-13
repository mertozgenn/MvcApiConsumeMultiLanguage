using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using UI.Languages;

namespace UI.Utils.Localization
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
