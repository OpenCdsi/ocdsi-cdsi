namespace OpenCdsi.Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IEnumerable<string> ObservationCodes { get; }
        IEnumerable<IVaccineDose> VaccineHistory { get; }
    }
}
