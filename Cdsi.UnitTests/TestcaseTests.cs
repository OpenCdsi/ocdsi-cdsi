using Cdsi.TestcaseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class TestCaseTests
    {
        const string TID = "2013-0083";

        [TestMethod]
        public void CanGetANamedTestcase()
        {
            var sut = Library.Testcases[TID];
            Assert.IsInstanceOfType(sut, typeof(Testcase));
        }

        [TestMethod]
        public void ThereAre801Testcases()
        {
            Assert.AreEqual(801, Library.Testcases.Count);
        }
    }
}
