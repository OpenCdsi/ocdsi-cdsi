using Cdsi.SupportingData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.UnitTests.Evaluation
{
    [TestClass]
    public class ConditionalSkip
    {
        public antigenSupportingDataSeriesSeriesDoseConditionalSkip Context { get; private set; }
        public EvaluationOptions Options { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Context = Load.Json<antigenSupportingDataSeriesSeriesDoseConditionalSkip>("conditionalskip.json");
            Options = Load.Json<EvaluationOptions>("evaluatoroptions.json");
        }
    }
}
