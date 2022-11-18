using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenCdsi.Date;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var env = OpenCdsi.Library.Testcases["2013-0002"].GetEnv();
            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var sut = antigen.series.First().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var env = OpenCdsi.Library.Testcases["2013-0002"].GetEnv();
            env.Patient = new Patient
            {
                DOB = env.Patient.DOB - Duration.Parse("1 month"),
                Gender = env.Patient.Gender,
                AdministeredVaccineDoses = env.Patient.AdministeredVaccineDoses,
                ObservationCodes = new List<string> { "048" }
            };

            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var env = OpenCdsi.Library.Testcases["2013-0002"].GetEnv();
            env.AssessmentDate += Duration.Parse("1 year");
            env.Patient.ObservationCodes.Add("048");

            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var series = antigen.series.Second();
            var sut = series.IsRelevantSeries(env);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var sut = antigen.series.First().ToModel();

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var sut = antigen.series.Second().ToModel();
            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
