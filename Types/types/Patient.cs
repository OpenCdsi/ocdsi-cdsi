namespace OpenCdsi.Cdsi
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; init; }
        public Gender Gender { get; init; }
        public IEnumerable<string> ObservationCodes { get; init; } = new List<string>();
        public IEnumerable<IVaccineDose> VaccineHistory { get; init; } = new List<IVaccineDose>();
    }
}
