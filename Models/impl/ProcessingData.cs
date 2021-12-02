using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class ProcessingData : IProcessingData
    {
        public System.DateTime AssessmentDate { get; set; }
        public IPatient Patient { get; set; }
        public IEnumerable<IVaccineDose> Doses { get; set;}
    }
}
