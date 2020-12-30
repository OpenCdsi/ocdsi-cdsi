using System.Collections.Generic;
using System.Linq;
using Cdsi.ReferenceLibrary;

namespace Cdsi.Models
{
    public static class ConversionHelpers
    {
        public static IEnumerable<IAdministeredDose> ToAdministeredDoses(this IVaccineDose dose)
        {
            return Reference.Schedule.cvxToAntigenMap.GetAntigens(dose.CVX)
                  .Select(x => new AdministeredDose()
                  {
                      AntigenName = x,
                      DateAdministered = dose.DateAdministered,
                      VaccineType = dose.VaccineType,
                      EvaluationStatus = EvaluationStatus.NotValid,
                      LotExpiration = Defaults.LotExpiration
                  });
        }
    }
}
