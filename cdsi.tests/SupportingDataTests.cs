using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using cdsi.refData;

namespace cdsi.refData.tests
{
    [TestClass]
    public class SupportingDataTests
    {
        [TestMethod]
        public void AntigenNames()
        {
            var names = SupportingData.Antigen.Keys;
            Assert.AreEqual(24, names.Count);
            Assert.AreEqual("Cholera", names.First());
        }

        [TestMethod]
        public void CanParseAntigenData()
        {
            var data = SupportingData.Antigen["Cholera"];
            Assert.AreEqual("Cholera", data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanParseScheduleData()
        {
            var data = SupportingData.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
