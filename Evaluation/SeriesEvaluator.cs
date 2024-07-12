using System.Reflection.PortableExecutable;

namespace OpenCdsi.Cdsi
{
    public class SeriesEvaluator : ISeriesContext, IEvaluator
    {
        public IPatientSeries PatientSeries { get; init; }
        public IEnumerable<IAntigenDose> ImmunizationHistory { get; init; }

        public bool Evaluate(IEvaluationOptions options)
        {
            var targets = new LinkedList<ITargetDose>(PatientSeries.TargetDoses);
            var vaccines = new LinkedList<IAntigenDose>(ImmunizationHistory);

            var doseEvaluator = GetDoseEvaluator(targets.First, vaccines.First);

            while (doseEvaluator != null)
            {
                doseEvaluator.Evaluate(options);
                doseEvaluator = GetDoseEvaluator(doseEvaluator.TargetDose.Next, doseEvaluator.AdministeredDose.Next);
            }

            PatientSeries.TargetDoses= targets.ToArray();

            PatientSeries.Status = PatientSeries.TargetDoses.All(x => x.Status == TargetDoseStatus.Satisfied)
                ? PatientSeriesStatus.Complete
                : PatientSeriesStatus.NotComplete;

            return true;
        }

        internal DoseEvaluator GetDoseEvaluator(LinkedListNode<ITargetDose> target, LinkedListNode<IAntigenDose> vaccine)
        {
            return (target == null || vaccine == null)
                  ? default
                  : new DoseEvaluator { TargetDose = target, AdministeredDose = vaccine };
        }
    }
}
