using Cdsi.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Calendar;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class SelectSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var testcase = TestInputs.CaseDTAPa;
            var antigen = SupportingData.Antigens["Measles"];
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            var selector = new SeriesSelector { Patient = patient, AssessmentDate = testcase.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[0]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var testcase = TestInputs.CaseDTAPa;
            var antigen = SupportingData.Antigens["Measles"];
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            patient = new Patient
            {
                DOB = patient.DOB - Interval.Parse("1 month"),
                Gender = patient.Gender,
                VaccineHistory = patient.VaccineHistory,
                Observations = new[] { new PatientObservation { Code = "048" } }
            };

            var selector = new SeriesSelector { Patient = patient, AssessmentDate = testcase.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {

            var testcase = TestInputs.CaseDTAPa;
            var antigen = SupportingData.Antigens["Measles"];
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            patient = new Patient
            {
                DOB = patient.DOB - Interval.Parse("1 month"),
                Gender = patient.Gender,
                VaccineHistory = patient.VaccineHistory,
                Observations = new[] { new PatientObservation { Code = "048" } }
            };

            var selector = new SeriesSelector { Patient = patient, AssessmentDate = testcase.AssessmentDate + Interval.Parse("1 year") };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var testcase = TestInputs.CaseDTAPa;
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);

            var gatherer = new DataGatherer { Patient = patient };
            var antigens = gatherer.OrganizeImmunizationHistory()
                .Select(x => x.AntigenName)
                .Select(x => SupportingData.Antigens[x]);

            var selector = new SeriesSelector { Patient = patient, AssessmentDate = testcase.AssessmentDate };
            var sut = selector.SelectRelevantPatientSeries(antigens);

            Assert.IsTrue(sut.Any());
        }
    }
}
