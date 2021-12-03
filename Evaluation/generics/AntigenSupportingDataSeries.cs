using System;
using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;
using Enum = Utility.Enum;

namespace Cdsi.Evaluation
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public static partial class AntigenSupportingDataSeries
    {
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
                beginAge = env.Patient.DOB.Add(Interval.ParseAll(indication.beginAge));
            }
            catch
            {
            };
            try
            {
                endAge = env.Patient.DOB.Add(Interval.ParseAll(indication.endAge));
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
