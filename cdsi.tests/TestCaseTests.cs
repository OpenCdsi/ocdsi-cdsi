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
            var testcases = new TestcaseCollection();
            Assert.IsInstanceOfType(testcases, typeof(TestcaseCollection));
        }

        [TestMethod]
        public void CanGetANamedTestcase()
        {
            var testcases = new TestcaseCollection();
            var testcase = testcases["2013-0011"];
            Assert.AreEqual(3, testcase.Evaluation.AdministeredDoses.Count());
        }
    }
}
