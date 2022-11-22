namespace OpenCdsi.Cdsi
{
    public class SeriesEvaluator :  ISeriesEvaluator
    {
        public IPatientSeries PatientSeries { get; init; }

        public IEnumerable<IAntigenDose> Evaluate(IEnumerable<IAntigenDose> immunizationHistory)
        {
            var targets = new LinkedList<ITargetDose>(PatientSeries.TargetDoses);
            var vaccines = new LinkedList<IAntigenDose>(immunizationHistory);

        //    {
        //    var currentTargetIdx = 0;

        //    foreach (IAntigenDose antigenDose in AntigenDoses)
        //    {
        //        var doseEvaluator = new DoseEvaluator
        //        {
        //            AntigenDose = antigenDose,
        //            TargetDose = PatientSeries.TargetDoses[currentTargetIdx]
        //        };

        //        doseEvaluator.Evaluate();
        //        if (doseEvaluator.TargetDose.Status != TargetDoseStatus.NotSatisfied) currentTargetIdx++;
        //    }
        //}

            throw new NotImplementedException();
        }
    }
}
