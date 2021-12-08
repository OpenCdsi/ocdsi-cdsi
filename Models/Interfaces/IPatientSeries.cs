using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatientSeries
    {
        string AntigenName { get; }
        string SeriesName { get; }
        IList<ITargetDose> TargetDoses { get; }
        IList<IAntigenDose> AntigenDoses { get; }
        PatientSeriesStatus Status { get; set; }
        PatientSeriesType SeriesType { get; }
    }
}