using System.Collections.Generic;
using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static class Library
    {
        public static IDictionary<string, ITestcase> Testcases = Factories.CreateTestcaseMap();
    }
}
