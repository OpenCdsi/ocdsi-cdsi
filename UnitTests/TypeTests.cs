using Cdsi.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void CanCreateOcdsiObjecFromTestcase()
        {
            var testcase = TestInputs.Case0002;
            var sut = testcase.Patient.ToCdsiType(testcase.Doses);

            Assert.AreEqual(new DateTime(2022, 8, 15), sut.DOB);
            Assert.AreEqual(Gender.Female, sut.Gender);
            Assert.AreEqual(2, sut.VaccineHistory.Count());
        }

        [TestMethod]
        public void CanCreateVaccineDosesFromTestcase()
        {
            var testcase = TestInputs.Case0099; 
            var sut = testcase.Doses.Select(x => x.ToCdsiType());

            Assert.AreEqual(3, sut.Count());
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigens["Measles"];
            var sut = PatientSeries.Create(antigen.series[0]);

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigens["Measles"];
            var sut = PatientSeries.Create(antigen.series[1]);

            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
