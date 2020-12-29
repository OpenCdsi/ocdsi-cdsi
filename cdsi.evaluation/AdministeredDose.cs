using cdsi.refData;
using cdsi.supportingData;
using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{

    public class AdministeredDose : IAdministeredDose
    {
        public AntigenIdentifier Antigen {get;set;}
        public DateTime DateAdministered {get;set;}
        public string DoseCondition {get;set;}
        public string EvaluationReason {get;set;}
        public EvaluationStatus EvaluationStatus {get;set;}
        public DateTime LotExpiration {get;set;}
        public string VaccineType {get;set;}
    }
}
