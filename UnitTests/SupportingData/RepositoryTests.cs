using Ocdsi.SupportingData;
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
            var repo = new Repository(TestData.DatPath);
            var result = repo.Antigen("HepB");
        }
        [TestMethod]
        public void LoadSchedules()
        {
            var repo = new Repository(TestData.DatPath);
            var result = repo.Schedule();
        }
    }
}
