using Ocdsi.SupportingData;
using Ocdsi.UnitTests;
using OpenCdsi.Cdsi;
using System.IO;
using System.Text.Json;

namespace Ocdsi.UnitTests
{
    public static class Load
    {
        public static Assessment Assessment(string fname)
        {

            var path = Path.Combine(TestData.JsonPath, fname);
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Assessment>(json);
        }

        public static scheduleSupportingData Schedule()
        {
            var repo = new Repository(TestData.ResourcePath);
            return repo.Schedule();
        }
    }
}
