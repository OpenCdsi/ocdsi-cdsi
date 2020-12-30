using System;

namespace Cdsi.TestcaseLibrary
{
    public class Forecast : IForecast
    {
        public string ForecastNum { get; internal set; }
        public DateTime EarliestDate { get; internal set; }
        public DateTime RecommendedDate { get; internal set; }
        public DateTime PastDueDate { get; internal set; }
    }
}
