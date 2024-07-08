using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocdsi.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocdsi.UnitTests.Calendar
{
    [TestClass]
    public class DateTimeTests
    {
        // Table 3-6
        [TestMethod]
        public void CALCDT_1()
        {
            // 01/01/2000 + 3 years = 01/01/2003
            var d = new DateTime(2000, 1, 1);
            var result = d.Add("3 years");
            Assert.AreEqual(new DateTime(2003, 1, 1), result);
        }

        [TestMethod]
        public void CALCDT_3c()
        {
            // 02/01/2000 + 5 weeks = 03/07/2000(leap year)
            var d = new DateTime(2000, 2, 1);
            var result = d.Add("5 weeks");
            Assert.AreEqual(new DateTime(2000, 3, 7), result);
        }

        [TestMethod]
        public void ClampMin()
        {
            var result = DateTime.MinValue.Clamp();
            Assert.AreEqual(new DateTime(1900, 1, 1), result);
        }

        [TestMethod]
        public void ClampMax()
        {
            var result = DateTime.MaxValue.Clamp();
            Assert.AreEqual(new DateTime(2999, 12, 31), result);
        }

        [TestMethod]
        public void TrapExceptionFromNull()
        {
            var result = DateTime.Now.Add(null, Date.MaxValue);
            Assert.AreEqual(Date.MaxValue, result);
        }

        [TestMethod]
        public void TrapExceptionFromEmpty()
        {
            var result = DateTime.Now.Add("", Date.MaxValue);
            Assert.AreEqual(Date.MaxValue, result);
        }
    }
}
