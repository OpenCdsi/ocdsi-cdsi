namespace OpenCdsi.Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IEnumerable<IPatientObservation> Observations { get; }
        IEnumerable<IVaccineDose> VaccineHistory { get; }
    }
}
