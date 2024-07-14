using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi.UnitTests.Evaluation
{
    [TestClass]
    public class EvaluationTests
    {
        [TestMethod]
        public void CanEvaluate_2013_0523()
        {
            RunEvaluation("2013-0523", "Measles", 0, (series, doses) =>
            {
                Assert.AreEqual(PatientSeriesStatus.NotComplete, series.Status);
                Assert.AreEqual(EvaluationStatus.Valid, doses[0].EvaluationStatus);
                Assert.AreEqual(TargetDoseStatus.Satisfied, series.TargetDoses.First().Status);
            });
        }


        [TestMethod]
        public void CanEvaluate_2013_0001()
        {
            RunEvaluation("2013-0001", "Diphtheria", 0, (series, doses) =>
            {
                Assert.AreEqual(PatientSeriesStatus.NotComplete, series.Status);
            });
        }

        [TestMethod]
        public void CanEvaluate_2013_0455()
        {
            RunEvaluation("2013-0455", "HPV", 0, (series, doses) =>
            {
                Assert.AreEqual(PatientSeriesStatus.Complete, series.Status);
            });
        }

        internal static void RunEvaluation(string caseId, string antigenName, int seriesIdx, Action<IPatientSeries, IList<IAntigenDose>> assertions)
        {
            // doses to evaluate
            var assessment = Load.Assessment(caseId);

            var gatherer = new DataGatherer { Patient = assessment.Patient };
            var doses = gatherer.OrganizeImmunizationHistory().Where(x => x.AntigenName == antigenName).ToList();

            // series to evaluate
            var antigen = Load.Antigen(antigenName);
            var series = PatientSeries.Create(antigen.series[seriesIdx]);

            // evaluation environment
            var options = new EvaluationOptions { AssessmentDate = assessment.AssessmentDate, DateOfBirth = assessment.Patient.DOB };

            var evaluator = new SeriesEvaluator { PatientSeries = series, ImmunizationHistory = doses };
            evaluator.Evaluate(options);

            assertions(series, doses);
        }
    }
}
