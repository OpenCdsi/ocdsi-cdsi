using System;
using System.Collections.Generic;
using System.Linq;
using Cdsi.ReferenceLibrary;

namespace Cdsi.PrepareData
{
    /// <summary>
    /// Cdsi Logic Spec 4.1 - Chapter 5
    /// </summary>
    public static class PatientSeriesHelpers
    {
        public static IPatientSeries ToModel(this antigenSupportingDataSeries series)
        {
            return new PatientSeries()
            {
                AntigenName = series.targetDisease,
                SeriesName = series.seriesName,
                Status = PatientSeriesStatus.NotComplete,
                TargetDoses = series.seriesDose.Select(x => x.ToModel()),
                SeriesType = Enum.Parse<PatientSeriesType>(series.seriesType)
            };
        }

        public static ITargetDose ToModel(this antigenSupportingDataSeriesSeriesDose dose)
        {
            return new TargetDose()
            {
                DoseName = dose.doseNumber,
                Status = TargetDoseStatus.NotSatisfied
            };
        }

        public static bool IsRelevantSeries(antigenSupportingDataSeries series)
        {
            // TODO: evaluate for 'risk' series
            return series.seriesType == "Standard";
        }

        public static IEnumerable<IPatientSeries> ToRelevantPatientSeries(this antigenSupportingData antigen)
        {
            return antigen.series
                .Where(x => IsRelevantSeries(x))
                .Select(x => x.ToModel());
        }

        public static IEnumerable<IPatientSeries> GetAllRelevantPatientSeries() // TODO: pass in data to evaluate for 'risk' series
        {
            return Reference.Antigen.Values
                .SelectMany(x => x.ToRelevantPatientSeries())
                .Where(x => x.TargetDoses.Count() > 0);
        }
    }
}
