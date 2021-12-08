namespace Cdsi
{
    public interface IInterval
    {
        int Duration { get; }
        IntervalUnit Unit { get; }
    }
}