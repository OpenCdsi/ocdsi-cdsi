using System;

namespace Cdsi.Models
{

    public class AdministeredDose : IAdministeredDose
    {
        public string AntigenName { get; internal set; }
        public DateTime DateAdministered { get; internal set; }
        public string DoseCondition { get; internal set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public DateTime LotExpiration { get; internal set; }
        public string VaccineType { get; internal set; }
    }
}
