using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenName { get; internal set; }
        public string SeriesName { get; internal set;}
        public IList<ITargetDose> TargetDoses { get; } = new List<ITargetDose>();
        public IList<IAntigenDose> AntigenDoses { get; } = new List<IAntigenDose>();
        public PatientSeriesStatus Status { get; set; }
        public PatientSeriesType SeriesType { get; internal set; }
    }
}
