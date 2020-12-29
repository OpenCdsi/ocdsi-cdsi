namespace Cdsi.ReferenceData
{
    public interface ITestcaseIdentifier
    {
        short Testcase { get; }
        short Year { get; }

        string ToString();
    }
}