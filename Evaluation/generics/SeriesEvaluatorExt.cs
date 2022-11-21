namespace OpenCdsi.Cdsi.Evaluation
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
