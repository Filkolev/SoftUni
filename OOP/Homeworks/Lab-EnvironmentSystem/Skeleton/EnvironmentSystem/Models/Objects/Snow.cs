namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    class Snow : EnvironmentObject
    {
        protected const char SnowCharImage = '.';

        public Snow(int x, int y, int width, int height)
            :base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { SnowCharImage } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
