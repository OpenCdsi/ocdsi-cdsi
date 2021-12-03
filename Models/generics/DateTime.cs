using System;
using System.Collections.Generic;

namespace Cdsi
{

    public static class DateTimeMath
    {
        public static System.DateTime Add(this System.DateTime date, IInterval interval)
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

        public static System.DateTime Add(this System.DateTime date, IEnumerable<IInterval> intervals)
        {
            var result = date;
            foreach (var interval in intervals)
            {
                result = result.Add(interval);
            }
            return result;
        }

        private static System.DateTime CALCDT_5(this System.DateTime date, int duration)
        {
            try
            {
                var m = date.Month + duration;
                var y = date.Year;
                if (m > 12)
                {
                    y += Math.DivRem(m, 12, out m);
                }
                return new System.DateTime(y, m, date.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return date.AddMonths(duration).AddDays(1); // Move to the start of the next month upon invalid date. Table 3-6
            }
        }
    }
}
