using Cdsi.SupportingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests.SupportingData
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void LoadAntigen()
        {
            var result = Load.Antigen("HepB");

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void LoadSchedules()
        {
            var result = Load.Schedule();

            Assert.IsNotNull(result);
        }
    }
}
