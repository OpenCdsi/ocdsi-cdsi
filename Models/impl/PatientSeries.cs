using System.Collections.Generic;

namespace Cdsi
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenName { get; set; }
        public string SeriesName { get; set; }
        public IEnumerable<TargetDose> TargetDoses { get; set; }
        public IEnumerable<AntigenDose> AntigenDoses { get; set; }
        public PatientSeriesStatus Status { get; set; }
        public PatientSeriesType SeriesType { get; set; }
    }
}
