using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ExcelDataReader;

namespace Cdsi.ReferenceLibrary
{
    public static class Factories
    {
        private const string ResourceName = "Cdsi.ReferenceLibrary.xlsx.cdsi-healthy-childhood-and-adult-test-cases-v4.4.xlsx";
        private static readonly Regex re = new Regex("Cdsi.ReferenceLibrary.xml.AntigenSupportingData-\\s*([\\w\\s]*)-508.xml");

        public static IDictionary<string, antigenSupportingData> CreateAntigenMap()
        {
            var deserializer = new XmlSerializer(typeof(antigenSupportingData));
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            return assembly.GetManifestResourceNames()
                  .Select(x => Tuple.Create(x, re.Match(x)))
                  .Where(x => x.Item2.Success)
                  .Select(x => assembly.GetManifestResourceStream(x.Item1))
                  .Select(x => (antigenSupportingData)deserializer.Deserialize(x))
                  .Select(x => KeyValuePair.Create(x.series[0].targetDisease, x))
                  .AsMap();
        }

        public static IDictionary<string, string> CreateVaccineTypeMap()
        {
            return Reference.Antigen.Values
                      .SelectMany(x => x.series)
                      .SelectMany(x => x.seriesDose)
                      .SelectMany(x => x.preferableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))
                         .Concat(x.allowableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))))
                     .Where(x => !string.IsNullOrWhiteSpace(x.Key))
                     .Distinct(new KeyEqualityComparer())
                     .OrderBy(x => x.Key)
                     .AsMap();
        }

        public static scheduleSupportingData CreateSupportingData()
        {
            var name = "Cdsi.ReferenceLibrary.xml.ScheduleSupportingData.xml";
            var assembly = Assembly.GetAssembly(typeof(Metadata));
            var resource = assembly.GetManifestResourceStream(name);
            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            return (scheduleSupportingData)deserializer.Deserialize(resource);
        }
        public static IDictionary<string, ITestcase> CreateTestcaseMap()
        {
            return GetDataSet().Tables[0].Rows.AsEnumerable()
                 .Select(x => x.AsTestcase())
                 .Select(x => KeyValuePair.Create(x.CdcTestId, x))
                 .AsMap();
        }

        private static DataSet GetDataSet()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            using var stream = assembly.GetManifestResourceStream(ResourceName);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            return reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                UseColumnDataType = true,
                FilterSheet = (tableReader, sheetIndex) => sheetIndex == 2,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
        }
    }
}
