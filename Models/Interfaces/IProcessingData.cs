using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IProcessingData
    {
        DateTime AssessmentDate { get; }
        IPatient Patient { get; }
        IList<IPatientSeries> RelevantPatientSeries { get; }
    }
}
