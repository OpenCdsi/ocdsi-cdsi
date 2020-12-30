using System;

namespace Cdsi.TestcaseLibrary
{
    public interface ITestcase
    {
        string CdcTestId { get;  }
        string ChangedInVersion { get;  }
        DateTime DateAdded { get;  }
        DateTime DateUpdated { get;  }
        Evaluation Evaluation { get;  }
        string EvaluationTestType { get;  }
        Forecast Forecast { get;  }
        string ForecastTestType { get;  }
        string GeneralDescription { get;  }
        Patient Patient { get;  }
        string ReasonForChange { get;  }
        string TestcaseName { get;  }
        string VaccineGroup { get;  }
    }
}