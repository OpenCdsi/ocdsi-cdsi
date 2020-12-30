using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ExcelDataReader;

namespace Cdsi.TestcaseLibrary
{
    public static class Factories
    {
        private static string ResourceName => "Cdsi.TestcaseLibrary.xlsx.cdsi-healthy-childhood-and-adult-test-cases-v4.4.xlsx";

        public static IDictionary<string, Testcase> CreateTestcaseMap()
        {
            return GetDataSet().Tables[0].Rows.AsEnumerable()
                 .Select(x => x.AsTestcase())
                 .Select(x => KeyValuePair.Create(x.CdcTestId, x))
                 .AsMap();
        }

        private static DataSet GetDataSet()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var assembly = Assembly.GetAssembly(typeof(TestcaseData.Metadata));
            using (var stream = assembly.GetManifestResourceStream(ResourceName))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
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

        private static IEnumerable<DataRow> AsEnumerable(this DataRowCollection rows)
        {
            foreach (DataRow row in rows)
            {
                yield return row;
            }
        }
    }
}
