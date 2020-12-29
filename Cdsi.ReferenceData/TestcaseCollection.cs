﻿using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Cdsi.TestcaseData;
using ExcelDataReader;

namespace Cdsi.ReferenceData
{
    public class TestcaseCollection : IEnumerable<Testcase>
    {
        private static string ResourceName => "Cdsi.TestcaseData.xlsx.cdsi-healthy-childhood-and-adult-test-cases-v4.4.xlsx";

        private DataSet Data { get; }

        private IEnumerable<DataRow> Records
        {
            get
            {
                var rows = new List<DataRow>();
                foreach (var row in Data.Tables[0].Rows)
                {
                    rows.Add((DataRow)row);
                }
                return rows;
            }
        }

        public TestcaseCollection()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var assembly = Assembly.GetAssembly(typeof(Cdsi.TestcaseData.Testcase));
            using (var stream = assembly.GetManifestResourceStream(ResourceName))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    Data = reader.AsDataSet(new ExcelDataSetConfiguration()
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

        public Testcase this[ITestcaseIdentifier id] => Data.AsTestcase(id.ToString());
        public IEnumerable<ITestcaseIdentifier> Keys => Records.Select(r => r.Field<string>("CDC_Test_ID")).Select(id => TestcaseIdentifier.Parse(id));
        public IEnumerable<Testcase> Values => Records.Select(r => r.AsTestcase());
        public int Count => Data.Tables[0].Rows.Count;

        public IEnumerator<Testcase> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}