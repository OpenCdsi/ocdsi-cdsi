using System;

namespace Cdsi.ReferenceLibrary
{
    public class Testcase : ITestcase
    {
        public string CdcTestId { get; set; }
        public string TestcaseName { get; set; }
        public string VaccineGroup { get; set; }
        public string EvaluationTestType { get; set; }
        public string ForecastTestType { get; set; }
        public IPatient Patient { get; set; }
        public IEvaluation Evaluation { get; set; }
        public IForecast Forecast { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string GeneralDescription { get; set; }
        public string ChangedInVersion { get; set; }
        public string ReasonForChange { get; set; }
    }
}
