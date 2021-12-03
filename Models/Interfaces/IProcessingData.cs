using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IProcessingData
    {
        System.DateTime AssessmentDate { get; }
        IPatient Patient { get; }
        IEnumerable<IVaccineDose> Doses { get; }
    }
}
