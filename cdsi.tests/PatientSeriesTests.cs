using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using cdsi.refData;
using cdsi.evaluation;

namespace cdsi.refData.tests
{
    [TestClass]
    public class PatientSeriesTests
    {
        [TestMethod]
        public void CanCreateFromAntigenSeries()
        {
            var patientseries = new PatientSeries("Cholera");
            Assert.AreEqual(1, patientseries.Count);
        }
    }
}
