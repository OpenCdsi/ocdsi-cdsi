using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{

    public class AdministeredDose
    {
        public EvaluationStatus Status { get; set; } = EvaluationStatus.Unknown;
        public DateTime DateAdministered {get;set;}
    }
}
