using Cdsi.SupportingData;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Cdsi.UnitTests
{
    public static class Load
    {
        public static readonly string JsonPath = @".\data";
        public static readonly string AssessmentsFileName = @"assessments.json";
        public static readonly string ResourcePath = @"..\..\..\..\Resources";

        internal static readonly Repository _repository;
        private static readonly IEnumerable<Assessment> _assessments;

        static Load()
        {
            var path = Path.Combine(JsonPath, AssessmentsFileName);
            var json = File.ReadAllText(path);
            _assessments = JsonSerializer.Deserialize<List<Assessment>>(json);

            _repository = new Repository(ResourcePath);

            Cdsi.Antigen.Initialize(ResourcePath);
            Cdsi.Schedule.Initialize(ResourcePath);
        }

        public static T Json<T>(string fname) where T : class
        {
            var path = Path.Combine(JsonPath, fname);
            var json = File.ReadAllText(path);
            return (T)  JsonSerializer.Deserialize<T>(json);
        }

        public static scheduleSupportingData Schedule()
        {
            return _repository.Schedule();
        }
        public static antigenSupportingData Antigen(string key)
        {
            return _repository.Antigen(key);
        }

        public static Assessment Assessment(string key)
        {
            return _assessments.FirstOrDefault(x => x.CaseId == key);
        }
    }
}
