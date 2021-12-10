using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    public static class VaccineDoseHelpers
    {
        public static IEnumerable<IAntigenDose> AsAntigenDoses(this IVaccineDose dose)
        {
            return SupportingData.Schedule.GetAntigenNames(dose.CVX)
                .Select(x => new AntigenDose
                {
                    AntigenName = x,
                    DateAdministered = dose.DateAdministered,
                    VaccineDescription = dose.VaccineDescription,
                    VaccineType = dose.VaccineType,
                    CVX = dose.CVX,
                    MVX = dose.MVX,
                    LotExpiration = dose.LotExpiration,
                    DoseCondition = dose.DoseCondition
                });
        }
    }
}
