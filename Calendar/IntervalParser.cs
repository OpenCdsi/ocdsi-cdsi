namespace Ocdsi.Calendar
{
    public readonly partial struct Interval
    {
        public static Interval Parse(string text)
        {
            text = text.Replace(" ", "");
            var components = new List<CalendarUnit>();
            do
            {
                components.Add(CalendarUnit.Parse(text));
                text = CalendarUnit.re.Replace(text, "");

            } while (!string.IsNullOrEmpty(text));

            components.Sort(new CalendarlUnitNameComparer());

            return new Interval()
            {
                Components = components.ToArray()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns>If the method returns false then the result variable is set to Interval.Empty. </returns>
        public static bool TryParse(string text, out Interval result)
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