using System.Collections.Generic;
using Cdsi.ReferenceData;

namespace Cdsi.Models
{
    public interface IPatientSeries
    {
        IAntigenSeriesIdentifier AntigenSeriesIdentifier { get; }
        IEnumerable<ITargetDose> TargetDoses { get; }
        PatientSeriesStatus Status { get; set; }
    }
}