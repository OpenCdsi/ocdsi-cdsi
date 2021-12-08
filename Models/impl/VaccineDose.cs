using System;

namespace Cdsi
{
    public class VaccineDose : IVaccineDose
    {
        public DateTime DateAdministered { get; internal set; }
        public string VaccineDescription { get; internal set; }
        public string VaccineType { get; internal set; }
        public string CVX { get; internal set; }
        public string MVX { get; internal set; }
        public DateTime LotExpiration { get; internal set; } = Defaults.LotExpiration;
        public string DoseCondition { get; internal set; }
    }
}
