using Ocdsi.Calendar;
using Ocdsi.SupportingData;

namespace OpenCdsi.Cdsi
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public class SeriesSelector
    {
        public IPatient Patient { get; init; }
        public DateTime AssessmentDate { get; init; }

        /// <summary>
        /// Select relevant patient series, Cdsi Logic Spec 4.1 Chapter 5.
        /// </summary>
        public IEnumerable<IPatientSeries> SelectRelevantPatientSeries(IEnumerable<antigenSupportingData> antigens)
        {
            return antigens.SelectMany(x => SelectRelevantPatientSeries(x));
        }

        public IEnumerable<IPatientSeries> SelectRelevantPatientSeries(antigenSupportingData antigen)
        {
            return antigen.series
                .Where(x => IsRelevantSeries(x))
                .Select(x => ToOcdsiType(x));
        }

        public bool IsRelevantSeries(antigenSupportingDataSeries series)
        {
            return IsRequiredGender(series) && (Enum.Parse<PatientSeriesType>(series.seriesType) == PatientSeriesType.Standard || IsIndicated(series));
        }

        /// <summary>
        /// The series is indicated for the patient if any of the series indications are indicated.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool IsIndicated(antigenSupportingDataSeries series)
        {
            return series.indication.Select(x => IsIndicated(x)).Aggregate(false, (x, y) => x || y);
        }

        public bool IsIndicated(antigenSupportingDataSeriesIndication indication)
        {
            DateTime beginDate, endDate;

            try
            {
                beginDate = Patient.DOB - Interval.Parse(indication.beginAge);
            }
            catch
            {
                beginDate = Date.MinValue;
            };
            try
            {
                endDate = Patient.DOB + Interval.Parse(indication.endAge);
            }
            catch
            {
                endDate = Date.MaxValue;
            };

            return (beginDate < AssessmentDate && AssessmentDate <= endDate)
                    && Patient.Observations.Any(x => x.Code == indication.observationCode.code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="series"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        /// <remarks>TABLE 5-4 IS THE SERIES RELEVANT FOR THE PATIENT?</remarks>
        public bool IsRequiredGender(antigenSupportingDataSeries series)
        {
            var genders = series.requiredGender.Select(x => Enum.Parse<Gender>(x));
            return genders.Contains(Patient.Gender) || genders.Contains(Gender.Any);
        }

        public IPatientSeries ToOcdsiType(antigenSupportingDataSeries series)
        {
            return new PatientSeries()
            {
                Series = series,
                Status = PatientSeriesStatus.NotComplete,
                TargetDoses = series.seriesDose.Select(x => (ITargetDose)new TargetDose()
                {
                    Status = TargetDoseStatus.NotSatisfied,
                    SeriesDose = x
                }).ToList()
            };
        }
    }
}