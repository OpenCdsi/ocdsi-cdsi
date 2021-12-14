﻿using System.Collections.Generic;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    public interface IPatientSeries
    {
        PatientSeriesStatus Status { get; set; }
        antigenSupportingDataSeries Series { get; }
        string Antigen { get; }
        string Name { get; }
        PatientSeriesType Type { get; }
        IList<ITargetDose> TargetDoses { get; }
    }
}