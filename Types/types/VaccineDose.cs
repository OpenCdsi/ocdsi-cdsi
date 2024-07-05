using System.Text.Json.Serialization;

namespace OpenCdsi.Cdsi
{
    public class VaccineDose : IVaccineDose
    {
        [JsonPropertyName("dateAdministered")]
        public DateTime DateAdministered { get; init; }

        [JsonPropertyName("vaccineName")]
        public string VaccineDescription { get; init; } = string.Empty;

        [JsonPropertyName("gender")]
        public string VaccineType { get; init; } = string.Empty;

        [JsonPropertyName("cvx")]
        public string CVX { get; init; } = string.Empty;

        [JsonPropertyName("mvx")]
        public string MVX { get; init; } = string.Empty;

        [JsonPropertyName("tradename")]
        public string Tradename { get; init; } = string.Empty;

        [JsonPropertyName("logExpiration")]
        public DateTime LotExpiration { get; init; }

        [JsonPropertyName("condition")]
        public string DoseCondition { get; init; } = string.Empty;

        [JsonPropertyName("volume")]
        public int Volume { get; init; } = 0;
    }
}
