using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.SupportingData;
using Cdsi.ReferenceData;
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
            Assert.IsInstanceOfType(names.First(key => key.Name == "Cholera"), typeof(AntigenIdentifier));
        }

        [TestMethod]
        public void CanParseAntigenData()
        {
            var key = Reference.Antigen.Keys.First(key => key.Name == "Cholera");
            var data = Reference.Antigen[key];
            Assert.AreEqual("Cholera", data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanParseScheduleData()
        {
            var data = Reference.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }

        [TestMethod]
        public void CanEquateAntigenIdentifiers()
        {
            var a = AntigenIdentifier.Parse("COVID-19");
            var b = AntigenIdentifier.Parse("COVID-19");
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void CanSortAntigenIdentifiers()
        {
            AntigenIdentifier[] ids = { AntigenIdentifier.Parse("COVID-21"), AntigenIdentifier.Parse("COVID-20"), AntigenIdentifier.Parse("COVID-19") };
            var sut = ids.OrderBy(x => x.Name);
            Assert.AreEqual(ids.Last(), sut.First()); 
        }
    }
}
