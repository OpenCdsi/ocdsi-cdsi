using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Ocdsi.UnitTests;
using OpenCdsi.Cdsi;

namespace Ocdsi.UnitTests.Evaluation
{
    [TestClass]
    public class EvaluationTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context) {
            Antigen.Initialize(TestData.ResourcePath);
            Schedule.Initialize(TestData.ResourcePath);
        }

        [TestMethod]
        public void CanEvaluateStandardPatientSeries()
        {
            // doses to evaluate
            var assessment = Load.Assessment(TestData.Case_2);

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var doses = gatherer.OrganizeImmunizationHistory().Where(x => x.AntigenName == "Measles").ToList();

            // series to evaluate
            var antigen = Antigen.Get("HepB");
            var series = PatientSeries.Create(antigen.series[0]); // standard Measles 2-dose series

            // evaluation environment
            var options = new EvaluationOptions { AssessmentDate = assessment.AssessmentDate, DateOfBirth = assessment.Patient.DOB };

            var evaluator = new SeriesEvaluator { PatientSeries = series, ImmunizationHistory = doses };
            evaluator.Evaluate(options);

            Assert.AreEqual(PatientSeriesStatus.NotComplete, series.Status);
            //Assert.AreEqual(doses[0].EvaluationStatus, EvaluationStatus.Valid);
            //Assert.AreEqual(doses[1].EvaluationStatus, EvaluationStatus.NotValid);
            //Assert.AreEqual(doses[1].EvaluationReasons.First(), EvaluationReason.AgeTooYoung);
        }
    }
}
