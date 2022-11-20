namespace OpenCdsi.Cdsi
{
    public static partial class SupportingDataExt
    {
        public static IPatientSeries ToModel(this antigenSupportingDataSeries series)
        {
            return new PatientSeries()
            {
                Series = series,
                Status = PatientSeriesStatus.NotComplete,
                TargetDoses = series.seriesDose.Select(x => (ITargetDose)new TargetDose()
                {
                    Status = TargetDoseStatus.NotSatisfied,
                    SeriesDose = x
                }).ToList()
            };
        }
    }
}
