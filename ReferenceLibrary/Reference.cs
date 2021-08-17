using System.Collections.Generic;
using Cdsi.ReferenceLibrary;

namespace Cdsi
{
    public static class Reference
    {
        public static scheduleSupportingData Schedule { get; } = Factories.CreateSupportingData();

        public static IDictionary<string, antigenSupportingData> Antigen { get; } = Factories.CreateAntigenMap();

        public static IDictionary<string, cdsiTestcase> Testcases { get; } = Factories.CreateTestcaseMap();
    }
}
