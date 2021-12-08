using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class ProcessingDataTests
    {
        const string TID = "2013-0002";

        [TestMethod]
        public void CanCreateProcessingDataObject()
        {
            var testcase = Library.Testcases[TID];
            var sut = testcase.CreateProcessingData();

            Assert.AreEqual(new DateTime(2020, 6, 9), sut.Patient.DOB);
            Assert.AreEqual(new DateTime(2020, 8, 13), sut.AssessmentDate);
            Assert.AreEqual(2, sut.Patient.AdministeredVaccineDoses.Count);
        }
    }
}
