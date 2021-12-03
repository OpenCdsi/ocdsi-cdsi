using System.Linq;
using Cdsi.Evaluation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.First().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeries()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsFalse(sut);
        }
    }
}
