﻿using Cdsi.SupportingData;

namespace Cdsi
{
    public class TargetDose : ITargetDose
    {
        public TargetDoseStatus Status { get; set; }
        public DateTime SatisfiedOn { get; set;}
        public antigenSupportingDataSeriesSeriesDose SeriesDose { get; init; }
    }
}
