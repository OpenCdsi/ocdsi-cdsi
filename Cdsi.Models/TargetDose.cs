namespace Cdsi.Models
{
    public class TargetDose : ITargetDose
    {
        public string DoseName { get; set; }
        public TargetDoseStatus Status { get; set; }
    }
}
