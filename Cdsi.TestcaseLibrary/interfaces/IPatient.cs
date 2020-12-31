using System;

namespace Cdsi.TestcaseLibrary
{
    public interface IPatient
    {
        DateTime AssessmentDate { get;  }
        DateTime DOB { get;  }
        string Gender { get;  }
        string MedHistoryCode { get;  }
        string MedHistoryCodeSys { get;  }
        string MedHistoryText { get;  }
    }
}