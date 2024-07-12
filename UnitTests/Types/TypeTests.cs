using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi;
using System;
using System.Linq;
using Cdsi.UnitTests;
using Cdsi.SupportingData;

namespace Cdsi.UnitTests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void CanCreateOcdsiObjecFromTestcase()
        {
            var assessment = Load.Assessment("2013-0002");

            Assert.AreEqual(new DateTime(2020, 6,9), assessment.Patient.DOB);
            Assert.AreEqual(Gender.Female, assessment.Patient.Gender);
            Assert.AreEqual(2, assessment.Patient.VaccineHistory.Count());
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = Load.Antigen("Measles");
            var sut = PatientSeries.Create(antigen.series[0]);

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = Load.Antigen("Measles");
            var sut = PatientSeries.Create(antigen.series[1]);

            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
