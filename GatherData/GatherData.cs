using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public class DataGatherer
    {
        public IPatient Patient { get; init; }

        /// <summary>
        /// Cdsi Logic Spec 4.1 Section 4-3
        /// </summary>
        public IEnumerable<IAntigenDose> OrganizeImmunizationHistory()
        {
            return Patient.VaccineHistory
                   .SelectMany(x => AsAntigenDose(x))
                   .OrderBy(x => x.AntigenName)
                   .ThenBy(x => x.VaccineDose.DateAdministered)
                   .ToList();
        }

        public IEnumerable<IAntigenDose> AsAntigenDose(IVaccineDose dose)
        {
            return SupportingData.Schedule.Vaccines
                    .Get(dose.CVX)
                    .Assocations()
                    .Select(x => new AntigenDose
                    {
                        AntigenName = x.antigen,
                        VaccineDose = dose,
                        EvaluationStatus = EvaluationStatus.NotValid
                    });
        }
    }
}
