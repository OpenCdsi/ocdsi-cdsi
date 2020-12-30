namespace Cdsi.Models
{
    public interface ITargetDose
    {
        string AntigenName { get; }
        string SeriesName { get; }
        string DoseName { get; }
        TargetDoseStatus Status { get; set; }
    }
}