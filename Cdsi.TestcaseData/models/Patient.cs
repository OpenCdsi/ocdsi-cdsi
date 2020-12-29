using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi.TestcaseData
{
    public class Patient
    {
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Med_History_Text { get; set; }
        public string Med_History_Code { get; set; }
        public string Med_History_Code_Sys { get; set; }
        public DateTime Assessment_Date { get; set; }

    }
}
