namespace Cdsi.ReferenceData

{
    public interface IAntigenSeriesDoseIdentifier : IAntigenSeriesIdentifier
    {
        int DoseIndex { get; }
    }
}