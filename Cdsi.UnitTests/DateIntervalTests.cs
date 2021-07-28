using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Cdsi.UnitTests
{
    [TestClass]
    public class DateIntervalTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var interval = IntervalParser.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }
        [TestMethod]
        public void CanParsetheFirstInterval()
        {
            var text = "6 years plus some bogus data";
            var interval = IntervalParser.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }

        [TestMethod]
        public void CanParseMultipleIntervals()
        {
            var text = "6 years - 4 days";
            var intervals = IntervalParser.ParseAll(text);
            Assert.AreEqual(6, intervals[0].Duration);
            Assert.AreEqual(IntervalUnit.Day, intervals[1].Unit);
        }

        // Table 3-6
        [TestMethod]
        public void CALCDT_1()
        {
            // 01/01/2000 + 3 years = 01/01/2003
            var d = new DateTime(2000, 1, 1);
            var i = IntervalParser.Parse("3 years");
            Assert.AreEqual(new DateTime(2003, 1, 1), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_2a()
        {
            // 01/01/2000 + 6 months = 07/01/2000
            var d = new DateTime(2000, 1, 1);
            var i = IntervalParser.Parse("6 months");
            Assert.AreEqual(new DateTime(2000, 7, 1), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_2b()
        {
            // 11/01/2000 + 6 months = 05/01/2001
            var d = new DateTime(2000, 11, 1);
            var i = IntervalParser.Parse("6 months");
            Assert.AreEqual(new DateTime(2001, 5, 1), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_3a()
        {
            // 01/01/2000 + 3 days = 01/04/2000
            var d = new DateTime(2000, 1, 1);
            var i = IntervalParser.Parse("3 days");
            Assert.AreEqual(new DateTime(2000, 1, 4), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_3b()
        {
            // 01/01/2000 + 3 weeks = 01/22/2000
            var d = new DateTime(2000, 1, 1);
            var i = IntervalParser.Parse("3 week");
            Assert.AreEqual(new DateTime(2000, 1, 22), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_3c()
        {
            // 02/01/2000 + 5 weeks = 03/07/2000(leap year)
            var d = new DateTime(2000, 2, 1);
            var i = IntervalParser.Parse("5 week");
            Assert.AreEqual(new DateTime(2000, 3, 7), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_3d()
        {
            // 02/01/2001 + 5 weeks = 03/08/2001(no leap year)
            var d = new DateTime(2001, 2, 1);
            var i = IntervalParser.Parse("5 week");
            Assert.AreEqual(new DateTime(2001, 3, 8), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_4()
        {
            // 01/15/2000 – 4 days = 01/11/2000
            var d = new DateTime(2000, 1, 15);
            var i = IntervalParser.Parse("- 4 days");
            Assert.AreEqual(new DateTime(2000, 1, 11), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_5a()
        {
            // 03/31/2000 + 6 months = 10/01/2000 (September 31 does not exist)
            var d = new DateTime(2000, 3, 31);
            var i = IntervalParser.Parse("6 months");
            Assert.AreEqual(new DateTime(2000, 10, 1), d.Add(i));
        }

        [TestMethod]
        public void CALCDT_5b()
        {
            // 08/31/2000 + 6 months = 03/01/2001 (February 31 does not exist)
            var d = new DateTime(2000, 8, 31);
            var i = IntervalParser.Parse("6 month");
            Assert.AreEqual(new DateTime(2001, 3, 1), d.Add(i));
        }
    }
}
