namespace Blobs.Contracts
{
    public interface IAttack
    {
        int Damage { get; }

        void ActivateEffects();
    }
}
