using System;
using System.Linq;
using Cdsi.ReferenceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void CanCreatePatientFromTestcase()
        {
            var tid = TestcaseIdentifier.Parse("2013-0099");
            var sut = Reference.Testcases[tid].Patient.ToModel();
            Assert.AreEqual(sut.Gender, Models.Gender.Female);
            Assert.AreEqual(sut.DOB, new DateTime(2013, 8, 26));
        }

        [TestMethod]
        public void CanCreateDosesFromTestcase()
        {
            var tid = TestcaseIdentifier.Parse("2013-0099");
            var test = Reference.Testcases[tid];
            var doses = test.Evaluation.AdministeredDoses;
            var sut = doses.ToModel();
            Assert.AreEqual(3, doses.Count());
            Assert.AreEqual(15, sut.Count());
            Assert.AreEqual(sut.First().Antigen.Name, "Diphtheria");
        }

        [TestMethod]
        public void CanSortAdministeredDoses()
        {
            var tid = TestcaseIdentifier.Parse("2013-0099");
            var test = Reference.Testcases[tid];
            var doses = test.Evaluation.AdministeredDoses;
            var administered = doses.ToModel();
            var sut = administered.OrderBy(x => x.Antigen).ThenBy(x => x.DateAdministered).ToArray();
            Assert.AreEqual(sut[0].Antigen, sut[1].Antigen);
            Assert.IsTrue(sut[0].DateAdministered < sut[1].DateAdministered);
        }
    }
}
