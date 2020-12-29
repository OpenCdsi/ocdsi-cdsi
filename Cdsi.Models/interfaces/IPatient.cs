using System;

namespace Cdsi.Models
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        string MedHistoryText { get; }
        string MedHistoryCode { get; }
        string MedHistoryCodeSys { get; }
        DateTime AssessmentDate { get; set; }
    }
}
