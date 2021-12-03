using System.Collections.Generic;
using System.Linq;
using Cdsi.Evaluation;
using Cdsi.SupportingDataLibrary;
using Cdsi.TestcaseLibrary;

namespace Cdsi.UnitTests
{
    public static class Factories
    {
        public static IPatient ToModel(this testcasePatient patient)
        {
            return new Patient()
            {
                DOB = patient.DOB,
                Gender = patient.Gender.ToLower().StartsWith("f") ? Gender.Female : Gender.Male
            };
        }

        public static IVaccineDose ToModel(this testcaseVaccineDoseAdministered dose)
        {
            return new VaccineDose()
            {
                CVX = dose.CVX,
                MVX = dose.MVX,
                DateAdministered = dose.DateAdministered,
                VaccineDescription = SupportingData.Schedule.GetVaccineDescription(dose.CVX),
                VaccineType = SupportingData.Schedule.GetVaccineType(dose.CVX)
            };
        }

        public static IEnumerable<IAntigenDose> ToModel(this IEnumerable<testcaseVaccineDoseAdministered> doses)
        {
            return doses.Select(x => x.ToModel()).SelectMany(x => x.AsAntigenDoses());
        }
    }
}
