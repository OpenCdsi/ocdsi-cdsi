using Cdsi.SupportingDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = Utility.Enum;


namespace Cdsi
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public static class SelectSeriesExt
    {
        /// <summary>
        /// Select relevant patient series, Cdsi Logic Spec 4.1 Chapter 5.
        /// </summary>
        /// <param name="env"></param>
        /// <remarks>
        /// Note that other patient series' can be Add()ed to the processing data,
        /// for example to evaluate/forecast newborns.
        /// </remarks>
        public static void SelectRelevantPatientSeries(this IProcessingData env)
        {
            var antigens = env.ImmunizationHistory.Select(x => x.AntigenName).Distinct();
            foreach (var antigen in antigens)
            {
                var sda = SupportingData.Antigen[antigen];
                var rs = sda.series.Where(x => x.IsRelevantSeries(env)).ToList();
                env.RelevantPatientSeries.AddAll(rs.Select(x => x.ToModel(env.ImmunizationHistory.Where(x => x.AntigenName == antigen))));
            }
        }

        /// <summary>
        /// The series is indicated for the patient if any of the series indications are indicated.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static bool IsIndicated(this antigenSupportingDataSeries series, IProcessingData env)
        {
            return series.indication.Select(x => x.IsIndicated(env)).Aggregate(false, (x, y) => x || y);
        }

        public static bool IsIndicated(this antigenSupportingDataSeriesIndication indication, IProcessingData env)
        {
            var beginAge = Defaults.MinAge;
            var endAge = Defaults.MaxAge;
            try
            {
                beginAge = env.Patient.DOB - Interval.Parse(indication.beginAge);
            }
            catch
            {
            };
            try
            {
                endAge = env.Patient.DOB + Interval.Parse(indication.endAge);
            }
            catch
            {
            };

            return (beginAge <= env.AssessmentDate && env.AssessmentDate <= endAge) && env.Patient.ObservationCodes.Contains(indication.observationCode.code);
        }

        public static bool IsRelevantSeries(this antigenSupportingDataSeries series, IProcessingData env)
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
            return !series.requiredGender.Where(x => !string.IsNullOrWhiteSpace(x)).Any() || series.requiredGender.Where(x => x == gender.ToString()).Any();
        }
    }
}