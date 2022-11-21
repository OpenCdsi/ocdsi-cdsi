
namespace OpenCdsi.Cdsi
{
    public interface IDoseEvaluator
    {
        ITargetDose TargetDose { get; set; }
        IAntigenDose AntigenDose { get; set; }
    }
}