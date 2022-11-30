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
            else
            {
                AdministeredDose.Value.EvaluationStatus= EvaluationStatus.NotValid;
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
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;

            // The following notes reference Table 6-16 Was the vaccine dose administered at a valid age?
            // The decision table was drawn as a decision tree and the tree was optimized my removing
            // implicit branches.

            // Conditon 2
            if (absMinDate <= adminDate && adminDate < minDate)
            {
                // Conditon 5
                if (TargetDose.Previous == null)
                {
                    // Result 4
                    AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.AgeGracePeriod);
                    return true;
                }
                else
                {
                    // Condition 6
                    if (AdministeredDose.Previous != null
                        && AdministeredDose.Previous.Value.EvaluationStatus == EvaluationStatus.NotValid
                        && AdministeredDose.Previous.Value.VaccineDose.DateAdministered.Add("1 year") < adminDate)
                    {
                        // Result 2
                        AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.AgeTooYoung);
                        return false;
                    }
                    else
                    {
                        // Result 3
                        AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.AgeGracePeriod);
                        return true;
                    }
                }
            }
            else
            {
                // Conditon 3
                if (minDate <= adminDate && adminDate < maxDate)
                {
                    // Result 5
                    return true;
                }
                else
                {
                    // Conditon 4
                    if (adminDate >= maxDate)
                    {
                        // Result 6
                        AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.AgeTooOld);
                        return false;

                    }
                    else
                    {
                        // Result 1
                        AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.AgeTooYoung);
                        return false;
                    }
                }
            }

            throw new ApplicationException("Invalid decision table evaluation.");
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
