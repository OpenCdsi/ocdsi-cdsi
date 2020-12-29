using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using cdsi.refData;
using cdsi.supportingData;

namespace cdsi.evaluation
{
    public class TargetDose : ITargetDose
    {
        public AntigenSeriesDoseIdentifier AntigenSeriesDose { get; }

        public TargetDoseStatus Status { get; set; }
    }
}
