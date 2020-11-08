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
            var antigen = SupportingData.Antigen["Cholera"];
            var patientseries = new PatientSeries(antigen.series[0]);
            Assert.AreEqual(1, patientseries.Count);
            Assert.AreEqual(1, patientseries[0].DoseNumber);
        }

        [TestMethod]
        public void CanCreateFromAntigenName()
        {
            var patientseries = new PatientSeries("Cholera");
            Assert.AreEqual(1, patientseries.Count);
            Assert.AreEqual(1, patientseries[0].DoseNumber);
        }
    }
}
