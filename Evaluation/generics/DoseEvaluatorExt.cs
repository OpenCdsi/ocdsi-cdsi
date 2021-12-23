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
            throw new NotImplementedException();
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
        public static void EvaluateAge(this IDoseEvaluator _, IAntigenDose previousAntigenDose)
        {
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public static void EvaluatePreferableInterval(this IDoseEvaluator _)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public static void EvaluateAllowableInterval(this IDoseEvaluator _)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public static void EvaluateLiveVirusConflict(this IDoseEvaluator _)
        {


        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public static void EvaluateForPreferableVaccine(this IDoseEvaluator _)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public static void EvaluateForAllowableVaccine(this IDoseEvaluator _)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public static void SatisfyTargetDose(this IDoseEvaluator _)
        {

        }
    }
}
