using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Cdsi.Evaluation;
using OpenCdsi.Cdsi.GatherData;
using OpenCdsi.Cdsi.SelectSeries;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class StageTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var sut = CaseLibrary.Cases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .ImmunizationHistory;

            Assert.AreEqual(6, sut.Count);
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var sut = CaseLibrary.Cases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .SelectRelevantPatientSeries()
                .RelevantPatientSeries;

            Assert.IsTrue(sut.Any());
        }

        [TestMethod]
        public void CanEvaluatePatientSeries()
        {
            var sut = CaseLibrary.Cases["2013-0002"]
                .GetEnv()
                .OrganizeImmunizationHistory()
                .SelectRelevantPatientSeries()
                .EvaluatePatientSeries()
                .RelevantPatientSeries;
        }
    }
}
