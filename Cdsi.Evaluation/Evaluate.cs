using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cdsi.Models;

namespace Cdsi.Evaluation
{
    public static class Evaluate
    {
        // Section 6.1
        public static bool CanBeEvaluated(this IAdministeredDose administeredDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.2
        public static bool CanSkip(this ITargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.3
        public static bool IsInadvertentVaccine(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.4
        public static void EvaluateAge(this IAdministeredDose administeredDose, ITargetDose targetDose, IAdministeredDose prevAdministeredDose)
        {
        }

        // Section 6.5
        public static void EvaluatePreferableInterval(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {

        }

        // Section 6.6
        public static void EvaluateAllowableInterval(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {

        }

        // Section 6.7
        public static void EvaluateLiveVirusConflict(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {


        }

        // Section 6.8
        public static void EvaluateForPreferableVaccine(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {

        }

        // Section 6.9
        public static void EvaluateForAllowableVaccine(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {

        }

        // Section 6.10
        public static void SatisfyTargetDose(this IAdministeredDose administeredDose, ITargetDose targetDose)
        {

        }
    }
}
