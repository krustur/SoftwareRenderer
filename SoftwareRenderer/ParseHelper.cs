using System.Globalization;

namespace SoftwareRenderer
{
    public class ParseHelper
    {
        private static CultureInfo _dotFloatCultureInfo;

        static ParseHelper()
        {
            _dotFloatCultureInfo = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            _dotFloatCultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";   
        }

        public static float ParseFloat(string floatString)
        {
            var f = float.Parse(floatString, NumberStyles.Any, _dotFloatCultureInfo);
            return f;

        }
    }
}