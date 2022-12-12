using OpenCdsi.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCdsi.Calendar;
using System.Transactions;

namespace OpenCdsi.Cdsi
{
    public static class ConditonalSkipHelpers
    {
        // There is an inordinate amount of code that does nothing but dispatches the arguments to the correct
        // method.
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkip thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            return thing.setLogic == "AND"
                 ? thing.set.All(x => x.Evaluate(options, doseContext))
                 : thing.set.Any(x => x.Evaluate(options, doseContext));
        }
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSet thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            return thing.conditionLogic == "AND"
                 ? thing.condition.All(x => x.Evaluate(options, doseContext))
                 : thing.condition.Any(x => x.Evaluate(options, doseContext));
        }
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            var conditionType = Enum.Parse<ConditionalSkipType>(thing.conditionType.Replace(" ", ""));

            switch (conditionType)
            {
                case ConditionalSkipType.Age:
                    return thing.SkipByAge(options, doseContext);
                case ConditionalSkipType.Interval:
                    return thing.SkipByInterval(options, doseContext);
                case ConditionalSkipType.CompletedSeries:
                    return thing.SkipByCompletedSeries(options, doseContext);
                case ConditionalSkipType.VaccineCountByAge:
                case ConditionalSkipType.VaccineCountByDate:
                    return thing.SkipByVaccineCount(options, doseContext);
                default:
                    return false;
            }
        }

        public static bool SkipByAge(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            var beginAge = options.DateOfBirth.Add(thing.beginAge);
            var endAge = options.DateOfBirth.Add(thing.endAge);

            return endAge > options.DateOfBirth && options.DateOfBirth >= beginAge;
        }

        public static bool SkipByInterval(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            var intervalDate = doseContext.AdministeredDose.Previous.Value.VaccineDose.DateAdministered.Add(thing.interval);

            return doseContext.AdministeredDose.Previous != null && options.DateOfBirth >= intervalDate;
        }

        public static bool SkipByCompletedSeries(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }

        public static bool SkipByVaccineCount(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            var countLogic = Enum.Parse<ConditionalSkipDoseCountLogic>(thing.doseCountLogic);
            var conditionalDoseCount = thing.GetVaccineCount(options, doseContext);
            var doseCount = int.Parse(thing.doseCount);

            switch (countLogic)
            {
                case ConditionalSkipDoseCountLogic.EqualTo:
                    return doseCount == conditionalDoseCount;
                case ConditionalSkipDoseCountLogic.GreaterThan:
                    return doseCount > conditionalDoseCount;
                case ConditionalSkipDoseCountLogic.LessThan:
                    return doseCount < conditionalDoseCount;
                default:
                    return false;
            }
        }

        public static int GetVaccineCount(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions options, IDoseContext doseContext)
        {
            var conditionType = Enum.Parse<ConditionalSkipType>(thing.conditionType.Replace(" ", ""));
            var types = thing.vaccineTypes.Split(',').Select(x => x.Trim());
            var conditionalskipdosetype = Enum.Parse<ConditionalSkipDoseType>(thing.doseType);

            DateTime beginDate;
            DateTime endDate;

            if (conditionType == ConditionalSkipType.VaccineCountByAge)
            {
                // skip-by-count-by-age
                beginDate = options.DateOfBirth.Add(thing.beginAge, Date.MinValue);
                endDate = options.DateOfBirth.Add(thing.endAge, Date.MaxValue);
            }
            else
            {
                // skip-by-count-by-interval
                beginDate = Date.Parse(thing.startDate, Date.MinValue);
                endDate = Date.Parse(thing.endDate, Date.MaxValue);
            }

            var current = doseContext.AdministeredDose;
            var count = 0;

            while (current != null)
            {
                if (beginDate <= current.Value.VaccineDose.DateAdministered
                    && current.Value.VaccineDose.DateAdministered < endDate
                    && types.Contains(current.Value.VaccineDose.VaccineType)
                    && (conditionalskipdosetype == ConditionalSkipDoseType.Valid
                    ? current.Value.EvaluationStatus == EvaluationStatus.Valid
                    : true))
                {
                    count++;
                }
                current = current.Previous;
            }
            return count;
        }
    }
}
