namespace Blobs.Contracts
{
    public interface IBlobFactory
    {
        IBlob CreateBlob(
            string name,
            int health,
            int damage,
            string attackType,
            string behaviourType,
            IAttackFactory attackFactory,
            IBehaviorFactory behaviorFactory);
    }
}
