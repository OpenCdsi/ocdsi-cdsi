
namespace OpenCdsi.Cdsi
{
    public interface IDoseEvaluator
    {
        LinkedListNode<ITargetDose> TargetDose { get; }
        LinkedListNode<IAntigenDose> AdministeredDose { get; }

        void Evaluate(IEvaluationOptions options);
    }
}