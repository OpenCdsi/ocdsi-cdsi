using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using cdsi.refData;

namespace cdsi.evaluation
{
    public class TargetDose
    {
        public TargetDoseStatus Status { get; set; } = TargetDoseStatus.NotSatisfied;
    }
}
