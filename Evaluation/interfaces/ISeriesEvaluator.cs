namespace OpenCdsi.Cdsi.Evaluation
{
    public interface ISeriesEvaluator
    {
        IList<IAntigenDose> AntigenDoses { get; }
        IPatientSeries PatientSeries { get; }
    }
}
