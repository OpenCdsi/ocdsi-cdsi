using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var env = Library.Testcases["2013-0002"].GetEnv();
            var antigen = Data.Antigen["Measles"];
            var sut = antigen.series.First().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var env = Library.Testcases["2013-0002"].GetEnv();
            var patient = env.Patient;
            patient.ObservationCodes.Add("048");
            patient.DOB -= Duration.Create(1, Interval.Month);

            var antigen = Data.Antigen["Measles"];
            var sut = antigen.series.Second().IsRelevantSeries(env);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var env = Library.Testcases["2013-0002"].GetEnv();
            env.AssessmentDate += Duration.Create(1, Interval.Year);
            env.Patient.ObservationCodes.Add("048");

            var antigen = Data.Antigen["Measles"];
            var series = antigen.series.Second();
            var sut = series.IsRelevantSeries(env);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void StandardSeriesToPatientSeries()
        {
            var antigen = Data.Antigen["Measles"];
            var sut = antigen.series.First().ToModel();

            Assert.AreEqual(PatientSeriesType.Standard, sut.SeriesType);
        }

        [TestMethod]
        public void RiskSeriesToPatientSeries()
        {
            var antigen = Data.Antigen["Measles"];
            var sut = antigen.series.Second().ToModel();
            Assert.AreEqual(PatientSeriesType.Risk, sut.SeriesType);
        }
    }
}
