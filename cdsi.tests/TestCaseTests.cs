using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using cdsi.testcases;
using System.Net.Http.Headers;
using System.Linq;

namespace cdsi.tests
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
