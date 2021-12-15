using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public partial class Interval : IInterval
    {
        public static readonly Interval ThirtyDays = new Interval { Duration = 30, Unit = IntervalUnit.Day };
        public static readonly Interval NinetyyDays = new Interval { Duration = 90, Unit = IntervalUnit.Day };

        public static readonly Interval OneMonth = new Interval { Duration = 1, Unit = IntervalUnit.Month };
        public static readonly Interval OneQuarter = new Interval { Duration = 3, Unit = IntervalUnit.Month };
        public static readonly Interval SixMonths = new Interval { Duration = 6, Unit = IntervalUnit.Month };

        public static readonly Interval OneYear = new Interval { Duration = 1, Unit = IntervalUnit.Year };
    }
}
