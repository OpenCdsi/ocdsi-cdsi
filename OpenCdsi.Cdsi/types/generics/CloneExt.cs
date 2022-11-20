using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public static class CloneExt
    {
        public static IAntigenDose Clone(this IAntigenDose obj)
        {
            return new AntigenDose
            {
                AntigenName = obj.AntigenName,
                AdministeredDose = obj.AdministeredDose,
                EvaluationStatus = EvaluationStatus.NotValid
            };
        }
    }
}
