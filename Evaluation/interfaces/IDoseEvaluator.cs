
namespace OpenCdsi.Cdsi.Evaluation
{
    public interface IDoseEvaluator
    {
        ITargetDose TargetDose { get; set; }
        IAntigenDose AntigenDose { get; set; }
    }
}