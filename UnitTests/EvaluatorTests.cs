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
            var env = Library.Testcases["2013-0002"].GetEnv();
            var antigen = Data.Antigen["Measles"];
            var series = antigen.series.First().ToModel();
            var sut = new SeriesEvaluator
            {
                PatientSeries = series
            };
        }
    }
}
