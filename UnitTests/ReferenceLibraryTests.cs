using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi.ReferenceLibrary;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class ReferenceLibraryTests
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
            Assert.AreEqual(key, data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanReadcheduleData()
        {
            var data = Reference.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}