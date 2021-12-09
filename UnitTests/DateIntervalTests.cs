using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class DateIntervalTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }
        [TestMethod]
        public void CanParsetheFirstInterval()
        {
            var text = "6 years plus some bogus data";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }

        [TestMethod]
        public void CanParseMultipleIntervals()
        {
            var text = "6 years - 4 days";
            var intervals = Interval.ParseAll(text);
            Assert.AreEqual(6, intervals.First().Duration);
            Assert.AreEqual(IntervalUnit.Day, intervals.Second().Unit);
        }

        // Table 3-6
        [TestMethod]
        public void CALCDT_1()
        {
            // 01/01/2000 + 3 years = 01/01/2003
            var d = new DateTime(2000, 1, 1);
            var i = Interval.Parse("3 years");
            Assert.AreEqual(new DateTime(2003, 1, 1), d + i);
        }

        [TestMethod]
        public void CALCDT_2a()
        {
            // 01/01/2000 + 6 months = 07/01/2000
            var d = new DateTime(2000, 1, 1);
            var i = Interval.Parse("6 months");
            Assert.AreEqual(new DateTime(2000, 7, 1), d + i);
        }

        [TestMethod]
        public void CALCDT_2b()
        {
            // 11/01/2000 + 6 months = 05/01/2001
            var d = new DateTime(2000, 11, 1);
            var i = Interval.Parse("6 months");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2001, 5, 1), d + i);
=======
            Assert.AreEqual(new System.DateTime(2001, 5, 1), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_3a()
        {
            // 01/01/2000 + 3 days = 01/04/2000
            var d = new DateTime(2000, 1, 1);
            var i = Interval.Parse("3 days");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2000, 1, 4), d + i);
=======
            Assert.AreEqual(new System.DateTime(2000, 1, 4), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_3b()
        {
            // 01/01/2000 + 3 weeks = 01/22/2000
            var d = new DateTime(2000, 1, 1);
            var i = Interval.Parse("3 week");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2000, 1, 22), d + i);
=======
            Assert.AreEqual(new System.DateTime(2000, 1, 22), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_3c()
        {
            // 02/01/2000 + 5 weeks = 03/07/2000(leap year)
            var d = new DateTime(2000, 2, 1);
            var i = Interval.Parse("5 week");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2000, 3, 7), d + i);
=======
            Assert.AreEqual(new System.DateTime(2000, 3, 7), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_3d()
        {
            // 02/01/2001 + 5 weeks = 03/08/2001(no leap year)
            var d = new DateTime(2001, 2, 1);
            var i = Interval.Parse("5 week");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2001, 3, 8), d + i);
=======
            Assert.AreEqual(new System.DateTime(2001, 3, 8), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_4()
        {
            // 01/15/2000 – 4 days = 01/11/2000
            var d = new DateTime(2000, 1, 15);
            var i = Interval.Parse("- 4 days");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2000, 1, 11), d + i);
=======
            Assert.AreEqual(new System.DateTime(2000, 1, 11), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_5a()
        {
            // 03/31/2000 + 6 months = 10/01/2000 (September 31 does not exist)
            var d = new DateTime(2000, 3, 31);
            var i = Interval.Parse("6 months");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2000, 10, 1), d + i);
=======
            Assert.AreEqual(new System.DateTime(2000, 10, 1), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void CALCDT_5b()
        {
            // 08/31/2000 + 6 months = 03/01/2001 (February 31 does not exist)
            var d = new DateTime(2000, 8, 31);
            var i = Interval.Parse("6 month");
<<<<<<< HEAD
            Assert.AreEqual(new DateTime(2001, 3, 1), d + i);
=======
            Assert.AreEqual(new System.DateTime(2001, 3, 1), d + i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }

        [TestMethod]
        public void JuneMinus6MonthsIsDecember()
        {
<<<<<<< HEAD
            var d = new DateTime(2020, 6, 9);
            var i = Interval.Parse("6 month");
            Assert.AreEqual(new DateTime(2019, 12, 10), d - i);
=======
            var d = new System.DateTime(2020, 6, 9);
            var i = Interval.Parse("6 month");
            Assert.AreEqual(new System.DateTime(2019, 12, 10), d - i);
>>>>>>> 05cb7d9137818dc5660e777ea8927f5fe5039fba
        }
    }
}

