namespace Cdsi
{
    public class TargetDose : ITargetDose
    {
        public string DoseName { get; internal set; }
        public TargetDoseStatus Status { get; set; }
    }
}
