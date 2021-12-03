using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class Patient : IPatient
    {
        public System.DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<string> ObservationCodes { get; set; } = new List<string>();
        public System.DateTime AssessmentDate { get; set; }
    }
}
