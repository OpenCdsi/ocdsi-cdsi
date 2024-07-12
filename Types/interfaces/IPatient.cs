namespace Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IList<PatientObservation> Observations { get; }
        IEnumerable<VaccineDose> VaccineHistory { get; }
        string MedicalHistoryCode { get; }
        string MedicalHistoryCodeSys { get; }
        string MedicalHistoryText { get; }
    }
}
