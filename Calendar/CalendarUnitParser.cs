using System.Text.RegularExpressions;

namespace Ocdsi.Calendar
{
    public readonly partial struct CalendarUnit
    {
        internal static readonly Regex re = new("^([\\+-]?\\d+)(\\w+)");

        public static CalendarUnit Parse(string text)
        {
            text = text.Replace(" ", "");
            var match = re.Match(text);
            if (match.Success)
            {
                return new()
                {
                    Value = int.Parse(match.Groups[1].Value),
                    Name = ParseName(match.Groups[2].Value)
                };
            }
            else
            {
                throw new FormatException($"Invalid interval format: {text}");
            }
        }

        internal static UnitName ParseName(string text)
        {
            text = text.ToLower();
            return (text.First()) switch
            {
                'y' => UnitName.Year,
                'm' => UnitName.Month,
                'w' => UnitName.Week,
                'd' => UnitName.Day,
                _ => throw new ArgumentException(text),
            };
        }

        public static bool TryParse(string text, out CalendarUnit result)
        {
            try
            {
                result = Parse(text);
                return true;
            }
            catch (FormatException)
            {
                result = Empty;
                return false;
            }
        }
    }
}
