namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public abstract class MovingObject : EnvironmentObject
    {
        protected MovingObject(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height)
        {
            this.Direction = direction;
        }

        public Point Direction { get; private set; }

        public override void Update()
        {
            this.Bounds.TopLeft.X += this.Direction.X;
            this.Bounds.TopLeft.Y += this.Direction.Y;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {   
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
