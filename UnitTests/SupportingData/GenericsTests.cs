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
    public class GenericsTests
    {
        [TestMethod]
        public void Cvx2Antigens()
        {
            var repo = new Repository(TestData.ResourcePath);
            var sched = repo.Schedule();

            var result = sched.AntigensByCvx("01").ToList();
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Diphtheria", result[0]);
        }
    }
}
