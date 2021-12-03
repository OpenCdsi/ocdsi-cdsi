using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Enum = Utility.Enum;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class UtilityTests
    {
        const string TID = "2013-0002";

        [TestMethod]
        public void CanParseGenderFromString()
        {
            var sut = Enum.TryParse<Gender>("Male");
            Assert.AreEqual(Gender.Male, sut);
        }

        [TestMethod]
        public void CanParseGenderFromNullOrEmptyString()
        {
            var sut = Enum.TryParse<Gender>("");
            Assert.AreEqual(Gender.Unknown, sut);

            sut = Enum.TryParse<Gender>(null);
            Assert.AreEqual(Gender.Unknown, sut);
        }
    }
}
