using System;
using System.Collections.Generic;
using System.Linq;
using Cdsi.SupportingData;

namespace Cdsi
{
    public static class DoseEvaluatorExt
    {
        // Cdsi Logic Spec 4.1 - Section 6-1
        public static bool CanBeEvaluated(this IDoseEvaluator dose)
        {
            if(dose.AntigenDose==null) return false;

            var administeredDose = dose.AntigenDose.AdministeredDose;

            var val = administeredDose.DateAdministered <= administeredDose.LotExpiration && string.IsNullOrWhiteSpace(administeredDose.DoseCondition);
            if (!val)
            {
                dose.AntigenDose.EvaluationStatus = EvaluationStatus.SubStandard;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public static bool CanSkip(this IDoseEvaluator dose)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public static bool IsInadvertentVaccine(this IDoseEvaluator dose)
        {
            var antigenDose = dose.AntigenDose;
            var targetDose = dose.TargetDose;

            var val = targetDose.SeriesDose.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == antigenDose.AdministeredDose.VaccineType).Any();
            if (val)
            {
                antigenDose.EvaluationStatus = EvaluationStatus.NotValid;
                antigenDose.EvaluationReason = "Inadvertent Administration";
                targetDose.Status = TargetDoseStatus.NotSatisfied;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-4
        public static bool EvaluateAge(this IDoseEvaluator dose, IAntigenDose previousAntigenDose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public static bool EvaluatePreferableInterval(this IDoseEvaluator dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public static bool EvaluateAllowableInterval(this IDoseEvaluator dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public static bool EvaluateLiveVirusConflict(this IDoseEvaluator dose)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public static bool EvaluateForPreferableVaccine(this IDoseEvaluator dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public static bool EvaluateForAllowableVaccine(this IDoseEvaluator dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public static bool SatisfyTargetDose(this IDoseEvaluator dose)
        {
            // this will short circuit so some status' might not get set correctly.
            // need to evaluate and later check the result?
            var val = dose.EvaluateAge(null)
                && dose.EvaluatePreferableInterval()
                && dose.EvaluateAllowableInterval()
                && !dose.EvaluateLiveVirusConflict()
                && dose.EvaluateForPreferableVaccine()
                && dose.EvaluateForAllowableVaccine();

            if (val)
            {
                dose.TargetDose.Status = TargetDoseStatus.Satisfied;
            }

            return val;
        }

    }
}
