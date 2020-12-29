namespace Cdsi.ReferenceData
{
    public interface IAntigenIdentifier
    {
        string Name { get; }
    }
    public interface IAntigenSeriesIdentifier : IAntigenIdentifier
    {
        string SeriesName { get; }
    }

    public interface IAntigenSeriesDoseIdentifier : IAntigenSeriesIdentifier
    {
        string DoseName { get; }
    }
}