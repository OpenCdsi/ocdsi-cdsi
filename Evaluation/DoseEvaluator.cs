namespace OpenCdsi.Cdsi
{
    public class DoseEvaluator : IDoseEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }

        /// <summary>
        ///  Cdsi Logic Spec 4.1 - Section 6-10
        /// </summary>
        /// <param name="dose"></param>
        public void Evaluate(LinkedListNode<IAntigenDose> dose)
        {
            if (CanBeEvaluated(dose))
            {
                // using short-circuited logical operators to halt the evaluation
                var val = EvaluateAge(dose)
                    && EvaluatePreferableInterval(dose)
                    && EvaluateAllowableInterval(dose)
                    && !EvaluateLiveVirusConflict(dose)
                    && EvaluateForPreferableVaccine(dose)
                    && EvaluateForAllowableVaccine(dose);

                if (val)
                {
                    TargetDose.Value.Status = TargetDoseStatus.Satisfied;
                }
            }
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
        public bool CanSkip()
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
                administered.EvaluationReason = EvaluationReasons.InadvertentAdministration;
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
    }
}
