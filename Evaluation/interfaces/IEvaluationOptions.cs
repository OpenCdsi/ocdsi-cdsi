using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
    public interface IEvaluationOptions
    {
        DateTime AssessmentDate { get; }
        DateTime DateOfBirth { get; }
        IEnumerable<IPatientObservation> Observations { get; }
    }
}
