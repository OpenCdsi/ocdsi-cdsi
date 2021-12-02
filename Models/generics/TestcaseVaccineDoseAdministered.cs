using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static class TestcaseVaccineDoseAdministered
    {
        public static VaccineDose ToModel(this testcaseVaccineDoseAdministered dose)
        {
            return new VaccineDose
            {
                CVX = dose.CVX,
                MVX = dose.MVX,
                DateAdministered = dose.DateAdministered,
                LotExpiration = Defaults.LotExpiration,
                VaccineType = dose.VaccineName
            };
        }
    }
}
