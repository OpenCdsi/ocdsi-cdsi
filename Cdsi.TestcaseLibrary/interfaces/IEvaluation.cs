using System.Collections.Generic;

namespace Cdsi.TestcaseLibrary
{
    public interface IEvaluation
    {
        IEnumerable<IDose> AdministeredDoses { get; }
        string SeriesStatus { get; }
    }
}