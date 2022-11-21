namespace OpenCdsi.Cdsi
{
    public interface IEnv
    {
        IPatient Patient { get; set; }
        DateTime AssessmentDate { get; set; }
        IList<IAntigenDose> ImmunizationHistory { get; set; }
        IList<IPatientSeries> RelevantPatientSeries { get; set; }
    }
}
