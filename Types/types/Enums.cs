using System.ComponentModel;

namespace OpenCdsi.Cdsi
{
    public partial class Parse
    {
        public static T Enum<T>(string s) where T : struct
        {
            return System.Enum.TryParse(s, true, out T result)
                  ? result
                  : default;
        }
    }

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
        Male,
        Unknown
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

    public enum ConditionSetLogic
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
