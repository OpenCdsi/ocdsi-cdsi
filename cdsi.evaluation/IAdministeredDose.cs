using cdsi.supportingData;
using System;
using System.Collections.Generic;

namespace cdsi.evaluation
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