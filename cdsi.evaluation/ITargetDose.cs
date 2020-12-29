using cdsi.refData;
using cdsi.supportingData;

namespace cdsi.evaluation
{
    public interface ITargetDose
    {
        AntigenSeriesDoseIdentifier AntigenSeriesDose { get; }
        TargetDoseStatus Status { get; set; }
    }
}