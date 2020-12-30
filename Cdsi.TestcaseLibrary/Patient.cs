using System;

namespace Cdsi.TestcaseLibrary
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; internal set; }
        public string Gender { get; internal set; }
        public string MedHistoryText { get; internal set; }
        public string MedHistoryCode { get; internal set; }
        public string MedHistoryCodeSys { get; internal set; }
        public DateTime AssessmentDate { get; internal set; }

    }
}
