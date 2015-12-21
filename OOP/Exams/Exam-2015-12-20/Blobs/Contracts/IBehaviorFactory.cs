namespace Blobs.Contracts
{
    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorType, IBlob blob);
    }
}