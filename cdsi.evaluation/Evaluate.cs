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
        public static void EvaluateAge(this IEnv env, AdministeredDose administeredDose, TargetDose targetDose)
        {

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
