using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cdsi.refData;
using cdsi.supportingData;

namespace cdsi.evaluation
{
    public class PatientSeries : IPatientSeries
    {
        public AntigenSeriesIdentifier AntigenSeries { get; set; }

        public IEnumerable<ITargetDose> TargetDoses { get; } = new List<ITargetDose>();

        public PatientSeriesStatus Status { get; set; }
    }
}
