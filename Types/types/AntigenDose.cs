namespace Cdsi
{

    public class AntigenDose : IAntigenDose
    {
        public string AntigenName { get; init; }
        public IVaccineDose VaccineDose { get; init; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public IList<EvaluationReason> EvaluationReasons { get; } = new List<EvaluationReason>();

    }
}
