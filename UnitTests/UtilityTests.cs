using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCdsi.Cdsi.UnitTests
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
            Assert.AreEqual(Gender.Any, sut);

            sut = Enum.TryParse<Gender>(null);
            Assert.AreEqual(Gender.Any, sut);
        }
    }
}
