using System.Collections.Generic;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    /// <summary>
    /// Tracks the state of the dose in the patient series.
    /// </summary>
    public interface ITargetDose
    {
        TargetDoseStatus Status { get; set; }
        antigenSupportingDataSeriesSeriesDose SeriesDose { get; }
    }
}