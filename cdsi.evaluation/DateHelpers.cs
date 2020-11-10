using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace cdsi.evaluation
{
    public enum IntervalUnit
    {
        Day,
        Week,
        Month,
        Year
    }

    public class Interval
    {
        private static Regex re = new Regex("^([\\+-]?\\d+)(\\w+)");

        public int Duration { get; set; }
        public IntervalUnit Unit { get; set; }

        private static IntervalUnit ParseUnit(string text)
        {
            text = text.ToLower();
            return (text.First()) switch
            {
                'y' => IntervalUnit.Year,
                'm' => IntervalUnit.Month,
                'w' => IntervalUnit.Week,
                'd' => IntervalUnit.Day,
                _ => throw new ArgumentException(text),
            };
        }

        public static Interval Parse(string text)
        {
            text = text.Replace(" ", "");
            var match = re.Match(text);
            if (match.Success)
            {
                return new Interval()
                {
                    Duration = int.Parse(match.Groups[1].Value),
                    Unit = ParseUnit(match.Groups[2].Value)
                };
            }
            else
            {
                throw new ArgumentException(text);
            }
        }

        public static IList<Interval> ParseAll(string text)
        {
            var intervals = new List<Interval>();
            text = text.Replace(" ", "");
            while (!string.IsNullOrEmpty(text))
            {
                intervals.Add(Parse(text));
                text = re.Replace(text, "");
            }
            return intervals;
        }
    }

    public static class DateMath
    {
        public static DateTime Add(this DateTime date, Interval interval)
        {
            return interval.Unit switch
            {
                IntervalUnit.Day => date.AddDays(interval.Duration),
                IntervalUnit.Week => date.AddDays(interval.Duration * 7),
                IntervalUnit.Month => date.AddMonths(interval.Duration),
                IntervalUnit.Year => date.AddMonths(interval.Duration * 12),
                _ => throw new ArgumentException(),
            };
        }
    }
}
