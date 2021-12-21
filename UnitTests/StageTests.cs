using Cdsi.SupportingDataLibrary;
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
            var env = Library.Testcases["2013-0002"].GetEnv();
            env.OrganizeImmunizationHistory();
            var sut = env.ImmunizationHistory;

            Assert.AreEqual(6, sut.Count);
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var env = Library.Testcases["2013-0002"].GetEnv();
            env.OrganizeImmunizationHistory();
            env.SelectRelevantPatientSeries();
            var sut = env.RelevantPatientSeries;

            Assert.IsTrue(sut.Any());
        }
    }
}
