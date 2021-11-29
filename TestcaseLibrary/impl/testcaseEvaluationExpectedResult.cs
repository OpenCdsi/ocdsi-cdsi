using System.Collections.Generic;

namespace Cdsi.TestcaseLibrary
{
    public class testcaseEvaluationExpectedResult
    {
        public string? SeriesStatus { get; set; }
        public IEnumerable<testcaseVaccineDoseAdministered>? AdministeredDoses { get; set; }
    }
}
