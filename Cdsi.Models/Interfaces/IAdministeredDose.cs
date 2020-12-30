using System;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    /// <summary>
    /// Represents an antigen dose administered to a patient.
    /// </summary>
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