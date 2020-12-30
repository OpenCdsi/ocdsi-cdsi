using System;

namespace Cdsi.TestcaseLibrary
{
    public class Testcase : ITestcase
    {
        public string CdcTestId { get; internal set; }
        public string TestcaseName { get; internal set; }
        public string VaccineGroup { get; internal set; }
        public string EvaluationTestType { get; internal set; }
        public string ForecastTestType { get; internal set; }
        public Patient Patient { get; internal set; }
        public Evaluation Evaluation { get; internal set; }
        public Forecast Forecast { get; internal set; }
        public DateTime DateAdded { get; internal set; }
        public DateTime DateUpdated { get; internal set; }
        public string GeneralDescription { get; internal set; }
        public string ChangedInVersion { get; internal set; }
        public string ReasonForChange { get; internal set; }
    }
}
