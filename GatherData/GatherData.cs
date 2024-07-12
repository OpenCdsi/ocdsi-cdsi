using Cdsi.SupportingData;

namespace Cdsi
{
    public class DataGatherer
    {
        public IPatient Patient { get; init; }

        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        public IEnumerable<IAntigenDose> OrganizeImmunizationHistory()
        {
            var antigenDoses = Patient.VaccineHistory.SelectMany(x => AsAntigenDose(x));
            return antigenDoses
                .OrderBy(x => x.AntigenName)
                   .ThenBy(x => x.VaccineDose.DateAdministered)
                   .ToList();
        }

        public IEnumerable<IAntigenDose> AsAntigenDose(IVaccineDose dose)
        {
            var vaccine = Schedule.Vaccines.FirstOrDefault(x => x.cvx == dose.CVX);
            return vaccine
                .association
                    .Select(x => new AntigenDose
                    {
                        AntigenName = x.antigen,
                        VaccineDose = dose
                    });
        }
    }
}
