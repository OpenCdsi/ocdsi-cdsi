using System.Collections.Generic;
using System.Linq;
using OpenCdsi.Cases;
using System;

namespace OpenCdsi.Cdsi.UnitTests
{
    public static class TestcaseLibraryExt
    {
        public static IPatient ToCdsiType(this testcasePatient tp, IEnumerable<testcaseVaccineDoseAdministered> tvda)
        {
            var gender = tp.Gender.ToLower().First() switch
            {
                'f' => Gender.Female,
                'm' => Gender.Male,
                _ => Gender.Unknown
            };

            var patient = new Patient
            {
                DOB = tp.DOB,
                Gender = gender,
                VaccineHistory = tvda.Select(x => x.ToCdsiType()).ToList()
            };

            return patient;
        }

        public static IList<IVaccineDose> ToCdsiType(this IEnumerable<testcaseVaccineDoseAdministered> doses)
        {
            return doses.Select(x => x.ToCdsiType()).ToList();
        }

        public static IVaccineDose ToCdsiType(this testcaseVaccineDoseAdministered dose)
        {
            return new VaccineDose
            {
                CVX = dose.CVX,
                MVX = dose.MVX,
                DateAdministered = dose.DateAdministered,
                LotExpiration = new DateTime(2999, 12, 31),
                VaccineType = dose.VaccineName
            };
        }
    }
}

