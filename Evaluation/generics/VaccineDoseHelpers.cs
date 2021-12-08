using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    public static class VaccineDoseHelpers
    {
        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        /// <param name="administeredDoses"></param>
        /// <returns></returns>
        public static IEnumerable<AntigenDose> OrganizeImmunizationHistory(this IEnumerable<IVaccineDose> administeredDoses)
        {
            return administeredDoses.SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.DateAdministered);
        }
    }
}
