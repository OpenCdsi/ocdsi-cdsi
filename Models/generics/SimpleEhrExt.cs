using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingDataLibrary;

namespace Cdsi
{
    public static class SimpleEhrExt
    {
        public static IEnumerable<IAntigenDose> AsAntigenDoses(this IVaccineDose dose)
        {
            return SupportingData.Schedule.GetAntigenNames(dose.CVX)
                .Select(x => new AntigenDose
                {
                    AntigenName = x,
                    AdministeredDose = dose,
                    EvaluationStatus = EvaluationStatus.NotValid
                })
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.AdministeredDose.DateAdministered);
        }
    }
}
