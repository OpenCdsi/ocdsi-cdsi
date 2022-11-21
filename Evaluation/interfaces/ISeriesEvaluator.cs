namespace OpenCdsi.Cdsi
{
    public interface ISeriesEvaluator
    {
        IList<IAntigenDose> AntigenDoses { get; }
        IPatientSeries PatientSeries { get; }
    }
}
