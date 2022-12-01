using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
    public class EvaluationOptions : IEvaluationOptions
    {
        public DateTime AssessmentDate { get; init; }
        public DateTime DateOfBirth { get; init; }
        public IEnumerable<IPatientObservation> Observations { get; } = Array.Empty<IPatientObservation>();
    }
}
