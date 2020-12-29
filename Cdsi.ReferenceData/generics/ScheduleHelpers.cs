using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingData;

namespace Cdsi.ReferenceData
{
    public static class ScheduleHelpers
    {
        public static IEnumerable<IAntigenIdentifier> GetAntigens(this scheduleSupportingDataCvxMap[] map, string cvx)
        {
            return map.First(x => x.cvx == cvx).association.Select(x => AntigenIdentifier.Parse(x.antigen));
        }

        public static string GetVaccineType(this scheduleSupportingDataCvxMap map)
        {
            return map.shortDescription;
        }

        public static string GetVaccineType(this scheduleSupportingDataCvxMap[] map, string cvx)
        {
            return map.First(x => x.cvx == cvx).GetVaccineType();
        }
    }
}
