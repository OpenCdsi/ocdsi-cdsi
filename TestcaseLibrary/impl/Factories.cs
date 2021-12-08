using System.Data;
using System.Reflection;
using System.Text;
using ExcelDataReader;

namespace Cdsi.TestcaseLibrary
{
    public static class Factories
    {
        private const string TestcaseResourceName = "TestcaseLibrary.xlsx.cdsi-healthy-childhood-and-adult-test-cases-v4.4.xlsx";

        public static IDictionary<string, testcase> CreateTestcaseMap()
        {
            return new Dictionary<string, testcase>(GetDataSet().Tables[0].Rows
                .AsEnumerable()
                 .Select(x => x.AsTestcase())
                 .Select(x => KeyValuePair.Create(x.CdcTestId, x)));
        }

        private static DataSet GetDataSet()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            using var stream = assembly.GetManifestResourceStream(TestcaseResourceName);
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
