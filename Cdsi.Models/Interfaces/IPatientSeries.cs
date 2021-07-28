using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatientSeries
    {
        string AntigenName { get; }
        string SeriesName { get; }
        IEnumerable<ITargetDose> TargetDoses { get; }
        PatientSeriesStatus Status { get; set; }
        PatientSeriesType SeriesType { get; }
    }
}