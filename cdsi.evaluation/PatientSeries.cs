using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cdsi.refData;

namespace cdsi.evaluation
{
    public class PatientSeries : List<TargetDose>
    {
        public PatientSeriesStatus Status { get; set; } = PatientSeriesStatus.Unknown;
        public string AntigenName { get; set; }
        public int SeriesNumber { get; set; }

        public PatientSeries() { }

        public PatientSeries(antigenSupportingDataSeries series)
        {
            var doses = series.seriesDose.Select(d => new TargetDose(d));
            this.AddRange(doses);
        }

        public PatientSeries(string name,int seriesNumber=0)
        {
            AntigenName = name;
            SeriesNumber = seriesNumber;
            var series = RefData.Antigen[name].series[seriesNumber];
            var doses = series.seriesDose.Select(d => new TargetDose(d));
            this.AddRange(doses);

        }
    }
}
