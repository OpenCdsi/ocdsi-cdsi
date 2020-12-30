using System.Collections.Generic;

namespace Cdsi.TestcaseLibrary
{
    public interface IEvaluation
    {
        IEnumerable<Dose> AdministeredDoses { get;  }
        string SeriesStatus { get;  }
    }
}