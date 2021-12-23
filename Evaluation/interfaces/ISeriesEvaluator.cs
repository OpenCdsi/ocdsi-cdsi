using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface ISeriesEvaluator
    {
        IList<IAntigenDose> AntigenDoses { get; }
        IPatientSeries PatientSeries { get; }
    }
}
