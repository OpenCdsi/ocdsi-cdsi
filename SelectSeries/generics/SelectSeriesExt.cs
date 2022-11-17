using OpenCdsi.SupportingData;
using OpenCdsi.Date;
using Enum = Utility.Enum;

namespace Cdsi
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public static partial class SelectSeriesExt
    {
        /// <summary>
        /// Select relevant patient series, Cdsi Logic Spec 4.1 Chapter 5.
        /// </summary>
        /// <param name="env"></param>
        /// <remarks>
        /// Note that other patient series' can be Add()ed to the processing data,
        /// for example to evaluate/forecast newborns.
        /// </remarks>
        public static IEnv SelectRelevantPatientSeries(this IEnv env)
        {
            // Todo: what if newborn who doesnt have an immunization history?
            var antigens = env.ImmunizationHistory.Select(x => x.AntigenName).Distinct();

            foreach (var antigen in antigens)
            {
                var sda = OpenCdsi.Data.Antigen[antigen];
                var rs = sda.series.Where(x => x.IsRelevantSeries(env));
                env.RelevantPatientSeries = rs.Select(x => x.ToModel()).ToList();
            }
            return env;
        }

        /// <summary>
        /// The series is indicated for the patient if any of the series indications are indicated.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static bool IsIndicated(this antigenSupportingDataSeries series, IEnv env)
        {
            return series.indication.Select(x => x.IsIndicated(env)).Aggregate(false, (x, y) => x || y);
        }

        public static bool IsIndicated(this antigenSupportingDataSeriesIndication indication, IEnv env)
        {
            var assessmentDate = env.AssessmentDate;
            var patient = env.Patient;
            var beginAge = Defaults.MinAge;
            var endAge = Defaults.MaxAge;

            try
            {
                beginAge = patient.DOB - Duration.Parse(indication.beginAge).Values.First();
            }
            catch
            {
            };
            try
            {
                endAge = patient.DOB + Duration.Parse(indication.endAge).Values.First();
            }
            catch
            {
            };

            return (beginAge <= assessmentDate && assessmentDate <= endAge) && patient.ObservationCodes.Contains(indication.observationCode.code);
        }

        public static bool IsRelevantSeries(this antigenSupportingDataSeries series, IEnv env)
        {
            return series.IsRequiredGender(env.Patient.Gender) && (Enum.TryParse<PatientSeriesType>(series.seriesType) == PatientSeriesType.Standard || series.IsIndicated(env));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="series"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        /// <remarks>TABLE 5-4 IS THE SERIES RELEVANT FOR THE PATIENT?</remarks>
        public static bool IsRequiredGender(this antigenSupportingDataSeries series, Gender gender)
        {
            return string.IsNullOrWhiteSpace(series.requiredGender[0]) || series.requiredGender.Where(x => x == gender.ToString()).Any();
        }
    }
}