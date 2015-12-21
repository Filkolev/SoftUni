namespace Blobs.Contracts
{
    using Models;

    public interface IBlob : IAttacker, IDefender, IUpdateable
    {
        string Name { get; }

        string BehaviorType { get; }

        void ActivateBehavior();

        event OnToggleBehaviorEventHandler OnToggleBehavior;

        event OnBlobDeathEventHandler OnBlobDeath;
    }
}
