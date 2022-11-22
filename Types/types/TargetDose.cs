using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public class TargetDose : ITargetDose
    {
        public TargetDoseStatus Status { get; set; }
        public antigenSupportingDataSeriesSeriesDose SeriesDose { get; init; }
    }
}
