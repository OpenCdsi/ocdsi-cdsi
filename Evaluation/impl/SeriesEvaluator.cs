using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class SeriesEvaluator : IEvaluator, ISeriesEvaluator
    {
        public void Evaluate(IEnv env)
        {
            var antigendoses = env.Get<IList<IAntigenDose>>(Env.Patient)
            throw new NotImplementedException();
        }
    }
}
