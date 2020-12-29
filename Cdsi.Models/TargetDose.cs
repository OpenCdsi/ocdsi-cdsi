using Cdsi.SupportingData;

namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public AntigenSeriesDoseIdentifier AntigenSeriesDose { get; }

        public TargetDoseStatus Status { get; set; }
    }
}
