using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.models
{
    // Table 3-1
    public enum EvaluationStatus
    {
        Unknown,
        Extraneous,
        NotValid,
        SubStandard,
        Valid
    }

    // Table 3-2
    public enum TargetDoseStatus
    {
        Unknown,
        NotSatisfied,
        Satisfied,
        Skipped
    }
    \// Table 3-3
    public enum PatientSeriesStatus
    {
        Unknown,
        AgedOut,
        Complete,
        Contraindicated,
        Immune,
        NotComplete,
        NotRecommended
    }
}
