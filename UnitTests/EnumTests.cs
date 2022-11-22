using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        public void CanParseGenderFromString()
        {
            var sut = Parse.Enum<Gender>("Male");
            Assert.AreEqual(Gender.Male, sut);
        }

        [TestMethod]
        public void CanParseGenderFromNullOrEmptyString()
        {
            var sut = Parse.Enum<Gender>("");
            Assert.AreEqual(Gender.Any, sut);

            sut = Parse.Enum<Gender>(null);
            Assert.AreEqual(Gender.Any, sut);
        }
    }
}
