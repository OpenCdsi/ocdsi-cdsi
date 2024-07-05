using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Ocdsi.Calendar;

namespace Ocdsi.UnitTests.Calendar
{
    [TestClass]
    public class SortingTests
    {
        internal List<CalendarUnit> SameUnitList()
        {
            return new List<CalendarUnit> { Defaults.Year * 12, Defaults.Year };
        }
        internal List<CalendarUnit> DifferentUnitList()
        {
            return new List<CalendarUnit> { Defaults.Week, Defaults.Year };
        }

        [TestMethod]
        public void SortCalendarUnits()
        {
            var components = SameUnitList();
            components.Sort(new CalendarUnitComparer());
            Assert.AreEqual(Defaults.Year, components.First());
            Assert.AreEqual(1, components.First().Value);
        }

        [TestMethod]
        public void SortByUnitName()
        {
            var components = DifferentUnitList();
            components.Sort(new CalendarlUnitNameComparer());
            Assert.AreEqual(Defaults.Year, components.First());
        }
    }
}
