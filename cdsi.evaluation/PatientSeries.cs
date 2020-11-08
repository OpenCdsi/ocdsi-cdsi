using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cdsi.refData;

namespace cdsi.evaluation
{
    public class PatientSeries : List<TargetDose>, IPatientSeries
    {
        public PatientSeriesStatus Status { get; set; } = PatientSeriesStatus.NotComplete;
        public string AntigenName { get; }
        public int SeriesNumber { get; }

        private PatientSeries() { }

        public PatientSeries(string name, int seriesNumber = 0)
        {
            AntigenName = name;
            SeriesNumber = seriesNumber;
            var series = SupportingData.Antigen[name].series[seriesNumber];
            var doses = series.seriesDose.Select(d => new TargetDose(d));
            this.AddRange(doses);

        }
    }
}
