using System;
using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;

namespace Cdsi.Evaluation
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public static partial class AntigenSupportingDataSeries
    {
        /// <summary>
        /// Gets a list of the observation codes from the supporting data.
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public static IEnumerable<string> Indications(this antigenSupportingDataSeries series)
        {
            return series.indication.Select(x => x.observationCode.code);
        }

        /// <summary>
        /// The series is indicated for the patient if the patient's record has an
        /// observation code in the series' indications list.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static bool IsIndicated(this antigenSupportingDataSeries series, IPatient patient)
        {
            // TODO add checks for beginAge/endAge. will require assessment date.
            var indications = Indications(series);
            return indications.Select(x => patient.ObservationCodes.Contains(x)).Any();
        }

        public static bool IsRelevantSeries(this antigenSupportingDataSeries series, IPatient patient)
        {
            return series.IsRequiredGender(patient.Gender) && (series.seriesType == "Standard" || IsIndicated(series, patient));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="series"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        /// <see cref="TABLE 5-4 IS THE SERIES RELEVANT FOR THE PATIENT?"/>
        public static bool IsRequiredGender(this antigenSupportingDataSeries series, Gender gender)
        {
            return !series.requiredGender.Where(x => !string.IsNullOrWhiteSpace(x)).Any() || series.requiredGender.Where(x => x == gender.ToString()).Any();
        }
    }
}
