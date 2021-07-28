using System;

namespace Cdsi.ReferenceLibrary
{
    public interface IForecast
    {
        DateTime EarliestDate { get; }
        string ForecastNum { get; }
        DateTime PastDueDate { get; }
        DateTime RecommendedDate { get; }
    }
}