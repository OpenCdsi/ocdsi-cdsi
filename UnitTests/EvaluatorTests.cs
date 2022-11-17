using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void CreateASeriesEvaluator()
        {
            var env = OpenCdsi.Library.Testcases["2013-0002"].GetEnv();
            var antigen = OpenCdsi.Data.Antigen["Measles"];
            var series = antigen.series.First().ToModel();
            var sut = new SeriesEvaluator
            {
                PatientSeries = series
            };
        }
    }
}
