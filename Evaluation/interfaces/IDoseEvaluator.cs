
namespace OpenCdsi.Cdsi
{
    public interface IDoseEvaluator
    {
        LinkedListNode<ITargetDose> TargetDose { get; }

      void Evaluate(LinkedListNode<IAntigenDose> dose);
    }
}