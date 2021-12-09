using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class ProcessingData : IProcessingData
    {
        public DateTime AssessmentDate { get; set; }
        public IPatient Patient { get; set; }
        public IList<IPatientSeries> RelevantPatientSeries { get; internal set;} = new List<IPatientSeries>();
    }
}
