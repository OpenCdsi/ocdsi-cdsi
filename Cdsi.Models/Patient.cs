using System;
using System.Text.RegularExpressions;

namespace Cdsi.Models
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; }
        public Gender Gender { get; }
        public string MedHistoryText { get; }
        public string MedHistoryCode { get; }
        public string MedHistoryCodeSys { get; }
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
