using System.Collections.Generic;

namespace Cdsi
{
    /// <summary>
    /// Tracks the state of the dose in the patient series.
    /// </summary>
    public interface ITargetDose
    {
        string DoseName { get; }
        TargetDoseStatus Status { get; set; }
        IList<IInadvertentVaccine> InadvertentVaccines { get; }
    }
}