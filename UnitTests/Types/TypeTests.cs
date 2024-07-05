using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Cdsi;
using System;
using System.Linq;
using Ocdsi.UnitTests;
using Ocdsi.SupportingData;

namespace Ocdsi.UnitTests.Types
{
    [TestClass]
    public class TypeTests
    {
        internal Repository Repository = new Repository(TestData.ResourcePath);

        [TestMethod]
        public void CanCreateOcdsiObjecFromTestcase()
        {
            var assessment = Load.Assessment(TestData.Case_2);

            Assert.AreEqual(new DateTime(2022, 8, 15), assessment.Patient.DOB);
            Assert.AreEqual(Gender.Female, assessment.Patient.Gender);
            Assert.AreEqual(2, assessment.AdministeredDoses.Count());
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = Repository.Antigen("Measles");
            var sut = PatientSeries.Create(antigen.series[0]);

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = Repository.Antigen("Measles");
            var sut = PatientSeries.Create(antigen.series[1]);

            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
