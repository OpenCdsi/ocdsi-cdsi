using System.Text.RegularExpressions;

namespace Cdsi.Calendar
{
    public static class Date
    {
        private static readonly DateTime _minValue = new(1900, 1, 1);
        private static readonly DateTime _maxValue = new(2999, 12, 31);
        public static DateTime MinValue => _minValue;
        public static DateTime MaxValue => _maxValue;

        public static DateTime Parse(string s, DateTime defaultValue = default)
        {
            var result = defaultValue;

            var p = @"(\d{4})(\d{2})(\d{2})";
            var r = @"$1-$2-$3";

            s = Regex.Replace(s, p, r);
            DateTime.TryParse(s, out result);

            return result;
        }
    }
}
