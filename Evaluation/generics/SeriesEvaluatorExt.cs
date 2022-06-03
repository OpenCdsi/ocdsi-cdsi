using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public static class SeriesEvaluatorExt
    {
        public static IEnv EvaluatePatientSeries(this IEnv env)
        {
            foreach (IPatientSeries patientSeries in env.RelevantPatientSeries)
            {
                var evaluator = new SeriesEvaluator()
                {
                    PatientSeries = patientSeries,
                    AntigenDoses = env.ImmunizationHistory
                };

                evaluator.Evaluate();
            }

            return env;
        }
    }
}
