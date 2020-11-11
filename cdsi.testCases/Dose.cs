using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.testCases
{
    public class Dose
    {
        public DateTime Date_Administered { get; set; }
        public string Vaccine_Name { get; set; }
        public string CVX { get; set; }
        public string MVX { get; set; }
        public string Evaluation_Status { get; set; }
        public string Evaluation_Reason { get; set; }
    }
}
