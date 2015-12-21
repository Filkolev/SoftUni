namespace Blobs.Contracts
{
    public interface IDefender
    {
        int Health { get; set; }

        bool IsAlive { get; }
    }
}
