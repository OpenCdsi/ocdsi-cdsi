using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi.TestcaseData
{
    public class Forecast
    {
        public string Forecast_Num { get; set; }
        public DateTime Earliest_Date { get; set; }
        public DateTime Recommended_Date { get; set; }
        public DateTime Past_Due_Date { get; set; }
    }
}
