using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdsi.SupportingDataLibrary;
using Enum = Utility.Enum;

namespace Cdsi
{
    public static partial class AntigenSupportingDataSeries
    {
        public static IPatientSeries ToModel(this antigenSupportingDataSeries series)
        {
            return new PatientSeries()
            {
                AntigenName = series.targetDisease,
                SeriesName = series.seriesName,
                Status = PatientSeriesStatus.NotComplete,
                TargetDoses = series.seriesDose.Select(x => x.ToModel()),
                SeriesType = Enum.TryParse<PatientSeriesType>(series.seriesType)
            };
        }

        public static TargetDose ToModel(this antigenSupportingDataSeriesSeriesDose dose)
        {
            return new TargetDose()
            {
                DoseName = dose.doseNumber,
                Status = TargetDoseStatus.NotSatisfied
            };
        }
    }
}
