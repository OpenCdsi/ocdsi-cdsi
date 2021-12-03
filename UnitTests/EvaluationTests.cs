using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class EvaluationTests
    {
        [TestMethod]
        public void CanOrganizeImmunizationHistory()
        {
            var env = Library.Testcases["2013-0002"].CreateProcessingData();
            var sut= env.Doses.OrganizeImmunizationHistory().ToList();
            Assert.AreEqual(6, sut.Count());
            Assert.IsInstanceOfType(sut[0], typeof(AntigenDose));
        }
    }
}
