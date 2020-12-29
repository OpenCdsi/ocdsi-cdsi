using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.ReferenceData;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class TestCaseTests
    {
        [TestMethod]
        public void CanReadTheResource()
        {
            var sut = new TestcaseCollection();
            Assert.IsInstanceOfType(sut, typeof(TestcaseCollection));
        }

        [TestMethod]
        public void CanGetANamedTestcase()
        {
            const string id = "2013-0083";
            var tid = TestcaseIdentifier.Parse(id);
            var sut = new TestcaseCollection();
            var data = sut[tid];
            Assert.AreEqual(2, data.Evaluation.AdministeredDoses.Count());
        }

        [TestMethod]
        public void ThereAre801data()
        {
            var sut = new TestcaseCollection();
            Assert.AreEqual(801, sut.Count);
        }

        [TestMethod]
        public void ParseTestId()
        {
            const string id = "2013-0083";
            var tid = TestcaseIdentifier.Parse(id);
            Assert.AreEqual(2013, tid.Year);
            Assert.AreEqual(83, tid.Testcase);
        }

        [TestMethod]
        public void CanRoundTripTestId()
        {
            const string id = "2013-0083";
            var tid = TestcaseIdentifier.Parse(id);
            Assert.AreEqual(id, tid.ToString());
        }
    }
}
