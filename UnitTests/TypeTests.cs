using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class TypeTests
    {
        readonly string[] TID = new string[] { "2013-0002", "2013-0099" };

        [TestMethod]
        public void CanCreateSimpleEhrObjecFromTestcase()
        {
            var testcase = CaseLibrary.Cases[TID[0]];
            var sut = testcase.Patient.ToEhr(testcase.Doses);

            Assert.AreEqual(new DateTime(2022, 8,15), sut.DOB);
            Assert.AreEqual(Gender.Female, sut.Gender);
            Assert.AreEqual(2, sut.VaccineHistory.Count);
        }

        [TestMethod]
        public void CanCreateAntigenDosesFromTestcase()
        {
            var testcase = CaseLibrary.Cases[TID[1]];
            var patient = testcase.Patient.ToEhr(testcase.Doses);
            var sut = patient.VaccineHistory.SelectMany(x => x.AsAntigenDoses());

            Assert.AreEqual(3, testcase.Evaluation.AdministeredDoses.Count());
            Assert.AreEqual(15, sut.Count());
            Assert.AreEqual(sut.First().AntigenName, "Diphtheria");
        }

        [TestMethod]
        public void CanSortAntigenDoses()
        {

            var testcase = CaseLibrary.Cases[TID[1]];
            var patient = testcase.Patient.ToEhr(testcase.Doses);
            var sut = patient.VaccineHistory.SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.VaccineDose.DateAdministered).ToArray();

            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].VaccineDose.DateAdministered < sut[1].VaccineDose.DateAdministered);
        }
    }
}
