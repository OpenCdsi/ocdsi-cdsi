using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi.Calendar;
using System;

namespace Cdsi.UnitTests.Calendar
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var interval = CalendarUnit.Parse(text);
            Assert.AreEqual(6, interval.Value);
            Assert.AreEqual(UnitName.Year, interval.Name);
        }
        [TestMethod]
        public void CanParseAnIntervalWithJunkText()
        {
            var text = "6 years plus some junk text";
            var interval = CalendarUnit.Parse(text);
            Assert.AreEqual(6, interval.Value);
            Assert.AreEqual(UnitName.Year, interval.Name);
        }

        [TestMethod]
        public void CanParseDuration()
        {
            var text = "6 years - 4 days";
            var duration = Interval.Parse(text);
            Assert.AreEqual(6, duration.Components[0].Value);
            Assert.AreEqual(UnitName.Day, duration.Components[1].Name);
        }

        [TestMethod]
        public void CanParseOutOfOrderDuration()
        {
            var text = "- 4 days + 6 years ";
            var duration = Interval.Parse(text);
            Assert.AreEqual(6, duration.Components[0].Value);
            Assert.AreEqual(UnitName.Day, duration.Components[1].Name);
        }

        [TestMethod]
        public void ParseIntervalNullStringIsEmpty()
        {
            var text = "";
            CalendarUnit.TryParse(text, out var obj);
            Assert.AreEqual(CalendarUnit.Empty, obj);
        }

        [TestMethod]
        public void ParseDurationNullStringIsEmpty()
        {
            var text = "";
            Interval.TryParse(text, out var obj);
            Assert.AreEqual(Interval.Empty, obj);
        }

        [TestMethod]
        public void ParseManyNullStringIsEmpty()
        {
            var text = "";
            Assert.ThrowsException<FormatException>(() => CalendarUnit.Parse(text));
        }

        [TestMethod]
        public void ParseDateOfBirthString()
        {
            var str = "3/3/1942"; // i love you mom
            var sut = Date.Parse(str);
            Assert.AreEqual(DateTime.Parse(str), sut);
        }

        [TestMethod]
        public void ParseConditionalSkipDateString()
        {
            var str = "19420303";
            var sut = Date.Parse(str);
            Assert.AreEqual(DateTime.Parse("3/3/1942"), sut);
        }
    }
}

