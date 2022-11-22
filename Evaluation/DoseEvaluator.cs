namespace OpenCdsi.Cdsi
{
    public class DoseEvaluator : IDoseEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }

        public IAntigenDose Evaluate(LinkedListNode<IAntigenDose> dose)
        {
            throw new NotImplementedException();
        }

        // Cdsi Logic Spec 4.1 - Section 6-1
        public bool CanBeEvaluated(LinkedListNode<IAntigenDose> dose)
        {
            var administered = dose.Value;
            var vaccine = dose.Value.VaccineDose;

            var val = vaccine.DateAdministered <= vaccine.LotExpiration && string.IsNullOrWhiteSpace(vaccine.DoseCondition);
            if (!val)
            {
                administered.EvaluationStatus = EvaluationStatus.SubStandard;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-2
        public bool CanSkip(LinkedListNode<IAntigenDose> dose)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-3
        public bool IsInadvertentVaccine(LinkedListNode<IAntigenDose> dose)
        {
            var target = TargetDose.Value;
            var administered = dose.Value;

            var val = target.SeriesDose.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == administered.VaccineDose.VaccineType).Any();
            if (val)
            {
                administered.EvaluationStatus = EvaluationStatus.NotValid;
                administered.EvaluationReason = Reasons.InadvertentAdministration;
                target.Status = TargetDoseStatus.NotSatisfied;
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-4
        public bool EvaluateAge(LinkedListNode<IAntigenDose> dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public bool EvaluatePreferableInterval(LinkedListNode<IAntigenDose> dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public bool EvaluateAllowableInterval(LinkedListNode<IAntigenDose> dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public bool EvaluateLiveVirusConflict(LinkedListNode<IAntigenDose> dose)
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public bool EvaluateForPreferableVaccine(LinkedListNode<IAntigenDose> dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public bool EvaluateForAllowableVaccine(LinkedListNode<IAntigenDose> dose)
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-10
        public bool SatisfyTargetDose(LinkedListNode<IAntigenDose> dose)
        {
            ////  will short circuit so some status' might not get set correctly.
            //// need to evaluate and later check the result?
            //var val = dose.EvaluateAge(null)
            //    && dose.EvaluatePreferableInterval()
            //    && dose.EvaluateAllowableInterval()
            //    && !dose.EvaluateLiveVirusConflict()
            //    && dose.EvaluateForPreferableVaccine()
            //    && dose.EvaluateForAllowableVaccine();

            //if (val)
            //{
            //    TargetDose.Status = TargetDoseStatus.Satisfied;
            //}

            //return val;
            throw new NotImplementedException();
        }

    }
}
