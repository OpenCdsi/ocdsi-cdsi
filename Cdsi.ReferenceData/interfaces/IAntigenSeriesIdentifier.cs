namespace Cdsi.ReferenceData
{
    public interface IAntigenSeriesIdentifier : IAntigenIdentifier
    {
        int SeriesIndex { get; }
    }
}