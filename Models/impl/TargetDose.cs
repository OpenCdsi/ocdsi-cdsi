using Cdsi.SupportingDataLibrary;
using System.Collections.Generic;

namespace Cdsi
{
    public class TargetDose : ITargetDose
    {
        public TargetDoseStatus Status { get; set; }
        public antigenSupportingDataSeriesSeriesDose SeriesDose { get; internal set; }
    }
}
