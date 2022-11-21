using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public static class SimpleEhrExt
    {
        public static IEnumerable<IAntigenDose> AsAntigenDoses(this IVaccineDose dose)
        {
            return SupportingData.Schedule.Vaccines
                    .Get(dose.CVX)
                    .Assocations()
                    .Select(x => new AntigenDose
                    {
                        AntigenName = x.antigen,
                        AdministeredDose = dose,
                        EvaluationStatus = EvaluationStatus.NotValid
                    });
        }

        public static IEnumerable<IAntigenDose> AsAntigenDoses(this IEnumerable<IVaccineDose> doses)
        {
            return doses.SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.AdministeredDose.DateAdministered);
        }
    }
}
