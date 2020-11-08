using System;
using System.Collections.Generic;

namespace cdsi.evaluation
{
    public interface IAdministeredDose
    {
        string Antigen { get; set; }
        DateTime DateAdministered { get; set; }
        string DoseCondition { get; set; }
        IList<string> EvaluationReasons { get; set; }
        EvaluationStatus EvaluationStatus { get; set; }
        DateTime LotExpiration { get; set; }
        string VaccineType { get; set; }
    }
}