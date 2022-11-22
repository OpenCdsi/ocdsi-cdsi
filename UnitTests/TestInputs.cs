using OpenCdsi;
using OpenCdsi.Cases;

namespace Cdsi.UnitTests
{
    internal class TestInputs
    {
        public static testcase CaseDTAPa => CaseLibrary.Cases["2013-0002"];
        public static testcase CaseDTAPb => CaseLibrary.Cases["2013-0099"];
        public static testcase CaseMMRa => CaseLibrary.Cases["2013-0523"];
    }
}
