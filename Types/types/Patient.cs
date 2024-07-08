using System.Text.Json.Serialization;
using System.Text.Json;
using Ocdsi.Serialization;

namespace OpenCdsi.Cdsi
{
    public class Patient : IPatient
    {
        [JsonPropertyName("dob")]
        public DateTime DOB { get; init; }

        [JsonPropertyName("gender")]
        [JsonConverter(typeof(JsonRegExConverter<Gender>))]
        public Gender Gender { get; init; }

        [JsonPropertyName("observations")]
        public IList<PatientObservation> Observations { get; init; } = new List<PatientObservation>();

        [JsonPropertyName("doses")]
        public IEnumerable<VaccineDose> VaccineHistory { get; init; } = new List<VaccineDose>();

        [JsonPropertyName("medHistoryCode")]
        public string MedicalHistoryCode { get; init; } = string.Empty;

        [JsonPropertyName("medHistoryCodeSys")]
        public string MedicalHistoryCodeSys { get; init; } = string.Empty;

        [JsonPropertyName("medHistoryText")]
        public string MedicalHistoryText { get; init; } = string.Empty;
    }
}
