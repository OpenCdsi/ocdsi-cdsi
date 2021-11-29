using System;

namespace Cdsi.TestcaseLibrary
{
    public class testcaseForecastExpectedResult 
    {
        public string? ForecastNum { get; set; }
        public DateTime EarliestDate { get; set; }
        public DateTime RecommendedDate { get; set; }
        public DateTime PastDueDate { get; set; }
    }
}
