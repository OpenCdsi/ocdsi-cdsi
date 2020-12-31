using System;

namespace Cdsi.TestcaseLibrary
{
    public class Forecast : IForecast
    {
        public string ForecastNum { get; set; }
        public DateTime EarliestDate { get; set; }
        public DateTime RecommendedDate { get; set; }
        public DateTime PastDueDate { get; set; }
    }
}
