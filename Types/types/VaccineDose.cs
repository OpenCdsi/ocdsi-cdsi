namespace OpenCdsi.Cdsi
{
    public class VaccineDose : IVaccineDose
    {
        public DateTime DateAdministered { get; init; }
        public string VaccineDescription { get; init; }
        public string VaccineType { get; init; }
        public string CVX { get; init; }
        public string MVX { get; init; }
        public DateTime LotExpiration { get; init; }
        public string DoseCondition { get; init; }
    }
}
