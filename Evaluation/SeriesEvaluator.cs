namespace OpenCdsi.Cdsi
{
    public class SeriesEvaluator : IEvaluator, ISeriesEvaluator
    {
        private IList<IAntigenDose> _antigenDoses;
        public IList<IAntigenDose> AntigenDoses
        {
            get => _antigenDoses;
            set => _antigenDoses = value.Where(x => x.AntigenName == PatientSeries.Antigen).Select(x => x.Clone()).ToList();
        }

        public IPatientSeries PatientSeries { get; set; }

        public void Evaluate()
        {
            var currentTargetIdx = 0;

            foreach (IAntigenDose antigenDose in AntigenDoses)
            {
                var doseEvaluator = new DoseEvaluator
                {
                    AntigenDose = antigenDose,
                    TargetDose = PatientSeries.TargetDoses[currentTargetIdx]
                };

                doseEvaluator.Evaluate();
                if (doseEvaluator.TargetDose.Status != TargetDoseStatus.NotSatisfied) currentTargetIdx++;
            }
        }
    }
}
