using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public static class DoseEvaluatorExt
    {
        // Cdsi Logic Spec 4.1 - Section 6-1
        public static bool CanBeEvaluated(this IDoseEvaluator _)
        {
            if(_.AntigenDose==null) return false;

            var administeredDose = _.AntigenDose.AdministeredDose;

            var val = administeredDose.DateAdministered <= administeredDose.LotExpiration && string.IsNullOrWhiteSpace(administeredDose.DoseCondition);
            if (!val)
            {
                _.AntigenDose.EvaluationStatus = EvaluationStatus.SubStandard;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public static bool CanSkip(this IDoseEvaluator _)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public static bool IsInadvertentVaccine(this IDoseEvaluator _)
        {
            var antigenDose = _.AntigenDose;
            var targetDose = _.TargetDose;

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
        public static bool EvaluateAge(this IDoseEvaluator _, IAntigenDose previousAntigenDose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public static bool EvaluatePreferableInterval(this IDoseEvaluator _)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public static bool EvaluateAllowableInterval(this IDoseEvaluator _)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public static bool EvaluateLiveVirusConflict(this IDoseEvaluator _)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public static bool EvaluateForPreferableVaccine(this IDoseEvaluator _)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public static bool EvaluateForAllowableVaccine(this IDoseEvaluator _)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public static bool SatisfyTargetDose(this IDoseEvaluator _)
        {
            // this will short circuit so some status' might not get set correctly.
            // need to evaluate and later check the result?
            var val = _.EvaluateAge(null)
                && _.EvaluatePreferableInterval()
                && _.EvaluateAllowableInterval()
                && !_.EvaluateLiveVirusConflict()
                && _.EvaluateForPreferableVaccine()
                && _.EvaluateForAllowableVaccine();

            if (val)
            {
                _.TargetDose.Status = TargetDoseStatus.Satisfied;
            }

            return val;
        }

    }
}
