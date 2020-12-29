﻿using System.Collections.Generic;
using Cdsi.SupportingData;

namespace Cdsi.Models
{
    public class PatientSeries : IPatientSeries
    {
        public string AntigenSeries { get; set; }

        public IEnumerable<ITargetDose> TargetDoses { get; } = new List<ITargetDose>();

        public PatientSeriesStatus Status { get; set; }
    }
}