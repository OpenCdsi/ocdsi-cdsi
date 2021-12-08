using System;
using System.Collections.Generic;

namespace Cdsi
{
    public interface IPatient
    {
        System.DateTime DOB { get; }
        Gender Gender { get; }
        public IList<string> ObservationCodes { get; }
    }
}
