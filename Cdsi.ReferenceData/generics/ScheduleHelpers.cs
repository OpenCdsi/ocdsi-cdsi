using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingData;

namespace Cdsi.ReferenceData
{
    public static class ScheduleHelpers
    {
        internal static IDictionary<string, string> VaccineTypeMap { get; } = new VaccineTypeMap();

        public static IEnumerable<string> GetAntigens(this scheduleSupportingDataCvxMap[] map, string cvx)
        {
            return map.First(x => x.cvx == cvx).association.Select(x => x.antigen);
        }

        public static string GetVaccineType(this scheduleSupportingData _, string cvx)
        {
            return VaccineTypeMap[cvx];
        }


        public static string GetVaccineDescription(this scheduleSupportingDataCvxMap map)
        {
            return map.shortDescription;
        }

        public static string GetVaccineDescription(this scheduleSupportingDataCvxMap[] map, string cvx)
        {
            return map.First(x => x.cvx == cvx).GetVaccineDescription();
        }
    }
}
