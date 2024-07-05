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
        private static scheduleSupportingData data;

        public static scheduleSupportingDataLiveVirusConflict[] LiveVirusConflicts => data.liveVirusConflicts;

        public static scheduleSupportingDataCvxMap[] Vaccines => data.cvxToAntigenMap;
        public static void Initialize(Repository repository)
        {
            data = repository.Schedule();
        }
        public static void Initialize(string resourcePath)
        {
            Initialize(new Repository(resourcePath));
        }
    }
}
