using System.Collections.Generic;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    public class PatientSeries : IPatientSeries
    {
        public IAntigenSeriesIdentifier AntigenSeriesIdentifier { get; internal set; }

        public IEnumerable<ITargetDose> TargetDoses { get; internal set; }

        public PatientSeriesStatus Status { get; set; }
    }
}
