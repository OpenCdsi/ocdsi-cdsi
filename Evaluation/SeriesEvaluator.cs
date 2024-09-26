using System.Reflection.PortableExecutable;

namespace Cdsi
{
    public class SeriesEvaluator : ISeriesContext, IEvaluator
    {
        public IPatientSeries PatientSeries { get; init; }
        public IEnumerable<IAntigenDose> ImmunizationHistory { get; init; }

        public bool Evaluate(IEvaluationOptions options)
        {
            var targets = new LinkedList<ITargetDose>(PatientSeries.TargetDoses);
            var vaccines = new LinkedList<IAntigenDose>(ImmunizationHistory);

            var doseEvaluator = DoseEvaluator.Create(targets.First, vaccines.First);

            while (doseEvaluator != null)
            {
                doseEvaluator.Evaluate(options);
                doseEvaluator = doseEvaluator.Next();
            }

            PatientSeries.TargetDoses = targets.ToArray();

            // target doses can be either skipped or satisfied
            PatientSeries.Status = PatientSeries.TargetDoses.All(x => x.Status != TargetDoseStatus.NotSatisfied)
                ? PatientSeriesStatus.Complete
                : PatientSeriesStatus.NotComplete;

            return true;
        }
    }
}
