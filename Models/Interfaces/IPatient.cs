using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatient
    {
        DateTime DOB { get; }
        Gender Gender { get; }
        IList<string> ObservationCodes { get; }
        IList<IVaccineDose> AdministeredVaccineDoses { get; }
    }
}
