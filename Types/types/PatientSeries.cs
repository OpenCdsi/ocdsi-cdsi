using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public class PatientSeries : IPatientSeries
    {
        public PatientSeriesStatus Status { get; set; }
        public antigenSupportingDataSeries Series { get; init; }
        public string Antigen { get => Series.targetDisease; }
        public string Name { get => Series.seriesName; }
        public PatientSeriesType SeriesType { get => Parse.Enum<PatientSeriesType>(Series.seriesType); }
        public IEnumerable<ITargetDose> TargetDoses { get; init; }
    }
}
