
namespace OpenCdsi.Cdsi
{
    public interface IDoseEvaluator
    {
        LinkedListNode<ITargetDose> TargetDose { get; }

        IAntigenDose Evaluate(LinkedListNode<IAntigenDose> dose);
    }
}