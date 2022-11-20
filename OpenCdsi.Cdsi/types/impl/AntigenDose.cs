using System;

namespace Cdsi
{

    public class AntigenDose : IAntigenDose
    {
        public string AntigenName { get; internal set; }
        public string EvaluationReason { get; set; }
        public EvaluationStatus EvaluationStatus { get; set; }
        public IVaccineDose AdministeredDose { get; internal set; }

    }
}
