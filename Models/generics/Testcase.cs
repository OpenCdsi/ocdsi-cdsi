using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static partial class Testcase
    {
        public static ProcessingData CreateProcessingData(this testcase tc)
        {
            return new ProcessingData
            {
                AssessmentDate = tc.AssessmentDate,
                Patient = tc.Patient.ToModel(tc.Doses)
            };
        }
    }
}
