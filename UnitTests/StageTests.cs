using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class StageTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            env.OrganizeImmunizationHistory();
            Assert.AreEqual(6, env.ImmunizationHistory.Count);
            Assert.IsInstanceOfType(env.ImmunizationHistory.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            env.OrganizeImmunizationHistory();
            env.SelectRelevantPatientSeries();
            Assert.IsTrue(env.RelevantPatientSeries.Any());
        }
    }
}
