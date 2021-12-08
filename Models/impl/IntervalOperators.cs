using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi
{
    public partial class Interval : IInterval
    {
        public static Interval operator *(int x, Interval i)
        {
            return new Interval { Duration = x * i.Duration, Unit = i.Unit };
        }
    }
}
