namespace EnvironmentSystem.Models
{
    using EnvironmentSystem.Interfaces;

    public class CollisionInfo
    {
        public CollisionInfo(ICollidable hitObject)
        {
            this.HitObject = hitObject;
        }

        public ICollidable HitObject { get; private set; }
    }
}