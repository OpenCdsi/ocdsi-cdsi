using System;
using System.Collections.Generic;

namespace Cdsi
{

    public static class DateHelpers
    {
        public static DateTime Add(this DateTime date, IInterval interval)
        {
            return interval.Unit switch
            {
                IntervalUnit.Day => date.AddDays(interval.Duration),
                IntervalUnit.Week => date.AddDays(interval.Duration * 7),
                IntervalUnit.Month => date.CALCDT_5(interval.Duration),
                IntervalUnit.Year => date.CALCDT_5(interval.Duration * 12),
                _ => throw new ArgumentException()
            };
        }

        public static DateTime Add(this DateTime date, IEnumerable<Interval> intervals)
        {
            var result = date;
            foreach (var interval in intervals)
            {
                result = result.Add(interval);
            }
            return result;
        }

        private static DateTime CALCDT_5(this DateTime date, int duration)
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
    }
}
