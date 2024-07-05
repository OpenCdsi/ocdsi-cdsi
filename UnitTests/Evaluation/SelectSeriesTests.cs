using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocdsi.Calendar;
using OpenCdsi.Cdsi;
using System.Linq;

namespace Ocdsi.UnitTests.Evaluation
{
    [TestClass]
    public class SelectSeriesTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Antigen.Initialize(TestData.ResourcePath);
            Schedule.Initialize(TestData.ResourcePath);
        }

        [TestMethod]
        public void SelectsStandardSeries()
        {
            var assessment = Load.Assessment(TestData.Case_203);
            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[0]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void SelectsRiskSeriesBecauseOfObservation()
        {
            var assessment = Load.Assessment(TestData.Case_203);
            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsTrue(sut);
        }

        [TestMethod]
        public void DontSelectsRiskSeriesBecauseOfAge()
        {
            var assessment = Load.Assessment(TestData.Case_203);
            var antigen = Antigen.Get("Measles");

            var selector = new SeriesSelector { Patient = assessment.Patient, AssessmentDate = assessment.AssessmentDate + Interval.Parse("1 year") };
            var sut = selector.IsRelevantSeries(antigen.series[1]);

            Assert.IsFalse(sut);
        }

        [TestMethod]
        public void CanSelectRelevantPatientSeries()
        {
            var assessment = Load.Assessment(TestData.Case_203);

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
