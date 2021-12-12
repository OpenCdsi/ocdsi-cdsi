using System.Collections.Generic;

namespace Cdsi
{
    public class TargetDose : ITargetDose
    {
        public string DoseName { get; internal set; }
        public TargetDoseStatus Status { get; set; } = TargetDoseStatus.NotSatisfied;
        public IList<IInadvertentVaccine> InadvertentVaccines { get; internal set; }
    }
}
