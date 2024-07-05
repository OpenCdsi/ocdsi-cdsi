using Ocdsi.SupportingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ocdsi.UnitTests.SupportingData
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void LoadAntigen()
        {
            var repo = new Repository(TestData.ResourcePath);
            var result = repo.Antigen("HepB");

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void LoadSchedules()
        {
            var repo = new Repository(TestData.ResourcePath);
            var result = repo.Schedule();

            Assert.IsNotNull(result);
        }
    }
}
