using Ocdsi.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Ocdsi.SupportingData;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    public static class Load
    {
        public static Assessment Case(string fname)
        {

            var path = Path.Combine(TestData.JsonPath, fname);
            var json = File.ReadAllText(path);
           return JsonSerializer.Deserialize<Assessment>(json);
        }

        public static scheduleSupportingData Schedule()
        {
            var repo = new Repository(TestData.DatPath);
            return repo.Schedule();
        }
    }
}
