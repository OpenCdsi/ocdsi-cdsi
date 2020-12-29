using cdsi.refData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cdsi.supportingData
{
  public static  class AntigenSupportingData
    {
        public static antigenSupportingData Get(this IDictionary<object, antigenSupportingData> antigens, AntigenIdentifier id)
        {
            return antigens[id.Name];
        }

        public static antigenSupportingDataSeries Get(this IDictionary<object, antigenSupportingData> antigens, AntigenSeriesIdentifier id)
        {
            return antigens[id.Name].series[id.SeriesIndex];
        }

        public static antigenSupportingDataSeriesSeriesDose Get(this IDictionary<object, antigenSupportingData> antigens, AntigenSeriesDoseIdentifier id)
        {
            return antigens[id.Name].series[id.SeriesIndex].seriesDose.First(el => el.doseNumber == $"Dose_{id.DoseIndex}");
        }
    }
}
