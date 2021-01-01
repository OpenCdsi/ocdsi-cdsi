using System.Collections.Generic;
using System.Linq;
using Cdsi.Models;
using Cdsi.PrepareData;
using Cdsi.ReferenceLibrary;

namespace Cdsi.UnitTests
{
    public static class Factories
    {
        public static IPatient ToModel(this TestcaseLibrary.IPatient patient)
        {
            return new Patient()
            {
                DOB = patient.DOB,
                Gender = patient.Gender.ToLower().StartsWith("f") ? Gender.Female : Gender.Male,
                MedHistoryText = patient.MedHistoryText,
                MedHistoryCode = patient.MedHistoryCode,
                MedHistoryCodeSys = patient.MedHistoryCodeSys,
                AssessmentDate = patient.AssessmentDate
            };
        }

        public static IVaccineDose ToModel(this TestcaseLibrary.IDose dose)
        {
            return new VaccineDose()
            {
                CVX = dose.CVX,
                MVX = dose.MVX,
                DateAdministered = dose.DateAdministered,
                VaccineDescription = Reference.Schedule.GetVaccineDescription(dose.CVX),
                VaccineType = Reference.Schedule.GetVaccineType(dose.CVX)
            };
        }

        public static IEnumerable<IAntigenDose> ToModel(this IEnumerable<TestcaseLibrary.IDose> doses)
        {
            return doses.Select(x => x.ToModel()).SelectMany(x => x.ToAntigenDoses());
        }
    }
}
