using System;

namespace Cdsi.Models
{
    public class Patient : IPatient
    {
        public DateTime DOB { get;  set; }
        public Gender Gender { get;  set; }
        public string MedHistoryText { get;  set; }
        public string MedHistoryCode { get;  set; }
        public string MedHistoryCodeSys { get;  set; }
        public DateTime AssessmentDate { get; set; }
    }
}
