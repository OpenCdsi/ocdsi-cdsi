namespace Cdsi
{
    public enum IntervalUnit
    {
        Day,
        Week,
        Month,
        Year
    }

    public enum Gender
    {
        Unknown,
        Female,
        Transgender,
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

    public enum PatientSeriesType
    {
        NotSpecified,
        Standard,
        Risk
    }
}
