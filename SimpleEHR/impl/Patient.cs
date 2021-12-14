using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public IList<string> ObservationCodes { get; set; }
        public IList<IVaccineDose> AdministeredVaccineDoses { get; set; }
    }
}
