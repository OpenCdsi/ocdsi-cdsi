using Ocdsi.SupportingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests.SupportingData
{
    [TestClass]
    public class FileTests
    {

        [TestMethod]
        public void LoadAntigenDat() { 
            var path = Path.Combine(TestData.DatPath, TestData.AntigenDat);
            var finfo = new FileInfo(path);

            var deserializer = new XmlSerializer(typeof(antigenSupportingData));
            var schedule= (antigenSupportingData)deserializer.Deserialize(finfo.OpenRead());
            Assert.IsNotNull(schedule);

        }

        [TestMethod]
        public void LoadScheduleDat()
        {
            var path = Path.Combine(TestData.DatPath, TestData.ScheduleDat);
            var finfo = new FileInfo(path);

            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            var schedule = (scheduleSupportingData)deserializer.Deserialize(finfo.OpenRead());
            Assert.IsNotNull(schedule);
        }
    }
}
