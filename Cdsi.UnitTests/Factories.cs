using System.Collections.Generic;
using System.Linq;
using Cdsi.ReferenceData;

namespace Cdsi.UnitTests
{
    public static class Factories
    {
        public static Models.Patient ToModel(this TestcaseData.Patient patient)
        {
            return new Models.Patient(
                patient.DOB,
                patient.Gender,
                patient.Med_History_Text,
                patient.Med_History_Code,
                patient.Med_History_Code_Sys,
                patient.Assessment_Date
                );
        }

        public static IEnumerable<Models.AdministeredDose> ToModel(this IEnumerable<TestcaseData.Dose> doses)
        {
            return doses.SelectMany(x => x.ToModel());
        }

        public static IEnumerable<Models.AdministeredDose> ToModel(this TestcaseData.Dose dose)
        {
            var antigens = Reference.Schedule.cvxToAntigenMap.GetAntigens(dose.CVX);
            return antigens.Select(x => new Models.AdministeredDose(AntigenIdentifier.Parse(x), dose.Date_Administered, dose.CVX));
        }
    }
}
