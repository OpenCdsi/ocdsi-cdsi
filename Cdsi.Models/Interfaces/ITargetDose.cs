using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    public interface ITargetDose
    {
        IAntigenSeriesDoseIdentifier AntigenSeriesDoseIdentifier { get; }
        TargetDoseStatus Status { get; set; }
    }
}