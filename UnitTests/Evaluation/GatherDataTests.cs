using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi;
using System.Linq;

namespace Cdsi.UnitTests.Evaluation
{
    [TestClass]
    public class GatherDataTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var assessment = Load.Assessment("2013-0002");

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var sut = gatherer.OrganizeImmunizationHistory();

            Assert.AreEqual(6, sut.Count());
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void AntigenDosesAreSorted()
        {
            var assessment = Load.Assessment("2013-0099");

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var sut = gatherer.OrganizeImmunizationHistory().ToList();

            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].VaccineDose.DateAdministered < sut[1].VaccineDose.DateAdministered);
        }
    }
}
