using cdsi.supportingData;
using System.Collections.Generic;

namespace cdsi.evaluation
{
    public interface IPatientSeries
    {
        AntigenSeriesIdentifier AntigenSeries { get; }
        IEnumerable<ITargetDose> TargetDoses { get; } 
        PatientSeriesStatus Status { get; set; }
    }
}