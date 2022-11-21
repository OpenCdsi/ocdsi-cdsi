namespace OpenCdsi.Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IList<string> ObservationCodes { get; }
        IList<IVaccineDose> VaccineHistory { get; }
    }
}
