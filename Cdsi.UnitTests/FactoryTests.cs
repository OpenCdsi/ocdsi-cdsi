using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class FactoryTests
    {
        const string TID = "2013-0099";

        [TestMethod]
        public void CanCreatePatientFromTestcase()
        {
            var sut = Library.Testcases[TID].Patient.ToModel();
            Assert.AreEqual(sut.Gender, Gender.Female);
            Assert.AreEqual(sut.DOB, new DateTime(2013, 8, 26));
        }

        [TestMethod]
        public void CanCreateDosesFromTestcase()
        {
            var test = Library.Testcases[TID];
            var doses = test.Evaluation.AdministeredDoses;
            var sut = doses.ToModel();
            Assert.AreEqual(3, doses.Count());
            Assert.AreEqual(15, sut.Count());
            Assert.AreEqual(sut.First().AntigenName, "Diphtheria");
        }

        [TestMethod]
        public void CanSortAdministeredDoses()
        {
            var test = Library.Testcases[TID];
            var doses = test.Evaluation.AdministeredDoses; 
            var administered = doses.ToModel();
            var sut = administered.OrderBy(x => x.AntigenName).ThenBy(x => x.DateAdministered).ToArray();
            Assert.AreEqual(sut[0].AntigenName, sut[1].AntigenName);
            Assert.IsTrue(sut[0].DateAdministered < sut[1].DateAdministered);
        }
    }
}
