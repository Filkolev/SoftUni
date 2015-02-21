namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;
    using Data.Structures;

    public class Snowflake : MovingObject
    {
        protected const char SnowflakeCharImage = '*';

        public Snowflake(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground || collisionInfo.HitObject is Snow)
            {
                this.Exists = false;
            }
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { SnowflakeCharImage } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists)
            {
                return new List<EnvironmentObject>() { new Snow(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Width, this.Bounds.Height) };
            }

            return new List<EnvironmentObject>();
        }
    }
}
