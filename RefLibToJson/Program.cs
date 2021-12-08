using System.IO;
using System.Text.Json;

namespace Cdsi.mkdb
{
    class Program
    {
        const string TESTCASES_FILENAME = "testcases.json";
        const string ANTIGENS_FILENAME = "antigens.json";
        const string SCHEDULE_FILENAME = "schedule.json";
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                // etc.
            };

            var data = JsonSerializer.Serialize(Library.Testcases, options);
            File.WriteAllText(TESTCASES_FILENAME, data);

            data = JsonSerializer.Serialize(SupportingData.Antigen, options);
            File.WriteAllText(ANTIGENS_FILENAME, data);

            data = JsonSerializer.Serialize(SupportingData.Schedule, options);
            File.WriteAllText(SCHEDULE_FILENAME, data);
        }
    }
}
