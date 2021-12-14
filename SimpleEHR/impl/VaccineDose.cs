using System;

namespace Cdsi
{
    public class VaccineDose : IVaccineDose
    {
        public DateTime DateAdministered { get; set; }
        public string VaccineDescription { get; set; }
        public string VaccineType { get; set; }
        public string CVX { get; set; }
        public string MVX { get; set; }
        public DateTime LotExpiration { get; set; }
        public string DoseCondition { get; set; }
    }
}
