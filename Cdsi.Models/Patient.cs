using System;
using System.Text.RegularExpressions;

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

        private static readonly Regex re = new Regex("^\\s*[Ff]");

        public Patient(DateTime dob, string gender, string text, string code, string sys, DateTime date)
        {
            DOB = dob;
            Gender = re.IsMatch(gender) ? Gender.Female : Gender.Male;
            MedHistoryText = text;
            MedHistoryCode = code;
            MedHistoryCodeSys = sys;
            AssessmentDate = date;
        }
    }
}
