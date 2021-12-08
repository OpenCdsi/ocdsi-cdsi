using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static class Library
    {
        public static IDictionary<string, testcase> Testcases = Factories.CreateTestcaseMap();
    }
}
