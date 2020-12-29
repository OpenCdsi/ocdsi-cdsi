using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.supportingData
{
   public class AntigenIdentifier 
    {
        public string Name { get; set; }
    }

    public class AntigenSeriesIdentifier : AntigenIdentifier
    {
        public int SeriesIndex { get; set; }
    }

    public class AntigenSeriesDoseIdentifier : AntigenSeriesIdentifier
    {
        public int DoseIndex { get; set; }
    }
}
