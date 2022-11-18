using System;
using System.Collections.Generic;

namespace Cdsi
{
    public class Patient : IPatient
    {
        public DateTime DOB { get; init; }
        public Gender Gender { get; init; }
        public IList<string> ObservationCodes { get; init; } = new List<string>();
        public IList<IVaccineDose> AdministeredVaccineDoses { get; init; } = new List<IVaccineDose>();
    }
}
