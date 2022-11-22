using Cdsi.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class EvaluationTests
    {
        [TestMethod]
        public void CanEvaluateStandardPatientSeries()
        {
            var testcase = TestInputs.CaseMMRa;
            // doses to evaluate
            var patient = testcase.Patient.ToCdsiType(testcase.Doses);
            var gatherer = new DataGatherer { Patient = patient };
            var doses = gatherer.OrganizeImmunizationHistory().Where(x => x.AntigenName == "Measles").ToList();
            // series to evaluate
            var antigen = SupportingData.Antigens["Measles"];
            var series = PatientSeries.Create(antigen.series[0]); // standard Measles 2-dose series

            var evaluator = new SeriesEvaluator { PatientSeries = series };
            evaluator.Evaluate(doses);

            Assert.AreEqual(PatientSeriesStatus.NotComplete, series.Status);
            Assert.AreEqual(doses[0].EvaluationStatus, EvaluationStatus.Valid);
            Assert.AreEqual(doses[1].EvaluationStatus, EvaluationStatus.NotValid);
            Assert.AreEqual(doses[1].EvaluationReason, EvaluationReasons.AgeTooYoung);
        }
    }
}
