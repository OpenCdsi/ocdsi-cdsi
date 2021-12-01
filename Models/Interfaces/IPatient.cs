using System;

namespace Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        string MedHistoryText { get; }
        string MedHistoryCode { get; }
        string MedHistoryCodeSys { get; }
    }
}
