
namespace Cdsi
{
    public interface IDoseEvaluator
    {
        bool CanBeEvaluated(IAntigenDose antigenDose);
        bool CanSkip(ITargetDose targetDose);
        void EvaluateAge(IAntigenDose administeredDose, ITargetDose targetDose, IAntigenDose prevAdministeredDose);
        void EvaluateAllowableInterval(IAntigenDose administeredDose, ITargetDose targetDose);
        void EvaluateForAllowableVaccine(IAntigenDose administeredDose, ITargetDose targetDose);
        void EvaluateForPreferableVaccine(IAntigenDose administeredDose, ITargetDose targetDose);
        void EvaluateLiveVirusConflict(IAntigenDose administeredDose, ITargetDose targetDose);
        void EvaluatePreferableInterval(IAntigenDose administeredDose, ITargetDose targetDose);
        bool IsInadvertentVaccine(IAntigenDose administeredDose, ITargetDose targetDose);
        void SatisfyTargetDose(IAntigenDose administeredDose, ITargetDose targetDose);
    }
}