namespace OpenCdsi.Cdsi
{
    public class SeriesEvaluator : ISeriesEvaluator
    {
        public IPatientSeries PatientSeries { get; init; }

        public void Evaluate(IEnumerable<IAntigenDose> immunizationHistory)
        {
            var targets = new LinkedList<ITargetDose>(PatientSeries.TargetDoses);
            var vaccines = new LinkedList<IAntigenDose>(immunizationHistory.Where(x => x.AntigenName == PatientSeries.Antigen));

            var target = targets.First;
            var vaccine = vaccines.First;

            while (target != null)
            {
                target.Value.Status = TargetDoseStatus.NotSatisfied;

                var evaluator = new DoseEvaluator { TargetDose = target };
                if (!evaluator.CanSkip())
                {
                    while (vaccine != null)
                    {
                        evaluator.Evaluate(vaccine);

                        // check the status of the doses and move the pointers accordingly
                        if (target.Value.Status == TargetDoseStatus.Satisfied || target.Value.Status == TargetDoseStatus.Skipped) break;
                       
                        vaccine = vaccine.Next;
                    }
                }
                target = target.Next;
            }
        }
    }
}
