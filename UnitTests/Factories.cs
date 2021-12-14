using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<IAntigenDose> ToModel(this IEnumerable<testcaseVaccineDoseAdministered> doses)
        {
            return doses.Select(x => x.ToEhr()).SelectMany(x => x.AsAntigenDoses());
        }
    }
}
