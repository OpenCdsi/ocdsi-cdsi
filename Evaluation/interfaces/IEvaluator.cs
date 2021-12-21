using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface IEvaluator
    {
        void Evaluate(IEnv env);
    }
}
