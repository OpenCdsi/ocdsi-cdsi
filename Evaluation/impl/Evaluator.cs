using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdsi.Evaluation
{
    public class Evaluator
    {
        public IProcessingData ProcessingData { get; internal set; }

        public Evaluator(IProcessingData pd)
        {
            ProcessingData = pd;

            // Organize immunization history, Cdsi Logic Spec 4.1 Section 4-3
            var antigenDoses = pd.Patient.AdministeredVaccineDoses.OrganizeImmunizationHistory();

            // Select relevant patient series, Cdsi Logic Spec 4.1 Chapter 5.
            //
            // Note that other patient series' can be Add()ed to the processing data,
            // for example to evaluate/forecast newborns.
            var antigens = antigenDoses.Select(x => x.AntigenName).Distinct();
            foreach (var antigen in antigens)
            {
                var sda = SupportingData.Antigen[antigen];
                var rs = sda.series.Where(x => x.IsRelevantSeries(ProcessingData)).ToList();
                ProcessingData.RelevantPatientSeries.AddAll(rs.Select(x => x.ToModel(antigenDoses.Where(x => x.AntigenName == antigen))));
            }
        }

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
