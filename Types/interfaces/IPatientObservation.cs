﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface IPatientObservation
    {
        string Code { get; }
        DateTime DateOfObservation { get; }
    }
}
