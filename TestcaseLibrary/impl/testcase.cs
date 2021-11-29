using System;

namespace Cdsi.TestcaseLibrary
{
    public class testcase
    {
        public string CdcTestId { get; set; }
        public string? TestcaseName { get; set; }
        public string? VaccineGroup { get; set; }
        public string? EvaluationTestType { get; set; }
        public string? ForecastTestType { get; set; }
        public testcasePatient? Patient { get; set; }
        public testcaseEvaluationExpectedResult? Evaluation { get; set; }
        public testcaseForecastExpectedResult? Forecast { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? GeneralDescription { get; set; }
        public string? ChangedInVersion { get; set; }
        public string? ReasonForChange { get; set; }
    }
}
