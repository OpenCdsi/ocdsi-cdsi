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

        public static Patient ToModel(this testcasePatient patient)
        {
            var gender = patient.Gender switch
            {
                "F" => Gender.Female,
                "Female" => Gender.Female,
                "M" => Gender.Male,
                "Male" => Gender.Male,
                _ => Gender.Unknown
            };

            return new Patient
            {
                DOB = patient.DOB,
                Gender = gender
            };
        }
    }
}
