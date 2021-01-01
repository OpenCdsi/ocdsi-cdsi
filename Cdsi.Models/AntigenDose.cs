using System;

namespace Cdsi.Models
{

    public class AntigenDose : IAntigenDose
    {
        public string AntigenName { get; set; }
        public DateTime DateAdministered { get; set; }
        public string DoseCondition { get; set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public DateTime LotExpiration { get; set; }
        public string VaccineType { get; set; }
    }
}
