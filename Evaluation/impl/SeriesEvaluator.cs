using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class SeriesEvaluator : IEvaluator, ISeriesEvaluator
    {
        private IList<IAntigenDose> _antigenDoses;
        private IList<ITargetDose> _targetDoses;

        public SeriesEvaluator(IList<IAntigenDose> antigenDoses, IPatientSeries series)
        {
            _antigenDoses = antigenDoses.Where(x => x.AntigenName == series.Antigen).Select(x => x.Clone()).ToList();
            _targetDoses = series.TargetDoses;
        }

        public void Evaluate(IEnv env)
        {
        }
    }
}
