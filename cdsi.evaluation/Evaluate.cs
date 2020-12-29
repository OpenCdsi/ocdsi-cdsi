using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cdsi.evaluation
{
    public static class Evaluate
    {
        // Section 6.1
        public static bool CanBeEvaluated(this AdministeredDose administeredDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.2
        public static bool CanSkip(this TargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.3
        public static bool IsInadvertentVaccine(this AdministeredDose administeredDose, TargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Section 6.4
        public static void EvaluateAge(this AdministeredDose administeredDose, TargetDose targetDose, AdministeredDose prevAdministeredDose)
        {
        }

        // Section 6.5
        public static void EvaluatePreferableInterval(this AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.6
        public static void EvaluateAllowableInterval(this AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.7
        public static void EvaluateLiveVirusConflict(this AdministeredDose administeredDose, TargetDose targetDose)
        {


        }

        // Section 6.8
        public static void EvaluateForPreferableVaccine(this AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.9
        public static void EvaluateForAllowableVaccine(this AdministeredDose administeredDose, TargetDose targetDose)
        {

        }

        // Section 6.10
        public static void SatisfyTargetDose(this AdministeredDose administeredDose, TargetDose targetDose)
        {

        }
    }
}
