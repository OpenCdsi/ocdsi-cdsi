using System;

namespace Cdsi.TestcaseLibrary
{
    public class Dose : IDose
    {
        public DateTime DateAdministered { get; internal set; }
        public string VaccineName { get; internal set; }
        public string CVX { get; set; }
        public string MVX { get; internal set; }
        public string EvaluationStatus { get; internal set; }
        public string EvaluationReason { get; internal set; }
    }
}
