using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenName { get; set; }
        public string SeriesName { get; set; }
        public IEnumerable<ITargetDose> TargetDoses { get; set; }
        public IEnumerable<IAntigenDose> AntigenDoses { get; set; }
        public PatientSeriesStatus Status { get; set; }
        public PatientSeriesType SeriesType { get; set; }
    }
}
