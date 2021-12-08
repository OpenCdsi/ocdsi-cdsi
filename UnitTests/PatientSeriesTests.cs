using System.Linq;
using Cdsi.Evaluation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.First().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            env.Patient.ObservationCodes.Add("048");
            ((Patient)env.Patient).DOB = env.Patient.DOB.AddDays(-180);
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            env.Patient.ObservationCodes.ToList().Add("048");
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.First().ToModel();
            Assert.AreEqual(PatientSeriesType.Standard,sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigen["Measles"];
            var sut = antigen.series.Second().ToModel();
            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }

        [TestMethod]
        public void StandardSeriesToPatientSeriesWithAntigenDoses()
        {
            var env = Library.Testcases["2013-0544"].CreateProcessingData();
            var antigen = SupportingData.Antigen["Measles"];
            var sut = (PatientSeries)antigen.series.First().ToModel(env.Patient.AdministeredVaccineDoses.OrganizeImmunizationHistory());
            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
            Assert.IsTrue(sut.AntigenDoses.Any());
        }
    }
}
