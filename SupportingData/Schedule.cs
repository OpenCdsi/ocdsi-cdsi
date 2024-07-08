using Ocdsi.SupportingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
    public static class Schedule
    {
        private static scheduleSupportingData repository;

        public static scheduleSupportingDataLiveVirusConflict[] LiveVirusConflicts => repository.liveVirusConflicts;

        public static scheduleSupportingDataCvxMap[] Vaccines => repository.cvxToAntigenMap;
        public static void Initialize(Repository repository)
        {
            Schedule.repository = repository.Schedule();
        }
        public static void Initialize(string resourcePath)
        {
            Initialize(new Repository(resourcePath));
        }
    }
}
