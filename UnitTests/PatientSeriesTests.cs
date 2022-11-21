using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Calendar;
using OpenCdsi.Cdsi.SelectSeries;
using System.Collections.Generic;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var env =CaseLibrary.Cases["2013-0002"].GetEnv();
            var antigen = SupportingData.Antigens["Measles"];
            var sut = antigen.series.First().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var env = CaseLibrary.Cases["2013-0002"].GetEnv();
            env.Patient = new Patient
            {
                DOB = env.Patient.DOB - Interval.Parse("1 month"),
                Gender = env.Patient.Gender,
                AdministeredVaccineDoses = env.Patient.AdministeredVaccineDoses,
                ObservationCodes = new List<string> { "048" }
            };

            var antigen =SupportingData.Antigens["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var env = CaseLibrary.Cases["2013-0002"].GetEnv();
            env.AssessmentDate += Interval.Parse("1 year");
            env.Patient.ObservationCodes.Add("048");

            var antigen = SupportingData.Antigens["Measles"];
            var series = antigen.series.Second();
            var sut = series.IsRelevantSeries(env);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigens["Measles"];
            var sut = antigen.series.First().ToModel();

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = SupportingData.Antigens["Measles"];
            var sut = antigen.series.Second().ToModel();
            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
