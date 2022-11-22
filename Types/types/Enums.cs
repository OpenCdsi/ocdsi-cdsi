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

    public enum Gender
    {
        Any,
        Female,
        Transgender,
        Male,
        Unknown
    }
}
