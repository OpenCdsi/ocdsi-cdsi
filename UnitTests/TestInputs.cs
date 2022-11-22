using OpenCdsi;
using OpenCdsi.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.UnitTests
{
    internal class TestInputs
    {
        public static testcase Case0002 => CaseLibrary.Cases["2013-0002"];
        public static testcase Case0099 => CaseLibrary.Cases["2013-0099"];
    }
}
