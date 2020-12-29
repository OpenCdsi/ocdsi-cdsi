using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdsi.ReferenceData
{
    public class TestcaseIdentifier : ITestcaseIdentifier
    {
        public short Year { get; private set; }
        public short Testcase { get; private set; }

        public override string ToString()
        {
            return $"{Year.ToString().PadLeft(4, '0')}-{Testcase.ToString().PadLeft(4, '0')}";
        }

        public static TestcaseIdentifier Parse(string id)
        {
            var components = id.Split('-').Select(el => short.Parse(el)).ToArray();
            return new TestcaseIdentifier() { Year = components[0], Testcase = components[1] };
        }
    }
}
