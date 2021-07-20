using System.Collections.Generic;

namespace Cdsi.ReferenceLibrary
{
    public interface IEvaluation
    {
        IEnumerable<IDose> AdministeredDoses { get; }
        string SeriesStatus { get; }
    }
}