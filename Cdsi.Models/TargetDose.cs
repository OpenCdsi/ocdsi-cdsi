using Cdsi.SupportingData;

namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public string AntigenSeriesDose { get; }

        public TargetDoseStatus Status { get; set; }
    }
}
