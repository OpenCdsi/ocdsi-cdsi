using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.ReferenceLibrary;
using System.Collections.Generic;

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
        }

        [TestMethod]
        public void CanReadAntigenData()
        {
            var key = "Cholera";
            var data = Reference.Antigen[key];
            Assert.AreEqual("Cholera", data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanReadcheduleData()
        {
            var data = Reference.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
