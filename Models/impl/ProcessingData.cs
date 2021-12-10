using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public partial class ProcessingData : IProcessingData
    {
        public DateTime AssessmentDate { get; internal set; }
        public IPatient Patient { get; internal set; }
        public IList<IPatientSeries> RelevantPatientSeries { get; internal set; } = new List<IPatientSeries>();
        public IList<IAntigenDose> ImmunizationHistory { get; internal set; } = new List<IAntigenDose>();
    }
}
