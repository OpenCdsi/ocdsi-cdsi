//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;

//namespace OpenCdsi.Cdsi.UnitTests
//{
//    [TestClass]
//    public class EvaluationTests
//    {
//        [TestMethod]
//        public void T20130001()
//        {
//            var env = new DoseTestEnv("2013-0001", "Diphtheria");
//            var eval = new DoseEvaluator
//            {
//                AntigenDose = null,
//                TargetDose = env.Targets.First()
//            };
//            eval.Evaluate();

//            Assert.AreEqual(TargetDoseStatus.NotSatisfied, eval.TargetDose.Status);
//        }

//        [TestMethod]
//        public void T20130002()
//        {
//            var env = new DoseTestEnv("2013-0002", "Diphtheria");
//            var eval = new DoseEvaluator
//            {
//                AntigenDose = env.Doses.First(),
//                TargetDose = env.Targets.First()
//            };
//            eval.Evaluate();

//            Assert.AreEqual(TargetDoseStatus.Satisfied, eval.TargetDose.Status);
//        }
//        [TestMethod]
//        public void CreateASeriesEvaluator()
//        {
//            var env = CaseLibrary.Cases["2013-0002"].GetEnv();
//            var antigen = SupportingData.Antigens["Measles"];
//            var series = antigen.series.First().ToModel();
//            var sut = new SeriesEvaluator
//            {
//                PatientSeries = series
//            };
//        }
//    }


//    //[TestMethod]
//    //public void CanEvaluatePatientSeries()
//    //{
//    //    var tcase = CaseLibrary.Cases["2013-0002"];
//    //    var doses = tcase.Doses.ToCdsiType();
//    //    var history = GatherData.OrganizeImmunizationHistory(doses);

//    //    var sut = CaseLibrary.Cases["2013-0002"]
//    //        .GetEnv()
//    //        .SelectRelevantPatientSeries()
//    //        .EvaluatePatientSeries()
//    //        .RelevantPatientSeries;
//    //}
//}
