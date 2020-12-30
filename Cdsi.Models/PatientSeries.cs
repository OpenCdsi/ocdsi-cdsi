using System.Collections.Generic;

namespace Cdsi.Models
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenName { get; internal set; }
        public string SeriesName { get; internal set; }

        public IEnumerable<ITargetDose> TargetDoses { get; internal set; }

        public PatientSeriesStatus Status { get; set; }
    }
}
