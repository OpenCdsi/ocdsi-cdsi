using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{
    public enum Gender
    {
        Female,
        Male
    }

    // Table 3-1
    public enum EvaluationStatus
    {
        NotValid,
        SubStandard,
        Extraneous,
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
        NotComplete,
        Contraindicated,
        NotRecommended,
        AgedOut,
        Immune,
        Complete
    }
}
