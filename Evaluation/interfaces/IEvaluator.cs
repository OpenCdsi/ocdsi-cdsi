using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
   public interface IEvaluator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Success or failure</returns>
        bool Evaluate(IEvaluationOptions options);
    }
}
