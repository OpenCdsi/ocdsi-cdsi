using cdsi.refData;
using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{

    public class AdministeredDose : IAdministeredDose
    {
        public EvaluationStatus EvaluationStatus { get; set; } = EvaluationStatus.NotValid;
        public IList<string> EvaluationReasons { get; set; } = new List<string>();
        public DateTime DateAdministered { get; set; }
        public DateTime LotExpiration { get; set; } = new DateTime(2999, 12, 31);
        public string DoseCondition { get; set; }
        public int? VaccineType { get; set; } // aka CVX ?
        public string Antigen { get; set; }
    }
}
