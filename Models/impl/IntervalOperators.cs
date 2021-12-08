using System;

namespace Cdsi
{
    public partial class Interval : IInterval
    {
        // DateTime helpers
        internal static DateTime Add(DateTime date, IInterval interval)
        {
            return interval.Unit switch
            {
                IntervalUnit.Day => date.AddDays(interval.Duration),
                IntervalUnit.Week => date.AddDays(interval.Duration * 7),
                IntervalUnit.Month => CALCDT_5(date, interval.Duration),
                IntervalUnit.Year => CALCDT_5(date,interval.Duration * 12),
                _ => throw new ArgumentException()
            };
        }
        internal static DateTime CALCDT_5(DateTime date, int duration)
        {
            try
            {
                var m = date.Month + duration;
                var y = date.Year;
                if (m > 12)
                {
                    y += Math.DivRem(m, 12, out m);
                }
                return new DateTime(y, m, date.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return date.AddMonths(duration).AddDays(1); // Move to the start of the next month upon invalid date. Table 3-6
            }
        }

        // Interval:Interval
        public static Interval operator +(Interval a, Interval b)
        {
            if (a.Unit != b.Unit) throw new ArgumentException("Both intervals must have the same Unit.");

            return new Interval { Duration = a.Duration + b.Duration, Unit = a.Unit };
        }
        public static Interval operator -(Interval a, Interval b)
        {
           return a + (-1 * b);
        }

        // Interval:DateTime
        public static DateTime operator +(DateTime a, Interval b)
        {
            return Add(a, b);
        }
        public static DateTime operator -(DateTime a, Interval b)
        {
            return Add(a, -1 * b);
        }
        public static DateTime operator +(Interval b, DateTime a)
        {
            return a + b;
        }
        public static DateTime operator -(Interval b, DateTime a)
        {
            return a - b;
        }

        // Interval:Integer
        public static Interval operator +(int a, Interval b)
        {
            return new Interval { Duration = b.Duration + a, Unit = b.Unit };
        }
        public static Interval operator -(int a, Interval b)
        {
            return new Interval { Duration = b.Duration - a, Unit = b.Unit };
        }
        public static Interval operator *(int a, Interval b)
        {
            return new Interval { Duration = a * b.Duration, Unit = b.Unit };
        }


        public static Interval operator +(Interval b, int a)
        {
            return a + b;
        }
        public static Interval operator -(Interval b, int a)
        {
            return a - b;
        }
        public static Interval operator *(Interval b, int a)
        {
            return a * b;
        }
    }
}
