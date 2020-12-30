using System.Collections.Generic;

namespace Cdsi.TestcaseLibrary
{
    public class Evaluation : IEvaluation
    {
        public string SeriesStatus { get; internal set; }
        public IEnumerable<Dose> AdministeredDoses { get; internal set; }
    }
}
