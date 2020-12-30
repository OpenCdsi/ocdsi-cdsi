using System;

namespace Cdsi.Models
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; internal set; }
        public Gender Gender { get; internal set; }
        public string MedHistoryText { get; internal set; }
        public string MedHistoryCode { get; internal set; }
        public string MedHistoryCodeSys { get; internal set; }
        public DateTime AssessmentDate { get; set; }
    }
}
