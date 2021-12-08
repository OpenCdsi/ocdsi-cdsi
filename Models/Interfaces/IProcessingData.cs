using System;

namespace Cdsi
{
    public interface IProcessingData
    {
        DateTime AssessmentDate { get; }
        IPatient Patient { get; }
    }
}
