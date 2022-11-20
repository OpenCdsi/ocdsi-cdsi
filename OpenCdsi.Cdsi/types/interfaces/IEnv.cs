using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface IEnv
    {
        IPatient Patient { get; set; }
        DateTime AssessmentDate { get; set; }
        IList<IAntigenDose> ImmunizationHistory { get; set; }
        IList<IPatientSeries> RelevantPatientSeries { get; set; }
    }
}
