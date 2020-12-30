using System;

namespace Cdsi.TestcaseLibrary
{
    public interface IDose
    {
        string CVX { get;  }
        DateTime DateAdministered { get;  }
        string EvaluationReason { get;  }
        string EvaluationStatus { get;  }
        string MVX { get;  }
        string VaccineName { get;  }
    }
}