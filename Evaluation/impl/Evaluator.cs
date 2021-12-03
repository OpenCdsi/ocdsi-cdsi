using System;
using System.Collections.Generic;

namespace Cdsi.Evaluation
{
    public class Evaluator
    {
        public IPatient Patient { get; set; }
        public IProcessingData ProcessingData { get; set; }
        public IEnumerable<IAntigenDose> AdministeredDoses { get; set; }
        public IEnumerable<ITargetDose> TargetDoses { get; set; }

        // Cdsi Logic Spec 4.1 - Section 6-1
        public bool CanBeEvaluated(IAntigenDose administeredDose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public bool CanSkip(ITargetDose targetDose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public bool IsInadvertentVaccine(IAntigenDose administeredDose, ITargetDose targetDose)
        {
            throw new NotImplementedException();
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
