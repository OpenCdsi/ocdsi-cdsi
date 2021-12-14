using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class SimpleEhrTests
    {
        readonly string[] TID = new string[] { "2013-0002", "2013-0099" };

        [TestMethod]
        public void CanCreateSimpleEhrObjecFromTestcase()
        {
            var testcase = Library.Testcases[TID[0]];
            var sut = testcase.Patient.ToEhr(testcase.Doses);

            Assert.AreEqual(new DateTime(2020, 6, 9), sut.DOB);
            Assert.AreEqual(Gender.Female, sut.Gender);
            Assert.AreEqual(2, sut.AdministeredVaccineDoses.Count);
        }

        [TestMethod]
        public void CanCreateAntigenDosesFromTestcase()
        {
            var testcase = Library.Testcases[TID[1]];
            var doses = testcase.Evaluation.AdministeredDoses;

            var sut = doses.ToModel();
            Assert.AreEqual(3, doses.Count());
            Assert.AreEqual(15, sut.Count());
            Assert.AreEqual(sut.First().AntigenName, "Diphtheria");
        }

        [TestMethod]
        public void CanSortAntigenDoses()
        {
            var test = Library.Testcases[TID[1]];
            var doses = test.Evaluation.AdministeredDoses;
            var administered = doses.ToModel();
            var sut = administered.OrderBy(x => x.AntigenName).ThenBy(x => x.DateAdministered).ToArray();
            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].DateAdministered < sut[1].DateAdministered);
        }
    }
}
