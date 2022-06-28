using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi.SupportingData;

using System.Linq;
using System.Collections.Generic;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class DoseEvaluationTests
    {
        [TestMethod]
        public void T20130001()
        {
            var env = new DoseTestEnv("2013-0001", "Diphtheria");
            var eval = new DoseEvaluator
            {
                AntigenDose = null,
                TargetDose = env.Targets.First()
            };
            eval.Evaluate();

            Assert.AreEqual(TargetDoseStatus.NotSatisfied, eval.TargetDose.Status);
        }

        [TestMethod]
        public void T20130002()
        {
            var env = new DoseTestEnv("2013-0002", "Diphtheria");
            var eval = new DoseEvaluator
            {
                AntigenDose = env.Doses.First(),
                TargetDose = env.Targets.First()
            };
            eval.Evaluate();

            Assert.AreEqual(TargetDoseStatus.Satisfied, eval.TargetDose.Status);
        }
    }
}
