namespace OpenCdsi.Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IEnumerable<PatientObservation> Observations { get; }
        IEnumerable<VaccineDose> VaccineHistory { get; }
        string MedicalHistoryCode { get; }
        string MedicalHistoryCodeSys { get; }
        string MedicalHistoryText { get; }
    }
}
