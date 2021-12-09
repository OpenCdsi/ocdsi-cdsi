using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static partial class Testcase
    {
        public static IProcessingData CreateProcessingData(this testcase tc)
        {
           return new ProcessingData
            {
                AssessmentDate = tc.AssessmentDate,
                Patient = tc.Patient.ToModel(tc.Doses)
            };
        }
    }
}
