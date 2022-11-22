namespace OpenCdsi.Cdsi
{

    public class AntigenDose : IAntigenDose
    {
        public string AntigenName { get; init; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public IVaccineDose VaccineDose { get; init; }

    }
}
