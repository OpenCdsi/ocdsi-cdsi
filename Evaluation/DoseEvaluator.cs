using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public class DoseEvaluator : IDoseEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }
        public LinkedListNode<IAntigenDose> AdministeredDose { get; init; }

        /// <summary>
        ///  Cdsi Logic Spec 4.1 - Section 6-10
        /// </summary>        
        public void Evaluate()
        {
            // short circuited evaluation halts
            if (CanBeEvaluated()
                && !CanSkip()
                && EvaluateAge()
                && (EvaluatePreferableInterval() || EvaluateAllowableInterval())
                && !EvaluateLiveVirusConflict()
                && (EvaluateForPreferableVaccine() || EvaluateForAllowableVaccine()))
            {
                TargetDose.Value.Status = TargetDoseStatus.Satisfied;
            }
        }

        // Cdsi Logic Spec 4.1 - Section 6-1
        public bool CanBeEvaluated()
        {
            var val = AdministeredDose.Value.VaccineDose.DateAdministered <= AdministeredDose.Value.VaccineDose.LotExpiration
                && string.IsNullOrWhiteSpace(AdministeredDose.Value.VaccineDose.DoseCondition);
            if (!val)
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.SubStandard;
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
            var val = TargetDose.Value.SeriesDose.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == AdministeredDose.Value.VaccineDose.VaccineType).Any();
            if (val)
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.NotValid;
                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.InadvertentAdministration);
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
