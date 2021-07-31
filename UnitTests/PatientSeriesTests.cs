using System.Linq;
using Cdsi.Evaluation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void CanCreateFromAntigenSeries()
        {
            var antigen = Reference.Antigen["Measles"];
            var sut = antigen.ToRelevantPatientSeries();
            Assert.AreEqual(1, sut.Count());
        }
    }
}
