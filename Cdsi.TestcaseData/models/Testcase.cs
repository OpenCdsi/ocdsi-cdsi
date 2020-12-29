using System;

namespace Cdsi.TestcaseData
{
    public class Testcase
    {
        public string CDC_Test_ID { get; set; }
        public string Test_Case_Name { get; set; }
        public string Vaccine_Group { get; set; }
        public string Evaluation_Test_Type { get; set; }
        public string Forecast_Test_Type { get; set; }
        public Patient Patient { get; set; }
        public Evaluation Evaluation { get; set; }
        public Forecast Forecast { get; set; }
        public DateTime Date_Added { get; set; }
        public DateTime Date_Updated { get; set; }
        public string General_Description { get; set; }
        public string Changed_In_Version { get; set; }
        public string Reason_For_Change { get; set; }
    }
}
