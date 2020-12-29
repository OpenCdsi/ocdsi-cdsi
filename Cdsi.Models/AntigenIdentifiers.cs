using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi.Models
{
    public class AntigenIdentifier : IAntigenIdentifier
    {
        public string Name { get; set; }
    }

    public class AntigenSeriesIdentifier : AntigenIdentifier, IAntigenSeriesIdentifier
    {
        public int SeriesIndex { get; set; }
    }

    public class AntigenSeriesDoseIdentifier : AntigenSeriesIdentifier, IAntigenSeriesDoseIdentifier
    {
        public int DoseIndex { get; set; }
    }
}
