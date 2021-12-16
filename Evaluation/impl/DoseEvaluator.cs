using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi
{
    public class DoseEvaluator
    {
        // Cdsi Logic Spec 4.1 - Section 6-1
        public bool CanBeEvaluated(IAntigenDose antigenDose)
        {
            var val = antigenDose.AdministeredDose.DateAdministered <= antigenDose.AdministeredDose.LotExpiration && string.IsNullOrWhiteSpace(antigenDose.AdministeredDose.DoseCondition);
            if (!val)
            {
                antigenDose.EvaluationStatus = EvaluationStatus.SubStandard;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public bool CanSkip(ITargetDose targetDose)
        {
            var val = true;
            if (val)
            {

            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public bool IsInadvertentVaccine(IAntigenDose administeredDose, ITargetDose targetDose)
        {
            var val = targetDose.SeriesDose.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == administeredDose.AdministeredDose.VaccineType).Any();
            if (val)
            {
                administeredDose.EvaluationStatus = EvaluationStatus.NotValid;
                administeredDose.EvaluationReason = "Inadvertent Administration";
                targetDose.Status = TargetDoseStatus.NotSatisfied;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-4
        public void EvaluateAge(IAntigenDose administeredDose, ITargetDose targetDose, IAntigenDose prevAdministeredDose)
        {
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public void EvaluatePreferableInterval(IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public void EvaluateAllowableInterval(IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public void EvaluateLiveVirusConflict(IAntigenDose administeredDose, ITargetDose targetDose)
        {


        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public void EvaluateForPreferableVaccine(IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public void EvaluateForAllowableVaccine(IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public void SatisfyTargetDose(IAntigenDose administeredDose, ITargetDose targetDose)
        {

        }
    }
}
