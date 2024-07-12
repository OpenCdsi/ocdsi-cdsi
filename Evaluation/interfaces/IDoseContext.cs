
namespace Cdsi
{
    public interface IDoseContext
    {
        LinkedListNode<ITargetDose> TargetDose { get; }
        LinkedListNode<IAntigenDose> AdministeredDose { get; }
    }
}