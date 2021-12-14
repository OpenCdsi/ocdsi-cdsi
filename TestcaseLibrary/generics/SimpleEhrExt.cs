using Cdsi.TestcaseLibrary;

namespace Cdsi
{
    public static class SimpleEhrExt
    {
        public static IAssessment GetAssessment(this testcase tc)
        {
            return new Assessment
            {
                AssessmentDate = tc.AssessmentDate,
                Patient = tc.Patient.ToEhr(tc.Doses)
            };
        }
        public static IPatient ToEhr(this testcasePatient tp, IEnumerable<testcaseVaccineDoseAdministered> tvda)
        {
            var gender = tp.Gender.ToLower().First() switch
            {
                'f' => Gender.Female,
                'm' => Gender.Male,
                _ => Gender.Unknown
            };

            var patient = new Patient
            {
                DOB = tp.DOB,
                Gender = gender
            };

            patient.AdministeredVaccineDoses = tvda.Select(x => x.ToEhr()).ToList();

            return patient;
        }
        public static IVaccineDose ToEhr(this testcaseVaccineDoseAdministered dose)
        {
            return new VaccineDose
            {
                CVX = dose.CVX,
                MVX = dose.MVX,
                DateAdministered = dose.DateAdministered,
                LotExpiration = new DateTime(2999, 12, 31),
                VaccineType = dose.VaccineName
            };
        }
    }
}
