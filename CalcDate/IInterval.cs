using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{

    public interface IInterval
    {
        int Duration { get; }
        IntervalUnit Unit { get; }
    }
}
