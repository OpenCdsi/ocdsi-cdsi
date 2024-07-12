namespace Cdsi.Calendar
{
    public readonly partial struct Interval
    {
        private static Interval FromComponents(List<CalendarUnit> components)
        {
            components.Sort(new CalendarlUnitNameComparer());
            return new Interval { Components = components.ToArray() };
        }

        // Interval:Interval
        public static Interval operator +(Interval a, Interval b)
        {
            var components = a.Components.ToList();
            components.AddRange(b.Components);

            return FromComponents(components);
        }
        public static Interval operator -(Interval a, Interval b)
        {
            return a + (-b);
        }
        public static Interval operator -(Interval a)
        {
            return a * -1;
        }
        public static Interval operator *(Interval a, int b)
        {
            var components = a.Components.Select(x => b * x).ToList();

            return FromComponents(components);
        }
        public static Interval operator *(int b, Interval a)
        {
            return a * b;
        }
        public static Interval operator /(Interval a, int b)
        {
            var components = a.Components.Select(x => x / b).ToList();

            return FromComponents(components);
        }


        // DateTime:Interval
        public static DateTime operator +(DateTime a, Interval b)
        {
            return a.Add(b.Components);
        }

        public static DateTime operator +(Interval b, DateTime a)
        {
            return a + b;
        }

        public static DateTime operator -(DateTime a, Interval b)
        {
            return a + (-b);
        }

        public static DateTime operator -(Interval b, DateTime a)
        {
            return a - b;
        }

        // Interval:Timespan
        public static bool operator <(Interval a, TimeSpan b)
        {
            return a.ToTimeSpan() < b;
        }

        public static bool operator >(Interval a, TimeSpan b)
        {
            return a.ToTimeSpan() > b;
        }

        public static bool operator <=(Interval a, TimeSpan b)
        {
            return a.ToTimeSpan() <= b;
        }

        public static bool operator >=(Interval a, TimeSpan b)
        {
            return a.ToTimeSpan() >= b;
        }

        // Timespan:Interval
        public static bool operator <(TimeSpan b, Interval a)
        {
            return a < b;
        }

        public static bool operator >(TimeSpan b, Interval a)
        {
            return a > b;
        }

        public static bool operator <=(TimeSpan b, Interval a)
        {
            return a <= b;
        }

        public static bool operator >=(TimeSpan b, Interval a)
        {
            return a >= b;
        }
    }
}
