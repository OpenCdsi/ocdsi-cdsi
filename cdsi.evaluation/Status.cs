using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{
    // Table 3-1
    public enum EvaluationStatus
    {
        Extraneous,
        NotValid,
        SubStandard,
        Valid
    }

    // Table 3-2
    public enum TargetDoseStatus
    {
        NotSatisfied,
        Satisfied,
        Skipped
    }

    // Table 3-3
    public enum PatientSeriesStatus
    {
        AgedOut,
        Complete,
        Contraindicated,
        Immune,
        NotComplete,
        NotRecommended
    }
}
