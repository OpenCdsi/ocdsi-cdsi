using System.Collections.Generic;
using System.Linq;
using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static partial class TestcasePatient
    {

        public static IPatient ToModel(this testcasePatient tp, IEnumerable<testcaseVaccineDoseAdministered> tvda)
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
                Gender = gender
            };

            patient.AdministeredVaccineDoses.AddAll(tvda.Select(x => x.ToModel()));

            return patient;
        }
    }
}
