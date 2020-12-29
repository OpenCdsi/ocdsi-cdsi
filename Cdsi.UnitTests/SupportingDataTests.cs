using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.SupportingData;

namespace cdsi.refData.tests
{
    [TestClass]
    public class SupportingDataTests
    {
        [TestMethod]
        public void AntigenNames()
        {
            var names = Cdsi.Reference.Antigen.Keys;
            Assert.AreEqual(24, names.Count);
            Assert.AreEqual("Cholera", names.First());
        }

        [TestMethod]
        public void CanParseAntigenData()
        {
            var data = Cdsi.Reference.Antigen["Cholera"];
            Assert.AreEqual("Cholera", data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanParseScheduleData()
        {
            var data = Cdsi.Reference.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
