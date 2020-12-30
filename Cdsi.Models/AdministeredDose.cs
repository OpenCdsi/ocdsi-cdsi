using System;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{

    public class AdministeredDose : IAdministeredDose
    {
        public IAntigenIdentifier Antigen { get; internal set; }
        public DateTime DateAdministered { get; internal set; }
        public string DoseCondition { get; internal set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public DateTime LotExpiration { get; internal set; }
        public string VaccineType { get; internal set; }

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
            VaccineType = Reference.Schedule.GetVaccineType(cvx);
        }
    }
}
