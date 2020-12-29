namespace Cdsi.Models

{
    public interface IAntigenSeriesDoseIdentifier : IAntigenSeriesIdentifier
    {
        int DoseIndex { get; set; }
    }
}