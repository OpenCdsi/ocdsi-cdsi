using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi
{
    public partial class Interval : IInterval
    {
        public int Duration { get; set; }
        public IntervalUnit Unit { get; set; }
    }
}
