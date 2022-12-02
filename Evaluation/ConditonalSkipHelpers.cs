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
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkip thing, IEvaluationOptions opts, IDoseContext doseContext)
        {
            return thing.setLogic == "AND"
                 ? thing.set.All(x => x.Evaluate(opts, doseContext))
                 : thing.set.Any(x => x.Evaluate(opts, doseContext));
        }
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSet thing, IEvaluationOptions opts, IDoseContext doseContext)
        {
            return thing.conditionLogic == "AND"
                 ? thing.condition.All(x => x.Evaluate(opts, doseContext))
                 : thing.condition.Any(x => x.Evaluate(opts, doseContext));
        }
        public static bool Evaluate(this antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition thing, IEvaluationOptions opts, IDoseContext doseContext)
        {
            return true;
        }
    }
}
