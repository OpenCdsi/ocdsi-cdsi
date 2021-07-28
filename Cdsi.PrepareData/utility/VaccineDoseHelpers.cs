using System.Collections.Generic;
using System.Linq;
using Cdsi.ReferenceLibrary;

namespace Cdsi.PrepareData
{
    public static class VaccineDoseHelpers
    {
        public static IEnumerable<IAntigenDose> ToAntigenDoses(this IVaccineDose dose)
        {
            return Reference.Schedule.GetAntigenNames(dose.CVX)
                  .Select(x => new AntigenDose()
                  {
                      AntigenName = x,
                      DateAdministered = dose.DateAdministered,
                      VaccineType = dose.VaccineType,
                      EvaluationStatus = EvaluationStatus.NotValid,
                      LotExpiration = Defaults.LotExpiration
                  });
        }

        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        /// <param name="administeredDoses"></param>
        /// <returns></returns>
        public static IEnumerable<IAntigenDose> OrganizeImmunizationHistory(IEnumerable<IVaccineDose> administeredDoses)
        {
            return administeredDoses.SelectMany(x => x.ToAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.DateAdministered);
        }
    }
}
