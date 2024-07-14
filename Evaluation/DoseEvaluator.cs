using Cdsi.Calendar;
using Cdsi.SupportingData;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cdsi
{
    public class DoseEvaluator : IDoseContext, IEvaluator
    {
        public LinkedListNode<ITargetDose> TargetDose { get; init; }
        public LinkedListNode<IAntigenDose> AdministeredDose { get; init; }

        private IEvaluationOptions _options;

        /// <summary>
        ///  Cdsi Logic Spec 4.3 - Section 6-10
        /// </summary>        
        public bool Evaluate(IEvaluationOptions options)
        {
            _options = options;

            // short circuited evaluation halts
            if (CanBeEvaluated()
                && !ConditionalSkip()
                && EvaluateAge()
                && (EvaluatePreferableInterval() || EvaluateAllowableInterval())
                && !EvaluateLiveVirusConflict()
                && (EvaluateForPreferableVaccine() || EvaluateForAllowableVaccine()))
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.Valid;
                TargetDose.Value.Status = TargetDoseStatus.Satisfied;
                TargetDose.Value.SatisfiedOn = AdministeredDose.Value.VaccineDose.DateAdministered;
            }
            else
            {
                AdministeredDose.Value.EvaluationStatus = EvaluationStatus.NotValid;
            }
            return true;
        }

        // Cdsi Logic Spec 4.3 - Section 6-1
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

        // Cdsi Logic Spec 4.3 - Section 6-2
        public bool ConditionalSkip()
        {
            var context = TargetDose.Value.SeriesDose.conditionalSkip
                        .Where(x => x.context == "Evaluation")
                        .FirstOrDefault();
          // /**
          //  * grab some data for testing
          //  */
          //var json= JsonSerializer.Serialize(context);
          //  File.WriteAllText("conditionalskip.json",json);
          //  json = JsonSerializer.Serialize(_options);
          //  File.WriteAllText("evaluatoroptions.json", json);
          //  json = JsonSerializer.Serialize(this);
          //  File.WriteAllText("doseevaluator.json", json);



            return context == null
                ? false
                : context.Evaluate(_options, this);
        }

        // Cdsi Logic Spec 4.3 - Section 6-3
        public bool IsInadvertentVaccine()
        {
            var val = TargetDose.Value.SeriesDose.inadvertentVaccine.Select(x => x.vaccineType).Where(x => x == AdministeredDose.Value.VaccineDose.VaccineType).Any();
            if (val)
            {
                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.InadvertentAdministration);
            }
            return val;
        }

        // Cdsi Logic Spec 4.3 - Section 6-4
        public bool EvaluateAge()
        {
            var minDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().minAge, Date.MinValue);
            var maxDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().maxAge, Date.MaxValue);
            var absMinDate = _options.DateOfBirth.Add(TargetDose.Value.SeriesDose.age.First().absMinAge, Date.MinValue);
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;

            // The following notes reference Table 6-16 Was the vaccine dose administered at a valid age?
            //
            // The decision table was drawn as a decision tree and the tree was optimized my removing
            // implicit branches. Conditions are the rows number 1-n while the results are the columns
            // numbered 1-n.

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

        // Cdsi Logic Spec 4.3 - Section 6-5
        public bool EvaluatePreferableInterval()
        {
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;
            var potentialIntervals = TargetDose.Value.SeriesDose.interval;

            if (potentialIntervals.Any(x=>!x.AllNullProperties()))
            {
                return potentialIntervals.All(x =>
                {
                    var refDoseDate = GetPrefereableIntervalReferenceDate(x);
                    var minDate = refDoseDate.Add(x.minInt, Date.MinValue);
                    var absMinDate = refDoseDate.Add(x.absMinInt, Date.MinValue);

                    // Condition 2
                    if (absMinDate <= adminDate && adminDate < minDate)
                    {
                        // Condition 4
                        if (TargetDose.Previous == null)
                        {
                            // Result 4
                            AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.IntervalGracePeriod);
                            return true;
                        }
                        else
                        {
                            // Condition 5
                            if (AdministeredDose.Previous != null
                                && AdministeredDose.Previous.Value.EvaluationStatus == EvaluationStatus.NotValid
                                && AdministeredDose.Previous.Value.VaccineDose.DateAdministered.Add("1 year") < adminDate)
                            {
                                // Result 2
                                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.IntervalTooSoon);
                                return false;
                            }
                            else
                            {
                                // Result 3
                                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.IntervalGracePeriod);
                                return true;
                            }
                        }
                    }
                    else
                    {
                        // Condition 1
                        if (adminDate < absMinDate)
                        {
                            // Result 1
                            AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.IntervalTooSoon);
                            return false;
                        }
                        else
                        {
                            // Condition 3
                            if (minDate < adminDate)
                            {
                                return true;
                            }
                            else
                            {
                                throw new ApplicationException("Invalid decision table evaluation.");
                            }
                        }
                    }
                });
            }
            else
            {
                return true;
            }

            throw new ApplicationException("Invalid decision table evaluation.");
        }

        // Cdsi Logic Spec 4.3 - Section 6-6
        public bool EvaluateAllowableInterval()
        {
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;
            var potentialIntervals = TargetDose.Value.SeriesDose.interval;

            return potentialIntervals.All(x =>
            {
                var refDoseDate = GetPrefereableIntervalReferenceDate(x);
                var absMinDate = refDoseDate.Add(x.absMinInt, Date.MinValue);

                if (adminDate < absMinDate)
                {
                    AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.IntervalTooSoon);
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }

        // Cdsi Logic Spec 4.3 - Section 6-7
        public bool EvaluateLiveVirusConflict()
        {
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;
            var currentVaccineType = AdministeredDose.Value.VaccineDose.VaccineType;
            var potentialConflicts = Schedule.LiveVirusConflicts.Where(x => x.current.vaccineType == currentVaccineType);

            // reference Tables 6-24,6-25,6-26,6-27

            // Condition 1
            if (potentialConflicts.Any())
            {
                // Condition 2
                if (AdministeredDose.Previous != null)
                {
                    var previous = AdministeredDose.Previous;
                    while (previous != null)
                    {
                        var conflict = potentialConflicts.FirstOrDefault(x => x.previous.vaccineType == previous.Value.VaccineDose.VaccineType);

                        // Condition 3
                        if (conflict != null)
                        {
                            var beginIntervalDate = previous.Value.VaccineDose.DateAdministered.Add(conflict.conflictBeginInterval, Date.MinValue);
                            var endIntervalDate = previous.Value.VaccineDose.DateAdministered.Add(conflict.conflictEndInterval, Date.MaxValue);

                            // Condition 4
                            if (beginIntervalDate <= adminDate && adminDate < endIntervalDate)
                            {
                                // Result 1
                                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.LiveVirusConflict);
                                return true;
                            }
                        }

                        previous = previous.Previous;
                    }
                    // Result 2
                    return false;
                }
                else
                {
                    // Result 2
                    return false;
                }
            }
            else
            {
                // Result 2
                return false;
            }

            throw new ApplicationException("Invalid decision table evaluation.");
        }

        // Cdsi Logic Spec 4.3 - Section 6-8
        public bool EvaluateForPreferableVaccine()
        {
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;
            var tradename = AdministeredDose.Value.VaccineDose.Tradename;
            var vol = AdministeredDose.Value.VaccineDose.Volume;
            var cvx = AdministeredDose.Value.VaccineDose.CVX;

            var potentialVaccines = TargetDose.Value.SeriesDose.preferableVaccine;

            if (potentialVaccines != null)
            {
                return potentialVaccines.Any(x =>
                {
                    var beginDate = _options.DateOfBirth.Add(x.beginAge, Date.MinValue);
                    var endDate = _options.DateOfBirth.Add(x.endAge, Date.MaxValue);

                    if (cvx == x.cvx)
                    {
                        if (beginDate <= adminDate && adminDate < endDate)
                        {
                            if (tradename == x.tradeName)
                            {
                                var prefVolume = 0;
                                int.TryParse(x.volume, out prefVolume);
                                if (vol < prefVolume)
                                {
                                    AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.VaccineLessThanRecommendedVolume);
                                }
                                return true;
                            }
                            else
                            {
                                AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.VaccineWrongTradename);
                                return false;
                            }
                        }
                        else
                        {
                            AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.VaccineOutOfAgeRange);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            throw new ApplicationException("Invalid decision table evaluation.");
        }

        // Cdsi Logic Spec 4.3 - Section 6-9
        public bool EvaluateForAllowableVaccine()
        {
            var adminDate = AdministeredDose.Value.VaccineDose.DateAdministered;
            var vtype = AdministeredDose.Value.VaccineDose.VaccineType;
            var potentialVaccines = TargetDose.Value.SeriesDose.allowableVaccine;

            return potentialVaccines.Any(x =>
            {
                var beginDate = _options.DateOfBirth.Add(x.beginAge, Date.MinValue);
                var endDate = _options.DateOfBirth.Add(x.endAge, Date.MaxValue);

                if (vtype == x.vaccineType)
                {
                    if (beginDate <= adminDate && adminDate < endDate)
                    {
                        return true;
                    }
                    else
                    {
                        AdministeredDose.Value.EvaluationReasons.Add(EvaluationReason.VaccineOutOfAgeRange);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            });
            throw new ApplicationException("Invalid decision table evaluation.");
        }

        internal DateTime GetPrefereableIntervalReferenceDate(antigenSupportingDataSeriesSeriesDoseAllowableInterval interval)
        {
            return interval.fromPrevious == "Y"
                ? GetRefDateFromPreviousDose()
                : GetRefDateFromTargetDose(interval.fromTargetDose);
        }

        internal DateTime GetPrefereableIntervalReferenceDate(antigenSupportingDataSeriesSeriesDoseInterval interval)
        {
            if (interval.fromPrevious == "Y")
            {
                return GetRefDateFromPreviousDose();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(interval.fromTargetDose))
                {
                    return GetRefDateFromTargetDose(interval.fromTargetDose);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(interval.fromMostRecent))
                    {
                        return GetRefDateFromMostRecent(interval.fromMostRecent);
                    }
                    else
                    {
                        if (interval.fromRelevantObs != null && !string.IsNullOrWhiteSpace(interval.fromRelevantObs.text)
                            && !string.IsNullOrWhiteSpace(interval.fromRelevantObs.code))
                        {
                            return GetRefDateFromObservation(interval.fromRelevantObs.code);
                        }
                    }
                }
            }
            return Date.MinValue;
        }

        public DateTime GetRefDateFromPreviousDose()
        {
            return AdministeredDose.Previous != null
                 && (AdministeredDose.Previous.Value.EvaluationStatus == EvaluationStatus.Valid
                 || AdministeredDose.Previous.Value.EvaluationStatus == EvaluationStatus.NotValid)
                 && !AdministeredDose.Previous.Value.EvaluationReasons.Contains(EvaluationReason.InadvertentAdministration)
                 ? AdministeredDose.Previous.Value.VaccineDose.DateAdministered
                 : Date.MinValue;
        }

        public DateTime GetRefDateFromTargetDose(string doseNumber)
        {
            var target = TargetDose.Previous;
            while (target != null)
            {
                if (target.Value.SeriesDose.doseNumber.Contains(doseNumber))
                {
                    return target.Value.SatisfiedOn;
                }
                target = target.Previous;
            }

            return Date.MinValue;
        }

        public DateTime GetRefDateFromMostRecent(string vaccineType)
        {
            var dose = AdministeredDose.Previous;
            while (dose != null)
            {
                if (dose.Value.VaccineDose.VaccineType == vaccineType)
                {
                    return dose.Value.VaccineDose.DateAdministered;
                }
                dose = dose.Previous;
            }

            return Date.MinValue;
        }

        public DateTime GetRefDateFromObservation(string code)
        {
            var obs = _options.Observations.Where(x => x.Code == code).FirstOrDefault();

            return obs != null
                ? obs.DateOfObservation
                : Date.MinValue;
        }
    }
}

