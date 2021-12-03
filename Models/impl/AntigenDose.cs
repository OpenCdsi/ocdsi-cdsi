using System;

namespace Cdsi
{

    public class AntigenDose :VaccineDose, IAntigenDose
    {
        public string AntigenName { get; set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; } = EvaluationStatus.NotValid;
    }
}
