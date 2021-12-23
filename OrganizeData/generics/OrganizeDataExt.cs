using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public static class OrganizeDataExt
    {
        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static void OrganizeImmunizationHistory(this IEnv env)
        {
            var patient = env.Patient;

            var immunizationHistory = patient.AdministeredVaccineDoses
                .SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.AdministeredDose.DateAdministered)
                .ToList();

            env.ImmunizationHistory = immunizationHistory;
        }
    }
}
