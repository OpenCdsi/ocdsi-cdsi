﻿using Cdsi.SupportingData;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi.ReferenceData
{
    public static class AntigenSupportingData
    {
        public static antigenSupportingData Antigen(this IDictionary<object, antigenSupportingData> antigens, IAntigenIdentifier id)
        {
            return antigens[id.Name];
        }

        public static antigenSupportingDataSeries Series(this IDictionary<object, antigenSupportingData> antigens, IAntigenSeriesIdentifier id)
        {
            return antigens[id.Name].series.First(x => x.seriesName == id.SeriesName);
        }

        public static antigenSupportingDataSeriesSeriesDose Dose(this IDictionary<object, antigenSupportingData> antigens, IAntigenSeriesDoseIdentifier id)
        {
            return antigens[id.Name].series.First(x => x.seriesName == id.SeriesName).seriesDose.First(x => x.doseNumber == id.DoseName);
        }
    }
}