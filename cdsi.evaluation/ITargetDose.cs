using cdsi.refData;

namespace cdsi.evaluation
{
    public interface ITargetDose
    {
        antigenSupportingDataSeriesSeriesDose RefData { get; }
        TargetDoseStatus Status { get; set; }
    }
}