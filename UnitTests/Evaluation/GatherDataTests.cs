using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Cdsi;
using System.Linq;

namespace Ocdsi.UnitTests.Evaluation
{
    [TestClass]
    public class GatherDataTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Antigen.Initialize(TestData.ResourcePath);
            Schedule.Initialize(TestData.ResourcePath);
        }

        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var assessment = Load.Assessment(TestData.Case_2);

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var sut = gatherer.OrganizeImmunizationHistory();

            Assert.AreEqual(6, sut.Count());
            Assert.IsInstanceOfType(sut.First(), typeof(AntigenDose));
        }

        [TestMethod]
        public void AntigenDosesAreSorted()
        {
            var assessment = Load.Assessment(TestData.Case_99);

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var sut = gatherer.OrganizeImmunizationHistory().ToList();

            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].VaccineDose.DateAdministered < sut[1].VaccineDose.DateAdministered);
        }
    }
}
