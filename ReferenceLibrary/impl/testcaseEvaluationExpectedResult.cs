using System.Collections.Generic;

namespace Cdsi.ReferenceLibrary
{
    public class testcaseEvaluationExpectedResult
    {
        public string SeriesStatus { get; set; }
        public IEnumerable<testcaseVaccineDoseAdministered> AdministeredDoses { get; set; }
    }
}
