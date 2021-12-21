using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class Env : IEnv
    {
        public IPatient Patient { get; set; }
        public DateTime AssessmentDate { get; set; }
        public IList<IAntigenDose> ImmunizationHistory { get; set; }
        public IList<IPatientSeries> RelevantPatientSeries { get; set; }
    }
}
