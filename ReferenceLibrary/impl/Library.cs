using System.Collections.Generic;
using Cdsi.ReferenceLibrary;

namespace Cdsi
{
    public static class Library
    {
        public static IDictionary<string, cdsiTestcase> Testcases = Factories.CreateTestcaseMap();
    }
}
