using Cdsi.SupportingData;

namespace Cdsi.Models
{
    public interface ITargetDose
    {
        string AntigenSeriesDose { get; }
        TargetDoseStatus Status { get; set; }
    }
}