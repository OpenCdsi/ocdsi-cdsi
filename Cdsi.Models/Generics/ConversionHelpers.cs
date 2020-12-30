using Cdsi.ReferenceData;

namespace Cdsi.Models.Generics
{
    public static class ConversionHelpers
    {
        public static IVaccineDose ToVaccineDose(this TestcaseData.Dose dose)
        {
            return new VaccineDose()
            {
                DateAdministered = dose.Date_Administered,
                CVX = dose.CVX,
                MVX = dose.MVX,
                VaccineDescription = Reference.Schedule.cvxToAntigenMap.GetVaccineDescription(dose.CVX),
                VaccineType = Reference.Schedule.GetVaccineType(dose.CVX)
            };
        }
    }
}
