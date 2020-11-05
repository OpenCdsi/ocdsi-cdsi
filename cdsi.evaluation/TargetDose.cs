using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using cdsi.refData;

namespace cdsi.evaluation
{
    public class TargetDose
    {
        public TargetDoseStatus Status { get; set; } = TargetDoseStatus.Unknown;
        public int DoseNumber { get; private set; }

        public TargetDose() { }

        public TargetDose(antigenSupportingDataSeriesSeriesDose dose)
        {
            DoseNumber = int.Parse(Regex.Match(dose.doseNumber, "(\\d+)").Groups[1].Value);
        }
    }
}
