using Ocdsi.SupportingData;
using Ocdsi.UnitTests;
using OpenCdsi.Cdsi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Ocdsi.UnitTests
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

            OpenCdsi.Cdsi.Antigen.Initialize(ResourcePath);
            OpenCdsi.Cdsi.Schedule.Initialize(ResourcePath);
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
