namespace OpenCdsi.Cdsi
{
    public static class OrganizeDataExt
    {
        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IEnv OrganizeImmunizationHistory(this IEnv env)
        {
            var patient = env.Patient;

            var immunizationHistory = patient.VaccineHistory
                .SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.VaccineDose.DateAdministered)
                .ToList();

            env.ImmunizationHistory = immunizationHistory;

            return env;
        }
    }
}
