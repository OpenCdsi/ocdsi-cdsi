using Cdsi.SupportingData;
using System;

namespace Cdsi.Models
{
    public interface IAdministeredDose
    {
        AntigenIdentifier Antigen { get; set; }
        DateTime DateAdministered { get; set; }
        string DoseCondition { get; set; }
        string EvaluationReason { get; set; }
        EvaluationStatus EvaluationStatus { get; set; }
        DateTime LotExpiration { get; set; }
        string VaccineType { get; set; }
    }
}