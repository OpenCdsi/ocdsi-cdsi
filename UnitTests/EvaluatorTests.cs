using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace OpenCdsi.Cdsi.UnitTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void CreateASeriesEvaluator()
        {
            var env = CaseLibrary.Cases["2013-0002"].GetEnv();
            var antigen = SupportingData.Antigens["Measles"];
            var series = antigen.series.First().ToModel();
            var sut = new SeriesEvaluator
            {
                PatientSeries = series
            };
        }
    }
}
