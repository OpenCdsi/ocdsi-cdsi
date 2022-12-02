using System.Reflection.PortableExecutable;

namespace OpenCdsi.Cdsi
{
    public class SeriesEvaluator : ISeriesEvaluator
    {
        public IPatientSeries PatientSeries { get; init; }

        public void Evaluate(IEnumerable<IAntigenDose> immunizationHistory, IEvaluationOptions options)
        {
            var targets = new LinkedList<ITargetDose>(PatientSeries.TargetDoses);
            var vaccines = new LinkedList<IAntigenDose>(immunizationHistory);

            var doseEvaluator = GetDoseEvaluator(targets.First, vaccines.First);

            while (doseEvaluator != null)
            {
                doseEvaluator.Evaluate(options);
                doseEvaluator = GetDoseEvaluator(doseEvaluator.TargetDose,doseEvaluator.AdministeredDose);
            }

            PatientSeries.Status = PatientSeries.TargetDoses.All(x => x.Status == TargetDoseStatus.Satisfied)
                ? PatientSeriesStatus.Complete
                : PatientSeriesStatus.NotComplete;
        }

        internal IDoseEvaluator GetDoseEvaluator(LinkedListNode<ITargetDose> target, LinkedListNode<IAntigenDose> vaccine)
        {
            while (target != null)
            {
                if (target.Value.Status == TargetDoseStatus.NotSatisfied) break;
                target = target.Next;
            }

            while (vaccine != null)
            {
                if (vaccine.Value.EvaluationStatus == EvaluationStatus.NotEvaluated) break;
                vaccine = vaccine.Next;
            }

            if (target != null && vaccine != null)
            {
                return new DoseEvaluator { TargetDose = target, AdministeredDose = vaccine };
            }
            else
            {
                return default;
            }
        }
    }
}
