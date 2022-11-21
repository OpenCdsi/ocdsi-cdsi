namespace OpenCdsi.Cdsi
{
    public class Env : IEnv
    {
        public IPatient Patient { get; set; }
        public DateTime AssessmentDate { get; set; }
        public IList<IAntigenDose> ImmunizationHistory { get; set; }
        public IList<IPatientSeries> RelevantPatientSeries { get; set; }
    }
}
