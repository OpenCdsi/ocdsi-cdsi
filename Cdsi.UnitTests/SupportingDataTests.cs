using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.SupportingData;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class SupportingDataTests
    {
        [TestMethod]
        public void AntigenNames()
        {
            var names = Reference.Antigen.Keys;
            Assert.AreEqual(23, names.Count);
            Assert.IsTrue(names.Contains("Cholera"));
        }

        [TestMethod]
        public void CanParseAntigenData()
        {
            var data = Reference.Antigen["Cholera"];
            Assert.AreEqual("Cholera", data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanParseScheduleData()
        {
            var data = Reference.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
