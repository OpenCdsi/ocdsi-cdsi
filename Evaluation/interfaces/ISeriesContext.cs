namespace OpenCdsi.Cdsi
{
    public interface ISeriesContext
    {
        IPatientSeries PatientSeries { get; }
        IEnumerable<IAntigenDose> ImmunizationHistory { get; }  
    }
}
