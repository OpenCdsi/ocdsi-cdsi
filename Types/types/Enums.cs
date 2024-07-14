using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cdsi
{
    // Table 3-1
    public enum EvaluationStatus
    {
        NotEvaluated,
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
        NotEvaluated,
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

    public enum Gender
    {
        Any,
        Female,
        Transgender,
        Male
    }

    public enum EvaluationReason
    {
        InadvertentAdministration,
        AgeGracePeriod,
        IntervalGracePeriod,
        AgeTooYoung,
        AgeTooOld,
        IntervalTooSoon,
        LiveVirusConflict,
        VaccineOutOfAgeRange,
        VaccineWrongTradename,
        VaccineLessThanRecommendedVolume
    }

    public enum ConditionLogic
    {
        NA,
        AND,
        OR
    }

    public enum ConditionalSkipContext
    {
        Evaluation,
        Forecast
    }

    public enum ConditionalSkipType
    {
        Age,
        Interval,
        CompletedSeries,
        VaccineCountByAge,
        VaccineCountByDate
    }

    public enum ConditionalSkipDoseCountLogic
    {
        NA,
        EqualTo,
        GreaterThan,
        LessThan
    }

    public enum ConditionalSkipDoseType
    {
        NA,
        Valid,
        Total
    }
}
