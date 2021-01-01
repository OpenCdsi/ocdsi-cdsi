using System;
using Cdsi.Models;

namespace Cdsi.Evaluation
{
    public static class Evaluate
    {
        // Cdsi Logic Spec 4.1 - Section 6-1
        public static bool CanBeEvaluated(this IAntigenDose administeredDose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public static bool CanSkip(this ITargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public static bool IsInadvertentVaccine(this IAntigenDose administeredDose, ITargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-4
        public static void EvaluateAge(this IAntigenDose administeredDose, ITargetDose targetDose, IAntigenDose prevAdministeredDose)
        {
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public static void EvaluatePreferableInterval(this IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public static void EvaluateAllowableInterval(this IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public static void EvaluateLiveVirusConflict(this IAntigenDose administeredDose, ITargetDose targetDose)
        {


        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public static void EvaluateForPreferableVaccine(this IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public static void EvaluateForAllowableVaccine(this IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public static void SatisfyTargetDose(this IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }
    }
}
