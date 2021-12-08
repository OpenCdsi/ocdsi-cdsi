using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Cdsi
{
    public partial class Interval
    {
        private static Regex re = new Regex("^([\\+-]?\\d+)(\\w+)");

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

        public static IEnumerable<Interval> ParseAll(string text)
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

}
