using System.Collections.Generic;
using OpenCdsi.SupportingData;

namespace Cdsi
{
    public interface IPatientSeries
    {
        PatientSeriesStatus Status { get; set; }
        antigenSupportingDataSeries Series { get; }
        string Antigen { get; }
        string Name { get; }
        PatientSeriesType SeriesType { get; }
        IList<ITargetDose> TargetDoses { get; }
    }
}