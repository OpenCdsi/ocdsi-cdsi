using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatientSeries
    {
        string AntigenName { get; }
        string SeriesName { get; }
        IEnumerable<TargetDose> TargetDoses { get; }
        IEnumerable<AntigenDose> AntigenDoses { get; }
        PatientSeriesStatus Status { get; set; }
        PatientSeriesType SeriesType { get; }
    }
}