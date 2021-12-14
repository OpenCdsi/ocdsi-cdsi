using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public partial class Assessment : IAssessment
    {
        public DateTime AssessmentDate { get;  set; }
        public IPatient Patient { get;  set; }
    }
}
