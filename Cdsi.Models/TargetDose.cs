namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public string AntigenName { get; internal set; }
        public string SeriesName { get; internal set; }
        public string DoseName { get; internal set; }

        public TargetDoseStatus Status { get; set; }
    }
}
