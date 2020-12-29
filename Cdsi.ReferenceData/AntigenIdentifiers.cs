using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi.ReferenceData
{
    public class AntigenIdentifier : IAntigenIdentifier
    {
        public string Name { get; private set; }
    }

    public class AntigenSeriesIdentifier : AntigenIdentifier, IAntigenSeriesIdentifier
    {
        public int SeriesIndex { get; private set; }
    }

    public class AntigenSeriesDoseIdentifier : AntigenSeriesIdentifier, IAntigenSeriesDoseIdentifier
    {
        public int DoseIndex { get; private set; }
    }
}
