using System;

namespace Cdsi.ReferenceLibrary
{
    public interface ITestcase
    {
        string CdcTestId { get; }
        string ChangedInVersion { get; }
        DateTime DateAdded { get; }
        DateTime DateUpdated { get; }
        IEvaluation Evaluation { get; }
        string EvaluationTestType { get; }
        IForecast Forecast { get; }
        string ForecastTestType { get; }
        string GeneralDescription { get; }
        IPatient Patient { get; }
        string ReasonForChange { get; }
        string TestcaseName { get; }
        string VaccineGroup { get; }
    }
}