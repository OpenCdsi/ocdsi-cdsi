using Cdsi.SupportingData;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi.Models
{
    public static  class AntigenSupportingData
    {
        public static antigenSupportingData Get(this IDictionary<object, antigenSupportingData> antigens, IAntigenIdentifier id)
        {
            return antigens[id.Name];
        }

        public static antigenSupportingDataSeries Get(this IDictionary<object, antigenSupportingData> antigens, IAntigenSeriesIdentifier id)
        {
            return antigens[id.Name].series[id.SeriesIndex];
        }

        public static antigenSupportingDataSeriesSeriesDose Get(this IDictionary<object, antigenSupportingData> antigens, IAntigenSeriesDoseIdentifier id)
        {
            return antigens[id.Name].series[id.SeriesIndex].seriesDose.First(el => el.doseNumber == $"Dose_{id.DoseIndex}");
        }
    }
}
