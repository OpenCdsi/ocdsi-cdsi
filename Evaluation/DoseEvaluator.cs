namespace OpenCdsi.Cdsi
{
    public class DoseEvaluator : IDoseEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }
        public LinkedListNode<IAntigenDose> AdministeredDose { get; init; }
        internal ITargetDose target => TargetDose.Value;
        internal IAntigenDose administered => AdministeredDose.Value;

        /// <summary>
        ///  Cdsi Logic Spec 4.1 - Section 6-10
        /// </summary>        
        public void Evaluate()
        {
            // short circuited evaluation halts the evaluation 
            if (CanBeEvaluated()
                && !CanSkip()
                && EvaluateAge()
                && (EvaluatePreferableInterval() || EvaluateAllowableInterval())
                && !EvaluateLiveVirusConflict()
                && (EvaluateForPreferableVaccine() || EvaluateForAllowableVaccine()))
            {
                target.Status = TargetDoseStatus.Satisfied;
            }
        }

        // Cdsi Logic Spec 4.1 - Section 6-1
        public bool CanBeEvaluated()
        {
            var vaccine = administered.VaccineDose;

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
        public bool IsInadvertentVaccine()
        {
            var series = target.SeriesDose;

            var val = series.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == administered.VaccineDose.VaccineType).Any();
            if (val)
            {
                administered.EvaluationStatus = EvaluationStatus.NotValid;
                administered.EvaluationReasons.Add(EvaluationReason.InadvertentAdministration);
            }
            return val;
        }

        // Cdsi Logic Spec 4.1 - Section 6-4
        public bool EvaluateAge()
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-5
        public bool EvaluatePreferableInterval()
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-6
        public bool EvaluateAllowableInterval()
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-7
        public bool EvaluateLiveVirusConflict()
        {
            return false;
        }

        // Cdsi Logic Spec 4.1 - Section 6-8
        public bool EvaluateForPreferableVaccine()
        {
            return true;
        }

        // Cdsi Logic Spec 4.1 - Section 6-9
        public bool EvaluateForAllowableVaccine()
        {
            return true;
        }
    }
}
