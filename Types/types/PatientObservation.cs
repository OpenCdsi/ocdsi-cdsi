﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class PatientObservation : IPatientObservation
    {
        public string Code { get; init; } = string.Empty;
        public DateTime DateOfObservation { get; init; }
    }
}
