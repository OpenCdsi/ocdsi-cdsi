using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class Env : Dictionary<object, object>, IEnv
    {
        public const string Patient = "PATIENT";
        public const string AssessmentDate = "ASSESSMENT_DATE";
        public const string ImmunizationHistory = "IMMUNIZATION_HISTORY";
        public const string RelevantPatientSeries = "RELEVANT_PATIENT_SERIES";

        public T Get<T>(object key)
        {
            return (T)this[key];
        }

        public void Set(object key, object value)
        {
            this[key] = value;
        }
    }
}
