using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdsi.TestcaseLibrary;
using Enum = Utility.Enum;

namespace Cdsi
{
    public static partial class TestcasePatient
    {

        public static Patient ToModel(this testcasePatient tp, IEnumerable<testcaseVaccineDoseAdministered> tvda)
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
