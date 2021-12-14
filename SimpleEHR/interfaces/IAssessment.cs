using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IAssessment
    {
        DateTime AssessmentDate { get; }
        IPatient Patient { get; }
    }
}
