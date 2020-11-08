using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using cdsi.refData;

namespace cdsi.evaluation
{
    public class TargetDose : ITargetDose
    {
        public antigenSupportingDataSeriesSeriesDose RefData { get; }
        public TargetDoseStatus Status { get; set; } = TargetDoseStatus.NotSatisfied;

        private TargetDose() { }
        public TargetDose(antigenSupportingDataSeriesSeriesDose refdata)
        {
            RefData = refdata;
        }
    }
}
