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
            return new Patient
            {
                DOB = patient.DOB,
                Gender = Enum.TryParse<Gender>(patient.Gender)
            };
        }
    }
}
