using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public IAntigenSeriesDoseIdentifier AntigenSeriesDoseIdentifier { get; internal set; }

        public TargetDoseStatus Status { get; set; }
    }
}
