using System;

namespace Cdsi.TestcaseLibrary
{
    public interface IForecast
    {
        DateTime EarliestDate { get; }
        string ForecastNum { get; }
        DateTime PastDueDate { get; }
        DateTime RecommendedDate { get; }
    }
}