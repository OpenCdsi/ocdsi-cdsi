namespace OpenCdsi.Cdsi
{

    public class AntigenDose : IAntigenDose
    {
        public string AntigenName { get; internal set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public IVaccineDose VaccineDose { get; internal set; }

    }
}
