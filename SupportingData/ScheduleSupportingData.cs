using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocdsi.SupportingData
{
    public static class ScheduleSupportingData
    {
        public static IEnumerable<string> AntigensByCvx(this scheduleSupportingData supportingData, string cvx)
        {
            var data = supportingData.cvxToAntigenMap.FirstOrDefault(x=>x.cvx == cvx);
            return data.association.Select(x=>x.antigen).ToList();
        }
    }
}
