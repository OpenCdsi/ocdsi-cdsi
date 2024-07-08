namespace Ocdsi.Calendar
{
    public readonly partial struct CalendarUnit
    {

        // CalendarUnit:CalendarUnit
        public static CalendarUnit operator +(CalendarUnit a, CalendarUnit b)
        {
            if (a.Name != b.Name) throw new ArgumentException("Both intervals must have the same Unit.");

            return new CalendarUnit { Value = a.Value + b.Value, Name = a.Name };
        }

        public static CalendarUnit operator -(CalendarUnit a, CalendarUnit b)
        {
            return a + (-b);
        }

        public static CalendarUnit operator -(CalendarUnit a)
        {
            return -1 * a;
        }

        // DateTime:CalendarUnit
        public static DateTime operator +(DateTime a, CalendarUnit b)
        {
            return a.Add(b);
        }
        public static DateTime operator -(DateTime a, CalendarUnit b)
        {
            return a.Add(-1 * b);
        }

        // CalendarUnit:Integer
        public static CalendarUnit operator +(CalendarUnit a, int b)
        {
            return new CalendarUnit { Value = a.Value + b, Name = a.Name };
        }
        public static CalendarUnit operator -(CalendarUnit a, int b)
        {
            return new CalendarUnit { Value = a.Value - b, Name = a.Name };
        }
        public static CalendarUnit operator *(CalendarUnit a, int b)
        {
            return new CalendarUnit { Value = a.Value * b, Name = a.Name };
        }
        public static CalendarUnit operator /(CalendarUnit a, int b)
        {
            return new CalendarUnit { Value = a.Value / b, Name = a.Name };
        }

        // CalendarUnit:Integer (associative operations)
        public static CalendarUnit operator +(int b, CalendarUnit a)
        {
            return a + b;
        }
        public static CalendarUnit operator *(int b, CalendarUnit a)
        {
            return a * b;
        }
    }
}
