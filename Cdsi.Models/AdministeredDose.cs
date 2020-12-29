using System;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{

    public class AdministeredDose : IAdministeredDose
    {
        public IAntigenIdentifier Antigen { get; }
        public DateTime DateAdministered { get; }
        public string DoseCondition { get; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public DateTime LotExpiration { get; }
        public string VaccineType { get; }

        public AdministeredDose(string antigen, DateTime on, string condition, DateTime expiry, string type)
        {
            Antigen = AntigenIdentifier.Parse(antigen);
            DateAdministered = on;
            DoseCondition = condition;
            LotExpiration = expiry;
            VaccineType = type;
            EvaluationStatus = Defaults.EvaluationStatus;
        }

        public AdministeredDose(IAntigenIdentifier id, DateTime on, string cvx)
        {
            Antigen = id;
            DateAdministered = on;
            LotExpiration = Defaults.LotExpiration;
            VaccineType = Reference.Schedule.cvxToAntigenMap.GetVaccineType(cvx);
        }
    }
}
