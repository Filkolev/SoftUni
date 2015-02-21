namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    class StarTrail : MovingObject
    {
        private const char StarDustImage = '.';

        public StarTrail(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
            this.Bounds.TopLeft.X += this.Direction.X;
            this.Bounds.TopLeft.Y += this.Direction.Y;

            if (this.Direction.X == 0 || this.Direction.Y == 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground || collisionInfo.HitObject is StarShrapnel)
            {
                this.Exists = false;
            }
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { StarDustImage } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
