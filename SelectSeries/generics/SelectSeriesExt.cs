﻿using Cdsi.SupportingDataLibrary;
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
        public static void SelectRelevantPatientSeries(this IEnv env)
        {
            // Todo: what if newborn who doesnt have an immunization history?
            var antigens = env.ImmunizationHistory.Select(x => x.AntigenName).Distinct();

            foreach (var antigen in antigens)
            {
                var sda = SupportingData.Antigen[antigen];
                var rs = sda.series.Where(x => x.IsRelevantSeries(env));
                env.RelevantPatientSeries = rs.Select(x => x.ToModel()).ToList();
            }
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
                beginAge = patient.DOB - Interval.Parse(indication.beginAge);
            }
            catch
            {
            };
            try
            {
                endAge = patient.DOB + Interval.Parse(indication.endAge);
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