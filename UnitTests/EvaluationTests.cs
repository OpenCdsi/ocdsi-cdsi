using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class EvaluationTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var sut = env.Patient.AdministeredVaccineDoses.OrganizeImmunizationHistory();
            Assert.AreEqual(6, sut.Count());
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void CanMakeAnEvaluator()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var sut =new Evaluation.Evaluator(env);
            Assert.IsTrue(sut.ProcessingData.RelevantPatientSeries.Any());
        }
    }
}
