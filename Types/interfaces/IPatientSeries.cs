﻿using Cdsi.SupportingData;

namespace Cdsi
{
    public interface IPatientSeries
    {
        PatientSeriesStatus Status { get; set; }
        antigenSupportingDataSeries Series { get; }
        string Antigen { get; }
        string Name { get; }
        PatientSeriesType SeriesType { get; }
        IEnumerable<ITargetDose> TargetDoses { get; set;}
    }
}