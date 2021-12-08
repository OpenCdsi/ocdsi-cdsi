using System.Collections.Generic;
using System.Linq;
using Cdsi.TestcaseLibrary;

namespace Cdsi.UnitTests
{
    public static class Factories
    {
        public static Patient ToModel(this testcasePatient patient)
        {
            return new Patient()
            {
                DOB = patient.DOB,
                Gender = patient.Gender.ToLower().StartsWith("f") ? Gender.Female : Gender.Male
            };
        }

        public static IEnumerable<AntigenDose> ToModel(this IEnumerable<testcaseVaccineDoseAdministered> doses)
        {
            return doses.Select(x => x.ToModel()).SelectMany(x => x.AsAntigenDoses());
        }
    }
}
