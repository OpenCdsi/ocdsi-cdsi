using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; set; }
        Gender Gender { get; set; }
        IList<string> ObservationCodes { get; }
        IList<IVaccineDose> AdministeredVaccineDoses { get; }
    }
}
