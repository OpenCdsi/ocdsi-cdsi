﻿using Cdsi.SupportingData;

namespace Cdsi
{
    /// <summary>
    /// Tracks the state of the dose in the patient series.
    /// </summary>
    public interface ITargetDose
    {
        TargetDoseStatus Status { get; set; }
        DateTime SatisfiedOn { get; set;}
        antigenSupportingDataSeriesSeriesDose SeriesDose { get; }
    }
}