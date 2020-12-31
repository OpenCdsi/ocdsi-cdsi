using System;

namespace Cdsi.TestcaseLibrary
{
    public class Dose : IDose
    {
        public DateTime DateAdministered { get; set; }
        public string VaccineName { get; set; }
        public string CVX { get; set; }
        public string MVX { get; set; }
        public string EvaluationStatus { get; set; }
        public string EvaluationReason { get; set; }
    }
}
