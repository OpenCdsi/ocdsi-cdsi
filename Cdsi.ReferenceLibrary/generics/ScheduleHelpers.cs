using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingData;

namespace Cdsi.ReferenceLibrary
{
    public static class ScheduleHelpers
    {
        internal static IDictionary<string, string> VaccineTypeMap { get; } = Factories.CreateVaccineTypeMap();

        public static IEnumerable<string> GetAntigenNames(this scheduleSupportingData schedule, string cvx)
        {
            return schedule.cvxToAntigenMap.First(x => x.cvx == cvx).association.Select(x => x.antigen);
        }

        public static string GetVaccineType(this scheduleSupportingData _, string cvx)
        {
            return VaccineTypeMap[cvx];
        }

        public static string GetVaccineDescription(this scheduleSupportingData schedule, string cvx)
        {
            return schedule.cvxToAntigenMap.First(x => x.cvx == cvx).shortDescription;
        }
    }
}
