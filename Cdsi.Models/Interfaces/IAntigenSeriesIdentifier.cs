namespace Cdsi.Models
{
    public interface IAntigenSeriesIdentifier : IAntigenIdentifier
    {
        int SeriesIndex { get; set; }
    }
}