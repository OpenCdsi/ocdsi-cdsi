using System.Collections.Generic;
using System.Linq;
using OpenCdsi.Cases;
using System;

namespace OpenCdsi.Cdsi.UnitTests
{
    public static class TestcaseLibraryExt
    {
        public static IPatient ToEhr(this testcasePatient tp, IEnumerable<testcaseVaccineDoseAdministered> tvda)
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
                ObservationCodes = new List<string>(),
                VaccineHistory = tvda.Select(x => x.ToEhr()).ToList()
            };

            return patient;
        }

        public static IVaccineDose ToEhr(this testcaseVaccineDoseAdministered dose)
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

        public static IEnv GetEnv(this testcase testcase)
        {
            var env = new Env();
            env.Patient = testcase.Patient.ToEhr(testcase.Doses);
            env.AssessmentDate = testcase.AssessmentDate;

            return env;
        }
    }
}

