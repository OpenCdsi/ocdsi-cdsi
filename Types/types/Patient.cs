using System.Text.Json.Serialization;

namespace OpenCdsi.Cdsi
{
    public class Patient : IPatient
    {
        [JsonPropertyName("dob")]
        public DateTime DOB { get; init; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; init; }

        [JsonPropertyName("observations")]
        public IEnumerable<IPatientObservation> Observations { get; init; } = new List<IPatientObservation>();

        [JsonPropertyName("doses")]
        public IEnumerable<IVaccineDose> VaccineHistory { get; init; } = new List<IVaccineDose>();
    }
}
