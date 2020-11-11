using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cdsi.evaluation
{
    public static class Evaluate
    {
        // Section 6.1
        public static void EvaluateDoseAdministeredCondition(this IEnv env, AdministeredDose administeredDose)
        {
            var administeredDate = env.Get<DateTime>("dateAdministered");
            if (administeredDate > administeredDose.LotExpiration || !string.IsNullOrEmpty(administeredDose.DoseCondition))
            {
                administeredDose.EvaluationStatus = EvaluationStatus.SubStandard;
            }
        }

        // Section 6.2
        public static void EvaluateConditionalSkip(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.3
        public static void EvaluateForInadvertentVaccine(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {
            if (targetDose.RefData.inadvertentVaccine.Select(d => d.vaccineType).Contains(administeredDose.VaccineType))
            {
                targetDose.Status = TargetDoseStatus.NotSatisfied;
                administeredDose.EvaluationStatus = EvaluationStatus.NotValid;
                administeredDose.EvaluationReasons.Add("Inadvertent administration");
            }
        }

        // Section 6.4
        public static void EvaluateAge(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose, AdministeredDose prevAdministeredDose)
        {
            var absMinAge = env.Get<DateTime>("dob").Add(targetDose.RefData.age[0].absMinAge, new DateTime(2999, 12, 31));
            var minAge = env.Get<DateTime>("dob").Add(targetDose.RefData.age[0].minAge, new DateTime(1900, 1, 1));
            var maxAge = env.Get<DateTime>("dob").Add(targetDose.RefData.age[0].maxAge, new DateTime(1900, 1, 1));

            if (administeredDose.DateAdministered < absMinAge)
            {
                administeredDose.EvaluationReasons.Add("Too young");
            }
            else if (absMinAge <= administeredDose.DateAdministered && administeredDose.DateAdministered < minAge)
            {
                if (prevAdministeredDose.EvaluationStatus == EvaluationStatus.NotValid && prevAdministeredDose.EvaluationReasons.Contains("Too young"))
                {
                    administeredDose.EvaluationReasons.Add("Too young");
                }
                else if (targetDose.RefData.doseNumber == "Dose 1")
                {
                    administeredDose.EvaluationReasons.Add("Grace period");
                }
                else
                {
                    administeredDose.EvaluationReasons.Add("Grace period");
                }
            }
            else
            {
                if (minAge <= administeredDose.DateAdministered && administeredDose.DateAdministered < maxAge)
                {
                    // dose administerd at valid age
                }
                else if (administeredDose.DateAdministered >= maxAge)
                {
                    administeredDose.EvaluationReasons.Add("Too old");
                }
            }
        }

        // Section 6.5
        public static void EvaluatePreferableInterval(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.6
        public static void EvaluateAllowableInterval(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.7
        public static void EvaluateLiveVirusConflict(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {


        }

        // Section 6.8
        public static void EvaluateForPreferableVaccine(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.9
        public static void EvaluateForAllowableVaccine(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.10
        public static void SatisfyTargetDose(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

        }
    }
}
