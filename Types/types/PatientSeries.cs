using Ocdsi.SupportingData;

namespace OpenCdsi.Cdsi
{
    public class PatientSeries : IPatientSeries
    {
        public PatientSeriesStatus Status { get; set; }
        public antigenSupportingDataSeries Series { get; init; }
        public string Antigen { get => Series.targetDisease; }
        public string Name { get => Series.seriesName; }
        public PatientSeriesType SeriesType { get => Enum.Parse<PatientSeriesType>(Series.seriesType); }
        public IEnumerable<ITargetDose> TargetDoses { get; set; }

        public static IPatientSeries Create(antigenSupportingDataSeries series)
        {
            return new PatientSeries
            {
                Series = series,
                TargetDoses = series.seriesDose.Select(x => new TargetDose { SeriesDose = x })
            };
        }
    }
}
