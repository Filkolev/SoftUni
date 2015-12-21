namespace Blobs.Contracts
{
    public interface IAttacker
    {
        int Damage { get; set; }

        string AttackType { get; }

        IAttack ProduceAttack();
    }
}
