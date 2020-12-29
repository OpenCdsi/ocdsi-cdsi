﻿using Cdsi.SupportingData;
using System.Collections.Generic;

namespace Cdsi.Models
{
    public interface IPatientSeries
    {
        AntigenSeriesIdentifier AntigenSeries { get; }
        IEnumerable<ITargetDose> TargetDoses { get; } 
        PatientSeriesStatus Status { get; set; }
    }
}