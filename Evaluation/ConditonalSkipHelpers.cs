using OpenCdsi.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
    public static class ConditonalSkipHelpers
    {
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
                    return SkipByAge(options, doseContext);
                case ConditionalSkipType.Interval:
                    return SkipByInterval(options, doseContext);
                case ConditionalSkipType.CompletedSeries:
                    return SkipByCompletedSeries(options, doseContext);
                case ConditionalSkipType.VaccineCountByAge:
                    return SkipByVaccineCountByAge(options, doseContext);
                case ConditionalSkipType.VaccineCountByDate:
                    return SkipByVaccineCountByDate(options, doseContext);
                default:
                    return false;
            }
        }

        public static bool SkipByAge(IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }

        public static bool SkipByInterval(IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }

        public static bool SkipByCompletedSeries(IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }

        public static bool SkipByVaccineCountByAge(IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }

        public static bool SkipByVaccineCountByDate(IEvaluationOptions options, IDoseContext doseContext)
        {
            return false;
        }
    }
}
