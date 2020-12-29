using System;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    public interface IAdministeredDose
    {
        IAntigenIdentifier Antigen { get; }
        DateTime DateAdministered { get; }
        string DoseCondition { get; }
        string EvaluationReason { get; set; }
        EvaluationStatus EvaluationStatus { get; set; }
        DateTime LotExpiration { get; }
        string VaccineType { get; }
    }
}