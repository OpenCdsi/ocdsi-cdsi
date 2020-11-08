namespace cdsi.evaluation
{
    public interface IPatientSeries
    {
        string AntigenName { get; }
        int SeriesNumber { get; }
        PatientSeriesStatus Status { get; set; }
    }
}