using Cdsi.SupportingData;

namespace Cdsi.Models
{
    public interface ITargetDose
    {
        AntigenSeriesDoseIdentifier AntigenSeriesDose { get; }
        TargetDoseStatus Status { get; set; }
    }
}