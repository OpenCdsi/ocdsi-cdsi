namespace Cdsi
{
    public class TargetDose : ITargetDose
    {
        public string DoseName { get; set; }
        public TargetDoseStatus Status { get; set; }
    }
}
