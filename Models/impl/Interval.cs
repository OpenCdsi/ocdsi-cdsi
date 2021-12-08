using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi
{
    public partial class Interval : IInterval
    {
        public int Duration { get; internal set; }
        public IntervalUnit Unit { get; internal set; }
    }
}
