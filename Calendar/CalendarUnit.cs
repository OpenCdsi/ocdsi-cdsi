using System.Diagnostics.CodeAnalysis;

namespace Cdsi.Calendar
{
    public readonly partial struct CalendarUnit : IEqualityComparer<CalendarUnit>
    {
        private static readonly CalendarUnit _empty = new() { Value = 0, Name = UnitName.Day };
        public static CalendarUnit Empty => _empty;

        public int Value { get; init; }
        public UnitName Name { get; init; }

        public bool Equals(CalendarUnit x, CalendarUnit y)
        {
            var a = DateTime.MinValue + x;
            var b = DateTime.MinValue + y;
            return a.Equals(b);
        }

        public int GetHashCode([DisallowNull] CalendarUnit obj)
        {
            return obj.GetHashCode();
        }
    }

    public class CalendarUnitComparer : IComparer<CalendarUnit>
    {
        public int Compare(CalendarUnit x, CalendarUnit y)
        {
            var a = DateTime.MinValue + x;
            var b = DateTime.MinValue + y;
            return a.CompareTo(b);
        }
    }

    public class CalendarlUnitNameComparer : IComparer<CalendarUnit>
    {
        public int Compare(CalendarUnit x, CalendarUnit y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
