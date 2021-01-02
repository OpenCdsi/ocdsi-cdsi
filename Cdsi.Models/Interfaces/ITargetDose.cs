namespace Cdsi.Models
{
    public interface ITargetDose
    {
        string DoseName { get; }
        TargetDoseStatus Status { get; set; }
    }
}