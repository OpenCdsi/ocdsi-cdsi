
namespace OpenCdsi.Cdsi
{
    public interface IDoseEvaluator
    {
        LinkedListNode<ITargetDose> TargetDose { get; }
        LinkedListNode<IAntigenDose> AdministeredDose { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Success or failure</returns>
        bool Evaluate(IEvaluationOptions options);
    }
}