using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.UnitTests
{
    internal static class TestData
    {
        public readonly static string JsonPath = @"..\..\..\json";
        public readonly static string Case001 = "Case-2013-0001.json";
        public readonly static string Case002 = "Case-2013-0103.json";
        public readonly static string Case003 = "Case-2013-0203.json";

        public static readonly string DatPath = @"..\..\..\..\Resources";
        public static readonly string AntigenDat = @"AntigenSupportingData- HepB-508.xml";
        public static readonly string ScheduleDat = @"ScheduleSupportingData.xml";
    }
}
