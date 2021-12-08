using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class ProcessingData : IProcessingData
    {
        public DateTime AssessmentDate { get; set; }
        public IPatient Patient { get; set; }
    }
}
