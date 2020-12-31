using System.Collections.Generic;

namespace Cdsi.Models
{
    public interface IPatientSeries
    {
        string AntigenName { get; }
        string SeriesName { get; }
        IEnumerable<ITargetDose> TargetDoses { get; }
        PatientSeriesStatus Status { get; set; }
    }
}