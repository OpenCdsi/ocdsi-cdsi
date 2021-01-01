using System.Collections.Generic;

namespace Cdsi.Models
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenName { get; set; }
        public string SeriesName { get; set; }

        public IEnumerable<ITargetDose> TargetDoses { get; set; }

        public PatientSeriesStatus Status { get; set; }
        public PatientSeriesType SeriesType { get; set; }
    }
}
