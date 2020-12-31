using System.Collections.Generic;

namespace Cdsi.TestcaseLibrary
{
    public class Evaluation : IEvaluation
    {
        public string SeriesStatus { get; set; }
        public IEnumerable<IDose> AdministeredDoses { get; set; }
    }
}
