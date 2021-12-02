using Cdsi.TestcaseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class TestCaseTests
    {
        const string TID = "2013-0083";
        const int NUM_TESTS = 801;

        [TestMethod]
        public void CanGetANamedTestcase()
        {
            var sut = Library.Testcases[TID];
            Assert.IsInstanceOfType(sut, typeof(testcase));
        }

        [TestMethod]
        public void ThereAreNumTestcases()
        {
            Assert.AreEqual(NUM_TESTS, Library.Testcases.Count);
        }
    }
}
