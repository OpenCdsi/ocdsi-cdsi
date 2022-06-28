using Cdsi.SupportingData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class StageTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var sut = Library.Testcases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .ImmunizationHistory;

            Assert.AreEqual(6, sut.Count);
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var sut = Library.Testcases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .SelectRelevantPatientSeries()
                .RelevantPatientSeries;

            Assert.IsTrue(sut.Any());
        }

        [TestMethod]
        public void CanEvaluatePatientSeries()
        {
            var sut = Library.Testcases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .SelectRelevantPatientSeries()
                .EvaluatePatientSeries()
                .RelevantPatientSeries;
        }
    }
}
