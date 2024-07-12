using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi.Calendar;
using Cdsi;
using System.Linq;

namespace Cdsi.UnitTests.Evaluation
{
    [TestClass]
    public class SelectSeriesTests
    {
        [TestMethod]
        public void SelectsStandardSeries()
        {
            var assessment = Load.Assessment("2013-0203");
            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[0]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var assessment = Load.Assessment("2013-0203");
            assessment.Patient.Observations.Add(new PatientObservation { Code="048"});

            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var assessment = Load.Assessment("2013-0203");
            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate + Interval.Parse("1 year") };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var assessment = Load.Assessment("2013-0203");

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var antigens = gatherer.OrganizeImmunizationHistory()
                .Select(x => x.AntigenName)
                .Select(x => Antigen.Get(x));

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate };
            var sut = selector.SelectRelevantPatientSeries(antigens);

            Assert.IsTrue(sut.Any());
        }
    }
}
