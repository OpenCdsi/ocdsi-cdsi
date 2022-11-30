using OpenCdsi.Calendar;
using OpenCdsi.Schedule;

namespace OpenCdsi.Cdsi
{
    public class DoseEvaluator : IDoseEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }
        public LinkedListNode<IAntigenDose> AdministeredDose { get; init; }

        private IEvaluationOptions _options;

        /// <summary>
        ///  Cdsi Logic Spec 4.1 - Section 6-10
        /// </summary>        
        public void Evaluate(IEvaluationOptions options)
        {
            _options = options;

            // short circuited evaluation halts
            if (CanBeEvaluated()
                && !CanSkip()
                && EvaluateAge()
                && (EvaluatePreferableInterval() || EvaluateAllowableInterval())
                && !EvaluateLiveVirusConflict()
                && (EvaluateForPreferableVaccine() || EvaluateForAllowableVaccine()))
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.Valid;
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
            var minDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().minAge, Date.MinValue);
            var maxDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().maxAge, Date.MaxValue);
            var absMinDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().absMinAge, Date.MinValue);

            var val = false;
            if (!val)
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.SubStandard;
            }
            return val;
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
