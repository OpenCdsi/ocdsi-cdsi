using System.Diagnostics.CodeAnalysis;

namespace Ocdsi.Calendar
{
    public readonly partial struct Interval : IEqualityComparer<Interval>
    {
        private static readonly Interval _empty = new() { Components = new[] { new CalendarUnit { Value = 0, Name = UnitName.Day } } };
        public static Interval Empty => _empty;
        public readonly CalendarUnit[] Components { get; init; }

        public bool Equals(Interval x, Interval y)
        {
            var a = DateTime.MinValue + x;
            var b = DateTime.MinValue + y;
            return a.Equals(b);
        }

        public int GetHashCode([DisallowNull] Interval obj)
        {
            return obj.GetHashCode();
        }

        public TimeSpan ToTimeSpan()
        {
            return (DateTime.MinValue + this) - DateTime.MinValue;
        }
    }

    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            var a = DateTime.MinValue + x;
            var b = DateTime.MinValue + y;
            return a.CompareTo(b);
        }
    }
}
