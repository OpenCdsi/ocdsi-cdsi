using System.Collections.Generic;
using System.Linq;

namespace Cdsi.ReferenceData
{
    public class VaccineTypeMap : Dictionary<string, string>
    {
        public VaccineTypeMap()
        {
            foreach (var item in Reference.Antigen.Values
                 .SelectMany(x => x.series)
                 .SelectMany(x => x.seriesDose)
                 .SelectMany(x => x.preferableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))
                     .Concat(x.allowableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))))
                 .Distinct()
                 .Where(x => !string.IsNullOrWhiteSpace(x.Key)))
            {
                    this[item.Key] = item.Value;
            }
        }
    }
}
