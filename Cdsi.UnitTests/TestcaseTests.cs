using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi.Testcases;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
 public   class TestCaseTests
    {
        [TestMethod]
        public void CanReadTheResource()
        {
            var testcases = new TestcaseLibrary();
            Assert.IsInstanceOfType(testcases, typeof(TestcaseLibrary));
        }

        [TestMethod]
        public void CanGetANamedTestcase()
        {
            var testcase = TestcaseLibrary.Instance["2013-0011"];
            Assert.AreEqual(3, testcase.Evaluation.AdministeredDoses.Count());
        }

        [TestMethod]
        public void ThereAre801Testcases()
        {
            Assert.AreEqual(801, TestcaseLibrary.Instance.Count);
        }
    }
}
