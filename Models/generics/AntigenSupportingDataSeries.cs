using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;
using Enum = Utility.Enum;

namespace Cdsi
{
    public static partial class AntigenSupportingDataSeries
    {
        public static PatientSeries ToModel(this antigenSupportingDataSeries asds)
        {
            var series = new PatientSeries()
            {
                AntigenName = asds.targetDisease,
                SeriesName = asds.seriesName,
                Status = PatientSeriesStatus.NotComplete,
                SeriesType = Enum.TryParse<PatientSeriesType>(asds.seriesType)
            };

            series.TargetDoses.AddAll(asds.seriesDose.Select(x => new TargetDose()
            {
                DoseName = x.doseNumber,
                Status = TargetDoseStatus.NotSatisfied
            }));

            return series;

        }
        public static PatientSeries ToModel(this antigenSupportingDataSeries asds, IEnumerable<IAntigenDose> ad)
        {
            var series = asds.ToModel();

            series.AntigenDoses.AddAll(ad.Where(x => x.AntigenName == asds.targetDisease));
            return series;
        }
    }
}
