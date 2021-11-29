using System.Collections.Generic;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    public static class SupportingData
    {
        public static scheduleSupportingData Schedule { get; } = Factories.CreateSupportingData();

        public static IDictionary<string, antigenSupportingData> Antigen { get; } = Factories.CreateAntigenMap();
    }
}
