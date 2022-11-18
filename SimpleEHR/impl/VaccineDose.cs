using System;

namespace Cdsi
{
    public class VaccineDose : IVaccineDose
    {
        public DateTime DateAdministered { get; init; }
        public string VaccineDescription { get; init; } = string.Empty;
        public string VaccineType { get; init; } = string.Empty;
        public string CVX { get; init; } = string.Empty;
        public string MVX { get; init; } = string.Empty;
        public DateTime LotExpiration { get; init; }
        public string DoseCondition { get; init; } = string.Empty;
    }
}
