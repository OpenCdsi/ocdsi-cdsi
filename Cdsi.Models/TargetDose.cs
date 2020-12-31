namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public string AntigenName { get;  set; }
        public string SeriesName { get;  set; }
        public string DoseName { get;  set; }

        public TargetDoseStatus Status { get; set; }
    }
}
