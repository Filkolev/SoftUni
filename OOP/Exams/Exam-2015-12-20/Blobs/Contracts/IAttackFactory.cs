namespace Blobs.Contracts
{
    public interface IAttackFactory
    {
        IAttack CreateAttack(string attackType, IBlob blob);
    }
}
