using Cdsi.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class GatherDataTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var testcase = TestInputs.CaseDTAPa;
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            var gatherer = new DataGatherer { Patient = patient };
            var sut = gatherer.OrganizeImmunizationHistory();

            Assert.AreEqual(6, sut.Count());
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void AntigenDosesAreSorted()
        {
            var testcase = TestInputs.CaseDTAPb;
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            var gatherer = new DataGatherer { Patient = patient };
            var sut = gatherer.OrganizeImmunizationHistory().ToList();

            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].VaccineDose.DateAdministered < sut[1].VaccineDose.DateAdministered);
        }
    }
}
