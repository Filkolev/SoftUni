namespace EnvironmentSystem.Interfaces
{
    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Data.Structures;

    public interface ICollidable
    {
        Rectangle Bounds { get; }

        CollisionGroup CollisionGroup { get; }

        void RespondToCollision(CollisionInfo collisionInfo);
    }
}