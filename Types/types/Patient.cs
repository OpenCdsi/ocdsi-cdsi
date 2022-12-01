namespace OpenCdsi.Cdsi
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; init; }
        public Gender Gender { get; init; }
        public IEnumerable<IPatientObservation> Observations { get; init; } = new List<IPatientObservation>();
        public IEnumerable<IVaccineDose> VaccineHistory { get; init; } = new List<IVaccineDose>();
    }
}
