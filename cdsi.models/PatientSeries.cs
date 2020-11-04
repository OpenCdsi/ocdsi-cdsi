using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.models
{
public    class PatientSeries: List<TargetDose>
    {
        public PatientSeriesStatus Status { get; set; } = PatientSeriesStatus.Unknown;
    }
}
